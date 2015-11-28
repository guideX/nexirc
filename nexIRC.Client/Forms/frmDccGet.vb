'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports System.IO
Imports nexIRC.Sockets
Imports nexIRC.Business.Helpers
Imports nexIRC.Business.Repositories
Imports nexIRC.Client.nexIRC.Client

Public Class frmDccGet
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
    'Private dccSettings As gDCC

    Public Sub InitDCCGet(ByVal lUsr As String, ByVal lRemIp As String, ByVal lRemPort As String, ByVal lFileName As String, ByVal lFileSize As String)
        Try
            lUser = lUsr
            lRemoteIp = lRemIp
            lRemotePort = lRemPort
            lRemoteFileName = lFileName
            lRemoteFileSize = Trim(lFileSize)
            lRemoteFileSize = Replace(lRemoteFileSize, Chr(32), "")
            lRemoteFileSize = Replace(lRemoteFileSize, Chr(1), "")
            lRemoteFileSize = Replace(lRemoteFileSize, " ", "")
            lblNickname.Text = lUsr
            lblIp.Text = Modules.lStrings.DecodeLongIPAddr(lRemIp)
            lblPort.Text = lRemPort
            lblSize.Text = lFileSize
            lblFilename.Text = lFileName
            ProgressBar1.Maximum = CType(lRemoteFileSize, Integer)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmDCCGet_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            tmrSendCurrentSize.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmDCCGet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'dccSettings = Modules.lSettings_DCC
            txtDownloadTo.Text = Modules.lSettings_DCC.dDownloadDirectory
            Me.Icon = mdiMain.Icon
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        Try
            Dim mBox As MsgBoxResult
            txtDownloadTo.Enabled = False
            If (File.Exists(Modules.lSettings.lINI.iBasePath & lblFilename.Text)) Then
                If Modules.lSettings.lIRC.iSettings.sPrompts = True Then
                    If Modules.lSettings_DCC.dFileExistsAction = Business.Enums.eDccFileExistsAction.dPrompt Then
                        mBox = MsgBox("This file already exists, replace the original?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel)
                    ElseIf Modules.lSettings_DCC.dFileExistsAction = Business.Enums.eDccFileExistsAction.dOverwrite Then
                        mBox = MsgBoxResult.Yes
                    ElseIf Modules.lSettings_DCC.dFileExistsAction = Business.Enums.eDccFileExistsAction.dIgnore Then
                        MsgBox("This file already exists!", MsgBoxStyle.Critical)
                        mBox = MsgBoxResult.No
                    End If
                Else
                    If Modules.lSettings_DCC.dFileExistsAction = Business.Enums.eDccFileExistsAction.dIgnore Then
                        mBox = MsgBoxResult.No
                    Else
                        mBox = MsgBoxResult.Yes
                    End If
                End If
                If mBox = MsgBoxResult.Yes Then
                    Kill(Modules.lSettings.lINI.iBasePath & lblFilename.Text)
                    Application.DoEvents()
                    If (File.Exists(Modules.lSettings.lINI.iBasePath & lblFilename.Text)) Then
                        If Modules.lSettings.lIRC.iSettings.sPrompts = True Then
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
            cmdRun.Enabled = False
            lSocket.Connect(Modules.lStrings.DecodeLongIPAddr(lRemoteIp), Convert.ToInt64(Trim(lRemotePort)))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SocketConnectedProc()
        Try
            lConnected = True
            tmrSendCurrentSize.Interval = lPacketSizeDelay
            If TextHelper.DoRight(txtDownloadTo.Text, 1) <> "\" Then
                txtDownloadTo.Text = txtDownloadTo.Text & "\"
            End If
            lLocalFileName = txtDownloadTo.Text & lRemoteFileName
            lOutPut = New FileStream(lLocalFileName, FileMode.Create, FileAccess.Write, FileShare.None)
            lBinaryWriter = New BinaryWriter(lOutPut)
            lFileOpen = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SocketDataArrivalProc(ByVal lData As String, ByVal lBytes() As Byte, ByVal lBytesRecieved As Integer)
        Try
            Dim i As Integer, n As Integer, lCBytes() As Byte
            If lConnected = True Then
                ReDim lCBytes(lBytesRecieved)
                For i = 0 To lBytesRecieved
                    n = n + 1
                    lCBytes(i) = lBytes(i)
                Next i
                lBinaryWriter.Write(lCBytes)
                lBytesRecievedCount = lBytesRecievedCount + CUInt(lData.Length)
                ProgressBar1.Value1 = Convert.ToInt32(lBytesRecievedCount)
                ProgressBar1.Value2 = Convert.ToInt32(lBytesRecievedCount)
                If Convert.ToInt32(lBytesRecievedCount) = Convert.ToInt32(lRemoteFileSize) Then
                    lSocket.SendBytes(BytesToChars(lBytesRecievedCount))
                    tmrDelayEndTransfer.Enabled = True
                    Exit Sub
                End If
                tmrSendCurrentSize.Enabled = True
            Else
                MsgBox("The following data could not be added: " & lData)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EndTransfer()
        Try
            tmrDelayEndTransfer.Enabled = False
            tmrSendCurrentSize.Enabled = False
            lConnected = False
            If lFileOpen = True Then
                lBinaryWriter.Close()
                lOutPut.Close()
                lOutPut.Dispose()
                lFileOpen = False
            End If
            Modules.lSettings.AddToDownloadManager(txtDownloadTo.Text & lblFilename.Text, lblNickname.Text, True)
            If Modules.lSettings_DCC.dAutoCloseDialogs = True Then
                Me.Close()
            Else
                Me.Text = "nexIRC - Transfer Complete"
                ProgressBar1.Value1 = 0
                ProgressBar1.Value2 = 0
                cmdRun.Visible = True
                cmdCancel.Text = "Close"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function BytesToChars(ByVal lBytes As Long) As Byte()
        Try
            Dim lLongValue As Long, lLongByte As Long, lSendBackByte() As Byte
            lLongValue = htonl(CUInt(lBytes))
            ReDim lSendBackByte(3)
            lLongByte = lLongValue And &HFF&
            lSendBackByte(0) = CByte(lLongByte)
            lLongByte = Convert.ToInt64((lLongValue And &HFF00&) / &H100)
            lLongByte = lLongByte And &HFF&
            lSendBackByte(1) = CByte(lLongByte)
            lLongByte = Convert.ToInt64((lLongValue And &HFF0000) / &H10000)
            lLongByte = lLongByte And &HFF&
            lSendBackByte(2) = CByte(lLongByte)
            lLongByte = Convert.ToInt64((lLongValue And &HFF000000) / &H1000000)
            lLongByte = lLongByte And &HFF&
            lSendBackByte(3) = CByte(lLongByte)
            BytesToChars = lSendBackByte
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function

    Private Sub SocketDisconnectedProc()
        Try
            If lConnected = True Then EndTransfer()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lSocket_socketConnected(ByVal SocketID As String) Handles lSocket.SocketConnected
        Try
            Dim lSocketConnectedProc As New EmptyDelegate(AddressOf SocketConnectedProc)
            Me.Invoke(lSocketConnectedProc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetProgressBar(ByVal lProgressBar As ProgressBar, ByVal lPercent As Integer)
        Try
            lProgressBar.Value = lPercent
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lSocket_socketDataArrival(ByVal SocketID As String, ByVal SocketData As String, ByVal lBytes() As Byte, ByVal lBytesRead As Integer) Handles lSocket.SocketDataArrival
        Try
            Dim lSocketDataArrivalProc As New DataArrivalDelegate(AddressOf SocketDataArrivalProc)
            Me.Invoke(lSocketDataArrivalProc, SocketData, lBytes, lBytesRead)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lSocket_socketDisconnected(ByVal SocketID As String) Handles lSocket.SocketDisconnected
        Try
            Dim lSocketDisconnectProc As New EmptyDelegate(AddressOf SocketDisconnectedProc)
            If lConnected = True Then Me.Invoke(lSocketDisconnectProc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tmrSendCurrentSize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSendCurrentSize.Tick

    End Sub

    Private Sub cmdDownloadTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDownloadTo.Click
        Try
            FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments
            FolderBrowserDialog1.ShowDialog()
            txtDownloadTo.Text = FolderBrowserDialog1.SelectedPath
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class