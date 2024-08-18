using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PYALauncherApps;
using PYALauncherApps.Controllers;
using PYALauncherApps.Models;
using PYALauncherApps.Services;
using PYALauncherApps.Views;

namespace MaterialSkinExample
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            // Configurar el contenedor de servicios
            var services = new ServiceCollection();
            ConfigureServices(services);
            
            // Crear el proveedor de servicios
            var serviceProvider = services.BuildServiceProvider();
            var mainController = serviceProvider.GetRequiredService<MainController>();
            var mainForm = serviceProvider.GetRequiredService<MainForm>();

            mainController.SetMainForm(mainForm);
            await mainController.OpenForm();

            // Iniciar la aplicación
            //Application.Run(mainForm);

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Registrar servicios y componentes
            services.AddSingleton<DatabaseService>();
            services.AddSingleton<SoftwareModel>();
            services.AddSingleton<SoftwareService>(); 
            services.AddSingleton<MainController>();
            services.AddSingleton<MainForm>();
            //services.AddSingleton<MainMenu>();
            services.AddScoped<AddEditForm>();



            /* Casos Inyección de dependencias 
             
             Transient: Una nueva instancia del servicio es creada cada vez que se solicita.
                        Ideal para solicitudes aisladas que no necesiten seguimiento
                        Malo en rendimiento por creacion de instancias nuevas o repetivas cada vez

             Scoped:    Una nueva instancia del servicio se crea una vez por solicitud 
                        (por ejemplo, una solicitud HTTP en una aplicación web). 
                        La misma instancia se reutiliza durante toda la solicitud.

                        Ideal para solictudes que ida y vuelta de datos
                        Malo para la gestion de memoria(fugas) y recursos, deben ser administrados

            Singleton:  Una sola instancia del servicio se crea la primera vez que se solicita, 
                        y la misma instancia se reutiliza en todas las solicitudes durante toda la vida de la aplicación.
                    
                        Ideal para servicios o caché global y accesible en toda la aplicación, ej datos de logging, buen rendimiento
                        Malo para manejar concurrencias de datos si no se maneja correctamente
             
            Cuándo Usar Cada Uno
	            • Transient     : Úsalo cuando necesites instancias nuevas y sin estado para cada solicitud.
	            • Scoped        : Ideal para servicios que deben mantener consistencia de estado durante una solicitud completa como solicitudes HTTP (ida y vuelta de datos)
	            • Singleton     : Útil para servicios que necesitan compartir información o estado globalmente a lo largo de la aplicación.

             */
        }
    }
}