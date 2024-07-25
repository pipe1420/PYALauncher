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
            this.materialCheckedListBox1 = new MaterialSkin.Controls.MaterialCheckedListBox();
            this.SuspendLayout();
            // 
            // listBoxConfigs
            // 
            this.listBoxConfigs.FormattingEnabled = true;
            this.listBoxConfigs.ItemHeight = 16;
            this.listBoxConfigs.Location = new System.Drawing.Point(114, 120);
            this.listBoxConfigs.Name = "listBoxConfigs";
            this.listBoxConfigs.Size = new System.Drawing.Size(149, 164);
            this.listBoxConfigs.TabIndex = 0;
            // 
            // listBoxSoftware
            // 
            this.listBoxSoftware.FormattingEnabled = true;
            this.listBoxSoftware.ItemHeight = 16;
            this.listBoxSoftware.Location = new System.Drawing.Point(114, 324);
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
            this.materialListBoxConfigs.Location = new System.Drawing.Point(417, 120);
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
            this.materialListBoxSoftware.Location = new System.Drawing.Point(417, 324);
            this.materialListBoxSoftware.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialListBoxSoftware.Name = "materialListBoxSoftware";
            this.materialListBoxSoftware.SelectedIndex = -1;
            this.materialListBoxSoftware.SelectedItem = null;
            this.materialListBoxSoftware.Size = new System.Drawing.Size(170, 164);
            this.materialListBoxSoftware.TabIndex = 3;
            // 
            // materialCheckedListBox1
            // 
            this.materialCheckedListBox1.AutoScroll = true;
            this.materialCheckedListBox1.BackColor = System.Drawing.SystemColors.Control;
            this.materialCheckedListBox1.Depth = 0;
            this.materialCheckedListBox1.Location = new System.Drawing.Point(650, 140);
            this.materialCheckedListBox1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCheckedListBox1.Name = "materialCheckedListBox1";
            this.materialCheckedListBox1.Size = new System.Drawing.Size(281, 374);
            this.materialCheckedListBox1.Striped = false;
            this.materialCheckedListBox1.StripeDarkColor = System.Drawing.Color.Empty;
            this.materialCheckedListBox1.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 676);
            this.Controls.Add(this.materialCheckedListBox1);
            this.Controls.Add(this.materialListBoxSoftware);
            this.Controls.Add(this.materialListBoxConfigs);
            this.Controls.Add(this.listBoxSoftware);
            this.Controls.Add(this.listBoxConfigs);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConfigs;
        private System.Windows.Forms.ListBox listBoxSoftware;
        private MaterialSkin.Controls.MaterialListBox materialListBoxConfigs;
        private MaterialSkin.Controls.MaterialListBox materialListBoxSoftware;
        private MaterialSkin.Controls.MaterialCheckedListBox materialCheckedListBox1;
    }
}