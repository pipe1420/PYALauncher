using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PYALauncherApps.Services
{
    public class SupabaseService
    {
        private readonly string _supabaseUrl = "https://zbstyiewgraliyyegilv.supabase.co"; // Reemplaza con tu URL de Supabase
        private readonly string _supabaseApiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inpic3R5aWV3Z3JhbGl5eWVnaWx2Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MjU4MTIxMzIsImV4cCI6MjA0MTM4ODEzMn0.BWepdjZ0FJ7N-nFuka6iZzqEQB6spxv-elIKJS0CTkQ"; // Reemplaza con tu API Key de Supabase
        private readonly string bucket = "apps";

        // Método para descargar un archivo desde un bucket de Supabase
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


        // Método para subir un archivo a Supabase
        public async Task SubirArchivoAsync(string filePath, string destinationPath)
        {
            // Crear cliente HTTP para hacer la petición
            using (var client = new HttpClient())
            {
                // Establecer las cabeceras de autenticación
                client.DefaultRequestHeaders.Add("apikey", _supabaseApiKey);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _supabaseApiKey);

                // Leer el archivo que se va a subir
                var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                // Construir la URL para la subida
                var uploadUrl = $"{_supabaseUrl}/storage/v1/object/{bucket}/{destinationPath}";

                // Hacer la petición POST para subir el archivo
                var response = await client.PostAsync(uploadUrl, fileContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Archivo subido exitosamente.");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al subir archivo: {response.StatusCode}, {errorContent}");
                }
            }
        }
    }
}
