<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatus2
    Inherits Telerik.WinControls.UI.RadForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RadCommandBar1 = New Telerik.WinControls.UI.RadCommandBar()
        Me.cbrConnection = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.CommandBarStripElement2 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdConnect = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdDisconnect = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdSep1 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.cmdChangeConnection = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdSep2 = New Telerik.WinControls.UI.CommandBarSeparator()
        Me.cmdChangeNickname = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdSendPrivMsg = New Telerik.WinControls.UI.CommandBarButton()
        Me.CommandBarButton1 = New Telerik.WinControls.UI.CommandBarButton()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadCommandBar1
        '
        Me.RadCommandBar1.AutoSize = True
        Me.RadCommandBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.RadCommandBar1.Name = "RadCommandBar1"
        Me.RadCommandBar1.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.cbrConnection})
        Me.RadCommandBar1.Size = New System.Drawing.Size(308, 30)
        Me.RadCommandBar1.TabIndex = 0
        Me.RadCommandBar1.Text = "RadCommandBar1"
        '
        'cbrConnection
        '
        Me.cbrConnection.DisplayName = Nothing
        Me.cbrConnection.MinSize = New System.Drawing.Size(25, 25)
        Me.cbrConnection.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1, Me.CommandBarStripElement2})
        '
        'CommandBarStripElement1
        '
        Me.CommandBarStripElement1.DisplayName = "CommandBarStripElement1"
        Me.CommandBarStripElement1.FloatingForm = Nothing
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdConnect, Me.cmdDisconnect, Me.cmdSep1, Me.cmdChangeConnection, Me.cmdSep2, Me.cmdChangeNickname, Me.cmdSendPrivMsg, Me.CommandBarButton1})
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Text = ""
        '
        'CommandBarStripElement2
        '
        Me.CommandBarStripElement2.DisplayName = "CommandBarStripElement2"
        Me.CommandBarStripElement2.FloatingForm = Nothing
        Me.CommandBarStripElement2.Name = "CommandBarStripElement2"
        Me.CommandBarStripElement2.Text = ""
        '
        'cmdConnect
        '
        Me.cmdConnect.AccessibleDescription = "Connect"
        Me.cmdConnect.AccessibleName = "Connect"
        Me.cmdConnect.DisplayName = "CommandBarButton1"
        Me.cmdConnect.Image = Global.nexIRC.My.Resources.Resources.network
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdConnect.VisibleInOverflowMenu = True
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.AccessibleDescription = "Disconnect"
        Me.cmdDisconnect.AccessibleName = "Disconnect"
        Me.cmdDisconnect.DisplayName = "CommandBarButton1"
        Me.cmdDisconnect.Image = Global.nexIRC.My.Resources.Resources.close
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.Text = "Disconnect"
        Me.cmdDisconnect.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdDisconnect.VisibleInOverflowMenu = True
        '
        'cmdSep1
        '
        Me.cmdSep1.AccessibleDescription = "CommandBarSeparator1"
        Me.cmdSep1.AccessibleName = "CommandBarSeparator1"
        Me.cmdSep1.DisplayName = "CommandBarSeparator1"
        Me.cmdSep1.Name = "cmdSep1"
        Me.cmdSep1.Text = ""
        Me.cmdSep1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdSep1.VisibleInOverflowMenu = False
        '
        'cmdChangeConnection
        '
        Me.cmdChangeConnection.AccessibleDescription = "Change Connection"
        Me.cmdChangeConnection.AccessibleName = "Change Connection"
        Me.cmdChangeConnection.DisplayName = "CommandBarButton1"
        Me.cmdChangeConnection.Image = Global.nexIRC.My.Resources.Resources.preferences
        Me.cmdChangeConnection.Name = "cmdChangeConnection"
        Me.cmdChangeConnection.Text = "Change Connection"
        Me.cmdChangeConnection.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdChangeConnection.VisibleInOverflowMenu = True
        '
        'cmdSep2
        '
        Me.cmdSep2.AccessibleDescription = "CommandBarSeparator2"
        Me.cmdSep2.AccessibleName = "CommandBarSeparator2"
        Me.cmdSep2.DisplayName = "CommandBarSeparator2"
        Me.cmdSep2.Name = "cmdSep2"
        Me.cmdSep2.Text = ""
        Me.cmdSep2.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdSep2.VisibleInOverflowMenu = False
        '
        'cmdChangeNickname
        '
        Me.cmdChangeNickname.AccessibleDescription = "Change Nickname"
        Me.cmdChangeNickname.AccessibleName = "Change Nickname"
        Me.cmdChangeNickname.DisplayName = "CommandBarButton1"
        Me.cmdChangeNickname.Image = Global.nexIRC.My.Resources.Resources.preferences
        Me.cmdChangeNickname.Name = "cmdChangeNickname"
        Me.cmdChangeNickname.Text = "Change Nickname"
        Me.cmdChangeNickname.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdChangeNickname.VisibleInOverflowMenu = True
        '
        'cmdSendPrivMsg
        '
        Me.cmdSendPrivMsg.AccessibleDescription = "Send Private Message"
        Me.cmdSendPrivMsg.AccessibleName = "Send Private Message"
        Me.cmdSendPrivMsg.DisplayName = "CommandBarButton1"
        Me.cmdSendPrivMsg.Image = Global.nexIRC.My.Resources.Resources.web
        Me.cmdSendPrivMsg.Name = "cmdSendPrivMsg"
        Me.cmdSendPrivMsg.Text = "Send Private Message"
        Me.cmdSendPrivMsg.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdSendPrivMsg.VisibleInOverflowMenu = True
        '
        'CommandBarButton1
        '
        Me.CommandBarButton1.AccessibleDescription = "SendNotice"
        Me.CommandBarButton1.AccessibleName = "SendNotice"
        Me.CommandBarButton1.DisplayName = "CommandBarButton1"
        Me.CommandBarButton1.Image = Global.nexIRC.My.Resources.Resources.web
        Me.CommandBarButton1.Name = "CommandBarButton1"
        Me.CommandBarButton1.Text = "SendNotice"
        Me.CommandBarButton1.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.CommandBarButton1.VisibleInOverflowMenu = True
        '
        'frmStatus2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 292)
        Me.Controls.Add(Me.RadCommandBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmStatus2"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Status"
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadCommandBar1 As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents cbrConnection As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents CommandBarStripElement2 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents cmdConnect As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdDisconnect As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdSep1 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents cmdChangeConnection As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdSep2 As Telerik.WinControls.UI.CommandBarSeparator
    Friend WithEvents cmdChangeNickname As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdSendPrivMsg As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents CommandBarButton1 As Telerik.WinControls.UI.CommandBarButton
End Class

