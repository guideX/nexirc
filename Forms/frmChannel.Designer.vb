<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChannel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChannel))
        Me.txtOutgoing = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIncoming = New Telerik.WinControls.RichTextBox.RadRichTextBox()
        Me.tspChannel = New Telerik.WinControls.UI.RadCommandBar()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdPart = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdHide = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdNotice = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdAddToChannelFolder = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdNames = New Telerik.WinControls.UI.CommandBarButton()
        Me.lvwNicklist = New Telerik.WinControls.UI.RadListView()
        Me.tmrGetNames = New System.Windows.Forms.Timer(Me.components)
        CType(Me.txtOutgoing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIncoming, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tspChannel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lvwNicklist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtOutgoing
        '
        Me.txtOutgoing.AcceptsReturn = True
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 230)
        Me.txtOutgoing.Multiline = True
        Me.txtOutgoing.Name = "txtOutgoing"
        '
        '
        '
        Me.txtOutgoing.RootElement.StretchVertically = True
        Me.txtOutgoing.Size = New System.Drawing.Size(583, 20)
        Me.txtOutgoing.TabIndex = 0
        Me.txtOutgoing.TabStop = False
        '
        'txtIncoming
        '
        Me.txtIncoming.ForeColor = System.Drawing.Color.White
        Me.txtIncoming.Location = New System.Drawing.Point(0, 30)
        Me.txtIncoming.Name = "txtIncoming"
        '
        '
        '
        Me.txtIncoming.RootElement.ForeColor = System.Drawing.Color.White
        Me.txtIncoming.Size = New System.Drawing.Size(457, 200)
        Me.txtIncoming.TabIndex = 1
        Me.txtIncoming.Text = "RadRichTextBox1"
        '
        'tspChannel
        '
        Me.tspChannel.AutoSize = True
        Me.tspChannel.Dock = System.Windows.Forms.DockStyle.Top
        Me.tspChannel.ImageList = Me.ImageList1
        Me.tspChannel.Location = New System.Drawing.Point(0, 0)
        Me.tspChannel.Name = "tspChannel"
        Me.tspChannel.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.tspChannel.Size = New System.Drawing.Size(583, 30)
        Me.tspChannel.TabIndex = 2
        Me.tspChannel.Text = "RadCommandBar1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "close.png")
        Me.ImageList1.Images.SetKeyName(1, "delete.png")
        Me.ImageList1.Images.SetKeyName(2, "announce.png")
        Me.ImageList1.Images.SetKeyName(3, "add.png")
        Me.ImageList1.Images.SetKeyName(4, "user.png")
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
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdPart, Me.cmdHide, Me.cmdNotice, Me.cmdAddToChannelFolder, Me.cmdNames})
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Text = ""
        '
        'cmdPart
        '
        Me.cmdPart.AccessibleDescription = "Part"
        Me.cmdPart.AccessibleName = "Part"
        Me.cmdPart.DisplayName = "CommandBarButton1"
        Me.cmdPart.Image = CType(resources.GetObject("cmdPart.Image"), System.Drawing.Image)
        Me.cmdPart.ImageIndex = 0
        Me.cmdPart.Name = "cmdPart"
        Me.cmdPart.Text = "Part"
        Me.cmdPart.ToolTipText = "Part"
        Me.cmdPart.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdPart.VisibleInOverflowMenu = True
        '
        'cmdHide
        '
        Me.cmdHide.AccessibleDescription = "Hide"
        Me.cmdHide.AccessibleName = "Hide"
        Me.cmdHide.DisplayName = "CommandBarButton1"
        Me.cmdHide.Image = CType(resources.GetObject("cmdHide.Image"), System.Drawing.Image)
        Me.cmdHide.ImageIndex = 1
        Me.cmdHide.Name = "cmdHide"
        Me.cmdHide.Text = "Hide"
        Me.cmdHide.ToolTipText = "Hide"
        Me.cmdHide.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdHide.VisibleInOverflowMenu = True
        '
        'cmdNotice
        '
        Me.cmdNotice.AccessibleDescription = "Notice"
        Me.cmdNotice.AccessibleName = "Notice"
        Me.cmdNotice.DisplayName = "CommandBarButton1"
        Me.cmdNotice.Image = CType(resources.GetObject("cmdNotice.Image"), System.Drawing.Image)
        Me.cmdNotice.ImageIndex = 2
        Me.cmdNotice.Name = "cmdNotice"
        Me.cmdNotice.Text = "Notice"
        Me.cmdNotice.ToolTipText = "Notice"
        Me.cmdNotice.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdNotice.VisibleInOverflowMenu = True
        '
        'cmdAddToChannelFolder
        '
        Me.cmdAddToChannelFolder.AccessibleDescription = "Add to Channel Folder"
        Me.cmdAddToChannelFolder.AccessibleName = "Add to Channel Folder"
        Me.cmdAddToChannelFolder.DisplayName = "CommandBarButton1"
        Me.cmdAddToChannelFolder.Image = CType(resources.GetObject("cmdAddToChannelFolder.Image"), System.Drawing.Image)
        Me.cmdAddToChannelFolder.ImageIndex = 3
        Me.cmdAddToChannelFolder.Name = "cmdAddToChannelFolder"
        Me.cmdAddToChannelFolder.Text = "Add to Channel Folder"
        Me.cmdAddToChannelFolder.ToolTipText = "Add to Channel Folder"
        Me.cmdAddToChannelFolder.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdAddToChannelFolder.VisibleInOverflowMenu = True
        '
        'cmdNames
        '
        Me.cmdNames.AccessibleDescription = "Names"
        Me.cmdNames.AccessibleName = "Names"
        Me.cmdNames.DisplayName = "CommandBarButton1"
        Me.cmdNames.Image = CType(resources.GetObject("cmdNames.Image"), System.Drawing.Image)
        Me.cmdNames.ImageIndex = 4
        Me.cmdNames.Name = "cmdNames"
        Me.cmdNames.Text = "Names"
        Me.cmdNames.ToolTipText = "Names"
        Me.cmdNames.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdNames.VisibleInOverflowMenu = True
        '
        'lvwNicklist
        '
        Me.lvwNicklist.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwNicklist.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwNicklist.Location = New System.Drawing.Point(463, 30)
        Me.lvwNicklist.Name = "lvwNicklist"
        Me.lvwNicklist.Size = New System.Drawing.Size(120, 200)
        Me.lvwNicklist.TabIndex = 3
        Me.lvwNicklist.Text = "RadListView1"
        '
        'tmrGetNames
        '
        '
        'frmChannel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(583, 267)
        Me.Controls.Add(Me.lvwNicklist)
        Me.Controls.Add(Me.tspChannel)
        Me.Controls.Add(Me.txtIncoming)
        Me.Controls.Add(Me.txtOutgoing)
        Me.Name = "frmChannel"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = False
        Me.Text = "frmChannel"
        CType(Me.txtOutgoing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIncoming, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tspChannel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lvwNicklist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOutgoing As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIncoming As Telerik.WinControls.RichTextBox.RadRichTextBox
    Friend WithEvents tspChannel As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents lvwNicklist As Telerik.WinControls.UI.RadListView
    Friend WithEvents tmrGetNames As System.Windows.Forms.Timer
    Friend WithEvents cmdPart As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdHide As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdNotice As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdAddToChannelFolder As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents cmdNames As Telerik.WinControls.UI.CommandBarButton
End Class

