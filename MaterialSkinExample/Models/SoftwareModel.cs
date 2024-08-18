using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYALauncherApps.Models
{
    public class SoftwareModel
    {
        public string SoftwareName { get; set; }
        public string Descripcion { get; set; }

        public List<Software> SoftwareList { get; set; }
    }

}
