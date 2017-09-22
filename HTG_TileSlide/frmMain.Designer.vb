<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuFile = New System.Windows.Forms.MenuItem()
        Me.MenuLoadPicture = New System.Windows.Forms.MenuItem()
        Me.MenuShuffle = New System.Windows.Forms.MenuItem()
        Me.menuSize = New System.Windows.Forms.MenuItem()
        Me.MenuSize3 = New System.Windows.Forms.MenuItem()
        Me.MenuSize4 = New System.Windows.Forms.MenuItem()
        Me.MenuSize5 = New System.Windows.Forms.MenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tmrTime = New System.Windows.Forms.Timer(Me.components)
        Me.pnlTiles = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuFile})
        '
        'MenuFile
        '
        Me.MenuFile.Index = 0
        Me.MenuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuLoadPicture, Me.MenuShuffle, Me.menuSize})
        Me.MenuFile.Text = "File"
        '
        'MenuLoadPicture
        '
        Me.MenuLoadPicture.Index = 0
        Me.MenuLoadPicture.Text = "Load Picture"
        '
        'MenuShuffle
        '
        Me.MenuShuffle.Index = 1
        Me.MenuShuffle.Text = "Shuffle"
        '
        'menuSize
        '
        Me.menuSize.Index = 2
        Me.menuSize.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuSize3, Me.MenuSize4, Me.MenuSize5})
        Me.menuSize.Text = "Size"
        '
        'MenuSize3
        '
        Me.MenuSize3.Checked = True
        Me.MenuSize3.Index = 0
        Me.MenuSize3.Text = "3 x 3"
        '
        'MenuSize4
        '
        Me.MenuSize4.Index = 1
        Me.MenuSize4.Text = "4 x 4"
        '
        'MenuSize5
        '
        Me.MenuSize5.Index = 2
        Me.MenuSize5.Text = "5 x 5"
        '
        'tmrTime
        '
        '
        'pnlTiles
        '
        Me.pnlTiles.BackColor = System.Drawing.Color.BurlyWood
        Me.pnlTiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTiles.Location = New System.Drawing.Point(0, 0)
        Me.pnlTiles.Name = "pnlTiles"
        Me.pnlTiles.Size = New System.Drawing.Size(284, 256)
        Me.pnlTiles.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 256)
        Me.Controls.Add(Me.pnlTiles)
        Me.Menu = Me.MainMenu1
        Me.Name = "frmMain"
        Me.Text = "HTG_TileSlide"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuFile As System.Windows.Forms.MenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tmrTime As System.Windows.Forms.Timer
    Private WithEvents pnlTiles As System.Windows.Forms.Panel
    Friend WithEvents MenuShuffle As System.Windows.Forms.MenuItem
    Friend WithEvents menuSize As System.Windows.Forms.MenuItem
    Friend WithEvents MenuLoadPicture As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSize3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSize4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuSize5 As System.Windows.Forms.MenuItem
End Class
