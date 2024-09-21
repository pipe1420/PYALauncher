using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace PYALauncherApps
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuIconList = new ImageList(components);
            materialCheckbox1 = new MaterialCheckbox();
            notifyIcon1 = new NotifyIcon(components);
            tabPageConfig = new TabPage();
            materialButton2 = new MaterialButton();
            materialLabel24 = new MaterialLabel();
            materialButton7 = new MaterialButton();
            materialLabel9 = new MaterialLabel();
            tabPageLogs = new TabPage();
            labelTitleHistory = new MaterialLabel();
            labelSubTitleHistory = new MaterialLabel();
            materialListBoxLogs = new MaterialListBox();
            buttonRefreshHistory = new MaterialButton();
            tabPageApps = new TabPage();
            buttonAppsRefresh = new MaterialButton();
            materialButtonAddSoftware = new MaterialButton();
            flowLayoutPanel2 = new FlowLayoutPanel();
            labelTitleApps = new MaterialLabel();
            labelSubTitleApps = new MaterialLabel();
            tabPageInicio = new TabPage();
            listBoxSoftware = new ListBox();
            listBoxConfigs = new ListBox();
            materialListBoxSoftware = new MaterialListBox();
            materialListBoxConfigs = new MaterialListBox();
            materialCard1 = new MaterialCard();
            materialLabel1 = new MaterialLabel();
            pictureBox1 = new PictureBox();
            materialCard7 = new MaterialCard();
            materialButton32 = new MaterialButton();
            materialLabel67 = new MaterialLabel();
            materialLabel68 = new MaterialLabel();
            materialCard5 = new MaterialCard();
            materialButton30 = new MaterialButton();
            materialLabel63 = new MaterialLabel();
            materialLabel64 = new MaterialLabel();
            materialLabel61 = new MaterialLabel();
            materialLabel62 = new MaterialLabel();
            materialTabControl1 = new MaterialTabControl();
            tabPagePerm = new TabPage();
            btnSavePerm = new MaterialButton();
            materialLabel2 = new MaterialLabel();
            dataGridViewPermisos = new DataGridView();
            labelTitlePermisos = new MaterialLabel();
            tabPageConfig.SuspendLayout();
            tabPageLogs.SuspendLayout();
            tabPageApps.SuspendLayout();
            tabPageInicio.SuspendLayout();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            materialCard7.SuspendLayout();
            materialCard5.SuspendLayout();
            materialTabControl1.SuspendLayout();
            tabPagePerm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPermisos).BeginInit();
            SuspendLayout();
            // 
            // menuIconList
            // 
            menuIconList.ColorDepth = ColorDepth.Depth32Bit;
            menuIconList.ImageStream = (ImageListStreamer)resources.GetObject("menuIconList.ImageStream");
            menuIconList.TransparentColor = Color.Transparent;
            menuIconList.Images.SetKeyName(0, "round_assessment_white_24dp.png");
            menuIconList.Images.SetKeyName(1, "round_backup_white_24dp.png");
            menuIconList.Images.SetKeyName(2, "round_bluetooth_white_24dp.png");
            menuIconList.Images.SetKeyName(3, "round_bookmark_white_24dp.png");
            menuIconList.Images.SetKeyName(4, "round_build_white_24dp.png");
            menuIconList.Images.SetKeyName(5, "round_gps_fixed_white_24dp.png");
            menuIconList.Images.SetKeyName(6, "round_http_white_24dp.png");
            menuIconList.Images.SetKeyName(7, "round_report_problem_white_24dp.png");
            menuIconList.Images.SetKeyName(8, "round_swap_vert_white_24dp.png");
            menuIconList.Images.SetKeyName(9, "round_phone_black_24dp.png");
            menuIconList.Images.SetKeyName(10, "round_push_pin_black_24dp.png");
            menuIconList.Images.SetKeyName(11, "round_mail_outline_black_24dp.png");
            menuIconList.Images.SetKeyName(12, "round_person_black_24dp.png");
            menuIconList.Images.SetKeyName(13, "round_add_a_photo_black_24dp.png");
            menuIconList.Images.SetKeyName(14, "round_alternate_email_black_24dp.png");
            menuIconList.Images.SetKeyName(15, "round_cancel_black_24dp.png");
            menuIconList.Images.SetKeyName(16, "round_error_black_24dp.png");
            menuIconList.Images.SetKeyName(17, "round_event_black_24dp.png");
            menuIconList.Images.SetKeyName(18, "outline_apps_white_24dp.png");
            // 
            // materialCheckbox1
            // 
            materialCheckbox1.Depth = 0;
            materialCheckbox1.Location = new Point(0, 0);
            materialCheckbox1.Margin = new Padding(0);
            materialCheckbox1.MouseLocation = new Point(-1, -1);
            materialCheckbox1.MouseState = MouseState.HOVER;
            materialCheckbox1.Name = "materialCheckbox1";
            materialCheckbox1.ReadOnly = false;
            materialCheckbox1.Ripple = true;
            materialCheckbox1.Size = new Size(104, 37);
            materialCheckbox1.TabIndex = 0;
            materialCheckbox1.Text = "materialCheckbox1";
            materialCheckbox1.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "En segundo plano";
            notifyIcon1.BalloonTipTitle = "PYA Launcher Apps";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "PYALauncherApps";
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // tabPageConfig
            // 
            tabPageConfig.BackColor = Color.White;
            tabPageConfig.Controls.Add(materialButton2);
            tabPageConfig.Controls.Add(materialLabel24);
            tabPageConfig.Controls.Add(materialButton7);
            tabPageConfig.Controls.Add(materialLabel9);
            tabPageConfig.ImageKey = "round_build_white_24dp.png";
            tabPageConfig.Location = new Point(4, 31);
            tabPageConfig.Margin = new Padding(4, 3, 4, 3);
            tabPageConfig.Name = "tabPageConfig";
            tabPageConfig.Size = new Size(1095, 712);
            tabPageConfig.TabIndex = 0;
            tabPageConfig.Text = "Acerca de";
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(206, 182);
            materialButton2.Margin = new Padding(5, 7, 5, 7);
            materialButton2.MouseState = MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(137, 36);
            materialButton2.TabIndex = 40;
            materialButton2.Text = "Cambiar Color";
            materialButton2.Type = MaterialButton.MaterialButtonType.Outlined;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // materialLabel24
            // 
            materialLabel24.AutoSize = true;
            materialLabel24.Depth = 0;
            materialLabel24.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel24.FontType = MaterialSkinManager.fontType.H3;
            materialLabel24.Location = new Point(21, 25);
            materialLabel24.Margin = new Padding(4, 0, 4, 0);
            materialLabel24.MouseState = MouseState.HOVER;
            materialLabel24.Name = "materialLabel24";
            materialLabel24.Size = new Size(213, 58);
            materialLabel24.TabIndex = 32;
            materialLabel24.Text = "Acerca de";
            // 
            // materialButton7
            // 
            materialButton7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton7.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton7.Depth = 0;
            materialButton7.HighEmphasis = true;
            materialButton7.Icon = null;
            materialButton7.Location = new Point(33, 182);
            materialButton7.Margin = new Padding(5, 7, 5, 7);
            materialButton7.MouseState = MouseState.HOVER;
            materialButton7.Name = "materialButton7";
            materialButton7.NoAccentTextColor = Color.Empty;
            materialButton7.Size = new Size(125, 36);
            materialButton7.TabIndex = 0;
            materialButton7.Text = "Modo Oscuro";
            materialButton7.Type = MaterialButton.MaterialButtonType.Outlined;
            materialButton7.UseAccentColor = false;
            materialButton7.UseVisualStyleBackColor = true;
            materialButton7.Click += materialButton1_Click;
            // 
            // materialLabel9
            // 
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.ForeColor = Color.FromArgb(180, 0, 0, 0);
            materialLabel9.Location = new Point(19, 114);
            materialLabel9.Margin = new Padding(4, 0, 4, 0);
            materialLabel9.MouseState = MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(531, 69);
            materialLabel9.TabIndex = 0;
            materialLabel9.Text = "Ajustes de aplicación.\r\n";
            // 
            // tabPageLogs
            // 
            tabPageLogs.BackColor = Color.White;
            tabPageLogs.Controls.Add(labelTitleHistory);
            tabPageLogs.Controls.Add(labelSubTitleHistory);
            tabPageLogs.Controls.Add(materialListBoxLogs);
            tabPageLogs.Controls.Add(buttonRefreshHistory);
            tabPageLogs.ImageKey = "round_bookmark_white_24dp.png";
            tabPageLogs.Location = new Point(4, 31);
            tabPageLogs.Margin = new Padding(2);
            tabPageLogs.Name = "tabPageLogs";
            tabPageLogs.Padding = new Padding(2);
            tabPageLogs.Size = new Size(1095, 712);
            tabPageLogs.TabIndex = 11;
            tabPageLogs.Text = "Historial";
            // 
            // labelTitleHistory
            // 
            labelTitleHistory.AutoSize = true;
            labelTitleHistory.Depth = 0;
            labelTitleHistory.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelTitleHistory.FontType = MaterialSkinManager.fontType.H3;
            labelTitleHistory.Location = new Point(21, 25);
            labelTitleHistory.Margin = new Padding(4, 0, 4, 0);
            labelTitleHistory.MouseState = MouseState.HOVER;
            labelTitleHistory.Name = "labelTitleHistory";
            labelTitleHistory.Size = new Size(181, 58);
            labelTitleHistory.TabIndex = 89;
            labelTitleHistory.Text = "Historial";
            // 
            // labelSubTitleHistory
            // 
            labelSubTitleHistory.AutoSize = true;
            labelSubTitleHistory.Depth = 0;
            labelSubTitleHistory.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelSubTitleHistory.ForeColor = Color.FromArgb(180, 0, 0, 0);
            labelSubTitleHistory.Location = new Point(19, 114);
            labelSubTitleHistory.Margin = new Padding(2, 0, 2, 0);
            labelSubTitleHistory.MouseState = MouseState.HOVER;
            labelSubTitleHistory.Name = "labelSubTitleHistory";
            labelSubTitleHistory.Size = new Size(557, 19);
            labelSubTitleHistory.TabIndex = 88;
            labelSubTitleHistory.Text = "Registros de movimientos de descargas, instalaciones, actualizaciones y otros.";
            // 
            // materialListBoxLogs
            // 
            materialListBoxLogs.BackColor = Color.White;
            materialListBoxLogs.BorderColor = Color.LightGray;
            materialListBoxLogs.Depth = 0;
            materialListBoxLogs.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialListBoxLogs.Location = new Point(22, 173);
            materialListBoxLogs.Margin = new Padding(2);
            materialListBoxLogs.MouseState = MouseState.HOVER;
            materialListBoxLogs.Name = "materialListBoxLogs";
            materialListBoxLogs.SelectedIndex = -1;
            materialListBoxLogs.SelectedItem = null;
            materialListBoxLogs.Size = new Size(932, 519);
            materialListBoxLogs.TabIndex = 0;
            // 
            // buttonRefreshHistory
            // 
            buttonRefreshHistory.AutoSize = false;
            buttonRefreshHistory.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonRefreshHistory.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonRefreshHistory.Depth = 0;
            buttonRefreshHistory.HighEmphasis = true;
            buttonRefreshHistory.Icon = Properties.Resources.outline_sync_white_24dp;
            buttonRefreshHistory.Location = new Point(916, 92);
            buttonRefreshHistory.Margin = new Padding(5, 7, 5, 7);
            buttonRefreshHistory.MouseState = MouseState.HOVER;
            buttonRefreshHistory.Name = "buttonRefreshHistory";
            buttonRefreshHistory.NoAccentTextColor = Color.Empty;
            buttonRefreshHistory.Size = new Size(39, 41);
            buttonRefreshHistory.TabIndex = 87;
            buttonRefreshHistory.Type = MaterialButton.MaterialButtonType.Contained;
            buttonRefreshHistory.UseAccentColor = false;
            buttonRefreshHistory.UseVisualStyleBackColor = true;
            buttonRefreshHistory.Click += materialButton3_Click;
            // 
            // tabPageApps
            // 
            tabPageApps.BackColor = Color.White;
            tabPageApps.Controls.Add(buttonAppsRefresh);
            tabPageApps.Controls.Add(materialButtonAddSoftware);
            tabPageApps.Controls.Add(flowLayoutPanel2);
            tabPageApps.Controls.Add(labelTitleApps);
            tabPageApps.Controls.Add(labelSubTitleApps);
            tabPageApps.ImageKey = "outline_apps_white_24dp.png";
            tabPageApps.Location = new Point(4, 31);
            tabPageApps.Margin = new Padding(2);
            tabPageApps.Name = "tabPageApps";
            tabPageApps.Size = new Size(1095, 712);
            tabPageApps.TabIndex = 12;
            tabPageApps.Text = "Aplicaciones";
            // 
            // buttonAppsRefresh
            // 
            buttonAppsRefresh.AutoSize = false;
            buttonAppsRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAppsRefresh.Density = MaterialButton.MaterialButtonDensity.Default;
            buttonAppsRefresh.Depth = 0;
            buttonAppsRefresh.HighEmphasis = true;
            buttonAppsRefresh.Icon = Properties.Resources.outline_sync_white_24dp;
            buttonAppsRefresh.Location = new Point(903, 91);
            buttonAppsRefresh.Margin = new Padding(5, 7, 5, 7);
            buttonAppsRefresh.MouseState = MouseState.HOVER;
            buttonAppsRefresh.Name = "buttonAppsRefresh";
            buttonAppsRefresh.NoAccentTextColor = Color.Empty;
            buttonAppsRefresh.Size = new Size(41, 42);
            buttonAppsRefresh.TabIndex = 76;
            buttonAppsRefresh.Type = MaterialButton.MaterialButtonType.Contained;
            buttonAppsRefresh.UseAccentColor = false;
            buttonAppsRefresh.UseVisualStyleBackColor = true;
            buttonAppsRefresh.Click += buttonAppsRefresh_Click;
            // 
            // materialButtonAddSoftware
            // 
            materialButtonAddSoftware.AutoSize = false;
            materialButtonAddSoftware.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButtonAddSoftware.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButtonAddSoftware.Depth = 0;
            materialButtonAddSoftware.HighEmphasis = true;
            materialButtonAddSoftware.Icon = null;
            materialButtonAddSoftware.Location = new Point(827, 44);
            materialButtonAddSoftware.Margin = new Padding(5, 7, 5, 7);
            materialButtonAddSoftware.MouseState = MouseState.HOVER;
            materialButtonAddSoftware.Name = "materialButtonAddSoftware";
            materialButtonAddSoftware.NoAccentTextColor = Color.Empty;
            materialButtonAddSoftware.Size = new Size(117, 42);
            materialButtonAddSoftware.TabIndex = 75;
            materialButtonAddSoftware.Text = "Agregar";
            materialButtonAddSoftware.Type = MaterialButton.MaterialButtonType.Contained;
            materialButtonAddSoftware.UseAccentColor = false;
            materialButtonAddSoftware.UseVisualStyleBackColor = true;
            materialButtonAddSoftware.Click += materialButtonAddSoftware_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(22, 173);
            flowLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(922, 494);
            flowLayoutPanel2.TabIndex = 74;
            flowLayoutPanel2.WrapContents = false;
            // 
            // labelTitleApps
            // 
            labelTitleApps.AutoSize = true;
            labelTitleApps.Depth = 0;
            labelTitleApps.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelTitleApps.FontType = MaterialSkinManager.fontType.H3;
            labelTitleApps.Location = new Point(14, 17);
            labelTitleApps.Margin = new Padding(4, 0, 4, 0);
            labelTitleApps.MouseState = MouseState.HOVER;
            labelTitleApps.Name = "labelTitleApps";
            labelTitleApps.Size = new Size(274, 58);
            labelTitleApps.TabIndex = 73;
            labelTitleApps.Text = "Aplicaciones";
            // 
            // labelSubTitleApps
            // 
            labelSubTitleApps.AutoSize = true;
            labelSubTitleApps.Depth = 0;
            labelSubTitleApps.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelSubTitleApps.ForeColor = Color.FromArgb(180, 0, 0, 0);
            labelSubTitleApps.Location = new Point(19, 114);
            labelSubTitleApps.Margin = new Padding(2, 0, 2, 0);
            labelSubTitleApps.MouseState = MouseState.HOVER;
            labelSubTitleApps.Name = "labelSubTitleApps";
            labelSubTitleApps.Size = new Size(672, 19);
            labelSubTitleApps.TabIndex = 72;
            labelSubTitleApps.Text = "Listado de aplicaciones diseñadas para potenciar el trabajo con herramientas de modelado 3D.";
            // 
            // tabPageInicio
            // 
            tabPageInicio.BackColor = Color.White;
            tabPageInicio.Controls.Add(listBoxSoftware);
            tabPageInicio.Controls.Add(listBoxConfigs);
            tabPageInicio.Controls.Add(materialListBoxSoftware);
            tabPageInicio.Controls.Add(materialListBoxConfigs);
            tabPageInicio.Controls.Add(materialCard1);
            tabPageInicio.Controls.Add(pictureBox1);
            tabPageInicio.Controls.Add(materialCard7);
            tabPageInicio.Controls.Add(materialCard5);
            tabPageInicio.Controls.Add(materialLabel61);
            tabPageInicio.Controls.Add(materialLabel62);
            tabPageInicio.ImageKey = "round_assessment_white_24dp.png";
            tabPageInicio.Location = new Point(4, 31);
            tabPageInicio.Margin = new Padding(2);
            tabPageInicio.Name = "tabPageInicio";
            tabPageInicio.Padding = new Padding(2);
            tabPageInicio.Size = new Size(1095, 712);
            tabPageInicio.TabIndex = 10;
            tabPageInicio.Text = "Inicio";
            // 
            // listBoxSoftware
            // 
            listBoxSoftware.FormattingEnabled = true;
            listBoxSoftware.ItemHeight = 15;
            listBoxSoftware.Location = new Point(681, 227);
            listBoxSoftware.Margin = new Padding(2);
            listBoxSoftware.Name = "listBoxSoftware";
            listBoxSoftware.Size = new Size(205, 214);
            listBoxSoftware.TabIndex = 75;
            listBoxSoftware.Visible = false;
            // 
            // listBoxConfigs
            // 
            listBoxConfigs.FormattingEnabled = true;
            listBoxConfigs.ItemHeight = 15;
            listBoxConfigs.Location = new Point(517, 227);
            listBoxConfigs.Margin = new Padding(2);
            listBoxConfigs.Name = "listBoxConfigs";
            listBoxConfigs.Size = new Size(159, 214);
            listBoxConfigs.TabIndex = 74;
            listBoxConfigs.Visible = false;
            // 
            // materialListBoxSoftware
            // 
            materialListBoxSoftware.BackColor = Color.White;
            materialListBoxSoftware.BorderColor = Color.LightGray;
            materialListBoxSoftware.Depth = 0;
            materialListBoxSoftware.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialListBoxSoftware.Location = new Point(324, 227);
            materialListBoxSoftware.Margin = new Padding(2);
            materialListBoxSoftware.MouseState = MouseState.HOVER;
            materialListBoxSoftware.Name = "materialListBoxSoftware";
            materialListBoxSoftware.SelectedIndex = -1;
            materialListBoxSoftware.SelectedItem = null;
            materialListBoxSoftware.Size = new Size(158, 216);
            materialListBoxSoftware.TabIndex = 73;
            materialListBoxSoftware.Visible = false;
            // 
            // materialListBoxConfigs
            // 
            materialListBoxConfigs.BackColor = Color.White;
            materialListBoxConfigs.BorderColor = Color.LightGray;
            materialListBoxConfigs.Depth = 0;
            materialListBoxConfigs.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialListBoxConfigs.Location = new Point(194, 227);
            materialListBoxConfigs.Margin = new Padding(2);
            materialListBoxConfigs.MouseState = MouseState.HOVER;
            materialListBoxConfigs.Name = "materialListBoxConfigs";
            materialListBoxConfigs.SelectedIndex = -1;
            materialListBoxConfigs.SelectedItem = null;
            materialListBoxConfigs.Size = new Size(125, 216);
            materialListBoxConfigs.TabIndex = 72;
            materialListBoxConfigs.Visible = false;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(22, 227);
            materialCard1.Margin = new Padding(8);
            materialCard1.MouseState = MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(16);
            materialCard1.Size = new Size(161, 216);
            materialCard1.TabIndex = 71;
            materialCard1.Visible = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkinManager.fontType.H6;
            materialLabel1.HighEmphasis = true;
            materialLabel1.Location = new Point(20, 16);
            materialLabel1.Margin = new Padding(4, 0, 4, 0);
            materialLabel1.MouseState = MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(83, 24);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Feed List";
            materialLabel1.UseMnemonic = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo_horizontal_Definitivo_2__removebg_preview;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(517, 25);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(460, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 71;
            pictureBox1.TabStop = false;
            // 
            // materialCard7
            // 
            materialCard7.BackColor = Color.FromArgb(255, 255, 255);
            materialCard7.Controls.Add(materialButton32);
            materialCard7.Controls.Add(materialLabel67);
            materialCard7.Controls.Add(materialLabel68);
            materialCard7.Depth = 0;
            materialCard7.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard7.Location = new Point(517, 475);
            materialCard7.Margin = new Padding(8);
            materialCard7.MouseState = MouseState.HOVER;
            materialCard7.Name = "materialCard7";
            materialCard7.Padding = new Padding(16);
            materialCard7.Size = new Size(460, 216);
            materialCard7.TabIndex = 70;
            // 
            // materialButton32
            // 
            materialButton32.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            materialButton32.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton32.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton32.Depth = 0;
            materialButton32.HighEmphasis = true;
            materialButton32.Icon = null;
            materialButton32.Location = new Point(364, 155);
            materialButton32.Margin = new Padding(5, 7, 5, 7);
            materialButton32.MouseState = MouseState.HOVER;
            materialButton32.Name = "materialButton32";
            materialButton32.NoAccentTextColor = Color.Empty;
            materialButton32.Size = new Size(76, 36);
            materialButton32.TabIndex = 1;
            materialButton32.Text = "Visitar";
            materialButton32.Type = MaterialButton.MaterialButtonType.Text;
            materialButton32.UseAccentColor = false;
            materialButton32.UseVisualStyleBackColor = true;
            materialButton32.Click += materialButton32_Click;
            // 
            // materialLabel67
            // 
            materialLabel67.AutoSize = true;
            materialLabel67.Depth = 0;
            materialLabel67.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel67.FontType = MaterialSkinManager.fontType.H6;
            materialLabel67.HighEmphasis = true;
            materialLabel67.Location = new Point(20, 16);
            materialLabel67.Margin = new Padding(4, 0, 4, 0);
            materialLabel67.MouseState = MouseState.HOVER;
            materialLabel67.Name = "materialLabel67";
            materialLabel67.Size = new Size(171, 24);
            materialLabel67.TabIndex = 0;
            materialLabel67.Text = "Sistema de Tickets";
            // 
            // materialLabel68
            // 
            materialLabel68.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel68.Depth = 0;
            materialLabel68.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel68.Location = new Point(20, 60);
            materialLabel68.Margin = new Padding(4, 0, 4, 0);
            materialLabel68.MouseState = MouseState.HOVER;
            materialLabel68.Name = "materialLabel68";
            materialLabel68.Size = new Size(421, 84);
            materialLabel68.TabIndex = 2;
            materialLabel68.Text = "Tienes algun inconveniente con tu equipo?\r\nIngresa un ticket en nuestros sistemas para que podarmos apoyarte!";
            // 
            // materialCard5
            // 
            materialCard5.BackColor = Color.FromArgb(255, 255, 255);
            materialCard5.Controls.Add(materialButton30);
            materialCard5.Controls.Add(materialLabel63);
            materialCard5.Controls.Add(materialLabel64);
            materialCard5.Depth = 0;
            materialCard5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard5.Location = new Point(22, 475);
            materialCard5.Margin = new Padding(8);
            materialCard5.MouseState = MouseState.HOVER;
            materialCard5.Name = "materialCard5";
            materialCard5.Padding = new Padding(16);
            materialCard5.Size = new Size(460, 216);
            materialCard5.TabIndex = 70;
            // 
            // materialButton30
            // 
            materialButton30.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            materialButton30.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton30.Density = MaterialButton.MaterialButtonDensity.Default;
            materialButton30.Depth = 0;
            materialButton30.HighEmphasis = true;
            materialButton30.Icon = null;
            materialButton30.Location = new Point(364, 155);
            materialButton30.Margin = new Padding(5, 7, 5, 7);
            materialButton30.MouseState = MouseState.HOVER;
            materialButton30.Name = "materialButton30";
            materialButton30.NoAccentTextColor = Color.Empty;
            materialButton30.Size = new Size(76, 36);
            materialButton30.TabIndex = 1;
            materialButton30.Text = "Visitar";
            materialButton30.Type = MaterialButton.MaterialButtonType.Text;
            materialButton30.UseAccentColor = false;
            materialButton30.UseVisualStyleBackColor = true;
            materialButton30.Click += materialButton30_Click;
            // 
            // materialLabel63
            // 
            materialLabel63.AutoSize = true;
            materialLabel63.Depth = 0;
            materialLabel63.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel63.FontType = MaterialSkinManager.fontType.H6;
            materialLabel63.HighEmphasis = true;
            materialLabel63.Location = new Point(20, 16);
            materialLabel63.Margin = new Padding(4, 0, 4, 0);
            materialLabel63.MouseState = MouseState.HOVER;
            materialLabel63.Name = "materialLabel63";
            materialLabel63.Size = new Size(140, 24);
            materialLabel63.TabIndex = 0;
            materialLabel63.Text = "Pares y Alvarez";
            materialLabel63.UseMnemonic = false;
            // 
            // materialLabel64
            // 
            materialLabel64.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialLabel64.Depth = 0;
            materialLabel64.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel64.Location = new Point(20, 60);
            materialLabel64.Margin = new Padding(4, 0, 4, 0);
            materialLabel64.MouseState = MouseState.HOVER;
            materialLabel64.Name = "materialLabel64";
            materialLabel64.Size = new Size(421, 84);
            materialLabel64.TabIndex = 2;
            materialLabel64.Text = "Generamos soluciones industriales para la minería, energía, química, derivados de la madera, petróleo, gas, alimentos, manufactura e infraestructura, entregando soluciones y calidad a sus clientes.";
            // 
            // materialLabel61
            // 
            materialLabel61.AutoSize = true;
            materialLabel61.Depth = 0;
            materialLabel61.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel61.FontType = MaterialSkinManager.fontType.H3;
            materialLabel61.Location = new Point(21, 25);
            materialLabel61.Margin = new Padding(4, 0, 4, 0);
            materialLabel61.MouseState = MouseState.HOVER;
            materialLabel61.Name = "materialLabel61";
            materialLabel61.Size = new Size(116, 58);
            materialLabel61.TabIndex = 34;
            materialLabel61.Text = "Inicio";
            // 
            // materialLabel62
            // 
            materialLabel62.Depth = 0;
            materialLabel62.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel62.ForeColor = Color.FromArgb(180, 0, 0, 0);
            materialLabel62.Location = new Point(19, 114);
            materialLabel62.Margin = new Padding(4, 0, 4, 0);
            materialLabel62.MouseState = MouseState.HOVER;
            materialLabel62.Name = "materialLabel62";
            materialLabel62.Size = new Size(492, 104);
            materialLabel62.TabIndex = 33;
            materialLabel62.Text = "Bienvenido a la aplicacion PYA Launcher Apps.\r\n\r\nAplicación diseñada para mantener actualizados todos los softwares y plugins diseñados para ti.\r\n";
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPageInicio);
            materialTabControl1.Controls.Add(tabPageApps);
            materialTabControl1.Controls.Add(tabPagePerm);
            materialTabControl1.Controls.Add(tabPageLogs);
            materialTabControl1.Controls.Add(tabPageConfig);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = menuIconList;
            materialTabControl1.Location = new Point(4, 74);
            materialTabControl1.Margin = new Padding(4, 3, 4, 3);
            materialTabControl1.MouseState = MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1103, 747);
            materialTabControl1.TabIndex = 18;
            // 
            // tabPagePerm
            // 
            tabPagePerm.BackColor = Color.White;
            tabPagePerm.Controls.Add(btnSavePerm);
            tabPagePerm.Controls.Add(materialLabel2);
            tabPagePerm.Controls.Add(dataGridViewPermisos);
            tabPagePerm.Controls.Add(labelTitlePermisos);
            tabPagePerm.ImageKey = "round_bookmark_white_24dp.png";
            tabPagePerm.Location = new Point(4, 31);
            tabPagePerm.Margin = new Padding(4, 3, 4, 3);
            tabPagePerm.Name = "tabPagePerm";
            tabPagePerm.Size = new Size(1095, 712);
            tabPagePerm.TabIndex = 13;
            tabPagePerm.Text = "Permisos";
            // 
            // btnSavePerm
            // 
            btnSavePerm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSavePerm.Density = MaterialButton.MaterialButtonDensity.Default;
            btnSavePerm.Depth = 0;
            btnSavePerm.HighEmphasis = true;
            btnSavePerm.Icon = null;
            btnSavePerm.Location = new Point(397, 598);
            btnSavePerm.Margin = new Padding(5, 7, 5, 7);
            btnSavePerm.MouseState = MouseState.HOVER;
            btnSavePerm.Name = "btnSavePerm";
            btnSavePerm.NoAccentTextColor = Color.Empty;
            btnSavePerm.Size = new Size(88, 36);
            btnSavePerm.TabIndex = 77;
            btnSavePerm.Text = "Guardar";
            btnSavePerm.Type = MaterialButton.MaterialButtonType.Contained;
            btnSavePerm.UseAccentColor = false;
            btnSavePerm.UseVisualStyleBackColor = true;
            btnSavePerm.Click += btnSavePerm_Click;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.ForeColor = Color.FromArgb(180, 0, 0, 0);
            materialLabel2.Location = new Point(22, 104);
            materialLabel2.Margin = new Padding(2, 0, 2, 0);
            materialLabel2.MouseState = MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(544, 19);
            materialLabel2.TabIndex = 76;
            materialLabel2.Text = "Listado de usuarios con permisos para gestionar las aplicaciones y usuarios.";
            // 
            // dataGridViewPermisos
            // 
            dataGridViewPermisos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPermisos.Location = new Point(26, 158);
            dataGridViewPermisos.Margin = new Padding(4, 3, 4, 3);
            dataGridViewPermisos.Name = "dataGridViewPermisos";
            dataGridViewPermisos.Size = new Size(828, 395);
            dataGridViewPermisos.TabIndex = 75;
            // 
            // labelTitlePermisos
            // 
            labelTitlePermisos.AutoSize = true;
            labelTitlePermisos.Depth = 0;
            labelTitlePermisos.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelTitlePermisos.FontType = MaterialSkinManager.fontType.H3;
            labelTitlePermisos.Location = new Point(23, 17);
            labelTitlePermisos.Margin = new Padding(4, 0, 4, 0);
            labelTitlePermisos.MouseState = MouseState.HOVER;
            labelTitlePermisos.Name = "labelTitlePermisos";
            labelTitlePermisos.Size = new Size(203, 58);
            labelTitlePermisos.TabIndex = 73;
            labelTitlePermisos.Text = "Permisos";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1111, 824);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimumSize = new Size(350, 231);
            Name = "MainForm";
            Padding = new Padding(4, 74, 4, 3);
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PYA Launcher Apps";
            Resize += MainForm_Resize;
            tabPageConfig.ResumeLayout(false);
            tabPageConfig.PerformLayout();
            tabPageLogs.ResumeLayout(false);
            tabPageLogs.PerformLayout();
            tabPageApps.ResumeLayout(false);
            tabPageApps.PerformLayout();
            tabPageInicio.ResumeLayout(false);
            tabPageInicio.PerformLayout();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            materialCard7.ResumeLayout(false);
            materialCard7.PerformLayout();
            materialCard5.ResumeLayout(false);
            materialCard5.PerformLayout();
            materialTabControl1.ResumeLayout(false);
            tabPagePerm.ResumeLayout(false);
            tabPagePerm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPermisos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ImageList menuIconList;
        private MaterialCheckbox materialCheckbox1;
        private NotifyIcon notifyIcon1;
        private TabPage tabPageConfig;
        private MaterialButton materialButton2;
        private MaterialLabel materialLabel24;
        private MaterialButton materialButton7;
        private MaterialLabel materialLabel9;
        private TabPage tabPageLogs;
        private MaterialButton buttonRefreshHistory;
        private MaterialListBox materialListBoxLogs;
        private TabPage tabPageApps;
        private FlowLayoutPanel flowLayoutPanel2;
        private MaterialLabel labelTitleApps;
        private MaterialLabel labelSubTitleApps;
        private TabPage tabPageInicio;
        private ListBox listBoxSoftware;
        private ListBox listBoxConfigs;
        private MaterialListBox materialListBoxSoftware;
        private MaterialListBox materialListBoxConfigs;
        private MaterialCard materialCard1;
        private MaterialLabel materialLabel1;
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
        private MaterialButton buttonAppsRefresh;
        private MaterialButton materialButtonAddSoftware;
        private MaterialLabel labelTitleHistory;
        private MaterialLabel labelSubTitleHistory;
        private TabPage tabPagePerm;
        private MaterialLabel labelTitlePermisos;
        private DataGridView dataGridViewPermisos;
        private MaterialLabel materialLabel2;
        private MaterialButton btnSavePerm;
    }
}
