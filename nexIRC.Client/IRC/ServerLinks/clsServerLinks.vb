Option Explicit On
Option Strict On
Namespace nexIRC.Client.IRC.ServerLinks
    Public Class clsServerLinks
        Private lStatusIndex As Integer
        Private lNetworkIndex As Integer

        Public Sub SetNetworkIndex(ByVal lIndex As Integer, _ComboBox As ComboBox)
            lNetworkIndex = lIndex
            Dim networks = Modules.IrcSettings.IrcNetworks.Get()
        End Sub

        Public Sub SetStatusIndex(ByVal lIndex As Integer)
            lStatusIndex = lIndex
        End Sub

        Public Sub AddToLinks(ByVal lServerIP As String, ByVal lPort As String, _ListView As ListView)
            Dim lItem As ListViewItem
            lItem = New ListViewItem
            lItem = _ListView.Items.Add(lServerIP)
            lItem.SubItems.Add(lPort)
            lItem.Checked = True
        End Sub

        Public Sub frmServerLinks_FormClosing(_ListView As ListView)
            Dim i As Integer
            Modules.lStatus.ClearServerLinks(lStatusIndex)
            Modules.lStatus.SetLinksWindowsVisible(lStatusIndex, False)
            For i = 0 To _ListView.Items.Count - 1
                With _ListView.Items(i)
                    Modules.lStatus.SaveServerLink(lStatusIndex, .Text, .SubItems(1).Text)
                End With
            Next i
        End Sub

        Public Sub Form_Load(_Form As Form, _ComboBox As ComboBox, _ListView As ListView)
            _Form.Icon = mdiMain.Icon
            Modules.lSettings.FillComboWithNetworks(_ComboBox)
            With _ListView.Columns
                .Add("Server IP", 160)
                .Add("Port", 140)
            End With
        End Sub

        Public Sub cmdOK_Click(_Form As Form, _ListView As ListView, _ComboBox As ComboBox)
            Dim mbox As MsgBoxResult, i As Integer, lItem As ListViewItem
            If Modules.lSettings.lIRC.iSettings.sPrompts = True Then
                mbox = MsgBox("Warning! You are about to add a range of servers to a network group via /LINKS command, are you sure you wish to proceed?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
            Else
                mbox = MsgBoxResult.Yes
            End If
            If mbox = MsgBoxResult.Yes Then
                For i = 0 To _ListView.Items.Count - 1
                    lItem = _ListView.Items(i)
                    If Len(lItem.Text) <> 0 Then
                        If lItem.Checked = True Then
                            'lSettings.AddServer(_ComboBox.Text & ": " & lItem.Text, lItem.Text, Modules.lSettings.FindNetworkIndex(_ComboBox.Text), Convert.ToInt64(Trim(lItem.SubItems(1).Text)))
                            Modules.lSettings.AddServer(_ComboBox.Text & ": " & lItem.Text, lItem.Text, Modules.IrcSettings.IrcNetworks.Find(_ComboBox.Text).ID, Convert.ToInt64(Trim(lItem.SubItems(1).Text)))

                        End If
                    End If
                Next i
            End If
            _Form.Close()
        End Sub

        Public Sub cmdCancel_Click(_Form As Form)
            _Form.Close()
        End Sub
    End Class
End Namespace