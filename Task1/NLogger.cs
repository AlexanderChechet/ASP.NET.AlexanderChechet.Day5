using System;
using NLog;

namespace Task1
{
    public class NLogger : ILogger
    {
        private Logger nLogger;

        public void Initialize()
        {
            nLogger = LogManager.GetCurrentClassLogger();
        }

        public void Warn(string message)
        {
            nLogger.Warn(message);
        }

        public void Warn(string format, params string[] message)
        {
            nLogger.Warn(format, message);
        }

        public void Info(string message)
        {
            nLogger.Info(message);
        }

        public void Info(string format, params string[] message)
        {
            nLogger.Info(format, message);
        }

        public void Debug(string message)
        {
            nLogger.Debug(message);
        }

        public void Debug(string format, params string[] message)
        {
            nLogger.Debug(format, message);
        }

        public void Error(string message)
        {
            nLogger.Error(message);
        }

        public void Error(string format, params string[] message)
        {
            nLogger.Error(format, message);
        }
    }
}
