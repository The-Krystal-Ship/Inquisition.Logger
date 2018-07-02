using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Inquisition.Logging
{
    public class Logger<T> : ILogger<T> where T : class
    {
        private readonly LoggerStyle _style;
        private readonly string _dateFormat;

        public Logger() : this(LoggerStyle.Compact)
        {

        }

        public Logger(LoggerStyle loggerStyle)
        {
            _style = loggerStyle;

            switch (_style)
            {
                case LoggerStyle.Compact:
                    _dateFormat = "hh\\:mm\\:ss tt";
                    break;
                default:
                    _dateFormat = "dd/MM/yyyy hh\\:mm\\:ss tt";
                    break;
            }
        }

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
            Log(ConsoleColor.DarkGreen, source, message, null, caller);
        }
        
        private void Log(ConsoleColor sourceForegroundColor, string source, string message, Exception e = null, int caller = 0)
        {
            WriteDate();
            WriteCaller(caller);

            if (source != null)
            {
                WriteSource(sourceForegroundColor, source);
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

        private void Surround(ConsoleColor color, string content)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = color;
            Console.Write(content);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            Console.ForegroundColor = currentColor;
        }

        private void WriteDate()
        {
            string date = DateTime.Now.ToString(_dateFormat);
            Surround(ConsoleColor.Blue, date);
        }
        private void WriteCaller(int caller)
        {
            Surround(ConsoleColor.White, caller.ToString("D3"));
        }
        private void WriteSource(ConsoleColor color, string source)
        {
            switch (_style)
            {
                case LoggerStyle.Compact:
                    Console.ForegroundColor = color;
                    Console.Write(source.Split('.').Last());
                    Console.ResetColor();
                    Console.Write(" - ");
                    break;
                default:
                    Console.ForegroundColor = color;
                    Console.Write(source);
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
            }
        }
        private void WriteMessage(string message)
        {
            switch (_style)
            {
                case LoggerStyle.Compact:
                    Console.Write(message);
                    break;
                default:
                    Console.WriteLine("    " + message);
                    break;
            }
        }
        private void WriteException(Exception e)
        {
            switch (_style)
            {
                case LoggerStyle.Compact:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(e.GetType().FullName);

                    if (e.Source != null)
                    {
                        WriteExceptionProperty(nameof(e.Source), e.Source);
                    }

                    if (e.Message != null)
                    {
                        WriteExceptionProperty(nameof(e.Message), e.Message);
                    }

                    if (e.StackTrace != null)
                    {
                        WriteExceptionProperty(nameof(e.StackTrace), e.StackTrace);
                    }

                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("    " + e.GetType().FullName);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(": ");

                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    if (e.Source != null)
                    {
                        WriteExceptionProperty(nameof(e.Source), e.Source, true);
                    }

                    if (e.Message != null)
                    {
                        WriteExceptionProperty(nameof(e.Message), e.Message, true);
                    }

                    if (e.StackTrace != null)
                    {
                        WriteExceptionProperty(nameof(e.StackTrace), e.StackTrace, true);
                    }
                    break;
            }

            Console.ResetColor();
        }
        
        private void WriteExceptionProperty(string source, string content, bool spacing = true)
        {
            Console.ForegroundColor = ConsoleColor.White;

            if (spacing)
                Console.Write("    ");

            Console.Write($"{source}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(content.Trim().Replace(Environment.NewLine, " "));
        }
    }
}
