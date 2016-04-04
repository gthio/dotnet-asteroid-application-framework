using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;

using Asteroid.Logger;

namespace Asteroid.Logger.EnterpriseLibrary
{
    public class EnterpriseLibraryLogger : ILogger
    {
        LogWriter writer;

        public EnterpriseLibraryLogger()
        {
            writer = new LogWriterFactory()
                .Create();
        }

        public void LogInfo(string title,
            string message)
        {
            LogMessage(title,
                message,
                LoggerCategory.Info);
        }

        public void LogWarning(string title,
            string message)
        {
            LogMessage(title,
                message,
                LoggerCategory.Warning);
        }

        public void LogAudit(string title,
            string message)
        {
            LogMessage(title,
                message,
                LoggerCategory.Audit);
        }

        public void LogDebug(string title,
            string message)
        {
            LogMessage(title,
                message,
                LoggerCategory.Debug);
        }

        public void LogError(string title,
            string message)
        {
            LogMessage(title,
                message,
                LoggerCategory.Error);
        }

        public void LogException(Exception ex)
        {
            LogMessage(ex.Message,
                BuildExceptionMessage(ex),
                LoggerCategory.Error);
        }

        public void LogException(string title,
            Exception ex)
        {
            LogMessage(title,
                BuildExceptionMessage(ex),
                LoggerCategory.Error);
        }

        private static string BuildExceptionMessage(Exception ex)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Message: " + ex.Message);
            sb.AppendLine("Source: " + ex.Source);
            sb.AppendLine("Stack Trace: " + ex.StackTrace);

            if (ex.InnerException != null)
            {
                sb.AppendLine("Inner exception");
                sb.AppendLine("Message: " + ex.InnerException.Message);
                sb.AppendLine("Source: " + ex.InnerException.Source);
                sb.AppendLine("Stack Trace: " + ex.InnerException.StackTrace);
            }

            return sb.ToString();
        }

        private void LogMessage(string title,
            string message,
            LoggerCategory category)
        {
            var logEntry = new LogEntry();

            logEntry.Title = title;
            logEntry.Message = message;

            logEntry.Categories.Clear();
            logEntry.Categories.Add(category.ToString());

            writer.Write(logEntry);
        }
    }
}
