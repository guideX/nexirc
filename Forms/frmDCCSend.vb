'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Classes.IO
Imports nexIRC.Modules
Imports nexIRC.Classes.Communications
Public Class frmDCCSend
    Private WithEvents lListen As AsyncServer
    Private WithEvents lSocket As AsyncSocket
    Private Delegate Sub mDoStatusColor(ByVal lData As String, ByVal lIndex As Integer)
    Private Delegate Sub SocketDelegate(ByVal lTmpSocket As AsyncSocket)
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
        With lFile
            .fBufferSize = lSettings_DCC.lDCC.dBufferSize
            .fFileNumber = FreeFile()
            FileOpen(.fFileNumber, txtFilename.Text, OpenMode.Binary, OpenAccess.Read)
            lFileOpen = True
            .fFileLength = LOF(.fFileNumber)
            SendFileChunk("")
        End With
    End Sub
    Public Sub SendFileChunk(ByVal lData As String)
        Dim msg As String, lSetProgress As New DoubleLongDelegate(AddressOf SetProgress)
        With lFile
            lResponceData = lResponceData & Environment.Newline & lData
            Clipboard.Clear()
            Clipboard.SetText(lResponceData)
            If .fFileLength - Loc(.fFileNumber) <= .fBufferSize Then .fBufferSize = (.fFileLength - Loc(.fFileNumber))
            If .fBufferSize = 0 Then Exit Sub
            .fBytesSent = .fBytesSent + .fBufferSize
            msg = Space(Convert.ToInt32(.fBufferSize))
            FileGet(.fFileNumber, msg)
            lSocket.Send(msg)
            Me.Invoke(lSetProgress, .fBytesSent, .fFileLength)
        End With
    End Sub
    Private Sub SetProgress(ByVal lBytesSent As Long, ByVal lLength As Long)
        Dim i As Long
        i = Convert.ToInt64(lBytesSent / lLength * 100)
        ProgressBar1.Value = Convert.ToInt32(i)
        If i <> 100 Then
            lblStatus.Text = "Sent: " & Format(lBytesSent, "###,###,###") & " bytes"
        Else
            lblStatus.Text = "Send Complete"
            tmrCloseSocketDelay.Enabled = True
        End If
    End Sub
    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        lStatusIndex = lIndex
    End Sub
    Private Sub frmDCCSend_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Files.WriteINI(lSettings.lINI.iDCC, "Settings", "DCCSendLastNick", cboNickname.Text)
        If lFileOpen = True Then FileClose(lFile.fFileNumber)
    End Sub
    Private Sub frmDCCSend_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        cboNickname.Text = Files.ReadINI(lSettings.lINI.iDCC, "Settings", "DCCSendLastNick", "")
        Me.Icon = mdiMain.Icon
        For i = 1 To lSettings.lNotify.nCount
            cboNickname.Items.Add(lSettings.lNotify.nNotify(i).nNickName)
        Next i
        For i = 128 To 9999
            cboPort.Items.Add(Trim(i.ToString))
        Next i
        cboPort.Text = Trim(lProcessNumeric.lIrcNumericHelper.ReturnDCCPort().ToString)
    End Sub
    Private Sub InitSendListenSocket(ByVal lPort As Integer)
        lListen = New AsyncServer(Convert.ToInt32(lPort))
        lListen.Start()
    End Sub
    Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        Dim msg As String, msg2 As String, lSetLabel As New StringDelegate(AddressOf SetLabel), msg3 As String
        If lStatus.Connected(lStatusIndex) = True Then
            If System.IO.File.Exists(txtFilename.Text) = True Then
                If (Not String.IsNullOrEmpty(cboNickname.Text)) Then
                    cmdSend.Enabled = False
                    cboNickname.Enabled = False
                    txtFilename.Enabled = False
                    cboPort.Enabled = False
                    Me.Invoke(lSetLabel, "Requesting Connection")
                    lSocket = New AsyncSocket
                    InitSendListenSocket(Convert.ToInt32(Trim(cboPort.Text)))
                    If lSettings_DCC.lDCC.dUseIpAddress = True Then
                        msg = lSettings_DCC.lDCC.dCustomIpAddress
                    Else
                        msg = lProcessNumeric.lIrcNumericHelper.ReturnMyIp()
                    End If
                    msg3 = Replace(lStrings.GetFileTitle(txtFilename.Text), " ", "_")
                    msg2 = "PRIVMSG " & Trim(cboNickname.Text) & " :DCC SEND " & msg3 & " " & lStrings.EncodeIPAddr(msg) & " " & Trim(cboPort.Text) & " " & (FileLen(txtFilename.Text)) & ""
                    lStatus.DoStatusSocket(lStatusIndex, "NOTICE " & Trim(cboNickname.Text) & " :DCC SEND " & msg3 & " (" & msg & ")")
                    lStatus.DoStatusSocket(lStatusIndex, msg2)
                End If
            End If
        End If
    End Sub
    Private Sub SetLabel(ByVal lData As String)
        lblStatus.Text = lData
    End Sub
    Private Sub lListen_ConnectionAccept(ByVal tmp_Socket As AsyncSocket) Handles lListen.ConnectionAccept
        Dim l As New EmptyDelegate(AddressOf InitFile)
        lSocket = tmp_Socket
        Me.Invoke(l)
    End Sub
    Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lSocket.socketDataArrival
        Dim l As New StringDelegate(AddressOf SendFileChunk)
        Me.Invoke(l, SocketData)
    End Sub
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
    Private Sub cmdSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectFile.Click
        OpenFileDialog1.Filter = "All Files (*.*)|*.*"
        OpenFileDialog1.ShowDialog()
        txtFilename.Text = OpenFileDialog1.FileName
    End Sub
    Private Sub tmrCloseSocketDelay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCloseSocketDelay.Tick
        tmrCloseSocketDelay.Enabled = False
        lSocket.Close()
        If lSettings_DCC.lDCC.dAutoCloseDialogs = True Then Me.Close()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class