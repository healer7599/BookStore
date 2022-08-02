using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConfigModel
{
    /// <summary>
    /// Chứa cấu hình chung của tất cả các app
    /// </summary>
    public class DefaultConfig
    {
        public LoggingConfig Logging { get; set; }

        public string AllowedHosts { get; set; }

        public ConnectionsConfig Connections { get; set; }
    }

    public class LoggingConfig
    {
        public LogLevelConfig LogLevel { get; set; }
    }

    public class LogLevelConfig
    {
        public string Default { get; set; }
    }
}
