<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiMain))
        Me.RadCommandBar1 = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.RadStatusStrip1 = New Telerik.WinControls.UI.RadStatusStrip()
        Me.tvwLeft = New Telerik.WinControls.UI.RadTreeView()
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvwLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadCommandBar1
        '
        Me.RadCommandBar1.AutoSize = True
        Me.RadCommandBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadCommandBar1.Location = New System.Drawing.Point(0, 0)
        Me.RadCommandBar1.Name = "RadCommandBar1"
        Me.RadCommandBar1.Rows.AddRange(New Telerik.WinControls.UI.CommandBarRowElement() {Me.CommandBarRowElement1})
        Me.RadCommandBar1.Size = New System.Drawing.Size(830, 30)
        Me.RadCommandBar1.TabIndex = 2
        Me.RadCommandBar1.Text = "RadCommandBar1"
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
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Text = ""
        '
        'RadStatusStrip1
        '
        Me.RadStatusStrip1.AutoSize = True
        Me.RadStatusStrip1.LayoutStyle = Telerik.WinControls.UI.RadStatusBarLayoutStyle.Stack
        Me.RadStatusStrip1.Location = New System.Drawing.Point(0, 332)
        Me.RadStatusStrip1.Name = "RadStatusStrip1"
        Me.RadStatusStrip1.Size = New System.Drawing.Size(830, 24)
        Me.RadStatusStrip1.TabIndex = 3
        Me.RadStatusStrip1.Text = "RadStatusStrip1"
        '
        'tvwLeft
        '
        Me.tvwLeft.BackColor = System.Drawing.Color.Black
        Me.tvwLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvwLeft.Location = New System.Drawing.Point(0, 30)
        Me.tvwLeft.Name = "tvwLeft"
        Me.tvwLeft.Size = New System.Drawing.Size(150, 302)
        Me.tvwLeft.SpacingBetweenNodes = -1
        Me.tvwLeft.TabIndex = 4
        Me.tvwLeft.Text = "RadTreeView1"
        '
        'mdiMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 356)
        Me.Controls.Add(Me.tvwLeft)
        Me.Controls.Add(Me.RadStatusStrip1)
        Me.Controls.Add(Me.RadCommandBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "mdiMain"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "nexIRC"
        CType(Me.RadCommandBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadStatusStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvwLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadCommandBar1 As Telerik.WinControls.UI.RadCommandBar
    Friend WithEvents CommandBarRowElement1 As Telerik.WinControls.UI.CommandBarRowElement
    Friend WithEvents CommandBarStripElement1 As Telerik.WinControls.UI.CommandBarStripElement
    Friend WithEvents RadStatusStrip1 As Telerik.WinControls.UI.RadStatusStrip
    Friend WithEvents tvwLeft As Telerik.WinControls.UI.RadTreeView
End Class

