using System;

namespace Inquisition.Logging
{
    public interface ILogger<T>
    {
        void LogInformation(string message);
        void LogInformation(string source, string message);
        void LogInformation(string source, string message, params object[] values);

        void LogError(Exception e);
        void LogError(string message);
        void LogError(string source, string message);
        void LogError(Exception e, string message);
        void LogError(string source, string message, Exception e);
    }
}
