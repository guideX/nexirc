'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmChangeConnection
    Private Sub frmChangeConnection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim n As Integer = lStatus.ActiveIndex, mbox As MsgBoxResult
            If lStatus.Connected(n) = True Then
                If lIRC.iSettings.sPrompts = True Then
                    mbox = MsgBox("You are currently connected on this status Window. In order to change connection settings on a status window, you must first disconnect. Would you like to disconnect now?", MsgBoxStyle.YesNo)
                    If mbox = MsgBoxResult.Yes Then
                        lStatus.CloseStatusConnection(n, True)
                    Else
                        Me.Close()
                    End If
                End If
            End If
            Me.Icon = mdiMain.Icon
            cboNetwork.Items.Add("(Select)")
            FillComboWithNetworks(cboNetwork, False)
            cboNetwork.SelectedIndex = 0
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmChangeConnection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            If cboServer.SelectedItem.ToString = "(Select)" Then Exit Sub
            lServers.sIndex = FindServerIndex(cboServer.SelectedItem.ToString)
            If chkNewStatusWindow.Checked = True Then lStatus.Create(lIRC, lServers)
            Application.DoEvents()
            Dim i As Integer = lStatus.ActiveIndex
            If i = 0 Then i = 1
            If chkConnectImmediatly.Checked = True Then
                Select Case lStatus.Connected(i)
                    Case True
                        If lIRC.iSettings.sPrompts = True Then
                            If MsgBox("You are already connected on this status window, would you like to disconnect?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                                lStatus.CloseStatusConnection(i, True)
                                lStatus.SetStatus(i)
                                lStatus.Connect(lServers.sIndex)
                            End If
                        Else
                            lStatus.CloseStatusConnection(i, True)
                            lStatus.SetStatus(i)
                            lStatus.Connect(lServers.sIndex)
                        End If
                    Case False
                        lStatus.Connect(lServers.sIndex)
                End Select
            Else
                lStatus.SetStatus(i)
            End If
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
        End Try
    End Sub

    Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged
        Try
            cboServer.Items.Clear()
            cboServer.Items.Add("(Select)")
            FillComboWithServers(cboServer, FindNetworkIndex(cboNetwork.SelectedItem.ToString), False)
            cboServer.SelectedIndex = 0
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cboNetwork_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetwork.SelectedIndexChanged")
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click")
        End Try
    End Sub
End Class