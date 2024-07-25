using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PYALauncherApps.Models;

namespace PYALauncherApps.Services
{
    public class ConfigService
    {

        ConfigList _config = new ConfigList();
        public ConfigService() { 
        
        }

        public List<Config> GetSoftwareListPSQL()
        {
            return _config.GetConfigListPQSL();
        }
    }
}
