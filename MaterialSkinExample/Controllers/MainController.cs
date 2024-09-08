using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PYALauncherApps.Models;
using PYALauncherApps.Services;

namespace PYALauncherApps.Controllers
{
    public class MainController
    {
        private readonly DatabaseService _databaseService;
        private MainForm _mainForm;

        public MainController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void SetMainForm(MainForm mainForm)
        {
            _mainForm = mainForm;
            OpenForm();
        }

        public void OpenForm()
        {
            if (_mainForm.InvokeRequired)
            {
                _mainForm.Invoke(new Action(() => OpenForm()));
            }
            else
            {
                Console.WriteLine("OpenForm()");
                _mainForm.InitializeAsync().GetAwaiter().GetResult();
                //_mainForm.ShowDialog();
            }
        }

        public async Task<List<Config>> LoadConfigs()
        {
            return await _databaseService.GetConfigs();
        }

        public async Task<List<Software>> LoadSoftware()
        {
            return await _databaseService.GetSoftware();
        }

        public async Task<bool> PutSoftware(Software software)
        {
            return await _databaseService.InsertUpdateSoftware(software);
        }

        public void InstallSoftware(List<Software> softwareList)
        {
            foreach (var software in softwareList)
            {
                Install(software);
            }
        }

        private void Install(Software software)
        {
            if (!string.IsNullOrEmpty(software.PathInstall))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = software.PathInstall,
                    Arguments = "", // Agrega argumentos si son necesarios
                    UseShellExecute = true
                };

                try
                {
                    Process.Start(startInfo);
                    Console.WriteLine($"Instalando {software.SoftwareName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al instalar {software.SoftwareName}: {ex.Message}");
                }
            }
        }
    }
}
