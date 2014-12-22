'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Settings
Imports nexIRC.Modules
Imports System.Net
Imports nexIRC.IniFile
Imports nexIRC.Settings2

Namespace nexIRC.IRC.Settings
    Public Class clsDCC
        Public lDCC As gDCC

        Public Sub LoadDCCSettings()
            Try
                Dim i As Integer, n As Integer
                With lDCC
                    ReDim .dIgnorelist.dItem(lSettings.lArraySizes.aDCCIgnore)
                    Dim fileExistsAction = Files.ReadINI(lSettings.lINI.iDCC, "Settings", "FileExistsAction", "1")
                    If (IsNumeric(fileExistsAction)) Then
                        Select Case Convert.ToInt32(fileExistsAction)
                            Case 1
                                .dFileExistsAction = eDCCFileExistsAction.dPrompt
                            Case 2
                                .dFileExistsAction = eDCCFileExistsAction.dOverwrite
                            Case 3
                                .dFileExistsAction = eDCCFileExistsAction.dPrompt
                        End Select
                    End If
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
                    If Len(.dCustomIpAddress) = 0 Then .dCustomIpAddress = DccSettings.ReturnOutsideIPAddress()
                    .dIgnorelist.dCount = Convert.ToInt32(Trim(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", "0")))
                    .dSendPort = Files.ReadINI(lSettings.lINI.iDCC, "Settings", "SendPort", "1024")
                    .dRandomizePort = Convert.ToBoolean(Trim(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "RandomizePort", "True")))
                    .dIgnorelist.dCount = Convert.ToInt32(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString)))
                    .dAutoIgnore = Convert.ToBoolean(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "AutoIgnore", "True"))
                    .dAutoCloseDialogs = Convert.ToBoolean(Files.ReadINI(lSettings.lINI.iDCC, "Settings", "AutoCloseDialogs", "False"))
                End With
                For i = 1 To lDCC.dIgnorelist.dCount
                    With lDCC.dIgnorelist.dItem(i)
                        .dData = Files.ReadINI(lSettings.lINI.iDCC, i.ToString().Trim(), "Data", "")
                        Dim type = Files.ReadINI(lSettings.lINI.iDCC, i.ToString().Trim(), "Type", "0")
                        If (IsNumeric(type)) Then
                            Select Case Convert.ToInt32(type)
                                Case 1
                                    .dType = gDCCIgnoreType.dNicknames
                                Case 2
                                    .dType = gDCCIgnoreType.dHostnames
                                Case 3
                                    .dType = gDCCIgnoreType.dFileTypes
                            End Select
                        End If
                    End With
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub SaveDCCSettings()
            Try
                DccSettings.SaveDCCSettings(lSettings.lINI.iDCC, lDCC)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace