Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private Const intSquare As Integer = 64
    Private Const intWidth As Integer = 62

    Private intNumberOfRows As Integer = 3
    Private intNumberOfCols As Integer = 3

    Private rndRandom As Random

    Private tilBlank As Block

    Private blnLoaded As Boolean

    Dim intCountDown As Integer

    Private tilTiles(,) As ucTile
    Friend WithEvents tilLast As ucTile


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Create(intNumberOfRows, intNumberOfCols)

    End Sub



    Protected Sub Randomize()

        rndRandom = New Random()

        intCountDown = 64 * intNumberOfRows * intNumberOfCols

        tmrTime.Interval = 1
        tmrTime.Enabled = True

    End Sub

    Private Sub tmrTime_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrTime.Tick

        Dim intCol As Integer = tilBlank.intCol
        Dim intRow As Integer = tilBlank.intRow

        Select Case (rndRandom.Next(4))

            Case 0

                intCol += 1

            Case 1

                intCol -= 1

            Case 2

                intRow += 1

            Case 3

                intRow -= 1

        End Select

        If (intCol >= 0 And intCol < intNumberOfCols And intRow >= 0 And intRow < intNumberOfRows) Then

            Shift(intCol, intRow)

        End If

        intCountDown = intCountDown - 1

        If (intCountDown = 0) Then

            tmrTime.Stop()

        End If

    End Sub


    Private Sub Shift(ByVal intCol As Integer, ByVal intRow As Integer)

        tilTiles(intRow, intCol).Location = New Point(tilBlank.intCol * intSquare, tilBlank.intRow * intSquare)

        tilTiles(tilBlank.intRow, tilBlank.intCol) = tilTiles(intRow, intCol)

        tilTiles(intRow, intCol) = Nothing

        tilBlank = New Block(intRow, intCol)

    End Sub

    Public Sub Create(ByVal intRows As Integer, ByVal intCols As Integer)

        Dim index As Integer = 0

        ReDim tilTiles(intRows, intCols)

        pnlTiles.Size = New Size(intSquare * intRows + 4, intSquare * intCols + 4)

        pnlTiles.Location = New Point(4, 4)

        Me.ClientSize = New Size(pnlTiles.Size.Width + 6, pnlTiles.Size.Height + 6)

        Dim Row, Col As Integer

        For Row = 0 To intRows - 1

            For Col = 0 To intCols - 1

                tilTiles(Row, Col) = New ucTile(intSquare, intSquare, index)

                tilTiles(Row, Col).Parent = Me.pnlTiles

                tilTiles(Row, Col).Location = New Point(Col * intSquare, Row * intSquare)

                index += 1

            Next

        Next

    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If blnLoaded = False Then Return

        If (e.KeyCode = Keys.Left And tilBlank.intCol < intNumberOfCols - 1) Then

            Shift(tilBlank.intCol + 1, tilBlank.intRow)

        ElseIf (e.KeyCode = Keys.Right And tilBlank.intCol > 0) Then

            Shift(tilBlank.intCol - 1, tilBlank.intRow)

        ElseIf (e.KeyCode = Keys.Up And tilBlank.intRow < intNumberOfRows - 1) Then

            Shift(tilBlank.intCol, tilBlank.intRow + 1)

        ElseIf (e.KeyCode = Keys.Down And tilBlank.intRow > 0) Then

            Shift(tilBlank.intCol, tilBlank.intRow - 1)

        End If

        e.Handled = True

        GameOver()

    End Sub

    Private Sub pnlTiles_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlTiles.MouseDown

        If blnLoaded = False Then Return

        Dim intRow As Integer = e.Y \ intSquare
        Dim intCol As Integer = e.X \ intSquare

        If (intCol = tilBlank.intCol) Then

            If (intRow < tilBlank.intRow) Then

                Dim intTempRow As Integer

                For intTempRow = tilBlank.intRow - 1 To intRow Step -1

                    Shift(intCol, intTempRow)

                Next

            ElseIf (intRow > tilBlank.intRow) Then

                Dim intTempRow As Integer

                For intTempRow = tilBlank.intRow + 1 To intRow

                    Shift(intCol, intTempRow)

                Next

            End If

        ElseIf (intRow = tilBlank.intRow) Then

            If (intCol < tilBlank.intCol) Then

                Dim intTempCol As Integer

                For intTempCol = tilBlank.intCol - 1 To intCol Step -1

                    Shift(intTempCol, intRow)

                Next

            ElseIf (intCol > tilBlank.intCol) Then

                Dim intTempCol As Integer

                For intTempCol = tilBlank.intCol + 1 To intCol

                    Shift(intTempCol, intRow)
                Next

            End If

        End If

        GameOver()

    End Sub

    Private Sub GameOver()

        Dim blnFinish As Boolean = True

        Dim intIndex As Integer
        Dim intRow As Integer
        Dim intCol As Integer

        For intRow = 0 To intNumberOfRows - 1

            For intCol = 0 To intNumberOfCols - 1

                If ((intIndex <> intNumberOfRows * intNumberOfCols) And Not (tilTiles(intRow, intCol) Is Nothing)) Then

                    blnFinish = blnFinish And (tilTiles(intRow, intCol).Index = intIndex)

                End If

                intIndex += 1

                If Not (blnFinish) Then Return

            Next

        Next

        If (blnFinish) Then

            tilTiles(intNumberOfRows - 1, intNumberOfCols - 1) = tilLast

            tilTiles(intNumberOfRows - 1, intNumberOfCols - 1).Visible = True

            MessageBox.Show("You Win", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            tilBlank = New Block(intNumberOfRows - 1, intNumberOfCols - 1)

        End If

    End Sub

    Private Sub MenuLoadPicture_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuLoadPicture.Click

        OpenFileDialog1.Filter = "All Picture Formats (*.jpg,*.bmp,*.gif, *.png)|*.jpg;*.bmp;*.gif;*.png"

        OpenFileDialog1.ShowDialog()

        Dim intRow As Integer
        Dim intCol As Integer

        For intRow = 0 To intNumberOfRows - 1

            For intCol = 0 To intNumberOfCols - 1

                Try

                    tilTiles(intRow, intCol).Dispose()

                Catch ex As Exception


                End Try

            Next

        Next

        Create(intNumberOfRows, intNumberOfCols)

        Dim intXThumb As Integer = intWidth * intNumberOfRows
        Dim intYThumb As Integer = intWidth * intNumberOfRows

        Dim imgImage As Image = Image.FromFile(OpenFileDialog1.FileName)

        imgImage = imgImage.GetThumbnailImage(intXThumb, intYThumb, Nothing, System.IntPtr.Zero)

        For intRow = 0 To intNumberOfRows - 1

            For intCol = 0 To intNumberOfCols - 1

                tilTiles(intRow, intCol).Tile(imgImage, New Point(intCol * intWidth, intRow * intWidth))

            Next

        Next

        tilBlank = New Block(intNumberOfRows - 1, intNumberOfCols - 1)

        blnLoaded = True
    End Sub

    Private Sub MenuShuffle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuShuffle.Click

        tilLast = tilTiles(intNumberOfRows - 1, intNumberOfCols - 1)

        tilLast.Visible = False

        tilTiles(intNumberOfRows - 1, intNumberOfCols - 1).Visible = False

        Randomize()

    End Sub

    Private Sub MenuSize3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuSize3.Click

        If (MenuSize3.Checked) Then Return

        Clear()

        MenuSize3.Checked = True

        intNumberOfRows = 3
        intNumberOfCols = 3

        Create(intNumberOfRows, intNumberOfCols)

    End Sub

    Private Sub MenuSize4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuSize4.Click

        If (MenuSize4.Checked) Then Return

        Clear()

        MenuSize4.Checked = True

        intNumberOfRows = 4
        intNumberOfCols = 4

        Create(intNumberOfRows, intNumberOfCols)

    End Sub

    Private Sub MenuSize5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuSize5.Click

        If (MenuSize5.Checked) Then Return

        Clear()

        MenuSize5.Checked = True

        intNumberOfRows = 5
        intNumberOfCols = 5

        Create(intNumberOfRows, intNumberOfCols)

    End Sub

    Private Sub Clear()

        MenuSize3.Checked = False
        MenuSize4.Checked = False
        MenuSize5.Checked = False

        Dim intRow As Integer
        Dim intCol As Integer

        For intRow = 0 To intNumberOfRows - 1

            For intCol = 0 To intNumberOfCols - 1

                Try

                    tilTiles(intRow, intCol).Dispose()

                Catch ex As Exception

                End Try

            Next

        Next

    End Sub

End Class

Public Structure Block

    Public intRow As Integer
    Public intCol As Integer

    Public Sub New(ByVal iRow As Integer, ByVal iCol As Integer)

        Me.intRow = iRow
        Me.intCol = iCol

    End Sub

End Structure