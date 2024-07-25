using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYALauncherApps.Models
{
    public class Config
    {
        public string Interval { get; set; }
        public bool Cleaning { get; set; }

        //PostgreSQL
        private List<Software> configListPQSL; // Propiedad para almacenar el JArray
    }
}
