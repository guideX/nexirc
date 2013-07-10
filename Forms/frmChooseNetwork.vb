Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows
Public Class frmChooseNetwork
    Public WithEvents lChooseNetwork As New clsChooseNetwork
    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        lChooseNetwork.cmdCancel_Click(Me)
    End Sub
    Private Sub frmChooseNetwork_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lChooseNetwork.Form_Load(cboNetworks)
    End Sub
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        lChooseNetwork.cmdOK_Click(Me, cboNetworks.Text)
    End Sub
End Class
