'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules

Public Class BotSettings
    Private _email As String
    Private _password As String

    Public Property Email() As String
        Get
            Try
                Return _email
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Get
        Set(value As String)
            Try
                _email = value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Property Password() As String
        Get
            Try
                Return _password
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Get
        Set(value As String)
            Try
                _password = value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property
End Class

Public Class NickBot
    Private _statusId As Integer

    Public Sub New(statusId As Integer)
        Try
            _statusId = statusId
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function BotNick() As String
        Dim networkId As Integer
        Try
            networkId = lStatus.NetworkIndex(StatusId)
            Select Case lSettings.lNetworks.nNetwork(networkId).nDescription.ToLower().Trim()
                Case "freenode"
                    Return "Nickserv"
                Case Else
                    Return ""
            End Select
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Public Property StatusId() As Integer
        Get
            Try
                Return _statusId
            Catch ex As Exception
                Throw ex
                Return Nothing
            End Try
        End Get
        Set(value As Integer)
            Try
                _statusId = value
            Catch ex As Exception
                Throw ex
            End Try
        End Set
    End Property

    Public Sub Login()
        Dim settings As BotSettings
        Try
            settings = New BotSettings()
            If (lSettings_Services.lNickServ.nLoginOnConnect) Then
                Select Case lSettings.lNetworks.nNetwork(lStatus.NetworkIndex(StatusId)).nDescription.ToLower().Trim()
                    Case "freenode"
                        If (lSettings_Services.lNickServ.nShowOnConnect = False) Then
                            If (Not String.IsNullOrEmpty(lSettings_Services.lNickServ.nLoginPassword)) And (Not String.IsNullOrEmpty(lSettings_Services.lNickServ.nLoginNickname)) Then
                                settings.Email = lSettings_Services.lNickServ.nLoginNickname
                                settings.Password = lSettings_Services.lNickServ.nLoginPassword
                                Login(settings)
                            End If
                        Else
                            LoginForm()
                        End If
                End Select
            ElseIf lSettings_Services.lNickServ.nShowOnConnect Then
                LoginForm()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub LoginForm()
        Try
            Select Case lSettings.lNetworks.nNetwork(lStatus.NetworkIndex(StatusId)).nDescription.ToLower().Trim()
                Case "freenode"
                    Dim f As New frmNickServLogin
                    f.SetStatusIndex(StatusId)
                    f.Show()
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Login(settings As BotSettings)
        Try
            Select Case lSettings.lNetworks.nNetwork(lStatus.NetworkIndex(StatusId)).nDescription.ToLower().Trim()
                Case "freenode"
                    If (Not String.IsNullOrEmpty(settings.Password) And Not String.IsNullOrEmpty(settings.Email)) Then
                        If (Not _statusId = 0) Then
                            With lStatus.GetObject(_statusId)
                                lStatus.SendSocket(_statusId, "PRIVMSG Nickserv :IDENTIFY " & settings.Email & " " & settings.Password)
                                lStatus.AddText(">Nickserv< identify", _statusId)
                            End With
                        End If
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Register(settings As BotSettings)
        Try
            Select Case lSettings.lNetworks.nNetwork(lStatus.NetworkIndex(StatusId)).nDescription.ToLower().Trim()
                Case "freenode"
                    If (Not String.IsNullOrEmpty(settings.Password) And Not String.IsNullOrEmpty(settings.Email)) Then
                        If (Not _statusId = 0) Then
                            With lStatus.GetObject(_statusId)
                                lStatus.SendSocket(_statusId, "PRIVMSG Nickserv :REGISTER " & settings.Password & " " & settings.Email)
                                lStatus.SendSocket(_statusId, "PRIVMSG Nickserv :set hide email on")
                                'lStatus.SendSocket(_statusId, "PRIVMSG " & _botNick & " :set email " & email)
                                lStatus.AddText(">Nickserv< register", _statusId)
                            End With
                        End If
                    End If
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Ghost(user As String)
        Try
            Select Case lSettings.lNetworks.nNetwork(lStatus.NetworkIndex(StatusId)).nDescription.ToLower().Trim()
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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class