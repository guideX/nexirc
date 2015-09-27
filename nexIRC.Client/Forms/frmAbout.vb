'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.IRC.UtilityWindows
Imports Telerik.WinControls
Imports Telerik.WinControls.UI

Public Class frmAbout
    Private WithEvents lAbout As New clsAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lAbout.Form_Load(Me, Me.RadPageView1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class