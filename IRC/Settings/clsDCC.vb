'nexIRC 3.0.31
'05-30-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports System.Net
Imports nexIRC.Business.Helpers

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
                .dFileExistsAction = CType(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "FileExistsAction", "1"), eDCCFileExistsAction)
                n = Convert.ToInt32(Trim(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "ChatPrompt", "1")))
                If n = 1 Then
                    .dChatPrompt = eDCCPrompt.ePrompt
                ElseIf n = 2 Then
                    .dChatPrompt = eDCCPrompt.eAcceptAll
                ElseIf n = 3 Then
                    .dChatPrompt = eDCCPrompt.eIgnore
                End If
                n = Convert.ToInt32(Trim(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "SendPrompt", "1")))
                If n = 1 Then
                    .dSendPrompt = eDCCPrompt.ePrompt
                ElseIf n = 2 Then
                    .dSendPrompt = eDCCPrompt.eAcceptAll
                ElseIf n = 3 Then
                    .dSendPrompt = eDCCPrompt.eIgnore
                End If
                .dPopupDownloadManager = Convert.ToBoolean(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "PopupDownloadManager", "False"))
                .dDownloadDirectory = NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "DownloadDirectory", "")
                If String.IsNullOrEmpty(.dDownloadDirectory) = True Then .dDownloadDirectory = Application.StartupPath & "\"
                .dDownloadDirectory = Replace(.dDownloadDirectory, "\\", "")
                .dBufferSize = Convert.ToInt64(Trim(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "BufferSize", "1024")))
                .dUseIpAddress = Convert.ToBoolean(Trim(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "UseIpAddress", "False")))
                .dCustomIpAddress = NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "CustomIpAddress", "")
                If Len(.dCustomIpAddress) = 0 Then .dCustomIpAddress = ReturnOutsideIPAddress()
                .dIgnorelist.dCount = Convert.ToInt32(Trim(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", "0")))
                .dSendPort = NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "SendPort", "1024")
                .dRandomizePort = Convert.ToBoolean(Trim(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "RandomizePort", "True")))
                .dIgnorelist.dCount = Convert.ToInt32(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString)))
                .dAutoIgnore = Convert.ToBoolean(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "AutoIgnore", "True"))
                .dAutoCloseDialogs = Convert.ToBoolean(NativeMethods.ReadINI(lSettings.lINI.iDCC, "Settings", "AutoCloseDialogs", "False"))
            End With
            For i = 1 To lDCC.dIgnorelist.dCount
                With lDCC.dIgnorelist.dItem(i)
                    .dData = NativeMethods.ReadINI(lSettings.lINI.iDCC, Trim(i.ToString), "Data", "")
                    .dType = CType(NativeMethods.ReadINI(lSettings.lINI.iDCC, Trim(i.ToString), "Type", "0"), gDCCIgnoreType)
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
        End Function

        Public Sub SaveDCCSettings()
            Dim i As Integer
            With lDCC
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "PopupDownloadManager", .dPopupDownloadManager.ToString())
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "DownloadDirectory", .dDownloadDirectory)
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "FileExistsAction", Trim(CType(.dFileExistsAction, Integer).ToString))
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString))
                For i = 1 To lDCC.dIgnorelist.dCount
                    NativeMethods.WriteINI(lSettings.lINI.iDCC, Trim(i.ToString), "Data", .dIgnorelist.dItem(i).dData)
                    NativeMethods.WriteINI(lSettings.lINI.iDCC, Trim(i.ToString), "Type", Trim(CType(.dIgnorelist.dItem(i).dType, Integer).ToString))
                Next i
                If .dChatPrompt = eDCCPrompt.ePrompt Then
                    NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "ChatPrompt", "1")
                ElseIf .dChatPrompt = eDCCPrompt.eAcceptAll Then
                    NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "ChatPrompt", "2")
                ElseIf .dChatPrompt = eDCCPrompt.eIgnore Then
                    NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "ChatPrompt", "3")
                End If
                If .dSendPrompt = eDCCPrompt.ePrompt Then
                    NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "SendPrompt", "1")
                ElseIf .dSendPrompt = eDCCPrompt.eAcceptAll Then
                    NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "SendPrompt", "2")
                ElseIf .dSendPrompt = eDCCPrompt.eIgnore Then
                    NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "SendPrompt", "3")
                End If
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "UseIpAddress", Trim(.dUseIpAddress.ToString))
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "CustomIpAddress", Trim(.dCustomIpAddress))
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString))
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "SendPort", Trim(.dSendPort.ToString))
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "RandomizePort", (Trim(.dRandomizePort.ToString)))
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "BufferSize", (Trim(.dBufferSize.ToString)))
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "AutoIgnore", Trim(.dAutoIgnore.ToString))
                NativeMethods.WriteINI(lSettings.lINI.iDCC, "Settings", "AutoCloseDialogs", Trim(.dAutoCloseDialogs.ToString))
            End With
        End Sub
    End Class
End Namespace