using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PYALauncherApps.Controllers;
using System.Security.Policy;
using PYALauncherApps.Models;
using System.IO;
using OfficeOpenXml;
using PYALauncherApps.Services;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace PYALauncherApps.Views
{
    public partial class AddEditForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex;
        MaterialSkin.MaterialListBoxItem materialListBoxItem13 = new MaterialSkin.MaterialListBoxItem();
        private readonly MainController _controller;
        private DatabaseService _databaseService;
        private string _btnAcessibleName;
        private List<Software> _softwareList;
        private string[] _nombresDeEquipos;
        private SoftwareService _softwareService;
        private Software softwareTemp = new Software();

        public AddEditForm(SoftwareService softwareService/*,string btnAcessibleName, List<Software> softwareList, DatabaseService databaseService*/)
        {
            InitializeComponent();


            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red700, Primary.Red900, Primary.Red100, Accent.Red200, TextShade.WHITE);

            colorSchemeIndex = PYALauncherApps.Properties.Settings.Default.codigoTema;

            bool tst = PYALauncherApps.Properties.Settings.Default.estiloTema;
            updateColor();
            if (tst == true)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }

            _softwareService = softwareService;
        }

        public async Task InitializeAsync()
        {

            if (_softwareService.GetSoftwareList() != null)
            {
                this._btnAcessibleName = _softwareService.GetSoftwareName();
                this._softwareList = _softwareService.GetSoftwareList();

                Software software = FindByName(_btnAcessibleName);
                if (software != null)
                {
                    LoadData(software);
                    this.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Aplicacion no encontrada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Dispose();
                }
            }

        }

        private void LoadData(Software software)
        {
            softwareTemp.Id = software.Id;
            softwareTemp.Descripcion = software.Descripcion;
            softwareTemp.Imagen = software.Imagen;
            softwareTemp.PathInstall = software.PathInstall;
            softwareTemp.SoftwareName = software.SoftwareName;
            softwareTemp.Tag = software.Tag;
            softwareTemp.UrlMsi = software.UrlMsi;
            softwareTemp.VerificaApp = software.VerificaApp;
            softwareTemp.Version = software.Version;
            softwareTemp.PathFile = software.PathFile;
            softwareTemp.ForceInstall = software.ForceInstall;
            softwareTemp.AutomaticInstall = software.AutomaticInstall;
            softwareTemp.Guid = software.SoftwareName;
            softwareTemp.Grupos = software.Grupos;
            softwareTemp.Hidden = software.Hidden;
            softwareTemp.Actions = software.Actions;
            softwareTemp.Machines = software.Machines;


            //var softwareFind = _softwareService.FindSoftware(software.SoftwareName);
            txtName.Text = software.SoftwareName;
            txtDescrip.Text = software.Descripcion;
            txtInstaller.Text = software.UrlMsi;
            cbxActions.SelectedIndex = 0;

            /* Acciones de la aplicacion
             cbxModality 
                0 = Instalacion
                1 = Actualizacion
                2 = Desinstalacion      
            */

            if (software.Actions == 0)
            {
                cbxActions.SelectedIndex = 0;
            }
            else if (software.Actions == 1)
            {
                cbxActions.SelectedIndex = 1;
            }
            else if(software.Actions == 2)
            {
                cbxActions.SelectedIndex = 2;
            }

            /* Modalidades de instalacion
             cbxModality 
                0 = Manual
                1 = Automatica
                2 = Forzada            
            */
            if (software.AutomaticInstall) {
                cbxModality.SelectedIndex = 1;
            }else if (software.ForceInstall)
            {
                cbxModality.SelectedIndex = 2;
            }
            else
            {
                cbxModality.SelectedIndex = 0;
            }

            LoadMachines(software.SoftwareName);

        }

        private void updateColor()
        {
            //These are just example color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal500 : Primary.Indigo500,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal700 : Primary.Indigo700,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal200 : Primary.Indigo100,
                        Accent.Pink200,
                        TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Red700 : Primary.Red700,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Red900 : Primary.Red900,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Red100 : Primary.Red100,
                        Accent.Red200,
                        TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.BlueGrey800,
                        Primary.BlueGrey900,
                        Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);
                    break;
                case 3:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Red700,
                        Primary.Red900,
                        Primary.Red100,
                        Accent.Red200,
                        TextShade.WHITE);
                    break;
            }

            PYALauncherApps.Properties.Settings.Default.codigoTema = colorSchemeIndex;
            PYALauncherApps.Properties.Settings.Default.Save();
            Invalidate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Esta seguro que desea eliminar la aplicación?", "Eliminar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Aplicacion eliminada!", "Eliminar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }


        private async void btnSave_Click(object sender, EventArgs e)
        {
            var resultPopUp = MessageBox.Show("¿Está seguro que desea guardar los cambios a la aplicación?", "Guardar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultPopUp == DialogResult.Yes)
            {
                try
                {
                    var UpdateSoftware = new Software
                    {
                        Id = softwareTemp.Id, // Asumiendo que el campo 'Id' es serial y se autogenera en la base de datos
                        Descripcion = txtDescrip.Text,
                        Imagen = "img",
                        PathInstall = "asd2",
                        SoftwareName = txtName.Text,
                        Tag = "tag",
                        UrlMsi = txtInstaller.Text,
                        VerificaApp = "test",
                        Version = "1.0.0",
                        PathFile = @"c:\ubicacion\app.dll",
                        ForceInstall = cbxModality.SelectedIndex == 2 ? true : false,
                        AutomaticInstall = cbxActions.SelectedIndex == 1 ? true : false,
                        Guid = Guid.NewGuid().ToString(), // Genera un nuevo GUID
                        Grupos = new string[] { "Grupo1", "Grupo2" },
                        Hidden = false,
                        Actions = cbxActions.SelectedIndex, // Según tus necesidades
                        Machines = GetMachinesFromDataGridView()
                    };

                    // Llamar al método UpdateSoftware a través de la instancia de SoftwareService
                    bool result = await _softwareService.UpdateSoftware(UpdateSoftware);

                    if (result)
                    {
                        // La operación fue exitosa
                        MessageBox.Show("Cambios guardados!", "Agregar / Editar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
                    {
                        // La operación falló
                        MessageBox.Show("Fallo el guardado de datos.", "Agregar / Editar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Agregar / Editar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public Software FindByName(string name)
        {
            return _softwareList.Find(software => software.SoftwareName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
       
        // Método para cargar las máquinas en el DataGridView
        private async void LoadMachines(string softwareName)
        {
            // Espera a que LoadSoftwareMachines termine y obtén las máquinas
            var software = await _softwareService.FindSoftware(softwareName);

            if (software != null && software.Machines != null)
            {
                // Convertimos el diccionario en una lista para mostrar en el DataGridView
                var machineList = software.Machines.Select(m => new MachineDisplayItem
                {
                    MachineKey = m.Key,
                    Name = m.Value.Name,
                    User = m.Value.User
                }).ToList();

                // Asigna la lista al DataGridView
                dataGridViewMachines.DataSource = new BindingList<MachineDisplayItem>(machineList);
            }
            else
            {
                MessageBox.Show("No se encontraron máquinas para este software.");
            }
        }

        private Dictionary<string, Machine> GetMachinesFromDataGridView()
        {
            var machines = new Dictionary<string, Machine>();

            foreach (DataGridViewRow row in dataGridViewMachines.Rows)
            {
                if (row.IsNewRow) continue; // Omite la fila de inserción (nueva fila)

                var machineKey = row.Cells["MachineKey"].Value?.ToString(); // Columna clave
                var machineName = row.Cells["Name"].Value?.ToString(); // Columna nombre
                var machineUser = row.Cells["User"].Value?.ToString(); // Columna usuario

                if (!string.IsNullOrEmpty(machineKey))
                {
                    machines[machineKey] = new Machine
                    {
                        Name = machineName,
                        User = machineUser
                    };
                }
            }

            return machines;
        }
    }
}
