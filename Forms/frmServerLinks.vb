'nexIRC 3.0.23
'06-13-2013 - guideX
Option Explicit On
Option Strict On
Public Class frmServerLinks
    Private lStatusIndex As Integer
    Private lNetworkIndex As Integer

    Public Sub SetNetworkIndex(ByVal lIndex As Integer)
        Try
            lNetworkIndex = lIndex
            cboNetworks.Text = lNetworks.nNetwork(lIndex).nDescription
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetNetworkIndex(ByVal lIndex As Integer)")
        End Try
    End Sub

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        Try
            lStatusIndex = lIndex
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
        End Try
    End Sub

    Public Sub AddToLinks(ByVal lServerIP As String, ByVal lPort As String)
        Try
            Dim lItem As ListViewItem
            lItem = New ListViewItem
            lItem = lvwLinks.Items.Add(lServerIP)
            lItem.SubItems.Add(lPort)
            lItem.Checked = True
        Catch ex As Exception
            ProcessError(ex.Message, "Public Sub AddToLinks(ByVal lServerIP As String, ByVal lPort As String)")
        End Try
    End Sub

    Private Sub frmServerLinks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim i As Integer
            lStatus.ClearServerLinks(lStatusIndex)
            lStatus.SetLinksWindowsVisible(lStatusIndex, False)
            For i = 0 To lvwLinks.Items.Count - 1
                With lvwLinks.Items(i)
                    lStatus.SaveServerLink(lStatusIndex, .Text, .SubItems(1).Text)
                End With
            Next i
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmServerLinks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
        End Try
    End Sub

    Private Sub frmServerLinks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim i As Integer
            Me.Icon = mdiMain.Icon
            For i = 1 To lNetworks.nCount
                With lNetworks.nNetwork(i)
                    If Len(lNetworks.nNetwork(i).nDescription) <> 0 Then
                        cboNetworks.Items.Add(.nDescription)
                    End If
                End With
            Next i
            With lvwLinks.Columns
                .Add("Server IP", 160)
                .Add("Port", 140)
            End With
        Catch ex As Exception
            ProcessError(ex.Message, "Private Sub frmServerLinks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            Dim mbox As MsgBoxResult, i As Integer, lItem As ListViewItem
            If lIRC.iSettings.sPrompts = True Then
                mbox = MsgBox("Warning! You are about to add a range of servers to a network group via /LINKS command, are you sure you wish to proceed?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
            Else
                mbox = MsgBoxResult.Yes
            End If
            If mbox = MsgBoxResult.Yes Then
                For i = 0 To lvwLinks.Items.Count - 1
                    lItem = lvwLinks.Items(i)
                    If Len(lItem.Text) <> 0 Then
                        If lItem.Checked = True Then
                            AddServer(cboNetworks.Text & ": " & lItem.Text, lItem.Text, FindNetworkIndex(cboNetworks.Text), CLng(Trim(lItem.SubItems(1).Text)))
                        End If
                    End If
                Next i
            End If
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
