'nexIRC 3.0.23
'02-27-2013 - guideX
Option Explicit On
Option Strict On

Public Class frmServerLinks
    Private lStatusIndex As Integer
    Private lNetworkIndex As Integer

    Public Sub SetNetworkIndex(ByVal lIndex As Integer)
        On Error Resume Next
        lNetworkIndex = lIndex
        cboNetworks.Text = lNetworks.nNetwork(lIndex).nDescription
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetNetworkIndex(ByVal lIndex As Integer)")
    End Sub

    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        On Error Resume Next
        lStatusIndex = lIndex
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
    End Sub

    Public Sub AddToLinks(ByVal lServerIP As String, ByVal lPort As String)
        On Error Resume Next
        Dim lItem As ListViewItem
        lItem = New ListViewItem
        lItem = lvwLinks.Items.Add(lServerIP)
        lItem.SubItems.Add(lPort)
        lItem.Checked = True
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Public Sub AddToLinks(ByVal lServerIP As String, ByVal lPort As String)")
    End Sub

    Private Sub frmServerLinks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        Dim i As Integer
        lStatus.ClearServerLinks(lStatusIndex)
        lStatus.SetLinksWindowsVisible(lStatusIndex, False)
        For i = 0 To lvwLinks.Items.Count - 1
            With lvwLinks.Items(i)
                lStatus.SaveServerLink(lStatusIndex, .Text, .SubItems(1).Text)
            End With
        Next i
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmServerLinks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
    End Sub

    Private Sub frmServerLinks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub frmServerLinks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error Resume Next
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
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error Resume Next
        Me.Close()
        'If Err.Number <> 0 Then 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
    End Sub
End Class
