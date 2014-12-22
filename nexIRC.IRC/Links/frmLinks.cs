using nexIRC.IRC.Structures;
namespace nexIRC.IRC.Links {
    public partial class frmLinks : Telerik.WinControls.UI.RadForm {
        public ServerLinks lServerLinksUI = new ServerLinks();
        private void frmLinks_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) {
            lServerLinksUI.frmServerLinks_FormClosing(lvwLinks);
        }
        private void frmLinks_Load(System.Object sender, System.EventArgs e) {
            lServerLinksUI.Form_Load(this, cboNetworks, lvwLinks);
        }
        private void cmdOK_Click(System.Object sender, System.EventArgs e) {
            lServerLinksUI.cmdOK_Click(this, lvwLinks, cboNetworks);
        }
        private void radListView1_SelectedItemChanged(System.Object sender, System.EventArgs e) {
        }
    }
}