using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using MaterialSkinExample.Database;
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

namespace MaterialSkinExample
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex;
        MaterialSkin.MaterialListBoxItem materialListBoxItem13 = new MaterialSkin.MaterialListBoxItem();

        public MainForm()
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

            //Inicia proceso de captura de configuraciones generales
            //EjecucionPorLapsosAsync();
            
            //New
            _controller = new MainController(databaseService);
            InitializeTimer();
            LoadDataAsync();

            Console.WriteLine("UserDomainName : " + Environment.UserDomainName);
            Console.WriteLine("UserName: {0}", Environment.UserName);
        }

      

        #region NUEVO
        private readonly MainController _controller;
        DatabaseService databaseService = new DatabaseService();
        private Timer updateTimer;
        private List<Config> _configs;
        private List<Software> _softwareList;

        private void InitializeTimer()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 10000; // 10 segundos
            updateTimer.Tick += new EventHandler(updateTimer_TickAsync);
            updateTimer.Start(); // Iniciar el timer
        }

        private async void updateTimer_TickAsync(object sender, EventArgs e)
        {
            try
            {
                var newConfigs = await _controller.LoadConfigs();
                var newSoftwareList = await _controller.LoadSoftware();

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

        private async Task LoadDataAsync()
        {
            // Cargar los datos de la base de datos
            _configs = await _controller.LoadConfigs();
            _softwareList = await _controller.LoadSoftware();

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
                    Text = software.Name
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
                    Text = "Editar" // Este texto puede variar según el estado del software
                };

                string localVersion = LocalVersionApp(software.PathInstall);
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

                // Configurar el evento Click del botón
                buttonInstall.Click += (sender, e) => ValidaDescarga(sender, e, software.UrlMsi, software.Version, software.PathFile, software.ForceInstall.ToString(), software.VerificaApp, software.AutomaticInstall.ToString(), software.PathInstall, true, software.Name);
                buttonEdit.Click += new EventHandler(AddEdit_Click);


                // Agregar controles a la tarjeta
                card.Controls.Add(labelTitulo);
                card.Controls.Add(labelVersion);
                card.Controls.Add(body);
                card.Controls.Add(buttonInstall);
                card.Controls.Add(buttonEdit);

                // Agregar la tarjeta al FlowLayoutPanel
                flowLayoutPanel2.Controls.Add(card);
            }
        }

        private string LocalVersionApp(string pathInstall)
        {
            string versionLocal;
            try
            {
                if (File.Exists(pathInstall))
                {
                    FileVersionInfo infoArchivo = FileVersionInfo.GetVersionInfo(pathInstall);
                    versionLocal = infoArchivo.FileVersion;

                    return versionLocal;
                }

            }
            catch (Exception ex)
            {
                return null;
                Console.WriteLine("Error al verificar version local en ruta: " + pathInstall + ex);
            }

            return null;
        }


        // Método que se ejecuta al hacer clic en el botón
        private void AddEdit_Click(object sender, EventArgs e)
        {
            AddEditForm _addEditForm = new AddEditForm();
            _addEditForm.ShowDialog();
    }

        #endregion










        #region OLD

        private async Task EjecucionPorLapsosAsync()
        {
            string intervalo = "";
            try
            {
                ConexionFirebase.CargaConexion();
                string result = await ConexionFirebase.ObtieneConfig();

                JObject data = JObject.Parse(result);
                JProperty latestProperty = data.Properties().Last();
                JArray latestRecords = (JArray)latestProperty.Value;

                foreach (JObject record in latestRecords)
                {
                    intervalo = (string)record["intervalo_check_segundos"];
                }
            }
            catch (Exception)
            {
                //Carga en segundos intervalo de sincronizacion predeterminado
                intervalo = "900";//15 minutos
            }

            while (true)
            {
                Console.WriteLine("Configuracion cargada, intervalo: " + intervalo);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Sincronizando...", "OK", true);
                SnackBarMessage.Show(this);
                // Llamar a tu método async Task aquí
                //await loadCardAsync();
                await Task.Delay(TimeSpan.FromSeconds(int.Parse(intervalo)));
            }
        }

        public async Task<JArray> GetAppsServer()
        {
            try
            {
                ConexionFirebase.CargaConexion();
                string result = await ConexionFirebase.ObtieneApps();

                JObject data = JObject.Parse(result);
                JProperty latestProperty = data.Properties().Last();
                JArray latestRecords = (JArray)latestProperty.Value;
                materialListBoxItem13.Text = "[GetAppsServer] Sincronizando con servidor..";
                materialListBoxLogs.Items.Add(materialListBoxItem13);

                return latestRecords;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                materialListBoxItem13.Text = "[GetAppsServer] Error al ejecutar sincronizacion " + ex.Message;
                materialListBoxLogs.Items.Add(materialListBoxItem13);

                return (JArray)"Error";
            }
        }

        private async Task loadCardAsync()
        {
            //flowLayoutPanel1.Controls.Clear();
            //listaFiltro.Items.Clear();

            MaterialLabel reload = new MaterialLabel();
            reload.AutoSize = true;
            reload.Depth = 0;
            reload.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            reload.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            reload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            reload.Location = new System.Drawing.Point(647, 228);
            reload.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            reload.MouseState = MaterialSkin.MouseState.HOVER;
            reload.Size = new System.Drawing.Size(217, 58);
            reload.TabIndex = 69;
            reload.Text = "Cargando...";

            //flowLayoutPanel1.Controls.Add(reload);

            JArray latestRecords = await GetAppsServer();

            //ConexionFirebase.CargaConexion();
            //string result = await ConexionFirebase.ObtieneApps();

            //JObject data = JObject.Parse(result);
            //JProperty latestProperty = data.Properties().Last();
            //JArray latestRecords = (JArray)latestProperty.Value;

            //flowLayoutPanel1.Controls.Clear();

            materialListBoxItem13.Text = "[loadCardAsync] latestRecords " + latestRecords.Count();
            materialListBoxLogs.Items.Add(materialListBoxItem13);

            foreach (JObject record in latestRecords)
            {
                string descripcion = (string)record["descripcion"];
                string imagen = (string)record["imagen"];
                string pathInstall = (string)record["path_install"];
                string software = (string)record["software"];
                string tag = (string)record["tag"];
                string urlMsi = (string)record["url_msi"];
                string verificaApp = (string)record["verifica_app"];
                string version = (string)record["version"];
                string pathFile = (string)record["path_file"];
                string forceInstall = (string)record["force_install"];
                string GUID = (string)record["GUID"];
                string automaticInstall = (string)record["automatic_install"];

                //JArray gruposArray = (JArray)record["version"];
                //string[] grupos = gruposArray.ToObject<string[]>();


                #region Agrega elementos de card
                //Console.WriteLine($"Descripción: {descripcion}");
                //Console.WriteLine($"Imagen: {imagen}");
                //Console.WriteLine($"Path de instalación: {pathInstall}");
                //Console.WriteLine($"Software: {software}");
                //Console.WriteLine($"Tag: {tag}");
                //Console.WriteLine($"URL MSI: {urlMsi}");
                //Console.WriteLine($"Verificación de la aplicación: {verificaApp}");
                //Console.WriteLine($"Versión: {version}");
                //Console.WriteLine();

                MaterialCard card = new MaterialCard();
                MaterialLabel labelTitulo = new MaterialLabel();
                MaterialLabel labelVersion = new MaterialLabel();
                MaterialLabel labelVersionWeb = new MaterialLabel();
                MaterialButton button = new MaterialButton();
                MaterialButton buttonUpdate = new MaterialButton();
                MaterialLabel body = new MaterialLabel();




                card.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                card.Depth = 0;
                card.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                card.Location = new System.Drawing.Point(24, 380);
                card.Margin = new System.Windows.Forms.Padding(9);
                card.MouseState = MaterialSkin.MouseState.HOVER;
                card.Padding = new System.Windows.Forms.Padding(19, 17, 19, 17);
                card.Size = new System.Drawing.Size(526, 150);
                card.TabIndex = 70;


                labelTitulo.AutoSize = true;
                labelTitulo.Depth = 0;
                labelTitulo.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
                labelTitulo.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
                labelTitulo.HighEmphasis = true;
                labelTitulo.Location = new System.Drawing.Point(23, 17);
                labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                labelTitulo.MouseState = MaterialSkin.MouseState.HOVER;
                labelTitulo.Size = new System.Drawing.Size(245, 24);
                labelTitulo.TabIndex = 0;
                labelTitulo.Text = $"{software}";

                body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                | System.Windows.Forms.AnchorStyles.Left)
                                | System.Windows.Forms.AnchorStyles.Right)));
                body.Depth = 0;
                body.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
                body.Location = new System.Drawing.Point(23, 64);
                body.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                body.MouseState = MaterialSkin.MouseState.HOVER;
                body.Size = new System.Drawing.Size(340, 90);
                body.TabIndex = 2;
                body.Text = $"{descripcion}";


                string localVersion = LocalVersionApp(pathInstall);
                labelVersion.AutoSize = true;
                labelVersion.Depth = 0;
                labelVersion.Enabled = false;
                labelVersion.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
                labelVersion.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
                labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                labelVersion.Location = new System.Drawing.Point(23, 45);
                labelVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                labelVersion.MouseState = MaterialSkin.MouseState.HOVER;
                labelVersion.Size = new System.Drawing.Size(269, 17);
                labelVersion.TabIndex = 82;


                if (localVersion != "null") labelVersion.Text = $"Version: {localVersion}";


                button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
                button.Depth = 0;
                button.HighEmphasis = true;
                button.Icon = null;
                button.Location = new System.Drawing.Point(427, 90);
                button.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                button.MouseState = MaterialSkin.MouseState.HOVER;
                button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
                button.NoAccentTextColor = System.Drawing.Color.Empty;
                button.Size = new System.Drawing.Size(100, 36);
                button.TabIndex = 1;

                //Agrega tags a filtro
                //listaFiltro.Items.Add(tag.ToUpper(), false);
                //listaFiltro.TabIndexChanged += (sender, e) => ActualizaListaApps(sender, e);

                #endregion

                /*
                 * resultadoVersion estados:
                                                0 = Versiones iguales
                                                1 = Local mas actualizado
                                                -1 = Version nueva disponibles en la web
                                                10 = error al comparar version local con web 
                 */
                Boolean estaInstalado = VerificaInstalacion(pathInstall);

                if (estaInstalado)
                {

                    int comparacion = CompararVersionApp(pathInstall, version);

                    if (comparacion == -1)
                    {
                        button.Text = "Actualización";
                        button.Enabled = true;

                        //DescargaEInstala(urlMsi, pathFile, forceInstall, software, version, GUID);
                        button.Click += (sender, e) => ValidaDescarga(sender, e, urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, true, software);

                        labelVersionWeb.AutoSize = true;
                        labelVersionWeb.Depth = 0;
                        labelVersionWeb.Enabled = false;
                        labelVersionWeb.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
                        labelVersionWeb.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
                        labelVersionWeb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                        labelVersionWeb.Location = new System.Drawing.Point(390, 70);
                        labelVersionWeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        labelVersionWeb.MouseState = MaterialSkin.MouseState.HOVER;
                        labelVersionWeb.Size = new System.Drawing.Size(269, 17);
                        labelVersionWeb.TabIndex = 82;
                        labelVersionWeb.Text = $"Nueva: {version}";
                    }

                    if (comparacion == 0)
                    {
                        button.Text = "Instalado";
                        button.Enabled = false;
                        button.Click += (sender, e) => ValidaDescarga(sender, e, urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, false, software);
                    }

                    if (comparacion == 1)
                    {
                        button.Text = "Local mas nueva";
                        button.Enabled = false;
                        button.Click += (sender, e) => ValidaDescarga(sender, e, urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, false, software);
                    }

                    if (comparacion == 10)
                    {
                        button.Text = "Error";
                        button.Enabled = false;
                        button.Click += (sender, e) => ValidaDescarga(sender, e, urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, false, software);
                    }

                }
                else
                {
                    //Aplicacion no detectada
                    button.Text = "Instalar";
                    button.Enabled = true;
                    button.Click += (sender, e) => ValidaDescarga(sender, e, urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, true, software);
                }
                button.UseAccentColor = false;
                button.UseVisualStyleBackColor = true;


                card.Controls.Add(labelTitulo);
                card.Controls.Add(labelVersion);
                card.Controls.Add(labelVersionWeb);
                card.Controls.Add(body);
                card.Controls.Add(button);
                //flowLayoutPanel1.Controls.Add(card);

                if (automaticInstall == "true")
                {
                    Console.WriteLine("\n[NOTIFICACION] Software: " + software + " viene con actualizacion automatica.\n");
                    DescargaApp(urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, false, software);

                    /* ROAD MAP VALIDATION
                     * 
                     * 
                        Verificar instalacion y autodescarga app

                            - Verificar si esta instalada alguna version
                                - Si existe instalacion
                                    - Comprarar vs la version web
                                        - Si es igual a version mas reciente no descarga
                                        - Si es inferior a la version web
                                            - Descargar
                                                - Si descarga existe 
                                                      - Goto VerificaProcesoActivo
                                                - Si no existe descarga app
                                                        - Genera descarga
                                                        - GoTo VerificaProcesoActivo
                                                            - Si esta activa, avisar a usuario para que la cierre
                                                            - Si no esta activa
                                                                - Goto Instalar
                                                            
                                - No existe instalacion
                                    - Descargar
                                        - Si descarga existe 
                                                - Goto VerificaProcesoActivo
                                        - Si no existe descarga app
                                                - Genera descarga
                                                - GoTo VerificaProcesoActivo
                                                    - Si esta activa, avisar a usuario para que la cierre
                                                    - Si no esta activa
                                                        - Goto Instalar
                                                            - Verificar instalacion forzada
                                                                - Si es si
                                                                    - Mata el proceso
                        
                    

                    */
                }

                if (forceInstall == "true")
                {
                    Console.WriteLine("\n[NOTIFICACION] Software: " + software + " viene con actualizacion forzada.\n");
                    DescargaApp(urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, false, software);
                }
            }
        }

        private void ActualizaListaApps(object sender, EventArgs e)
        {
            //foreach (var item in listaFiltro.Items)
            //{
            //    Console.WriteLine("Item Checked: " + item.Text);
            //}
        }

        public async Task ValidaDescarga(object sender, EventArgs e, string urlMsi, string version, string pathFile, string forceInstall,
            string verificaApp, string automaticInstall, string pathInstall, bool instalaManual, string software)
        {
            DescargaApp(urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, instalaManual, software);
        }

        private void DescargaApp(string urlMsi, string version, string pathFile, string forceInstall, string verificaApp, string automaticInstall, string pathInstall, bool instalaManual, string software)
        {
            string directorio = @"C:\temp\repository";
            string rutaDescarga = Path.Combine(directorio, pathFile);

            //verifica si existe descarga
            if (File.Exists(rutaDescarga))
            {
                Console.WriteLine("rutaDescarga" + rutaDescarga);
                string[] versionLocalSucia = pathFile.Split('_');
                string versionLocal = versionLocalSucia[1].Substring(0, 7);

                Console.WriteLine("verifica si existe descarga..." + versionLocal + ", " + version);
                Version v1 = Version.Parse(versionLocal);
                Version v2 = Version.Parse(version);
                Console.WriteLine("Compara versiones: " + v1.CompareTo((Object)v2));

                //si version local vs web son iguales va al proceso de instalacion
                if (v1 != null && v1.CompareTo(v2) == 0)
                {
                    Console.WriteLine("[DescargaApp] Archivo ya descargado...");
                    materialListBoxItem13.Text = "[DescargaApp] Archivo ya descargado... " + rutaDescarga;
                    materialListBoxLogs.Items.Add(materialListBoxItem13);

                    goto INSTALACION;
                }
                else
                {
                    using (WebClient client = new WebClient())
                    {
                        Console.WriteLine("Descarga iniciando...");
                        materialListBoxItem13.Text = "[DescargaApp] Descarga iniciando... " + rutaDescarga;
                        materialListBoxLogs.Items.Add(materialListBoxItem13);
                        client.DownloadFile(urlMsi, rutaDescarga);
                        Console.WriteLine("Descarga completada...");
                        materialListBoxItem13.Text = "[DescargaApp] Descarga completada... " + rutaDescarga;
                        materialListBoxLogs.Items.Add(materialListBoxItem13);
                    }
                    goto INSTALACION;
                }
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(directorio);

                    using (WebClient client = new WebClient())
                    {
                        Console.WriteLine("Descarga iniciando...");
                        client.DownloadFile(urlMsi, rutaDescarga);
                        Console.WriteLine("Descarga completada...");
                    }
                    Console.WriteLine("Descarga ruta archivo: " + rutaDescarga);

                    materialListBoxItem13.Text = "[DescargaApp] Descarga ruta archivo: " + rutaDescarga;
                    materialListBoxLogs.Items.Add(materialListBoxItem13);

                    goto INSTALACION;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al crear el directorio: " + ex.Message);
                    materialListBoxItem13.Text = "[DescargaApp] Error al crear el directorio: " + ex.Message;
                    materialListBoxLogs.Items.Add(materialListBoxItem13);
                }

            }

        INSTALACION:
            VerificaProcesoActivo(verificaApp, rutaDescarga, automaticInstall, forceInstall, pathInstall, instalaManual, version, software);

            //Reaload datos dinamicos de la nube
            //loadCardAsync();
        }

        private void VerificaProcesoActivo(string verificaApp, string rutaDescarga, string automaticInstall, string forceInstall, string pathInstall, bool instalaManual, string version, string software)
        {
            Process[] procesos = Process.GetProcessesByName(verificaApp);
            //Console.WriteLine("VerificaProcesoActivo: " + verificaApp);

            if (procesos.Length > 0)
            {
                Console.WriteLine("El proceso " + verificaApp.ToUpper() + " está activo.");

                if (automaticInstall == "true")
                {
                    Console.WriteLine("[AutomaticInstall] El proceso " + verificaApp.ToUpper() + " está activo. No fue posible la instalacion." + rutaDescarga);
                    MaterialSnackBar SnackBarMessage2 = new MaterialSnackBar("El proceso " + verificaApp.ToUpper() + " esta activo.  No fue posible la instalacion.", "OK", true);
                    SnackBarMessage2.Show(this);
                }

                if (forceInstall == "true")
                {
                    Console.WriteLine("[ForceInstall] Instalacion forzada, proceso esta activo...");

                    DetieneProceso(verificaApp);

                    if (VerificaInstalacion(pathInstall))
                    {
                        //verifica version local vs nube
                        string versionLocal = LocalVersionApp(pathInstall);
                        /*
                        * resultadoVersion estados:
                           0 = Versiones iguales
                           1 = Local mas actualizado
                           -1 = Version nueva disponibles en la web
                           10 = error al comparar version local con web 
                        */
                        int comparacion = CompararVersionApp(pathInstall, version);

                        if (comparacion == 0) Console.WriteLine("Version mas reciente instalada de : " + software);

                        if (comparacion == 1) Console.WriteLine("Version local mas actualizada: " + versionLocal);

                        if (comparacion == -1)
                        {
                            Console.WriteLine("Version nueva disponibles en la web: " + version);
                            EjectutaDesinstalacion(rutaDescarga, software);
                            System.Threading.Thread.Sleep(3000);
                            EjecutaInstalacion(rutaDescarga, software);
                        }

                        if (comparacion == 10)
                        {
                            Console.WriteLine("Error al verificar version: " + version);
                            MaterialSnackBar SnackBarMessage2 = new MaterialSnackBar("Error al verificar instalacion de  " + software, 3000, "OK");
                            SnackBarMessage2.Show(this);
                        }
                    }
                    else
                    {
                        EjecutaInstalacion(rutaDescarga, software);
                    }
                }
            }
            else
            {
                if (automaticInstall == "true")
                {
                    //Console.WriteLine("El proceso " + verificaApp.ToUpper() + " no está activo." + rutaDescarga);

                    //Si esta instalada una version previa
                    if (VerificaInstalacion(pathInstall))
                    {
                        //verifica version local vs nube
                        string versionLocal = LocalVersionApp(pathInstall);
                        /*
                        * resultadoVersion estados:
                           0 = Versiones iguales
                           1 = Local mas actualizado
                           -1 = Version nueva disponibles en la web
                           10 = error al comparar version local con web 
                        */
                        int comparacion = CompararVersionApp(pathInstall, version);

                        if (comparacion == 0)
                        {
                            Console.WriteLine("Version mas reciente instalada de : " + software);
                        }

                        if (comparacion == 1)
                        {
                            Console.WriteLine("Version local mas actualizada: " + versionLocal);
                        }

                        if (comparacion == -1)
                        {
                            Console.WriteLine("Version nueva disponibles en la web: " + version);
                            EjectutaDesinstalacion(rutaDescarga, software);
                            System.Threading.Thread.Sleep(5000);
                            EjecutaInstalacion(rutaDescarga, software);
                        }

                        if (comparacion == 10)
                        {
                            Console.WriteLine("Error al verificar version: " + version);
                            MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Error al verificar instalacion de  " + software, "OK", true);
                            SnackBarMessage.Show(this);
                        }
                    }
                    else
                    {
                        EjecutaInstalacion(rutaDescarga, software);
                    }
                }

                if (instalaManual == true)
                {
                    //Si esta instalada una version previa, desinstalar
                    if (VerificaInstalacion(pathInstall))
                    {
                        EjectutaDesinstalacion(rutaDescarga, software);
                    }
                    else
                    {
                        EjecutaInstalacion(rutaDescarga, software);
                    }

                }

                if (forceInstall == "true")
                {
                    Console.WriteLine("Instalacion forzada, proceso no esta activo...");


                    if (VerificaInstalacion(pathInstall))
                    {
                        //verifica version local vs nube
                        string versionLocal = LocalVersionApp(pathInstall);

                        /*
                        * resultadoVersion estados:
                           0 = Versiones iguales
                           1 = Local mas actualizado
                           -1 = Version nueva disponibles en la web
                           10 = error al comparar version local con web 
                        */
                        int comparacion = CompararVersionApp(pathInstall, version);

                        if (comparacion == 0)
                        {
                            //Version mas reciente instalada
                            Console.WriteLine("Version mas reciente instalada de : " + software);
                        }

                        if (comparacion == 1)
                        {
                            //local mas actualizado, probable version beta testing
                            Console.WriteLine("Version local mas actualizada: " + versionLocal);
                        }


                        if (comparacion == -1)
                        {
                            //Version nueva disponibles en la web, necesita update
                            Console.WriteLine("Version nueva disponibles en la web: " + version);
                            EjectutaDesinstalacion(rutaDescarga, software);
                            System.Threading.Thread.Sleep(5000);
                            EjecutaInstalacion(rutaDescarga, software);
                        }

                        if (comparacion == 10)
                        {
                            //Error al verificar version
                            Console.WriteLine("Error al verificar version: " + version);
                            MaterialSnackBar SnackBarMessage2 = new MaterialSnackBar("Error al verificar instalacion de  " + software, 3000, "OK");
                            SnackBarMessage2.Show(this);
                        }
                    }
                    else
                    {
                        EjecutaInstalacion(rutaDescarga, software);
                    }
                }
            }
        }

        private void EjecutaInstalacion(string rutaDescarga, string software)
        {
            try
            {

                if (Environment.UserDomainName == "PYAING")
                {
                    Debug.WriteLine("[EjecutaInstalacion] UserDomainName " + Environment.UserDomainName);
                    string userName = PYALauncherApps.Properties.Settings.Default.usuario;
                    string password = PYALauncherApps.Properties.Settings.Default.password;
                    var securePassword = new System.Security.SecureString();

                    foreach (char c in password) securePassword.AppendChar(c);

                    Process process = new Process();
                    process.StartInfo.FileName = "msiexec.exe";
                    process.StartInfo.Arguments = string.Format(" /q /i \"{0}\" ALLUSERS=1", rutaDescarga);
                    process.StartInfo.UserName = userName;
                    process.StartInfo.Password = securePassword;
                    process.StartInfo.Verb = "runas";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();
                    process.WaitForExit();
                    process.Close();
                    process.Dispose();
                }
                else
                {
                    Debug.WriteLine("[EjecutaInstalacion] UserDomainName " + Environment.UserDomainName);
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = "msiexec.exe";
                    startInfo.Arguments = string.Format(" /q /i \"{0}\" ALLUSERS=1", rutaDescarga);
                    startInfo.Verb = "runas"; // Solicitar elevación de permisos
                    startInfo.UseShellExecute = false;

                    Process.Start(startInfo);

                }



                Debug.WriteLine("[EjecutaInstalacion] El proceso de instalación de " + software + " finalizado correctamente.");

                materialListBoxItem13.Text = "[EjecutaInstalacion] El proceso de instalación de " + software + " finalizado correctamente.";
                materialListBoxLogs.Items.Add(materialListBoxItem13);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso de instalación de " + software + " finalizado correctamente.", 3000, "OK");
                SnackBarMessage.Show(this);

            }
            catch (Exception ex)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Error al ejecutar la instalación " + software, 3000, "OK");
                SnackBarMessage.Show(this);
                materialListBoxItem13.Text = "[EjecutaInstalacion] Error al ejecutar la instalación de " + software + "." + ex.Message;
                materialListBoxLogs.Items.Add(materialListBoxItem13);
            }
            //Reaload datos dinamicos de la nube
            System.Threading.Thread.Sleep(5000);
            //loadCardAsync();
        }

        private void EjectutaDesinstalacion(string rutaDescarga, string software)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "msiexec.exe";
                process.StartInfo.Arguments = string.Format(" /q /x \"{0}\" ALLUSERS=1", rutaDescarga);

                if (Environment.UserDomainName == "PYAING")
                {
                    string userName = PYALauncherApps.Properties.Settings.Default.usuario;
                    string password = PYALauncherApps.Properties.Settings.Default.password;
                    var securePassword = new System.Security.SecureString();

                    foreach (char c in password) securePassword.AppendChar(c);

                    process.StartInfo.UserName = userName;
                    process.StartInfo.Password = securePassword;
                }
                else
                {
                    process.StartInfo.Verb = "runas"; // Ejecuta el proceso con privilegios de administrador
                }

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();



                Console.WriteLine("[EjectutaDesinstalacion] El proceso de desinstalación de " + software + " finalizado correctamente.");
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso de desinstalación de " + software + " finalizado correctamente.", 3000, "OK");
                SnackBarMessage.Show(this);
                materialListBoxItem13.Text = "[EjectutaDesinstalacion] El proceso de desinstalación de " + software + " finalizado correctamente.";
                materialListBoxLogs.Items.Add(materialListBoxItem13);

            }
            catch (Exception ex)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Error al ejecutar desinstalación " + software, 3000, "OK");
                SnackBarMessage.Show(this);

                materialListBoxItem13.Text = "[EjectutaDesinstalacion] Error al ejecutar la desinstalación  de " + software + "." + ex.Message;
                materialListBoxLogs.Items.Add(materialListBoxItem13);
            }

        }

        private void DetieneProceso(string verificaApp)
        {
            string proceso = verificaApp + ".exe";
            try
            {
                Process cmdProcess = new Process();
                cmdProcess.StartInfo.FileName = "cmd.exe";
                cmdProcess.StartInfo.RedirectStandardInput = true;
                cmdProcess.StartInfo.UseShellExecute = false;
                cmdProcess.StartInfo.CreateNoWindow = true;

                cmdProcess.Start();

                cmdProcess.StandardInput.WriteLine($"taskkill /F /IM {proceso}");
                cmdProcess.StandardInput.Flush();
                cmdProcess.StandardInput.Close();
                cmdProcess.WaitForExit();

                Console.WriteLine($"Proceso {proceso} ha sido finalizado.");
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso " + proceso + " a sido detenido.", 3000, "OK");
                SnackBarMessage.Show(this);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error al detener proceso {proceso} ha sido finalizado.");
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Error al detener proceso " + proceso, 3000, "OK");
                SnackBarMessage.Show(this);
            }

        }

        private void InstallByUser(string software)
        {

        }

        public void LimpiaInstalacion()
        {
            string productName = "NombreDelProducto"; // Nombre del producto que deseas verificar

            bool isInstalled = IsProductInstalled(productName);

            if (isInstalled)
            {
                Console.WriteLine("El producto está instalado.");
            }
            else
            {
                Console.WriteLine("El producto no está instalado.");
            }
        }

        public bool IsProductInstalled(string productName)
        {
            string query = $"SELECT * FROM Win32_Product WHERE Name = '{productName}'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            ManagementObjectCollection productCollection = searcher.Get();

            return (productCollection.Count > 0);
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

        private Boolean VerificaInstalacion(String pathInstall)
        {
            if (File.Exists(pathInstall))
            {
                //Console.WriteLine("El archivo existe." + pathInstall);
                return true;
            }
            else
            {
                //Console.WriteLine("El archivo no existe." + pathInstall);
                return false;
            }


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

        private void materialButtonReload_Click(object sender, EventArgs e)
        {
            //Carga datos dinamicos de la nube
            //loadCardAsync();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2)
                colorSchemeIndex = 0;
            updateColor();
        }

        //private void materialButton1_Click_1(object sender, EventArgs e)
        //{

        //    listaFiltro.Items.Clear();
        //    listaFiltro.Items.Sort();
        //    listaFiltro.Refresh();
        //    Console.WriteLine("Filtro limpio" + listaFiltro.Items.Count);
        //}

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

        #endregion

       
    }
}
