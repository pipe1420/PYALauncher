using System;
using System.Collections.Generic;
using Npgsql;
using PYALauncherApps.Models;

namespace MaterialSkinExample.Database
{
    public class ConexionPostgresql
    {
        public static string connString = "Host=pya_db;Username=felipe;Password=12345;Database=pya_apps";

        private List<Software> GetSoftwareList()
        {
            List<Software> softwareList = new List<Software>();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT descripcion, imagen, path_install, software, tag, url_msi, verifica_app, version, path_file, force_install, automatic_install, guid, grupos, hidden FROM pya_apps.software;", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Software software = new Software
                        {
                            Descripcion = reader.GetString(0),
                            Imagen = reader.GetString(1),
                            PathInstall = reader.GetString(2),
                            SoftwareName = reader.GetString(3),
                            Tag = reader.GetString(4),
                            UrlMsi = reader.GetString(5),
                            VerificaApp = reader.GetString(6),
                            Version = reader.GetString(7),
                            PathFile = reader.GetString(8),
                            ForceInstall = reader.GetBoolean(9),
                            AutomaticInstall = reader.GetBoolean(10),
                            Guid = reader.GetString(11),
                            Grupos = reader.GetFieldValue<List<string>>(12), // Asumiendo que 'grupos' se almacena como un array en la base de datos
                            Hidden = reader.GetBoolean(13)
                        };

                        softwareList.Add(software);
                    }
                }
            }

            return softwareList;
        }

        private List<Config> GetConfigList()
        {
            List<Software> softwareList = new List<Software>();

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT descripcion, imagen, path_install, software, tag, url_msi, verifica_app, version, path_file, force_install, automatic_install, guid, grupos, hidden FROM pya_apps.software;", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Software software = new Software
                        {
                            Descripcion = reader.GetString(0),
                            Imagen = reader.GetString(1),
                            PathInstall = reader.GetString(2),
                            SoftwareName = reader.GetString(3),
                            Tag = reader.GetString(4),
                            UrlMsi = reader.GetString(5),
                            VerificaApp = reader.GetString(6),
                            Version = reader.GetString(7),
                            PathFile = reader.GetString(8),
                            ForceInstall = reader.GetBoolean(9),
                            AutomaticInstall = reader.GetBoolean(10),
                            Guid = reader.GetString(11),
                            Grupos = reader.GetFieldValue<List<string>>(12), // Asumiendo que 'grupos' se almacena como un array en la base de datos
                            Hidden = reader.GetBoolean(13)
                        };

                        softwareList.Add(software);
                    }
                }
            }

            return softwareList;
        }






    }
}