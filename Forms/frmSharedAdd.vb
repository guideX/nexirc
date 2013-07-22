'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmSharedAdd
    Public Enum eSharedAddType
        sAddNetwork = 1
    End Enum
    Public lSharedAddType As eSharedAddType
    Private Sub OK_Button()
        'Try
        Select Case lSharedAddType
            Case eSharedAddType.sAddNetwork
                If Len(txtDescription.Text) <> 0 Then
                    AddNetwork(txtDescription.Text)
                    frmCustomize.ClearServers()
                    Me.Close()
                Else
                    If lIRC.iSettings.sPrompts = True Then MsgBox("Please type a network description", MsgBoxStyle.Exclamation)
                End If
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub OK_Button()")
        'End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub
    Private Sub frmAddNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        lWinVisible.wAddNetwork = True
        txtDescription.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmAddNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
    Private Sub txtNetworkDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        'Try
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            OK_Button()
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtNetworkDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNetworkDescription.KeyPress")
        'End Try
    End Sub
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        OK_Button()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        Me.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub
    Private Sub ServerListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'On Error Resume Next
        mdiMain.BrowseURL("http://www.irchelp.org/irchelp/networks/servers/index.html")
        'If Err.Number <> 0 Then ProcessError(ex.Message, "Private Sub mnuServerLists_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuServerLists.Click")
    End Sub
End Class