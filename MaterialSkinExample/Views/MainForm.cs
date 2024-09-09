using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Management;
using PYALauncherApps.Models;
using System.Collections.Generic;
using PYALauncherApps.Controllers;
using PYALauncherApps.Services;
using PYALauncherApps.Views;
using System.ComponentModel;
using System.Net.Http;
using NLog;
using System.Security.Policy;
using Microsoft.Win32;

namespace PYALauncherApps
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex;
        MaterialSkin.MaterialListBoxItem materialListBoxItem13 = new MaterialSkin.MaterialListBoxItem();
        private readonly MainController _mainController;
        private DatabaseService _databaseService;
        private AddEditForm _addEditForm;
        private Timer updateTimer;
        private List<Config> _configs;
        private List<Software> _softwareList;
        private readonly SoftwareService _softwareService;
        private readonly UsersService _usersService;
        private TabPage tabPageHidePermisos, tabPageHideLogs;
        private List<UserPermissionDisplayItem> _userPermissionsList;
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private MaterialSnackBar SnackBarMessage;

        public MainForm(DatabaseService databaseService, MainController mainController, AddEditForm addEditForm, SoftwareService softwareService, UsersService usersService)
        {
            InitializeComponent();
            tabPageHidePermisos = materialTabControl1.TabPages["tabPagePerm"];
            tabPageHideLogs = materialTabControl1.TabPages["tabPageLogs"];
            materialTabControl1.TabPages.Remove(tabPageHideLogs);

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

            _databaseService = databaseService;
            _mainController = mainController;
            _addEditForm = addEditForm;
            _softwareService = softwareService;
            _usersService = usersService;
            _usersService = usersService;
            
            LoadUserPermissions();

        }


        public async Task InitializeAsync()
        {
            //Inicia proceso de captura de configuraciones generales
            //EjecucionPorLapsosAsync();

            //New
            
            InitializeTimer();
            ReloadApps();
            //LoadDataAsync();
            

            Console.WriteLine("UserDomainName : " + Environment.UserDomainName);
            Console.WriteLine("UserName: {0}", Environment.UserName);
        }
        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 30000; // 10 segundos
            updateTimer.Tick += new EventHandler(async (sender, e) => await UpdateSoftwareListAsync());
            updateTimer.Start(); // Iniciar el timer
        }

        private async void updateTimer_TickAsync(object sender, EventArgs e)
        {
            try
            {
                var newConfigs = await _mainController.LoadConfigs();
                var newSoftwareList = await _mainController.LoadSoftware();

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
                    // Crear y agregar tarjetas dinámicamente en el FlowLayoutPanel
                    CreateCards(_softwareList);
                }
                else
                {
                    Console.WriteLine("La lista de software no ha cambiado.");
                }


            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private bool AreListsEqual<T>(List<T> list1, List<T> list2)
        {
            if (list1 == null && list2 == null) return true;
            if (list1 == null || list2 == null) return false;
            return list1.SequenceEqual(list2);
        }


        private async Task LoadDataAsync()
        {
            // Cargar los datos de la base de datos
            _configs = await _mainController.LoadConfigs();
            _softwareList = await _mainController.LoadSoftware();

            // Mostrar los datos en la interfaz gráfica
            listBoxConfigs.DataSource = _configs;
            listBoxSoftware.DataSource = _softwareList;

            // Limpiar cualquier elemento previo en las listas
            materialListBoxConfigs.Clear();
            materialListBoxSoftware.Clear();

            // Añadir items a los listBox
            foreach (var item in _configs)
            {
                materialListBoxConfigs.AddItem(item.ToString());
            }

            foreach (var item in _softwareList)
            {
                materialListBoxSoftware.AddItem(item.ToString());
            }

            // Crear y agregar tarjetas dinámicamente en el FlowLayoutPanel
            CreateCards(_softwareList);
        }

        private void CreateCards(List<Software> softwareList)
        {
            try
            {
                bool canEditApps = false;

                var currentUserPermission = _userPermissionsList
                    .FirstOrDefault(up => up.UserName.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase));

                if (currentUserPermission != null)
                {
                    canEditApps = currentUserPermission.CanEditApps;
                }

                flowLayoutPanel2.Controls.Clear(); // Limpiar cualquier control previo

                foreach (var software in softwareList)
                {
                    // Crear la tarjeta
                    MaterialCard card = new MaterialCard
                    {
                        BackColor = System.Drawing.Color.FromArgb(255, 255, 255),
                        Depth = 0,
                        ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0),
                        Margin = new Padding(9),
                        MouseState = MaterialSkin.MouseState.HOVER,
                        Padding = new Padding(19, 17, 19, 17),
                        Size = new System.Drawing.Size(650, 150),
                        TabIndex = 70
                    };

                    // Crear y configurar el título
                    MaterialLabel labelTitulo = new MaterialLabel
                    {
                        AutoSize = true,
                        Depth = 0,
                        Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel),
                        FontType = MaterialSkin.MaterialSkinManager.fontType.H6,
                        HighEmphasis = true,
                        Location = new System.Drawing.Point(23, 17),
                        Margin = new Padding(4, 0, 4, 0),
                        MouseState = MaterialSkin.MouseState.HOVER,
                        Text = software.SoftwareName
                    };

                    // Crear y configurar el cuerpo
                    MaterialLabel body = new MaterialLabel
                    {
                        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                        Depth = 0,
                        Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel),
                        Location = new System.Drawing.Point(23, 64),
                        Margin = new Padding(4, 0, 4, 0),
                        MouseState = MaterialSkin.MouseState.HOVER,
                        Size = new System.Drawing.Size(480, 90),
                        Text = software.Descripcion
                    };

                    // Crear y configurar el botón instalar
                    MaterialButton buttonInstall = new MaterialButton
                    {
                        Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                        AutoSizeMode = AutoSizeMode.GrowOnly,
                        AutoSize = false,
                        Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default,
                        Depth = 0,
                        HighEmphasis = true,
                        Location = new System.Drawing.Point(527, 30),
                        Margin = new Padding(0),
                        MouseState = MaterialSkin.MouseState.HOVER,
                        NoAccentTextColor = System.Drawing.Color.Empty,
                        Size = new System.Drawing.Size(100, 36),
                        TabIndex = 1,
                        Text = "Instalar" // Este texto puede variar según el estado del software
                    };

                    // Crear y configurar el botón instalar
                    MaterialButton buttonEdit = new MaterialButton
                    {
                        Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                        AutoSizeMode = AutoSizeMode.GrowOnly,
                        AutoSize = false,
                        Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default,
                        Depth = 0,
                        HighEmphasis = true,
                        Location = new System.Drawing.Point(527, 80),
                        Margin = new Padding(0),
                        MouseState = MaterialSkin.MouseState.HOVER,
                        NoAccentTextColor = System.Drawing.Color.Empty,
                        Size = new System.Drawing.Size(100, 36),
                        TabIndex = 1,
                        Text = "Editar",
                        AccessibleName = software.SoftwareName.ToString(),
                        Enabled = canEditApps ? true : false
                    };

                    string localVersion = LocalVersionApp(software.PathInstall, software.SoftwareName);
                    MaterialLabel labelVersion = new MaterialLabel
                    {
                        AutoSize = true,
                        Depth = 0,
                        Enabled = false,
                        Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel),
                        //FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2,
                        ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
                        Location = new System.Drawing.Point(23, 43),
                        Margin = new System.Windows.Forms.Padding(4, 0, 4, 0),
                        MouseState = MaterialSkin.MouseState.HOVER,
                        Size = new System.Drawing.Size(269, 17),
                        TabIndex = 82,
                        Text = localVersion != null ? Text = $"Version: {localVersion}" : Text = ""
                    };

                    // Verificar si el software ya está instalado y actualizar el texto del botón
                    if (VerificaInstalacion(software.PathInstall))
                    {
                        buttonInstall.Text = "Instalado";
                        buttonInstall.Enabled = false;
                    }

                    // Configurar el evento Click del botón
                    buttonInstall.Click += async (sender, e) =>
                    {
                        await Task.Run(() =>
                        {
                            //ValidaDescarga(sender, e, software.UrlMsi, software.Version, software.PathFile, software.ForceInstall.ToString(), software.VerificaApp, software.AutomaticInstall.ToString(), software.PathInstall, true, software.SoftwareName);
                            DescargarEInstalar(software.InstallerName);
                        });
                    };
                    buttonEdit.Click += new EventHandler(AddEdit_Click);


                    // Agregar controles a la tarjeta
                    card.Controls.Add(labelTitulo);
                    card.Controls.Add(labelVersion);
                    card.Controls.Add(body);
                    card.Controls.Add(buttonInstall);
                    //if (canEditApps) 
                    card.Controls.Add(buttonEdit);


                    // Agregar la tarjeta al FlowLayoutPanel
                    flowLayoutPanel2.Controls.Add(card);


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error CreateCards : " + ex);
            }
        }



        // Método que se ejecuta al hacer clic en el botón
        private void AddEdit_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(AddEdit_Click), sender, e);
                return;
            }

            Button button = (Button)sender;
            string btnAcessibleName = button.AccessibleName;

            if(button.Text == "Editar")
            {
                _softwareService.SetSoftwareList(_softwareList);
                _softwareService.SetSoftwareName(button.AccessibleName);

                Debug.WriteLine("AddEdit_Click Editar: " + button.Text); // Datos recibidos
                _addEditForm.InitializeAsync();
                
            }

            if (button.Text == "Agregar")
            {
                Debug.WriteLine("AddEdit_Click Agregar: " + button.Text); // Datos recibidos
                _addEditForm.InitializeAsyncEmpty();
            }

            Debug.WriteLine("AddEdit_Click SoftwareName: " + button.AccessibleName); // Datos recibidos
        }

        private async Task UpdateSoftwareListAsync()
        {
            ReloadApps();

            //var newSoftwareList = await _mainController.LoadSoftware();

            //// Comprobar si la lista ha cambiado
            //bool softwareChanged = !AreListsEqual(_softwareList, newSoftwareList);

            //if (softwareChanged)
            //{
            //    _softwareList = newSoftwareList;
            //    // Actualizar las tarjetas si la lista cambió
            //    CreateCards(_softwareList);
            //}
            //else
            //{
            //    // Incluso si la lista no cambió, actualizar el estado de los botones
            //    CreateCards(_softwareList);
            //}
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            //materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;


            if (materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                PYALauncherApps.Properties.Settings.Default.estiloTema = false;
                PYALauncherApps.Properties.Settings.Default.Save();
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                PYALauncherApps.Properties.Settings.Default.estiloTema = true;
                PYALauncherApps.Properties.Settings.Default.Save();
            }


            //updateColor();
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

        private void materialButton32_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://webmail.pyaing.cl/intranet/soporte/views/user.php");
        }

        private void materialButton30_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.pya.cl");
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2)
                colorSchemeIndex = 0;
            updateColor();
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Focus();
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            //Carga datos dinamicos de la nube
            //loadCardAsync();
        }
        public int CompararVersionApp(string pathInstall, string versionWeb)
        {
            string versionLocal = "Null";

            try
            {
                if (File.Exists(pathInstall))
                {
                    FileVersionInfo infoArchivo = FileVersionInfo.GetVersionInfo(pathInstall);
                    versionLocal = infoArchivo.FileVersion;

                    Version v1 = new Version(versionLocal);
                    Version v2 = new Version(versionWeb);
                    //Console.WriteLine("Versión local = " + versionLocal + ", Version web es = " + versionWeb + "\n\n");

                    return v1.CompareTo(v2);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Error al verificar version: " + versionWeb + " en ruta: " + pathInstall);
            }
            //return 10 para error
            return 10;
        }


        public async Task UpdateSoftwareList()
        {
            // Cargar nuevamente la lista de software
            _softwareList = await _mainController.LoadSoftware();

            // Recargar las aplicaciones en el hilo de la UI de forma segura
            if (this.InvokeRequired)
            {
                // Si no estamos en el hilo de la UI, usa Invoke para realizar la actualización de la UI
                this.Invoke(new Action(ReloadApps));
            }
            else
            {
                // Si ya estamos en el hilo de la UI, simplemente llama a ReloadApps directamente
                ReloadApps();
            }
        }

        public async void ReloadApps()
        {
            // Asegurarse de que la manipulación de la UI ocurre en el hilo principal
            if (InvokeRequired)
            {
                Invoke(new Action(ReloadApps));
                return;
            }

            flowLayoutPanel2.Controls.Clear();

            MaterialLabel reload = new MaterialLabel();
            reload.AutoSize = true;
            reload.Depth = 0;
            reload.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            reload.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            reload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            reload.Location = new System.Drawing.Point(647, 228);
            reload.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            reload.MouseState = MaterialSkin.MouseState.HOVER;
            reload.Size = new System.Drawing.Size(217, 58);
            reload.TabIndex = 69;
            reload.Text = "Cargando...";

            flowLayoutPanel2.Controls.Add(reload);

            // Obtener nuevamente la lista de software desde la base de datos
            _softwareList = await _mainController.LoadSoftware();

            Debug.WriteLine("_softwareList : " + _softwareList.Count());

            if (_softwareList.Count > 0)
            {
                CreateCards(_softwareList);
            }
            else
            {
                reload.Text = "No hay softwares para mostrar...";
            }
            
        }

        private async void buttonAppsRefresh_Click(object sender, EventArgs e)
        {
            ReloadApps();
        }

        private void materialButtonAddSoftware_Click(object sender, EventArgs e)
        {
            _addEditForm.InitializeAsyncEmpty();
        }


        private async void LoadUserPermissions()
        {
            _userPermissionsList = await _usersService.GetAllUserPermissionsAsync();

            if (_userPermissionsList != null && _userPermissionsList.Any())
            {
                var permissionDisplayList = _userPermissionsList.Select(up => new UserPermissionDisplayItem
                {
                    UserName = up.UserName,
                    CanEditApps = up.CanEditApps,
                    CanViewUserTab = up.CanViewUserTab
                }).ToList();

                // Verifica si el usuario actual tiene permiso para ver la pestaña de usuarios
                var currentUserPermission = _userPermissionsList
                    .FirstOrDefault(up => up.UserName.Equals(Environment.UserName, StringComparison.OrdinalIgnoreCase));
                

                if (currentUserPermission == null)
                {
                    HideTabPage();
                }

                


                dataGridViewPermisos.DataSource = new BindingList<UserPermissionDisplayItem>(permissionDisplayList);
            } 
            else
            {
                // Si no se encontraron permisos, asignar una lista vacía pero con columnas definidas
                dataGridViewPermisos.DataSource = new BindingList<UserPermissionDisplayItem>();
                //InitializeDataGridViewColumns();
                Console.WriteLine("No se encontraron permisos de usuarios.");
            }
        }

        private void btnSavePerm_Click(object sender, EventArgs e)
        {
            SaveUserPermissionsAsync();
        }

        private async Task SaveUserPermissionsAsync()
        {
            var result = MessageBox.Show("¿Está seguro que desea guardar los cambios?", "Permisos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var permissionsList = (BindingList<UserPermissionDisplayItem>)dataGridViewPermisos.DataSource;
                bool saveResult = await _softwareService.SaveUserPermissions(permissionsList);

                if (saveResult)
                {
                    // Refrescar la visualización de permisos
                    MessageBox.Show("Permisos guardados!", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUserPermissions();
                }
                else
                {
                    MessageBox.Show("Error al guardar los permisos.", "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private async void RefreshUserPermissions()
        {
            try
            {
                // Volver a cargar los permisos desde la base de datos
                var userPermissionsList = await _usersService.GetAllUserPermissionsAsync();

                if (userPermissionsList != null && userPermissionsList.Any())
                {
                    // Actualizar el DataGridView con los permisos actualizados
                    var permissionDisplayList = userPermissionsList.Select(up => new UserPermissionDisplayItem
                    {
                        UserName = up.UserName,
                        CanEditApps = up.CanEditApps,
                        CanViewUserTab = up.CanViewUserTab
                    }).ToList();

                    dataGridViewPermisos.DataSource = new BindingList<UserPermissionDisplayItem>(permissionDisplayList);
                }
                else
                {
                    // Si no se encontraron permisos, mostrar una lista vacía pero con columnas definidas
                    dataGridViewPermisos.DataSource = new BindingList<UserPermissionDisplayItem>();
                    MessageBox.Show("No se encontraron permisos de usuarios.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar permisos: {ex.Message}");
            }
        }

        // Para ocultar el TabPage
        private void HideTabPage()
        {
            materialTabControl1.TabPages.Remove(tabPageHidePermisos);
        }

        // Para mostrar nuevamente el TabPage
        private void ShowTabPage()
        {
            materialTabControl1.TabPages.Add(tabPageHidePermisos);
        }



        public async Task DescargarEInstalar(string fileName)
        {
            //string file = "7z2408-x64.msi";
           string FolderDownload = @"C:\temp\repository";

            SupabaseService supabaseService = new SupabaseService();
            InstaladorService instaladorService = new InstaladorService();

            // Descarga el archivo
            string rutaArchivoDescargado = await supabaseService.DescargarArchivoAsync(fileName, FolderDownload);

            // Instala el archivo
            int resuInstalacion = instaladorService.InstalarArchivoSilenciosamente(rutaArchivoDescargado);

            switch (resuInstalacion)
            {
                case 0:
                    ShowSnackMessage("Instalación completada exitosamente.", "OK");
                    break;
                case -1:
                    ShowSnackMessage("Formato de instalador no soportado.", "OK");
                    break;
                case -2:
                    ShowSnackMessage("Error al intentar instalar el archivo.", "OK");
                    break;
                case -3:
                    ShowSnackMessage("El archivo no existe.", "OK");
                    break;
                default:
                    break;
            }

            ReloadApps();
        }

        private void ShowSnackMessage(string message, string textActionDismiss)
        {
            if (InvokeRequired)
            {
                // Usar Invoke para ejecutar el método en el hilo principal de la UI
                this.Invoke(new Action(() => ShowSnackMessage(message, textActionDismiss)));
            }
            else
            {
                // Mostrar el SnackBar en el hilo principal
                SnackBarMessage = new MaterialSnackBar(message, textActionDismiss, true);
                SnackBarMessage.Show(this);
            }
        }

        private string LocalVersionApp(string pathInstall, string appName)
        {
            string versionLocal;
            try
            {
                // Primero, intentar obtener la versión de la aplicación desde el Registro de Windows
                versionLocal = GetAppVersionFromRegistry(appName);
                if (!string.IsNullOrEmpty(versionLocal))
                {
                    return versionLocal; // Devuelve la versión si se encuentra en el Registro
                }

                // Si no se encontró en el Registro, intentar obtener la versión desde la ubicación del archivo
                if (File.Exists(pathInstall))
                {
                    FileVersionInfo infoArchivo = FileVersionInfo.GetVersionInfo(pathInstall);
                    versionLocal = infoArchivo.FileVersion;
                    return versionLocal; // Devuelve la versión si se encuentra el archivo
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al verificar versión local en ruta: " + pathInstall + " - " + ex.Message);
                return null;
            }

            return null; // No se encontró la aplicación ni en el registro ni en la ruta del archivo
        }

        // Método para obtener la versión desde el registro de Windows
        private string GetAppVersionFromRegistry(string appName)
        {
            // Buscar en el registro de 64 bits
            string version = GetAppVersionInRegistry(appName, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");

            // Si no se encuentra en 64 bits, verificar en el registro de 32 bits
            if (string.IsNullOrEmpty(version))
            {
                version = GetAppVersionInRegistry(appName, @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            }

            return version;
        }

        // Método auxiliar para buscar la versión en el Registro
        private string GetAppVersionInRegistry(string appName, string registryPath)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath))
            {
                if (key != null)
                {
                    foreach (string subkeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subkey = key.OpenSubKey(subkeyName))
                        {
                            var displayName = subkey.GetValue("DisplayName") as string;
                            var displayVersion = subkey.GetValue("DisplayVersion") as string;

                            if (!string.IsNullOrEmpty(displayName) && displayName.IndexOf(appName, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                return displayVersion; // Retorna la versión si se encuentra la aplicación
                            }
                        }
                    }
                }
            }

            return null; // No se encontró la aplicación en el registro
        }


        private Boolean VerificaInstalacion(String pathInstall)
        {
            if (File.Exists(pathInstall))
            {
                Debug.WriteLine("El archivo existe." + pathInstall);
                return true;
            }
            else
            {
                Debug.WriteLine("El archivo no existe." + pathInstall);
                return false;
            }
        }
    }
}