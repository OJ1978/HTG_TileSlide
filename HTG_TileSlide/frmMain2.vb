Structure Block
    Public Row, Col As Integer
    Public Sub New(ByVal row As Integer, ByVal col As Integer)
        Me.Row = row
        Me.Col = col
    End Sub
End Structure

Public Class frmMain2
    Inherits System.Windows.Forms.Form

#Region "Private Fields"
    'Private Fields

    ' the tiles width/Height size
    Const tSquare As Integer = 64

    ' the image size in the tile
    ' here the image width and height
    'are both equal to tImageW
    Const tImageW As Integer = 62

    ' Number of rows in the Grid (Default)
    Dim nRows As Integer = 3

    ' Number of Columns in the Grid (Default)
    Dim nCols As Integer = 3

    ' rand variable is used in shuffling
    ' the tiles
    Dim rand As Random

    ' blankTile will keep information
    ' about the empty block and its 
    ' location(Row, Col) in the Grid
    Dim blankTile As Block

    'Check if a picture is loaded into the puzzle
    'or not
    Dim PictureLoaded As Boolean = False

    Dim timerCountdown As Integer  ' the timers total time

    ' a temproray tile, which hold info
    ' on the last tile in the grid
    Friend WithEvents tmplasttile As ctlTile

    ' the tiles used to build the puzzle
    Private tile(,) As ctlTile

    Friend WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents menuLoad As System.Windows.Forms.MenuItem
    Friend WithEvents menuShuffle As System.Windows.Forms.MenuItem
    Friend WithEvents menuSize As System.Windows.Forms.MenuItem
    Friend WithEvents menu3X3 As System.Windows.Forms.MenuItem
    Friend WithEvents menu4X4 As System.Windows.Forms.MenuItem
    Friend WithEvents menu5X5 As System.Windows.Forms.MenuItem
    Friend WithEvents openFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents menuGridColor As System.Windows.Forms.MenuItem
    Friend WithEvents menuWhite As System.Windows.Forms.MenuItem
    Friend WithEvents menuGreen As System.Windows.Forms.MenuItem
    Friend WithEvents menuBlue As System.Windows.Forms.MenuItem
    Friend WithEvents menuRed As System.Windows.Forms.MenuItem
    Friend WithEvents menuSilver As System.Windows.Forms.MenuItem
#End Region

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tRandom As System.Windows.Forms.Timer
    Private WithEvents tilesPanel As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tilesPanel = New System.Windows.Forms.Panel()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.menuLoad = New System.Windows.Forms.MenuItem()
        Me.menuShuffle = New System.Windows.Forms.MenuItem()
        Me.menuSize = New System.Windows.Forms.MenuItem()
        Me.menu3X3 = New System.Windows.Forms.MenuItem()
        Me.menu4X4 = New System.Windows.Forms.MenuItem()
        Me.menu5X5 = New System.Windows.Forms.MenuItem()
        Me.menuGridColor = New System.Windows.Forms.MenuItem()
        Me.menuWhite = New System.Windows.Forms.MenuItem()
        Me.menuGreen = New System.Windows.Forms.MenuItem()
        Me.menuBlue = New System.Windows.Forms.MenuItem()
        Me.menuRed = New System.Windows.Forms.MenuItem()
        Me.menuSilver = New System.Windows.Forms.MenuItem()
        Me.openFile = New System.Windows.Forms.OpenFileDialog()
        Me.tRandom = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'tilesPanel
        '
        Me.tilesPanel.BackColor = System.Drawing.Color.PaleGreen
        Me.tilesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tilesPanel.Location = New System.Drawing.Point(8, 8)
        Me.tilesPanel.Name = "tilesPanel"
        Me.tilesPanel.Size = New System.Drawing.Size(272, 224)
        Me.tilesPanel.TabIndex = 0
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuLoad, Me.menuShuffle, Me.menuSize, Me.menuGridColor})
        '
        'menuLoad
        '
        Me.menuLoad.Index = 0
        Me.menuLoad.Text = "Load Picture"
        '
        'menuShuffle
        '
        Me.menuShuffle.Enabled = False
        Me.menuShuffle.Index = 1
        Me.menuShuffle.Text = "Shuffle"
        '
        'menuSize
        '
        Me.menuSize.Index = 2
        Me.menuSize.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menu3X3, Me.menu4X4, Me.menu5X5})
        Me.menuSize.RadioCheck = True
        Me.menuSize.Text = "Size"
        '
        'menu3X3
        '
        Me.menu3X3.Checked = True
        Me.menu3X3.DefaultItem = True
        Me.menu3X3.Index = 0
        Me.menu3X3.RadioCheck = True
        Me.menu3X3.Text = "3 x 3"
        '
        'menu4X4
        '
        Me.menu4X4.Index = 1
        Me.menu4X4.RadioCheck = True
        Me.menu4X4.Text = "4 x 4"
        '
        'menu5X5
        '
        Me.menu5X5.Index = 2
        Me.menu5X5.RadioCheck = True
        Me.menu5X5.Text = "5 x 5"
        '
        'menuGridColor
        '
        Me.menuGridColor.Enabled = False
        Me.menuGridColor.Index = 3
        Me.menuGridColor.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuWhite, Me.menuGreen, Me.menuBlue, Me.menuRed, Me.menuSilver})
        Me.menuGridColor.Text = " Color"
        '
        'menuWhite
        '
        Me.menuWhite.Index = 0
        Me.menuWhite.Text = "White"
        '
        'menuGreen
        '
        Me.menuGreen.Checked = True
        Me.menuGreen.DefaultItem = True
        Me.menuGreen.Index = 1
        Me.menuGreen.Text = "Green"
        '
        'menuBlue
        '
        Me.menuBlue.Index = 2
        Me.menuBlue.Text = "Blue"
        '
        'menuRed
        '
        Me.menuRed.Index = 3
        Me.menuRed.Text = "Red"
        '
        'menuSilver
        '
        Me.menuSilver.Index = 4
        Me.menuSilver.Text = "Silver"
        '
        'tRandom
        '
        '
        'frmMain2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(288, 241)
        Me.Controls.Add(Me.tilesPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Menu = Me.mainMenu1
        Me.Name = "frmMain2"
        Me.Text = "Tiles Slide Puzzle"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Load mnfrm"
    'This function is called when the user 
    'uses the menu to load an image
    Private Sub mnfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MakeTiles(nRows, nCols)
    End Sub
#End Region

#Region "Randomize and Timer event"
    ' This function shuffles the tiles in the gird 
    Protected Sub Randomize()
        rand = New Random()
        timerCountdown = 64 * nRows * nCols

        'timer.Tick    += new EventHandler(TimerOnTick);
        tRandom.Interval = 1
        tRandom.Enabled = True
    End Sub

    ' Here a new location for moving a tile
    ' in the shuffling process is randomly
    ' made, on the condition to be in the limits
    ' of the puzzle's grid size.
    Private Sub TimerOnTick(ByVal obj As Object, ByVal ea As EventArgs) Handles tRandom.Tick
        Dim col As Integer = blankTile.Col
        Dim row As Integer = blankTile.Row

        Select Case (rand.Next(4))
            Case 0 : col += 1
            Case 1 : col -= 1
            Case 2 : row += 1
            Case 3 : row -= 1
        End Select

        If (col >= 0 And col < nCols And row >= 0 And row < nRows) Then
            ' after making a random location
            ' the tile is moved to that location
            MoveTile(col, row)
        End If

        timerCountdown = timerCountdown - 1
        If (timerCountdown = 0) Then
            tRandom.Stop()
        End If
    End Sub
#End Region

#Region "Move Tile (int Col, Int Row)"
    ' This function handles moving a tile
    ' to a new location in the grid
    Private Sub MoveTile(ByVal Col As Integer, ByVal Row As Integer)
        tile(Row, Col).Location = New Point(blankTile.Col * tSquare, _
                       blankTile.Row * tSquare)

        tile(blankTile.Row, blankTile.Col) = tile(Row, Col)
        tile(Row, Col) = Nothing
        blankTile = New Block(Row, Col)
    End Sub
#End Region

#Region "Make Tiles (int Rows, int Cols)"
    ' This function builds the tiles in the grid 
    ' and arranges them
    Public Sub MakeTiles(ByVal Rows As Integer, ByVal Cols As Integer)
        Dim index As Integer = 0

        ReDim tile(Rows, Cols)
        tilesPanel.Size = New Size(tSquare * Rows + 4, tSquare * Cols + 4)
        tilesPanel.Location = New Point(4, 4)
        Me.ClientSize = New Size(tilesPanel.Size.Width + 6, tilesPanel.Size.Height + 6)

        Dim Row, Col As Integer
        For Row = 0 To Rows - 1
            For Col = 0 To Cols - 1
                tile(Row, Col) = New ctlTile(tSquare, tSquare, index)
                tile(Row, Col).Parent = Me.tilesPanel
                tile(Row, Col).Location = New Point(Col * tSquare, Row * tSquare)
                index += 1
            Next
        Next
    End Sub
#End Region

#Region "KeyBoard and Mouse events"
    ' Here all the key events handled in the puzzle
    ' are identified
    Private Sub mnfrm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ' Check if the game is shuffled
        ' or not
        If ((menuShuffle.Enabled) Or (PictureLoaded = False)) Then Return

        ' Arrow Keys Left
        If (e.KeyCode = Keys.Left And blankTile.Col < nCols - 1) Then
            MoveTile(blankTile.Col + 1, blankTile.Row)

            ' Arrow Keys Right
        ElseIf (e.KeyCode = Keys.Right And blankTile.Col > 0) Then
            MoveTile(blankTile.Col - 1, blankTile.Row)

            ' Arrow Keys Up
        ElseIf (e.KeyCode = Keys.Up And blankTile.Row < nRows - 1) Then
            MoveTile(blankTile.Col, blankTile.Row + 1)

            ' Arrow Keys Down
        ElseIf (e.KeyCode = Keys.Down And blankTile.Row > 0) Then
            MoveTile(blankTile.Col, blankTile.Row - 1)

        End If

        e.Handled = True  'Handle the event !!
        CheckFinish()     'Check if the puzzle is solved
    End Sub

    ' Here all the mouse events handled in the puzzle
    ' are identified
    Private Sub tilesPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tilesPanel.MouseDown
        ' Check if the game is shuffled
        ' or not
        If ((menuShuffle.Enabled) Or (PictureLoaded = False)) Then Return

        Dim Col As Integer = e.X \ tSquare  'integer division
        Dim Row As Integer = e.Y \ tSquare  'integer division

        If (Col = blankTile.Col) Then
            If (Row < blankTile.Row) Then
                Dim Row2 As Integer
                For Row2 = blankTile.Row - 1 To Row Step -1
                    MoveTile(Col, Row2)
                Next

            ElseIf (Row > blankTile.Row) Then
                Dim Row2 As Integer
                For Row2 = blankTile.Row + 1 To Row
                    MoveTile(Col, Row2)
                Next
            End If

        ElseIf (Row = blankTile.Row) Then
            If (Col < blankTile.Col) Then
                Dim Col2 As Integer
                For Col2 = blankTile.Col - 1 To Col Step -1
                    MoveTile(Col2, Row)
                Next

            ElseIf (Col > blankTile.Col) Then
                Dim Col2 As Integer
                For Col2 = blankTile.Col + 1 To Col
                    MoveTile(Col2, Row)
                Next
            End If
        End If

        CheckFinish() ' Check if the puzzle is solved
    End Sub
#End Region

#Region "Check tiles if rearranged Correctly"
    ' this Method checks if the tiles are rearranged in the
    ' correct order, if so the game is said to be over and
    ' the player is congratulated :)
    Private Sub CheckFinish()
        Dim Finished As Boolean = True

        Dim index As Integer = 0
        Dim Row, Col As Integer

        For Row = 0 To nRows - 1
            For Col = 0 To nCols - 1
                If ((index <> nRows * nCols) And Not (tile(Row, Col) Is Nothing)) Then
                    Finished = Finished And (tile(Row, Col).tIndex = index)
                End If
                index += 1
                If Not (Finished) Then Return
            Next
        Next

        If (Finished) Then
            tile(nRows - 1, nCols - 1) = tmplasttile
            tile(nRows - 1, nCols - 1).Visible = True
            MessageBox.Show("Congratulations!!, You did it !!", "Game Over", _
              System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
            blankTile = New Block(nRows - 1, nCols - 1)
            menuShuffle.Enabled = True
            menuGridColor.Enabled = False
        End If
    End Sub
#End Region

#Region "Load an Image to the Grid"
    ' This method handles the image loading prosses
    ' also here the image is cut into block (nRows by nCols)
    ' then pasted on the tiles in the grid
    Private Sub menuLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuLoad.Click
        openFile.FileName = ""
        ' the formats acceptable
        openFile.Filter = "All Picture Files (*.jpg,*.bmp,*.gif)|*.jpg;*.bmp;*.gif"
        openFile.ShowDialog()
        If (openFile.FileName = "") Then
            menuShuffle.Enabled = False
            menuGridColor.Enabled = True
            Return
        End If

        Dim Row, Col As Integer
        For Row = 0 To nRows - 1
            For Col = 0 To nCols - 1
                Try
                    tile(Row, Col).Dispose()
                Catch
                    'Do nothing
                End Try
            Next
        Next

        MakeTiles(nRows, nCols)

        Dim cxThumbnail As Integer = tImageW * nRows
        Dim cyThumbnail As Integer = tImageW * nRows

        Dim Pic As Image = Image.FromFile(openFile.FileName)
        Pic = Pic.GetThumbnailImage(cxThumbnail, cyThumbnail, Nothing, System.IntPtr.Zero)

        Console.WriteLine(tile(0, 0).Location)
        For Row = 0 To nRows - 1
            For Col = 0 To nCols - 1
                tile(Row, Col).tilePicture(Pic, New Point(Col * tImageW, Row * tImageW))
            Next
        Next

        blankTile = New Block(nRows - 1, nCols - 1)
        menuShuffle.Enabled = True
        menuGridColor.Enabled = False
        PictureLoaded = True
    End Sub
#End Region

#Region "menu Shuffle the Tiles"
    ' This method calls the Randomize function
    Private Sub menuShuffle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuShuffle.Click
        menuShuffle.Enabled = False
        menuGridColor.Enabled = True
        tmplasttile = tile(nRows - 1, nCols - 1)
        tmplasttile.Visible = False
        tile(nRows - 1, nCols - 1).Visible = False
        Randomize()
    End Sub
#End Region

#Region "menu SIZE"
    ' Here all the sizing process is done, care must be taken
    ' that if the grid size is changed the tiles are cleared
    ' for a new game!!

    ' This method sets the grid to 3X3 (3 Rows by 3 Columns)
    Private Sub menu3X3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu3X3.Click
        If (menu3X3.Checked) Then Return
        clearItems()
        menu3X3.Checked = True
        nRows = 3
        nCols = 3
        MakeTiles(nRows, nCols)
    End Sub

    ' This method sets the grid to 4X4 (4 Rows by 4 Columns)
    Private Sub menu4X4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu4X4.Click
        If (menu4X4.Checked) Then Return
        clearItems()
        menu4X4.Checked = True
        nRows = 4
        nCols = 4
        MakeTiles(nRows, nCols)
    End Sub

    ' This method sets the grid to 5X5 (5 Rows by 5 Columns)
    Private Sub menu5X5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu5X5.Click
        If (menu5X5.Checked) Then Return
        clearItems()
        menu5X5.Checked = True
        nRows = 5
        nCols = 5
        MakeTiles(nRows, nCols)
    End Sub

    ' This function clears all the check marks in the Size menu
    Private Sub clearItems()
        menu3X3.Checked = False
        menu4X4.Checked = False
        menu5X5.Checked = False
        Dim Row, Col As Integer
        For Row = 0 To nRows - 1
            For Col = 0 To nCols - 1
                Try
                    tile(Row, Col).Dispose()
                Catch
                    'do nothing
                End Try
            Next
        Next
        menuShuffle.Enabled = False
        menuGridColor.Enabled = True
        PictureLoaded = False
    End Sub

#End Region

#Region "Grid Color"

    ' Here the menu Color Grid processing
    ' is handled

    Private Sub ClearColors()
        menuWhite.Checked = False
        menuGreen.Checked = False
        menuBlue.Checked = False
        menuRed.Checked = False
        menuSilver.Checked = False
    End Sub

    Private Sub menuWhite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuWhite.Click
        ClearColors()
        menuWhite.Checked = True
        Me.tilesPanel.BackColor = Color.LightYellow
    End Sub

    Private Sub menuGreen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuGreen.Click
        ClearColors()
        menuWhite.Checked = True
        Me.tilesPanel.BackColor = Color.PaleGreen
    End Sub

    Private Sub menuBlue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuBlue.Click
        ClearColors()
        menuWhite.Checked = True
        Me.tilesPanel.BackColor = Color.LightBlue
    End Sub

    Private Sub menuRed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuRed.Click
        ClearColors()
        menuWhite.Checked = True
        Me.tilesPanel.BackColor = Color.LightCoral
    End Sub

    Private Sub menuSilver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSilver.Click
        ClearColors()
        menuWhite.Checked = True
        Me.tilesPanel.BackColor = Color.Silver
    End Sub

#End Region

    Private Sub menuGridColor_Click(sender As Object, e As EventArgs) Handles menuGridColor.Click

    End Sub
End Class
