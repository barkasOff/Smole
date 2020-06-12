using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Smole.Core
{
    /// <summary>
    /// To control operations
    /// </summary>
    public class ApplicationLoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// Creates and returns a logger object
        /// </summary>
        /// <param name="categoryName"> Logger object </param>
        /// <returns> Logger object </returns>
        public ILogger CreateLogger(string categoryName) => new MyLogger();

        /// <summary>
        /// Manages the release of resources
        /// </summary>
        public void Dispose() { }

        /// <summary>
        /// The logger itself is represented by an ILogger object
        /// </summary>
        private class MyLogger : ILogger
        {
            /// <summary>
            /// This method returns an IDisposable that represents some scope for the logger
            /// </summary>
            /// <typeparam name="TState"> Any state </typeparam>
            /// <param name="state"> Represents some scope for the logger </param>
            /// <returns> An IDisposable </returns>
            public IDisposable BeginScope<TState>(TState state) => null;

            /// <summary>
            /// Is the logger available for use?
            /// </summary>
            /// <param name="logLevel"> Depending on the value of this object </param>
            /// <returns> Always enabled</returns>
            public bool IsEnabled(LogLevel logLevel) => true;

            /// <summary>
            /// This method is designed to perform logging
            /// </summary>
            /// <typeparam name="TState"> Some state object </typeparam>
            /// <param name="logLevel"> Level of detail of the current message </param>
            /// <param name="eventId">Event id </param>
            /// <param name="state"> Some state object that stores the message </param>
            /// <param name="exception"> Exception information </param>
            /// <param name="formatter"> Format function </param>
            public void Log<TState>(LogLevel logLevel, EventId eventId,
                    TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                // Append to the file
                File.AppendAllText("log.txt", formatter(state, exception));

                // Console output
                // Console.WriteLine(formatter(state, exception));
            }
        }
    }
}
