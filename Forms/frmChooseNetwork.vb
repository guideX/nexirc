'nexIRC 3.0.26
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows

Public Class frmChooseNetwork
    Public WithEvents lChooseNetwork As New clsChooseNetwork

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Try
            lChooseNetwork.cmdCancel_Click(Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmChooseNetwork_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            lChooseNetwork.Form_Load(cboNetworks, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        Try
            lChooseNetwork.cmdOK_Click(Me, cboNetworks.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class