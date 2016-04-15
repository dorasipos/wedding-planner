using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Dora.WeddingPlanner.Logging
{
    public static class Extensions
    {
        public static LogTiming Timing(this Logger logger, string actionName, LogLevel logLevel)
        {
            return new LogTiming(logger, actionName, logLevel);
        }

        public static LogTiming Timing(this Logger logger, string actionName)
        {
            return new LogTiming(logger, actionName);
        }
    }
}
