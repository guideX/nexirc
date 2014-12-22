namespace nexIRC.IRC.Links
{
    partial class frmLinks
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
            this.cboNetworks = new Telerik.WinControls.UI.RadDropDownList();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.cmdAdd = new Telerik.WinControls.UI.RadButton();
            this.cmdCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboNetworks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // cboNetworks
            // 
            this.cboNetworks.DropDownAnimationEnabled = true;
            this.cboNetworks.Location = new System.Drawing.Point(12, 12);
            this.cboNetworks.Name = "cboNetworks";
            this.cboNetworks.ShowImageInEditorArea = true;
            this.cboNetworks.Size = new System.Drawing.Size(344, 20);
            this.cboNetworks.TabIndex = 0;
            // 
            // radListView1
            // 
            this.radListView1.GroupItemSize = new System.Drawing.Size(200, 20);
            this.radListView1.ItemSize = new System.Drawing.Size(200, 20);
            this.radListView1.Location = new System.Drawing.Point(12, 38);
            this.radListView1.Name = "radListView1";
            this.radListView1.Size = new System.Drawing.Size(344, 164);
            this.radListView1.TabIndex = 1;
            this.radListView1.Text = "radListView1";
            this.radListView1.SelectedItemChanged += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListView1_SelectedItemChanged);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(190, 210);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(80, 24);
            this.cmdAdd.TabIndex = 2;
            this.cmdAdd.Text = "Add";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(276, 210);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(80, 24);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            // 
            // frmLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 241);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.radListView1);
            this.Controls.Add(this.cboNetworks);
            this.Name = "frmLinks";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmLinks";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.frmLinks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboNetworks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadDropDownList cboNetworks;
        private Telerik.WinControls.UI.RadListView radListView1;
        private Telerik.WinControls.UI.RadButton cmdAdd;
        private Telerik.WinControls.UI.RadButton cmdCancel;
    }
}
