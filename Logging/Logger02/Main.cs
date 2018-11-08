using System.Diagnostics;
using log4net;

namespace Logging.Logger02
{
    public class Main
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Main));

        public void Execute(int count, string message)
        {
            GlobalContext.Properties["pid"] = Process.GetCurrentProcess().Id;
            for (var i = 0; i < count; i++)
            {
                GlobalContext.Properties["code"] = $"{i + 1:0000}";
                Logger.Info(" ===== START =====");
                Logger.Info(message);
                Logger.Info(" ===== END =====");
            }
        }
    }
}
