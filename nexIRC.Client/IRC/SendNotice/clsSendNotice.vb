'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Imports nexIRC.clsCommandTypes
Imports nexIRC.Business.Enums

Public Class clsSendNoticeUI
    Private lStatusIndex As Integer
    Public WriteOnly Property StatusIndex() As Integer
        Set(ByVal _StatusIndex As Integer)
            Try
                lStatusIndex = _StatusIndex
            Catch ex As Exception
                Throw ex 'ProcessError(ex.Message, "Public WriteOnly Property StatusIndex() As Integer")
            End Try
        End Set
    End Property
    Public Sub cmdOK_Click(ByVal _MessageTextBox As TextBox, ByVal _NickNameTextBox As TextBox)
        Try
            If Len(_MessageTextBox.Text) <> 0 Then
                lStrings.ProcessReplaceCommand(lStatus.ActiveIndex, IrcCommandTypes.cNOTICE, _NickNameTextBox.Text, _MessageTextBox.Text)
                _MessageTextBox.Text = ""
            End If
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click")
        End Try
    End Sub
    Public Sub cmdCancel_Click(ByVal _Form As Form)
        Try
            _Form.Close()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub
    Public Sub Form_Load(ByVal _Form As Form)
        Try
            _Form.Icon = mdiMain.Icon
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub frmPrivateMessage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
End Class