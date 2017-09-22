<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucTile
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    Public Sub New(ByVal tWidth As Integer, ByVal tHeight As Integer, ByVal index As Integer)

        MyBase.New()
        'Tile's Index
        intIndex = index

        'Disable control so parent form cann handle its key and mouse
        'events
        Enabled = False

        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

        'Image Base and Imgae Fixation Here
        If ((tWidth < 32 Or tWidth > 96) Or (tHeight < 32 Or tHeight > 96)) Then
            Me.Size = New Size(64, 64)
            tWidth = 64
            tHeight = 64
        Else
            Me.Size = New Size(tWidth, tHeight)
        End If

        btnImage.Location = New Point(0, 0)
        btnImage.Size = New Size(tWidth, tHeight)

        picTile.Location = New Point(1, 1)
        picTile.Size = New Size(tWidth - 2, tHeight - 2)
        picTile.Image = Nothing

    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.picTile = New System.Windows.Forms.PictureBox()
        Me.btnImage = New System.Windows.Forms.Button()
        CType(Me.picTile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picTile
        '
        Me.picTile.BackColor = System.Drawing.Color.Peru
        Me.picTile.Location = New System.Drawing.Point(2, 2)
        Me.picTile.Name = "picTile"
        Me.picTile.Size = New System.Drawing.Size(60, 60)
        Me.picTile.TabIndex = 3
        Me.picTile.TabStop = False
        '
        'btnImage
        '
        Me.btnImage.BackColor = System.Drawing.Color.Maroon
        Me.btnImage.Enabled = False
        Me.btnImage.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImage.Location = New System.Drawing.Point(1, 1)
        Me.btnImage.Name = "btnImage"
        Me.btnImage.Size = New System.Drawing.Size(62, 62)
        Me.btnImage.TabIndex = 2
        Me.btnImage.UseVisualStyleBackColor = False
        '
        'ucTile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.picTile)
        Me.Controls.Add(Me.btnImage)
        Me.Name = "ucTile"
        Me.Size = New System.Drawing.Size(64, 64)
        CType(Me.picTile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picTile As System.Windows.Forms.PictureBox
    Friend WithEvents btnImage As System.Windows.Forms.Button

End Class
