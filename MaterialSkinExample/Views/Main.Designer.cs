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
            this.SuspendLayout();
            // 
            // listBoxConfigs
            // 
            this.listBoxConfigs.FormattingEnabled = true;
            this.listBoxConfigs.ItemHeight = 16;
            this.listBoxConfigs.Location = new System.Drawing.Point(105, 50);
            this.listBoxConfigs.Name = "listBoxConfigs";
            this.listBoxConfigs.Size = new System.Drawing.Size(292, 356);
            this.listBoxConfigs.TabIndex = 0;
            // 
            // listBoxSoftware
            // 
            this.listBoxSoftware.FormattingEnabled = true;
            this.listBoxSoftware.ItemHeight = 16;
            this.listBoxSoftware.Location = new System.Drawing.Point(462, 58);
            this.listBoxSoftware.Name = "listBoxSoftware";
            this.listBoxSoftware.Size = new System.Drawing.Size(292, 340);
            this.listBoxSoftware.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxSoftware);
            this.Controls.Add(this.listBoxConfigs);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxConfigs;
        private System.Windows.Forms.ListBox listBoxSoftware;
    }
}