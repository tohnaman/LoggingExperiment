using CommandLine;

namespace Logging
{
    public class Options
    {
        [Option('l', "logger", Required = true, HelpText = "logger種別 NLog or log4net")]
        public string LoggerType {get; set;}

        [Option('c', "count", Required = true, HelpText = "回数")]
        public int Count {get; set;}

        [Value(0, MetaName = "message", HelpText = "ログ内容")]
        public string Message {get; set;}
    }
}
