using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using PYALauncherApps.Models;

namespace PYALauncherApps.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public async Task<List<Config>> GetConfigs()
        {
            var configs = new List<Config>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("SELECT id, interval, cleaning FROM pya_apps.config", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            configs.Add(new Config
                            {
                                Id = reader.GetInt32(0),
                                Interval = reader.GetDecimal(1),
                                Cleaning = reader.GetBoolean(2)
                            });
                        }
                    }
                }
            }

            return configs;
        }



        public async Task<List<Software>> GetSoftware()
        {
            var softwareList = new List<Software>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("SELECT * FROM pya_apps.software", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            softwareList.Add(new Software
                            {
                                Id = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                Imagen = reader.GetString(2),
                                PathInstall = reader.GetString(3),
                                Name = reader.GetString(4),
                                Tag = reader.GetString(5),
                                UrlMsi = reader.GetString(6),
                                VerificaApp = reader.GetString(7),
                                Version = reader.GetString(8),
                                PathFile = reader.GetString(9),
                                ForceInstall = reader.GetBoolean(10),
                                AutomaticInstall = reader.GetBoolean(11),
                                Guid = reader.GetString(12),
                                Grupos = reader.IsDBNull(13) ? null : reader.GetFieldValue<string[]>(13),
                                Hidden = reader.GetBoolean(14)
                            });
                        }
                    }
                }
            }

            return softwareList;
        }
    }
}
