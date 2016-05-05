'nexIRC 3.0.30
'04-23-2016 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class frmQuerySettings
    Private Sub frmQuerySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim i As Integer
            Me.Icon = mdiMain.Icon
            With lSettings.lQuerySettings
                lStatus.SetListBoxToConnections(lstConnections)
                txtStandbyMessage.Text = .qStandByMessage
                txtDeclineMessage.Text = .qDeclineMessage
                chkPromptUser.Checked = .qPromptUser
                chkSpamFilter.Checked = .qEnableSpamFilter
                chkAutoShowWindow.Checked = .qAutoShowWindow
                Select Case .qAutoAllow
                    Case Settings.eQueryAutoAllow.qList
                        optAutoAllow1.Checked = True
                    Case Settings.eQueryAutoAllow.qEveryOne
                        optAutoAllow2.Checked = True
                    Case Settings.eQueryAutoAllow.qNoOne
                        optAutoAllow3.Checked = True
                End Select
                Select Case .qAutoDeny
                    Case Settings.eQueryAutoDeny.qList
                        optAutoDeny1.Checked = True
                    Case Settings.eQueryAutoDeny.qEveryOne
                        optAutoDeny2.Checked = True
                    Case Settings.eQueryAutoDeny.qNoOne
                        optAutoDeny3.Checked = True
                End Select
                For i = 1 To .qAutoAllowCount
                    lstAutoAllowList.Items.Add(.qAutoAllowList(i))
                Next i
                For i = 1 To .qAutoDenyCount
                    lstAutoDenyList.Items.Add(.qAutoDenyList(i))
                Next i
                For i = 1 To .qSpamPhraseCount
                    lstSpamPhrases.Items.Add(.qSpamPhrases(i))
                Next i
            End With
        Catch ex As Exception
            Throw 'ProcessError(ex.Message, "Private Sub frmSecureQuerySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub

    Private Sub cmdAddToAutoAllowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToAutoAllowList.Click
        Try
            Dim msg As String
            msg = InputBox("Add to Auto Allow List")
            If Len(msg) <> 0 Then lstAutoAllowList.Items.Add(msg)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdRemoveFromAutoAllowList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromAutoAllowList.Click
        Try
            lstAutoAllowList.Items.RemoveAt(lstAutoAllowList.SelectedIndex)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdAddToAutoDenyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToAutoDenyList.Click
        Try
            Dim msg As String
            msg = InputBox("Add to Auto Deny List")
            If Len(msg) <> 0 Then lstAutoDenyList.Items.Add(msg)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdRemoveFromAutoDenyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromAutoDenyList.Click
        Try
            lstAutoDenyList.Items.RemoveAt(lstAutoDenyList.SelectedIndex)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdClearLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLog.Click
        Try
            lstQueryLog.Items.Clear()
            txtQueryLog.Text = ""
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdAddToSpamPhrases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToSpamPhrases.Click
        Try
            Dim msg As String
            msg = InputBox("Add to Phrases")
            If Len(msg) <> 0 Then lstSpamPhrases.Items.Add(msg)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdRemoveFromSpamPhrases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromSpamPhrases.Click
        Try
            lstSpamPhrases.Items.RemoveAt(lstSpamPhrases.SelectedIndex)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try
            With lSettings.lQuerySettings
                Dim i As Integer, n As Integer
                For i = 0 To lstAutoAllowList.Items.Count - 1
                    If Len(lstAutoAllowList.Items(i)) <> 0 Then
                        n = n + 1
                        .qAutoAllowList(n) = lstAutoAllowList.Items(i).ToString
                    End If
                Next i
                .qAutoAllowCount = n
                n = 0
                For i = 0 To lstAutoDenyList.Items.Count - 1
                    If Len(lstAutoDenyList.Items(i)) <> 0 Then
                        n = n + 1
                        .qAutoDenyList(n) = lstAutoDenyList.Items(i).ToString
                    End If
                Next i
                .qAutoDenyCount = n
                n = 0
                For i = 0 To lstSpamPhrases.Items.Count - 1
                    If Len(lstSpamPhrases.Items(i)) <> 0 Then
                        n = n + 1
                        .qSpamPhrases(n) = lstSpamPhrases.Items(i).ToString
                    End If
                Next i
                .qSpamPhraseCount = n
                .qStandByMessage = txtStandbyMessage.Text
                .qDeclineMessage = txtDeclineMessage.Text
                .qAutoShowWindow = chkAutoShowWindow.Checked
                .qPromptUser = chkPromptUser.Checked
                .qEnableSpamFilter = chkSpamFilter.Checked
                If optAutoAllow1.Checked = True Then
                    .qAutoAllow = Settings.eQueryAutoAllow.qList
                ElseIf optAutoAllow2.Checked = True Then
                    .qAutoAllow = Settings.eQueryAutoAllow.qEveryOne
                ElseIf optAutoAllow3.Checked = True Then
                    .qAutoAllow = Settings.eQueryAutoAllow.qNoOne
                End If
                If optAutoDeny1.Checked = True Then
                    .qAutoDeny = Settings.eQueryAutoDeny.qList
                ElseIf optAutoDeny2.Checked = True Then
                    .qAutoDeny = Settings.eQueryAutoDeny.qEveryOne
                ElseIf optAutoDeny3.Checked = True Then
                    .qAutoDeny = Settings.eQueryAutoDeny.qNoOne
                End If
            End With
            Me.Close()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw
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
            Throw
        End Try
    End Sub

    Private Sub lstQueryLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstQueryLog.SelectedIndexChanged
        Try
            Dim i As Integer, n As Integer
            i = lStatus.FindByInitialText(lstConnections.Text)
            n = lStatus.PrivateMessage_Find(i, lstQueryLog.Text)
            'lStrings.DoColor(lStatus.PrivateMessage_IncomingText(i, n), txtQueryLog)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class