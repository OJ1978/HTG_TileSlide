Public Class ucTile
    Inherits System.Windows.Forms.UserControl

    Private pntImage As Point

    Private intIndex As Integer

    Public ReadOnly Property Index() As Integer

        Get

            Return intIndex

        End Get

    End Property

    Public ReadOnly Property ImageSize() As Size

        Get

            Return Me.picTile.Size

        End Get

    End Property

    Public Sub Tile(ByVal imImage As Image, ByVal ptStart As Point)

        picTile.Image = imImage
        pntImage = ptStart

    End Sub

    Private Sub picTile_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picTile.Paint

        If Not (picTile.Image Is Nothing) Then

            Dim g As Graphics = e.Graphics

            g.DrawImage(picTile.Image, New Rectangle(New Point(0, 0), New Size(picTile.Width, picTile.Height)), New Rectangle(pntImage, New Size(picTile.Width, picTile.Height)), GraphicsUnit.Pixel)

        End If

    End Sub

End Class
