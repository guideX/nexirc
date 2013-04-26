'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On
Imports System.IO

Public Class frmDCCGet
    Public Declare Function htonl Lib "wsock32.dll" (ByVal hostlong As UInt32) As UInt32
    Private WithEvents lSocket As New nexIRC.Sockets.AsyncSocket
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
        On Error Resume Next
        lUser = lUsr
        lRemoteIp = lRemIp
        lRemotePort = lRemPort
        lRemoteFileName = lFileName
        lRemoteFileSize = Trim(lFileSize)
        lRemoteFileSize = Replace(lRemoteFileSize, Chr(32), "")
        lRemoteFileSize = Replace(lRemoteFileSize, Chr(1), "")
        lRemoteFileSize = Replace(lRemoteFileSize, " ", "")
        lblNickname.Text = lUsr
        lblIp.Text = DecodeLongIPAddr(lRemIp)
        lblPort.Text = lRemPort
        lblSize.Text = lFileSize
        lblFilename.Text = lFileName
        ProgressBar1.Maximum = CType(lRemoteFileSize, Integer)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmDCCGet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub frmDCCGet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        tmrSendCurrentSize.Enabled = False
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmDCCGet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
    End Sub

    Private Sub frmDCCGet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        txtDownloadTo.Text = lDCC.dDownloadDirectory
        Me.Icon = mdiMain.Icon
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmDCCGet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
        Dim mBox As MsgBoxResult
        txtDownloadTo.Enabled = False
        If DoesFileExist(lINI.iBasePath & lblFilename.Text) = True Then
            If lIRC.iSettings.sPrompts = True Then
                If lDCC.dFileExistsAction = eDCCFileExistsAction.dPrompt = True Then
                    mBox = MsgBox("This file already exists, replace the original?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)
                ElseIf lDCC.dFileExistsAction = eDCCFileExistsAction.dOverwrite = True Then
                    mBox = MsgBoxResult.Yes
                ElseIf lDCC.dFileExistsAction = eDCCFileExistsAction.dIgnore = True Then
                    MsgBox("This file already exists!", MsgBoxStyle.Critical)
                    mBox = MsgBoxResult.No
                End If
            Else
                If lDCC.dFileExistsAction = eDCCFileExistsAction.dIgnore = True Then
                    mBox = MsgBoxResult.No
                Else
                    mBox = MsgBoxResult.Yes
                End If
            End If
            If mBox = MsgBoxResult.Yes Then
                Kill(lINI.iBasePath & lblFilename.Text)
                Application.DoEvents()
                If DoesFileExist(lINI.iBasePath & lblFilename.Text) = True Then
                    If lIRC.iSettings.sPrompts = True Then
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
        lSocket.Connect(DecodeLongIPAddr(lRemoteIp), CLng(Trim(lRemotePort)))
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub

    Private Sub SocketConnectedProc()
        On Error Resume Next
        lConnected = True
        tmrSendCurrentSize.Interval = lPacketSizeDelay
        If DoRight(txtDownloadTo.Text, 1) <> "\" Then
            txtDownloadTo.Text = txtDownloadTo.Text & "\"
        End If
        lLocalFileName = txtDownloadTo.Text & lRemoteFileName
        lOutPut = New FileStream(lLocalFileName, FileMode.Create, FileAccess.Write, FileShare.None)
        lBinaryWriter = New BinaryWriter(lOutPut)
        lFileOpen = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SocketConnectedProc()")
    End Sub

    Private Sub SocketDataArrivalProc(ByVal lData As String, ByVal lBytes() As Byte, ByVal lBytesRecieved As Integer)
        On Error Resume Next
        Dim i As Integer, n As Integer, lCBytes() As Byte
        If lConnected = True Then
            ReDim lCBytes(lBytesRecieved)
            For i = 0 To lBytesRecieved
                n = n + 1
                lCBytes(i) = lBytes(i)
            Next i
            lBinaryWriter.Write(lCBytes)
            lBytesRecievedCount = lBytesRecievedCount + CUInt(Len(lData))
            ProgressBar1.Value = CInt(lBytesRecievedCount)
            If CInt(lBytesRecievedCount) = CInt(lRemoteFileSize) Then
                lSocket.SendBytes(BytesToChars(lBytesRecievedCount))
                tmrDelayEndTransfer.Enabled = True
                Exit Sub
            End If
            tmrSendCurrentSize.Enabled = True
        Else
            MsgBox("The following data could not be added: " & lData)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SocketDataArrivalProc(ByVal lData As String)")
    End Sub

    Private Sub EndTransfer()
        On Error Resume Next
        tmrDelayEndTransfer.Enabled = False
        tmrSendCurrentSize.Enabled = False
        lConnected = False
        If lFileOpen = True Then
            lBinaryWriter.Close()
            lOutPut.Close()
            lOutPut.Dispose()
            lFileOpen = False
        End If
        AddToDownloadManager(txtDownloadTo.Text & lblFilename.Text, lblNickname.Text, True)
        If lDCC.dAutoCloseDialogs = True Then
            Me.Close()
        Else
            Me.Text = "nexIRC - Transfer Complete"
            ProgressBar1.Value = 0
            cmdRun.Visible = True
            cmdCancel.Text = "Close"
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub EndTransfer()")
    End Sub

    Private Function BytesToChars(ByVal lBytes As Long) As Byte()
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Function BytesToChars(ByVal lBytes As Long) As Byte()")
    End Function

    Private Sub SocketDisconnectedProc()
        On Error Resume Next
        If lConnected = True Then EndTransfer()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SocketDisconnectedProc()")
    End Sub

    Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.socketConnected
        On Error Resume Next
        Dim lSocketConnectedProc As New EmptyDelegate(AddressOf SocketConnectedProc)
        Me.Invoke(lSocketConnectedProc)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.socketConnected")
    End Sub

    Public Sub SetProgressBar(ByVal lProgressBar As ProgressBar, ByVal lPercent As Integer)
        On Error Resume Next
        lProgressBar.Value = lPercent
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetProgressBar(ByVal lProgressBar As ProgressBar, ByVal lPercent As Integer)")
    End Sub

    Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lSocket.socketDataArrival
        On Error Resume Next
        Dim lSocketDataArrivalProc As New DataArrivalDelegate(AddressOf SocketDataArrivalProc)
        Me.Invoke(lSocketDataArrivalProc, SocketData, lBytes, lBytesRead)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String) Handles lSocket.socketDataArrival")
    End Sub

    Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected
        On Error Resume Next
        Dim lSocketDisconnectProc As New EmptyDelegate(AddressOf SocketDisconnectedProc)
        If lConnected = True Then Me.Invoke(lSocketDisconnectProc)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.socketDisconnected")
    End Sub

    Private Sub lSocket_socketError(ByVal lData As String) Handles lSocket.socketError
        On Error Resume Next
        Dim lSocketDisconnectProc As New EmptyDelegate(AddressOf SocketDisconnectedProc)
        Me.Invoke(lSocketDisconnectProc)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketError(ByVal lData As String) Handles lSocket.socketError")
    End Sub

    Private Sub tmrSendCurrentSize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSendCurrentSize.Tick
        On Error Resume Next
        tmrSendCurrentSize.Enabled = False
        lSocket.SendBytes(BytesToChars(lBytesRecievedCount))
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub tmrSendCurrentSize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSendCurrentSize.Tick")
    End Sub

    Private Sub cmdDownloadTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDownloadTo.Click
        On Error Resume Next
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments
        FolderBrowserDialog1.ShowDialog()
        txtDownloadTo.Text = FolderBrowserDialog1.SelectedPath
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click")
    End Sub

    Private Sub tmrDelayEndTransfer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDelayEndTransfer.Tick
        On Error Resume Next
        tmrDelayEndTransfer.Enabled = False
        If lConnected = True Then
            lSocket.Close()
            EndTransfer()
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub tmrDelayEndTransfer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDelayEndTransfer.Tick")
    End Sub
End Class