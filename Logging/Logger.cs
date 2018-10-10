using Microsoft.Extensions.Logging;

using System;

namespace TheKrystalShip.Logging
{
    public class Logger : ILogger
    {
        private static readonly object _lock = new object();
        private readonly string _name;
        private readonly LoggerConfiguration _config;

        public Logger(string name, LoggerConfiguration config)
        {
            _name = name;
            _config = config;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            lock (_lock)
            {
                if (_config.EventId == 0 || _config.EventId == eventId.Id)
                {
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = _config.Color;
                    Console.WriteLine($"{logLevel.ToString()} - {eventId.Id} - {_name} - {formatter(state, exception)}");
                    Console.ForegroundColor = color;
                }
            }
        }
    }
}
