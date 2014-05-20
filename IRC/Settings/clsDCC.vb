'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Classes.IO
Imports nexIRC.Modules
Imports System.Net
Namespace nexIRC.IRC.Settings
    Public Class clsDCC
        Public Enum eDCCFileExistsAction
            dPrompt = 1
            dOverwrite = 2
            dIgnore = 3
        End Enum
        Public Enum eDCCPrompt
            ePrompt = 1
            eAcceptAll = 2
            eIgnore = 3
        End Enum
        Public Enum gDCCIgnoreType
            dNicknames = 1
            dHostnames = 2
            dFileTypes = 3
        End Enum
        Public Structure gDCCIgnoreItem
            Public dType As gDCCIgnoreType
            Public dData As String
        End Structure
        Public Structure gDCCIgnoreList
            Public dCount As Integer
            Public dItem() As gDCCIgnoreItem
        End Structure
        Public Structure gDCC
            Public dFileExistsAction As eDCCFileExistsAction
            Public dChatPrompt As eDCCPrompt
            Public dSendPrompt As eDCCPrompt
            Public dUseIpAddress As Boolean
            Public dCustomIpAddress As String
            Public dIgnorelist As gDCCIgnoreList
            Public dSendPort As String
            Public dRandomizePort As Boolean
            Public dBufferSize As Long
            Public dAutoIgnore As Boolean
            Public dAutoCloseDialogs As Boolean
            Public dDownloadDirectory As String
            Public dPopupDownloadManager As Boolean
        End Structure

        Public lDCC As gDCC

        Public Sub LoadDCCSettings()
            Dim i As Integer, n As Integer
            With lDCC
                ReDim .dIgnorelist.dItem(lSettings.lArraySizes.aDCCIgnore)
                .dFileExistsAction = CType(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "FileExistsAction", "1"), eDCCFileExistsAction)
                n = Convert.ToInt32(Trim(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "ChatPrompt", "1")))
                If n = 1 Then
                    .dChatPrompt = eDCCPrompt.ePrompt
                ElseIf n = 2 Then
                    .dChatPrompt = eDCCPrompt.eAcceptAll
                ElseIf n = 3 Then
                    .dChatPrompt = eDCCPrompt.eIgnore
                End If
                n = Convert.ToInt32(Trim(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "SendPrompt", "1")))
                If n = 1 Then
                    .dSendPrompt = eDCCPrompt.ePrompt
                ElseIf n = 2 Then
                    .dSendPrompt = eDCCPrompt.eAcceptAll
                ElseIf n = 3 Then
                    .dSendPrompt = eDCCPrompt.eIgnore
                End If
                .dPopupDownloadManager = Convert.ToBoolean(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "PopupDownloadManager", "False"))
                .dDownloadDirectory = Files.ReadINI(lSettings.lINI.iDCC, "Settings", "DownloadDirectory", "")
                If String.IsNullOrEmpty(.dDownloadDirectory) = True Then .dDownloadDirectory = Application.StartupPath & "\"
                .dDownloadDirectory = Replace(.dDownloadDirectory, "\\", "")
                .dBufferSize = Convert.ToInt64(Trim(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "BufferSize", "1024")))
                .dUseIpAddress = Convert.ToBoolean(Trim(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "UseIpAddress", "False")))
                .dCustomIpAddress = Files.ReadINI(lSettings.lINI.iDCC, "Settings", "CustomIpAddress", "")
                If Len(.dCustomIpAddress) = 0 Then .dCustomIpAddress = ReturnOutsideIPAddress()
                .dIgnorelist.dCount = Convert.ToInt32(Trim(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", "0")))
                .dSendPort = Files.ReadINI(lSettings.lINI.iDCC, "Settings", "SendPort", "1024")
                .dRandomizePort = Convert.ToBoolean(Trim(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "RandomizePort", "True")))
                .dIgnorelist.dCount = Convert.ToInt32(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString)))
                .dAutoIgnore = Convert.ToBoolean(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "AutoIgnore", "True"))
                .dAutoCloseDialogs = Convert.ToBoolean(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "AutoCloseDialogs", "False"))
            End With
            For i = 1 To lDCC.dIgnorelist.dCount
                With lDCC.dIgnorelist.dItem(i)
                    .dData = Files.ReadINI(lSettings.lINI.iDCC, Trim(i.ToString), "Data", "")
                    .dType = CType(Files.ReadINI(lSettings.lINI.iDCC, Trim(i.ToString), "Type", "0"), gDCCIgnoreType)
                    Select Case .dType
                        Case gDCCIgnoreType.dNicknames
                            .dType = gDCCIgnoreType.dNicknames
                        Case gDCCIgnoreType.dHostnames
                            .dType = gDCCIgnoreType.dHostnames
                        Case gDCCIgnoreType.dFileTypes
                            .dType = gDCCIgnoreType.dFileTypes
                    End Select
                End With
            Next i
        End Sub

        Public Function ReturnOutsideIPAddress() As String
            Try
                Dim client As New WebClient, baseurl As String = "http://checkip.dyndns.org:8245/", data As System.IO.Stream, reader As System.IO.StreamReader, s As String
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR1.0.3705;)")
                data = client.OpenRead(baseurl)
                reader = New System.IO.StreamReader(data)
                s = reader.ReadToEnd
                data.Close()
                reader.Close()
                s = s.Replace("<html><head><title>Current IP Check</title></head><body>", "").Replace("</body></html>", "").ToString()
                s = s.Replace("Current IP Address: ", "")
                Return s
            Catch ex As Exception
                'Throw ex
                Return Nothing
            End Try
        End Function

        Public Sub SaveDCCSettings()
            Try
                Dim i As Integer
                With lDCC
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "PopupDownloadManager", .dPopupDownloadManager.ToString())
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "DownloadDirectory", .dDownloadDirectory)
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "FileExistsAction", Trim(CType(.dFileExistsAction, Integer).ToString))
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString))
                    For i = 1 To lDCC.dIgnorelist.dCount
                        Files.WriteINI(lSettings.lINI.iDCC, Trim(i.ToString), "Data", .dIgnorelist.dItem(i).dData)
                        Files.WriteINI(lSettings.lINI.iDCC, Trim(i.ToString), "Type", Trim(CType(.dIgnorelist.dItem(i).dType, Integer).ToString))
                    Next i
                    If .dChatPrompt = eDCCPrompt.ePrompt Then
                        Files.WriteINI(lSettings.lINI.iDCC, "Settings", "ChatPrompt", "1")
                    ElseIf .dChatPrompt = eDCCPrompt.eAcceptAll Then
                        Files.WriteINI(lSettings.lINI.iDCC, "Settings", "ChatPrompt", "2")
                    ElseIf .dChatPrompt = eDCCPrompt.eIgnore Then
                        Files.WriteINI(lSettings.lINI.iDCC, "Settings", "ChatPrompt", "3")
                    End If
                    If .dSendPrompt = eDCCPrompt.ePrompt Then
                        Files.WriteINI(lSettings.lINI.iDCC, "Settings", "SendPrompt", "1")
                    ElseIf .dSendPrompt = eDCCPrompt.eAcceptAll Then
                        Files.WriteINI(lSettings.lINI.iDCC, "Settings", "SendPrompt", "2")
                    ElseIf .dSendPrompt = eDCCPrompt.eIgnore Then
                        Files.WriteINI(lSettings.lINI.iDCC, "Settings", "SendPrompt", "3")
                    End If
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "UseIpAddress", Trim(.dUseIpAddress.ToString))
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "CustomIpAddress", Trim(.dCustomIpAddress))
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString))
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "SendPort", Trim(.dSendPort.ToString))
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "RandomizePort", (Trim(.dRandomizePort.ToString)))
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "BufferSize", (Trim(.dBufferSize.ToString)))
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "AutoIgnore", Trim(.dAutoIgnore.ToString))
                    Files.WriteINI(lSettings.lINI.iDCC, "Settings", "AutoCloseDialogs", Trim(.dAutoCloseDialogs.ToString))
                End With
            Catch ex As Exception
                'Throw ex
            End Try
        End Sub
    End Class
End Namespace