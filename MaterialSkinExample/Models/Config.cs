using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYALauncherApps.Models
{
    public class Config
    {
        public int Id { get; set; }
        public decimal Interval { get; set; }
        public bool Cleaning { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var config = (Config)obj;
            return Id == config.Id &&
                   Interval == config.Interval &&
                   Cleaning == config.Cleaning;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class ConfigList
    {
        public List<ConfigList> GetConfigListPQSL()
        {
            List<ConfigList> GetConfigListPQSL = null;
            
            return GetConfigListPQSL;
        }
    }
}
