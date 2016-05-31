Option Explicit On
Option Strict On
'nexIRC 3.0.31
'05-30-2016 - guideX
Imports nexIRC.Enum
Imports nexIRC.Modules
Public Class frmQuerySettings
    Private Sub frmQuerySettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        Me.Icon = mdiMain.Icon
        With lSettings.lQuerySettings
            lStatus.SetListBoxToConnections(lstConnections)
            txtStandbyMessage.Text = .StandByMessage
            txtDeclineMessage.Text = .DeclineMessage
            chkPromptUser.Checked = .PromptUser
            chkSpamFilter.Checked = .EnableSpamFilter
            chkAutoShowWindow.Checked = .AutoShowWindow
            Select Case .AutoAllow
                Case QueryOption.List
                    optAutoAllow1.Checked = True
                Case QueryOption.Everyone
                    optAutoAllow2.Checked = True
                Case QueryOption.NoOne
                    optAutoAllow3.Checked = True
            End Select
            Select Case .AutoDeny
                Case QueryOption.List
                    optAutoDeny1.Checked = True
                Case QueryOption.Everyone
                    optAutoDeny2.Checked = True
                Case QueryOption.NoOne
                    optAutoDeny3.Checked = True
            End Select
            For i = 1 To .AutoAllowList.Count
                lstAutoAllowList.Items.Add(.AutoAllowList(i))
            Next i
            For i = 1 To .AutoDenyList.Count
                lstAutoDenyList.Items.Add(.AutoDenyList(i))
            Next i
            For i = 1 To .SpamPhrases.Count
                lstSpamPhrases.Items.Add(.SpamPhrases(i))
            Next i
        End With
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
        With lSettings.lQuerySettings
            .AutoAllowList = New List(Of String)
            .AutoDenyList = New List(Of String)
            .SpamPhrases = New List(Of String)
            For i As Integer = 0 To lstAutoAllowList.Items.Count - 1
                If (Not String.IsNullOrEmpty(lstAutoAllowList.Items(i).ToString)) Then
                    .AutoAllowList.Add(lstAutoAllowList.Items(i).ToString)
                End If
            Next i
            For i As Integer = 0 To lstAutoDenyList.Items.Count - 1
                If (Not String.IsNullOrEmpty(lstAutoDenyList.Items(i).ToString)) Then
                    .AutoDenyList.Add(lstAutoDenyList.Items(i).ToString)
                End If
            Next i
            For i As Integer = 0 To lstSpamPhrases.Items.Count - 1
                If (Not String.IsNullOrEmpty(lstSpamPhrases.Items(i).ToString)) Then
                    .SpamPhrases.Add(lstSpamPhrases.Items(i).ToString)
                End If
            Next i
            .StandByMessage = txtStandbyMessage.Text
            .DeclineMessage = txtDeclineMessage.Text
            .AutoShowWindow = chkAutoShowWindow.Checked
            .PromptUser = chkPromptUser.Checked
            .EnableSpamFilter = chkSpamFilter.Checked
            If optAutoAllow1.Checked = True Then
                .AutoAllow = QueryOption.List
            ElseIf optAutoAllow2.Checked = True Then
                .AutoAllow = QueryOption.Everyone
            ElseIf optAutoAllow3.Checked = True Then
                .AutoAllow = QueryOption.NoOne
            End If
            If optAutoDeny1.Checked = True Then
                .AutoDeny = QueryOption.List
            ElseIf optAutoDeny2.Checked = True Then
                .AutoDeny = QueryOption.Everyone
            ElseIf optAutoDeny3.Checked = True Then
                .AutoDeny = QueryOption.NoOne
            End If
        End With
        Me.Close()
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