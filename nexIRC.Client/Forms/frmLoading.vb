Public Class FrmLoading
    Private Sub FrmLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "nexIRC - v" & Application.ProductVersion
        Me.Visible = True
        Me.Width = 316
        Me.Height = 116
    End Sub
    Public Sub SetProgress(ByVal lData As String, ByVal lValue As Integer)
        'Try
            lblStatus.Text = lData
            prgLoading.Step = lValue
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub
End Class