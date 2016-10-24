using nexIRC.Business.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nexIRC.Test {
    public partial class frmServers : Form {
        public frmServers() {
            InitializeComponent();
        }

        private void cmdLoad_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                var obj = c.ReadAllServers();
                var blah = "";
            }
        }

        private void cmdSave_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                var obj = c.ReadAllServers();
                c.SaveServers(obj);
            }
        }

        private void cmdCreate_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                var obj = c.ReadAllServers();
                c.SaveServers(obj);
            }
        }

        private void cmdClear_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                c.ClearServers();
            }
        }

        private void cmdIndex_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                MessageBox.Show(c.ReadServerIndex().ToString());
            }
        }
    }
}
