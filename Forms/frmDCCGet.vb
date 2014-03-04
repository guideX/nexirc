'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports System.IO
Imports nexIRC.Classes.IO
Imports nexIRC.Classes.Communications
Imports nexIRC.Modules

Public Class frmDCCGet
    Public Declare Function htonl Lib "wsock32.dll" (ByVal hostlong As UInt32) As UInt32
    Private WithEvents lSocket As New AsyncSocket
    Private Delegate Sub DataArrivalDelegate(ByVal lData As String, ByVal lBytes() As Byte, ByVal lBytesRecieved As Integer)
    Private Delegate Sub EmptyDelegate()
    Private lOutPut As FileStream
    Private lBinaryWriter As BinaryWriter
    Private lUser As String
    Private lRemoteIp As String
    Private lRemotePort As String
    Private lRemoteFileName As String
    Private lRemoteFileSize As String
    Private lLocalFileName As String
    Private lConnected As Boolean
    Private lBytesRecievedCount As UInt32
    Private lFileOpen As Boolean
    Private lPacketSizeDelay As Integer = 1000

    Public Sub InitDCCGet(ByVal lUsr As String, ByVal lRemIp As String, ByVal lRemPort As String, ByVal lFileName As String, ByVal lFileSize As String)
        'Try
        lUser = lUsr
        lRemoteIp = lRemIp
        lRemotePort = lRemPort
        lRemoteFileName = lFileName
        lRemoteFileSize = Trim(lFileSize)
        lRemoteFileSize = Replace(lRemoteFileSize, Chr(32), "")
        lRemoteFileSize = Replace(lRemoteFileSize, Chr(1), "")
        lRemoteFileSize = Replace(lRemoteFileSize, " ", "")
        lblNickname.Text = lUsr
        lblIp.Text = lStrings.DecodeLongIPAddr(lRemIp)
        lblPort.Text = lRemPort
        lblSize.Text = lFileSize
        lblFilename.Text = lFileName
        ProgressBar1.Maximum = CType(lRemoteFileSize, Integer)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub frmDCCGet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Try
        tmrSendCurrentSize.Enabled = False
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub frmDCCGet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        txtDownloadTo.Text = lSettings_DCC.lDCC.dDownloadDirectory
        Me.Icon = mdiMain.Icon
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Try
        Dim mBox As MsgBoxResult
        txtDownloadTo.Enabled = False
        If (File.Exists(lSettings.lINI.iBasePath & lblFilename.Text)) Then
            If lSettings.lIRC.iSettings.sPrompts = True Then
                If lSettings_DCC.lDCC.dFileExistsAction = nexIRC.IRC.Settings.clsDCC.eDCCFileExistsAction.dPrompt = True Then
                    mBox = MsgBox("This file already exists, replace the original?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)
                ElseIf lSettings_DCC.lDCC.dFileExistsAction = nexIRC.IRC.Settings.clsDCC.eDCCFileExistsAction.dOverwrite = True Then
                    mBox = MsgBoxResult.Yes
                ElseIf lSettings_DCC.lDCC.dFileExistsAction = nexIRC.IRC.Settings.clsDCC.eDCCFileExistsAction.dIgnore = True Then
                    MsgBox("This file already exists!", MsgBoxStyle.Critical)
                    mBox = MsgBoxResult.No
                End If
            Else
                If lSettings_DCC.lDCC.dFileExistsAction = nexIRC.IRC.Settings.clsDCC.eDCCFileExistsAction.dIgnore = True Then
                    mBox = MsgBoxResult.No
                Else
                    mBox = MsgBoxResult.Yes
                End If
            End If
            If mBox = MsgBoxResult.Yes Then
                Kill(lSettings.lINI.iBasePath & lblFilename.Text)
                Application.DoEvents()
                If (File.Exists(lSettings.lINI.iBasePath & lblFilename.Text)) Then
                    If lSettings.lIRC.iSettings.sPrompts = True Then
                        MsgBox("Unable to remove '" & lblFilename.Text & "'")
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If
            ElseIf mBox = MsgBoxResult.No Then
                Exit Sub
            ElseIf mBox = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        cmdOK.Enabled = False
        lSocket.Connect(lStrings.DecodeLongIPAddr(lRemoteIp), CLng(Trim(lRemotePort)))
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub SocketConnectedProc()
        'Try
        lConnected = True
        tmrSendCurrentSize.Interval = lPacketSizeDelay
        If lStrings.DoRight(txtDownloadTo.Text, 1) <> "\" Then
            txtDownloadTo.Text = txtDownloadTo.Text & "\"
        End If
        lLocalFileName = txtDownloadTo.Text & lRemoteFileName
        lOutPut = New FileStream(lLocalFileName, FileMode.Create, FileAccess.Write, FileShare.None)
        lBinaryWriter = New BinaryWriter(lOutPut)
        lFileOpen = True
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub SocketDataArrivalProc(ByVal lData As String, ByVal lBytes() As Byte, ByVal lBytesRecieved As Integer)
        'Try
        Dim i As Integer, n As Integer, lCBytes() As Byte
        If lConnected = True Then
            ReDim lCBytes(lBytesRecieved)
            For i = 0 To lBytesRecieved
                n = n + 1
                lCBytes(i) = lBytes(i)
            Next i
            lBinaryWriter.Write(lCBytes)
            lBytesRecievedCount = lBytesRecievedCount + CUInt(Len(lData))
            ProgressBar1.Value = Convert.ToInt32(lBytesRecievedCount)
            If Convert.ToInt32(lBytesRecievedCount) = Convert.ToInt32(lRemoteFileSize) Then
                lSocket.SendBytes(BytesToChars(lBytesRecievedCount))
                tmrDelayEndTransfer.Enabled = True
                Exit Sub
            End If
            tmrSendCurrentSize.Enabled = True
        Else
            MsgBox("The following data could not be added: " & lData)
        End If
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub EndTransfer()
        'Try
        tmrDelayEndTransfer.Enabled = False
        tmrSendCurrentSize.Enabled = False
        lConnected = False
        If lFileOpen = True Then
            lBinaryWriter.Close()
            lOutPut.Close()
            lOutPut.Dispose()
            lFileOpen = False
        End If
        lSettings.AddToDownloadManager(txtDownloadTo.Text & lblFilename.Text, lblNickname.Text, True)
        If lSettings_DCC.lDCC.dAutoCloseDialogs = True Then
            Me.Close()
        Else
            Me.Text = "nexIRC - Transfer Complete"
            ProgressBar1.Value = 0
            cmdRun.Visible = True
            cmdCancel.Text = "Close"
        End If
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Function BytesToChars(ByVal lBytes As Long) As Byte()
        'Try
            Dim lLongValue As Long, lLongByte As Long, lSendBackByte() As Byte
            lLongValue = htonl(CUInt(lBytes))
            ReDim lSendBackByte(3)
            lLongByte = lLongValue And &HFF&
            lSendBackByte(0) = CByte(lLongByte)
            lLongByte = CLng((lLongValue And &HFF00&) / &H100)
            lLongByte = lLongByte And &HFF&
            lSendBackByte(1) = CByte(lLongByte)
            lLongByte = CLng((lLongValue And &HFF0000) / &H10000)
            lLongByte = lLongByte And &HFF&
            lSendBackByte(2) = CByte(lLongByte)
            lLongByte = CLng((lLongValue And &HFF000000) / &H1000000)
            lLongByte = lLongByte And &HFF&
            lSendBackByte(3) = CByte(lLongByte)
            BytesToChars = lSendBackByte
            'Catch ex As Exception
            'Throw ex
            'End Try
    End Function

    Private Sub SocketDisconnectedProc()
        'Try
        If lConnected = True Then EndTransfer()
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.SocketConnected
        'Try
        Dim lSocketConnectedProc As New EmptyDelegate(AddressOf SocketConnectedProc)
        Me.Invoke(lSocketConnectedProc)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Public Sub SetProgressBar(ByVal lProgressBar As ProgressBar, ByVal lPercent As Integer)
        'Try
        lProgressBar.Value = lPercent
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lSocket.SocketDataArrival
        'Try
        Dim lSocketDataArrivalProc As New DataArrivalDelegate(AddressOf SocketDataArrivalProc)
        Me.Invoke(lSocketDataArrivalProc, SocketData, lBytes, lBytesRead)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.SocketDisconnected
        'Try
        Dim lSocketDisconnectProc As New EmptyDelegate(AddressOf SocketDisconnectedProc)
        If lConnected = True Then Me.Invoke(lSocketDisconnectProc)
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub tmrSendCurrentSize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSendCurrentSize.Tick
        'Try
        tmrSendCurrentSize.Enabled = False
        lSocket.SendBytes(BytesToChars(lBytesRecievedCount))
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub cmdDownloadTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDownloadTo.Click
        'Try
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments
        FolderBrowserDialog1.ShowDialog()
        txtDownloadTo.Text = FolderBrowserDialog1.SelectedPath
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub tmrDelayEndTransfer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDelayEndTransfer.Tick
        'Try
        tmrDelayEndTransfer.Enabled = False
        If lConnected = True Then
            lSocket.Close()
            EndTransfer()
        End If
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub
End Class