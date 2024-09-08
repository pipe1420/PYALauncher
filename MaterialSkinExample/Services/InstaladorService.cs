using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYALauncherApps.Services
{
    public class InstaladorService
    {
        public int InstalarArchivoSilenciosamente(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;

                    // Verificar si es un archivo MSI o EXE
                    if (filePath.EndsWith(".msi"))
                    {
                        // Comprobar si el sistema es de 64 bits
                        string msiexecPath = Environment.Is64BitOperatingSystem
                            ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "msiexec.exe")
                            : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.SystemX86), "msiexec.exe");

                        process.StartInfo.FileName = msiexecPath; // Ejecutar msiexec para MSI
                        process.StartInfo.Arguments = $"/i \"{filePath}\" /quiet /norestart"; // Instalación silenciosa de MSI
                    }
                    else if (filePath.EndsWith(".exe"))
                    {
                        process.StartInfo.FileName = filePath; // Ejecutar el EXE

                        // Argumentos comunes para instalaciones silenciosas de EXE
                        // Puedes ajustar los argumentos si el instalador requiere otros (por ejemplo, /silent, /quiet)
                        process.StartInfo.Arguments = "/S /quiet /norestart"; // Ajusta según el instalador EXE específico
                    }
                    else
                    {
                        Console.WriteLine("Formato de archivo no soportado.");
                        return -1;
                    }

                    process.Start();
                    process.WaitForExit(); // Esperar que el proceso termine

                    // Verificar si la instalación fue exitosa
                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine("Instalación completada exitosamente.");
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine($"Error en la instalación. Código de salida: {process.ExitCode}");
                        return process.ExitCode;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al intentar instalar el archivo: {ex.Message}");
                    return -2;
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
                return -3;
            }
        }
    }
}
