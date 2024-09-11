using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supabase.Postgrest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PYALauncherApps.Models
{
    public class Machine
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }
    }


    public class MachineDisplayItem
    {
        public string MachineKey { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
    }



}
