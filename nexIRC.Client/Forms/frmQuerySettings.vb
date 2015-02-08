'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmQuerySettings
    Private Sub frmQuerySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim i As Integer
            Me.Icon = mdiMain.Icon
            'With lSettings.lQuerySettings
            Dim data = Modules.IrcSettings.QuerySettings.Get()
            With data
                lStatus.SetListBoxToConnections(lstConnections)
                txtStandbyMessage.Text = .StandByMessage
                txtDeclineMessage.Text = .DeclineMessage
                chkPromptUser.Checked = .PromptUser
                chkSpamFilter.Checked = .EnableSpamFilter
                chkAutoShowWindow.Checked = .AutoShowWindow
                Select Case .AutoAllow
                    Case IrcSettings.QueryPermission.List
                        optAutoAllow1.Checked = True
                    Case IrcSettings.QueryPermission.EveryOne
                        optAutoAllow2.Checked = True
                    Case IrcSettings.QueryPermission.NoOne
                        optAutoAllow3.Checked = True
                End Select
                Select Case .AutoDeny
                    Case IrcSettings.QueryPermission.List
                        optAutoDeny1.Checked = True
                    Case IrcSettings.QueryPermission.EveryOne
                        optAutoDeny2.Checked = True
                    Case IrcSettings.QueryPermission.NoOne
                        optAutoDeny3.Checked = True
                End Select
                For i = 1 To .AutoAllowCount
                    lstAutoAllowList.Items.Add(.AutoAllowList(i))
                Next i
                For i = 1 To .AutoDenyCount
                    lstAutoDenyList.Items.Add(.AutoDenyList(i))
                Next i
                For i = 1 To .SpamPhraseCount
                    lstSpamPhrases.Items.Add(.SpamPhrases(i))
                Next i
                Modules.IrcSettings.QuerySettings.Save(data)
            End With
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub frmSecureQuerySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub

    Private Sub cmdAddToAutoAllowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToAutoAllowList.Click
        Try
            Dim msg As String
            msg = InputBox("Add to Auto Allow List")
            If Len(msg) <> 0 Then lstAutoAllowList.Items.Add(msg)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdRemoveFromAutoAllowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromAutoAllowList.Click
        Try
            lstAutoAllowList.Items.RemoveAt(lstAutoAllowList.SelectedIndex)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdAddToAutoDenyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToAutoDenyList.Click
        Try
            Dim msg As String
            msg = InputBox("Add to Auto Deny List")
            If Len(msg) <> 0 Then lstAutoDenyList.Items.Add(msg)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdRemoveFromAutoDenyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromAutoDenyList.Click
        Try
            lstAutoDenyList.Items.RemoveAt(lstAutoDenyList.SelectedIndex)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLog.Click
        Try
            lstQueryLog.Items.Clear()
            txtQueryLog.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdAddToSpamPhrases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToSpamPhrases.Click
        Try
            Dim msg As String
            msg = InputBox("Add to Phrases")
            If Len(msg) <> 0 Then lstSpamPhrases.Items.Add(msg)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdRemoveFromSpamPhrases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromSpamPhrases.Click
        Try
            lstSpamPhrases.Items.RemoveAt(lstSpamPhrases.SelectedIndex)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            'With lSettings.lQuerySettings
            With Modules.IrcSettings.QuerySettings.Get()
                Dim i As Integer, n As Integer
                For i = 0 To lstAutoAllowList.Items.Count - 1
                    If Len(lstAutoAllowList.Items(i)) <> 0 Then
                        n = n + 1
                        .AutoAllowList(n) = lstAutoAllowList.Items(i).ToString
                    End If
                Next i
                .AutoAllowCount = n
                n = 0
                For i = 0 To lstAutoDenyList.Items.Count - 1
                    If Len(lstAutoDenyList.Items(i)) <> 0 Then
                        n = n + 1
                        .AutoDenyList(n) = lstAutoDenyList.Items(i).ToString
                    End If
                Next i
                .AutoDenyCount = n
                n = 0
                For i = 0 To lstSpamPhrases.Items.Count - 1
                    If Len(lstSpamPhrases.Items(i)) <> 0 Then
                        n = n + 1
                        .SpamPhrases(n) = lstSpamPhrases.Items(i).ToString
                    End If
                Next i
                .SpamPhraseCount = n
                .StandByMessage = txtStandbyMessage.Text
                .DeclineMessage = txtDeclineMessage.Text
                .AutoShowWindow = chkAutoShowWindow.Checked
                .PromptUser = chkPromptUser.Checked
                .EnableSpamFilter = chkSpamFilter.Checked
                If optAutoAllow1.Checked = True Then
                    .AutoAllow = IrcSettings.QueryPermission.List
                ElseIf optAutoAllow2.Checked = True Then
                    .AutoAllow = IrcSettings.QueryPermission.EveryOne
                ElseIf optAutoAllow3.Checked = True Then
                    .AutoAllow = IrcSettings.QueryPermission.NoOne
                End If
                If optAutoDeny1.Checked = True Then
                    .AutoDeny = IrcSettings.QueryPermission.List
                ElseIf optAutoDeny2.Checked = True Then
                    .AutoDeny = IrcSettings.QueryPermission.EveryOne
                ElseIf optAutoDeny3.Checked = True Then
                    .AutoDeny = IrcSettings.QueryPermission.NoOne
                End If
            End With
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lstConnections_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstConnections.SelectedIndexChanged
        Try
            Dim i As Integer
            txtQueryLog.Text = ""
            lstQueryLog.Items.Clear()
            i = lStatus.FindByInitialText(lstConnections.Text)
            If i <> 0 Then lStatus.PrivateMessage_SetListBox(i, lstQueryLog)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub lstQueryLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstQueryLog.SelectedIndexChanged
        Try
            Dim i As Integer, n As Integer
            i = lStatus.FindByInitialText(lstConnections.Text)
            n = lStatus.PrivateMessage_Find(i, lstQueryLog.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class