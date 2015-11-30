Option Explicit On
Option Strict On
Imports nexIRC.Business.Enums
Namespace nexIRC.Client.IRC.SendNotice
    Public Class clsSendNoticeUI
        Private lStatusIndex As Integer

        Public WriteOnly Property StatusIndex() As Integer
            Set(ByVal _StatusIndex As Integer)
                lStatusIndex = _StatusIndex
            End Set
        End Property

        Public Sub cmdOK_Click(ByVal _MessageTextBox As TextBox, ByVal _NickNameTextBox As TextBox)
            If Len(_MessageTextBox.Text) <> 0 Then
                Modules.lStrings.ProcessReplaceCommand(Modules.lStatus.ActiveIndex, IrcCommandTypes.cNOTICE, _NickNameTextBox.Text, _MessageTextBox.Text)
                _MessageTextBox.Text = ""
            End If
        End Sub

        Public Sub cmdCancel_Click(ByVal _Form As Form)
            _Form.Close()
        End Sub

        Public Sub Form_Load(ByVal _Form As Form)
            _Form.Icon = mdiMain.Icon
        End Sub
    End Class
End Namespace