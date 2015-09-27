'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports Telerik.WinControls.UI
Imports nexIRC.Modules
Imports nexIRC.Business.Enums

Public Class clsSharedAdd
    Public Enum eSharedAddType
        sAddNetwork = 1
        sAddNickName = 2
        sCommandError = 3
        sInfo = 4
        sKick = 5
        sKill = 6
    End Enum
    Public Event ChangeCaption(ByVal _Data As String)
    Public Event ChangeMoreInformationLabel1(ByVal data As String)
    Public Event ChangeMoreInformationLabel2(ByVal data As String)
    Public Event CloseForm()
    Public Event FocusTextBox()
    Public StatusIndex As Integer
    Private lSharedAddType As eSharedAddType
    Public Property SharedAddType() As eSharedAddType
        Get
            Try
                Return lSharedAddType
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Get
        Set(ByVal _SharedAddType As eSharedAddType)
            Try
                lSharedAddType = _SharedAddType
                Select Case _SharedAddType
                    Case eSharedAddType.sAddNetwork
                        RaiseEvent ChangeCaption("nexIRC - Add Network")
                    Case eSharedAddType.sAddNickName
                        RaiseEvent ChangeCaption("nexIRC - Add Nickname")
                    Case eSharedAddType.sCommandError
                        RaiseEvent ChangeCaption("nexIRC - Command Error")
                        RaiseEvent ChangeMoreInformationLabel1("This command is for use by servers to report errors to other servers.")
                        RaiseEvent ChangeMoreInformationLabel2("It is also used before terminating client connections.")
                    Case eSharedAddType.sInfo
                        RaiseEvent ChangeCaption("nexIRC - Info")
                        RaiseEvent ChangeMoreInformationLabel1("Get info about <target> server, or current server if <target> omitted.")
                        RaiseEvent ChangeMoreInformationLabel2("Info returned includes version, when compiled, patch level, when started, other info.")
                    Case eSharedAddType.sKick
                        RaiseEvent ChangeCaption("nexIRC - Kick")
                        RaiseEvent ChangeMoreInformationLabel1("Forcibly removes <client> from <channel>")
                        RaiseEvent ChangeMoreInformationLabel2("This command may only be issued by channel operators.")
                    Case eSharedAddType.sKill
                        RaiseEvent ChangeCaption("nexIRC - Kill")
                        RaiseEvent ChangeMoreInformationLabel1("Forcibly removes <client> from the network.")
                        RaiseEvent ChangeMoreInformationLabel2("This command may only be issued by IRC operators.")
                End Select
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property
    Private Sub OK_Button(ByVal _Value As String)
        Try
            Select Case lSharedAddType
                Case eSharedAddType.sAddNickName
                    If (Not String.IsNullOrEmpty(_Value)) Then
                        'lSettings.AddNickName(_Value)
                        frmCustomize.cboMyNickNames.Items.Add(_Value)
                        RaiseEvent CloseForm()
                    End If
                Case eSharedAddType.sAddNetwork
                    If (Not String.IsNullOrEmpty(_Value)) Then
                        Dim network = New IrcSettings.NetworkData()
                        network.Description = _Value
                        Modules.IrcSettings.IrcNetworks.Add(network)
                        frmCustomize.ClearServers()
                        RaiseEvent CloseForm()
                    Else
                        If lSettings.lIRC.iSettings.sPrompts = True Then MsgBox("Please type a network description", MsgBoxStyle.Exclamation)
                    End If
                Case eSharedAddType.sCommandError
                    If (Not String.IsNullOrEmpty(_Value)) Then
                        Modules.lStrings.ProcessReplaceCommand(StatusIndex, IrcCommandTypes.cERROR, _Value)
                    End If
                Case eSharedAddType.sInfo
                    Modules.lStrings.ProcessReplaceCommand(StatusIndex, IrcCommandTypes.cINFO, _Value)
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub cmdCancel_Click()
        RaiseEvent CloseForm()
    End Sub
    Public Sub Form_Load()
        Try
            lSettings.lWinVisible.wAddNetwork = True
            RaiseEvent FocusTextBox()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub txtNetworkDescription_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal _Form As Form, ByVal _DescriptionTextBox As RadTextBox)
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
                e.Handled = True
                OK_Button(_DescriptionTextBox.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub mnuExit_Click()
        RaiseEvent CloseForm()
    End Sub
    Public Sub cmdOK_Click(ByVal _Value As String, ByVal _Form As Form)
        OK_Button(_Value)
    End Sub
    Public Sub ExitToolStripMenuItem_Click()
        RaiseEvent CloseForm()
    End Sub
End Class