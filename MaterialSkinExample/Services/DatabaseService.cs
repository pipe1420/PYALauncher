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
using Supabase;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supabase.Postgrest;


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
                    "s.verifica_app, s.version, s.path_file, s.force_install, s.automatic_install, s.guid, s.grupos, s.hidden, s.actions, s.machines, s.installername " +
                    "from pya_apps.software s where s.hidden = false order by s.software_name", connection))
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
                                Machines = reader.IsDBNull(16) ? null : JsonConvert.DeserializeObject<Dictionary<string, Machine>>(reader.GetString(16)),
                                InstallerName = reader.IsDBNull(17) ? null : reader.GetString(17),
                            };

                            softwareList.Add(software);
                        }
                    }
                }
            }

            return softwareList;
        }


        private async Task<bool> SoftwareExists(string softwareName)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand(
                    "SELECT COUNT(*) FROM pya_apps.software WHERE software_name = @software_name;", connection))
                {
                    command.Parameters.AddWithValue("@software_name", softwareName);
                    var result = (long)await command.ExecuteScalarAsync();

                    Debug.WriteLine("SoftwareExists : " + result);
                    return result > 0;
                }
            }
        }


        public async Task<bool> InsertUpdateSoftware(Software software)
        {
            try
            {
                bool exists = await SoftwareExists(software.SoftwareName);

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    string query;
                    if (exists)
                    {
                        // Actualizar si ya existe
                        query = "UPDATE pya_apps.software SET " +
                                "descripcion = @descripcion, imagen = @imagen, path_install = @path_install, " +
                                "tag = @tag, url_msi = @url_msi, verifica_app = @verifica_app, version = @version, " +
                                "path_file = @path_file, force_install = @force_install, automatic_install = @automatic_install, " +
                                "guid = @guid, grupos = @grupos, hidden = @hidden, actions = @actions, machines = @machines" +
                                (software.InstallerName != null ? ", installername = @installername" : "") +
                                " WHERE software_name = @software_name;";
                    }
                    else
                    {
                        // Insertar nuevo si no existe
                        query = "INSERT INTO pya_apps.software " +
                                "(descripcion, imagen, path_install, software_name, tag, url_msi, verifica_app, " +
                                "version, path_file, force_install, automatic_install, guid, grupos, hidden, actions, machines" +
                                (software.InstallerName != null ? ", installername" : "") +
                                ") VALUES " +
                                "(@descripcion, @imagen, @path_install, @software_name, @tag, @url_msi, @verifica_app, " +
                                "@version, @path_file, @force_install, @automatic_install, @guid, @grupos, @hidden, @actions, @machines" +
                                (software.InstallerName != null ? ", @installername" : "") + ");";
                    }

                    using (var command = new NpgsqlCommand(query, connection))
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

                        // Agregar installername solo si no es nulo
                        if (software.InstallerName != null)
                        {
                            command.Parameters.AddWithValue("@installername", software.InstallerName);
                        }
                        Debug.WriteLine($"Comando: {command.CommandText}");
                        Debug.WriteLine($"Comando: {command.Parameters}");

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return true; // Operación exitosa
            }
            catch (Exception ex)
            {
                // Loguear el error o manejarlo según sea necesario
                Debug.WriteLine($"Error al insertar o actualizar el software: {ex}");
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

        public async Task<bool> DeleteSoftware(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    using (var command = new NpgsqlCommand("DELETE FROM pya_apps.software WHERE id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        return rowsAffected > 0; // Retorna true si al menos una fila fue afectada (software eliminado)
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar o registrar la excepción
                Debug.WriteLine($"Error al eliminar el software: {ex.Message}");
                return false; // Retorna false si hubo un fallo
            }
        }

        public async Task<UserPermissions> GetUserPermissionsAsync(string userName)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT up.CanEditApps, up.CanViewUserTab
                          FROM Users u
                          JOIN UserPermissions up ON u.UserId = up.UserId
                          WHERE u.UserName = @UserName";

                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", userName);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new UserPermissions
                        {
                            CanEditApps = reader.GetBoolean(0),
                            CanViewUserTab = reader.GetBoolean(1)
                        };
                    }
                }
            }
            return null;
        }

        public async Task<List<UserPermissionDisplayItem>> GetAllUserPermissionsAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"SELECT u.userName, up.caneditapps, up.canviewusertab
                      FROM pya_apps.users u
                      JOIN pya_apps.userpermissions up ON u.userid = up.userid";

                var command = new NpgsqlCommand(query, connection);
                var userPermissionsList = new List<UserPermissionDisplayItem>();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        userPermissionsList.Add(new UserPermissionDisplayItem
                        {
                            UserName = reader.GetString(0),
                            CanEditApps = reader.GetBoolean(1),
                            CanViewUserTab = reader.GetBoolean(2)
                        });
                    }
                }

                return userPermissionsList;
            }
        }



        public async Task<bool> SaveUserPermissionAsync(UserPermissionDisplayItem permission)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    // Verificar si el usuario ya existe
                    var userId = await GetUserIdAsync(permission.UserName);

                    if (userId != null)
                    {
                        // Si existe, actualiza sus permisos
                        var query = @"UPDATE pya_apps.UserPermissions 
                              SET CanEditApps = @CanEditApps, CanViewUserTab = @CanViewUserTab
                              WHERE UserId = @UserId";

                        var command = new NpgsqlCommand(query, connection);
                        command.Parameters.AddWithValue("@CanEditApps", permission.CanEditApps);
                        command.Parameters.AddWithValue("@CanViewUserTab", permission.CanViewUserTab);
                        command.Parameters.AddWithValue("@UserId", userId);

                        var rowsAffected = await command.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                    else
                    {
                        // Si no existe, insertar el usuario y sus permisos
                        userId = await InsertUserAsync(permission.UserName, connection);

                        var query = @"INSERT INTO pya_apps.UserPermissions (UserId, CanEditApps, CanViewUserTab)
                              VALUES (@UserId, @CanEditApps, @CanViewUserTab)";

                        var command = new NpgsqlCommand(query, connection);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@CanEditApps", permission.CanEditApps);
                        command.Parameters.AddWithValue("@CanViewUserTab", permission.CanViewUserTab);

                        var rowsAffected = await command.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo del error (puedes registrar el error o mostrar un mensaje)
                // Opcional: log de errores
                Console.WriteLine($"Error al guardar permisos: {ex.Message}");
                return false;
            }
        }


        private async Task<int?> GetUserIdAsync(string userName)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT UserId FROM pya_apps.Users WHERE UserName = @UserName";
                var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", userName);

                var result = await command.ExecuteScalarAsync();

                return result != null ? (int?)result : null;
            }
        }

        private async Task<int> InsertUserAsync(string userName, NpgsqlConnection connection)
        {
            var query = "INSERT INTO pya_apps.Users (UserName) VALUES (@UserName) RETURNING UserId";
            var command = new NpgsqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", userName);

            return (int)await command.ExecuteScalarAsync();
        }


       
    }
}
