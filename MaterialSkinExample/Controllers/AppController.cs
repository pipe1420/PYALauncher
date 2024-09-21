using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using PYALauncherApps.Models;
using PYALauncherApps.Services;

namespace PYALauncherApps.Controllers
{
    public class AppController
    {

        #region OLD
        //private static MainForm _formulario = new MainForm();
        private static List<Config> _configList = new List<Config>();
        private static List<Software> _softwareList = new List<Software>();

        public static void Initialize()
        {
            Console.WriteLine("Initialize()");
            //GetConfigAsync();
            //GetSoftwareAsync();
            OpenForm();
        }
        public static void OpenForm()
        {
            Console.WriteLine("OpenForm()");
            //EjecucionPorLapsosAsync();
            //_formulario.ShowDialog();
        }

        public static void GetConfigAsync()
        {
            Console.WriteLine("GetConfigAsync()");
            //_softwareList = _serviceSoftware.GetSoftwareListPSQL();
        }

        public static void GetSoftwareAsync()
        {
            Console.WriteLine("GetSoftwareAsync()");
            //_softwareList = _serviceSoftware.GetSoftwareListPSQL();
        }
        #endregion
    }
}
