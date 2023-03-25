namespace SimpleDI
{
    public class LogManager
    {
        private ILogger _logger;

        public LogManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
