<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServerLinks
    Inherits System.Windows.Forms.Form

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
        Me.lvwLinks = New System.Windows.Forms.ListView
        Me.cboNetworks = New System.Windows.Forms.ComboBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lvwLinks
        '
        Me.lvwLinks.CheckBoxes = True
        Me.lvwLinks.Location = New System.Drawing.Point(12, 36)
        Me.lvwLinks.Name = "lvwLinks"
        Me.lvwLinks.Size = New System.Drawing.Size(344, 173)
        Me.lvwLinks.TabIndex = 0
        Me.lvwLinks.UseCompatibleStateImageBehavior = False
        Me.lvwLinks.View = System.Windows.Forms.View.Details
        '
        'cboNetworks
        '
        Me.cboNetworks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNetworks.FormattingEnabled = True
        Me.cboNetworks.Location = New System.Drawing.Point(12, 8)
        Me.cboNetworks.Name = "cboNetworks"
        Me.cboNetworks.Size = New System.Drawing.Size(344, 21)
        Me.cboNetworks.TabIndex = 1
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(210, 215)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(70, 29)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "Add"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(286, 215)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(70, 29)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmServerLinks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 250)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cboNetworks)
        Me.Controls.Add(Me.lvwLinks)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServerLinks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nexIRC - Server Links"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwLinks As System.Windows.Forms.ListView
    Friend WithEvents cboNetworks As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
