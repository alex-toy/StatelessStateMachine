using System;

namespace SimpleDI
{
    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"log to database: {message}");
        }
    }
}
