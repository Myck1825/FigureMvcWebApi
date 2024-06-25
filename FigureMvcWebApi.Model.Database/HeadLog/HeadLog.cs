using FigureMvcWebApi.Model.CustomExceptions;
using FigureMvcWebApi.Model.Database.Enums;
using FigureMvcWebApi.Model.HeadLog;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FigureMvcWebApi.Model.Database.HeadLog
{
    /// <summary>
    /// Elasticsearch head log.
    /// </summary>
    public sealed class HeadLog : IHeadLog
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(HeadLog));

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:FigureMvcWebApi.Model.Database.HeadLog"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public HeadLog()
        {
        }

        #region -- IHeadLog implementation --

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ex">Ex.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        public void LogError(Exception ex, string message, IDictionary<string, string> propertyDictionary = null)
        {
            message = message ?? "No error message";

            Log(LogLevel.Error, message, propertyDictionary, ex ?? new Exception(message));
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        public void LogError(string message, IDictionary<string, string> propertyDictionary = null)
        {
            message = message ?? "No error message";

            Log(LogLevel.Error, message, propertyDictionary, new Exception(message));
        }

        /// <summary>
        /// Logs the info.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        public void LogInfo(string message, IDictionary<string, string> propertyDictionary = null)
            => Log(LogLevel.Information, message ?? "No info message", propertyDictionary, null);


        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        public void LogWarning(string message, IDictionary<string, string> propertyDictionary = null)
            => Log(LogLevel.Warning, message ?? "No warning message", propertyDictionary, null);


        #endregion

        #region -- Private helpers --

        /// <summary>
        /// Log the specified logLevel, message, propertyDictionary and ex.
        /// </summary>
        /// <returns>The log.</returns>
        /// <param name="logLevel">Log level.</param>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        /// <param name="ex">Ex.</param>
        private void Log(LogLevel logLevel, string message, IDictionary<string, string> propertyDictionary, Exception ex)
        {
            message = $"Message: '{message}'";

            IEnumerable<string> properties = propertyDictionary?.Select(x => $"(\"{x.Key}\" : \"{x.Value})\"") ?? Enumerable.Empty<string>();

            if (properties.Any())
                message += $"Properties: '{string.Join(", ", properties)}'";

            switch (logLevel)
            {
                case LogLevel.Information: _logger.Info(message); break;
                case LogLevel.Warning: _logger.Warn(message); break;
                case LogLevel.Error: _logger.Error(message, ex); break;
                default: throw new SwitchMissingCaseException();
            }
        }

        #endregion
    }
}
