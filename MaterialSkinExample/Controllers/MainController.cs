using System;
using System.Collections.Generic;
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

        public MainController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<Config> LoadConfigs()
        {
            return _databaseService.GetConfigs();
        }

        public List<Software> LoadSoftware()
        {
            return _databaseService.GetSoftware();
        }
    }
}
