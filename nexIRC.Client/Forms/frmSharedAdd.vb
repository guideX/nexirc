'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Client.nexIRC.Client.IRC.Status.UtilityWindows
Public Class frmSharedAdd
    Public WithEvents lSharedAddUI As New clsSharedAdd
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        lSharedAddUI.cmdCancel_Click()
    End Sub
    Private Sub frmAddNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lSharedAddUI.Form_Load()
    End Sub
    Private Sub txtNetworkDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        lSharedAddUI.txtNetworkDescription_KeyPress(e, Me, txtDescription)
    End Sub
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lSharedAddUI.mnuExit_Click()
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        lSharedAddUI.cmdOK_Click(txtDescription.Text, Me)
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lSharedAddUI.ExitToolStripMenuItem_Click()
    End Sub
    Private Sub lSharedAddUI_ChangeCaption(_Data As String) Handles lSharedAddUI.ChangeCaption
        Me.Text = _Data
    End Sub
    Private Sub lSharedAddUI_ChangeMoreInformationLabel1(data As String) Handles lSharedAddUI.ChangeMoreInformationLabel1
        lblMoreInformation1.Text = data : lblMoreInformation1.Visible = True
    End Sub
    Private Sub lSharedAddUI_ChangeMoreInformationLabel2(data As String) Handles lSharedAddUI.ChangeMoreInformationLabel2
        lblMoreInformation2.Text = data : lblMoreInformation2.Visible = True
    End Sub
    Private Sub lSharedAddUI_CloseForm() Handles lSharedAddUI.CloseForm
        Me.Close()
    End Sub
    Private Sub lSharedAddUI_FocusTextBox() Handles lSharedAddUI.FocusTextBox
        txtDescription.Focus()
    End Sub
End Class