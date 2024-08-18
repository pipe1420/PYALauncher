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
            this.txtDescrip = new MaterialSkin.Controls.MaterialTextBox();
            this.cbxActions = new MaterialSkin.Controls.MaterialComboBox();
            this.cbxModality = new MaterialSkin.Controls.MaterialComboBox();
            this.txtInstaller = new MaterialSkin.Controls.MaterialTextBox();
            this.dataGridViewMachines = new System.Windows.Forms.DataGridView();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
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
            this.btnSave.Location = new System.Drawing.Point(420, 706);
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
            this.btnDelete.Location = new System.Drawing.Point(28, 706);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDelete.Size = new System.Drawing.Size(158, 36);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDelete.UseAccentColor = false;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDescrip
            // 
            this.txtDescrip.AnimateReadOnly = false;
            this.txtDescrip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescrip.Depth = 0;
            this.txtDescrip.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDescrip.Hint = "Descripción";
            this.txtDescrip.LeadingIcon = null;
            this.txtDescrip.Location = new System.Drawing.Point(28, 232);
            this.txtDescrip.MaxLength = 50;
            this.txtDescrip.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDescrip.Multiline = false;
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(550, 50);
            this.txtDescrip.TabIndex = 42;
            this.txtDescrip.Text = "";
            this.txtDescrip.TrailingIcon = null;
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
            this.cbxActions.Location = new System.Drawing.Point(28, 344);
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
            this.cbxModality.Location = new System.Drawing.Point(306, 344);
            this.cbxModality.MaxDropDownItems = 4;
            this.cbxModality.MouseState = MaterialSkin.MouseState.OUT;
            this.cbxModality.Name = "cbxModality";
            this.cbxModality.Size = new System.Drawing.Size(272, 49);
            this.cbxModality.StartIndex = 0;
            this.cbxModality.TabIndex = 47;
            // 
            // txtInstaller
            // 
            this.txtInstaller.AnimateReadOnly = false;
            this.txtInstaller.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInstaller.Depth = 0;
            this.txtInstaller.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtInstaller.Hint = "URL MSI";
            this.txtInstaller.LeadingIcon = null;
            this.txtInstaller.Location = new System.Drawing.Point(28, 288);
            this.txtInstaller.MaxLength = 50;
            this.txtInstaller.MouseState = MaterialSkin.MouseState.OUT;
            this.txtInstaller.Multiline = false;
            this.txtInstaller.Name = "txtInstaller";
            this.txtInstaller.Size = new System.Drawing.Size(550, 50);
            this.txtInstaller.TabIndex = 50;
            this.txtInstaller.Text = "";
            this.txtInstaller.TrailingIcon = null;
            // 
            // dataGridViewMachines
            // 
            this.dataGridViewMachines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMachines.Location = new System.Drawing.Point(28, 438);
            this.dataGridViewMachines.Name = "dataGridViewMachines";
            this.dataGridViewMachines.Size = new System.Drawing.Size(550, 227);
            this.dataGridViewMachines.TabIndex = 52;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(28, 407);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(550, 28);
            this.materialLabel1.TabIndex = 53;
            this.materialLabel1.Text = "Listado de equipos";
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 776);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.dataGridViewMachines);
            this.Controls.Add(this.txtInstaller);
            this.Controls.Add(this.cbxModality);
            this.Controls.Add(this.cbxActions);
            this.Controls.Add(this.txtDescrip);
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
        private MaterialSkin.Controls.MaterialTextBox txtDescrip;
        private MaterialSkin.Controls.MaterialComboBox cbxActions;
        private MaterialSkin.Controls.MaterialComboBox cbxModality;
        private MaterialSkin.Controls.MaterialTextBox txtInstaller;
        private System.Windows.Forms.DataGridView dataGridViewMachines;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}