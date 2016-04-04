using System;

namespace Asteroid.Logger
{
    public interface ILogger
    {
        void LogInfo(string title, 
            string message);

        void LogWarning(string title, 
            string message);
       
        void LogAudit(string title, 
            string message);

        void LogDebug(string title, 
            string message);

        void LogError(string title, 
            string message);
        
        void LogException(Exception ex);

        void LogException(string title, 
            Exception ex);
    }
}
