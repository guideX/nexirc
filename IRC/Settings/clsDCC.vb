Option Explicit On
Option Strict On
Imports nexIRC.Classes.IO
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
        End Structure
        Public lDCC As gDCC
        Public Sub LoadDCCSettings()
            Dim i As Integer, n As Integer
            With lDCC
                ReDim .dIgnorelist.dItem(lArraySizes.aDCCIgnore)
                .dFileExistsAction = CType(clsFiles.ReadINI(lINI.iDCC, "Settings", "FileExistsAction", "1"), eDCCFileExistsAction)
                n = CInt(Trim(clsFiles.ReadINI(lINI.iDCC, "Settings", "ChatPrompt", "1")))
                If n = 1 Then
                    .dChatPrompt = eDCCPrompt.ePrompt
                ElseIf n = 2 Then
                    .dChatPrompt = eDCCPrompt.eAcceptAll
                ElseIf n = 3 Then
                    .dChatPrompt = eDCCPrompt.eIgnore
                End If
                n = CInt(Trim(clsFiles.ReadINI(lINI.iDCC, "Settings", "SendPrompt", "1")))
                If n = 1 Then
                    .dSendPrompt = eDCCPrompt.ePrompt
                ElseIf n = 2 Then
                    .dSendPrompt = eDCCPrompt.eAcceptAll
                ElseIf n = 3 Then
                    .dSendPrompt = eDCCPrompt.eIgnore
                End If
                .dDownloadDirectory = clsFiles.ReadINI(lINI.iDCC, "Settings", "DownloadDirectory", "")
                If Len(.dDownloadDirectory) = 0 Then .dDownloadDirectory = Application.StartupPath & "\"
                .dDownloadDirectory = Replace(.dDownloadDirectory, "\\", "")
                .dBufferSize = CLng(Trim(clsFiles.ReadINI(lINI.iDCC, "Settings", "BufferSize", "1024")))
                .dUseIpAddress = CBool(Trim(clsFiles.ReadINI(lINI.iDCC, "Settings", "UseIpAddress", "False")))
                .dCustomIpAddress = clsFiles.ReadINI(lINI.iDCC, "Settings", "CustomIpAddress", "")
                If Len(.dCustomIpAddress) = 0 Then .dCustomIpAddress = New WebClient().DownloadString("http://www.whatismyip.com/automation/n09230945.asp")
                .dIgnorelist.dCount = CInt(Trim(clsFiles.ReadINI(lINI.iDCC, "Settings", "IgnoreCount", "0")))
                .dSendPort = clsFiles.ReadINI(lINI.iDCC, "Settings", "SendPort", "1024")
                .dRandomizePort = CBool(Trim(clsFiles.ReadINI(lINI.iDCC, "Settings", "RandomizePort", "True")))
                .dIgnorelist.dCount = CInt(clsFiles.ReadINI(lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString)))
                .dAutoIgnore = CBool(clsFiles.ReadINI(lINI.iDCC, "Settings", "AutoIgnore", "True"))
                .dAutoCloseDialogs = CBool(clsFiles.ReadINI(lINI.iDCC, "Settings", "AutoCloseDialogs", "False"))
            End With
            For i = 1 To lDCC.dIgnorelist.dCount
                With lDCC.dIgnorelist.dItem(i)
                    .dData = clsFiles.ReadINI(lINI.iDCC, Trim(i.ToString), "Data", "")
                    .dType = CType(clsFiles.ReadINI(lINI.iDCC, Trim(i.ToString), "Type", "0"), gDCCIgnoreType)
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
        Public Sub SaveDCCSettings()
            Dim i As Integer
            With lDCC
                clsFiles.WriteINI(lINI.iDCC, "Settings", "DownloadDirectory", .dDownloadDirectory)
                clsFiles.WriteINI(lINI.iDCC, "Settings", "FileExistsAction", Trim(CType(.dFileExistsAction, Integer).ToString))
                clsFiles.WriteINI(lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString))
                For i = 1 To lDCC.dIgnorelist.dCount
                    clsFiles.WriteINI(lINI.iDCC, Trim(i.ToString), "Data", .dIgnorelist.dItem(i).dData)
                    clsFiles.WriteINI(lINI.iDCC, Trim(i.ToString), "Type", Trim(CType(.dIgnorelist.dItem(i).dType, Integer).ToString))
                Next i
                If .dChatPrompt = eDCCPrompt.ePrompt Then
                    clsFiles.WriteINI(lINI.iDCC, "Settings", "ChatPrompt", "1")
                ElseIf .dChatPrompt = eDCCPrompt.eAcceptAll Then
                    clsFiles.WriteINI(lINI.iDCC, "Settings", "ChatPrompt", "2")
                ElseIf .dChatPrompt = eDCCPrompt.eIgnore Then
                    clsFiles.WriteINI(lINI.iDCC, "Settings", "ChatPrompt", "3")
                End If
                If .dSendPrompt = eDCCPrompt.ePrompt Then
                    clsFiles.WriteINI(lINI.iDCC, "Settings", "SendPrompt", "1")
                ElseIf .dSendPrompt = eDCCPrompt.eAcceptAll Then
                    clsFiles.WriteINI(lINI.iDCC, "Settings", "SendPrompt", "2")
                ElseIf .dSendPrompt = eDCCPrompt.eIgnore Then
                    clsFiles.WriteINI(lINI.iDCC, "Settings", "SendPrompt", "3")
                End If
                clsFiles.WriteINI(lINI.iDCC, "Settings", "UseIpAddress", Trim(.dUseIpAddress.ToString))
                clsFiles.WriteINI(lINI.iDCC, "Settings", "CustomIpAddress", Trim(.dCustomIpAddress))
                clsFiles.WriteINI(lINI.iDCC, "Settings", "IgnoreCount", Trim(.dIgnorelist.dCount.ToString))
                clsFiles.WriteINI(lINI.iDCC, "Settings", "SendPort", Trim(.dSendPort.ToString))
                clsFiles.WriteINI(lINI.iDCC, "Settings", "RandomizePort", (Trim(.dRandomizePort.ToString)))
                clsFiles.WriteINI(lINI.iDCC, "Settings", "BufferSize", (Trim(.dBufferSize.ToString)))
                clsFiles.WriteINI(lINI.iDCC, "Settings", "AutoIgnore", Trim(.dAutoIgnore.ToString))
                clsFiles.WriteINI(lINI.iDCC, "Settings", "AutoCloseDialogs", Trim(.dAutoCloseDialogs.ToString))
            End With
        End Sub
    End Class
End Namespace