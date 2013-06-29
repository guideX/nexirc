'nexIRC 3.0.23
'06-13-2013 - guideX

Option Explicit On
Option Strict On
'Imports FileIO.FileSystem

Public Class frmNotepad

    Private Sub frmNotepad_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            FileIO.FileSystem.WriteAllText(lINI.iNotepad, txtData.Text, False)
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmNotepad_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed")
        End Try
    End Sub

    Private Sub frmNotepad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtData.Text = FileIO.FileSystem.ReadAllText(lINI.iNotepad)
            Me.MdiParent = mdiMain
            Me.Icon = mdiMain.Icon
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmNotepad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub

    Private Sub frmNotepad_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            txtData.Width = Me.ClientSize.Width
            txtData.Height = Me.ClientSize.Height
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmNotepad_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize")
        End Try
    End Sub

    Private Sub txtData_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtData.TextChanged

    End Sub
End Class