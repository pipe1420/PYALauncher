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

        public AddEditForm(string btnAcessibleName, List<Software> softwareList, DatabaseService databaseService)
        {
            InitializeComponent();


            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
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

            this._btnAcessibleName = btnAcessibleName;
            this._softwareList = softwareList;


            _databaseService = databaseService;

            Software software = FindByName(_btnAcessibleName);
            if (software != null)
            {
                LoadData(software);
            }
            else
            {
                MessageBox.Show("Aplicacion no encontrada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }


        }

        private void LoadData(Software software)
        {
            txtName.Text = software.SoftwareName;
            txtDescrip.Text = software.Descripcion;
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
            var resultPopUp = MessageBox.Show("¿Esta seguro que desea guardar los cambios a la aplicación?", "Guardar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultPopUp == DialogResult.Yes)
            {
                try
                {
                    var UpdateSoftware = new Software
                    {
                        Id = 0, // Asumiendo que el campo 'Id' es serial y se autogenera en la base de datos
                        Descripcion = "asd", //txtDescrip.Text,
                        Imagen = "img",
                        PathInstall = "asd2", //txtInstaller.Text,
                        SoftwareName = "Nombre del Software",
                        Tag = "Etiqueta",
                        UrlMsi = "http://ruta/a/instalador.msi",
                        VerificaApp = "Verificador",
                        Version = "1.0.0",
                        PathFile = "C:/ruta/al/archivo",
                        ForceInstall = false,
                        AutomaticInstall = true,
                        Guid = Guid.NewGuid().ToString(), // Genera un nuevo GUID
                        Grupos = new string[] { "Grupo1", "Grupo2" },
                        Hidden = false,
                        Actions = 1, // Según tus necesidades
                        Machines = new List<string> { "Equipo1", "Equipo2", "Equipo3" } // Lista de nombres de equipos
                    };

                    // Crear una instancia de MainController

                    // Llamar al método PutSoftware a través de la instancia
                    bool result = await _databaseService.InsertUpdateSoftware(UpdateSoftware);


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
                catch (Exception)
                {
                    // Manejo de excepciones
                    MessageBox.Show("Error al guardar los datos.", "Agregar / Editar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                
            }
        }

        public Software FindByName(string name)
        {
            return _softwareList.Find(software => software.SoftwareName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private void btnLoadMachines_Click(object sender, EventArgs e)
        {
            try
            {
                string pathFile = txtListMachines.Text;

                if (string.IsNullOrEmpty(pathFile))
                {
                    //ruta pegada no detectada
                }
                
                string filePath = SelectFileExcel();
                if (!string.IsNullOrEmpty(filePath))
                {
                    string[] equipos = readXLS(filePath);

                    if (equipos != null)
                    {
                        _nombresDeEquipos = equipos;
                    }
                    
                }
                else
                {
                    MessageBox.Show("No se seleccionó ningún archivo.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar archivo");
            }
        }

        public string[] readXLS(string FilePath)
        {
            var nombresDeEquipos = new List<string>();

            // Configuración necesaria para que EPPlus funcione correctamente con archivos .xlsx
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
         
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count

                // Lee las filas desde la segunda fila hasta el final
                for (int i = 2; i <= rowCount; i++)
                {
                    // Lee el valor de la primera columna
                    string nombre = worksheet.Cells[i, 1].Text;

                    // Si el valor no es nulo o vacío, añádelo a la lista
                    if (!string.IsNullOrEmpty(nombre))
                    {
                        nombresDeEquipos.Add(nombre);
                    }
                }

                return nombresDeEquipos.ToArray();
            }
        }

        private string SelectFileExcel()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtiene la ruta completa del archivo seleccionado
                    return openFileDialog.FileName;
                }
            }

            return null;
        }

        
    }
}
