<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatus
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
        Me.components = New System.ComponentModel.Container()
        Me.txtIncoming = New Telerik.WinControls.RichTextBox.RadRichTextBox()
        Me.tspStatus = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdConnection = New Telerik.WinControls.UI.CommandBarDropDownButton()
        Me.cmdConnect = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdDisconnect = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.cmdSendNotice = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdNewPrivateMessage = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdListChannels = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdChangeNickname = New Telerik.WinControls.UI.CommandBarButton()
        Me.txtOutgoing = New Telerik.WinControls.UI.RadTextBox()
        Me.tmrWaitForLUsers = New System.Windows.Forms.Timer(Me.components)
        Me.tmrWaitForWhois = New System.Windows.Forms.Timer(Me.components)
        CType(Me.txtIncoming, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tspStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutgoing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIncoming
        '
        Me.txtIncoming.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncoming.Location = New System.Drawing.Point(0, 30)
        Me.txtIncoming.Name = "txtIncoming"
        Me.txtIncoming.Size = New System.Drawing.Size(300, 100)
        Me.txtIncoming.TabIndex = 0
        Me.txtIncoming.Text = "RadRichTextBox1"
        '
        'tspStatus
        '
        Me.tspStatus.AutoSize = True
        Me.tspStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.tspStatus.Location = New System.Drawing.Point(0, 0)
        Me.tspStatus.Name = "tspStatus"
        Me.tspStatus.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.tspStatus.Size = New System.Drawing.Size(304, 30)
        Me.tspStatus.TabIndex = 1
        Me.tspStatus.Text = "RadCommandBar1"
        '
        'CommandBarRowElement1
        '
        Me.CommandBarRowElement1.DisplayName = Nothing
        Me.CommandBarRowElement1.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement1.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1})
        '
        'CommandBarStripElement1
        '
        Me.CommandBarStripElement1.DisplayName = "CommandBarStripElement1"
        Me.CommandBarStripElement1.FloatingForm = Nothing
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdConnection, Me.cmdSendNotice, Me.cmdNewPrivateMessage, Me.cmdListChannels, Me.cmdChangeNickname})
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Text = ""
        '
        'cmdConnection
        '
        Me.cmdConnection.AccessibleDescription = "Connection"
        Me.cmdConnection.AccessibleName = "Connection"
        Me.cmdConnection.DisplayName = "CommandBarDropDownButton1"
        Me.cmdConnection.Image = Global.nexIRC.My.Resources.Resources.network
        Me.cmdConnection.Items.AddRange(New Telerik.WinControls.RadItem() {Me.cmdConnect, Me.cmdDisconnect})
        Me.cmdConnection.Name = "cmdConnection"
        Me.cmdConnection.Text = "Connection"
        Me.cmdConnection.ToolTipText = "Connect"
        Me.cmdConnection.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdConnection.VisibleInOverflowMenu = True
        '
        'cmdConnect
        '
        Me.cmdConnect.AccessibleDescription = "Connect"
        Me.cmdConnect.AccessibleName = "Connect"
        '
        '
        '
        Me.cmdConnect.ButtonElement.AccessibleDescription = "RadMenuButtonItem1"
        Me.cmdConnect.ButtonElement.AccessibleName = "RadMenuButtonItem1"
        Me.cmdConnect.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.AccessibleDescription = "Disconnect"
        Me.cmdDisconnect.AccessibleName = "Disconnect"
        '
        '
        '
        Me.cmdDisconnect.ButtonElement.AccessibleDescription = "Disconnect"
        Me.cmdDisconnect.ButtonElement.AccessibleName = "Disconnect"
        Me.cmdDisconnect.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.Text = "Disconnect"
        Me.cmdDisconnect.Visibility = Telerik.WinControls.ElementVisibility.Visible
        '
        'cmdSendNotice
        '
        Me.cmdSendNotice.AccessibleDescription = "Send Notice"
        Me.cmdSendNotice.AccessibleName = "Send Notice"
        Me.cmdSendNotice.DisplayName = "CommandBarButton1"
        Me.cmdSendNotice.Image = Global.nexIRC.My.Resources.Resources.forward
        Me.cmdSendNotice.Name = "cmdSendNotice"
        Me.cmdSendNotice.Text = "Send Notice"
        Me.cmdSendNotice.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdSendNotice.VisibleInOverflowMenu = True
        '
        'cmdNewPrivateMessage
        '
        Me.cmdNewPrivateMessage.AccessibleDescription = "Private Message"
        Me.cmdNewPrivateMessage.AccessibleName = "Private Message"
        Me.cmdNewPrivateMessage.DisplayName = "CommandBarButton1"
        Me.cmdNewPrivateMessage.Image = Global.nexIRC.My.Resources.Resources.user
        Me.cmdNewPrivateMessage.Name = "cmdNewPrivateMessage"
        Me.cmdNewPrivateMessage.Text = "Private Message"
        Me.cmdNewPrivateMessage.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdNewPrivateMessage.VisibleInOverflowMenu = True
        '
        'cmdListChannels
        '
        Me.cmdListChannels.AccessibleDescription = "List Channels"
        Me.cmdListChannels.AccessibleName = "List Channels"
        Me.cmdListChannels.DisplayName = "CommandBarButton1"
        Me.cmdListChannels.Image = Global.nexIRC.My.Resources.Resources.edit__1_
        Me.cmdListChannels.Name = "cmdListChannels"
        Me.cmdListChannels.Text = "List Channels"
        Me.cmdListChannels.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdListChannels.VisibleInOverflowMenu = True
        '
        'cmdChangeNickname
        '
        Me.cmdChangeNickname.AccessibleDescription = "Change Nickname"
        Me.cmdChangeNickname.AccessibleName = "Change Nickname"
        Me.cmdChangeNickname.DisplayName = "CommandBarButton1"
        Me.cmdChangeNickname.Image = Global.nexIRC.My.Resources.Resources.tools
        Me.cmdChangeNickname.Name = "cmdChangeNickname"
        Me.cmdChangeNickname.Text = "Change Nickname"
        Me.cmdChangeNickname.ToolTipText = "Change Nickname"
        Me.cmdChangeNickname.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdChangeNickname.VisibleInOverflowMenu = True
        '
        'txtOutgoing
        '
        Me.txtOutgoing.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 136)
        Me.txtOutgoing.Margin = New System.Windows.Forms.Padding(0)
        Me.txtOutgoing.Name = "txtOutgoing"
        Me.txtOutgoing.Size = New System.Drawing.Size(300, 20)
        Me.txtOutgoing.TabIndex = 2
        Me.txtOutgoing.TabStop = False
        '
        'frmStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 191)
        Me.Controls.Add(Me.txtOutgoing)
        Me.Controls.Add(Me.tspStatus)
        Me.Controls.Add(Me.txtIncoming)
        Me.Name = "frmStatus"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = False
        Me.Text = "Status"
        CType(Me.txtIncoming, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tspStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOutgoing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIncoming As Telerik.WinControls.RichTextBox.RadRichTextBox
    Friend WithEvents tspStatus As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents txtOutgoing As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents tmrWaitForLUsers As System.Windows.Forms.Timer
    Friend WithEvents tmrWaitForWhois As System.Windows.Forms.Timer
    Friend WithEvents cmdConnection As Telerik.WinControls.UI.CommandBarDropDownButton
    Friend WithEvents cmdSendNotice As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdConnect As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdDisconnect As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents cmdNewPrivateMessage As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdListChannels As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdChangeNickname As Telerik.WinControls.UI.CommandBarButton
End Class

