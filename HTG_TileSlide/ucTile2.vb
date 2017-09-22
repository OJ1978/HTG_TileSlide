Public Class ctlTile
    Inherits System.Windows.Forms.UserControl

    Private imagePoint As Point
    Friend WithEvents imageBase As System.Windows.Forms.Button
    Friend WithEvents tilePic As System.Windows.Forms.PictureBox
    Private t_index As Integer

    Public ReadOnly Property tIndex() As Integer
        Get
            Return t_index
        End Get
    End Property

    Public ReadOnly Property tImageSize() As Size
        Get
            Return Me.tilePic.Size
        End Get
    End Property

    Private components As System.ComponentModel.Container = Nothing

#Region "Contructor and Dispose"
    ' Constructor for the control
    Public Sub New(ByVal tWidth As Integer, ByVal tHeight As Integer, ByVal index As Integer)

        MyBase.New()
        'Tile's Index
        t_index = index

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

        imageBase.Location = New Point(0, 0)
        imageBase.Size = New Size(tWidth, tHeight)
        tilePic.Location = New Point(1, 1)
        tilePic.Size = New Size(tWidth - 2, tHeight - 2)
        tilePic.Image = Nothing
    End Sub

    ' Clean up any resources being used.
    Protected Overloads Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

#Region "Component Designer generated code"
    ' Required method for Designer support - do not modify 
    ' the contents of this method with the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.imageBase = New System.Windows.Forms.Button()
        Me.tilePic = New System.Windows.Forms.PictureBox()
        Me.SuspendLayout()
        ' 
        ' imageBase
        ' 
        Me.imageBase.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.imageBase.Enabled = False
        Me.imageBase.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.imageBase.Location = New System.Drawing.Point(1, 1)
        Me.imageBase.Name = "imageBase"
        Me.imageBase.Size = New System.Drawing.Size(62, 62)
        Me.imageBase.TabIndex = 0
        ' 
        ' tilePic
        ' 
        Me.tilePic.BackColor = System.Drawing.Color.OliveDrab
        Me.tilePic.Location = New System.Drawing.Point(2, 2)
        Me.tilePic.Name = "tilePic"
        Me.tilePic.Size = New System.Drawing.Size(60, 60)
        Me.tilePic.TabIndex = 1
        Me.tilePic.TabStop = False
        ' 
        ' ctlTile
        ' 
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tilePic, Me.imageBase})
        Me.Name = "ctlTile"
        Me.Size = New System.Drawing.Size(64, 64)
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region "Tile Picture"
    'Here the tile imgae is declared painted on the tile
    Public Sub tilePicture(ByVal tImage As Image, ByVal StartPt As Point)
        tilePic.Image = tImage
        imagePoint = StartPt
    End Sub
#End Region

#Region "Repaint Tile"
    ' Here required repainting is done
    ' based on the onpaint event
    Private Sub TilePic_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tilePic.Paint
        If Not (tilePic.Image Is Nothing) Then
            Dim g As Graphics = e.Graphics
            g.DrawImage(tilePic.Image, New Rectangle(New Point(0, 0), New Size(tilePic.Width, tilePic.Height)), _
             New Rectangle(imagePoint, New Size(tilePic.Width, tilePic.Height)), GraphicsUnit.Pixel)
        End If
    End Sub
#End Region
End Class
