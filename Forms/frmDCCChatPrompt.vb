'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmDCCChatPrompt
    Private lNickName As String
    Private lAddress As String
    Private lPort As String
    Private lStatusIndex As Integer

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        On Error Resume Next
        lStatusIndex = lIndex
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lStatusIndex As Integer)")
    End Sub

    Public Sub SetInfo(ByVal lNick As String, ByVal lAddr As String, ByVal lPrt As String)
        On Error Resume Next
        If Len(lNick) <> 0 And Len(lAddr) <> 0 And Len(lPrt) <> 0 Then
            lNickName = lNick
            lAddress = lAddr
            lPort = lPrt
            lblNickName.Text = lNick
            lblAddress.Text = DecodeLongIPAddr(lAddr)
        End If
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetInfo(ByVal lNick As String, ByVal lAddr As String, ByVal lPrt As Long)")
    End Sub

    Private Sub frmDCCChatPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.Icon = mdiMain.Icon
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmDCCChatPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
        Dim lDCCChat As New frmDCCChat
        lDCCChat.cboUsers.Text = lNickName
        lDCCChat.SetStatusIndex(lStatusIndex)
        lDCCChat.SetInfo(lAddress, Trim(lPort.ToString))
        lDCCChat.Show()
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmDCCChatPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub
End Class