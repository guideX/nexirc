Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Imports nexIRC.Models.Network
Imports nexIRC.Business.Controllers

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
            Return lSharedAddType
        End Get
        Set(_SharedAddType As eSharedAddType)
            lSharedAddType = _SharedAddType
            Select Case _SharedAddType
                Case eSharedAddType.sAddNetwork
                    RaiseEvent ChangeCaption("nexIRC - Add Network")
                Case eSharedAddType.sAddNickName
                    RaiseEvent ChangeCaption("nexIRC - Add Nickname")
            End Select
        End Set
    End Property
    Private Sub OK_Button(_Value As String)
        Select Case lSharedAddType
            Case eSharedAddType.sAddNickName
                If (Not _Value.Length = 0) Then
                    lSettings.AddNickName(_Value)
                    frmCustomize.cboMyNickNames.Items.Add(_Value)
                    RaiseEvent CloseForm()
                End If
            Case eSharedAddType.sAddNetwork
                If _Value.Length <> 0 Then
                    If (Not String.IsNullOrEmpty(_Value)) Then
                        Dim n = New NetworkModel
                        n.Name = _Value
                        Using c As New ConnectionController(lSettings.lINI.iNetworks, lSettings.lINI.iServers)
                            If (c.CreateNetwork(n, Modules.lSettings.lNetworks.Networks)) Then
                                frmCustomize.ClearServers()
                            End If
                        End Using
                        RaiseEvent CloseForm()
                    End If
                Else
                    If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Please type a network description", MsgBoxStyle.Exclamation)
                End If
        End Select
    End Sub
    Public Sub cmdCancel_Click()
        RaiseEvent CloseForm()
    End Sub
    Public Sub Form_Load()
        lSettings.lWinVisible.wAddNetwork = True
        RaiseEvent FocusTextBox()
    End Sub
    Public Sub txtNetworkDescription_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, _Form As Form, _DescriptionTextBox As RadTextBox)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            e.Handled = True
            OK_Button(_DescriptionTextBox.Text)
        End If
    End Sub
    Public Sub mnuExit_Click()
        RaiseEvent CloseForm()
    End Sub
    Public Sub cmdOK_Click(_Value As String, _Form As Form)
        OK_Button(_Value)
    End Sub
    Public Sub ExitToolStripMenuItem_Click()
        RaiseEvent CloseForm()
    End Sub
    Public Sub ServerListToolStripMenuItem_Click()
        'mdiMain.BrowseURL("http://www.irchelp.org/irchelp/networks/servers/index.html")
    End Sub
End Class