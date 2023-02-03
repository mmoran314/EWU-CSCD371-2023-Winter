using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class Jester : IJokeOutput, IJokeService
{
    private IJokeOutput? _ReallyCoolJokeOutput;
    private IJokeService? _JokeService;
    
    public IJokeOutput ReallyCoolJokeOutput
    {
        get
        {
            return _ReallyCoolJokeOutput!; // Use null forgiveness here after null checking on setter
        }
        set
        {
            _ReallyCoolJokeOutput = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
    public IJokeService JokeService
    {
        get
        {
            return _JokeService!; // Use null forgiveness here after null checking on setter
        }
        set
        {
            _JokeService = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
    
    public Jester(IJokeOutput reallyCoolJokeOutput, IJokeService jokeService)
    {
        ReallyCoolJokeOutput = reallyCoolJokeOutput;
        JokeService = jokeService;
    }

    
    public string TellJoke()
    {
        string testJoke = GetJoke();
        bool isChuckNorris = true;
        while (isChuckNorris) {
            if (testJoke.Contains("Chuck Norris") || testJoke.Contains("Chuck") || testJoke.Contains("Norris")) {
                testJoke = GetJoke();
                continue;
            }
            else
            {
                isChuckNorris=false;
            }
        }

        ReallyCoolJokeOutput.WriteJoke(testJoke);
        return testJoke;
    }
    public string GetJoke()
    {
        return JokeService.GetJoke();
    }
    public void WriteJoke(string joke)
    {
        Console.Write(joke);
    }
}
