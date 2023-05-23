using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Text;
using System.Windows.Forms;
using MaterialSkinExample.Database;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Net;
using Microsoft;


namespace MaterialSkinExample
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex;

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
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red700,Primary.Red900, Primary.Red100, Accent.Red200, TextShade.WHITE);

            colorSchemeIndex = PYALauncherApps.Properties.Settings.Default.codigoTema;

            bool tst = PYALauncherApps.Properties.Settings.Default.estiloTema;
            updateColor();
            if(tst == true)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }

            //Carga datos dinamicos de la nube
            loadCardAsync();
        }

        private async Task loadCardAsync()
        {
            flowLayoutPanel1.Controls.Clear();
            listaFiltro.Items.Clear();

    

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
            
            flowLayoutPanel1.Controls.Add(reload);

            ConexionFirebase.CargaConexion();
            string result = await ConexionFirebase.ObtieneApps();
            
            JObject data = JObject.Parse(result);
            JProperty latestProperty = data.Properties().Last();
            JArray latestRecords = (JArray)latestProperty.Value;

            flowLayoutPanel1.Controls.Clear();



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
                

                if(localVersion != "null") labelVersion.Text = $"Version: {localVersion}";

               
                button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
                button.Depth = 0;
                button.HighEmphasis = true;
                button.Icon = null;
                button.Location = new System.Drawing.Point(427, 90);
                button.Margin = new System.Windows.Forms.Padding(0,0,0,0);
                button.MouseState = MaterialSkin.MouseState.HOVER;
                button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
                button.NoAccentTextColor = System.Drawing.Color.Empty;
                button.Size = new System.Drawing.Size(76, 36);
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
                    
                    if(comparacion == 0)
                    {
                        button.Text = "Instalado";
                        button.Enabled = false;
                        button.Click += (sender, e) => ValidaDescarga(sender, e, urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, false, software);
                    }

                    if(comparacion == 1)
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
                flowLayoutPanel1.Controls.Add(card);
                
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
            Console.WriteLine("Filtro limpio3: " + listaFiltro.Items.Count);
        }

        private void ActualizaListaApps(object sender, EventArgs e)
        {
            foreach (var item in listaFiltro.Items)
            {
                Console.WriteLine("Item Checked: " + item.Text);
            }
        }

        public async Task ValidaDescarga(object sender, EventArgs e, string urlMsi, string version, string pathFile, string forceInstall, 
            string verificaApp, string automaticInstall, string pathInstall, bool instalaManual, string software)
        {
            DescargaApp(urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall, pathInstall, instalaManual, software);
        }

        private void DescargaApp(string urlMsi, string version, string pathFile, string forceInstall, string verificaApp, string automaticInstall, string pathInstall, bool instalaManual, string software)
        {
            string rutaDescarga = Path.Combine("C:\\temp\\repository", pathFile);

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
                    Console.WriteLine("Archivo ya descargado...");
                    goto INSTALACION;
                }
                else
                {
                    using (WebClient client = new WebClient())
                    {
                        Console.WriteLine("Descarga iniciando...");
                        client.DownloadFile(urlMsi, rutaDescarga);
                        Console.WriteLine("Descarga completada...");
                    }
                    goto INSTALACION;
                }
            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    Console.WriteLine("Descarga iniciando...");
                    client.DownloadFile(urlMsi, rutaDescarga);
                    Console.WriteLine("Descarga completada...");
                }
                Console.WriteLine("Descarga ruta archivo: " + rutaDescarga);
                goto INSTALACION;
            }

            INSTALACION:
            VerificaProcesoActivo(verificaApp, rutaDescarga, automaticInstall, forceInstall, pathInstall, instalaManual, version, software);
            //if (automaticInstall == "true")
            //{
                
            //}
            

            //Reaload datos dinamicos de la nube
            //loadCardAsync();
        }

        private void VerificaProcesoActivo(string verificaApp, string rutaDescarga, string automaticInstall, string forceInstall, string pathInstall, bool instalaManual, string version, string software)
        {
            Process[] procesos = Process.GetProcessesByName(verificaApp);
            Console.WriteLine("VerificaProcesoActivo: " + verificaApp);

            if (procesos.Length > 0)
            {
                Console.WriteLine("El proceso " + verificaApp.ToUpper() + " está activo.");
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso " + verificaApp.ToUpper() + " está activo. Favor cierre la aplicacion antes de continuar.", "OK", true);
                SnackBarMessage.Show(this);

                if (forceInstall == "true")
                {
                    Console.WriteLine("Instalacion forzada, proceso esta activo...");
                    //Matar proceso
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
            else
            {
                if(automaticInstall == "true")
                {
                    Console.WriteLine("El proceso " + verificaApp.ToUpper() + " no está activo." + rutaDescarga);
                    //MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso instalación a comenzado.", "OK", true);
                    //SnackBarMessage.Show(this);

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
                            MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Error al verificar instalacion de  " + software, "OK", true);
                            SnackBarMessage.Show(this);
                        }   
                        
                    }
                    else
                    {
                        EjecutaInstalacion(rutaDescarga, software);
                    }
                    
                }

                if(instalaManual == true)
                {
                    //Si esta instalada una version previa, desinstalar
                    if (VerificaInstalacion(pathInstall))
                    {
                        EjectutaDesinstalacion(rutaDescarga, software);
                    }
                    else
                    {
                        //S
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
                string userName = "administrador";
                string password = "InsodEp&a8094";
                string command = $"msiexec.exe /i \"{rutaDescarga}\" /quiet /norestart";
                
                // Convertir la contraseña en un objeto SecureString
                var securePassword = new System.Security.SecureString();
                foreach (char c in password)
                {
                    securePassword.AppendChar(c);
                }

                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "msiexec.exe";
                    process.StartInfo.Arguments = string.Format(" /q /i \"{0}\" ALLUSERS=1", rutaDescarga);
                    process.StartInfo.UserName = userName;
                    process.StartInfo.Password = securePassword;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();
                    process.WaitForExit();

                    //Process.Start(startInfo);
                    Console.WriteLine("Proceso de instalación a finalizado correctamente");
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso de instalación de "+ software+" finalizado correctamente.", 3000, "OK");
                    SnackBarMessage.Show(this);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al iniciar la aplicación: " + ex.Message);
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Error al instalar aplicación " + software, 3000, "OK");
                    SnackBarMessage.Show(this);
                }
            }
            catch (Exception)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Error al ejecutar la instalación " + software, 3000, "OK");
                SnackBarMessage.Show(this);
            }
            //Reaload datos dinamicos de la nube
            System.Threading.Thread.Sleep(5000);
            loadCardAsync();
        }

        private void EjectutaDesinstalacion(string rutaDescarga, string software)
        {
            try
            {
                string userName = "administrador";
                string password = "InsodEp&a8094";
                string command = $"msiexec.exe /x \"{rutaDescarga}\" /quiet /norestart";
                
                // Convertir la contraseña en un objeto SecureString
                var securePassword = new System.Security.SecureString();
                foreach (char c in password)
                {
                    securePassword.AppendChar(c);
                }
                
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "msiexec.exe";
                    process.StartInfo.Arguments = string.Format(" /q /x \"{0}\" ALLUSERS=1", rutaDescarga);
                    process.StartInfo.UserName = userName;
                    process.StartInfo.Password = securePassword;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.Start();
                    process.WaitForExit();
                    //Process.Start(startInfo);
                    Console.WriteLine("El proceso de desinstalación a finalizado correctamente.");
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso de desinstalación de "+ software+" finalizado correctamente.", 3000, "OK");
                    SnackBarMessage.Show(this);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al desinstalar aplicación: " + ex.Message);
                    MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Error al desinstalar aplicación " + software, 3000, "OK");
                    SnackBarMessage.Show(this);
                }
            }
            catch (Exception)
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Error al ejecutar desinstalación " + software, 3000, "OK");
                SnackBarMessage.Show(this);
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

        private string LocalVersionApp(string pathInstall)
        {
            string versionLocal = "null";
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
                Console.WriteLine("Error al verificar version local en ruta: " + pathInstall + ex);   
            }
            return versionLocal;
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
            

            if(materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT)
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
            loadCardAsync();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2)
                colorSchemeIndex = 0;
            updateColor();
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            
            listaFiltro.Items.Clear();
            listaFiltro.Items.Sort();
            listaFiltro.Refresh();
            Console.WriteLine("Filtro limpio" + listaFiltro.Items.Count);
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
    }
}
