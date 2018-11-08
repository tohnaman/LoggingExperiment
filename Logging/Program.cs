using System;
using CommandLine;
using log4net;
using Logging.Logger01;
using NLog;
using LogManager = NLog.LogManager;

namespace Logging
{
    internal class Program
    {
        private static readonly Logger Logger1 = LogManager.GetCurrentClassLogger();
        private static readonly ILog Logger2 = log4net.LogManager.GetLogger(typeof(Program));

        private static void Main(string[] args)
        {
            Logger1.Info("Main NLog");
            Logger2.Info("Main log4net");

            var param = new Options();
            Parser.Default.ParseArguments<Options>(args).WithParsed(opt =>
            {
                Console.WriteLine("パース成功！");
                var loggerType = opt.LoggerType.ToLower();
                switch (loggerType)
                {
                    case "nlog":
                        param.LoggerType = "nlog";
                        break;
                    case "log4net":
                        param.LoggerType = "log4net";
                        break;
                    default:
                        param.LoggerType = "other";
                        break;
                }

                param.Count = opt.Count;
                param.Message = opt.Message;
            })
                  .WithNotParsed(er => {Console.WriteLine("パース失敗！");});

            switch (param.LoggerType)
            {
                case "nlog":
                    new Main().Execute(param.Count, param.Message);
                    break;
                case "log4net":
                    new Logger02.Main().Execute(param.Count, param.Message);
                    break;
            }
        }
    }
}
