namespace PYALauncherApps.Views
{
    partial class AddEditForm
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
            this.labelTitle = new MaterialSkin.Controls.MaterialLabel();
            this.labelSubTitle = new MaterialSkin.Controls.MaterialLabel();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnDelete = new MaterialSkin.Controls.MaterialButton();
            this.cbxActions = new MaterialSkin.Controls.MaterialComboBox();
            this.cbxModality = new MaterialSkin.Controls.MaterialComboBox();
            this.dataGridViewMachines = new System.Windows.Forms.DataGridView();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.multiLineDescrip = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.multiLineURLMSI = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.multiLinePathDll = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.txtVersion = new MaterialSkin.Controls.MaterialTextBox();
            this.txtProcessVerificaApp = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachines)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Depth = 0;
            this.labelTitle.Font = new System.Drawing.Font("Roboto", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            this.labelTitle.Location = new System.Drawing.Point(21, 74);
            this.labelTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(308, 41);
            this.labelTitle.TabIndex = 35;
            this.labelTitle.Text = "Agregar / Editar App";
            // 
            // labelSubTitle
            // 
            this.labelSubTitle.Depth = 0;
            this.labelSubTitle.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelSubTitle.Location = new System.Drawing.Point(25, 126);
            this.labelSubTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSubTitle.Name = "labelSubTitle";
            this.labelSubTitle.Size = new System.Drawing.Size(619, 28);
            this.labelSubTitle.TabIndex = 36;
            this.labelSubTitle.Text = "Permite agregar o editar propiedades de aplicación, funcionamiento y despliegue.";
            // 
            // txtName
            // 
            this.txtName.AnimateReadOnly = false;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.Hint = "Nombre";
            this.txtName.LeadingIcon = null;
            this.txtName.Location = new System.Drawing.Point(28, 176);
            this.txtName.MaxLength = 50;
            this.txtName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(550, 50);
            this.txtName.TabIndex = 38;
            this.txtName.Text = "";
            this.txtName.TrailingIcon = null;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(306, 799);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(158, 36);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Guardar";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDelete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDelete.Depth = 0;
            this.btnDelete.HighEmphasis = true;
            this.btnDelete.Icon = null;
            this.btnDelete.Location = new System.Drawing.Point(496, 74);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDelete.Size = new System.Drawing.Size(82, 36);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDelete.UseAccentColor = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbxActions
            // 
            this.cbxActions.AutoResize = false;
            this.cbxActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.cbxActions.Depth = 0;
            this.cbxActions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxActions.DropDownHeight = 174;
            this.cbxActions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxActions.DropDownWidth = 121;
            this.cbxActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbxActions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxActions.FormattingEnabled = true;
            this.cbxActions.Hint = "Acciones";
            this.cbxActions.IntegralHeight = false;
            this.cbxActions.ItemHeight = 43;
            this.cbxActions.Items.AddRange(new object[] {
            "Instalación",
            "Actualización",
            "Desinstalación"});
            this.cbxActions.Location = new System.Drawing.Point(28, 541);
            this.cbxActions.MaxDropDownItems = 4;
            this.cbxActions.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxActions.Name = "cbxActions";
            this.cbxActions.Size = new System.Drawing.Size(272, 49);
            this.cbxActions.StartIndex = 0;
            this.cbxActions.TabIndex = 46;
            // 
            // cbxModality
            // 
            this.cbxModality.AutoResize = false;
            this.cbxModality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbxModality.Depth = 0;
            this.cbxModality.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxModality.DropDownHeight = 174;
            this.cbxModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModality.DropDownWidth = 121;
            this.cbxModality.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbxModality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbxModality.FormattingEnabled = true;
            this.cbxModality.Hint = "Modalidad";
            this.cbxModality.IntegralHeight = false;
            this.cbxModality.ItemHeight = 43;
            this.cbxModality.Items.AddRange(new object[] {
            "Manual",
            "Automática",
            "Forzada"});
            this.cbxModality.Location = new System.Drawing.Point(306, 541);
            this.cbxModality.MaxDropDownItems = 4;
            this.cbxModality.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxModality.Name = "cbxModality";
            this.cbxModality.Size = new System.Drawing.Size(272, 49);
            this.cbxModality.StartIndex = 0;
            this.cbxModality.TabIndex = 47;
            // 
            // dataGridViewMachines
            // 
            this.dataGridViewMachines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMachines.Location = new System.Drawing.Point(28, 644);
            this.dataGridViewMachines.Name = "dataGridViewMachines";
            this.dataGridViewMachines.Size = new System.Drawing.Size(550, 146);
            this.dataGridViewMachines.TabIndex = 52;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(28, 613);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(550, 28);
            this.materialLabel1.TabIndex = 53;
            this.materialLabel1.Text = "Listado de equipos";
            // 
            // multiLineDescrip
            // 
            this.multiLineDescrip.AnimateReadOnly = false;
            this.multiLineDescrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.multiLineDescrip.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.multiLineDescrip.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.multiLineDescrip.Depth = 0;
            this.multiLineDescrip.HideSelection = true;
            this.multiLineDescrip.Hint = "Descripción";
            this.multiLineDescrip.Location = new System.Drawing.Point(28, 232);
            this.multiLineDescrip.MaxLength = 32767;
            this.multiLineDescrip.MouseState = MaterialSkin.MouseState.OUT;
            this.multiLineDescrip.Name = "multiLineDescrip";
            this.multiLineDescrip.PasswordChar = '\0';
            this.multiLineDescrip.ReadOnly = false;
            this.multiLineDescrip.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.multiLineDescrip.SelectedText = "";
            this.multiLineDescrip.SelectionLength = 0;
            this.multiLineDescrip.SelectionStart = 0;
            this.multiLineDescrip.ShortcutsEnabled = true;
            this.multiLineDescrip.Size = new System.Drawing.Size(550, 88);
            this.multiLineDescrip.TabIndex = 54;
            this.multiLineDescrip.TabStop = false;
            this.multiLineDescrip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.multiLineDescrip.UseSystemPasswordChar = false;
            // 
            // multiLineURLMSI
            // 
            this.multiLineURLMSI.AnimateReadOnly = false;
            this.multiLineURLMSI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.multiLineURLMSI.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.multiLineURLMSI.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.multiLineURLMSI.Depth = 0;
            this.multiLineURLMSI.HideSelection = true;
            this.multiLineURLMSI.Hint = "URL MSI";
            this.multiLineURLMSI.Location = new System.Drawing.Point(28, 435);
            this.multiLineURLMSI.MaxLength = 32767;
            this.multiLineURLMSI.MouseState = MaterialSkin.MouseState.OUT;
            this.multiLineURLMSI.Name = "multiLineURLMSI";
            this.multiLineURLMSI.PasswordChar = '\0';
            this.multiLineURLMSI.ReadOnly = false;
            this.multiLineURLMSI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.multiLineURLMSI.SelectedText = "";
            this.multiLineURLMSI.SelectionLength = 0;
            this.multiLineURLMSI.SelectionStart = 0;
            this.multiLineURLMSI.ShortcutsEnabled = true;
            this.multiLineURLMSI.Size = new System.Drawing.Size(550, 100);
            this.multiLineURLMSI.TabIndex = 55;
            this.multiLineURLMSI.TabStop = false;
            this.multiLineURLMSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.multiLineURLMSI.UseSystemPasswordChar = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(142, 799);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(158, 36);
            this.btnCancel.TabIndex = 56;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCancel.UseAccentColor = false;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // multiLinePathDll
            // 
            this.multiLinePathDll.AnimateReadOnly = false;
            this.multiLinePathDll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.multiLinePathDll.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.multiLinePathDll.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.multiLinePathDll.Depth = 0;
            this.multiLinePathDll.HideSelection = true;
            this.multiLinePathDll.Hint = "Ubicación DLL";
            this.multiLinePathDll.Location = new System.Drawing.Point(28, 382);
            this.multiLinePathDll.MaxLength = 32767;
            this.multiLinePathDll.MouseState = MaterialSkin.MouseState.OUT;
            this.multiLinePathDll.Name = "multiLinePathDll";
            this.multiLinePathDll.PasswordChar = '\0';
            this.multiLinePathDll.ReadOnly = false;
            this.multiLinePathDll.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.multiLinePathDll.SelectedText = "";
            this.multiLinePathDll.SelectionLength = 0;
            this.multiLinePathDll.SelectionStart = 0;
            this.multiLinePathDll.ShortcutsEnabled = true;
            this.multiLinePathDll.Size = new System.Drawing.Size(550, 47);
            this.multiLinePathDll.TabIndex = 57;
            this.multiLinePathDll.TabStop = false;
            this.multiLinePathDll.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.multiLinePathDll.UseSystemPasswordChar = false;
            // 
            // txtVersion
            // 
            this.txtVersion.AnimateReadOnly = false;
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVersion.Depth = 0;
            this.txtVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtVersion.Hint = "Versión";
            this.txtVersion.LeadingIcon = null;
            this.txtVersion.Location = new System.Drawing.Point(386, 326);
            this.txtVersion.MaxLength = 50;
            this.txtVersion.MouseState = MaterialSkin.MouseState.OUT;
            this.txtVersion.Multiline = false;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(192, 50);
            this.txtVersion.TabIndex = 58;
            this.txtVersion.Text = "";
            this.txtVersion.TrailingIcon = null;
            // 
            // txtProcessVerificaApp
            // 
            this.txtProcessVerificaApp.AnimateReadOnly = false;
            this.txtProcessVerificaApp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProcessVerificaApp.Depth = 0;
            this.txtProcessVerificaApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtProcessVerificaApp.Hint = "Proceso asociado(acad, revit)";
            this.txtProcessVerificaApp.LeadingIcon = null;
            this.txtProcessVerificaApp.Location = new System.Drawing.Point(28, 326);
            this.txtProcessVerificaApp.MaxLength = 50;
            this.txtProcessVerificaApp.MouseState = MaterialSkin.MouseState.OUT;
            this.txtProcessVerificaApp.Multiline = false;
            this.txtProcessVerificaApp.Name = "txtProcessVerificaApp";
            this.txtProcessVerificaApp.Size = new System.Drawing.Size(352, 50);
            this.txtProcessVerificaApp.TabIndex = 59;
            this.txtProcessVerificaApp.Text = "";
            this.txtProcessVerificaApp.TrailingIcon = null;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 861);
            this.Controls.Add(this.txtProcessVerificaApp);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.multiLinePathDll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.multiLineURLMSI);
            this.Controls.Add(this.multiLineDescrip);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dataGridViewMachines);
            this.Controls.Add(this.cbxModality);
            this.Controls.Add(this.cbxActions);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelSubTitle);
            this.Controls.Add(this.labelTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar / Editar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMachines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel labelTitle;
        private MaterialSkin.Controls.MaterialLabel labelSubTitle;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnDelete;
        private MaterialSkin.Controls.MaterialComboBox cbxActions;
        private MaterialSkin.Controls.MaterialComboBox cbxModality;
        private System.Windows.Forms.DataGridView dataGridViewMachines;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 multiLineDescrip;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 multiLineURLMSI;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 multiLinePathDll;
        private MaterialSkin.Controls.MaterialTextBox txtVersion;
        private MaterialSkin.Controls.MaterialTextBox txtProcessVerificaApp;
    }
}