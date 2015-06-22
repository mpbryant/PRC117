Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms



Public Class kdu

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer


    Private Sub kdu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'create an array for each uniquely shaped button
        Dim VolDnArray(5) As Point
        VolDnArray(0) = New Point(0, 0)
        VolDnArray(1) = New Point(0, 45)
        VolDnArray(2) = New Point(58, 82)
        VolDnArray(3) = New Point(93, 57)
        VolDnArray(4) = New Point(86, 13)

        Dim VolUpArray(5) As Point
        VolUpArray(0) = New Point(0, 40)
        VolUpArray(1) = New Point(58, 0)
        VolUpArray(2) = New Point(93, 26)
        VolUpArray(3) = New Point(86, 70)
        VolUpArray(4) = New Point(0, 80)

        Dim PreDnArray(5) As Point
        PreDnArray(0) = New Point(0, 12)
        PreDnArray(1) = New Point(93, 0)
        PreDnArray(2) = New Point(93, 40)
        PreDnArray(3) = New Point(26, 80)
        PreDnArray(4) = New Point(0, 50)

        Dim PreUpArray(5) As Point
        PreUpArray(0) = New Point(0, 30)
        PreUpArray(1) = New Point(25, 2)
        PreUpArray(2) = New Point(93, 45)
        PreUpArray(3) = New Point(93, 80)
        PreUpArray(4) = New Point(0, 70)

        Dim entArray(5) As Point
        entArray(0) = New Point(0, 0)
        entArray(1) = New Point(37, 4)
        entArray(2) = New Point(37, 18)
        entArray(3) = New Point(20, 45)
        entArray(4) = New Point(0, 42)

        Dim clrArray(5) As Point
        clrArray(0) = New Point(0, 2)
        clrArray(1) = New Point(20, 0)
        clrArray(2) = New Point(37, 30)
        clrArray(3) = New Point(37, 40)
        clrArray(4) = New Point(0, 44)

        Dim pushRightArray(7) As Point
        pushRightArray(0) = New Point(0, 10)
        pushRightArray(1) = New Point(15, 10)
        pushRightArray(2) = New Point(15, 0)
        pushRightArray(3) = New Point(30, 20)
        pushRightArray(4) = New Point(15, 40)
        pushRightArray(5) = New Point(15, 30)
        pushRightArray(6) = New Point(0, 30)

        Dim pushLeftArray(8) As Point
        pushLeftArray(0) = New Point(0, 20)
        pushLeftArray(1) = New Point(15, 0)
        pushLeftArray(2) = New Point(15, 10)
        pushLeftArray(3) = New Point(30, 10)
        pushLeftArray(4) = New Point(30, 30)
        pushLeftArray(5) = New Point(15, 30)
        pushLeftArray(6) = New Point(15, 40)
        pushLeftArray(7) = New Point(0, 20)

        Dim pushUpArray(8) As Point
        pushUpArray(0) = New Point(0, 15)
        pushUpArray(1) = New Point(20, 0)
        pushUpArray(2) = New Point(40, 15)
        pushUpArray(3) = New Point(30, 15)
        pushUpArray(4) = New Point(30, 30)
        pushUpArray(5) = New Point(10, 30)
        pushUpArray(6) = New Point(10, 15)
        pushUpArray(7) = New Point(0, 15)

        Dim pushDownArray(8) As Point
        pushDownArray(0) = New Point(10, 0)
        pushDownArray(1) = New Point(30, 0)
        pushDownArray(2) = New Point(30, 15)
        pushDownArray(3) = New Point(40, 15)
        pushDownArray(4) = New Point(20, 30)
        pushDownArray(5) = New Point(0, 15)
        pushDownArray(6) = New Point(10, 15)
        pushDownArray(7) = New Point(10, 0)




        'create a GRAPHICSPATH reference
        Dim myVolDn As GraphicsPath = New GraphicsPath
        myVolDn.AddPolygon(VolDnArray)
        

        Dim myVolUp As GraphicsPath = New GraphicsPath
        myVolUp.AddPolygon(VolUpArray)

        Dim myPreDn As GraphicsPath = New GraphicsPath
        myPreDn.AddPolygon(PreDnArray)

        Dim myPreUp As GraphicsPath = New GraphicsPath
        myPreUp.AddPolygon(PreUpArray)

        Dim myEnt As GraphicsPath = New GraphicsPath
        myEnt.AddPolygon(entArray)

        Dim myClr As GraphicsPath = New GraphicsPath
        myClr.AddPolygon(clrArray)

        Dim myPushRight As GraphicsPath = New GraphicsPath
        myPushRight.AddPolygon(pushRightArray)

        Dim myPushLeft As GraphicsPath = New GraphicsPath
        myPushLeft.AddPolygon(pushLeftArray)

        Dim myPushUp As GraphicsPath = New GraphicsPath
        myPushUp.AddPolygon(pushUpArray)

        Dim myPushDown As GraphicsPath = New GraphicsPath
        myPushDown.AddPolygon(pushDownArray)

        Dim mySelect As GraphicsPath = New GraphicsPath
        mySelect.AddEllipse(0, 0, 25, 25)




        'create a new region based on the GRAPHICSPATH object
        volDnBtn.Region = New Region(myVolDn)
        volDnBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        volUpBtn.Region = New Region(myVolUp)
        volUpBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        preDnBtn.Region = New Region(myPreDn)
        preDnBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        preUpBtn.Region = New Region(myPreUp)
        preUpBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        entBtn.Region = New Region(myEnt)
        entBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        clrBtn.Region = New Region(myClr)
        clrBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        pushRightBtn.Region = New Region(myPushRight)
        pushRightBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        pushLeftBtn.Region = New Region(myPushLeft)
        pushLeftBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        pushUpBtn.Region = New Region(myPushUp)
        pushUpBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        pushDownBtn.Region = New Region(myPushDown)
        pushDownBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        selectBTN.Region = New Region(mySelect)
        selectBTN.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255)

        KduDimmer.Show()
        KduDimmer.Location = New Point(Me.Location.X + 178, Me.Location.Y + 154)
    End Sub


    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        Form1.btn0_Click(sender, e)
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Form1.btn1_Click(sender, e)
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Form1.btn2_Click(sender, e)
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        Form1.btn3_Click(sender, e)
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Form1.btn4_Click(sender, e)
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Form1.btn5_Click(sender, e)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Form1.btn6_Click(sender, e)
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Form1.btn7_Click(sender, e)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Form1.btn8_Click(sender, e)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Form1.btn9_Click(sender, e)
    End Sub

    Private Sub volDnBtn_Click(sender As Object, e As EventArgs) Handles volDnBtn.Click
        Form1.btnVolDn_Click(sender, e)
    End Sub

    Private Sub volUpBtn_Click(sender As Object, e As EventArgs) Handles volUpBtn.Click
        Form1.btnVolUp_Click(sender, e)
    End Sub

    Private Sub preDnBtn_Click(sender As Object, e As EventArgs) Handles preDnBtn.Click
        Form1.btnPreDn_Click(sender, e)
    End Sub

    Private Sub preUpBtn_Click(sender As Object, e As EventArgs) Handles preUpBtn.Click
        Form1.btnPreUp_Click(sender, e)
    End Sub

    Private Sub entBtn_Click(sender As Object, e As EventArgs) Handles entBtn.Click
        Form1.btnEnt_Click(sender, e)
    End Sub

    Private Sub clrBtn_Click(sender As Object, e As EventArgs) Handles clrBtn.Click
        Form1.btnClr_Click(sender, e)
    End Sub

    Public Sub StartDisplayTimer()

        displayTimer.Enabled = True
        displayTimer.Interval = 1000

    End Sub

    Private Sub displayTimerTick(sender As Object, e As EventArgs) Handles displayTimer.Tick

        displayTimer.Stop() 'stops the clock
        displayPic.BackgroundImage = My.Resources.Initializing_Screen
        displayPic.Visible = True
        displayTimer2.Enabled = True
        displayTimer2.Interval = 1000

    End Sub

    Private Sub displayTimer2_Tick(sender As Object, e As EventArgs) Handles displayTimer2.Tick

        displayTimer2.Stop()
        displayPic.Visible = False
        

    End Sub


    Private Sub HighligtSelectButton_MouseEnter(sender As Object, e As EventArgs) Handles pushUpBtn.MouseEnter, pushDownBtn.MouseEnter, pushLeftBtn.MouseEnter, pushRightBtn.MouseEnter, selectBTN.MouseEnter

        pushUpBtn.BackColor = Color.Gold
        pushDownBtn.BackColor = Color.Gold
        pushRightBtn.BackColor = Color.Gold
        pushLeftBtn.BackColor = Color.Gold
        selectBTN.BackColor = Color.Gold


    End Sub

    Private Sub HighligtSelectButton_MouseLeave(sender As Object, e As EventArgs) Handles pushUpBtn.MouseLeave, pushDownBtn.MouseLeave, pushLeftBtn.MouseLeave, pushRightBtn.MouseLeave, selectBTN.MouseLeave

        pushUpBtn.BackColor = Color.Transparent
        pushDownBtn.BackColor = Color.Transparent
        pushRightBtn.BackColor = Color.Transparent
        pushLeftBtn.BackColor = Color.Transparent
        selectBTN.BackColor = Color.Transparent


    End Sub


    Private Sub pushLeftBtn_Click(sender As Object, e As EventArgs) Handles pushLeftBtn.Click
        Form1.btnLeftArrow_click(sender, e)
    End Sub

    Private Sub pushRightBtn_Click(sender As Object, e As EventArgs) Handles pushRightBtn.Click
        Form1.btnRightArrow_Click(sender, e)
    End Sub

    Private Sub pushUpBtn_Click(sender As Object, e As EventArgs) Handles pushUpBtn.Click
        Form1.btn6_Click(sender, e)
    End Sub

    Private Sub pushDownBtn_Click(sender As Object, e As EventArgs) Handles pushDownBtn.Click
        Form1.btn9_Click(sender, e)
    End Sub

    Private Sub SelectBtn_Click(sender As Object, e As EventArgs) Handles selectBTN.Click
        Form1.btnEnt_Click(sender, e)
    End Sub

    Public Sub KDUregion()

        closeBtn.Visible = True
        moveBtn.Visible = True


    End Sub

    Private Sub moveBtn_MouseDown(sender As Object, e As MouseEventArgs) Handles moveBtn.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.X - Me.Top
    End Sub

    Private Sub moveBtn_MouseMove(sender As Object, e As MouseEventArgs) Handles moveBtn.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - 360
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub moveBtn_MouseUp(sender As Object, e As MouseEventArgs) Handles moveBtn.MouseUp
        drag = False
    End Sub

    Public Sub TransparencyShow()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        Me.TransparencyKey = Color.FromArgb(128, 128, 128)
        Me.closeBtn.Visible = False
        Me.moveBtn.Visible = False
        KduDimmer.Location = New Point(Me.Location.X + 178, Me.Location.Y + 154)
    End Sub

    Public Sub TransparencyHide()
        Me.TransparencyKey = Color.FromArgb(127, 127, 127)
        Me.closeBtn.Visible = True
        Me.moveBtn.Visible = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        KduDimmer.Location = New Point(Me.Location.X + 168, Me.Location.Y + 122)
    End Sub


    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub kdu_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            KduDimmer.Location = New Point(Me.Location.X + 168, Me.Location.Y + 122)
        Else
            KduDimmer.Location = New Point(Me.Location.X + 178, Me.Location.Y + 154)
        End If

    End Sub
End Class