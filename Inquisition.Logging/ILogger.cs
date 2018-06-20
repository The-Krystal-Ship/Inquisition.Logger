using System;
using System.Runtime.CompilerServices;

namespace Inquisition.Logging
{
    public interface ILogger<T>
    {
        void LogInformation(string message, [CallerLineNumber] int caller = 0);
        void LogInformation(string source, string message, [CallerLineNumber] int caller = 0);

        void LogError(Exception e, [CallerLineNumber] int caller = 0);
        void LogError(string message, [CallerLineNumber] int caller = 0);
        void LogError(string source, string message, [CallerLineNumber] int caller = 0);
        void LogError(Exception e, string message, [CallerLineNumber] int caller = 0);
        void LogError(string source, string message, Exception e, [CallerLineNumber] int caller = 0);
    }
}
