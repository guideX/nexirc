<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChannelList
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
        Dim ListViewDetailColumn4 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Channel")
        Dim ListViewDetailColumn5 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Topic")
        Dim ListViewDetailColumn6 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "User Count")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChannelList))
        Me.lvwChannels = New Telerik.WinControls.UI.RadListView()
        Me.RadCommandBar1 = New Telerik.WinControls.UI.RadCommandBar()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.cmdRefresh = New Telerik.WinControls.UI.CommandBarButton()
        Me.cmdAddToChannelFolder = New Telerik.WinControls.UI.CommandBarButton()
        CType(Me.lvwChannels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvwChannels
        '
        ListViewDetailColumn4.HeaderText = "Channel"
        ListViewDetailColumn5.HeaderText = "Topic"
        ListViewDetailColumn6.HeaderText = "User Count"
        Me.lvwChannels.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn4, ListViewDetailColumn5, ListViewDetailColumn6})
        Me.lvwChannels.EnableColumnSort = True
        Me.lvwChannels.EnableSorting = True
        Me.lvwChannels.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwChannels.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwChannels.ItemSpacing = -1
        Me.lvwChannels.Location = New System.Drawing.Point(0, 30)
        Me.lvwChannels.Name = "lvwChannels"
        Me.lvwChannels.Size = New System.Drawing.Size(533, 210)
        Me.lvwChannels.TabIndex = 0
        Me.lvwChannels.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        Me.lvwChannels.Visible = False
        '
        'RadCommandBar1
        '
        Me.RadCommandBar1.AutoSize = True
        Me.RadCommandBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadCommandBar1.ImageList = Me.ImageList1
        Me.RadCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.RadCommandBar1.Name = "RadCommandBar1"
        Me.RadCommandBar1.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.RadCommandBar1.Size = New System.Drawing.Size(883, 55)
        Me.RadCommandBar1.TabIndex = 1
        Me.RadCommandBar1.Text = "RadCommandBar1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "refresh.png")
        Me.ImageList1.Images.SetKeyName(1, "add.png")
        '
        'CommandBarRowElement1
        '
        Me.CommandBarRowElement1.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder
        Me.CommandBarRowElement1.DisplayName = Nothing
        Me.CommandBarRowElement1.MinSize = New System.Drawing.Size(25, 25)
        Me.CommandBarRowElement1.Strips.AddRange(New Telerik.WinControls.UI.CommandBarStripElement() {Me.CommandBarStripElement1})
        '
        'CommandBarStripElement1
        '
        Me.CommandBarStripElement1.DisplayName = "CommandBarStripElement1"
        Me.CommandBarStripElement1.FloatingForm = Nothing
        Me.CommandBarStripElement1.Items.AddRange(New Telerik.WinControls.UI.RadCommandBarBaseItem() {Me.cmdRefresh, Me.cmdAddToChannelFolder})
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Text = ""
        '
        'cmdRefresh
        '
        Me.cmdRefresh.AccessibleDescription = "Refresh"
        Me.cmdRefresh.AccessibleName = "Refresh"
        Me.cmdRefresh.DisplayName = "CommandBarButton1"
        Me.cmdRefresh.Image = CType(resources.GetObject("cmdRefresh.Image"), System.Drawing.Image)
        Me.cmdRefresh.ImageIndex = 0
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdRefresh.VisibleInOverflowMenu = True
        '
        'cmdAddToChannelFolder
        '
        Me.cmdAddToChannelFolder.AccessibleDescription = "Add to Channel Folder"
        Me.cmdAddToChannelFolder.AccessibleName = "Add to Channel Folder"
        Me.cmdAddToChannelFolder.DisplayName = "CommandBarButton1"
        Me.cmdAddToChannelFolder.Image = CType(resources.GetObject("cmdAddToChannelFolder.Image"), System.Drawing.Image)
        Me.cmdAddToChannelFolder.ImageIndex = 1
        Me.cmdAddToChannelFolder.Name = "cmdAddToChannelFolder"
        Me.cmdAddToChannelFolder.Text = "Add to Channel Folder"
        Me.cmdAddToChannelFolder.ToolTipText = "Add to Channel Folder"
        Me.cmdAddToChannelFolder.Visibility = Telerik.WinControls.ElementVisibility.Visible
        Me.cmdAddToChannelFolder.VisibleInOverflowMenu = True
        '
        'frmChannelsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(883, 353)
        Me.Controls.Add(Me.lvwChannels)
        Me.Controls.Add(Me.RadCommandBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChannelsList"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.ShowIcon = False
        Me.Text = "Channel List"
        CType(Me.lvwChannels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwChannels As Telerik.WinControls.UI.RadListView
    Friend WithEvents RadCommandBar1 As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents cmdRefresh As Telerik.WinControls.UI.CommandBarButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdAddToChannelFolder As Telerik.WinControls.UI.CommandBarButton
End Class

