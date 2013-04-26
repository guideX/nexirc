<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNetworkSettings
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
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtBufferSize = New System.Windows.Forms.TextBox
        Me.lblBufferSize = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.chkRandomize = New System.Windows.Forms.CheckBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtSendPort = New System.Windows.Forms.TextBox
        Me.txtCustomIpAddress = New System.Windows.Forms.TextBox
        Me.optIpAddressCustom = New System.Windows.Forms.RadioButton
        Me.optIpAddressAuto = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(157, 144)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(238, 144)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdFind
        '
        Me.cmdFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.Location = New System.Drawing.Point(257, 66)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(46, 21)
        Me.cmdFind.TabIndex = 26
        Me.cmdFind.Text = "Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtBufferSize
        '
        Me.txtBufferSize.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBufferSize.Location = New System.Drawing.Point(135, 6)
        Me.txtBufferSize.Name = "txtBufferSize"
        Me.txtBufferSize.Size = New System.Drawing.Size(168, 21)
        Me.txtBufferSize.TabIndex = 25
        '
        'lblBufferSize
        '
        Me.lblBufferSize.AutoSize = True
        Me.lblBufferSize.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBufferSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBufferSize.Location = New System.Drawing.Point(12, 9)
        Me.lblBufferSize.Name = "lblBufferSize"
        Me.lblBufferSize.Size = New System.Drawing.Size(63, 13)
        Me.lblBufferSize.TabIndex = 24
        Me.lblBufferSize.Text = "Buffer Size:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label22.Location = New System.Drawing.Point(12, 69)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(102, 13)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "Custom IP Address:"
        '
        'chkRandomize
        '
        Me.chkRandomize.AutoSize = True
        Me.chkRandomize.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRandomize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkRandomize.Location = New System.Drawing.Point(135, 120)
        Me.chkRandomize.Name = "chkRandomize"
        Me.chkRandomize.Size = New System.Drawing.Size(65, 17)
        Me.chkRandomize.TabIndex = 22
        Me.chkRandomize.Text = "Random"
        Me.chkRandomize.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label21.Location = New System.Drawing.Point(12, 96)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 21
        Me.Label21.Text = "Port Range:"
        '
        'txtSendPort
        '
        Me.txtSendPort.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSendPort.Location = New System.Drawing.Point(135, 93)
        Me.txtSendPort.Name = "txtSendPort"
        Me.txtSendPort.Size = New System.Drawing.Size(168, 21)
        Me.txtSendPort.TabIndex = 20
        '
        'txtCustomIpAddress
        '
        Me.txtCustomIpAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomIpAddress.Location = New System.Drawing.Point(135, 66)
        Me.txtCustomIpAddress.Name = "txtCustomIpAddress"
        Me.txtCustomIpAddress.Size = New System.Drawing.Size(117, 21)
        Me.txtCustomIpAddress.TabIndex = 19
        '
        'optIpAddressCustom
        '
        Me.optIpAddressCustom.AutoSize = True
        Me.optIpAddressCustom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optIpAddressCustom.ForeColor = System.Drawing.SystemColors.WindowText
        Me.optIpAddressCustom.Location = New System.Drawing.Point(12, 49)
        Me.optIpAddressCustom.Name = "optIpAddressCustom"
        Me.optIpAddressCustom.Size = New System.Drawing.Size(199, 17)
        Me.optIpAddressCustom.TabIndex = 18
        Me.optIpAddressCustom.TabStop = True
        Me.optIpAddressCustom.Text = "Manually enter my IP Address below"
        Me.optIpAddressCustom.UseVisualStyleBackColor = True
        '
        'optIpAddressAuto
        '
        Me.optIpAddressAuto.AutoSize = True
        Me.optIpAddressAuto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optIpAddressAuto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.optIpAddressAuto.Location = New System.Drawing.Point(12, 33)
        Me.optIpAddressAuto.Name = "optIpAddressAuto"
        Me.optIpAddressAuto.Size = New System.Drawing.Size(129, 17)
        Me.optIpAddressAuto.TabIndex = 17
        Me.optIpAddressAuto.TabStop = True
        Me.optIpAddressAuto.Text = "Detect my IP Address"
        Me.optIpAddressAuto.UseVisualStyleBackColor = True
        '
        'frmNetworkSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 178)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtBufferSize)
        Me.Controls.Add(Me.lblBufferSize)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.chkRandomize)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtSendPort)
        Me.Controls.Add(Me.txtCustomIpAddress)
        Me.Controls.Add(Me.optIpAddressCustom)
        Me.Controls.Add(Me.optIpAddressAuto)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNetworkSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "nexIRC - Network Settings"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtBufferSize As System.Windows.Forms.TextBox
    Friend WithEvents lblBufferSize As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chkRandomize As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtSendPort As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomIpAddress As System.Windows.Forms.TextBox
    Friend WithEvents optIpAddressCustom As System.Windows.Forms.RadioButton
    Friend WithEvents optIpAddressAuto As System.Windows.Forms.RadioButton
End Class
