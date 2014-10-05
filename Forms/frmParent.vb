'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.nexIRC.MainWindow
Public Class frmParent
    Private WithEvents lMainWindowUI As New clsMainWindowUI
    Private Sub mnuAdmin_Click(sender As Object, e As System.EventArgs) Handles mnuAdmin.Click
        lMainWindowUI.cmd_Admin_Click()
    End Sub
    Private Sub mnuAway_Click(sender As Object, e As System.EventArgs) Handles mnuAway.Click
        lMainWindowUI.cmd_Away_Click()
    End Sub
    Private Sub mnuBack_Click(sender As Object, e As System.EventArgs) Handles mnuBack.Click
        lMainWindowUI.cmd_Back_Click()
    End Sub
    Private Sub mnuClearHistory_Click(sender As Object, e As System.EventArgs) Handles mnuClearHistory.Click
        lMainWindowUI.cmd_ClearHistory_Click(mnuRecentServerItem1, mnuRecentServerItem2, mnuRecentServerItem3)
    End Sub
    Private Sub mnuDie_Click(sender As Object, e As System.EventArgs) Handles mnuIRCOperatorDie.Click
        lMainWindowUI.cmd_Die()
    End Sub
    Private Sub mnuError_Click(sender As Object, e As System.EventArgs) Handles mnuError.Click
        lMainWindowUI.cmd_Error()
    End Sub
    Private Sub mnuKick_Click(sender As Object, e As System.EventArgs) Handles mnuKick.Click
        lMainWindowUI.cmd_Kick()
    End Sub
    Private Sub mnuHelp_Click(sender As Object, e As System.EventArgs) Handles mnuHelp.Click
        lMainWindowUI.cmd_Help()
    End Sub
    Private Sub mnuInfo_Click(sender As Object, e As System.EventArgs) Handles mnuInfo.Click
        lMainWindowUI.cmd_Info()
    End Sub
    Private Sub mnuInvite_Click(sender As Object, e As System.EventArgs) Handles mnuInvite.Click
        lMainWindowUI.cmd_Invite()
    End Sub
    Private Sub mnuIRCOperatorCNotice_Click(sender As Object, e As System.EventArgs) Handles mnuIRCOperatorCNotice.Click
        lMainWindowUI.cmd_CNotice()
    End Sub
    Private Sub mnuIRCOperatorConnect_Click(sender As Object, e As System.EventArgs) Handles mnuIRCOperatorConnect.Click
        lMainWindowUI.cmd_IRCOperatorConnect()
    End Sub
End Class