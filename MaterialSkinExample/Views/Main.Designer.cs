namespace PYALauncherApps.Views
{
    partial class Main
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
            this.listBoxConfigs = new System.Windows.Forms.ListBox();
            this.listBoxSoftware = new System.Windows.Forms.ListBox();
            this.materialListBoxConfigs = new MaterialSkin.Controls.MaterialListBox();
            this.materialListBoxSoftware = new MaterialSkin.Controls.MaterialListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialTabControl2 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1.SuspendLayout();
            this.materialTabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxConfigs
            // 
            this.listBoxConfigs.FormattingEnabled = true;
            this.listBoxConfigs.ItemHeight = 16;
            this.listBoxConfigs.Location = new System.Drawing.Point(41, 43);
            this.listBoxConfigs.Name = "listBoxConfigs";
            this.listBoxConfigs.Size = new System.Drawing.Size(149, 164);
            this.listBoxConfigs.TabIndex = 0;
            // 
            // listBoxSoftware
            // 
            this.listBoxSoftware.FormattingEnabled = true;
            this.listBoxSoftware.ItemHeight = 16;
            this.listBoxSoftware.Location = new System.Drawing.Point(41, 247);
            this.listBoxSoftware.Name = "listBoxSoftware";
            this.listBoxSoftware.Size = new System.Drawing.Size(149, 164);
            this.listBoxSoftware.TabIndex = 1;
            // 
            // materialListBoxConfigs
            // 
            this.materialListBoxConfigs.BackColor = System.Drawing.Color.White;
            this.materialListBoxConfigs.BorderColor = System.Drawing.Color.LightGray;
            this.materialListBoxConfigs.Depth = 0;
            this.materialListBoxConfigs.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialListBoxConfigs.Location = new System.Drawing.Point(344, 43);
            this.materialListBoxConfigs.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialListBoxConfigs.Name = "materialListBoxConfigs";
            this.materialListBoxConfigs.SelectedIndex = -1;
            this.materialListBoxConfigs.SelectedItem = null;
            this.materialListBoxConfigs.Size = new System.Drawing.Size(170, 164);
            this.materialListBoxConfigs.TabIndex = 2;
            // 
            // materialListBoxSoftware
            // 
            this.materialListBoxSoftware.BackColor = System.Drawing.Color.White;
            this.materialListBoxSoftware.BorderColor = System.Drawing.Color.LightGray;
            this.materialListBoxSoftware.Depth = 0;
            this.materialListBoxSoftware.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialListBoxSoftware.Location = new System.Drawing.Point(344, 247);
            this.materialListBoxSoftware.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialListBoxSoftware.Name = "materialListBoxSoftware";
            this.materialListBoxSoftware.SelectedIndex = -1;
            this.materialListBoxSoftware.SelectedItem = null;
            this.materialListBoxSoftware.Size = new System.Drawing.Size(170, 164);
            this.materialListBoxSoftware.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.listBoxConfigs);
            this.tabPage1.Controls.Add(this.materialListBoxSoftware);
            this.tabPage1.Controls.Add(this.listBoxSoftware);
            this.tabPage1.Controls.Add(this.materialListBoxConfigs);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(1522, 888);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pestaña 1";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // materialTabControl2
            // 
            this.materialTabControl2.Controls.Add(this.tabPage1);
            this.materialTabControl2.Controls.Add(this.tabPage2);
            this.materialTabControl2.Controls.Add(this.tabPage3);
            this.materialTabControl2.Depth = 0;
            this.materialTabControl2.Location = new System.Drawing.Point(13, 74);
            this.materialTabControl2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl2.Multiline = true;
            this.materialTabControl2.Name = "materialTabControl2";
            this.materialTabControl2.SelectedIndex = 0;
            this.materialTabControl2.Size = new System.Drawing.Size(1530, 917);
            this.materialTabControl2.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1522, 888);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage3";
            this.tabPage2.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1522, 888);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "tabPage4";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 997);
            this.Controls.Add(this.materialTabControl2);
            this.Name = "Main";
            this.Text = "Main";
            this.tabPage1.ResumeLayout(false);
            this.materialTabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConfigs;
        private System.Windows.Forms.ListBox listBoxSoftware;
        private MaterialSkin.Controls.MaterialListBox materialListBoxConfigs;
        private MaterialSkin.Controls.MaterialListBox materialListBoxSoftware;
        private System.Windows.Forms.TabPage tabPage1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}