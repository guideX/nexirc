<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDownloadManager
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDownloadManager))
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdRun = New System.Windows.Forms.Button
        Me.cmdOpenLocation = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.lvwDownloadManager = New System.Windows.Forms.ListView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(227, 201)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(44, 26)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRun
        '
        Me.cmdRun.Location = New System.Drawing.Point(177, 201)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(44, 26)
        Me.cmdRun.TabIndex = 2
        Me.cmdRun.Text = "Run"
        Me.cmdRun.UseVisualStyleBackColor = True
        '
        'cmdOpenLocation
        '
        Me.cmdOpenLocation.Enabled = False
        Me.cmdOpenLocation.Location = New System.Drawing.Point(12, 201)
        Me.cmdOpenLocation.Name = "cmdOpenLocation"
        Me.cmdOpenLocation.Size = New System.Drawing.Size(90, 26)
        Me.cmdOpenLocation.TabIndex = 3
        Me.cmdOpenLocation.Text = "Open Location"
        Me.cmdOpenLocation.UseVisualStyleBackColor = True
        Me.cmdOpenLocation.Visible = False
        '
        'cmdClear
        '
        Me.cmdClear.Enabled = False
        Me.cmdClear.Location = New System.Drawing.Point(127, 201)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(44, 26)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        Me.cmdClear.Visible = False
        '
        'lvwDownloadManager
        '
        Me.lvwDownloadManager.LargeImageList = Me.ImageList1
        Me.lvwDownloadManager.Location = New System.Drawing.Point(12, 12)
        Me.lvwDownloadManager.MultiSelect = False
        Me.lvwDownloadManager.Name = "lvwDownloadManager"
        Me.lvwDownloadManager.Size = New System.Drawing.Size(258, 183)
        Me.lvwDownloadManager.SmallImageList = Me.ImageList1
        Me.lvwDownloadManager.StateImageList = Me.ImageList1
        Me.lvwDownloadManager.TabIndex = 5
        Me.lvwDownloadManager.UseCompatibleStateImageBehavior = False
        Me.lvwDownloadManager.View = System.Windows.Forms.View.List
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "BSG Document.ico")
        '
        'frmDownloadManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 236)
        Me.Controls.Add(Me.lvwDownloadManager)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.cmdOpenLocation)
        Me.Controls.Add(Me.cmdRun)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmDownloadManager"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Download Manager"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdRun As System.Windows.Forms.Button
    Friend WithEvents cmdOpenLocation As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lvwDownloadManager As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
