Option Explicit On
Option Strict On
Imports nexIRC.Models.Bot
Imports nexIRC.Modules

Public Class NickBot
    Private _statusId As Integer
    Private _settings As NickBotModel

    Public Sub New(statusId As Integer)
        _statusId = statusId
        _settings = New NickBotModel(statusId)
    End Sub

    Public Property StatusId() As Integer
        Get
            Return _statusId
        End Get
        Set(value As Integer)
            _statusId = value
        End Set
    End Property

    Public Sub Login(newSettings As NickBotModel)
        If (lSettings_Services.lNickServ.nLoginOnConnect) Then
            Select Case lSettings.lNetworks.Networks(lStatus.NetworkIndex(StatusId)).Name.ToLower().Trim()
                Case "freenode"
                    If (lSettings_Services.lNickServ.nShowOnConnect = False) Then
                        If (Not String.IsNullOrEmpty(lSettings_Services.lNickServ.nLoginPassword)) And (Not String.IsNullOrEmpty(lSettings_Services.lNickServ.nLoginNickname)) Then
                            _settings.Email = lSettings_Services.lNickServ.nLoginNickname
                            _settings.Password = lSettings_Services.lNickServ.nLoginPassword
                            'Login()
                        End If
                    Else
                        LoginForm()
                    End If
            End Select
        ElseIf lSettings_Services.lNickServ.nShowOnConnect Then
            LoginForm()
        End If
    End Sub

    Public Sub Login()
        If (lSettings_Services.lNickServ.nLoginOnConnect) Then
            Select Case lSettings.lNetworks.Networks(lStatus.NetworkIndex(StatusId)).Name.ToLower().Trim()
                Case "freenode"
                    If (Not String.IsNullOrEmpty(_settings.Password) And Not String.IsNullOrEmpty(_settings.Email)) Then
                        If (Not _statusId = 0) Then
                            With lStatus.GetObject(_statusId)
                                lStatus.SendSocket(_statusId, "PRIVMSG Nickserv :IDENTIFY " & _settings.Email & " " & _settings.Password)
                                lStatus.AddText(">Nickserv< identify", _statusId)
                            End With
                        End If
                    End If
            End Select
        End If
    End Sub
    Public Sub LoginForm()
        Select Case lSettings.lNetworks.Networks(lStatus.NetworkIndex(StatusId)).Name.ToLower().Trim()
            Case "freenode"
                Dim f As New frmNickServLogin
                f.SetStatusIndex(StatusId)
                f.Show()
        End Select
    End Sub


    Public Sub Register()
        Select Case lSettings.lNetworks.Networks(lStatus.NetworkIndex(StatusId)).Name.ToLower().Trim()
            Case "freenode"
                If (Not String.IsNullOrEmpty(_settings.Password) And Not String.IsNullOrEmpty(_settings.Email)) Then
                    If (Not _statusId = 0) Then
                        With lStatus.GetObject(_statusId)
                            lStatus.SendSocket(_statusId, "PRIVMSG Nickserv :REGISTER " & _settings.Password & " " & _settings.Email)
                            lStatus.SendSocket(_statusId, "PRIVMSG Nickserv :set hide email on")
                            'lStatus.SendSocket(_statusId, "PRIVMSG " & _botNick & " :set email " & email)
                            lStatus.AddText(">Nickserv< register", _statusId)
                        End With
                    End If
                End If
        End Select
    End Sub

    Public Sub Ghost(user As String)
        Select Case lSettings.lNetworks.Networks(lStatus.NetworkIndex(StatusId)).Name.ToLower().Trim()
            Case "freenode"
                If (Not String.IsNullOrEmpty(user)) Then
                    If (Not _statusId = 0) Then
                        With lStatus.GetObject(_statusId)
                            lStatus.SendSocket(_statusId, "PRIVMSG Nickserv :GHOST " & user)
                            lStatus.AddText(">Nickserv< ghost", _statusId)
                        End With
                    End If
                End If
        End Select
    End Sub
End Class