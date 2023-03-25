using System;

namespace SimpleDI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger;
            string loggerType = "text";
            switch (loggerType)
            {
                case "text": logger = new TextLogger(); break;
                case "database": logger = new DatabaseLogger(); break;
                default: logger = new DatabaseLogger(); break;
            }
            LogManager LogManager = new LogManager(logger);

            try
            {
                throw new DivideByZeroException();
            }
            catch (Exception ex)
            {
                LogManager.Log(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
