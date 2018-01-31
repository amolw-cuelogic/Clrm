using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Common
{
    public class AppLogManager
    {
        // Prerequisite : Add below line to AssemblyInfo.cs
        // [assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

        public static void Configure()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static log4net.ILog GetLogger()
        {
            return LogManager.GetLogger(Assembly.GetCallingAssembly(), "Default");
        }
    }
}
