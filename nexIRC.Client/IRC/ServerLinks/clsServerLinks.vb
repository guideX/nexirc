Option Explicit On
Option Strict On
Imports nexIRC.Business.Controllers
'nexIRC 3.0.31
'05-30-2016 - guideX
Imports nexIRC.Models.Server
Imports nexIRC.Modules
Public Class clsServerLinks
    Private lStatusIndex As Integer
    Private lNetworkIndex As Integer
    Public Sub SetNetworkIndex(ByVal lIndex As Integer, _ComboBox As ComboBox)
        Try
            lNetworkIndex = lIndex
            _ComboBox.Text = lSettings.lNetworks.Networks(lIndex).Name
        Catch ex As Exception
            Throw 'ProcessError(ex.Message, "Public Sub SetNetworkIndex(ByVal lIndex As Integer)")
        End Try
    End Sub
    Public Sub SetStatusIndex(ByVal lIndex As Integer)
        Try
            lStatusIndex = lIndex
        Catch ex As Exception
            Throw 'ProcessError(ex.Message, "Public Sub SetStatusIndex(ByVal lIndex As Integer)")
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
            Throw 'ProcessError(ex.Message, "Public Sub AddToLinks(ByVal lServerIP As String, ByVal lPort As String)")
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
            Throw 'ProcessError(ex.Message, "Private Sub frmServerLinks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing")
        End Try
    End Sub
    Public Sub Form_Load(_Form As Form, _ComboBox As ComboBox, _ListView As ListView)
        Try
            Dim i As Integer
            _Form.Icon = mdiMain.Icon
            For i = 0 To lSettings.lNetworks.Networks.Count - 1
                With lSettings.lNetworks.Networks(i)
                    If Len(lSettings.lNetworks.Networks(i).Name) <> 0 Then
                        _ComboBox.Items.Add(.Name)
                    End If
                End With
            Next i
            With _ListView.Columns
                .Add("Server IP", 160)
                .Add("Port", 140)
            End With
        Catch ex As Exception
            Throw 'ProcessError(ex.Message, "Private Sub frmServerLinks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load")
        End Try
    End Sub
    Public Sub cmdOK_Click(form As Form, _ListView As ListView, _ComboBox As ComboBox)
        Dim mbox As MsgBoxResult, i As Integer, lItem As ListViewItem
        If (lSettings.lIRC.iSettings.sPrompts) Then
            mbox = MsgBox("Warning! You are about to add a range of servers to a network group via /LINKS command, are you sure you wish to proceed?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
        Else
            mbox = MsgBoxResult.Yes
        End If
        If (mbox = MsgBoxResult.Yes) Then
            For i = 0 To _ListView.Items.Count - 1
                lItem = _ListView.Items(i)
                If (lItem.Text.Length <> 0) Then
                    If (lItem.Checked) Then
                        Dim server As New ServerModel
                        server.Description = _ComboBox.Text & ": " & lItem.Text
                        server.Ip = lItem.Text
                        server.NetworkIndex = lSettings.FindNetworkIndex(_ComboBox.Text)
                        server.Port = Convert.ToInt64(Trim(lItem.SubItems(1).Text))
                        Using c As New ConnectionController(lSettings.lINI.iNetworks, lSettings.lINI.iServers)
                            c.CreateServer(server)
                        End Using
                    End If
                End If
            Next i
        End If
        form.Close()
    End Sub
    Public Sub cmdCancel_Click(_Form As Form)
        Try
            _Form.Close()
        Catch ex As Exception
            Throw 'ProcessError(ex.Message, "Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click")
        End Try
    End Sub
End Class