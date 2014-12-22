'nexIRC 3.0.31
'Sunday, Oct 4th, 2014 - guideX
Option Explicit On
Option Strict On
Imports nexIRC.Modules
Public Class clsServerLinks
    Private lStatusIndex As Integer
    Private lNetworkIndex As Integer
    Public Sub SetNetworkIndex(ByVal lIndex As Integer, _ComboBox As ComboBox)
        Try
            lNetworkIndex = lIndex
            _ComboBox.Text = lSettings.lNetworks.nNetwork(lIndex).nDescription
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub SetNetworkIndex(ByVal lIndex As Integer)")
        End Try
    End Sub
    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        Try
            lStatusIndex = lIndex
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
        End Try
    End Sub
    Public Sub AddToLinks(ByVal lServerIP As String, ByVal lPort As String, _ListView As ListView)
        Try
            Dim lItem As ListViewItem
            lItem = New ListViewItem
            lItem = _ListView.Items.Add(lServerIP)
            lItem.SubItems.Add(lPort)
            lItem.Checked = True
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Public Sub AddToLinks(ByVal lServerIP As String, ByVal lPort As String)")
        End Try
    End Sub
    Public Sub frmServerLinks_FormClosing(_ListView As ListView)
        Try
            Dim i As Integer
            lStatus.ClearServerLinks(lStatusIndex)
            lStatus.SetLinksWindowsVisible(lStatusIndex, False)
            For i = 0 To _ListView.Items.Count - 1
                With _ListView.Items(i)
                    lStatus.SaveServerLink(lStatusIndex, .Text, .SubItems(1).Text)
                End With
            Next i
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub frmServerLinks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
        End Try
    End Sub
    Public Sub Form_Load(_Form As Form, _ComboBox As ComboBox, _ListView As ListView)
        Try
            Dim i As Integer
            _Form.Icon = mdiMain.Icon
            For i = 1 To lSettings.lNetworks.nCount
                With lSettings.lNetworks.nNetwork(i)
                    If Len(lSettings.lNetworks.nNetwork(i).nDescription) <> 0 Then
                        _ComboBox.Items.Add(.nDescription)
                    End If
                End With
            Next i
            With _ListView.Columns
                .Add("Server IP", 160)
                .Add("Port", 140)
            End With
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub frmServerLinks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
    Public Sub cmdOK_Click(_Form As Form, _ListView As ListView, _ComboBox As ComboBox)
        Try
            Dim mbox As MsgBoxResult, i As Integer, lItem As ListViewItem
            If lSettings.lIRC.iSettings.sPrompts = True Then
                mbox = MsgBox("Warning! You are about to add a range of servers to a network group via /LINKS command, are you sure you wish to proceed?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
            Else
                mbox = MsgBoxResult.Yes
            End If
            If mbox = MsgBoxResult.Yes Then
                For i = 0 To _ListView.Items.Count - 1
                    lItem = _ListView.Items(i)
                    If Len(lItem.Text) <> 0 Then
                        If lItem.Checked = True Then
                            lSettings.AddServer(_ComboBox.Text & ": " & lItem.Text, lItem.Text, lSettings.FindNetworkIndex(_ComboBox.Text), Convert.ToInt64(Trim(lItem.SubItems(1).Text)))
                        End If
                    End If
                Next i
            End If
            _Form.Close()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click")
        End Try
    End Sub
    Public Sub cmdCancel_Click(_Form As Form)
        Try
            _Form.Close()
        Catch ex As Exception
            Throw ex 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub
End Class