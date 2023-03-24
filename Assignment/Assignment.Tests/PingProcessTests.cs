using IntelliTect.TestTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment.Tests;

[TestClass]
public class PingProcessTests
{
    PingProcess Sut { get; set; } = new();

    [TestInitialize]
    public void TestInitialize()
    {
        Sut = new();
    }

    [TestMethod]
    public void Start_PingProcess_Success()
    {
        Process process = Process.Start("ping", "localhost");
        process.WaitForExit();
        Assert.AreEqual<int>(0, process.ExitCode);
    }

    [TestMethod]
    public void Run_GoogleDotCom_Success()
    {
        int exitCode = Sut.Run("google.com").ExitCode;
        Assert.AreEqual<int>(0, exitCode);
    }


    [TestMethod]
    public void Run_InvalidAddressOutput_Success()
    {
        (int exitCode, string? stdOutput) = Sut.Run("badaddress");
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.AreEqual<string?>(
            "Ping request could not find host badaddress. Please check the name and try again.".Trim(),
            stdOutput,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(1, exitCode);
    }

    [TestMethod]
    public void Run_CaptureStdOutput_Success()
    {
        //Arrange
        PingResult result = Sut.Run("localhost");
        
        //Assert
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void RunTaskAsync_Success()
    {
        //Arrange
        Task<PingResult> result = Sut.RunTaskAsync("localhost");
        
        //Assert
        AssertValidPingOutput(result.Result);
    }

    [TestMethod]
    public void RunAsync_UsingTaskReturn_Success()
    {
        //Arrange
        Task<PingResult> result = Sut.RunAsync("localhost");
        
        //Act
        AssertValidPingOutput(result.Result);
    }

    [TestMethod]
    async public Task RunAsync_UsingTpl_Success()
    {
        //Arrange
        PingResult result = await Sut.RunAsync("localhost");

        //Assert
        AssertValidPingOutput(result);
    }


    [TestMethod]
    [ExpectedException(typeof(AggregateException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping()
    {
        //Arrange
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = cancellationTokenSource.Token;
        
        //Act
        Task<PingResult> result = Sut.RunAsync("localhost",  cancellationToken);
        cancellationTokenSource.Cancel();
        result.Wait();
        
    }

    [TestMethod]
    [ExpectedException(typeof(TaskCanceledException))]
    public void RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException()
    {
        //Arrange
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        //Act
        try
        {
            Task<PingResult> result = Sut.RunAsync("localhost", cancellationToken);
            cancellationTokenSource.Cancel();
            result.Wait();
        }
        catch(AggregateException ex)
        {
            Exception taskCanceledException = ex.Flatten();
            throw taskCanceledException.InnerException!;
        }
    }

    [TestMethod]
    async public Task RunAsync_MultipleHostAddresses_True()
    {
        //Arrange
        string[] hostNames = new string[] { "localhost", "localhost", "localhost", "localhost" };
        int expectedLineCount = PingOutputLikeExpression.Split(Environment.NewLine).Length*hostNames.Length;

        //Act
        PingResult result = await Sut.RunAsync(hostNames);
        int? lineCount = result.StdOutput?.Split(Environment.NewLine).Length;
        
        //Assert
        Assert.AreEqual<int?>(expectedLineCount, lineCount);
    }

    [TestMethod]

    async public Task RunLongRunningAsync_UsingTpl_Success()
    {
        //Arrange
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        //Act
        PingResult result = await Sut.RunLongRunningAsync("localhost");
        
        //Assert
        AssertValidPingOutput(result);
    }

    [TestMethod]
    public void StringBuilderAppendLine_InParallel_IsNotThreadSafe()
    {
        //Arrange
        object lockable = new();
        IEnumerable<int> numbers = Enumerable.Range(0, short.MaxValue);
        System.Text.StringBuilder stringBuilder = new();

        //Act
        numbers.AsParallel().ForAll(item =>
        {
            lock (lockable)
            {
                stringBuilder.AppendLine("");
            }
        });
        int lineCount = stringBuilder.ToString().Split(Environment.NewLine).Length;

        //Assert
        Assert.AreEqual<int>(lineCount, numbers.Count()+1);
        
    }
    // Changed for how pings seem to work for my machine.
    readonly string PingOutputLikeExpression = @"
Pinging * with 32 bytes of data:
Reply from *.*.*.*: bytes=* time<*
Reply from *.*.*.*: bytes=* time<*
Reply from *.*.*.*: bytes=* time<*
Reply from *.*.*.*: bytes=* time<*

Ping statistics for *.*.*.*:
    Packets: Sent = *, Received = *, Lost = 0 (0% loss),
Approximate round trip times in milli-seconds:
    Minimum = *, Maximum = *, Average = *".Trim();
    private void AssertValidPingOutput(int exitCode, string? stdOutput)
    {
        Assert.IsFalse(string.IsNullOrWhiteSpace(stdOutput));
        stdOutput = WildcardPattern.NormalizeLineEndings(stdOutput!.Trim());
        Assert.IsTrue(stdOutput?.IsLike(PingOutputLikeExpression)??false,
            $"Output is unexpected: {stdOutput}");
        Assert.AreEqual<int>(0, exitCode);
    }
    private void AssertValidPingOutput(PingResult result) =>
        AssertValidPingOutput(result.ExitCode, result.StdOutput);
}
