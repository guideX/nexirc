'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports nexIRC.clsCommandTypes

Public Class clsSendNoticeUI
    Private lStatusIndex As Integer
    Public WriteOnly Property StatusIndex() As Integer
        Set(_StatusIndex As Integer)
            Try
                lStatusIndex = _StatusIndex
            Catch ex As Exception
                ProcessError(ex.Message, "Public WriteOnly Property StatusIndex() As Integer")
            End Try
        End Set
    End Property
    Public Sub cmdOK_Click(_MessageTextBox As TextBox, _NickNameTextBox As TextBox)
        Try
            If Len(_MessageTextBox.Text) <> 0 Then
                ProcessReplaceCommand(lStatus.ActiveIndex, eCommandTypes.cNOTICE, _NickNameTextBox.Text, _MessageTextBox.Text)
                _MessageTextBox.Text = ""
            End If
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click")
        End Try
    End Sub
    Public Sub cmdCancel_Click(_Form As Form)
        Try
            _Form.Close()
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub
    Public Sub Form_Load(_Form As Form)
        Try
            _Form.Icon = mdiMain.Icon
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmPrivateMessage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
End Class