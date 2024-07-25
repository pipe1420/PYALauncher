using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PYALauncherApps.Models
{
    public class Software
    {
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string PathInstall { get; set; }
        public string SoftwareName { get; set; }
        public string Tag { get; set; }
        public string UrlMsi { get; set; }
        public string VerificaApp { get; set; }
        public string Version { get; set; }
        public string PathFile { get; set; }
        public bool ForceInstall { get; set; }
        public bool AutomaticInstall { get; set; }
        public string Guid { get; set; }
        public List<string> Grupos { get; set; }
        public bool Hidden { get; set; }


       
    }

    public class SoftwareList
    {
        //Firebase
        private JArray softwareList; // Propiedad para almacenar el JArray
        public JArray ListSoftware { get => softwareList; set => softwareList = value; } // Propiedad para el JArray


        //PostgreSQL
        private List<Software> softwareListPQSL; // Propiedad para almacenar el JArray
        public List<Software> ListSoftwarePSQL { get => softwareListPQSL; set => softwareListPQSL = value; } // Propiedad para el JArray
    }
}
