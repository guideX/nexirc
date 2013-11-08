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
        Me.txtIncoming = New Telerik.WinControls.RichTextBox.RadRichTextBox()
        Me.tspStatus = New Telerik.WinControls.UI.RadCommandBar()
        Me.CommandBarRowElement1 = New Telerik.WinControls.UI.CommandBarRowElement()
        Me.CommandBarStripElement1 = New Telerik.WinControls.UI.CommandBarStripElement()
        Me.txtOutgoing = New Telerik.WinControls.UI.RadTextBox()
        CType(Me.txtIncoming, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tspStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOutgoing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIncoming
        '
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
        Me.CommandBarStripElement1.Name = "CommandBarStripElement1"
        Me.CommandBarStripElement1.Text = ""
        '
        'txtOutgoing
        '
        Me.txtOutgoing.Location = New System.Drawing.Point(0, 136)
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
End Class

