'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Public Class clsSharedAdd
    Public Enum eSharedAddType
        sAddNetwork = 1
        sAddNickName = 2
    End Enum
    Private lSharedAddType As eSharedAddType
    Public Event ChangeCaption(_Data As String)
    Public Event CloseForm()
    Public Event FocusTextBox()
    Public Property SharedAddType() As eSharedAddType
        Get
            Try
                Return lSharedAddType
            Catch ex As Exception
                'Throw ex 'ProcessError(ex.Message, "Public Property SharedAddType() As eSharedAddType")
                Return Nothing
            End Try
        End Get
        Set(_SharedAddType As eSharedAddType)
            Try
                lSharedAddType = _SharedAddType
                Select Case _SharedAddType
                    Case eSharedAddType.sAddNetwork
                        RaiseEvent ChangeCaption("nexIRC - Add Network")
                    Case eSharedAddType.sAddNickName
                        RaiseEvent ChangeCaption("nexIRC - Add Nickname")
                End Select
            Catch ex As Exception
                'Throw ex 'ProcessError(ex.Message, "Public Property SharedAddType() As eSharedAddType")
            End Try
        End Set
    End Property
    Private Sub OK_Button(_Value As String)
        Try
            Select Case lSharedAddType
                Case eSharedAddType.sAddNickName
                    If (Not _Value.Length = 0) Then
                        lSettings.AddNickName(_Value)
                        RaiseEvent CloseForm()
                    End If
                Case eSharedAddType.sAddNetwork
                    If _Value.Length <> 0 Then
                        lSettings.AddNetwork(_Value)
                        frmCustomize.ClearServers()
                        RaiseEvent CloseForm()
                    Else
                        If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Please type a network description", MsgBoxStyle.Exclamation)
                    End If
            End Select
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub OK_Button()")
        End Try
    End Sub
    Public Sub cmdCancel_Click()
        Try
            RaiseEvent CloseForm()
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub
    Public Sub Form_Load()
        Try
            lSettings.lWinVisible.wAddNetwork = True
            RaiseEvent FocusTextBox()
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub frmAddNetwork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
    Public Sub txtNetworkDescription_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, _Form As Form, _DescriptionTextBox As RadTextBox)
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                e.Handled = True
                OK_Button(_DescriptionTextBox.Text)
            End If
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub txtNetworkDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNetworkDescription.KeyPress")
        End Try
    End Sub
    Public Sub mnuExit_Click()
        Try
            RaiseEvent CloseForm()
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        End Try
    End Sub
    Public Sub cmdOK_Click(_Value As String, _Form As Form)
        OK_Button(_Value)
    End Sub
    Public Sub ExitToolStripMenuItem_Click()
        Try
            RaiseEvent CloseForm()
        Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)")
        End Try
    End Sub
    Public Sub ServerListToolStripMenuItem_Click()
        'mdiMain.BrowseURL("http://www.irchelp.org/irchelp/networks/servers/index.html")
    End Sub
End Class