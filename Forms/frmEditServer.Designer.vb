<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditServer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIp = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.cboNetwork = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(125, 12)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(165, 21)
        Me.txtDescription.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Description:"
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(125, 39)
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(94, 21)
        Me.txtIp.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Ip/Port:"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(225, 39)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(65, 21)
        Me.txtPort.TabIndex = 9
        '
        'cboNetwork
        '
        Me.cboNetwork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNetwork.FormattingEnabled = True
        Me.cboNetwork.Location = New System.Drawing.Point(125, 66)
        Me.cboNetwork.Name = "cboNetwork"
        Me.cboNetwork.Size = New System.Drawing.Size(165, 21)
        Me.cboNetwork.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Network:"
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(154, 92)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(65, 23)
        Me.cmdOK.TabIndex = 13
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(225, 93)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(65, 23)
        Me.cmdCancel.TabIndex = 14
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmEditServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(302, 123)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cboNetwork)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtIp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditServer"
        Me.Text = "nexIRC - Edit Server"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents cboNetwork As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
