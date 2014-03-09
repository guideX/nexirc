'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On

Imports nexIRC.clsCommandTypes
Imports nexIRC.Modules

Public Class frmPrivateMessage
    Private lStatusIndex As Integer

    Public WriteOnly Property StatusIndex() As Integer
        Set(_StatusIndex As Integer)
            'Try
            lStatusIndex = _StatusIndex
            'Catch ex As Exception
            'Throw ex 'ProcessError(ex.Message, "Public WriteOnly Property StatusIndex() As Integer")
            'End Try
        End Set
    End Property

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        'Try
        If Len(txtMessage.Text) <> 0 Then
            lStrings.ProcessReplaceCommand(lStatus.ActiveIndex, eCommandTypes.cPRIVMSG, txtNickName.Text, txtMessage.Text)
            txtMessage.Text = ""
        End If
        'Catch ex As Exception
        'Throw ex
        'End Try
    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        'Try
        Me.Close()
        'Catch ex As Exception
        'Throw ex 
        'End Try
    End Sub

    Private Sub frmPrivateMessage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Try
        Me.Icon = mdiMain.Icon
        'Catch ex As Exception
        'Throw ex 
        'End Try
    End Sub
End Class