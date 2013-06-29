'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmDCCChatPrompt
    Private lNickName As String
    Private lAddress As String
    Private lPort As String
    Private lStatusIndex As Integer

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        Try
            lStatusIndex = lIndex
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lStatusIndex As Integer)")
        End Try
    End Sub

    Public Sub SetInfo(ByVal lNick As String, ByVal lAddr As String, ByVal lPrt As String)
        Try
            If Len(lNick) <> 0 And Len(lAddr) <> 0 And Len(lPrt) <> 0 Then
                lNickName = lNick
                lAddress = lAddr
                lPort = lPrt
                lblNickName.Text = lNick
                lblAddress.Text = DecodeLongIPAddr(lAddr)
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetInfo(ByVal lNick As String, ByVal lAddr As String, ByVal lPrt As String)")
        End Try
    End Sub

    Private Sub frmDCCChatPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = mdiMain.Icon
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmDCCChatPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Dim lDCCChat As New frmDCCChat
            lDCCChat.cboUsers.Text = lNickName
            lDCCChat.SetStatusIndex(lStatusIndex)
            lDCCChat.SetInfo(lAddress, Trim(lPort.ToString))
            lDCCChat.Show()
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub
End Class