'nexIRC 3.0.23
'02-27-2013 - guideX

Option Explicit On
Option Strict On

Public Class frmDCCSend
    Private WithEvents lListen As nexIRC.Sockets.AsyncServer
    Private WithEvents lSocket As nexIRC.Sockets.AsyncSocket
    Private Delegate Sub mDoStatusColor(ByVal lData As String, ByVal lIndex As Integer)
    Private Delegate Sub SocketDelegate(ByVal lTmpSocket As nexIRC.Sockets.AsyncSocket)
    Private Delegate Sub ProgressBarDelegate(ByVal lValue As Integer)
    Private Delegate Sub DoubleLongDelegate(ByVal lLong As Long, ByVal lLong2 As Long)
    Private lStatusIndex As Integer
    Private lConnected As Boolean
    Private lFileData As String
    Private lFileDataBkup As String
    Private lFileOpen As Boolean
    Private Delegate Sub StringDelegate(ByVal lData As String)
    Private Delegate Sub EmptyDelegate()
    Private lResponceData As String

    Private Structure gFile
        Public fFileNumber As Integer
        Public fBufferSize As Long
        Public fFileLength As Long
        Public fBytesSent As Long
    End Structure

    Private lFile As gFile

    Public Sub InitFile()
        On Error Resume Next
        With lFile
            .fBufferSize = lDCC.dBufferSize
            .fFileNumber = FreeFile()
            FileOpen(.fFileNumber, txtFilename.Text, OpenMode.Binary, OpenAccess.Read)
            lFileOpen = True
            .fFileLength = LOF(.fFileNumber)
            SendFileChunk("")
        End With
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub InitFile()")
    End Sub

    Public Sub SendFileChunk(ByVal lData As String)
        On Error Resume Next
        Dim msg As String, lSetProgress As New DoubleLongDelegate(AddressOf SetProgress)
        With lFile
            lResponceData = lResponceData & vbCrLf & lData
            Clipboard.Clear()
            Clipboard.SetText(lResponceData)
            If .fFileLength - Loc(.fFileNumber) <= .fBufferSize Then .fBufferSize = (.fFileLength - Loc(.fFileNumber))
            If .fBufferSize = 0 Then Exit Sub
            .fBytesSent = .fBytesSent + .fBufferSize
            msg = Space(CInt(.fBufferSize))
            FileGet(.fFileNumber, msg)
            lSocket.Send(msg)
            Me.Invoke(lSetProgress, .fBytesSent, .fFileLength)
        End With
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SendFileChunk()")
    End Sub

    Private Sub SetProgress(ByVal lBytesSent As Long, ByVal lLength As Long)
        On Error Resume Next
        Dim i As Long
        i = CLng(lBytesSent / lLength * 100)
        ProgressBar1.Value = CInt(i)
        If i <> 100 Then
            lblStatus.Text = "Sent: " & Format(lBytesSent, "###,###,###") & " bytes"
        Else
            lblStatus.Text = "Send Complete"
            tmrCloseSocketDelay.Enabled = True
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SetProgressBar()")
    End Sub

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        On Error Resume Next
        lStatusIndex = lIndex
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
    End Sub

    Private Sub frmDCCSend_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        WriteINI(lINI.iDCC, "Settings", "DCCSendLastNick", cboNickname.Text)
        If lFileOpen = True Then FileClose(lFile.fFileNumber)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmDCCSend_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
    End Sub

    Private Sub frmDCCSend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        Dim i As Integer
        cboNickname.Text = ReadINI(lINI.iDCC, "Settings", "DCCSendLastNick", "")
        Me.Icon = mdiMain.Icon
        For i = 1 To lNotify.nCount
            cboNickname.Items.Add(lNotify.nNotify(i).nNickName)
        Next i
        For i = 128 To 9999
            cboPort.Items.Add(Trim(i.ToString))
        Next i
        cboPort.Text = Trim(lStatus.lIRCMisc.ReturnDCCPort().ToString)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmDCCSend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load")
    End Sub

    Private Sub InitSendListenSocket(ByVal lPort As Integer)
        On Error Resume Next
        lListen = New nexIRC.Sockets.AsyncServer(CInt(lPort))
        lListen.Start()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub InitSendListenSocket(ByVal lPort As Integer)")
    End Sub

    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        On Error Resume Next
        Dim msg As String, msg2 As String, lSetLabel As New StringDelegate(AddressOf SetLabel), msg3 As String
        If lStatus.Connected(lStatusIndex) = True Then
            If System.IO.File.Exists(txtFilename.Text) = True Then
                If Len(cboNickname.Text) <> 0 Then
                    cmdSend.Enabled = False
                    cboNickname.Enabled = False
                    txtFilename.Enabled = False
                    cboPort.Enabled = False
                    Me.Invoke(lSetLabel, "Requesting Connection")
                    lSocket = New nexIRC.Sockets.AsyncSocket
                    InitSendListenSocket(CInt(Trim(cboPort.Text)))
                    If lDCC.dUseIpAddress = True Then
                        msg = lDCC.dCustomIpAddress
                    Else
                        msg = lStatus.lIRCMisc.ReturnMyIp()
                    End If
                    msg3 = Replace(GetFileTitle(txtFilename.Text), " ", "_")
                    msg2 = "PRIVMSG " & Trim(cboNickname.Text) & " :DCC SEND " & msg3 & " " & EncodeIPAddr(msg) & " " & Trim(cboPort.Text) & " " & (FileLen(txtFilename.Text)) & ""
                    lStatus.DoStatusSocket(lStatusIndex, "NOTICE " & Trim(cboNickname.Text) & " :DCC SEND " & msg3 & " (" & msg & ")")
                    lStatus.DoStatusSocket(lStatusIndex, msg2)
                End If
            End If
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click")
    End Sub

    Private Sub SetLabel(ByVal lData As String)
        On Error Resume Next
        lblStatus.Text = lData
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub SetLabel(ByVal lData As String)")
    End Sub

    Private Sub lListen_ConnectionAccept(ByVal tmp_Socket As nexIRC.Sockets.AsyncSocket) Handles lListen.ConnectionAccept
        On Error Resume Next
        Dim l As New EmptyDelegate(AddressOf InitFile)
        lSocket = tmp_Socket
        Me.Invoke(l)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lListen_ConnectionAccept(ByVal tmp_Socket As nexIRC.Sockets.AsyncSocket) Handles lListen.ConnectionAccept")
    End Sub

    Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lSocket.socketDataArrival
        On Error Resume Next
        Dim l As New StringDelegate(AddressOf SendFileChunk)
        Me.Invoke(l, SocketData)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String) Handles lSocket.socketDataArrival")
    End Sub

    Private Sub lSocket_socketError(ByVal lData As String) Handles lSocket.socketError
        On Error Resume Next
        Dim lSetLabel As New StringDelegate(AddressOf SetLabel)
        Me.Invoke(lSetLabel, lData)
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub lSocket_socketError(ByVal lData As String) Handles lSocket.socketError")
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click")
    End Sub

    Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click
        On Error Resume Next
        OpenFileDialog1.Filter = "All Files (*.*)|*.*"
        OpenFileDialog1.ShowDialog()
        txtFilename.Text = OpenFileDialog1.FileName
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click")
    End Sub

    Private Sub tmrCloseSocketDelay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCloseSocketDelay.Tick
        On Error Resume Next
        tmrCloseSocketDelay.Enabled = False
        lSocket.Close()
        If lDCC.dAutoCloseDialogs = True Then Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub tmrCloseSocketDelay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCloseSocketDelay.Tick")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click")
    End Sub
End Class