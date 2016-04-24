'nexIRC 3.0.30
'04-23-2016 - guideX
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
            Throw ex
        End Try
    End Sub

    Public Sub SetInfo(ByVal lNick As String, ByVal lAddr As String, ByVal lPrt As String)
        Try
            If (Not String.IsNullOrEmpty(lNick) And Not String.IsNullOrEmpty(lAddr) And Not String.IsNullOrEmpty(lPrt)) Then
                lNickName = lNick
                lAddress = lAddr
                lPort = lPrt
                lblNickName.Text = lNick
                lblAddress.Text = Modules.lStrings.DecodeLongIPAddr(lAddr)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmDCCChatPrompt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = mdiMain.Icon
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Dim lDCCChat As New frmDCCChat
            lDCCChat.cboUsers.Text = lNickName
            lDCCChat.lDccChatUI.SetStatusIndex(lStatusIndex)
            lDCCChat.lDccChatUI.SetInfo(lAddress, Trim(lPort.ToString))
            lDCCChat.Show()
            Me.Close()
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
End Class