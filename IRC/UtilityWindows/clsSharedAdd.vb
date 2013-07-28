'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Public Class clsSharedAdd
    Public Enum eSharedAddType
        sAddNetwork = 1
    End Enum
    Public lSharedAddType As eSharedAddType
    Private Sub OK_Button(_DescriptionTextBox As RadTextBox, _Form As Form)
        'Try
        Select Case lSharedAddType
            Case eSharedAddType.sAddNetwork
                If Len(_DescriptionTextBox.Text) <> 0 Then
                    AddNetwork(_DescriptionTextBox.Text)
                    frmCustomize.ClearServers()
                    _Form.Close()
                Else
                    If lIRC.iSettings.sPrompts = True Then MsgBox("Please type a network description", MsgBoxStyle.Exclamation)
                End If
        End Select
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub OK_Button()")
        'End Try
    End Sub
    Public Sub cmdCancel_Click(_Form As Form)
        'Try
        _Form.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        'End Try
    End Sub
    Public Sub Form_Load(_Form As Form, _DescriptionTextBox As RadTextBox)
        'Try
        lWinVisible.wAddNetwork = True
        _DescriptionTextBox.Focus()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub frmAddNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        'End Try
    End Sub
    Public Sub txtNetworkDescription_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, _Form As Form, _DescriptionTextBox As RadTextBox)
        'Try
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            OK_Button(_DescriptionTextBox, _Form)
        End If
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub txtNetworkDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNetworkDescription.KeyPress")
        'End Try
    End Sub
    Public Sub mnuExit_Click(_Form As Form)
        'Try
        _Form.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub
    Public Sub cmdOK_Click(_DescriptionTextBox As RadTextBox, _Form As Form)
        OK_Button(_DescriptionTextBox, _Form)
    End Sub
    Public Sub ExitToolStripMenuItem_Click(_Form As Form)
        'Try
        _Form.Close()
        'Catch ex As Exception
        'ProcessError(ex.Message, "Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        'End Try
    End Sub
    Public Sub ServerListToolStripMenuItem_Click()
        mdiMain.BrowseURL("http://www.irchelp.org/irchelp/networks/servers/index.html")
    End Sub
End Class