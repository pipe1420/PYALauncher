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
        private readonly SupabaseService _supabaseService;
        private MainForm _mainForm;

        public MainController(DatabaseService databaseService, SupabaseService supabaseService)
        {
            _databaseService = databaseService;
            _supabaseService = supabaseService;
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
            //var data = await _databaseService.GetSoftware();
            var dataSupabase = await _supabaseService.GetSoftware();
            
            return dataSupabase;
        }

        public async Task<bool> PutSoftware(Software software)
        {
            return await _databaseService.InsertUpdateSoftware(software);
        }

    }
}
