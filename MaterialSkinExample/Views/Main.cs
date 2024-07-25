using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using PYALauncherApps.Controllers;
using PYALauncherApps.Models;
using PYALauncherApps.Services;

namespace PYALauncherApps.Views
{
    public partial class Main : MaterialForm
    {
        private readonly MainController _controller;
        DatabaseService databaseService = new DatabaseService();
        private List<Config> _configs;
        private List<Software> _softwareList;
        private Timer updateTimer;
        public readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex;

        public Main()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red700, Primary.Red900, Primary.Red100, Accent.Red200, TextShade.WHITE);
            colorSchemeIndex = PYALauncherApps.Properties.Settings.Default.codigoTema;

            // Inicializa controller
            _controller = new MainController(databaseService);

            InitializeTimer();
            LoadData();
        }


        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 10000; // 10 segundos
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            updateTimer.Start(); // Iniciar el timer
        }

        private void LoadData()
        {
            _configs = _controller.LoadConfigs();
            _softwareList = _controller.LoadSoftware();

            // Mostrar los datos en la interfaz gráfica
            listBoxConfigs.DataSource = _configs;
            listBoxSoftware.DataSource = _softwareList;

            foreach (var item in _configs)
            {
                materialListBoxConfigs.AddItem(item.ToString());
            }

            foreach (var item in _softwareList)
            {
                materialListBoxSoftware.AddItem(item.ToString());
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            var newConfigs = _controller.LoadConfigs();
            var newSoftwareList = _controller.LoadSoftware();

            bool configsChanged = !AreListsEqual(_configs, newConfigs);
            bool softwareChanged = !AreListsEqual(_softwareList, newSoftwareList);

            if (configsChanged)
            {
                _configs = newConfigs;
                listBoxConfigs.DataSource = null;
                listBoxConfigs.DataSource = _configs;
                Console.WriteLine("La lista de configuraciones ha cambiado.");
            }
            else
            {
                Console.WriteLine("La lista de configuraciones no ha cambiado.");
            }

            if (softwareChanged)
            {
                _softwareList = newSoftwareList;
                listBoxSoftware.DataSource = null;
                listBoxSoftware.DataSource = _softwareList;
                Console.WriteLine("La lista de software ha cambiado.");
            }
            else
            {
                Console.WriteLine("La lista de software no ha cambiado.");
            }
        }

        private bool AreListsEqual<T>(List<T> list1, List<T> list2)
        {
            if (list1 == null && list2 == null) return true;
            if (list1 == null || list2 == null) return false;
            if (list1.Count != list2.Count) return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
            return true;
        }


        private void InstallButton_Click(object sender, EventArgs e)
        {
            List<Software> selectedSoftware = new List<Software>();

            foreach (var item in checkedListBoxSoftware.CheckedItems)
            {
                selectedSoftware.Add(item as Software);
            }

            _controller.InstallSoftware(selectedSoftware);
        }



    }
}
