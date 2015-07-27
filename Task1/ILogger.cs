namespace Task1
{
    public interface ILogger
    {
        void Initialize();
        void Warn(string message);
        void Warn(string format, params string[] message);
        void Info(string message);
        void Info(string format, params string[] message);
        void Debug(string message);
        void Debug(string format, params string[] message);
        void Error(string message);
        void Error(string format, params string[] message);
    }
}
