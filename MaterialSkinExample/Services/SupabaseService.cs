using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Supabase;
using Newtonsoft.Json;
using PYALauncherApps.Models;
using System.Diagnostics;
using static Supabase.Postgrest.Constants;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace PYALauncherApps.Services
{
    public class SupabaseService
    {
        private readonly string _supabaseUrl = "https://zbstyiewgraliyyegilv.supabase.co"; // Reemplaza con tu URL de Supabase
        private readonly string _supabaseUrlDDBB = "https://postgres.zbstyiewgraliyyegilv:KY!57HKc7iuamXX@aws-0-sa-east-1.pooler.supabase.com:6543/postgres"; // Reemplaza con tu URL de Supabase
        private readonly string _supabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inpic3R5aWV3Z3JhbGl5eWVnaWx2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU4MTIxMzIsImV4cCI6MjA0MTM4ODEzMn0.BWepdjZ0FJ7N-nFuka6iZzqEQB6spxv-elIKJS0CTkQ"; // Reemplaza con tu API Key de Supabase
        private readonly string bucket = "apps";
        private HttpClient _httpClient;
        private Supabase.Client _client;

        public SupabaseService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_supabaseUrlDDBB);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _supabaseApiKey);
            _httpClient.DefaultRequestHeaders.Add("apikey", _supabaseApiKey);


            _client = new Supabase.Client(_supabaseUrl, _supabaseApiKey);
        }

        public async Task<string> GetConfigs()
        {
            var response = await _httpClient.GetAsync("/rest/v1/configs?select=*");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }


        /// <summary>
        /// Método para descargar un archivo desde un bucket de Supabase
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="downloadPath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> DescargarArchivoAsync(string filePath, string downloadPath)
        {
            var url = $"{_supabaseUrl}/storage/v1/object/public/{bucket}/{filePath}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("apikey", _supabaseApiKey);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var fileFullPath = Path.Combine(downloadPath, Path.GetFileName(filePath));

                    // Usar el método sincrónico WriteAllBytes
                    File.WriteAllBytes(fileFullPath, content);

                    return fileFullPath; // Retorna la ruta completa del archivo descargado
                }
                else
                {
                    throw new Exception($"Error al descargar el archivo: {response.StatusCode}");
                }
            }
        }

        
        /// Método para subir un archivo a Supabase
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task SubirArchivoAsync(string filePath)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    // Establecer las cabeceras de autenticación
                    client.DefaultRequestHeaders.Add("apikey", _supabaseApiKey);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _supabaseApiKey);

                    // Obtener el nombre del archivo desde la ruta
                    string fileName = Path.GetFileName(filePath);

                    // Crear el contenido del archivo en el formato multipart
                    var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    var formContent = new MultipartFormDataContent();
                    formContent.Add(new StreamContent(fileStream), "file", fileName);

                    // Construir la URL para la subida (incluir el nombre del archivo)
                    var uploadUrl = $"{_supabaseUrl}/storage/v1/object/apps/{fileName}";

                    // Comprobar si el archivo ya existe (opcional)
                    var checkResponse = await client.GetAsync(uploadUrl);
                    bool fileExists = checkResponse.IsSuccessStatusCode;

                    // Si el archivo ya existe, usar PUT para sobrescribirlo
                    HttpResponseMessage response;
                    if (fileExists)
                    {
                        response = await client.PutAsync(uploadUrl, formContent); // Usar PUT para sobrescribir
                    }
                    else
                    {
                        response = await client.PostAsync(uploadUrl, formContent); // Usar POST para subir por primera vez
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        Debug.WriteLine("Archivo subido exitosamente.");
                    }
                    else
                    {
                        // Manejar el error con detalle
                        var errorContent = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Error al subir archivo: {response.StatusCode}, {errorContent}");
                    }


                }
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y mostrarla
                Console.WriteLine($"Excepción durante la subida: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteSoftware(int id)
        {
            var response = await _httpClient.DeleteAsync($"/rest/v1/software?id=eq.{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Software>> GetSoftware()
        {
            try
            {
                // Asegurarse de inicializar el cliente
                await _client.InitializeAsync();

                // Obtener los registros desde la tabla "software" donde "hidden = false"
                var response = await _client.From<Software>()
                    .Where(s => s.Hidden == false)
                    .Order(x => x.SoftwareName, Ordering.Ascending)
                    .Get();

                // Verificar los datos recibidos (temporalmente para depuración)
                var softwareList = response.Models;

                if (softwareList == null || !softwareList.Any())
                {
                    throw new Exception("La lista de software está vacía o es nula.");
                }

                foreach (var software in softwareList)
                {
                    if (software.Grupos == null)
                    {
                        Debug.WriteLine($"Software '{software.SoftwareName}' no tiene grupos asignados.");
                    }
                    else
                    {
                        Debug.WriteLine($"Software '{software.SoftwareName}' tiene {software.Grupos.Length} grupos.");
                    }
                }

                return softwareList;
            }
            catch (JsonSerializationException ex)
            {
                Debug.WriteLine($"Error de deserialización JSON: {ex.Message}");
                throw; // O maneja el error según tu contexto
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        public async Task<List<UserPermissionDisplayItem>> GetAllUserPermissionsAsync()
        {
            // Asegúrate de inicializar el cliente de Supabase
            await _client.InitializeAsync();
            
            // Realiza el query con InnerJoin
            var result = await _client
                .From<UserPermissions>()
                .Select("*, users:userid(username)")  // Notación para hacer un Inner Join en Supabase
                .Get();

            var usuarios = await _client
                .From<Users>()
                .Select("id, username")  // Notación para hacer un Inner Join en Supabase
                .Get();

            var usersList = new List<Users>();
            foreach (var user in usuarios.Models)
            {
                usersList.Add(new Users
                {
                    Id = user.Id,
                    Username = user.Username
                });
            }

            var userPermissionsList = new List<UserPermissionDisplayItem>();
            foreach (var userPermission in result.Models)
            {
                var username = usersList.FirstOrDefault(u => u.Id == userPermission.UserID)?.Username;
                // Accede directamente a las propiedades del modelo UserPermissions
                userPermissionsList.Add(new UserPermissionDisplayItem
                {
                    UserName = username,
                    CanEditApps = userPermission.CanEditApps,
                    CanViewUserTab = userPermission.CanViewUserTab
                });
            }

            //foreach (var item in userPermissionsList)
            //{
            //    Debug.WriteLine(item.UserName);
            //    Debug.WriteLine(item.CanEditApps);
            //    Debug.WriteLine(item.CanViewUserTab);
            //}

            return userPermissionsList;
        }

    }
}
