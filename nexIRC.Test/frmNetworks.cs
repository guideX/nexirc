using nexIRC.Business.Controllers;
using nexIRC.Models.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nexIRC.Test {
    public partial class frmNetworks : Form {
        public frmNetworks() {
            InitializeComponent();
        }

        private void cmdLoadNetworks_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                var obj = c.ReadAllNetworks();
                var blah = "";
            }
        }

        private void frmNetworks_Load(object sender, EventArgs e) {

        }

        private void cmdIndex_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                MessageBox.Show(c.ReadNetworkIndex().ToString());
            }
        }

        private void cmdSaveNetworks_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                var obj = c.ReadAllNetworks();
                MessageBox.Show(c.SaveNetworks(obj).ToString());
            }
        }

        private void cmdAddNetwork_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                var obj = new NetworkModel();
                var objs = c.ReadAllNetworks();
                obj.Name = "DALNET";
                MessageBox.Show(c.CreateNetwork(obj, objs).ToString());
            }
        }

        private void cmdClearNetworks_Click(object sender, EventArgs e) {
            using (var c = new ConnectionController(@"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\networks.ini", @"C:\dev\team-nexgen\nexirc\nexIRC\nexIRC.Client\bin\Debug\data\config\servers.ini")) {
                c.ClearNetworks();
            }
        }
    }
}
