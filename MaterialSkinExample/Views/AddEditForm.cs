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
using System.Xml.Linq;


namespace PYALauncherApps.Views
{
    public partial class AddEditForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex;
        MaterialSkin.MaterialListBoxItem materialListBoxItem13 = new MaterialSkin.MaterialListBoxItem();
        private readonly MainController _mainController;
        private DatabaseService _databaseService;
        private string _btnAcessibleName;
        private List<Software> _softwareList;
        private string[] _nombresDeEquipos;
        private SoftwareService _softwareService;
        private Software softwareTemp = new Software();
        private readonly MainForm _mainForm;

        public AddEditForm(SoftwareService softwareService)
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
            //_mainController = mainController;
            //_mainForm = mainForm; // Asigna la instancia de MainForm
        }

        public async Task InitializeAsync()
        {
            // Inicializar las columnas del DataGridView
            InitializeDataGridViewColumns();

            if (_softwareService.GetSoftwareList() != null)
            {
                //Edicion de app
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
                    MessageBox.Show("Aplicación no encontrada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            else
            {
                InitializeAsyncEmpty();
            }

        }

        public async Task InitializeAsyncEmpty()
        {
            Debug.WriteLine("Limpiando formulario");
            // Si es una nueva aplicación, muestra el formulario sin datos pero con las columnas listas
            dataGridViewMachines.DataSource = new BindingList<MachineDisplayItem>();
            txtName.Text = "";
            txtVersion.Text = "";
            multiLineDescrip.Text = "";
            multiLinePathDll.Text = "";
            textSelectPathInstaller.Text = "";
            cbxModality.SelectedIndex = -1;
            cbxActions.SelectedIndex = -1;
            softwareTemp.ClearFields();

            this.ShowDialog();
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
            multiLineDescrip.Text = software.Descripcion;
            textSelectPathInstaller.Text = "";
            multiLinePathDll.Text = software.PathFile;
            txtVersion.Text = software.Version; 
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea eliminar la aplicación?", "Eliminar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool deleteResult = await _softwareService.DeleteSoftware(softwareTemp.Id);

                if (deleteResult)
                {
                    MessageBox.Show("Aplicación eliminada!", "Eliminar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la aplicación.", "Eliminar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // Validar que el campo Nombre y la Ruta del Instalador no estén vacíos
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("El nombre de la aplicación es obligatorio.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detener la ejecución si el campo está vacío
            }

            //if (string.IsNullOrWhiteSpace(textSelectPathInstaller.Text))
            //{
            //    MessageBox.Show("La ruta del instalador es obligatoria.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return; // Detener la ejecución si el campo está vacío
            //}

            var resultPopUp = MessageBox.Show("¿Está seguro que desea guardar los cambios a la aplicación?", "Guardar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultPopUp == DialogResult.Yes)
            {
                try
                {
                    // Limpiar las comillas de la ruta
                    string multiLinePathDllClean = multiLinePathDll.Text.Trim('\"');

                    // Crear objeto Software para la actualización
                    var UpdateSoftware = new Software
                    {
                        Id = softwareTemp.Id, // Asumiendo que el campo 'Id' es serial y se autogenera en la base de datos
                        Descripcion = multiLineDescrip.Text,
                        Imagen = "img",
                        PathInstall = multiLinePathDllClean,
                        SoftwareName = txtName.Text,
                        Tag = "tag",
                        UrlMsi = textSelectPathInstaller.Text,
                        VerificaApp = txtProcessVerificaApp.Text,
                        Version = txtVersion.Text,
                        PathFile = multiLinePathDllClean,
                        ForceInstall = cbxModality.SelectedIndex == 2 ? true : false,
                        AutomaticInstall = cbxActions.SelectedIndex == 1 ? true : false,
                        Guid = Guid.NewGuid().ToString(), // Genera un nuevo GUID
                        Grupos = new string[] { "Grupo1", "Grupo2" },
                        Hidden = false,
                        Actions = cbxActions.SelectedIndex, // Según tus necesidades
                        Machines = GetMachinesFromDataGridView(),
                        InstallerName = softwareTemp.InstallerName
                    };

                    // Llamar al método UpdateSoftware a través de la instancia de SoftwareService
                    bool result = await _softwareService.UpdateSoftware(UpdateSoftware);

                    if (result)
                    {
                        // La operación fue exitosa, ahora subir el archivo a Supabase
                        await SubirArchivoASupabase(textSelectPathInstaller.Text);

                        MessageBox.Show("Cambios guardados y archivo subido exitosamente.", "Agregar / Editar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
                    Debug.WriteLine($"Error al guardar los datos: {ex}");
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
            var software = await _softwareService.FindSoftware(softwareName);

            if (software != null && software.Machines != null)
            {
                var machineList = software.Machines.Select(m => new MachineDisplayItem
                {
                    MachineKey = m.Key,
                    Name = m.Value.Name,
                    User = m.Value.User
                }).ToList();

                dataGridViewMachines.DataSource = new BindingList<MachineDisplayItem>(machineList);
            }
            else
            {
                // Si no se encontraron máquinas, asignar una lista vacía pero con columnas definidas
                dataGridViewMachines.DataSource = new BindingList<MachineDisplayItem>();
                MessageBox.Show("No se encontraron máquinas para este software.");
            }
        }

        private void InitializeDataGridViewColumns()
        {
            // Limpiar columnas existentes
            dataGridViewMachines.Columns.Clear();

            // Agregar columnas manualmente
            dataGridViewMachines.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MachineKey",
                HeaderText = "MachineKey",
                DataPropertyName = "MachineKey"
            });

            dataGridViewMachines.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name"
            });

            dataGridViewMachines.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "User",
                HeaderText = "User",
                DataPropertyName = "User"
            });
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();          
        }

        // Método para subir el archivo a Supabase
        public async Task SubirArchivoASupabase(string filePath)
        {
            SupabaseService supabaseService = new SupabaseService();

            // Asegúrate de que la ruta del archivo no sea nula o vacía
            if (!File.Exists(filePath))
            {
                Debug.WriteLine("El archivo seleccionado no existe.");
                return;
            }
            else
            {
                await supabaseService.SubirArchivoAsync(filePath);
            }

        }

        private void btnSelectPathInstaller_Click(object sender, EventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => btnSelectPathInstaller_Click(sender, e)));
                    return;
                }

                // Crear una instancia de OpenFileDialog para seleccionar el archivo MSI
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Filtrar para mostrar solo archivos .msi
                    openFileDialog.Filter = "Archivos MSI o EXE (*.msi;*.exe)|*.msi;*.exe";
                    openFileDialog.Title = "Seleccione el archivo MSI o EXE";

                    // Mostrar el diálogo de selección de archivo
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Capturar la ruta del archivo seleccionado
                        string rutaMsi = openFileDialog.FileName;
                        softwareTemp.InstallerName = openFileDialog.SafeFileName; 

                        // Actualizar el control de texto con la ruta del archivo seleccionado
                        textSelectPathInstaller.Text = rutaMsi;

                        Console.WriteLine($"Ruta del archivo MSI seleccionada: {rutaMsi}");
                    }
                    else
                    {
                        Console.WriteLine("No se seleccionó ningún archivo.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción inesperada y mostrarla
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
