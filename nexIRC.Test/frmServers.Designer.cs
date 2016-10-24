namespace nexIRC.Test {
    partial class frmServers {
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
            this.cmdIndex = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdCreate = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdIndex
            // 
            this.cmdIndex.Location = new System.Drawing.Point(86, 177);
            this.cmdIndex.Name = "cmdIndex";
            this.cmdIndex.Size = new System.Drawing.Size(113, 23);
            this.cmdIndex.TabIndex = 13;
            this.cmdIndex.Text = "Index";
            this.cmdIndex.UseVisualStyleBackColor = true;
            this.cmdIndex.Click += new System.EventHandler(this.cmdIndex_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(86, 148);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(113, 23);
            this.cmdClear.TabIndex = 12;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdCreate
            // 
            this.cmdCreate.Location = new System.Drawing.Point(86, 119);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(113, 23);
            this.cmdCreate.TabIndex = 11;
            this.cmdCreate.Text = "Create";
            this.cmdCreate.UseVisualStyleBackColor = true;
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(86, 90);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(113, 23);
            this.cmdSave.TabIndex = 10;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(86, 61);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(113, 23);
            this.cmdLoad.TabIndex = 9;
            this.cmdLoad.Text = "Load";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // frmServers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cmdIndex);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdCreate);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdLoad);
            this.Name = "frmServers";
            this.Text = "frmServers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdIndex;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdCreate;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdLoad;
    }
}