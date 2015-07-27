using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class LogAdapter
    {
        private readonly ILogger logger;

        public LogAdapter(ILogger logger)
        {
            this.logger = logger;
        }

        public void Initialize()
        {
            logger.Initialize();
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Warn(string format, params string[] message)
        {
            logger.Warn(format, message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Info(string format, params string[] message)
        {
            logger.Info(format, message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Debug(string format, params string[] message)
        {
            logger.Debug(format, message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(string format, params string[] message)
        {
            logger.Error(format, message);
        }
    }
}
