﻿using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using PYALauncherApps;
using PYALauncherApps.Controllers;
using PYALauncherApps.Models;
using PYALauncherApps.Services;
using PYALauncherApps.Views;

namespace PYALauncherApps
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Iniciar la aplicación en el hilo principal de la UI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configurar el contenedor de servicios
            var services = new ServiceCollection();
            ConfigureServices(services);

            // Crear el proveedor de servicios
            var serviceProvider = services.BuildServiceProvider();
            var mainController = serviceProvider.GetRequiredService<MainController>();
            var mainForm = serviceProvider.GetRequiredService<MainForm>();

            mainController.SetMainForm(mainForm);

            // Iniciar el ciclo de vida de la aplicación
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Registrar servicios y componentes
            services.AddSingleton<DatabaseService>();
            services.AddScoped<SupabaseService>();
            services.AddSingleton<SoftwareModel>();
            services.AddSingleton<MainForm>();
            services.AddSingleton<SoftwareService>();
            services.AddSingleton<UsersService>();
            services.AddSingleton<MainController>();
            services.AddSingleton<AddEditForm>();
        }
    }
}
