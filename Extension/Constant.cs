using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    public static class Constant
    {
        public static string Default { get; set; } = ""Default.json""
        public enum ConfigFileName : string
        {
            Default = ,
            Connection = "Connection.json",
        }
    }
}
