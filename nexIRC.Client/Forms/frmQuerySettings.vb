Option Explicit On
Option Strict On
'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Imports nexIRC.Business.Repositories
Imports nexIRC.Client.nexIRC.Client

Public Class frmQuerySettings
    Private Sub frmQuerySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Me.Icon = mdiMain.Icon
        'With Modules.lSettings.lQuerySettings
        Dim data = Modules.IrcSettings.QuerySettings.Get()
        With data
            Modules.lStatus.SetListBoxToConnections(lstConnections)
            txtStandbyMessage.Text = .StandByMessage
            txtDeclineMessage.Text = .DeclineMessage
            chkPromptUser.Checked = .PromptUser
            chkSpamFilter.Checked = .EnableSpamFilter
            chkAutoShowWindow.Checked = .AutoShowWindow
            Select Case .AutoAllow
                Case QueryPermission.List
                    optAutoAllow1.Checked = True
                Case QueryPermission.EveryOne
                    optAutoAllow2.Checked = True
                Case QueryPermission.NoOne
                    optAutoAllow3.Checked = True
            End Select
            Select Case .AutoDeny
                Case QueryPermission.List
                    optAutoDeny1.Checked = True
                Case QueryPermission.EveryOne
                    optAutoDeny2.Checked = True
                Case QueryPermission.NoOne
                    optAutoDeny3.Checked = True
            End Select
            For i = 0 To .AutoAllowList.Count() - 1
                If (Not String.IsNullOrEmpty(.AutoAllowList(i))) Then
                    lstAutoAllowList.Items.Add(.AutoAllowList(i))
                End If
            Next i
            For i = 0 To .AutoDenyList.Count() - 1
                If (Not String.IsNullOrEmpty(.AutoDenyList(i))) Then
                    lstAutoDenyList.Items.Add(.AutoDenyList(i))
                End If
            Next i
            For i = 0 To .SpamPhrases.Count() - 1
                If (Not String.IsNullOrEmpty(.SpamPhrases(i))) Then
                    lstSpamPhrases.Items.Add(.SpamPhrases(i))
                End If
            Next i
            Modules.IrcSettings.QuerySettings.Save(data)
        End With
    End Sub

    Private Sub cmdAddToAutoAllowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToAutoAllowList.Click
        'Try
            Dim msg As String
            msg = InputBox("Add to Auto Allow List")
            If Len(msg) <> 0 Then lstAutoAllowList.Items.Add(msg)
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub cmdRemoveFromAutoAllowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromAutoAllowList.Click
        'Try
            lstAutoAllowList.Items.RemoveAt(lstAutoAllowList.SelectedIndex)
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub cmdAddToAutoDenyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToAutoDenyList.Click
        'Try
            Dim msg As String
            msg = InputBox("Add to Auto Deny List")
            If Len(msg) <> 0 Then lstAutoDenyList.Items.Add(msg)
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub cmdRemoveFromAutoDenyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromAutoDenyList.Click
        'Try
            lstAutoDenyList.Items.RemoveAt(lstAutoDenyList.SelectedIndex)
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub cmdClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLog.Click
        'Try
            lstQueryLog.Items.Clear()
            txtQueryLog.Text = ""
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub cmdAddToSpamPhrases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToSpamPhrases.Click
        'Try
            Dim msg As String
            msg = InputBox("Add to Phrases")
            If Len(msg) <> 0 Then lstSpamPhrases.Items.Add(msg)
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub cmdRemoveFromSpamPhrases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromSpamPhrases.Click
        'Try
            lstSpamPhrases.Items.RemoveAt(lstSpamPhrases.SelectedIndex)
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'Try
            Dim querySettings = Modules.IrcSettings.QuerySettings.Get()
            With querySettings
                .AutoAllowList = New List(Of String)
                .AutoDenyList = New List(Of String)
                .SpamPhrases = New List(Of String)
                Dim i As Integer ', n As Integer
                For i = 0 To lstAutoAllowList.Items.Count - 1
                    If (Not String.IsNullOrEmpty(lstAutoAllowList.Items.Item(i).ToString())) Then
                        .AutoAllowList.Add(lstAutoAllowList.Items(i).ToString)
                    End If
                Next i
                For i = 0 To lstAutoDenyList.Items.Count - 1
                    If (Not String.IsNullOrEmpty(lstAutoDenyList.Items(i).ToString())) Then
                        .AutoDenyList.Add(lstAutoDenyList.Items(i).ToString)
                    End If
                Next i
                For i = 0 To lstSpamPhrases.Items.Count - 1
                    If (Not String.IsNullOrEmpty(lstSpamPhrases.Items(i).ToString())) Then
                        .SpamPhrases.Add(lstSpamPhrases.Items(i).ToString)
                    End If
                Next i
                .StandByMessage = txtStandbyMessage.Text
                .DeclineMessage = txtDeclineMessage.Text
                .AutoShowWindow = chkAutoShowWindow.Checked
                .PromptUser = chkPromptUser.Checked
                .EnableSpamFilter = chkSpamFilter.Checked
                If optAutoAllow1.Checked = True Then
                    .AutoAllow = QueryPermission.List
                ElseIf optAutoAllow2.Checked = True Then
                    .AutoAllow = QueryPermission.EveryOne
                ElseIf optAutoAllow3.Checked = True Then
                    .AutoAllow = QueryPermission.NoOne
                End If
                If optAutoDeny1.Checked = True Then
                    .AutoDeny = QueryPermission.List
                ElseIf optAutoDeny2.Checked = True Then
                    .AutoDeny = QueryPermission.EveryOne
                ElseIf optAutoDeny3.Checked = True Then
                    .AutoDeny = QueryPermission.NoOne
                End If
            End With
            Me.Close()
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        'Try
            Me.Close()
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub lstConnections_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstConnections.SelectedIndexChanged
        'Try
            Dim i As Integer
            txtQueryLog.Text = ""
            lstQueryLog.Items.Clear()
            i = Modules.lStatus.FindByInitialText(lstConnections.Text)
            If i <> 0 Then Modules.lStatus.PrivateMessage_SetListBox(i, lstQueryLog)
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub lstQueryLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstQueryLog.SelectedIndexChanged
        'Try
            Dim i As Integer, n As Integer
            i = Modules.lStatus.FindByInitialText(lstConnections.Text)
            n = Modules.lStatus.PrivateMessage_Find(i, lstQueryLog.Text)
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        'Try
            Me.Close()
        'Catch ex As Exception
            'Throw ex
        'End Try
    End Sub
End Class