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

        //public MaterialCard card = new MaterialCard();
        //public MaterialLabel labelTitulo = new MaterialLabel();
        //public MaterialLabel labelVersion = new MaterialLabel();
        //public MaterialLabel labelVersionWeb = new MaterialLabel();
        //public MaterialButton button = new MaterialButton();
        //public MaterialButton buttonUpdate = new MaterialButton();
        //public MaterialLabel body = new MaterialLabel();

        

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

            colorSchemeIndex = Properties.Settings.Default.codigoTema;

            bool tst = Properties.Settings.Default.estiloTema;
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


                string localVersion = LocalVersionApp(pathInstall, version);
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
                //materialCheckedListBox1.Items.Add(tag.ToUpper(), false);
                
                listaFiltro.Items.Add(tag.ToUpper(), false);
                listaFiltro.TabIndexChanged += (sender, e) => ActualizaListaApps(sender, e);

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
                    if (CompararVersionApp(pathInstall, version) == -1)
                    {
                        button.Text = "Actualización";
                        button.Enabled = true;

                        //DescargaEInstala(urlMsi, pathFile, forceInstall, software, version, GUID);
                        button.Click += (sender, e) => ValidaDescarga(sender, e, urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall);

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
                    else
                    {
                        button.Text = "Instalado";
                        button.Enabled = false;
                        button.Click += (sender, e) => ValidaDescarga(sender, e, urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall);
                    }
                }
                else
                {
                    //Aplicacion no detectada
                    button.Text = "Instalar";
                    button.Enabled = true;
                    button.Click += (sender, e) => ValidaDescarga(sender, e, urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall);
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

                    if(!estaInstalado)
                    {
                        DescargaApp(urlMsi, version, pathFile, forceInstall, verificaApp, automaticInstall);
                    }

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

        public void ValidaDescarga(object sender, EventArgs e, string urlMsi, string version, string pathFile, string forceInstall, string verificaApp, string automaticInstall)
        {
            DescargaApp( urlMsi,  version,  pathFile,  forceInstall,  verificaApp,  automaticInstall);
        }

        private void DescargaApp(string urlMsi, string version, string pathFile, string forceInstall, string verificaApp, string automaticInstall)
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
            VerificaProcesoActivo(verificaApp, rutaDescarga, automaticInstall, forceInstall);
            //if (automaticInstall == "true")
            //{
                
            //}
            

            //Reaload datos dinamicos de la nube
            //loadCardAsync();
        }

        private void VerificaProcesoActivo(string verificaApp, string rutaDescarga, string automaticInstall, string forceInstall)
        {
            Process[] procesos = Process.GetProcessesByName(verificaApp);

            if (procesos.Length > 0)
            {
                Console.WriteLine("El proceso " + verificaApp.ToUpper() + " está activo.");
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso " + verificaApp.ToUpper() + " está activo. Favor cierre la aplicacion antes de continuar.", "OK", true);
                SnackBarMessage.Show(this);

                if (forceInstall == "true")
                {
                    //Matar proceso
                    
                    //EjecutaInstalacion(rutaDescarga);
                }
            }
            else
            {
                Console.WriteLine("El proceso " + verificaApp.ToUpper() + " no está activo." + rutaDescarga);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso instalación a comenzado.", "OK", true);
                SnackBarMessage.Show(this);
                EjecutaInstalacion(rutaDescarga);
                //if (automaticInstall == "true")
                //{
                    
                //}

                
            }
        }

        private void EjecutaInstalacion(string rutaDescarga)
        {
            string userName = "administrador";
            string password = "InsodEp&a8094";
            string command = $"msiexec.exe /i \"{rutaDescarga}\" /quiet /norestart";
            ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = appPath + "\\" + appName;
            startInfo.FileName = "cmd.exe";
            startInfo.Verb = "runas"; // Solicitar elevación de permisos
            startInfo.UseShellExecute = false;
            startInfo.UserName = userName;
            startInfo.Arguments = $"/c {command}";
            

            Console.WriteLine("Arguments command: " + startInfo.Arguments);

            // Convertir la contraseña en un objeto SecureString
            var securePassword = new System.Security.SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            startInfo.Password = securePassword;

            try
            {
                //Process process = new Process();
                //process.StartInfo = startInfo;
                //process.Start();
                //process.WaitForExit();

                Process.Start(startInfo);

                //MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso instalación a finalizado correctamente.", "OK", true);
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso de instalación a finalizado correctamente.", 10000, "OK");
                SnackBarMessage.Show(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al iniciar la aplicación: " + ex.Message);
            }

            //Reaload datos dinamicos de la nube
            //loadCardAsync();
        }

        ////Metodo Original
        //public void InstalaAppOriginal(object sender, EventArgs e, string urlMsi, string version, string pathFile)
        //{
        //    string rutaDescarga = Path.Combine("C:\\temp\\repository", pathFile);
        //    Console.WriteLine("Descarga config: " + rutaDescarga);

        //    using (WebClient client = new WebClient())
        //    {
        //        Console.WriteLine("Descarga iniciando...");
        //        client.DownloadFile(urlMsi, rutaDescarga);
        //        Console.WriteLine("Descarga completada... " + rutaDescarga);
        //    }
        //    string ruta = @"C:\temp\repository\TimeBimCAD_1.4.2.0.msi";
        //    string msiPath = "C:\\temp\\repository\\TimeBimCAD_1.4.2.0.msi";
        //    string accountName = "administrador";

        //    // Construir el comando para instalar el MSI con la cuenta local especificada
        //    string command = $"msiexec.exe /i \"{msiPath}\" /quiet /norestart";

        //    // Ejecutar el comando en un proceso
        //    using (Process process = new Process())
        //    {
        //        process.StartInfo.FileName = "cmd.exe";
        //        process.StartInfo.Arguments = $"/c {command}";
        //        process.StartInfo.UseShellExecute = false;
        //        process.StartInfo.RedirectStandardOutput = true;
        //        process.Start();

        //        // Leer la salida del proceso
        //        string output = process.StandardOutput.ReadToEnd();

        //        process.WaitForExit();

        //        // Verificar si la instalación fue exitosa
        //        if (process.ExitCode == 0)
        //        {
        //            Console.WriteLine("Instalación exitosa");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Error en la instalación. Código de salida: {process.ExitCode}");
        //        }

        //        Console.WriteLine(output);

        //        #region
        //        //verifica si existe descarga
        //        if (File.Exists(rutaDescarga))
        //        {
        //            Console.WriteLine("rutaDescarga" + rutaDescarga);

        //            string s = "You win some. You lose some.";

        //            string[] versionLocalSucia = pathFile.Split('_');
        //            string versionLocal = versionLocalSucia[1].Substring(0, 7);

        //            Console.WriteLine("verifica si existe descarga..." + versionLocal + ", " + version);
        //            Version v1 = Version.Parse(versionLocal);
        //            Version v2 = Version.Parse(version);
        //            Console.WriteLine("Compara versiones: " + v1.CompareTo((Object)v2));

        //            //si version local vs web son iguales va al proceso de instalacion
        //            if (v1 != null && v1.CompareTo(v2) == 0)
        //            {
        //                Console.WriteLine("Archivo ya descargado...");

        //                Console.WriteLine("Iniciando instalacion veriricada...");
        //                string fileInstall = Path.Combine(Path.GetTempPath(), "instala.bat");

        //                if (File.Exists(fileInstall))
        //                {
        //                    File.Delete(fileInstall);
        //                }

        //                using (FileStream fs = File.Create(fileInstall))
        //                {
        //                    //Byte[] title = new UTF8Encoding(true).GetBytes($"@echo off\r\nmsiexec.exe /i {GUID} /quiet /norestart\r\ndel \"%~f0\"");
        //                    Byte[] title = new UTF8Encoding(true).GetBytes($"@echo off\r\nmsiexec.exe /i \"{@rutaDescarga}\" /quiet /norestart");
        //                    fs.Write(title, 0, title.Length);
        //                }



        //                Process procesoBatch = new Process();
        //                procesoBatch.StartInfo.FileName = fileInstall;
        //                procesoBatch.StartInfo.CreateNoWindow = true;
        //                procesoBatch.Start();
        //                procesoBatch.WaitForExit();

        //                Console.WriteLine("instalacion completada...");
        //            }
        //            else
        //            {
        //                using (WebClient client = new WebClient())
        //                {
        //                    Console.WriteLine("Descarga iniciando...");
        //                    client.DownloadFile(urlMsi, rutaDescarga);
        //                    Console.WriteLine("Descarga completada...");
        //                }
        //                Console.WriteLine("Descarga ruta archivo2: " + rutaDescarga);
        //                Console.WriteLine("Iniciando instalacion nueva2...");



        //                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", $"msiexec /i " + @rutaDescarga + " / quiet /norestart");


        //                //Process process = new Process();
        //                //process.StartInfo.FileName = "cmd.exe";
        //                //process.StartInfo.Arguments = $"msiexec /i \"{@rutaDescarga}\" /quiet /norestart";


        //                ////Console.WriteLine("CMD : " + process.StartInfo.Arguments.ToString());
        //                //process.StartInfo.CreateNoWindow = true;
        //                //process.Start();
        //                //process.WaitForExit();
        //                Console.WriteLine("instalacion completada..." + procStartInfo);


        //                //Console.WriteLine("Iniciando instalacion...");
        //                //string fileInstall = Path.Combine(Path.GetTempPath(), "instala.bat");

        //                //if (File.Exists(fileInstall))
        //                //{
        //                //    File.Delete(fileInstall);
        //                //}

        //                //using (FileStream fs = File.Create(fileInstall))
        //                //{
        //                //    //Byte[] title = new UTF8Encoding(true).GetBytes($"@echo off\r\nmsiexec.exe /i {GUID} /quiet /norestart\r\ndel \"%~f0\"");
        //                //    Byte[] title = new UTF8Encoding(true).GetBytes($"@echo off\r\nmsiexec.exe /i \"{@rutaDescarga}\" /quiet /norestart\r\ndel \"%~f0\"");
        //                //    fs.Write(title, 0, title.Length);
        //                //    Console.WriteLine("CMD : " + title);
        //                //}

        //                //Process procesoBatch = new Process();
        //                //procesoBatch.StartInfo.FileName = fileInstall;
        //                //procesoBatch.StartInfo.CreateNoWindow = true;
        //                //procesoBatch.Start();
        //                //procesoBatch.WaitForExit();

        //                //Console.WriteLine("instalacion completada...");

        //            }

        //        }
        //        else
        //        {
        //            using (WebClient client = new WebClient())
        //            {
        //                Console.WriteLine("Descarga iniciando...");
        //                client.DownloadFile(urlMsi, rutaDescarga);
        //                Console.WriteLine("Descarga completada...");
        //            }
        //            Console.WriteLine("Descarga ruta archivo: " + rutaDescarga);

        //            Process.Start(@"cmd", @"/c " + $"msiexec /i \"{@rutaDescarga}\" /quiet /norestart");

        //            //Process process = new Process();
        //            //process.StartInfo.FileName = "cmd.exe";
        //            //process.StartInfo.Arguments = $"msiexec /i \"{@rutaDescarga}\" /quiet /norestart";


        //            ////Console.WriteLine("CMD : " + process.StartInfo.Arguments.ToString());
        //            //process.StartInfo.CreateNoWindow = true;
        //            //process.Start();
        //            ////process.WaitForExit();
        //            Console.WriteLine("instalacion completada...");
        //        }

        //        #endregion
        //    }
        //}


        //public void DescargaEInstala(string urlMsi, string pathFile, string forceInstall, string software, string versionWeb, string GUID)
        //{
        //    string rutaDescarga = Path.Combine(Path.GetTempPath(), pathFile);
        //    Console.WriteLine("Descarga config: " + rutaDescarga);

        //    //verifica si existe descarga
        //    if (File.Exists(rutaDescarga))
        //    {
        //        Console.WriteLine("rutaDescarga: " + rutaDescarga );

        //        string s = "You win some. You lose some.";

        //        string[] versionLocalSucia = pathFile.Split('_');
        //        string versionLocal = versionLocalSucia[1].Substring(0, 7);

        //        Console.WriteLine("verifica si existe descarga..." + versionLocal + ", " + versionWeb);
        //        Version v1 = Version.Parse(versionLocal);
        //        Version v2 = Version.Parse(versionWeb);
        //        Console.WriteLine("Compara versiones: " + v1.CompareTo((Object)v2));

        //        //si version local vs web son iguales va al proceso de instalacion
        //        if (v1 != null && v1.CompareTo(v2) == 0)
        //        {
        //            Console.WriteLine("Archivo ya descargado... redirigiendo a verificacion de instalacion");
        //            goto FORCE_INSTALL;
        //        }
        //        else
        //        {
        //            using (WebClient client = new WebClient())
        //            {
        //                Console.WriteLine("Descarga iniciando...");
        //                client.DownloadFile(urlMsi, rutaDescarga);
        //                Console.WriteLine("Descarga completada...");
        //            }
        //            Console.WriteLine("Descarga ruta archivo: " + rutaDescarga);
        //        }

        //    }
        //    else
        //    {
        //        using (WebClient client = new WebClient())
        //        {
        //            Console.WriteLine("Descarga iniciando...");
        //            client.DownloadFile(urlMsi, rutaDescarga);
        //            Console.WriteLine("Descarga completada...");
        //        }
        //        Console.WriteLine("Descarga ruta archivo: " + rutaDescarga);
        //    }



        //    FORCE_INSTALL:
        //    if(forceInstall == "true")
        //    {
        //        Console.WriteLine("Iniciando desinstalacion...");
        //        string fileUnninstall = Path.Combine(Path.GetTempPath(), "desinstala.bat");

        //        if (File.Exists(fileUnninstall))
        //        {
        //            File.Delete(fileUnninstall);
        //        }
        //        // Create a new file     
        //        using (FileStream fs = File.Create(fileUnninstall))
        //        {
        //            // Add some text to file    wmic product where name="RevitActivityTrackerApplication" call uninstall /nointeractive

        //            //Byte[] title = new UTF8Encoding(true).GetBytes("wmic product where name=\"RevitActivityTrackerApplication\" call uninstall /nointeractive");
        //            Byte[] title = new UTF8Encoding(true).GetBytes($"@echo off\r\nmsiexec.exe /x {GUID} /quiet /norestart\r\ndel \"%~f0\"");
        //            fs.Write(title, 0, title.Length);
        //        }

        //        Console.WriteLine("Software " + software + ", GUI = " + GUID + ", desinstalado correctamente.");

        //        Process procesoBatch = new Process();
        //        procesoBatch.StartInfo.FileName = fileUnninstall;

        //        procesoBatch.Start();
        //        procesoBatch.WaitForExit();




        //        //Process process = new Process();
        //        //process.StartInfo.FileName = "cmd.exe";
        //        ////process.StartInfo.WorkingDirectory = rutaDescarga;
        //        //process.StartInfo.Arguments = $"wmic product where name='{software}' call uninstall /nointeractive";
        //        //process.Start();
        //        //process.WaitForExit();
        //        Console.WriteLine("Desinstalacion completada...");

        //        //Console.WriteLine("Iniciando update...");
        //        //Process process = new Process();
        //        //process.StartInfo.FileName = "cmd.exe";
        //        ////process.StartInfo.WorkingDirectory = rutaDescarga;
        //        //process.StartInfo.Arguments = $"msiexec /x {rutaDescarga} /q";
        //        //process.Start();
        //        //process.WaitForExit();
        //        //Console.WriteLine("Update completado...");

        //    }
        //    else
        //    {
        //        Console.WriteLine("forceInstall = " + forceInstall);
        //    }
        //}

        private string LocalVersionApp(string pathInstall, string version)
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

                    //Console.WriteLine("\n\nFile: " + infoArchivo.FileDescription + '\n' + "Version number: " + infoArchivo.FileVersion + "\n\n");
                    //Console.WriteLine("Versión local = " + versionLocal + ", Version web es = " + versionWeb + "\n\n");

                    Version v1 = new Version(versionLocal);
                    Version v2 = new Version(versionWeb);
                    //Console.WriteLine("Compara versiones: " + v1.CompareTo((Object)v2));

                    return v1.CompareTo(v2);

                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("Error al verificar version: " + versionWeb + " en ruta: " + pathInstall);
            }
            
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
                Properties.Settings.Default.estiloTema = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                Properties.Settings.Default.estiloTema = true;
                Properties.Settings.Default.Save();
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

            Properties.Settings.Default.codigoTema = colorSchemeIndex;
            Properties.Settings.Default.Save();
            Invalidate();
        }

        //private Boolean VerificaApp(object sender, EventArgs e, string verificaApp, string pathInstall, string version)
        //{
        //    Process[] procesos = Process.GetProcessesByName(verificaApp);

        //    if (procesos.Length > 0)
        //    {
        //        Console.WriteLine("El proceso de AutoCAD está activo.");
        //        MaterialSnackBar SnackBarMessage = new MaterialSnackBar("El proceso "+ verificaApp.ToUpper() + " está activo. Favor cierre la aplicacion antes de continuar.", "OK", true);
        //        SnackBarMessage.Show(this);
        //        return true;
        //    }
        //    else
        //    {
        //        Console.WriteLine("El proceso " + verificaApp.ToUpper()+" no está activo.");
        //        return false;
        //    }
            
        //}

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

      
    }
}
