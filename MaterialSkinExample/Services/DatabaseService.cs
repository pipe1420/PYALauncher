using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
                using (var command = new NpgsqlCommand("select s.id, s.descripcion, s.imagen, s.path_install, s.software_name, s.tag, s.url_msi, " +
                    "s.verifica_app, s.version, s.path_file, s.force_install, s.automatic_install, s.guid, s.grupos, s.hidden, s.actions, s.machines " +
                    "from pya_apps.software s order by s.software_name", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var software = new Software
                            {
                                Id = reader.GetInt32(0),
                                Descripcion = reader.IsDBNull(1) ? null : reader.GetString(1),
                                Imagen = reader.IsDBNull(2) ? null : reader.GetString(2),
                                PathInstall = reader.IsDBNull(3) ? null : reader.GetString(3),
                                SoftwareName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Tag = reader.IsDBNull(5) ? null : reader.GetString(5),
                                UrlMsi = reader.IsDBNull(6) ? null : reader.GetString(6),
                                VerificaApp = reader.IsDBNull(7) ? null : reader.GetString(7),
                                Version = reader.IsDBNull(8) ? null : reader.GetString(8),
                                PathFile = reader.IsDBNull(9) ? null : reader.GetString(9),
                                ForceInstall = reader.GetBoolean(10),
                                AutomaticInstall = reader.GetBoolean(11),
                                Guid = reader.IsDBNull(12) ? null : reader.GetString(12),
                                Grupos = reader.IsDBNull(13) ? null : reader.GetFieldValue<string[]>(13),
                                Hidden = reader.GetBoolean(14),
                                Actions = reader.GetInt32(15),
                                Machines = reader.IsDBNull(16) ? null : JsonConvert.DeserializeObject<Dictionary<string, Machine>>(reader.GetString(16))
                            };

                            softwareList.Add(software);
                        }
                    }
                }
            }

            return softwareList;
        }


        public async Task<bool> InsertUpdateSoftware(Software software)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new NpgsqlCommand(
                        "INSERT INTO pya_apps.software " +
                        "(id, descripcion, imagen, path_install, software_name, tag, url_msi, verifica_app, " +
                        "version, path_file, force_install, automatic_install, guid, grupos, hidden, actions, machines) " +
                        "VALUES " +
                        "(@id, @descripcion, @imagen, @path_install, @software_name, @tag, @url_msi, @verifica_app, " +
                        "@version, @path_file, @force_install, @automatic_install, @guid, @grupos, @hidden, @actions, @machines) " +
                        "ON CONFLICT (id) " +
                        "DO UPDATE SET " +
                        "descripcion = EXCLUDED.descripcion, " +
                        "imagen = EXCLUDED.imagen, " +
                        "path_install = EXCLUDED.path_install, " +
                        "software_name = EXCLUDED.software_name, " +
                        "tag = EXCLUDED.tag, " +
                        "url_msi = EXCLUDED.url_msi, " +
                        "verifica_app = EXCLUDED.verifica_app, " +
                        "version = EXCLUDED.version, " +
                        "path_file = EXCLUDED.path_file, " +
                        "force_install = EXCLUDED.force_install, " +
                        "automatic_install = EXCLUDED.automatic_install, " +
                        "guid = EXCLUDED.guid, " +
                        "grupos = EXCLUDED.grupos, " +
                        "hidden = EXCLUDED.hidden, " +
                        "actions = EXCLUDED.actions, " +
                        "machines = EXCLUDED.machines;", connection))
                    {
                        
                        command.Parameters.AddWithValue("@id", software.Id);
                        command.Parameters.AddWithValue("@descripcion", software.Descripcion);
                        command.Parameters.AddWithValue("@imagen", software.Imagen);
                        command.Parameters.AddWithValue("@path_install", software.PathInstall);
                        command.Parameters.AddWithValue("@software_name", software.SoftwareName);
                        command.Parameters.AddWithValue("@tag", software.Tag);
                        command.Parameters.AddWithValue("@url_msi", software.UrlMsi);
                        command.Parameters.AddWithValue("@verifica_app", software.VerificaApp);
                        command.Parameters.AddWithValue("@version", software.Version);
                        command.Parameters.AddWithValue("@path_file", software.PathFile);
                        command.Parameters.AddWithValue("@force_install", software.ForceInstall);
                        command.Parameters.AddWithValue("@automatic_install", software.AutomaticInstall);
                        command.Parameters.AddWithValue("@guid", software.Guid);
                        command.Parameters.AddWithValue("@grupos", software.Grupos);
                        command.Parameters.AddWithValue("@hidden", software.Hidden);
                        command.Parameters.AddWithValue("@actions", software.Actions);

                        // Manejo de 'machines' como tipo jsonb
                        var machinesJson = JsonConvert.SerializeObject(software.Machines);
                        var machinesParameter = new NpgsqlParameter("@machines", NpgsqlTypes.NpgsqlDbType.Jsonb)
                        {
                            Value = machinesJson
                        };
                        command.Parameters.Add(machinesParameter);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Loguear el error o manejarlo según sea necesario
                Debug.WriteLine($"Error al insertar o actualizar el software: {ex.Message}");
                return false; // Hubo un fallo
            }
        }


        public async Task<Software> FindSoftware(string softwareName)
        {
            Software softwareItem = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("select s.id, s.descripcion, s.imagen, s.path_install, s.software_name, s.tag, s.url_msi, " +
                    "s.verifica_app, s.version, s.path_file, s.force_install, s.automatic_install, s.guid, s.grupos, s.hidden, s.actions, s.machines " +
                    "from pya_apps.software s where s.software_name = @softwareName", connection))
                {
                    command.Parameters.AddWithValue("@softwareName", softwareName);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            softwareItem = new Software
                            {
                                Id = reader.GetInt32(0),
                                Descripcion = reader.GetString(1),
                                Imagen = reader.GetString(2),
                                PathInstall = reader.GetString(3),
                                SoftwareName = reader.GetString(4),
                                Tag = reader.GetString(5),
                                UrlMsi = reader.GetString(6),
                                VerificaApp = reader.GetString(7),
                                Version = reader.GetString(8),
                                PathFile = reader.GetString(9),
                                ForceInstall = reader.GetBoolean(10),
                                AutomaticInstall = reader.GetBoolean(11),
                                Guid = reader.GetString(12),
                                Grupos = reader.IsDBNull(13) ? null : reader.GetFieldValue<string[]>(13),
                                Hidden = reader.GetBoolean(14),
                                Actions = reader.GetInt32(15),
                                Machines = reader.IsDBNull(16) ? null : JsonConvert.DeserializeObject<Dictionary<string, Machine>>(reader.GetString(16))
                            };
                        }
                    }
                }
            }

            return softwareItem;
        }





    }
}
