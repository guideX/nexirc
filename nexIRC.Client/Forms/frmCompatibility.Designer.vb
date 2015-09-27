<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompatibility
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompatibility))
        Me.lvwCompatibility = New Telerik.WinControls.UI.RadListView()
        Me.cmdOK = New Telerik.WinControls.UI.RadButton()
        Me.cmdCancel = New Telerik.WinControls.UI.RadButton()
        Me.lnkRemove = New System.Windows.Forms.LinkLabel()
        Me.lnkAdd = New System.Windows.Forms.LinkLabel()
        CType(Me.lvwCompatibility, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvwCompatibility
        '
        Me.lvwCompatibility.GroupItemSize = New System.Drawing.Size(200, 20)
        Me.lvwCompatibility.ItemSize = New System.Drawing.Size(200, 20)
        Me.lvwCompatibility.Location = New System.Drawing.Point(12, 12)
        Me.lvwCompatibility.Name = "lvwCompatibility"
        Me.lvwCompatibility.Size = New System.Drawing.Size(290, 153)
        Me.lvwCompatibility.TabIndex = 0
        Me.lvwCompatibility.Text = "RadListView1"
        Me.lvwCompatibility.ThemeName = "Office2010Black"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(178, 171)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(59, 24)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.ThemeName = "Office2010Black"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(243, 171)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(59, 24)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.ThemeName = "Office2010Black"
        '
        'lnkRemove
        '
        Me.lnkRemove.AutoSize = True
        Me.lnkRemove.Location = New System.Drawing.Point(46, 171)
        Me.lnkRemove.Name = "lnkRemove"
        Me.lnkRemove.Size = New System.Drawing.Size(47, 13)
        Me.lnkRemove.TabIndex = 18
        Me.lnkRemove.TabStop = True
        Me.lnkRemove.Text = "Remove"
        '
        'lnkAdd
        '
        Me.lnkAdd.AutoSize = True
        Me.lnkAdd.Location = New System.Drawing.Point(12, 171)
        Me.lnkAdd.Name = "lnkAdd"
        Me.lnkAdd.Size = New System.Drawing.Size(28, 13)
        Me.lnkAdd.TabIndex = 19
        Me.lnkAdd.TabStop = True
        Me.lnkAdd.Text = "Add"
        '
        'frmCompatibility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 207)
        Me.Controls.Add(Me.lnkAdd)
        Me.Controls.Add(Me.lnkRemove)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lvwCompatibility)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCompatibility"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.Text = "nexIRC - Compatibility"
        Me.ThemeName = "Office2010Black"
        CType(Me.lvwCompatibility, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwCompatibility As Telerik.WinControls.UI.RadListView
    Friend WithEvents cmdOK As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmdCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents lnkRemove As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkAdd As System.Windows.Forms.LinkLabel
End Class

