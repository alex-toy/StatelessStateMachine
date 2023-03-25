using System;

namespace SimpleDI
{
    public class TextLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"log to text file: {message}");
        }
    }
}
