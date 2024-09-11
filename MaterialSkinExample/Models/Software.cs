using Supabase.Postgrest.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Supabase.Postgrest.Attributes;
using System;

namespace PYALauncherApps.Models
{
    

    [Table("software")]
    public class Software : BaseModel
    {
        private string _gruposRaw;


        [Column("id")]
        public int Id { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("imagen")]
        public string Imagen { get; set; }

        [Column("path_install")]
        public string PathInstall { get; set; }

        [Column("software_name")]
        public string SoftwareName { get; set; } // Asegúrate de usar el nombre correcto de la columna

        [Column("tag")]
        public string Tag { get; set; }

        [Column("url_msi")]
        public string UrlMsi { get; set; }

        [Column("verifica_app")]
        public string VerificaApp { get; set; }

        [Column("version")]
        public string Version { get; set; }

        [Column("path_file")]
        public string PathFile { get; set; }

        [Column("force_install")]
        public bool ForceInstall { get; set; }

        [Column("automatic_install")]
        public bool AutomaticInstall { get; set; }

        [Column("guid")]
        public string Guid { get; set; }

        [Column("grupos")]
        public string[] Grupos
        {
            get
            {
                // Si el valor es una cadena, dividirla en un arreglo
                if (!string.IsNullOrEmpty(_gruposRaw))
                {
                    return _gruposRaw
                        .Replace("{", string.Empty)
                        .Replace("}", string.Empty)
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                }

                return new string[0];
            }
            set
            {
                _gruposRaw = string.Join(",", value);
            }
        }

        [Column("hidden")]
        public bool Hidden { get; set; }

        [Column("actions")]
        public int Actions { get; set; }

        [Column("machines")]
        public Dictionary<string, Machine> Machines { get; set; }

        [Column("installername")]
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

        public override string ToString()
        {
            return SoftwareName;
        }

        public static class SelectedApplication
        {
            public static string SelectedApp { get; set; }
        }

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

    public class CustomJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string[]);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Convertir la cadena a un arreglo de string si es necesario
            var value = reader.Value as string;
            if (!string.IsNullOrEmpty(value))
            {
                return value.Split(',');
            }

            return new string[0];
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var array = value as string[];
            if (array != null)
            {
                writer.WriteValue(string.Join(",", array));
            }
        }
    }

}
