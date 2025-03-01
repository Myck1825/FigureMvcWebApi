﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.HeadLog
{
    /// <summary>
    /// Head log.
    /// </summary>
    public interface IHeadLog
    {
        /// <summary>
        /// Logs the info.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        void LogInfo(string message, IDictionary<string, string> propertyDictionary = null);

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        void LogWarning(string message, IDictionary<string, string> propertyDictionary = null);

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ex">Ex.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        void LogError(Exception ex, string message, IDictionary<string, string> propertyDictionary = null);

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        void LogError(string message, IDictionary<string, string> propertyDictionary = null);
    }
}
