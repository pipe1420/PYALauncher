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
        public int Id { get; set; }
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
        public string[] Grupos { get; set; }
        public bool Hidden { get; set; }
        public int Actions { get; set; }
        //public List<string> Machines { get; set; } // 'machines' (jsonb)
        public Dictionary<string, Machine> Machines { get; set; }
        public string InstallerName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var software = (Software)obj;
            return Id == software.Id &&
                   Descripcion == software.Descripcion &&
                   Imagen == software.Imagen &&
                   PathInstall == software.PathInstall &&
                   SoftwareName == software.SoftwareName &&
                   Tag == software.Tag &&
                   UrlMsi == software.UrlMsi &&
                   VerificaApp == software.VerificaApp &&
                   Version == software.Version &&
                   PathFile == software.PathFile &&
                   ForceInstall == software.ForceInstall &&
                   AutomaticInstall == software.AutomaticInstall &&
                   Guid == software.Guid &&
                   Hidden == software.Hidden &&
                   Actions == software.Actions &&
                   Machines == software.Machines &&
                   InstallerName == software.InstallerName;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        // Sobrescribir el método ToString
        public override string ToString()
        {
            return SoftwareName;
        }

        public static class SelectedApplication
        {
            public static string SelectedApp { get; set; }
        }

        // Método para limpiar los campos
        public void ClearFields()
        {
            Id = 0;
            Descripcion = string.Empty;
            Imagen = string.Empty;
            PathInstall = string.Empty;
            SoftwareName = string.Empty;
            Tag = string.Empty;
            UrlMsi = string.Empty;
            VerificaApp = string.Empty;
            Version = string.Empty;
            PathFile = string.Empty;
            ForceInstall = false;
            AutomaticInstall = false;
            Guid = string.Empty;
            Grupos = null;
            Hidden = false;
            Actions = 0;
            Machines = new Dictionary<string, Machine>();
            InstallerName = string.Empty;
        }

    }

}
