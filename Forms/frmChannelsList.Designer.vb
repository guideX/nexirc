<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChannelsList
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
        Dim ListViewDetailColumn1 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Channel")
        Dim ListViewDetailColumn2 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "Topic")
        Dim ListViewDetailColumn3 As Telerik.WinControls.UI.ListViewDetailColumn = New Telerik.WinControls.UI.ListViewDetailColumn("Column 2", "User Count")
        Me.lvwChannels = New Telerik.WinControls.UI.RadListView()
        CType(Me.lvwChannels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvwChannels
        '
        ListViewDetailColumn1.HeaderText = "Channel"
        ListViewDetailColumn2.HeaderText = "Topic"
        ListViewDetailColumn3.HeaderText = "User Count"
        Me.lvwChannels.Columns.AddRange(New Telerik.WinControls.UI.ListViewDetailColumn() {ListViewDetailColumn1, ListViewDetailColumn2, ListViewDetailColumn3})
        Me.lvwChannels.EnableColumnSort = True
        Me.lvwChannels.EnableSorting = True
        Me.lvwChannels.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwChannels.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwChannels.ItemSpacing = -1
        Me.lvwChannels.Location = New System.Drawing.Point(0, 0)
        Me.lvwChannels.Name = "lvwChannels"
        Me.lvwChannels.Size = New System.Drawing.Size(533, 210)
        Me.lvwChannels.TabIndex = 0
        Me.lvwChannels.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView
        Me.lvwChannels.Visible = False
        '
        'frmChannelsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(883, 353)
        Me.Controls.Add(Me.lvwChannels)
        Me.Name = "frmChannelsList"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "Channel List"
        CType(Me.lvwChannels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwChannels As Telerik.WinControls.UI.RadListView
End Class

