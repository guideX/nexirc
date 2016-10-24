namespace nexIRC.Test {
    partial class frmNetworks {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cmdClearNetworks = new System.Windows.Forms.Button();
            this.cmdAddNetwork = new System.Windows.Forms.Button();
            this.cmdSaveNetworks = new System.Windows.Forms.Button();
            this.cmdLoadNetworks = new System.Windows.Forms.Button();
            this.cmdIndex = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdClearNetworks
            // 
            this.cmdClearNetworks.Location = new System.Drawing.Point(86, 162);
            this.cmdClearNetworks.Name = "cmdClearNetworks";
            this.cmdClearNetworks.Size = new System.Drawing.Size(113, 23);
            this.cmdClearNetworks.TabIndex = 7;
            this.cmdClearNetworks.Text = "Clear Networks";
            this.cmdClearNetworks.UseVisualStyleBackColor = true;
            this.cmdClearNetworks.Click += new System.EventHandler(this.cmdClearNetworks_Click);
            // 
            // cmdAddNetwork
            // 
            this.cmdAddNetwork.Location = new System.Drawing.Point(86, 133);
            this.cmdAddNetwork.Name = "cmdAddNetwork";
            this.cmdAddNetwork.Size = new System.Drawing.Size(113, 23);
            this.cmdAddNetwork.TabIndex = 6;
            this.cmdAddNetwork.Text = "Add Network";
            this.cmdAddNetwork.UseVisualStyleBackColor = true;
            this.cmdAddNetwork.Click += new System.EventHandler(this.cmdAddNetwork_Click);
            // 
            // cmdSaveNetworks
            // 
            this.cmdSaveNetworks.Location = new System.Drawing.Point(86, 104);
            this.cmdSaveNetworks.Name = "cmdSaveNetworks";
            this.cmdSaveNetworks.Size = new System.Drawing.Size(113, 23);
            this.cmdSaveNetworks.TabIndex = 5;
            this.cmdSaveNetworks.Text = "Save Networks";
            this.cmdSaveNetworks.UseVisualStyleBackColor = true;
            this.cmdSaveNetworks.Click += new System.EventHandler(this.cmdSaveNetworks_Click);
            // 
            // cmdLoadNetworks
            // 
            this.cmdLoadNetworks.Location = new System.Drawing.Point(86, 75);
            this.cmdLoadNetworks.Name = "cmdLoadNetworks";
            this.cmdLoadNetworks.Size = new System.Drawing.Size(113, 23);
            this.cmdLoadNetworks.TabIndex = 4;
            this.cmdLoadNetworks.Text = "Load Networks";
            this.cmdLoadNetworks.UseVisualStyleBackColor = true;
            this.cmdLoadNetworks.Click += new System.EventHandler(this.cmdLoadNetworks_Click);
            // 
            // cmdIndex
            // 
            this.cmdIndex.Location = new System.Drawing.Point(86, 191);
            this.cmdIndex.Name = "cmdIndex";
            this.cmdIndex.Size = new System.Drawing.Size(113, 23);
            this.cmdIndex.TabIndex = 8;
            this.cmdIndex.Text = "Index";
            this.cmdIndex.UseVisualStyleBackColor = true;
            this.cmdIndex.Click += new System.EventHandler(this.cmdIndex_Click);
            // 
            // frmNetworks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 446);
            this.Controls.Add(this.cmdIndex);
            this.Controls.Add(this.cmdClearNetworks);
            this.Controls.Add(this.cmdAddNetwork);
            this.Controls.Add(this.cmdSaveNetworks);
            this.Controls.Add(this.cmdLoadNetworks);
            this.Name = "frmNetworks";
            this.Text = "frmNetworks";
            this.Load += new System.EventHandler(this.frmNetworks_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdClearNetworks;
        private System.Windows.Forms.Button cmdAddNetwork;
        private System.Windows.Forms.Button cmdSaveNetworks;
        private System.Windows.Forms.Button cmdLoadNetworks;
        private System.Windows.Forms.Button cmdIndex;
    }
}