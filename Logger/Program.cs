using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger;

public class Program
{
    public static void Main(string[] args)
    {
        
        string path = "output.txt";
        using(StreamWriter sw = File.CreateText(path))
        {
            DateTime localDate = DateTime.Now;
            sw.WriteLine(localDate);
            sw.WriteLine("FileLogger");
        }

        Console.WriteLine("Hello world");
    }
}
