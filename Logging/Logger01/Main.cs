using System;
using NLog;

namespace Logging.Logger01
{
    public class Main
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Execute(int count, string message)
        {
            for (var i = 0; i < count; i++)
            {
                LogManager.Configuration.Variables["code"] = $"{i + 1:0000}";
                Logger.Info(" ===== START =====");
                Logger.Info(message);
                Logger.Info(" ===== END =====");
            }
        }
    }
}
