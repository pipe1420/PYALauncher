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

    }
}
