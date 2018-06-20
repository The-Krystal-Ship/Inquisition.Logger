using System;
using System.Runtime.CompilerServices;

namespace Inquisition.Logging
{
    public class Logger<T> : ILogger<T> where T : class
    {
        public void LogError(Exception e, [CallerLineNumber] int caller = 0)
        {
            Log(ConsoleColor.Red, typeof(T).ToString(), null, e, caller);
        }

        public void LogError(Exception e, string message, [CallerLineNumber] int caller = 0)
        {
            Log(ConsoleColor.Red, typeof(T).ToString(), message, e, caller);
        }

        public void LogError(string source, string message, [CallerLineNumber] int caller = 0)
        {
            Log(ConsoleColor.Red, source, message, null, caller);
        }

        public void LogError(string message, [CallerLineNumber] int caller = 0)
        {
            Log(ConsoleColor.Red, typeof(T).ToString(), message, null, caller);
        }

        public void LogError(string source, string message, Exception e, [CallerLineNumber] int caller = 0)
        {
            Log(ConsoleColor.Red, source, message, e, caller);
        }

        public void LogInformation(string message, [CallerLineNumber] int caller = 0)
        {
            LogInformation(typeof(T).ToString(), message, caller);
        }

        public void LogInformation(string source, string message, [CallerLineNumber] int caller = 0)
        {
            Log(ConsoleColor.Green, source, message, null, caller);
        }

        private void Log(ConsoleColor sourceForegroundColor, string source, string message, Exception e = null, int caller = 0)
        {
            WriteDate();

            if (source != null)
            {
                WriteSource(sourceForegroundColor, source, caller);
            }

            if (message != null)
            {
                WriteMessage(message);
            }

            if (e != null)
            {
                WriteException(e);
            }

            Console.WriteLine();
        }

        private void WriteDate()
        {
            string date = $"{DateTime.Now.TimeOfDay:hh\\:mm\\:ss}";
            Console.Write(date);
        }

        private void WriteSource(ConsoleColor color, string source, int caller)
        {
            Console.ForegroundColor = color;
            Console.Write("    " + source + " line " + caller + ":");
            Console.WriteLine();
            Console.ResetColor();
        }

        private void WriteMessage(string message)
        {
            Console.WriteLine("    " + message);
        }

        private void WriteException(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("    " + e.ToString());
            Console.ResetColor();
        }
    }
}
