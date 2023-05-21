using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace MaterialSkinExample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuIconList = new System.Windows.Forms.ImageList(this.components);
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel24 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton7 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.tabPageApps = new System.Windows.Forms.TabPage();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.listaFiltro = new MaterialSkin.Controls.MaterialCheckedListBox();
            this.materialButtonReload = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel60 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel59 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel45 = new MaterialSkin.Controls.MaterialLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageInicio = new System.Windows.Forms.TabPage();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialCard7 = new MaterialSkin.Controls.MaterialCard();
            this.materialButton32 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel67 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel68 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard5 = new MaterialSkin.Controls.MaterialCard();
            this.materialButton30 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel63 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel64 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel61 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel62 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.materialCheckbox1 = new MaterialSkin.Controls.MaterialCheckbox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPageConfig.SuspendLayout();
            this.tabPageApps.SuspendLayout();
            this.tabPageInicio.SuspendLayout();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.materialCard7.SuspendLayout();
            this.materialCard5.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuIconList
            // 
            this.menuIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuIconList.ImageStream")));
            this.menuIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.menuIconList.Images.SetKeyName(0, "round_assessment_white_24dp.png");
            this.menuIconList.Images.SetKeyName(1, "round_backup_white_24dp.png");
            this.menuIconList.Images.SetKeyName(2, "round_bluetooth_white_24dp.png");
            this.menuIconList.Images.SetKeyName(3, "round_bookmark_white_24dp.png");
            this.menuIconList.Images.SetKeyName(4, "round_build_white_24dp.png");
            this.menuIconList.Images.SetKeyName(5, "round_gps_fixed_white_24dp.png");
            this.menuIconList.Images.SetKeyName(6, "round_http_white_24dp.png");
            this.menuIconList.Images.SetKeyName(7, "round_report_problem_white_24dp.png");
            this.menuIconList.Images.SetKeyName(8, "round_swap_vert_white_24dp.png");
            this.menuIconList.Images.SetKeyName(9, "round_phone_black_24dp.png");
            this.menuIconList.Images.SetKeyName(10, "round_push_pin_black_24dp.png");
            this.menuIconList.Images.SetKeyName(11, "round_mail_outline_black_24dp.png");
            this.menuIconList.Images.SetKeyName(12, "round_person_black_24dp.png");
            this.menuIconList.Images.SetKeyName(13, "round_add_a_photo_black_24dp.png");
            this.menuIconList.Images.SetKeyName(14, "round_alternate_email_black_24dp.png");
            this.menuIconList.Images.SetKeyName(15, "round_cancel_black_24dp.png");
            this.menuIconList.Images.SetKeyName(16, "round_error_black_24dp.png");
            this.menuIconList.Images.SetKeyName(17, "round_event_black_24dp.png");
            this.menuIconList.Images.SetKeyName(18, "outline_apps_white_24dp.png");
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.BackColor = System.Drawing.Color.White;
            this.tabPageConfig.Controls.Add(this.materialButton2);
            this.tabPageConfig.Controls.Add(this.materialLabel24);
            this.tabPageConfig.Controls.Add(this.materialButton7);
            this.tabPageConfig.Controls.Add(this.materialLabel9);
            this.tabPageConfig.ImageKey = "round_build_white_24dp.png";
            this.tabPageConfig.Location = new System.Drawing.Point(4, 31);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Size = new System.Drawing.Size(999, 620);
            this.tabPageConfig.TabIndex = 0;
            this.tabPageConfig.Text = "Configuracion";
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(177, 158);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(137, 36);
            this.materialButton2.TabIndex = 40;
            this.materialButton2.Text = "Cambiar Color";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // materialLabel24
            // 
            this.materialLabel24.AutoSize = true;
            this.materialLabel24.Depth = 0;
            this.materialLabel24.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel24.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel24.Location = new System.Drawing.Point(21, 17);
            this.materialLabel24.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel24.Name = "materialLabel24";
            this.materialLabel24.Size = new System.Drawing.Size(299, 58);
            this.materialLabel24.TabIndex = 32;
            this.materialLabel24.Text = "Configuración";
            // 
            // materialButton7
            // 
            this.materialButton7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton7.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton7.Depth = 0;
            this.materialButton7.HighEmphasis = true;
            this.materialButton7.Icon = null;
            this.materialButton7.Location = new System.Drawing.Point(28, 158);
            this.materialButton7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton7.Name = "materialButton7";
            this.materialButton7.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton7.Size = new System.Drawing.Size(125, 36);
            this.materialButton7.TabIndex = 0;
            this.materialButton7.Text = "Modo Oscuro";
            this.materialButton7.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.materialButton7.UseAccentColor = false;
            this.materialButton7.UseVisualStyleBackColor = true;
            this.materialButton7.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // materialLabel9
            // 
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(19, 79);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(455, 60);
            this.materialLabel9.TabIndex = 0;
            this.materialLabel9.Text = "Ajustes de aplicación.\r\n";
            // 
            // tabPageApps
            // 
            this.tabPageApps.BackColor = System.Drawing.Color.White;
            this.tabPageApps.Controls.Add(this.materialButton1);
            this.tabPageApps.Controls.Add(this.listaFiltro);
            this.tabPageApps.Controls.Add(this.materialButtonReload);
            this.tabPageApps.Controls.Add(this.materialLabel60);
            this.tabPageApps.Controls.Add(this.materialLabel59);
            this.tabPageApps.Controls.Add(this.materialLabel45);
            this.tabPageApps.Controls.Add(this.flowLayoutPanel1);
            this.tabPageApps.ImageKey = "outline_apps_white_24dp.png";
            this.tabPageApps.Location = new System.Drawing.Point(4, 31);
            this.tabPageApps.Name = "tabPageApps";
            this.tabPageApps.Size = new System.Drawing.Size(999, 620);
            this.tabPageApps.TabIndex = 8;
            this.tabPageApps.Text = "Aplicaciones";
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = global::MaterialSkinExample.Properties.Resources.outline_sync_white_24dp;
            this.materialButton1.Location = new System.Drawing.Point(796, 197);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(105, 38);
            this.materialButton1.TabIndex = 88;
            this.materialButton1.Text = "Limpiar";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Visible = false;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click_1);
            // 
            // listaFiltro
            // 
            this.listaFiltro.AutoScroll = true;
            this.listaFiltro.BackColor = System.Drawing.Color.White;
            this.listaFiltro.Depth = 0;
            this.listaFiltro.Location = new System.Drawing.Point(688, 236);
            this.listaFiltro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listaFiltro.MouseState = MaterialSkin.MouseState.HOVER;
            this.listaFiltro.Name = "listaFiltro";
            this.listaFiltro.Size = new System.Drawing.Size(213, 290);
            this.listaFiltro.Striped = false;
            this.listaFiltro.StripeDarkColor = System.Drawing.Color.Empty;
            this.listaFiltro.TabIndex = 87;
            this.listaFiltro.Visible = false;
            // 
            // materialButtonReload
            // 
            this.materialButtonReload.AutoSize = false;
            this.materialButtonReload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonReload.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonReload.Depth = 0;
            this.materialButtonReload.HighEmphasis = true;
            this.materialButtonReload.Icon = global::MaterialSkinExample.Properties.Resources.outline_sync_white_24dp;
            this.materialButtonReload.Location = new System.Drawing.Point(661, 138);
            this.materialButtonReload.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonReload.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonReload.Name = "materialButtonReload";
            this.materialButtonReload.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonReload.Size = new System.Drawing.Size(39, 38);
            this.materialButtonReload.TabIndex = 86;
            this.materialButtonReload.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonReload.UseAccentColor = false;
            this.materialButtonReload.UseVisualStyleBackColor = true;
            this.materialButtonReload.Click += new System.EventHandler(this.materialButtonReload_Click);
            // 
            // materialLabel60
            // 
            this.materialLabel60.Depth = 0;
            this.materialLabel60.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel60.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel60.Location = new System.Drawing.Point(686, 199);
            this.materialLabel60.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel60.Name = "materialLabel60";
            this.materialLabel60.Size = new System.Drawing.Size(133, 34);
            this.materialLabel60.TabIndex = 85;
            this.materialLabel60.Text = "Filtrar por:";
            this.materialLabel60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialLabel60.Visible = false;
            // 
            // materialLabel59
            // 
            this.materialLabel59.AutoSize = true;
            this.materialLabel59.Depth = 0;
            this.materialLabel59.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel59.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel59.Location = new System.Drawing.Point(15, 15);
            this.materialLabel59.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel59.Name = "materialLabel59";
            this.materialLabel59.Size = new System.Drawing.Size(274, 58);
            this.materialLabel59.TabIndex = 71;
            this.materialLabel59.Text = "Aplicaciones";
            // 
            // materialLabel45
            // 
            this.materialLabel45.AutoSize = true;
            this.materialLabel45.Depth = 0;
            this.materialLabel45.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel45.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel45.Location = new System.Drawing.Point(20, 80);
            this.materialLabel45.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel45.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel45.Name = "materialLabel45";
            this.materialLabel45.Size = new System.Drawing.Size(595, 19);
            this.materialLabel45.TabIndex = 70;
            this.materialLabel45.Text = "Listado de aplicaciones para potenciar el trabajo con herramientas de modelado 3D" +
    ".";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(25, 138);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(619, 456);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // tabPageInicio
            // 
            this.tabPageInicio.BackColor = System.Drawing.Color.White;
            this.tabPageInicio.Controls.Add(this.materialCard1);
            this.tabPageInicio.Controls.Add(this.pictureBox1);
            this.tabPageInicio.Controls.Add(this.materialCard7);
            this.tabPageInicio.Controls.Add(this.materialCard5);
            this.tabPageInicio.Controls.Add(this.materialLabel61);
            this.tabPageInicio.Controls.Add(this.materialLabel62);
            this.tabPageInicio.ImageKey = "round_assessment_white_24dp.png";
            this.tabPageInicio.Location = new System.Drawing.Point(4, 31);
            this.tabPageInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageInicio.Name = "tabPageInicio";
            this.tabPageInicio.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageInicio.Size = new System.Drawing.Size(999, 620);
            this.tabPageInicio.TabIndex = 10;
            this.tabPageInicio.Text = "Inicio";
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.materialLabel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(19, 197);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14, 14, 14, 14);
            this.materialCard1.Size = new System.Drawing.Size(819, 187);
            this.materialCard1.TabIndex = 71;
            this.materialCard1.Visible = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(17, 14);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(83, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Feed List";
            this.materialLabel1.UseMnemonic = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MaterialSkinExample.Properties.Resources.Logo_horizontal_Definitivo_2__removebg_preview;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(443, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(394, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // materialCard7
            // 
            this.materialCard7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard7.Controls.Add(this.materialButton32);
            this.materialCard7.Controls.Add(this.materialLabel67);
            this.materialCard7.Controls.Add(this.materialLabel68);
            this.materialCard7.Depth = 0;
            this.materialCard7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard7.Location = new System.Drawing.Point(443, 412);
            this.materialCard7.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.materialCard7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard7.Name = "materialCard7";
            this.materialCard7.Padding = new System.Windows.Forms.Padding(14, 14, 14, 14);
            this.materialCard7.Size = new System.Drawing.Size(394, 187);
            this.materialCard7.TabIndex = 70;
            // 
            // materialButton32
            // 
            this.materialButton32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton32.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton32.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton32.Depth = 0;
            this.materialButton32.HighEmphasis = true;
            this.materialButton32.Icon = null;
            this.materialButton32.Location = new System.Drawing.Point(301, 129);
            this.materialButton32.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton32.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton32.Name = "materialButton32";
            this.materialButton32.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton32.Size = new System.Drawing.Size(76, 36);
            this.materialButton32.TabIndex = 1;
            this.materialButton32.Text = "Visitar";
            this.materialButton32.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.materialButton32.UseAccentColor = false;
            this.materialButton32.UseVisualStyleBackColor = true;
            this.materialButton32.Click += new System.EventHandler(this.materialButton32_Click);
            // 
            // materialLabel67
            // 
            this.materialLabel67.AutoSize = true;
            this.materialLabel67.Depth = 0;
            this.materialLabel67.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel67.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel67.HighEmphasis = true;
            this.materialLabel67.Location = new System.Drawing.Point(17, 14);
            this.materialLabel67.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel67.Name = "materialLabel67";
            this.materialLabel67.Size = new System.Drawing.Size(171, 24);
            this.materialLabel67.TabIndex = 0;
            this.materialLabel67.Text = "Sistema de Tickets";
            // 
            // materialLabel68
            // 
            this.materialLabel68.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel68.Depth = 0;
            this.materialLabel68.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel68.Location = new System.Drawing.Point(17, 52);
            this.materialLabel68.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel68.Name = "materialLabel68";
            this.materialLabel68.Size = new System.Drawing.Size(361, 73);
            this.materialLabel68.TabIndex = 2;
            this.materialLabel68.Text = "Tienes algun inconveniente con tu equipo?\r\nIngresa un ticket en nuestros sistemas" +
    " para que podarmos apoyarte!";
            // 
            // materialCard5
            // 
            this.materialCard5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard5.Controls.Add(this.materialButton30);
            this.materialCard5.Controls.Add(this.materialLabel63);
            this.materialCard5.Controls.Add(this.materialLabel64);
            this.materialCard5.Depth = 0;
            this.materialCard5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard5.Location = new System.Drawing.Point(19, 412);
            this.materialCard5.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.materialCard5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard5.Name = "materialCard5";
            this.materialCard5.Padding = new System.Windows.Forms.Padding(14, 14, 14, 14);
            this.materialCard5.Size = new System.Drawing.Size(394, 187);
            this.materialCard5.TabIndex = 70;
            // 
            // materialButton30
            // 
            this.materialButton30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton30.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton30.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton30.Depth = 0;
            this.materialButton30.HighEmphasis = true;
            this.materialButton30.Icon = null;
            this.materialButton30.Location = new System.Drawing.Point(301, 129);
            this.materialButton30.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton30.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton30.Name = "materialButton30";
            this.materialButton30.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton30.Size = new System.Drawing.Size(76, 36);
            this.materialButton30.TabIndex = 1;
            this.materialButton30.Text = "Visitar";
            this.materialButton30.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.materialButton30.UseAccentColor = false;
            this.materialButton30.UseVisualStyleBackColor = true;
            this.materialButton30.Click += new System.EventHandler(this.materialButton30_Click);
            // 
            // materialLabel63
            // 
            this.materialLabel63.AutoSize = true;
            this.materialLabel63.Depth = 0;
            this.materialLabel63.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel63.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel63.HighEmphasis = true;
            this.materialLabel63.Location = new System.Drawing.Point(17, 14);
            this.materialLabel63.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel63.Name = "materialLabel63";
            this.materialLabel63.Size = new System.Drawing.Size(140, 24);
            this.materialLabel63.TabIndex = 0;
            this.materialLabel63.Text = "Pares y Alvarez";
            this.materialLabel63.UseMnemonic = false;
            // 
            // materialLabel64
            // 
            this.materialLabel64.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel64.Depth = 0;
            this.materialLabel64.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel64.Location = new System.Drawing.Point(17, 52);
            this.materialLabel64.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel64.Name = "materialLabel64";
            this.materialLabel64.Size = new System.Drawing.Size(361, 73);
            this.materialLabel64.TabIndex = 2;
            this.materialLabel64.Text = "Generamos soluciones industriales para la minería, energía, química, derivados de" +
    " la madera, petróleo, gas, alimentos, manufactura e infraestructura, entregando " +
    "soluciones y calidad a sus clientes.";
            // 
            // materialLabel61
            // 
            this.materialLabel61.AutoSize = true;
            this.materialLabel61.Depth = 0;
            this.materialLabel61.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel61.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel61.Location = new System.Drawing.Point(18, 22);
            this.materialLabel61.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel61.Name = "materialLabel61";
            this.materialLabel61.Size = new System.Drawing.Size(116, 58);
            this.materialLabel61.TabIndex = 34;
            this.materialLabel61.Text = "Inicio";
            // 
            // materialLabel62
            // 
            this.materialLabel62.Depth = 0;
            this.materialLabel62.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel62.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel62.Location = new System.Drawing.Point(16, 99);
            this.materialLabel62.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel62.Name = "materialLabel62";
            this.materialLabel62.Size = new System.Drawing.Size(422, 90);
            this.materialLabel62.TabIndex = 33;
            this.materialLabel62.Text = "Bienvenido a la aplicacion PYA Launcher Apps.\r\n\r\nAplicación diseñada para mantene" +
    "r actualizados todos los softwares y plugins diseñados para ti.\r\n";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPageApps);
            this.materialTabControl1.Controls.Add(this.tabPageInicio);
            this.materialTabControl1.Controls.Add(this.tabPageConfig);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.menuIconList;
            this.materialTabControl1.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1007, 655);
            this.materialTabControl1.TabIndex = 18;
            // 
            // materialCheckbox1
            // 
            this.materialCheckbox1.Depth = 0;
            this.materialCheckbox1.Location = new System.Drawing.Point(0, 0);
            this.materialCheckbox1.Margin = new System.Windows.Forms.Padding(0);
            this.materialCheckbox1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialCheckbox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckbox1.Name = "materialCheckbox1";
            this.materialCheckbox1.ReadOnly = false;
            this.materialCheckbox1.Ripple = true;
            this.materialCheckbox1.Size = new System.Drawing.Size(104, 37);
            this.materialCheckbox1.TabIndex = 0;
            this.materialCheckbox1.Text = "materialCheckbox1";
            this.materialCheckbox1.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "En segundo plano";
            this.notifyIcon1.BalloonTipTitle = "PYA Launcher Apps";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "PYALauncherApps";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1013, 722);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "MainForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PYA Launcher Apps";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            this.tabPageApps.ResumeLayout(false);
            this.tabPageApps.PerformLayout();
            this.tabPageInicio.ResumeLayout(false);
            this.tabPageInicio.PerformLayout();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.materialCard7.ResumeLayout(false);
            this.materialCard7.PerformLayout();
            this.materialCard5.ResumeLayout(false);
            this.materialCard5.PerformLayout();
            this.materialTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ImageList menuIconList;
        private TabPage tabPageConfig;
        private MaterialLabel materialLabel24;
        private MaterialButton materialButton7;
        private MaterialLabel materialLabel9;
        private TabPage tabPageApps;
        private MaterialLabel materialLabel60;
        private MaterialLabel materialLabel59;
        private MaterialLabel materialLabel45;
        private FlowLayoutPanel flowLayoutPanel1;
        private TabPage tabPageInicio;
        private PictureBox pictureBox1;
        private MaterialCard materialCard7;
        private MaterialButton materialButton32;
        private MaterialLabel materialLabel67;
        private MaterialLabel materialLabel68;
        private MaterialCard materialCard5;
        private MaterialButton materialButton30;
        private MaterialLabel materialLabel63;
        private MaterialLabel materialLabel64;
        private MaterialLabel materialLabel61;
        private MaterialLabel materialLabel62;
        private MaterialTabControl materialTabControl1;
        private MaterialButton materialButtonReload;
        private MaterialButton materialButton2;
        public MaterialCheckedListBox listaFiltro;
        private MaterialCheckbox materialCheckbox1;
        private MaterialButton materialButton1;
        private MaterialCard materialCard1;
        private MaterialLabel materialLabel1;
        private NotifyIcon notifyIcon1;
    }
}
