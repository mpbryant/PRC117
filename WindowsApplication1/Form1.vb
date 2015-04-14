Imports System.Threading
Imports System.Data.SqlClient






Public Class Form1


    Dim timeDelayCount As Integer = 1
    Dim timeDelayCountHigh As Integer = 5
    Dim pressNum As Integer = 0
    Dim timeStart As Integer = 0
    Dim timeEnd As Integer
    Dim formIsClosed As Boolean = False
    Dim image As Boolean = False  'variable used to determine if the background image is anything except blank
    Dim t As Thread 'thread variable used to control the display background image and visability
    Dim knobIndex As Integer = 0 'used as a reference number to indicate which knob image is loaded
    Dim screenReady As Boolean = False 'used to indicate if the display is blank and green
    Dim vulosDisplayed As Boolean = False 'used to indicate a vulos page is shown on the PRC display
    Dim pageDisplayed As Integer 'used to indicate what page is displayed. Used along with vulosDisplayed, and postFailDisplayed to indicate what the display should present
    Dim postFailDisplayed As Boolean = False 'used to indicate a POST FAIL page is shown on the PRC display
    Dim scrollingDown As String 'used in case statement to determine what is placed next into d1TB when scrolling down
    Dim scrollingUp As String 'used in case statement to determine what is placed next into b1TB when scrolling up

    Dim ml1 As String 'determines the highest menu level. Aids ml2, ml3, ml4 in determining which methods to use
    Dim ml2 As String
    Public ml3 As String = "" 'some menus have different ml3s such as TX or RX. set this variable with that ml3 option when the ml3 forks.
    Dim ml4 As String
    Dim ml5 As String
    Dim ml6 As String
    Dim menuDepth As Integer 'represents the combined information of ml1-ml6 to show what menu is displayed

    Dim desiredPage As String 'represents the page that the user wants to see

    Dim thread2 As Thread

    Dim digit1 As New TextBox 'digits are for the individual digits that allow for tuning the radio or ip address input
    Dim digit2 As New TextBox
    Dim digit3 As New TextBox
    Dim digit4 As New TextBox
    Dim digit5 As New TextBox
    Dim digit6 As New TextBox
    Dim digit7 As New TextBox
    Dim digit8 As New TextBox
    Dim digit9 As New TextBox
    Dim digit10 As New TextBox
    Dim digit11 As New TextBox
    Dim digit12 As New TextBox
    Dim digitHighlighted() As TextBox

    Dim previousPage As String 'represents the previous page displayed
    Dim updatedFreq As String = "0227.5000" 'holds the frequency after changing the number
    Dim tempRecall As String = "" 'holds the temporary frequency until stored in updatedFreq

    Dim currentPageNum As Integer 'used to indicate what page (of multiple page options) is displayed
    Dim updatedDB As String = "00" 'used to store the db level of the transmit power in the wideband tests menu
    Dim rfPath As String 'used to determine if the system is in wideband or lowband operation
    Dim timeDuration As String 'stores the receive test duration time entered by the user
    Dim updatedDuration As String = "000" 'stores the test duration during wideband receive tests

    Dim fLow As String 'used as the low frequency reference
    Dim fHigh As String 'used as the high frequency reference
    Dim combinedString As String 'used to concatenate the D string

    Dim direction As String = "forward" 'set by subs to determine which direction to flow (ie right arrow vs left arrow)

    Dim tbBorder1 As New TextBox 'three textboxes used to create a progressbar
    Dim tbBack As New TextBox
    Dim tbFront As New TextBox
    Dim meterReading As Decimal = 0.0 'used to increment the progressbar during the SW Validation test
    Dim lengthOfDelay As Decimal = 0 'used in GeneralTimer as the length of the desired delay
    Dim keypadLock As String = "" 'used to store the passwordto unlock the keypad
    Dim timeItTakes As Decimal = 1800 'used to determine the time it takes for a progressbar to transition 0 to full 

    Dim missionLoaded(98) As String 'array to hold mission plan files
    Dim missionPlanDateTime(98) As Date 'array to hold mission file dates
    Dim missionIndex As Integer 'mission plan array index

    Dim ip1 As New TextBox 'used to store ip address, first digit
    Dim ip2 As New TextBox 'used to store ip address
    Dim ip3 As New TextBox 'used to store ip address
    Dim ip4 As New TextBox 'used to store decimal point
    Dim ip5 As New TextBox 'used to store ip address
    Dim ip6 As New TextBox 'used to store ip address
    Dim ip7 As New TextBox 'used to store ip address
    Dim ip8 As New TextBox 'used to store decimal point
    Dim ip9 As New TextBox 'used to store ip address
    Dim ip10 As New TextBox 'used to store ip address
    Dim ip11 As New TextBox 'used to store ip address
    Dim ip12 As New TextBox 'used to store decimal point
    Dim ip13 As New TextBox 'used to store ip address
    Dim ip14 As New TextBox 'used to store ip address
    Dim ip15 As New TextBox 'used to store ip address
    Dim ipAddress As String 'stores the ip address for ping tests

    Dim keychainDigit(16) As Integer 'stores the digit information , 1-16
    Dim keychain(10) As String 'stores the completed chain, 1-10

    Dim numberPushed As Integer 'stores the number assigned to the keypad button
    Dim currentDateTime As Date 'stores the current date time
    Dim pppState As String = "ONLINE" 'stores the PPP state
    Dim PPPAddress As String = "10.0.0.1" 'stores the PPP IP address 
    Dim peerAddress As String = "10.0.0.2" 'used to store the Peer IP address

    Dim thread3 As Thread
    Dim radioSilenceState As String = "OFF" 'stores the radio silence condition
    Dim txPower As String = "USER" 'stores the selected transmit power
    Dim txPowerDB As Integer = 0 'stores the user selected transmit power
    Dim txPwr As String = "00 DB DOWN (+10.0 W)" 'stores the user selected transmit power as a string
    Dim waveform As String = "VULOS" 'stores the key information name
    Dim encryptionType(11, 8) As String 'stores the type of encryption
    Dim waveVal As Integer
    Dim typeVal As Integer

    Dim menuItems(10, 15) As String 'represents the last item in a menu
    Dim ArrayUpperLimit As Integer
    Dim xHi As Integer = 15 'represents the upper array value
    Dim xLo As Integer = 0 'represents the lower array value
    Dim xCurrent As Integer = 0 'represents teh current location in the array
    Dim xHighlitedText As String 'used to store the highlighted text in an array
    Dim menuChoices As String 'represents the menu selection

    Dim fillPort As String 'represents the fill port type
    Dim fillDevice As String 'represents the fill device used
    Dim keyType As String 'represents the key type being used
    Dim maxFillNum As Integer 'used along with GenericNumberScroll() to initiate the highest number 

    Dim from As String
    Dim light As Integer = 0 'represents the state of the backlight 1=on, 0=off
    Dim senderName As String =""   'variable representing the sending sub

    Dim volBar As Integer = 451   'represents the volume level bar graph as a pixel location
    Dim volumeBar As New TextBox 'the top visible moving scale
    Dim volumeBarBackground As New TextBox 'the green background of the volume bar
    Dim volumeBarOutline As New TextBox 'The black outline surrounding the volume scale

    Public presetRowNum As Integer 'used to iterate through the presets data table
    Dim dash As String = "-" 'used to look for a - in b1TB

    'used to store the data from the datagrid so it can be placed in a textbox
    Public storedNumber As String
    Public storedName As String
    Public storedType As String
    Public storedTraffic As String
    Public storedMod As String
    Public storedDescription As String
    Public storedRXfreq As String
    Public storedTXfreq As String
    Public storedWaveform As String
    Public storedChannel As String
    Public storedKey As String
    Public storedOption As String
    Public storedBW As String
    Public storedBPS As String
    Public storedVoiceMode As String
    Public storedInterleave As String
    Public storedFWDerror As String
    Public storedSquelch As String
    Public lastClick As Integer 'used to track button clicks during text entry from keyboard
    Public myCount As Integer  'start myCount over


    'used for storing the name or description of stored presets
    Dim nameBox1 As New TextBox
    Dim nameBox2 As New TextBox
    Dim nameBox3 As New TextBox
    Dim nameBox4 As New TextBox
    Dim nameBox5 As New TextBox
    Dim nameBox6 As New TextBox
    Dim nameBox7 As New TextBox
    Dim nameBox8 As New TextBox
    Dim nameBox9 As New TextBox
    Dim nameBox10 As New TextBox
    Dim nameBox11 As New TextBox
    Dim nameBox12 As New TextBox
    Dim nameBox13 As New TextBox
    Dim nameBox14 As New TextBox
    Dim nameBox15 As New TextBox
    Dim nameBox16 As New TextBox
    Dim nameBox17 As New TextBox
    Dim nameBox18 As New TextBox
    Dim nameBox19 As New TextBox
    Dim nameBox20 As New TextBox

    Dim nameBoxesAdded As Boolean = False
    Dim highlightedNameBox As TextBox 'used to store the name of the nameBox that is highlighted
    Dim nextBox As TextBox 'used to store the name of the next nameBox that is going to be highlighted
    Dim lastBox As TextBox 'used to store the name of the previously highlighted nameBox (for left arrow operations)
    Dim testString As String 'tests the nameboxes for INSERT DESCRIPTION
    Dim newName As String 'stores the new name of the preset as typed by the user
    Public newWave As String 'stores the new waveform of the preset as selected by the user    
    Dim newDesc As String 'stores the new description of the preset as selected by the user


    Dim satcomChannelInt As Integer
    Dim newRXfreq As String
    Dim newTXfreq As String

    Dim thisNum As String
    Dim wasNumBx1Changed As Boolean = False
    Dim wasNumBx2Changed As Boolean = False
    Dim wasNumBx3Changed As Boolean = False
    Dim newSatcomChannel As Integer
    Dim freqRange As String
    Dim testFreq As Double
    Dim transmitChoice As String
    Public storedCryptoMode As String
    Public storedCryptoKey As String
    Public tekNum As String
    Public convertedTekNum As Integer
    Public tekString As String
    Public storedSatcomChannel As String
    Public mySatcomInt As Integer
    Public MySatcomChannel As String
    Public tempTrafficMode As String
    Public storedDataMode As String
    Public tempVoiceMode As String
    Public shortStoredTraffic As String
    Public storedCodebook As String
    Public storedKeySource As String
    Public storedAutoswitch As String
    Public storedRXfade As String
    Public storedTrainingFrames As String
    Public storedFascinatorMode As String
    Public storedKG84Mode As String
    Public storedAESmode As String

    Dim page4TB1 As New TextBox()
    Dim page4TB2 As New TextBox()
    Dim storedDeviation As String
    Dim storedOptMod As String
    Public tempB2text As String
    Dim storedTXpower As String
    Dim storedTXpowerDown As String
    Dim myDBdown As String
    Dim manualSquelchSetting As Integer
    Dim storedCTCSS As Integer
    Dim storedCTCSSfreq As String
    Dim storedCTCSSeia As String
    Dim storedCTCSSham As String
    Dim forcedback As Boolean
    Dim storedRxSquelch As String
    Dim storedCTCSSuserEntry As String
    Dim storedCTCSSrx As String
    Dim storedCTCSSrxFreq As String
    Dim storedCTCSSrxEIA As String
    Dim storedCTCSSrxHAM As String
    Dim storedCTCSSrxUserEntry As String
    Dim storedCTCSStemp As String
    Dim storedChannelBusyPriority As String
    Dim storedCDCSStxCode As String
    Dim storedCDCSSrxCode As String
    Dim temp As String
    Dim storedVinsonCompatibility As String


    'storing beacon information
    Dim storedBeaconFreq As String
    Dim storedBeaconMod As String
    Dim storedBeaconTxDuration As String
    Dim storedBeaconOffDuration As String
    Dim storedBeaconTxPower As String
    Dim tempBeaconFreq As String
    Dim pwrBarOutline As New TextBox
    Dim pwrBarBackground As New TextBox
    Dim storedScanEnable As String
    Dim storedInScanList As String

    'creates anew instance of a table adqapter
    Dim ScanListTA As New StoredPresetsDataSetTableAdapters.PRCtrainerTableAdapter()
    Dim scanNum(98) As String
    Dim scanName(98) As String
    Dim scanListComplete(5) As String
    Dim scanListFull As Boolean
    Dim scanListIsEmpty As Boolean
    Dim removalCandidate As String
    Dim storedPriorityTx As String
    Dim storedPriorityRxEnable As String
    Dim storedPriorityRx As String
    Dim storedHoldTimeDuration As String
    Dim storedEnableHoldTime As String
    Dim storedHangTime As String
    Dim storedSpare As String
    Dim storedRxPriorityScanning As String
    Dim modBox As New TextBox()

    'Radio Config Submenu
    Const defaultMaintPswd As String = "H2445830"
    Dim tempMaintPswd As String = ""
    Dim tempMaintPswd2 As String = ""
    Dim newMaintPswd As String = ""
    Dim pswd1 As String
    Dim pswd2 As String
    Dim pswd3 As String
    Dim pswd4 As String
    Dim pswd5 As String
    Dim pswd6 As String
    Dim pswd7 As String
    Dim pswd8 As String
    Dim pswd9 As String
    Dim pswd10 As String
    Dim pswd11 As String
    Dim pswd12 As String
    Dim b1Warning As String
    Dim c1Warning As String
    Dim storedGPStype As String
    Dim storedGPSsleepEnable As String
    Dim storedPositionFormat As String
    Dim storedTransmitMode As String
    Dim storedMaintSelection As String
    Dim tempWaveform As String
    Dim tempCryptoMode As String
    Dim tempKeyType As String
    Dim alarm As Boolean = False

    Dim mycolor As Color = Color.FromName("ForestGreen")

    Dim xfactor As Integer = 211    'fixed values to adjust the difference of item locations on KDU display compared to PRC display
    Dim yfactor As Integer = -22
    Dim startTimerCount As Integer = 0  'used to count the clock ticks in TurnOnCheck()
    Dim numOfInstances As Integer

    


    






    'knob section

    Private Sub btnOFF_Click(sender As Object, e As EventArgs) Handles btnOFF.Click 'event handler when the mode knob is turned OFF
        ModeKnob.BackgroundImage = My.Resources.KnobOFF  'loads knob image in off position
        tbBorder1.Visible = False
        tbBack.Visible = False
        tbFront.Visible = False
        volumeBarBackground.Visible = False
        volumeBarOutline.Visible = False
        page4TB1.Visible = False
        page4TB2.Visible = False
        knobIndex = 0 'sets the index for off to 0
        FlashRoff() 'added to ensure A1TB is off when screen is off
        ShutDown()
    End Sub

    Private Sub btnCT_Click(sender As Object, e As EventArgs) Handles btnCT.Click 'event handler when the mode knob is turned to CT (Cypher Text)
        If (ml3 = "alarm occurred" Or ml3 = "zeroize alert") And knobIndex <> 0 Then
            ModeKnob.BackgroundImage = My.Resources.KnobCT 'loads knob image in CT position
            knobIndex = 1 'sets the index for CT to 1
            Exit Sub
        End If

        DisplayReset()
        SetVisibilityOFF()

        

        ml1 = ""
        ml2 = ""
        ml3 = ""
        ml4 = ""
        ml5 = ""
        ml6 = ""
        HelperUpdate()


        ModeKnob.BackgroundImage = My.Resources.KnobCT 'loads knob image in CT position
        knobIndex = 1 'sets the index for CT to 1

        

        TurnOnCheck() 'checks if the system has just been turned on

        If screenReady = True Then

            DisplayVulosPage1()
        End If
        MyCreateIPboxes()


    End Sub

    Private Sub btnPT_Click(sender As Object, e As EventArgs) Handles btnPT.Click 'event handler when the mode knob is turned or PT (Plain Text)
        If (ml3 = "alarm occurred" Or ml3 = "zeroize alert") And knobIndex <> 0 Then
            ModeKnob.BackgroundImage = My.Resources.KnobPT 'loads knob image in CT position
            knobIndex = 2 'sets the index for PT to 2
            Exit Sub
        End If


        DisplayReset()
        SetVisibilityOFF()
        ml1 = ""
        ml2 = ""
        ml3 = ""
        ml4 = ""
        ml5 = ""
        ml6 = ""
        HelperUpdate()

        ModeKnob.BackgroundImage = My.Resources.KnobPT 'loads knob image in PT position
        knobIndex = 2 'sets the index for PT to 2
        TurnOnCheck() 'checks if the system has just been turned on

        If screenReady = True Then

            DisplayVulosPage1()
        End If
        MyCreateIPboxes()

    End Sub

    Private Sub btnLD_Click(sender As Object, e As EventArgs) Handles btnLD.Click 'event handler when the mode knob is turned to LOAD

        If (ml3 = "alarm occurred" Or ml3 = "zeroize alert") And knobIndex <> 0 Then
            ModeKnob.BackgroundImage = My.Resources.KnobLD 'loads knob image in LOAD position
            knobIndex = 3 'sets the index for LOAD to 3
            Exit Sub
        End If

        DisplayReset()
        SetVisibilityOFF()
        ml1 = ""
        ml2 = ""
        ml3 = ""
        ml4 = ""
        ml5 = ""
        ml6 = ""
        HelperUpdate()


        ModeKnob.BackgroundImage = My.Resources.KnobLD 'loads knob image in LOAD position
        knobIndex = 3 'sets the index for LOAD to 3
        TurnOnCheck() 'checks if the system has just been turned on

        If screenReady = True Then

            DisplayLoadPage1()
        End If
        MyCreateIPboxes()


    End Sub

    Private Sub btnZeroize_Click(sender As Object, e As EventArgs) Handles btnZeroize.Click 'event handler when the mode knob is turned to ZEROIZE
        DisplayReset()
        SetVisibilityOFF()
        ml1 = ""
        ml2 = ""
        ml3 = ""
        ml4 = ""
        ml5 = ""
        ml6 = ""
        HelperUpdate()


        ModeKnob.BackgroundImage = My.Resources.KnobZ 'loads knob image in LOAD position
        knobIndex = 4 'sets the index for LOAD to 3
        TurnOnCheck() 'checks if the system has just been turned on

        If screenReady = True Then
            AlarmOccurred()

        End If
        MyCreateIPboxes()



    End Sub

    'button section

    Public Sub btnVolUp_Click(sender As Object, e As EventArgs) Handles btnVolUp.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If
        If ml1 = "lock keypad" Then 'locks the keypad


        ElseIf ml2 = "keypad test" And ml3 = "press any key" Then
            c1TB.Text = "VOLUME UP"
            PositionAndHighlight()

        ElseIf knobIndex <> 0 And a1TB.Text = "R" Then
            senderName = "volumeUp"
            ChangeVolume()
        End If

    End Sub

    Public Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        thisNum = "1"

        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If

        'checks if the VULOS 1 page is active
        If vulosDisplayed = True Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "1"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "1"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If




        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "1"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "1"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If






        If ml1 = "lock keypad" Then 'locks the keypad
            keypadLock = "1"
        ElseIf ml2 = "keypad test" And ml3 = "press any key" Then
            c1TB.Text = "1 BUTTON"
            PositionAndHighlight()
        ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
            numberPushed = 1
            EnterNumber()
        End If





        'for using buttons as a keyboard
        If (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

            If lastClick <> 1 Then
                lastClick = 1 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            If myCount = 5 Then 'sets the highest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "A"
                Case 2
                    highlightedNameBox.Text = "B"
                Case 3
                    highlightedNameBox.Text = "C"
                Case 4
                    highlightedNameBox.Text = "1"
            End Select

            ArrangeNameboxes()

            myCount += 1
            lastClick = 1

        End If

        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

    End Sub

    Public Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        thisNum = "2"

        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If

        'checks if the VULOS 1 page is active
        If vulosDisplayed = True Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "2"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "2"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If




        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "2"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "2"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If






        If ml1 = "lock keypad" Then 'locks the keypad
        ElseIf ml2 = "keypad test" And ml3 = "press any key" Then
            c1TB.Text = "2 BUTTON"
            PositionAndHighlight()
        ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
            numberPushed = 2
            EnterNumber()
        Else
            Backlight()
        End If

        'for using buttons as a keyboard
        If (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

            If lastClick <> 2 Then
                lastClick = 2 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            If myCount = 5 Then 'sets the highest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "D"
                Case 2
                    highlightedNameBox.Text = "E"
                Case 3
                    highlightedNameBox.Text = "F"
                Case 4
                    highlightedNameBox.Text = "2"
            End Select

            ArrangeNameboxes()


            myCount += 1
            lastClick = 2

        End If

        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

    End Sub

    Public Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        thisNum = "3"

        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml1 = "program" And ml2 = "" Then
            ml1 = "mode"
            ml2 = ""
            HelperUpdate()
            ModeMainPage()
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If

        'checks if the VULOS 1 page is active
        If vulosDisplayed = True Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "3"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "3"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If


        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "3"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "3"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If





        If ml1 = "lock keypad" Then 'locks the keypad
            keypadLock = keypadLock + "3"
        ElseIf ml2 = "keypad test" And ml3 = "press any key" Then
            c1TB.Text = "3 BUTTON"
            PositionAndHighlight()
        ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
            numberPushed = 3
            EnterNumber()


            'for using buttons as a keyboard
        ElseIf (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

            If lastClick <> 3 Then
                lastClick = 3 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            If myCount = 5 Then 'sets the highest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "G"
                Case 2
                    highlightedNameBox.Text = "H"
                Case 3
                    highlightedNameBox.Text = "I"
                Case 4
                    highlightedNameBox.Text = "3"
            End Select

            ArrangeNameboxes()


            myCount += 1
            lastClick = 3


        ElseIf ml1 <> "main zeroize menu" And (knobIndex = 1 Or knobIndex = 2) Then
            ml1 = "mode"
            checkArray()
        End If

        If ml1 = "main zeroize menu" Then
            ModeMainPage()
        End If

        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

    End Sub

    Public Sub btnPreUp_Click(sender As Object, e As EventArgs) Handles btnPreUp.Click

        If ml1 = "lock keypad" Then 'locks the keypad
            Exit Sub
        ElseIf ml2 = "keypad test" And ml3 = "press any key" Then
            c1TB.Text = "PRESET UP"
            PositionAndHighlight()
            Exit Sub
        End If

        senderName = "BtnPreUp"

        If ButtonBypass() = True Then
            Exit Sub
        End If

        DisplayReset()
        DisplayVulosPage1()

        'iterates through the presets in a VULOS page
        If (b1TB.Text.IndexOf(dash) <> -1) Or (c1TB.Text.IndexOf(dash) <> -1) Then 'looks for a - in the b1TB
            If presetRowNum <= 97 Then
                presetRowNum += 1
            Else
                presetRowNum = 0
            End If
            RecallPreset()

            If ml3 = "system preset number" Then
                SystemPresetNumber()
            End If

            If ml3 = "add scan list" Then
                AddScanList()
            End If

        End If
        'end iterates






    End Sub

    Public Sub btnVolDn_Click(sender As Object, e As EventArgs) Handles btnVolDn.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If
        If ml1 = "lock keypad" Then 'locks the keypad
        ElseIf ml2 = "keypad test" And ml3 = "press any key" Then
            c1TB.Text = "VOL DOWN"
            PositionAndHighlight()

        ElseIf knobIndex <> 0 And a1TB.Text = "R" Then
            senderName = "volumeDown"
            ChangeVolume()
        End If

    End Sub

    Public Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        thisNum = "4"

        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml1 = "" Then
            senderName = "squelch button pushed"
            AnalogSquelchType()
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If

        'checks if the VULOS 1 page is active
        If vulosDisplayed = True Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "4"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "4"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If




        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "4"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "4"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If





        If ml1 = "lock keypad" Then 'locks the keypad
        ElseIf ml2 = "keypad test" And ml3 = "press any key" Then
            c1TB.Text = "4 BUTTON"
            PositionAndHighlight()
        ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
            numberPushed = 4
            EnterNumber()
        End If



        'for using buttons as a keyboard
        If (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

            If lastClick <> 4 Then
                lastClick = 4 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            If myCount = 5 Then 'sets the highest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "J"
                Case 2
                    highlightedNameBox.Text = "K"
                Case 3
                    highlightedNameBox.Text = "L"
                Case 4
                    highlightedNameBox.Text = "4"
            End Select

            ArrangeNameboxes()


            myCount += 1
            lastClick = 4

        End If

        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

    End Sub

    Public Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        thisNum = "5"

        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If

        'checks if the VULOS 1 page is active
        If vulosDisplayed = True Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "5"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "5"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If




        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "5"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "5"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If

            Exit Sub
        End If





        If ml1 = "lock keypad" Then 'locks the keypad
        ElseIf ml2 = "keypad test" And ml3 = "press any key" Then
            c1TB.Text = "5 BUTTON"
            PositionAndHighlight()
            Exit Sub
        ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
            numberPushed = 5
            EnterNumber()
            Exit Sub
        End If




        'for using buttons as a keyboard
        If (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

            If lastClick <> 5 Then
                lastClick = 5 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            If myCount = 5 Then 'sets the highest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "M"
                Case 2
                    highlightedNameBox.Text = "N"
                Case 3
                    highlightedNameBox.Text = "O"
                Case 4
                    highlightedNameBox.Text = "5"
            End Select

            ArrangeNameboxes()


            myCount += 1
            lastClick = 5
            MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
            MyCreateIPboxes()
            Exit Sub
        End If

        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

        If ml1 <> "lock keypad" Then
            MainZeroizeMenu()
        End If




    End Sub

    'UP BUTTON

    Public Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click 'UP BUTTON
        If ButtonBypass() = True Then
            Exit Sub
        End If

        Dim confirmation As Boolean = False

        If vulosDisplayed = True Then
            Exit Sub
        End If

        If b1TB.Text = "ANALOG SQUELCH LEVEL" Then
            Exit Sub
        End If

        thisNum = "6"
        direction = "up"

        If ml3 = "zeroize haipe" Then
            If c1TB.Text = "TEK" Then
                c1TB.Text = "VECTOR"
            Else
                c1TB.Text = "TEK"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If CheckMyList() = True Then
            Exit Sub
        End If

        If ml3 = "select zeroize key type" Then
            ChangeListValue()
            Exit Sub
        End If

        If ml3 = "select waveform to zeroize" Then
            confirmation = ListCollections(ml3, c1TB.Text)
            If confirmation = True Then
                SetWidth(c1TB)
                CenterMe(c1TB)
                Exit Sub
            End If
        End If

        If ml3 = "leap seconds" Then
            ChangeLeapSeconds(c1TB.Text)
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "time format" Then
            If c1TB.Text = "LOCAL 24-HOUR" Then
                c1TB.Text = "LOCAL 12-HOUR"
            Else
                c1TB.Text = "LOCAL 24-HOUR"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "date format" Then
            If c1TB.Text = "MM-DD-YY" Then
                c1TB.Text = "DD-MM-YY"
            ElseIf c1TB.Text = "DD-MM-YY" Then
                c1TB.Text = "ZULU"
            ElseIf c1TB.Text = "ZULU" Then
                c1TB.Text = "YY-MM-DD"
            ElseIf c1TB.Text = "YY-MM-DD" Then
                c1TB.Text = "MM-DD-YY"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "vpod config" Then
            If c1TB.Text = "VOICE PRIORITY" Then
                c1TB.Text = "DISABLED"
            ElseIf c1TB.Text = "DISABLED" Then
                c1TB.Text = "MUTE DATA AUDIO"
            ElseIf c1TB.Text = "MUTE DATA AUDIO" Then
                c1TB.Text = "VOICE PRIORITY"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "sa destination" Then
            If c1TB.Text = "CUSTOM IP" Then
                c1TB.Text = "PPP PEER"
            Else
                c1TB.Text = "CUSTOM IP"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "sa packet type" Then
            If c1TB.Text = "HARRIS" Then
                c1TB.Text = "CURSOR ON TARGET"
            Else
                c1TB.Text = "HARRIS"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "vulos sa config" Then
            If c1TB.Text = "AUTO" Then
                c1TB.Text = "OFF"
            Else
                c1TB.Text = "AUTO"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "report format" Then
            If c1TB.Text = "CID" Then
                c1TB.Text = "NAME"
            ElseIf c1TB.Text = "NAME" Then
                c1TB.Text = "NAMECID"
            ElseIf c1TB.Text = "NAMECID" Then
                c1TB.Text = "CIDNAME"
            ElseIf c1TB.Text = "CIDNAME" Then
                c1TB.Text = "CID"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        'use this to scroll on the improved menu pages
        confirmation = ScrollingNewMenu()
        If confirmation = True Then
            Exit Sub
        End If

        If ml3 = "retransmit config" Or ml3 = "local sa report" Or ml3 = "sa receive" Then
            OffOnChoice()
            Exit Sub
        End If

        If ml3 = "port stop bits" Then
            If c1TB.Text = "1" Then
                c1TB.Text = "2"
            Else
                c1TB.Text = "1"
            End If
            Exit Sub
        End If

        If ml3 = "port parity" Then
            If c1TB.Text = "NONE" Then
                c1TB.Text = "EVEN"
            ElseIf c1TB.Text = "EVEN" Then
                c1TB.Text = "ODD"
            ElseIf c1TB.Text = "ODD" Then
                c1TB.Text = "NONE"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "port character length" Then
            If c1TB.Text = "8" Then
                c1TB.Text = "7"
            Else
                c1TB.Text = "8"
            End If
            Exit Sub
        End If

        If ml3 = "port baudrate" Then
            If c1TB.Text = "9600" Then
                c1TB.Text = "19200"
            ElseIf c1TB.Text = "19200" Then
                c1TB.Text = "28800"
            ElseIf c1TB.Text = "28800" Then
                c1TB.Text = "38400"
            ElseIf c1TB.Text = "38400" Then
                c1TB.Text = "57600"
            ElseIf c1TB.Text = "57600" Then
                c1TB.Text = "115200"
            ElseIf c1TB.Text = "115200" Then
                c1TB.Text = "9600"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "red ethernet port" Then
            If c1TB.Text = "BUILT IN" Then
                c1TB.Text = "USB"
            Else
                c1TB.Text = "BUILT IN"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "grid digits" Then
            If c1TB.Text = "8" Then
                c1TB.Text = "10"
            ElseIf c1TB.Text = "10" Then
                c1TB.Text = "12"
            ElseIf c1TB.Text = "12" Then
                c1TB.Text = "14"
            ElseIf c1TB.Text = "14" Then
                c1TB.Text = "2"
            ElseIf c1TB.Text = "2" Then
                c1TB.Text = "4"
            ElseIf c1TB.Text = "4" Then
                c1TB.Text = "6"
            ElseIf c1TB.Text = "6" Then
                c1TB.Text = "8"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "angular units" Then
            If c1TB.Text = "DEGREES MAGNETIC" Then
                c1TB.Text = "DEGREES TRUE"
            ElseIf c1TB.Text = "DEGREES TRUE" Then
                c1TB.Text = "MIL MAGNETIC"
            ElseIf c1TB.Text = "MIL MAGNETIC" Then
                c1TB.Text = "MIL TRUE"
            ElseIf c1TB.Text = "MIL TRUE" Then
                c1TB.Text = "STRECK MAGNETIC"
            ElseIf c1TB.Text = "STRECK MAGNETIC" Then
                c1TB.Text = "STRECK TRUE"
            ElseIf c1TB.Text = "STRECK TRUE" Then
                c1TB.Text = "DEGREES MAGNETIC"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "elevation basis" Then
            If c1TB.Text = "MEAN SEA LEVEL" Then
                c1TB.Text = "DATUM BASED"
            Else
                c1TB.Text = "MEAN SEA LEVEL"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "linear units" Then
            If c1TB.Text = "METRIC" Then
                c1TB.Text = "STATUTE"
            ElseIf c1TB.Text = "STATUTE" Then
                c1TB.Text = "NAUTICAL"
            ElseIf c1TB.Text = "NAUTICAL" Then
                c1TB.Text = "METRIC"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "position format" Then
            If c1TB.Text = "LAT LONG DMS" Then
                c1TB.Text = "MGRS-OLD"
            ElseIf c1TB.Text = "MGRS-OLD" Then
                c1TB.Text = "MGRS-NEW"
            ElseIf c1TB.Text = "MGRS-NEW" Then
                c1TB.Text = "UTM/UPS"
            ElseIf c1TB.Text = "UTM/UPS" Then
                c1TB.Text = "LAT LONG DM"
            ElseIf c1TB.Text = "LAT LONG DM" Then
                c1TB.Text = "LAT LONG DMS"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "gps type" Then
            If c1TB.Text = "INTERNAL" Then
                c1TB.Text = "INTERNAL PASS-THRU"
            ElseIf c1TB.Text = "INTERNAL PASS-THRU" Then
                c1TB.Text = "DISABLED"
            ElseIf c1TB.Text = "DISABLED" Then
                c1TB.Text = "INTERNAL"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "antenna lna" Then
            If c1TB.Text = "DISABLED" Then
                c1TB.Text = "RX ENABLED"
            ElseIf c1TB.Text = "RX ENABLED" Then
                c1TB.Text = "ALWAYS ENABLED"
            ElseIf c1TB.Text = "ALWAYS ENABLED" Then
                c1TB.Text = "DISABLED"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml3 = "ppp config" Or ml3 = "radio maintenance" Or ml3 = "external device menu" Or ml3 = "network configuration menu" Then
            If c1TB.BackColor = Color.Black Then
                SetBackGreen(c1TB)
                SetBackBlack(b1TB)
            End If
            Exit Sub
        End If

        If ml3 = "async character length" Or ml3 = "async parity" Or ml3 = "async stop bits" Or ml3 = "async flow control" Then
            Exit Sub
        End If


        If ml3 = "async config" Then
            If c1TB.Text = "1200" Then
                c1TB.Text = "2400"
            ElseIf c1TB.Text = "2400" Then
                c1TB.Text = "4800"
            ElseIf c1TB.Text = "4800" Then
                c1TB.Text = "9600"
            ElseIf c1TB.Text = "9600" Then
                c1TB.Text = "1200"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "sync edge" Then
            If c1TB.Text = "FALLING" Then
                c1TB.Text = "RISING"
            Else
                c1TB.Text = "FALLING"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "sync config" Then
            If c1TB.Text = "INTERNAL ON CTS" Then
                c1TB.Text = "INTERNAL"
            ElseIf c1TB.Text = "INTERNAL" Then
                c1TB.Text = "EXTERNAL"
            ElseIf c1TB.Text = "EXTERNAL" Then
                c1TB.Text = "INTERNAL ON CTS"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If


        If ml3 = "polarity config" Then
            If c1TB.Text = "NORMAL" Then
                c1TB.Text = "INVERTED"
            ElseIf c1TB.Text = "INVERTED" Then
                c1TB.Text = "RX INVERTED"
            ElseIf c1TB.Text = "RX INVERTED" Then
                c1TB.Text = "TX INVERTED"
            ElseIf c1TB.Text = "TX INVERTED" Then
                c1TB.Text = "NORMAL"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If


        If ml3 = "general hw config" Then
            If c1TB.Text = "RS232" Then
                c1TB.Text = "USB"
            ElseIf c1TB.Text = "USB" Then
                c1TB.Text = "RS422"
            ElseIf c1TB.Text = "RS422" Then
                c1TB.Text = "RS232"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "audio sidetone" Or ml3 = "tcp accel config" Or ml3 = "red ping reply" Or ml3 = "gps sleep cycle" Or ml3 = "voice key up timeout" Or ml3 = "external keyline" Or ml3 = "ct override" Then
            If c1TB.Text = "ENABLED" Then
                c1TB.Text = "DISABLED"
            Else
                c1TB.Text = "ENABLED"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml2 = "radio config" And (ml3 = "" Or ml3 = "general config" Or ml3 = "data port config") Then
            ScrollingMenu()
            Exit Sub
        End If


        If ml3 = "rx priority scanning" Or ml3 = "enable hold time" Or ml3 = "message processing" Then
            EnableDisable(c1TB.Text)
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "priority tx preset" Or ml3 = "priority rx preset" Then

            For i = 0 To 4
                If scanListComplete(i) = c1TB.Text Then
                    If i = 4 Then
                    Else
                        c1TB.Text = scanListComplete(i + 1)
                        Exit For
                    End If
                End If
            Next
            SetWidth(c1TB)
            CenterMe(c1TB)
            SetBackBlack(c1TB)
            Exit Sub
        End If



        If ml3 = "scan list" Or ml3 = "view scan list" Or ml3 = "sa config menu" Or ml3 = "remove preset" Or ml3 = "ipv4 configuration menu" Then
            If d1TB.BackColor = Color.Black Then
                SetBackGreen(d1TB)
                SetBackBlack(c1TB)
            ElseIf c1TB.BackColor = Color.Black Then
                SetBackGreen(c1TB)
                SetBackBlack(b1TB)
            ElseIf b1TB.BackColor = Color.Black Then
                If ml3 = "ipv4 configuration menu" Or ml3 = "sa config menu" Then
                    Exit Sub
                End If
                ScanListScroll()
            End If
            Exit Sub
        End If

        confirmation = CheckYesNo() 'checks for YES/NO toggle
        If confirmation = True Then
            Exit Sub
        End If

        If ml3 = "beacon tx power" Then
            If c1TB.Text = "MEDIUM" Then
                c1TB.Text = "HIGH"
            ElseIf c1TB.Text = "HIGH" Then
                c1TB.Text = "LOW"
            ElseIf c1TB.Text = "LOW" Then
                c1TB.Text = "MEDIUM"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "beacon modulation" Then
            If c1TB.Text = "AM" Then
                c1TB.Text = "FM"
            Else
                c1TB.Text = "AM"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "vinson compatibility" Or ml3 = "autosave config" Then
            If c1TB.Text = "ON" Then
                c1TB.Text = "OFF"
            Else
                c1TB.Text = "ON"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "cdcss tx code" Or ml3 = "cdcss rx code" Then
            CDCSSupOrDown(thisNum, c1TB.Text, temp)
            c1TB.Text = temp
            Exit Sub
        End If


        If ml3 = "channel busy priority" Then
            If c1TB.Text = "TRANSMIT" Then
                c1TB.Text = "RECEIVE"
            Else
                c1TB.Text = "TRANSMIT"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If


        If ml3 = "fm tx tone" Then

            If storedMod = "AM" Then
                c1TB.Text = "DISABLED"
                SetBackGreen(c1TB)
            Else
                If c1TB.Text = "ENABLED" Then
                    c1TB.Text = "DISABLED"
                Else
                    c1TB.Text = "ENABLED"
                End If
            End If

            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If


        If ml3 = "ctcss rx tone" Then
            storedCTCSSrx += 1

            If storedCTCSSrx > 43 Then
                storedCTCSSrx = 1
                CTCSSsquelchLoad(storedCTCSSrx - 1, storedCTCSSrxFreq, storedCTCSSrxEIA, storedCTCSSrxHAM)
                c1TB.Text = " " + storedCTCSSrxFreq
                c3TB.Text = storedCTCSSrxEIA
                c4TB.Text = storedCTCSSrxHAM
                Exit Sub
            End If


            If storedCTCSSrx = 43 Then
                c1TB.Text = " USER"
                c3TB.Text = ""
                c4TB.Text = ""
                storedCTCSSrx = 0
            Else
                CTCSSsquelchLoad(storedCTCSSrx - 1, storedCTCSSrxFreq, storedCTCSSrxEIA, storedCTCSSrxHAM)
                c1TB.Text = " " + storedCTCSSrxFreq
                c3TB.Text = storedCTCSSrxEIA
                c4TB.Text = storedCTCSSrxHAM
            End If

            Exit Sub
        End If

        If ml3 = "ctcss tx tone" Then
            storedCTCSS += 1

            If storedCTCSS > 43 Then
                storedCTCSS = 1
                CTCSSsquelchLoad(storedCTCSS - 1, storedCTCSSfreq, storedCTCSSeia, storedCTCSSham)
                c1TB.Text = " " + storedCTCSSfreq
                c3TB.Text = storedCTCSSeia
                c4TB.Text = storedCTCSSham
                Exit Sub
            End If


            If storedCTCSS = 43 Then
                c1TB.Text = " USER"
                c3TB.Text = ""
                c4TB.Text = ""
                storedCTCSS = 0
            Else
                CTCSSsquelchLoad(storedCTCSS - 1, storedCTCSSfreq, storedCTCSSeia, storedCTCSSham)
                c1TB.Text = " " + storedCTCSSfreq
                c3TB.Text = storedCTCSSeia
                c4TB.Text = storedCTCSSham
            End If

            Exit Sub
        End If

        If ml3 = "analog squelch type" Or ml3 = "rx squelch type" Or ml3 = "rx squelch type cdcss" Then
            SquelchTypeUpDown()
            SetWidth(c1TB)
            CenterMe(c1TB)
            SetBackBlack(c1TB)
            Exit Sub
        End If

        If ml3 = "user power level" Then
            Dim temp As Integer
            temp = CInt(myDBdown)
            temp += 1

            If temp < 10 Then
                myDBdown = "0" + CStr(temp)
            Else
                myDBdown = CStr(temp)
            End If
            If temp > 10 Then
                myDBdown = 10
            End If
            c1TB.Text = myDBdown + " DB DOWN"
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "power level" Then
            If c1TB.Text = "HIGH" Then
                c1TB.Text = "USER"
            ElseIf c1TB.Text = "USER" Then
                c1TB.Text = "LOW"
            ElseIf c1TB.Text = "LOW" Then
                c1TB.Text = "HIGH"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "interleaver" Then
            Select Case c1TB.Text
                Case "- -"
                    c1TB.Text = "2"
                Case "2"
                    c1TB.Text = "4"
                Case "4"
                    c1TB.Text = "8"
                Case "8"
                    c1TB.Text = "16"
                Case "16"
                    c1TB.Text = "32"
                Case "32"
                    c1TB.Text = "- -"

            End Select

            Exit Sub

        End If

        If ml3 = "option code" Then
            AvailableOptionsForCrypto(storedCryptoMode, tempB2text, b2TB.Text)
            GetOptionsData(b2TB.Text, storedBW, storedOptMod, storedBPS, storedFWDerror)
            c1TB.Text = storedBW
            SetWidth(c1TB)
            c1TB.Location = New Point((d1TB.Location.X + (d1TB.Width / 2)) - (c1TB.Width / 2), c1TB.Location.Y)
            c1TB.Visible = True
            c3TB.Text = storedOptMod
            SetWidth(c3TB)
            c3TB.Location = New Point((d3TB.Location.X + (d3TB.Width) / 2) - (c3TB.Width / 2), c1TB.Location.Y)
            c3TB.Visible = True
            c4TB.Text = storedBPS
            SetWidth(c4TB)
            c4TB.Location = New Point((d6TB.Location.X + (d6TB.Width / 2)) - (c4TB.Width / 2), c1TB.Location.Y)
            c4TB.Visible = True
            c7TB.Text = storedFWDerror
            SetWidth(c7TB)
            c7TB.Location = New Point((d7TB.Location.X + (d7TB.Width / 2)) - (c7TB.Width / 2), c1TB.Location.Y)
            c7TB.Visible = True
            Exit Sub

        End If

        If ml3 = "fm deviation" Then
            If c1TB.Text = "6.5 kHz" Then
                c1TB.Text = "5.0 kHz"
            ElseIf c1TB.Text = "5.0 kHz" Then
                c1TB.Text = "8.0 kHz"
            ElseIf c1TB.Text = "8.0 kHz" Then
                c1TB.Text = "6.5 kHz"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
        End If

        If ml3 = "modulation type" Then
            If c1TB.Text = "AM" Then
                c1TB.Text = "FM"
            ElseIf c1TB.Text = "FM" Then
                If storedCryptoMode = "AES" Or storedCryptoMode = "NONE" Then
                    c1TB.Text = "AM"
                Else
                    c1TB.Text = "MS181"
                End If

            ElseIf c1TB.Text = "MS181" Then
                c1TB.Text = "AM"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
        End If

        If ml3 = "key source" Then
            If c1TB.Text = "RTS" Then
                c1TB.Text = "DATA"
            Else
                c1TB.Text = "RTS"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
        End If

        If ml3 = "lpc codebook" Then
            If c1TB.Text = "ENGLISH" Then
                c1TB.Text = "DUTCH"
            ElseIf c1TB.Text = "DUTCH" Then
                c1TB.Text = "ARABIC"
            ElseIf c1TB.Text = "ARABIC" Then
                c1TB.Text = "ENGLISH"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
        End If

        If ml3 = "voice mode select" Then
            Select Case storedTraffic
                Case "VOICE"
                    If storedVoiceMode = "CLEAR" Then
                        storedVoiceMode = "CVSD"
                        Select Case storedCryptoMode
                            Case "VINSON"
                                storedBPS = "16k"
                            Case "AES"
                                storedBPS = "16k"
                            Case "NONE"
                                storedBPS = "16k"
                            Case "FASCINATOR"
                                storedBPS = "12k"
                        End Select

                    ElseIf storedVoiceMode = "CVSD" Then
                        storedVoiceMode = "CLEAR"
                        Select Case storedCryptoMode
                            Case "VINSON"
                                storedBPS = " "
                            Case "AES"
                                storedBPS = " "
                            Case "NONE"
                                storedBPS = " "
                            Case "FASCINATOR"
                                storedBPS = " "
                        End Select
                    End If

                Case "VOICE AND DATA"

                    If storedCryptoMode = "ANDVT" Then
                        If storedVoiceMode = "LPC 2400" Then
                            storedVoiceMode = "MELP 2400"
                        ElseIf storedVoiceMode = "MELP 2400" Then
                            storedVoiceMode = "LPC 2400"
                        End If
                    End If

                    If storedCryptoMode = "VINSON" Then
                        storedVoiceMode = "CVSD"
                    End If

            End Select

            c1TB.Text = storedVoiceMode
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub

        End If

        If ml3 = "data mode select" Then
            If c1TB.Text = "SYNCRONOUS" Then
                c1TB.Text = "ASYNCRONOUS"
            Else
                c1TB.Text = "SYNCRONOUS"
            End If

            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "traffic mode" Then
            Select Case storedCryptoMode

                Case "NONE"
                    If storedTraffic = "VOICE" Then
                        storedTraffic = "DATA"
                    Else
                        storedTraffic = "VOICE"
                    End If

                Case "ANDVT"
                    If storedTraffic = "DATA" Then
                        storedTraffic = "VOICE AND DATA"
                    Else
                        storedTraffic = "DATA"
                    End If

                Case "VINSON"
                    If storedTraffic = "VOICE AND DATA" Then
                        storedTraffic = "VOICE"
                    ElseIf storedTraffic = "VOICE" Then
                        storedTraffic = "DATA"
                    ElseIf storedTraffic = "DATA" Then
                        storedTraffic = "VOICE AND DATA"
                    End If

                Case "AES"
                    If storedTraffic = "VOICE" Then
                        storedTraffic = "DATA"
                    Else
                        storedTraffic = "VOICE"
                    End If
            End Select

            c1TB.Text = storedTraffic
            SetWidth(c1TB)
            CenterMe(c1TB)

            Exit Sub
        End If


        If ml3 = "rx fade priority" Or ml3 = "voice autoswitch" Then
            If c1TB.Text = "ENABLED" Then
                c1TB.Text = "DISABLED"
            Else
                c1TB.Text = "ENABLED"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "check submode" Then
            Select Case c1TB.Text
                Case "STANDARD"
                    c1TB.Text = "ALTERNATE"
                Case "ALTERNATE"
                    c1TB.Text = "STANDARD"

                Case "CTR1 (MIN ERR PROP)"
                    c1TB.Text = "CFB1 (CPHR FDBK RESYNC)"
                Case "CFB1 (CPHR FDBK RESYNC)"
                    c1TB.Text = "CTR1 (MIN ERR PROP)"

                Case "REDUNDANT (MODE1)"
                    c1TB.Text = "REDUNDANT*(MODE2)"
                Case "REDUNDANT*(MODE2)"
                    c1TB.Text = "NON-REDUND (MODE3)"
                Case "NON-REDUND (MODE3)"
                    c1TB.Text = "NON-REDUND*(MODE4)"
                Case "NON-REDUND*(MODE4)"
                    c1TB.Text = "REDUNDANT (MODE1)"

                Case "6"
                    c1TB.Text = "9"
                Case "9"
                    c1TB.Text = "12"
                Case "12"
                    c1TB.Text = "15"
                Case "15"
                    c1TB.Text = "20"
                Case "20"
                    c1TB.Text = "30"
                Case "30"
                    c1TB.Text = "60"
                Case "60"
                    c1TB.Text = "6"

            End Select

            SetWidth(c1TB)
            CenterMe(c1TB)

            Exit Sub
        End If

        If ml3 = "encryption key" Then
            TekConversion()
            Exit Sub
        End If

        If ml3 = "crypto mode" Then
            Select Case c1TB.Text
                Case "ANDVT"
                    c1TB.Text = "VINSON"
                Case "VINSON"
                    c1TB.Text = "NONE"
                Case "NONE"
                    c1TB.Text = "AES"
                Case "AES"
                    c1TB.Text = "FASCINATOR"
                Case "FASCINATOR"
                    c1TB.Text = "KG84"
                Case "KG84"
                    c1TB.Text = "ANDVT"
            End Select
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If



        If ml3 = "vulos rx only" Then
            YesNoChoice()
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If

        If ml3 = "tx freq source" Then

            If c1TB.Text = "USE RX FREQ" Then
                c1TB.Text = "EDIT TX FREQ"
                SetWidth(c1TB)
                CenterMe(c1TB)
            Else
                c1TB.Text = "USE RX FREQ"
                SetWidth(c1TB)
                CenterMe(c1TB)
            End If

            Exit Sub

        End If

        If ml3 = "preset type" Then

            If c1TB.Text = "LOS" Then
                c1TB.Text = "SATCOM"
                SetWidth(c1TB)
                CenterMe(c1TB)
            Else
                c1TB.Text = "LOS"
                SetWidth(c1TB)
                CenterMe(c1TB)
            End If

            Exit Sub

        End If




        'checks if the VULOS 1 page is active
        If vulosDisplayed = True And ml1 = "" Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "6"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "6"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If





        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "6"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "6"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If





        If ml3 = "scan config" Then
            ScanScroll()
            Exit Sub
        End If


        If ml1 = "lock keypad" Then 'locks the keypad
        Else

            If ml1 = "program" And ml2 = "" Then
                ProgramScrollUp()
            ElseIf ml1 = "program" And ml2 = "system presets" And ml3 = "" Then
                ScrollUp()
            ElseIf ml1 = "program" And ml2 = "system presets" And ml3 = "programming menu" Then
                ProgrammingMenuMoveUp()
                MeasureArray()
                AutoScrollbar()
            ElseIf ml1 = "program" And ml2 = "vulos config" Then
                If c1TB.BackColor = Color.Black Then
                    SetBackGreen(c1TB)
                    SetBackBlack(b1TB)
                End If

            End If

            If ml1 = "" Then
                OptionsScrollUp()
            ElseIf ml1 = "mode" And ml2 = "otar transmit" And (ml3 = "NO" Or ml3 = "YES") Then
                YesNoChoice()
                ml3 = c1TB.Text
            ElseIf ml1 = "mode" And ml2 = "otar receive" And ml3 = "receive mk" Then
                c1TB.Text = "RECEIVE AK"
                ml3 = "receive ak"
                HelperUpdate()
                PositionAndHighlight()
            ElseIf ml1 = "mode" And ml2 = "otar receive" And ml3 = "receive ak" Then
                c1TB.Text = "RECEIVE MK"
                ml3 = "receive mk"
                HelperUpdate()
                PositionAndHighlight()
            ElseIf ml1 = "mode" And ml2 = "scan" And ml3 = "enable" Then
                c1TB.Text = "DISABLE"
                ml3 = "disable"
                SetWidth(c1TB)
                CenterMe(c1TB)
            ElseIf ml1 = "mode" And ml2 = "scan" And ml3 = "disable" Then
                c1TB.Text = "ENABLE"
                ml3 = "enable"
                SetWidth(c1TB)
                CenterMe(c1TB)
            ElseIf ml1 = "mode" And ml2 = "clone mode" And c1TB.Text = "RECEIVE CLONE" Then
                c1TB.Text = "TRANSMIT CLONE"
                PositionAndHighlight()
            ElseIf ml1 = "mode" And ml2 = "clone mode" And c1TB.Text = "TRANSMIT CLONE" Then
                c1TB.Text = "RECEIVE CLONE"
                PositionAndHighlight()
            ElseIf ml1 = "fill" And ml2 = "" Then
                GenericMenuScroll()
            ElseIf ml1 = "fill" And ml2 = "fill device type" And ml3 <> "key number:" Then
                xHi = 15
                SingleLineScroll()
            ElseIf ml1 = "fill" And ml2 = "fill device type" And ml3 = "key number:" Then
                GenericNumberScroll()
            ElseIf ml1 = "mode" And ml2 = "" Then
                GenericMenuScroll()
            ElseIf ml1 = "test options" And ml2 = "wideband tests" And ml5 = "input frequency" Then
                NumberUp()
            ElseIf ml1 = "data mode" And menuDepth = 1 Then
                OffOnChoice()
            ElseIf ml1 = "gps options" And ml2 = "" Then
                GenericScrollUp()
            ElseIf ml1 = "gps options" And ml2 = "gps status" Then
                ScrollGPSstatusUp()
            ElseIf ml1 = "mission plan" And ml2 = "" Then
                MissionPlanMainScroll()
            ElseIf ml1 = "mission plan" And ml2 = "activate plan" Then
                SelectStationScrollUp()
            ElseIf ml1 = "mission plan" And ml2 = "mission plan loading" Then
                YesNoChoice()
            ElseIf ml1 = "network options" And ml2 = "" Then
                GenericScrollUp()
                b7PB.BackgroundImage = My.Resources.scrollbarFull
            ElseIf ml1 = "network options" And ml2 = "ping by" Then
                PingScroll()
            ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
                'PingAddressUP() 'scrolls the individual digit up
                numberPushed = 6
                EnterNumber()
                GenericScrollUp() 'scrolls the host name up
                b7PB.BackgroundImage = My.Resources.scrollbarFull
            ElseIf ml1 = "network options" And ml2 = "keychain verification" Then
                KeychainUp()
            ElseIf ml1 = "radio information" And ml2 = "" Then
                GenericScrollUp()
                b7PB.BackgroundImage = My.Resources.scrollbarFull
            ElseIf ml1 = "radio options" And ml2 = "" Then
                If c1TB.Text = "OFF" Then
                    c1TB.Text = "ON"
                    radioSilenceState = "ON"
                    c1TB.Width = c1TB.TextLength * 15
                    c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                    FlashRon()
                ElseIf c1TB.Text = "ON" Then
                    c1TB.Text = "OFF"
                    radioSilenceState = "OFF"
                    c1TB.Width = c1TB.TextLength * 14
                    c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                    a1TB.Visible = True
                    FlashRoff()
                End If
            ElseIf ml1 = "radio options" And ml2 = "rf faults persist" Then
                If c1TB.Text = "OFF" Then
                    c1TB.Text = "ON"
                    c1TB.Width = c1TB.TextLength * 15
                    c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                ElseIf c1TB.Text = "ON" Then
                    c1TB.Text = "OFF"
                    c1TB.Width = c1TB.TextLength * 14
                    c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                    a1TB.Visible = True
                End If
            ElseIf ml1 = "radio options" And (ml2 = "pa failsafe" Or ml2 = "remote kdu") Then
                If c1TB.Text = "DISABLED" Then
                    c1TB.Text = "ENABLED"
                    c1TB.Width = c1TB.TextLength * 13
                    c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                ElseIf c1TB.Text = "ENABLED" Then
                    c1TB.Text = "DISABLED"
                    c1TB.Width = c1TB.TextLength * 12
                    c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                    a1TB.Visible = True
                End If
            ElseIf ml1 = "sa options" And ml2 = "" Then
                If c1TB.Text = "DISABLE" Then
                    c1TB.Text = "ENABLE"
                    c1TB.Width = c1TB.TextLength * 13
                    c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                ElseIf c1TB.Text = "ENABLE" Then
                    c1TB.Text = "DISABLE"
                    c1TB.Width = c1TB.TextLength * 12
                    c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                    a1TB.Visible = True
                End If
            ElseIf ml1 = "system information" And ml2 = "" Then
                SysInfoScrollUp()
            ElseIf ml1 = "system information" And ml2 = "versions" Then
                VersionScrollUp()
            ElseIf ml1 = "tx power options" And ml2 = "" Then
                direction = "up"
                TxPowerScroll()
            ElseIf ml1 = "tx power options" And ml2 = "user" Then
                direction = "up"
                TxPowerUserScroll()
            ElseIf ml1 = "view key info" And ml2 = "" Then
                direction = "up"
                KeyInfoNameScroll()
            ElseIf ml1 = "view key info" And ml2 <> "" Then
                direction = "up"
                KeyTypeScroll()



            ElseIf ml2 = "on" And menuDepth = 2 Then
                If c1TB.Text = "SYNC/ASYNC" Then
                    c1TB.Text = "PPP"
                ElseIf c1TB.Text = "PPP" Then
                    c1TB.Text = "SYNC/ASYNC"
                End If
                c1TB.Width = c1TB.TextLength * 12
                c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)

            Else

                If menuDepth = 3 And ml2 <> "otar receive" Then
                    testOptionsBertBertModeTransmitOrReceive()
                End If

                If menuDepth = 4 And ml4 <> "crypto mode" And ml4 <> "otar assignment" Then
                    SyncChoicesUp()
                End If

                If ml4 = "y/n" Or ml5 = "y/n" Or ml6 = "y/n" Then
                    YesNoChoice()
                End If

                If ml2 = "optional tests" Then
                    OptionalTestsSubMenu()
                End If

                If ml2 = "wideband tests" Then
                    WidebandMenuScrollUp()
                End If

                If ml4 = "3 to 8 min" Then
                    YesNoChoice()
                End If

                TestOptionsScrollUp()

                If ml3 = "tx rx" And menuDepth = 3 Then
                    If c1TB.Text = "TX" Then
                        c1TB.Text = "RX"
                        c1TB.Width = 28
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    ElseIf c1TB.Text = "RX" Then
                        c1TB.Text = "TX"
                        c1TB.Width = 28
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    End If
                End If

                If (ml4 = "tx" Or ml4 = "rx") And menuDepth = 4 Then
                    If c1TB.Text = "HIGHBAND" Then
                        c1TB.Text = "LOWBAND"
                        c1TB.Width = 94
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    ElseIf c1TB.Text = "LOWBAND" Then
                        c1TB.Text = "HIGHBAND"
                        c1TB.Width = 100
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    End If
                End If

                If ml3 = "rx sensitivity" Or ml3 = "tx power" Or ml3 = "tx frequency" Or ml3 = "full duplex" And menuDepth = 3 Then
                    If c1TB.Text = "HIGHBAND" Then
                        c1TB.Text = "LOWBAND"
                        c1TB.Width = 94
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    ElseIf c1TB.Text = "LOWBAND" Then
                        c1TB.Text = "HIGHBAND"
                        c1TB.Width = 100
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    End If
                End If

                If (ml5 = "highband" Or ml5 = "lowband") And menuDepth = 5 Then
                    If c1TB.Text = "1250 KHz" Then
                        c1TB.Text = "2500 KHz"
                    ElseIf c1TB.Text = "2500 KHz" Then
                        c1TB.Text = "5000 KHz"
                    ElseIf c1TB.Text = "5000 KHz" Then
                        c1TB.Text = "1250 KHz"
                    End If
                End If

                If (ml4 = "highband" Or ml4 = "lowband") And menuDepth = 4 Then
                    If c1TB.Text = "5000 KHz" Then
                        c1TB.Text = "1250 KHz"
                        c1TB.Width = 82
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    ElseIf c1TB.Text = "1250 KHz" Then
                        c1TB.Text = "2500 KHz"
                        c1TB.Width = 82
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    ElseIf c1TB.Text = "2500 KHz" Then
                        c1TB.Text = "5000 KHz"
                        c1TB.Width = 82
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    End If
                End If

                If ml2 = "keypad test" And ml3 = "press any key" Then
                    c1TB.Text = "UP ARROW"
                    PositionAndHighlight()
                End If

            End If
        End If




        'for using buttons as a keyboard
        If (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

            If lastClick <> 6 Then
                lastClick = 6 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            If myCount = 5 Then 'sets the highest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "P"
                Case 2
                    highlightedNameBox.Text = "Q"
                Case 3
                    highlightedNameBox.Text = "R"
                Case 4
                    highlightedNameBox.Text = "6"
            End Select

            ArrangeNameboxes()


            myCount += 1
            lastClick = 6

        End If


        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

        HelperUpdate()
    End Sub

    Public Sub btnPreDn_Click(sender As Object, e As EventArgs) Handles btnPreDn.Click

        If ml1 = "lock keypad" Then 'locks the keypad
            Exit Sub
        ElseIf ml2 = "keypad test" And ml3 = "press any key" Then
            c1TB.Text = "PRESET DOWN"
            PositionAndHighlight()
            Exit Sub
        End If

        senderName = "BtnPreDown"

        If ButtonBypass() = True Then
            Exit Sub
        End If

        DisplayReset()
        DisplayVulosPage1()

        'iterates through the presets
        If (b1TB.Text.IndexOf(dash) <> -1) Or (c1TB.Text.IndexOf(dash) <> -1) Then 'looks for a - in the b1TB
            If presetRowNum >= 1 Then
                presetRowNum -= 1
            Else
                presetRowNum = 98
            End If
            RecallPreset()

            If ml3 = "system preset number" Then
                SystemPresetNumber()
            End If

            If ml3 = "add scan list" Then
                AddScanList()
            End If

        End If
        'end iterates







    End Sub

    'CLEAR BUTTON

    Public Sub btnClr_Click(sender As Object, e As EventArgs) Handles btnClr.Click
        If ButtonBypass() = True Then
            If ml3 = "zeroize alert" Then
            Else
                Exit Sub
            End If
        End If

        If ml1 = "lock keypad" Then 'locks the keypad
        Else
            direction = "backward"

            If ml3 = "zeroize alert" Then
                If knobIndex = 1 Or knobIndex = 2 Then
                    DisplayVulosPage1()
                ElseIf knobIndex = 3 Then
                    DisplayLoadPage1()
                End If
                ml3 = ""
                Exit Sub
            End If

            If ml3 = "erasing plans successful" Then
                MainZeroizeMenu()
                Exit Sub
            End If

            If ml1 = "main zeroize menu" Then
                DisplayVulosPage1()
                Exit Sub
            End If

            If ml3 = "hub has been reset" Then
                RadioMaintenance()
                Exit Sub
            End If

            If ml3 = "reset hub capacity" Then
                RadioMaintenance()
                Exit Sub
            End If

            If ml3 = "radio system clock" Then
                RadioConfig()
                Exit Sub
            End If

            If ml3 = "utc offset message" Then
                RadioSystemClock()
                Exit Sub
            End If

            If ml3 = "programming menu" Then
                SystemPresetsMenu()
                Exit Sub
            End If

            If ml3 = "" And ml2 = "radio config" Then
                ml2 = ""
                ProgramMain()
                Exit Sub
            End If

            If ml3 = "general config" And ml2 = "radio config" Then
                ml3 = ""
                RadioConfig()
                Exit Sub
            End If

            If ml3 = "ipv4 configuration menu" Then
                NetworkConfigMenu()
                Exit Sub
            End If

            If ml3 = "network configuration menu" Then
                RadioGeneralConfig()
                Exit Sub
            End If

            If ml3 = "change maint pswd" Or ml3 = "confirm maint pswd" Or ml3 = "change maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "reenter maint pswd" Then
                If nameBox1.BackColor = Color.Black Then
                    RadioConfig()
                End If
                HideCharacters()
                PresetNameMoveLeft()
                Exit Sub
            End If

            If ml3 = "maintenance password" Then
                TestOptions()
            End If

            If ml3 = "view scan list" Then
                ScanList()
                Exit Sub
            End If

            If (ml1 = "program" And ml2 = "") Then
                DisplayVulosPage1()
                Exit Sub
            End If

            If (ml2 = "system presets" And ml3 = "") Or (ml1 = "program" And ml2 = "vulos config" And ml3 = "") Then
                ProgramMain()
                Exit Sub
            End If

            If ml3 = "scan config" Then
                SystemPresetsMenu()
                Exit Sub
            End If

            If ml3 = "scan list" Or ml3 = "priority tx preset" Then
                ScanConfig()
                Exit Sub
            End If

            If ml1 = "mission plan" And ml2 = "mission plan loading" Then
                ml2 = ""
                MissionPlanMain()
            ElseIf ml1 = "mode" And ml2 = "" And ml3 = "" And ml4 = "" Then
                ml1 = ""
                DisplayVulosPage1()
            ElseIf ml1 = "mode" And ml2 = "otar transmit" And ml3 = "transmitting" Then
                OtarTxAborted()
            ElseIf ml1 = "radio options" Then
                DisplayOptionsMenu()
                Exit Sub
            ElseIf ml1 = "mode" And ml2 = "otar transmit" And (ml3 = "NO" Or ml3 = "aborted") Then
                ml4 = ""
                ml3 = ""
                ml2 = ""
                ml1 = "mode"
                ModeMainPage()
            ElseIf (ml1 = "mode" And ml2 = "otar receive" And (ml3 = "receive ak" Or ml3 = "receive mk") And ml4 = "receiving") Then
                ml5 = "aborted"
            ElseIf (ml1 = "mode" And ml2 = "otar receive" And (ml3 = "receive ak" Or ml3 = "receive mk") And ml4 = "complete") Or (ml1 = "mode" And ml2 = "otar receive" And (ml3 = "receive ak" Or ml3 = "receive mk") And ml4 = "") Or (ml1 = "mode" And ml2 = "otar receive" And (ml3 = "select") And ml4 = "successful") Then
                ml4 = ""
                ml3 = ""
                ml2 = ""
                ml1 = "mode"
                ModeMainPage()
            ElseIf ml1 = "mode" And ml2 = "scan" And (ml3 = "enable" Or ml3 = "disable") Then
                ml3 = ""
                ml2 = ""
                ml1 = "mode"
                ModeMainPage()
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "all plan files" And ml4 = "complete" Then
                ml3 = ""
                ml2 = ""
                checkArray()
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "all plan files" And ml4 = "transmitting" Then
                from = ""
                b1TB.Text = "TRANSMIT CLONE"
                c1TB.Text = "ABORTED"
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                d1TB.Text = "PRESS CLR/ENT TO EXIT"
                b6PB.Visible = False
                ml3 = ""
                ml4 = ""
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "all plan files" And ml4 = "transmit clone" Then
                from = ""
                b1TB.Text = "xxxxxx CLONE"
                c1TB.Text = "ABORTED"
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                d1TB.Text = "PRESS CLR/ENT TO EXIT"
                b6PB.Visible = False
                ml3 = ""
                ml4 = ""
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "receive clone" And ml4 = "complete" Then
                ml3 = ""
                ml2 = ""
                checkArray()
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "receive clone" And ml4 = "receiving" Then
                from = ""
                b1TB.Text = "RECEIVE CLONE"
                c1TB.Text = "ABORTED"
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                d1TB.Text = "PRESS CLR/ENT TO EXIT"
                b6PB.Visible = False
                ml3 = ""
                ml4 = ""
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "receive clone" And ml4 = "receive clone" Then
                from = ""
                b1TB.Text = "RECEIVE CLONE"
                c1TB.Text = "ABORTED"
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                d1TB.Text = "PRESS CLR/ENT TO EXIT"
                b6PB.Visible = False
                ml3 = ""
                ml4 = ""
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "" Then
                ClonePage()
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "receive clone" And ml4 = "" Then
                ml3 = ""
                ml2 = ""
                checkArray()
            ElseIf ml1 = "system information" And (ml2 = "" Or ml2 = "versions") Then
                SystemInfoPage()
                ml2 = ""
            ElseIf ml1 = "network options" And ml2 = "ping success" Then
                ml2 = ""
                NetworkOptionsBasePageLoad()
            ElseIf ml1 = "radio information" And ml2 = "" And ml3 <> "end" Then
                DisplayOptionsMenu()
            ElseIf ml1 = "radio information" And (ml2 <> "" Or ml3 = "end") Then
                RadioInfoTopMenu()
                ml2 = ""
                ml3 = ""
            ElseIf ml1 = "fill" And ml3 = "initiate fill" Then
                'thread2.Abort()
                FillFailed()
            ElseIf ml1 = "fill" And ml2 = "otar tek" Then
                FillStoreAbort()
            ElseIf ml1 = "mode" And ml2 = "beacon" And ml3 = "" Then
                ml2 = ""
                checkArray()
            ElseIf ml1 = "mode" And ml2 = "beacon" And ml3 = "running" Then
                TerminateBeaconMode()
                ml4 = "y/n"
                YesNoChoice()
            ElseIf ml1 = "test options" And ml2 = "" Then
                DisplayOptionsMenu()
                Exit Sub



                'for using buttons as a keyboard
            ElseIf (ml3 = "system preset name" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

                GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

                If lastClick <> 10 Then
                    lastClick = 10 'used for tacking how many times a button is pushed
                    myCount = 1
                End If

                If myCount = 0 Then 'sets the lowest possible value
                    myCount = 1
                End If

                GetHighlightedNamebox() 'gets the name of the highlighted namebox

                Select Case myCount
                    Case 1
                        highlightedNameBox.Text = " "

                End Select

                ArrangeNameboxes()


                lastClick = 10




            End If

            If c1TB.Text = "3 TO 8 MIN" Or c1TB.Text = "...WAIT..." Then
                TestOptions()
            End If

            Select Case menuDepth
                Case "0"
                    DisplayVulosPage1()
            End Select

            Select Case ml6
                Case "63"
                    TestOptions()
                Case "511"
                    TestOptions()
                Case "2047"
                    TestOptions()
                Case "4095"
                    TestOptions()
                Case "mark"
                    TestOptions()
                Case "space"
                    TestOptions()
                Case "1:1"
                    TestOptions()
                Case "0011"
                    TestOptions()
                Case "3 TO 8 MIN"
                    TestOptions()
                Case "test passed"
                    TestOptions()
                Case "test complete"
                    TestOptions()
                Case "test in progress"
                    TestOptions()

            End Select

            If ml2 = "lcd test" Then '3-18
                checkArray()
            End If

            If ml2 = "keypad test" And ml3 = "press any key" Then
                TestOptions()

            End If

            If ml6 = "memory test passed" Then
                TestOptions()
            End If
        End If
        HelperUpdate()

    End Sub

    Public Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click 'OPTIONS MENU
        If ButtonBypass() = True Then
            Exit Sub
        End If

        thisNum = "7"

        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If


        'checks if the VULOS 1 page is active
        If vulosDisplayed = True Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "7"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "7"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                'Exit Sub
            End If


        End If




        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "7"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "7"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If





        If ml1 = "lock keypad" Then 'locks the keypad
            keypadLock = keypadLock + "7"





            'for using buttons as a keyboard
        ElseIf (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

            If lastClick <> 7 Then
                lastClick = 7 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            If myCount = 5 Then 'sets the highest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "S"
                Case 2
                    highlightedNameBox.Text = "T"
                Case 3
                    highlightedNameBox.Text = "U"
                Case 4
                    highlightedNameBox.Text = "7"
            End Select

            ArrangeNameboxes()


            myCount += 1
            lastClick = 7







        ElseIf knobIndex = 3 Then
            DisplayReset()
            SetVisibilityOFF()
            ml1 = ""
            ml2 = ""
            ml3 = ""
            ml4 = ""
            ml5 = ""
            ml6 = ""
            HelperUpdate()


            TurnOnCheck() 'checks if the system has just been turned on

            If screenReady = True Then

                DisplayLoadPage1()
            End If

        ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
            numberPushed = 7
            EnterNumber()
        Else
            If ml1 = "" Then
                DisplayReset()
                DisplayOptionsMenu()
            ElseIf ml2 = "" And ml1 <> "" Then
                DisplayReset()
                DisplayOptionsMenu()
            Else


                If ml2 = "keypad test" And ml3 = "press any key" Then
                    c1TB.Text = "7 BUTTON"
                    PositionAndHighlight()
                Else
                    Try 'if thread2 is running, terminate it
                        thread2.Abort()
                    Catch ex As Exception

                    End Try

                    ml1 = "test options"

                    TestOptions()
                    HelperUpdate()

                End If

            End If
        End If




        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()



    End Sub

    Public Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        thisNum = "8"

        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If

        'checks if the VULOS 1 page is active
        If vulosDisplayed = True And ml1 = "" Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "8"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "8"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If




        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "8"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "8"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If





        If ml1 = "lock keypad" Then 'locks the keypad
        ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
            numberPushed = 8
            EnterNumber()


            'for using buttons as a keyboard
        ElseIf (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

            If lastClick <> 8 Then
                lastClick = 8 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            If myCount = 5 Then 'sets the highest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "V"
                Case 2
                    highlightedNameBox.Text = "W"
                Case 3
                    highlightedNameBox.Text = "X"
                Case 4
                    highlightedNameBox.Text = "8"
            End Select

            ArrangeNameboxes()


            myCount += 1
            lastClick = 8




        Else
            If ml2 = "keypad test" And ml3 = "press any key" Then
                c1TB.Text = "8 BUTTON"
                PositionAndHighlight()
            ElseIf knobIndex = 1 Or knobIndex = 2 Then
                vulosDisplayed = False
                ml1 = "program"
                ProgramMain()
                HelperUpdate()
                'MainZeroizeMenu()
            End If

        End If


        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

    End Sub

    'DOWN BUTTON

    Public Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        Dim confirmation As Boolean = False


        If vulosDisplayed = True Then
            Exit Sub
        End If

        If b1TB.Text = "ANALOG SQUELCH LEVEL" Then
            Exit Sub
        End If

        thisNum = "9"
        direction = "down"

        If ml3 = "zeroize haipe" Then
            If c1TB.Text = "TEK" Then
                c1TB.Text = "VECTOR"
            Else
                c1TB.Text = "TEK"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If CheckMyList() = True Then 'add ml3=xxxxx to CheckMyList function to make items scroll
            Exit Sub
        End If

        If ml3 = "select zeroize key type" Then
            ChangeListValue()
            Exit Sub
        End If

        If ml3 = "select waveform to zeroize" Then
            confirmation = ListCollections(ml3, c1TB.Text)
            If confirmation = True Then
                SetWidth(c1TB)
                CenterMe(c1TB)
                Exit Sub
            End If
        End If

        If ml3 = "leap seconds" Then
            ChangeLeapSeconds(c1TB.Text)
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "time format" Then
            If c1TB.Text = "LOCAL 24-HOUR" Then
                c1TB.Text = "LOCAL 12-HOUR"
            Else
                c1TB.Text = "LOCAL 24-HOUR"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "date format" Then
            If c1TB.Text = "MM-DD-YY" Then
                c1TB.Text = "DD-MM-YY"
            ElseIf c1TB.Text = "DD-MM-YY" Then
                c1TB.Text = "ZULU"
            ElseIf c1TB.Text = "ZULU" Then
                c1TB.Text = "YY-MM-DD"
            ElseIf c1TB.Text = "YY-MM-DD" Then
                c1TB.Text = "MM-DD-YY"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "vpod config" Then
            If c1TB.Text = "VOICE PRIORITY" Then
                c1TB.Text = "DISABLED"
            ElseIf c1TB.Text = "DISABLED" Then
                c1TB.Text = "MUTE DATA AUDIO"
            ElseIf c1TB.Text = "MUTE DATA AUDIO" Then
                c1TB.Text = "VOICE PRIORITY"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "sa destination" Then
            If c1TB.Text = "CUSTOM IP" Then
                c1TB.Text = "PPP PEER"
            Else
                c1TB.Text = "CUSTOM IP"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "sa packet type" Then
            If c1TB.Text = "HARRIS" Then
                c1TB.Text = "CURSOR ON TARGET"
            Else
                c1TB.Text = "HARRIS"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "vulos sa config" Then
            If c1TB.Text = "AUTO" Then
                c1TB.Text = "OFF"
            Else
                c1TB.Text = "AUTO"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "report format" Then
            If c1TB.Text = "CID" Then
                c1TB.Text = "NAME"
            ElseIf c1TB.Text = "NAME" Then
                c1TB.Text = "NAMECID"
            ElseIf c1TB.Text = "NAMECID" Then
                c1TB.Text = "CIDNAME"
            ElseIf c1TB.Text = "CIDNAME" Then
                c1TB.Text = "CID"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        'use this to scroll on the improved menu pages
        confirmation = ScrollingNewMenu()
        If confirmation = True Then
            Exit Sub
        End If


        If ml3 = "retransmit config" Or ml3 = "local sa report" Or ml3 = "sa receive" Then
            OffOnChoice()
            Exit Sub
        End If

        If ml3 = "port stop bits" Then
            If c1TB.Text = "1" Then
                c1TB.Text = "2"
            Else
                c1TB.Text = "1"
            End If
            Exit Sub
        End If

        If ml3 = "port parity" Then
            If c1TB.Text = "NONE" Then
                c1TB.Text = "EVEN"
            ElseIf c1TB.Text = "EVEN" Then
                c1TB.Text = "ODD"
            ElseIf c1TB.Text = "ODD" Then
                c1TB.Text = "NONE"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "port character length" Then
            If c1TB.Text = "8" Then
                c1TB.Text = "7"
            Else
                c1TB.Text = "8"
            End If
            Exit Sub
        End If

        If ml3 = "port baudrate" Then
            If c1TB.Text = "9600" Then
                c1TB.Text = "19200"
            ElseIf c1TB.Text = "19200" Then
                c1TB.Text = "28800"
            ElseIf c1TB.Text = "28800" Then
                c1TB.Text = "38400"
            ElseIf c1TB.Text = "38400" Then
                c1TB.Text = "57600"
            ElseIf c1TB.Text = "57600" Then
                c1TB.Text = "115200"
            ElseIf c1TB.Text = "115200" Then
                c1TB.Text = "9600"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "red ethernet port" Then
            If c1TB.Text = "BUILT IN" Then
                c1TB.Text = "USB"
            Else
                c1TB.Text = "BUILT IN"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "grid digits" Then
            If c1TB.Text = "8" Then
                c1TB.Text = "10"
            ElseIf c1TB.Text = "10" Then
                c1TB.Text = "12"
            ElseIf c1TB.Text = "12" Then
                c1TB.Text = "14"
            ElseIf c1TB.Text = "14" Then
                c1TB.Text = "2"
            ElseIf c1TB.Text = "2" Then
                c1TB.Text = "4"
            ElseIf c1TB.Text = "4" Then
                c1TB.Text = "6"
            ElseIf c1TB.Text = "6" Then
                c1TB.Text = "8"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "angular units" Then
            If c1TB.Text = "DEGREES MAGNETIC" Then
                c1TB.Text = "DEGREES TRUE"
            ElseIf c1TB.Text = "DEGREES TRUE" Then
                c1TB.Text = "MIL MAGNETIC"
            ElseIf c1TB.Text = "MIL MAGNETIC" Then
                c1TB.Text = "MIL TRUE"
            ElseIf c1TB.Text = "MIL TRUE" Then
                c1TB.Text = "STRECK MAGNETIC"
            ElseIf c1TB.Text = "STRECK MAGNETIC" Then
                c1TB.Text = "STRECK TRUE"
            ElseIf c1TB.Text = "STRECK TRUE" Then
                c1TB.Text = "DEGREES MAGNETIC"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "elevation basis" Then
            If c1TB.Text = "MEAN SEA LEVEL" Then
                c1TB.Text = "DATUM BASED"
            Else
                c1TB.Text = "MEAN SEA LEVEL"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "linear units" Then
            If c1TB.Text = "METRIC" Then
                c1TB.Text = "STATUTE"
            ElseIf c1TB.Text = "STATUTE" Then
                c1TB.Text = "NAUTICAL"
            ElseIf c1TB.Text = "NAUTICAL" Then
                c1TB.Text = "METRIC"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "position format" Then
            If c1TB.Text = "LAT LONG DMS" Then
                c1TB.Text = "MGRS-OLD"
            ElseIf c1TB.Text = "MGRS-OLD" Then
                c1TB.Text = "MGRS-NEW"
            ElseIf c1TB.Text = "MGRS-NEW" Then
                c1TB.Text = "UTM/UPS"
            ElseIf c1TB.Text = "UTM/UPS" Then
                c1TB.Text = "LAT LONG DM"
            ElseIf c1TB.Text = "LAT LONG DM" Then
                c1TB.Text = "LAT LONG DMS"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "gps type" Then
            If c1TB.Text = "INTERNAL" Then
                c1TB.Text = "INTERNAL PASS-THRU"
            ElseIf c1TB.Text = "INTERNAL PASS-THRU" Then
                c1TB.Text = "DISABLED"
            ElseIf c1TB.Text = "DISABLED" Then
                c1TB.Text = "INTERNAL"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "antenna lna" Then
            If c1TB.Text = "DISABLED" Then
                c1TB.Text = "RX ENABLED"
            ElseIf c1TB.Text = "RX ENABLED" Then
                c1TB.Text = "ALWAYS ENABLED"
            ElseIf c1TB.Text = "ALWAYS ENABLED" Then
                c1TB.Text = "DISABLED"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If


        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml3 = "ppp config" Or ml3 = "radio maintenance" Or ml3 = "external device menu" Or ml3 = "network configuration menu" Then
            If b1TB.BackColor = Color.Black Then
                SetBackGreen(b1TB)
                SetBackBlack(c1TB)
            End If
            Exit Sub
        End If

        If ml3 = "async character length" Or ml3 = "async parity" Or ml3 = "async stop bits" Or ml3 = "async flow control" Then
            Exit Sub
        End If

        If ml3 = "async config" Then
            If c1TB.Text = "1200" Then
                c1TB.Text = "2400"
            ElseIf c1TB.Text = "2400" Then
                c1TB.Text = "4800"
            ElseIf c1TB.Text = "4800" Then
                c1TB.Text = "9600"
            ElseIf c1TB.Text = "9600" Then
                c1TB.Text = "1200"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "sync edge" Then
            If c1TB.Text = "FALLING" Then
                c1TB.Text = "RISING"
            Else
                c1TB.Text = "FALLING"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "sync config" Then
            If c1TB.Text = "INTERNAL ON CTS" Then
                c1TB.Text = "INTERNAL"
            ElseIf c1TB.Text = "INTERNAL" Then
                c1TB.Text = "EXTERNAL"
            ElseIf c1TB.Text = "EXTERNAL" Then
                c1TB.Text = "INTERNAL ON CTS"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If


        If ml3 = "polarity config" Then
            If c1TB.Text = "NORMAL" Then
                c1TB.Text = "INVERTED"
            ElseIf c1TB.Text = "INVERTED" Then
                c1TB.Text = "RX INVERTED"
            ElseIf c1TB.Text = "RX INVERTED" Then
                c1TB.Text = "TX INVERTED"
            ElseIf c1TB.Text = "TX INVERTED" Then
                c1TB.Text = "NORMAL"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If


        If ml3 = "general hw config" Then
            If c1TB.Text = "RS232" Then
                c1TB.Text = "USB"
            ElseIf c1TB.Text = "USB" Then
                c1TB.Text = "RS422"
            ElseIf c1TB.Text = "RS422" Then
                c1TB.Text = "RS232"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "audio sidetone" Or ml3 = "tcp accel config" Or ml3 = "red ping reply" Or ml3 = "gps sleep cycle" Or ml3 = "voice key up timeout" Or ml3 = "external keyline" Or ml3 = "ct override" Then
            If c1TB.Text = "ENABLED" Then
                c1TB.Text = "DISABLED"
            Else
                c1TB.Text = "ENABLED"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml2 = "radio config" And (ml3 = "" Or ml3 = "general config" Or ml3 = "data port config") Then
            ScrollingMenu()
            Exit Sub
        End If


        If ml3 = "rx priority scanning" Or ml3 = "message processing" Or ml3 = "enable hold time" Then
            EnableDisable(c1TB.Text)
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If


        If ml3 = "priority tx preset" Or ml3 = "priority rx preset" Then

            For i = 0 To 4
                If scanListComplete(i) = c1TB.Text Then
                    If i = 0 Then
                    Else
                        c1TB.Text = scanListComplete(i - 1)
                        Exit For
                    End If
                End If
            Next
            SetWidth(c1TB)
            CenterMe(c1TB)
            SetBackBlack(c1TB)
            Exit Sub
        End If


        If ml3 = "scan list" Or ml3 = "view scan list" Or ml3 = "sa config menu" Or ml3 = "remove preset" Or ml3 = "ipv4 configuration menu" Then
            If b1TB.BackColor = Color.Black Then
                SetBackGreen(b1TB)
                SetBackBlack(c1TB)
            ElseIf c1TB.BackColor = Color.Black Then
                SetBackGreen(c1TB)
                SetBackBlack(d1TB)
            ElseIf d1TB.BackColor = Color.Black Then
                If ml3 = "ipv4 configuration menu" Or ml3 = "sa config menu" Then
                    Exit Sub
                End If
                ScanListScroll()
            End If
            Exit Sub
        End If

        confirmation = CheckYesNo() 'checks for YES/NO toggle
        If confirmation = True Then
            Exit Sub
        End If


        If ml3 = "beacon tx power" Then
            If c1TB.Text = "MEDIUM" Then
                c1TB.Text = "LOW"
            ElseIf c1TB.Text = "HIGH" Then
                c1TB.Text = "MEDIUM"
            ElseIf c1TB.Text = "LOW" Then
                c1TB.Text = "HIGH"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "beacon modulation" Then
            If c1TB.Text = "AM" Then
                c1TB.Text = "FM"
            Else
                c1TB.Text = "AM"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "vinson compatibility" Or ml3 = "autosave config" Then
            If c1TB.Text = "ON" Then
                c1TB.Text = "OFF"
            Else
                c1TB.Text = "ON"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "cdcss tx code" Or ml3 = "cdcss rx code" Then
            CDCSSupOrDown(thisNum, c1TB.Text, temp)
            c1TB.Text = temp
            Exit Sub
        End If


        If ml3 = "channel busy priority" Then
            If c1TB.Text = "TRANSMIT" Then
                c1TB.Text = "RECEIVE"
            Else
                c1TB.Text = "TRANSMIT"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If


        If ml3 = "fm tx tone" Then

            If storedMod = "AM" Then
                c1TB.Text = "DISABLED"
                SetBackGreen(c1TB)
            Else
                If c1TB.Text = "ENABLED" Then
                    c1TB.Text = "DISABLED"
                Else
                    c1TB.Text = "ENABLED"
                End If
            End If

            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "ctcss rx tone" Then
            storedCTCSSrx -= 1

            If storedCTCSSrx < 0 Then
                storedCTCSSrx = 43
                CTCSSsquelchLoad(storedCTCSSrx - 1, storedCTCSSrxFreq, storedCTCSSrxEIA, storedCTCSSrxHAM)
                c1TB.Text = " " + storedCTCSSrxFreq
                c3TB.Text = storedCTCSSrxEIA
                c4TB.Text = storedCTCSSrxHAM
                Exit Sub
            End If

            If storedCTCSSrx = 0 Then
                c1TB.Text = " USER"
                c3TB.Text = ""
                c4TB.Text = ""
                storedCTCSSrx = 43
            Else
                CTCSSsquelchLoad(storedCTCSSrx - 1, storedCTCSSrxFreq, storedCTCSSrxEIA, storedCTCSSrxHAM)
                c1TB.Text = " " + storedCTCSSrxFreq
                c3TB.Text = storedCTCSSrxEIA
                c4TB.Text = storedCTCSSrxHAM
            End If

            Exit Sub
        End If


        If ml3 = "ctcss tx tone" Then
            storedCTCSS -= 1

            If storedCTCSS < 0 Then
                storedCTCSS = 43
                CTCSSsquelchLoad(storedCTCSS - 1, storedCTCSSfreq, storedCTCSSeia, storedCTCSSham)
                c1TB.Text = " " + storedCTCSSfreq
                c3TB.Text = storedCTCSSeia
                c4TB.Text = storedCTCSSham
                Exit Sub
            End If

            If storedCTCSS = 0 Then
                c1TB.Text = " USER"
                c3TB.Text = ""
                c4TB.Text = ""
                storedCTCSS = 43
            Else
                CTCSSsquelchLoad(storedCTCSS - 1, storedCTCSSfreq, storedCTCSSeia, storedCTCSSham)
                c1TB.Text = " " + storedCTCSSfreq
                c3TB.Text = storedCTCSSeia
                c4TB.Text = storedCTCSSham
            End If

            Exit Sub
        End If

        If ml3 = "analog squelch type" Or ml3 = "rx squelch type" Or ml3 = "rx squelch type cdcss" Then
            SquelchTypeUpDown()
            SetWidth(c1TB)
            CenterMe(c1TB)
            SetBackBlack(c1TB)
            Exit Sub
        End If

        If ml3 = "user power level" Then
            Dim temp As Integer
            temp = CInt(myDBdown)

            temp -= 1

            If temp < 1 Then
                temp = 0
            End If

            If temp < 10 Then
                myDBdown = "0" + CStr(temp)
            Else
                myDBdown = CStr(temp)
            End If

            c1TB.Text = myDBdown + " DB DOWN"
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "power level" Then
            If c1TB.Text = "HIGH" Then
                c1TB.Text = "LOW"
            ElseIf c1TB.Text = "LOW" Then
                c1TB.Text = "USER"
            ElseIf c1TB.Text = "USER" Then
                c1TB.Text = "HIGH"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "interleaver" Then
            Select Case c1TB.Text
                Case "- -"
                    c1TB.Text = "2"
                Case "2"
                    c1TB.Text = "4"
                Case "4"
                    c1TB.Text = "8"
                Case "8"
                    c1TB.Text = "16"
                Case "16"
                    c1TB.Text = "32"
                Case "32"
                    c1TB.Text = "- -"

            End Select

            Exit Sub

        End If

        If ml3 = "option code" Then
            AvailableOptionsForCrypto(storedCryptoMode, tempB2text, b2TB.Text)
            GetOptionsData(b2TB.Text, storedBW, storedOptMod, storedBPS, storedFWDerror)
            c1TB.Text = storedBW
            SetWidth(c1TB)
            c1TB.Location = New Point((d1TB.Location.X + (d1TB.Width / 2)) - (c1TB.Width / 2), c1TB.Location.Y)
            c1TB.Visible = True
            c3TB.Text = storedOptMod
            SetWidth(c3TB)
            c3TB.Location = New Point((d3TB.Location.X + (d3TB.Width) / 2) - (c3TB.Width / 2), c1TB.Location.Y)
            c3TB.Visible = True
            c4TB.Text = storedBPS
            SetWidth(c4TB)
            c4TB.Location = New Point((d6TB.Location.X + (d6TB.Width / 2)) - (c4TB.Width / 2), c1TB.Location.Y)
            c4TB.Visible = True
            c7TB.Text = storedFWDerror
            SetWidth(c7TB)
            c7TB.Location = New Point((d7TB.Location.X + (d7TB.Width / 2)) - (c7TB.Width / 2), c1TB.Location.Y)
            c7TB.Visible = True
            Exit Sub

        End If

        If ml3 = "fm deviation" Then
            If c1TB.Text = "6.5 kHz" Then
                c1TB.Text = "5.0 kHz"
            ElseIf c1TB.Text = "5.0 kHz" Then
                c1TB.Text = "8.0 kHz"
            ElseIf c1TB.Text = "8.0 kHz" Then
                c1TB.Text = "6.5 kHz"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
        End If

        If ml3 = "modulation type" Then
            If c1TB.Text = "AM" Then
                c1TB.Text = "FM"
            ElseIf c1TB.Text = "FM" Then
                If storedCryptoMode = "AES" Or storedCryptoMode = "NONE" Then
                    c1TB.Text = "AM"
                Else
                    c1TB.Text = "MS181"
                End If

            ElseIf c1TB.Text = "MS181" Then
                c1TB.Text = "AM"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
        End If

        If ml3 = "key source" Then
            If c1TB.Text = "RTS" Then
                c1TB.Text = "DATA"
            Else
                c1TB.Text = "RTS"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
        End If

        If ml3 = "lpc codebook" Then
            If c1TB.Text = "ENGLISH" Then
                c1TB.Text = "DUTCH"
            ElseIf c1TB.Text = "DUTCH" Then
                c1TB.Text = "ARABIC"
            ElseIf c1TB.Text = "ARABIC" Then
                c1TB.Text = "ENGLISH"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
        End If

        If ml3 = "voice mode select" Then
            Select Case storedTraffic
                Case "VOICE"
                    If storedVoiceMode = "CLEAR" Then
                        storedVoiceMode = "CVSD"
                        Select Case storedCryptoMode
                            Case "VINSON"
                                storedBPS = "16k"
                            Case "AES"
                                storedBPS = "16k"
                            Case "NONE"
                                storedBPS = "16k"
                            Case "FASCINATOR"
                                storedBPS = "12k"
                        End Select

                    ElseIf storedVoiceMode = "CVSD" Then
                        storedVoiceMode = "CLEAR"
                        Select Case storedCryptoMode
                            Case "VINSON"
                                storedBPS = " "
                            Case "AES"
                                storedBPS = " "
                            Case "NONE"
                                storedBPS = " "
                            Case "FASCINATOR"
                                storedBPS = " "
                        End Select
                    End If

                Case "VOICE AND DATA"
                    If storedCryptoMode = "ANDVT" Then
                        If storedVoiceMode = "LPC 2400" Then
                            storedVoiceMode = "MELP 2400"
                        ElseIf storedVoiceMode = "MELP 2400" Then
                            storedVoiceMode = "LPC 2400"
                        End If
                    End If

                    If storedCryptoMode = "VINSON" Then
                        storedVoiceMode = "CVSD"
                    End If
            End Select

            c1TB.Text = storedVoiceMode
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub

        End If

        If ml3 = "data mode select" Then
            If c1TB.Text = "SYNCRONOUS" Then
                c1TB.Text = "ASYNCRONOUS"
            Else
                c1TB.Text = "SYNCRONOUS"
            End If

            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "traffic mode" Then
            Select Case storedCryptoMode

                Case "NONE"
                    If storedTraffic = "VOICE" Then
                        storedTraffic = "DATA"
                    Else
                        storedTraffic = "VOICE"
                    End If

                Case "ANDVT"
                    If storedTraffic = "DATA" Then
                        storedTraffic = "VOICE AND DATA"
                    Else
                        storedTraffic = "DATA"
                    End If

                Case "VINSON"
                    If storedTraffic = "VOICE AND DATA" Then
                        storedTraffic = "VOICE"
                    ElseIf storedTraffic = "VOICE" Then
                        storedTraffic = "DATA"
                    ElseIf storedTraffic = "DATA" Then
                        storedTraffic = "VOICE AND DATA"
                    End If

                Case "AES"
                    If storedTraffic = "VOICE" Then
                        storedTraffic = "DATA"
                    Else
                        storedTraffic = "VOICE"
                    End If
            End Select


            c1TB.Text = storedTraffic
            SetWidth(c1TB)
            CenterMe(c1TB)

            Exit Sub
        End If

        If ml3 = "rx fade priority" Or ml3 = "voice autoswitch" Then
            If c1TB.Text = "ENABLED" Then
                c1TB.Text = "DISABLED"
            Else
                c1TB.Text = "ENABLED"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "check submode" Then
            Select Case c1TB.Text
                Case "STANDARD"
                    c1TB.Text = "ALTERNATE"
                Case "ALTERNATE"
                    c1TB.Text = "STANDARD"

                Case "CTR1 (MIN ERR PROP)"
                    c1TB.Text = "CFB1 (CPHR FDBK RESYNC)"
                Case "CFB1 (CPHR FDBK RESYNC)"
                    c1TB.Text = "CTR1 (MIN ERR PROP)"

                Case "REDUNDANT (MODE1)"
                    c1TB.Text = "NON-REDUND*(MODE4)"
                Case "REDUNDANT*(MODE2)"
                    c1TB.Text = "REDUNDANT (MODE1)"
                Case "NON-REDUND (MODE3)"
                    c1TB.Text = "REDUNDANT*(MODE2)"
                Case "NON-REDUND*(MODE4)"
                    c1TB.Text = "NON-REDUND (MODE3)"

                Case "6"
                    c1TB.Text = "60"
                Case "9"
                    c1TB.Text = "6"
                Case "12"
                    c1TB.Text = "9"
                Case "15"
                    c1TB.Text = "12"
                Case "20"
                    c1TB.Text = "15"
                Case "30"
                    c1TB.Text = "20"
                Case "60"
                    c1TB.Text = "30"

            End Select

            SetWidth(c1TB)
            CenterMe(c1TB)

            Exit Sub
        End If

        If ml3 = "encryption key" Then
            TekConversion()
            Exit Sub
        End If

        If ml3 = "crypto mode" Then
            Select Case c1TB.Text
                Case "ANDVT"
                    c1TB.Text = "KG84"
                Case "VINSON"
                    c1TB.Text = "ANDVT"
                Case "NONE"
                    c1TB.Text = "VINSON"
                Case "AES"
                    c1TB.Text = "NONE"
                Case "FASCINATOR"
                    c1TB.Text = "AES"
                Case "KG84"
                    c1TB.Text = "FASCINATOR"
            End Select
            SetWidth(c1TB)
            CenterMe(c1TB)
            Exit Sub
        End If

        If ml3 = "vulos rx only" Then
            YesNoChoice()
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If

        If ml3 = "tx freq source" Then

            If c1TB.Text = "USE RX FREQ" Then
                c1TB.Text = "EDIT TX FREQ"
                SetWidth(c1TB)
                CenterMe(c1TB)
            Else
                c1TB.Text = "USE RX FREQ"
                SetWidth(c1TB)
                CenterMe(c1TB)
            End If

            Exit Sub

        End If

        If ml3 = "preset type" Then

            If c1TB.Text = "LOS" Then
                c1TB.Text = "SATCOM"
                SetWidth(c1TB)
                CenterMe(c1TB)
            Else
                c1TB.Text = "LOS"
                SetWidth(c1TB)
                CenterMe(c1TB)
            End If

            Exit Sub

        End If


        'checks if the VULOS 1 page is active
        If vulosDisplayed = True And ml1 = "" Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "9"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "9"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If




        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "9"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "9"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If







        If ml3 = "scan config" Then
            GenericMenuScroll()
            Exit Sub
        End If



        If ml1 = "lock keypad" Then 'locks the keypad
            If keypadLock = "137" Then
                keypadLock = ""
                DisplayOptionsMenu()
            End If

        ElseIf ml1 = "program" And ml2 = "" Then
            ProgramScrollDn()
        ElseIf ml1 = "program" And ml2 = "system presets" And ml3 = "" Then
            ScrollDown()
        ElseIf ml1 = "program" And ml2 = "system presets" And ml3 = "programming menu" Then
            ProgrammingMenuMoveDn()
            MeasureArray()
            AutoScrollbar()
        ElseIf ml1 = "program" And ml2 = "vulos config" Then
            If b1TB.BackColor = Color.Black Then
                SetBackGreen(b1TB)
                SetBackBlack(c1TB)
            End If


        ElseIf ml1 = "fill" And ml2 = "" Then
            GenericMenuScroll()
        ElseIf ml1 = "mode" And ml2 = "scan" And ml3 = "enable" Then
            c1TB.Text = "DISABLE"
            ml3 = "disable"
            SetWidth(c1TB)
            CenterMe(c1TB)
        ElseIf ml1 = "mode" And ml2 = "scan" And ml3 = "disable" Then
            c1TB.Text = "ENABLE"
            ml3 = "enable"
            SetWidth(c1TB)
            CenterMe(c1TB)
        ElseIf ml1 = "mode" And ml2 = "otar transmit" And (ml3 = "NO" Or ml3 = "YES") Then
            YesNoChoice()
            ml3 = c1TB.Text
        ElseIf ml1 = "mode" And ml2 = "otar receive" And ml3 = "receive mk" Then
            c1TB.Text = "RECEIVE AK"
            ml3 = "receive ak"
            HelperUpdate()
            PositionAndHighlight()
        ElseIf ml1 = "mode" And ml2 = "otar receive" And ml3 = "receive ak" Then
            c1TB.Text = "RECEIVE MK"
            ml3 = "receive mk"
            HelperUpdate()
            PositionAndHighlight()
        ElseIf ml1 = "mode" And ml2 = "clone mode" And c1TB.Text = "RECEIVE CLONE" Then
            c1TB.Text = "TRANSMIT CLONE"
            PositionAndHighlight()
        ElseIf ml1 = "mode" And ml2 = "clone mode" And c1TB.Text = "TRANSMIT CLONE" Then
            c1TB.Text = "RECEIVE CLONE"
            PositionAndHighlight()
        ElseIf ml1 = "fill" And ml2 = "fill device type" And ml3 <> "key number:" Then
            xHi = 15
            SingleLineScroll()
        ElseIf ml1 = "fill" And ml2 = "fill device type" And ml3 = "key number:" Then
            GenericNumberScroll()
        ElseIf ml1 = "mode" And ml2 = "" Then
            GenericMenuScroll()
        ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
            numberPushed = 9
            EnterNumber()
        ElseIf ml1 = "radio options" And ml2 = "" Then
            If c1TB.Text = "OFF" Then
                c1TB.Text = "ON"
                radioSilenceState = "ON"
                c1TB.Width = c1TB.TextLength * 15
                c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                FlashRon()
            ElseIf c1TB.Text = "ON" Then
                c1TB.Text = "OFF"
                radioSilenceState = "OFF"
                c1TB.Width = c1TB.TextLength * 14
                c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                a1TB.Visible = True
                FlashRoff()
            End If
        ElseIf ml1 = "radio options" And ml2 = "rf faults persist" Then
            If c1TB.Text = "OFF" Then
                c1TB.Text = "ON"
                c1TB.Width = c1TB.TextLength * 15
                c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
            ElseIf c1TB.Text = "ON" Then
                c1TB.Text = "OFF"
                c1TB.Width = c1TB.TextLength * 14
                c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                a1TB.Visible = True
            End If
        ElseIf ml1 = "radio options" And (ml2 = "pa failsafe" Or ml2 = "remote kdu") Then
            If c1TB.Text = "DISABLED" Then
                c1TB.Text = "ENABLED"
                c1TB.Width = c1TB.TextLength * 13
                c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
            ElseIf c1TB.Text = "ENABLED" Then
                c1TB.Text = "DISABLED"
                c1TB.Width = c1TB.TextLength * 12
                c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                a1TB.Visible = True
            End If
        ElseIf ml1 = "sa options" And ml2 = "" Then
            If c1TB.Text = "DISABLE" Then
                c1TB.Text = "ENABLE"
                c1TB.Width = c1TB.TextLength * 13
                c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
            ElseIf c1TB.Text = "ENABLE" Then
                c1TB.Text = "DISABLE"
                c1TB.Width = c1TB.TextLength * 12
                c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
                a1TB.Visible = True
            End If
        ElseIf ml1 = "system information" And ml2 = "" Then
            SysInfoScrollDown()
        ElseIf ml1 = "system information" And ml2 = "versions" Then
            VersionScrollDown()
        ElseIf ml1 = "tx power options" And ml2 = "" Then
            direction = "down"
            TxPowerScroll()
        ElseIf ml1 = "tx power options" And ml2 = "user" Then
            direction = "down"
            TxPowerUserScroll()
        ElseIf ml1 = "view key info" And ml2 = "" Then
            direction = "down"
            KeyInfoNameScroll()
        ElseIf ml1 = "view key info" And ml2 <> "" Then
            direction = "down"
            KeyTypeScroll()




        Else
            If ml1 = "" Then

                OptionsScrollDown()
            ElseIf ml1 = "test options" And ml2 = "wideband tests" And ml5 = "input frequency" Then
                NumberDown()
            ElseIf ml1 = "data mode" And menuDepth = 1 Then
                OffOnChoice()

            ElseIf ml1 = "gps options" And ml2 = "" Then
                GenericScrollDown()
            ElseIf ml1 = "gps options" And ml2 = "gps status" Then
                ScrollGPSstatusDown()
            ElseIf ml1 = "mission plan" And ml2 = "" Then
                MissionPlanMainScroll()
            ElseIf ml1 = "mission plan" And ml2 = "activate plan" Then
                SelectStationScrollDown()
            ElseIf ml1 = "mission plan" And ml2 = "mission plan loading" Then
                YesNoChoice()
            ElseIf ml1 = "network options" And ml2 = "" Then
                GenericScrollDown()
                b7PB.BackgroundImage = My.Resources.scrollbarFull
            ElseIf ml1 = "network options" And ml2 = "ping by" Then
                PingScroll()
            ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
                'PingAddressDown() 'scrolls the individual digit down
                GenericScrollDown() 'scrolls the host name down
                b7PB.BackgroundImage = My.Resources.scrollbarFull
            ElseIf ml1 = "network options" And ml2 = "keychain verification" Then
                KeychainDown()
            ElseIf ml1 = "radio information" And ml2 = "" Then
                GenericScrollDown()
                b7PB.BackgroundImage = My.Resources.scrollbarFull



            ElseIf ml2 = "on" And menuDepth = 2 Then
                If c1TB.Text = "SYNC/ASYNC" Then
                    c1TB.Text = "PPP"
                ElseIf c1TB.Text = "PPP" Then
                    c1TB.Text = "SYNC/ASYNC"
                End If
                c1TB.Width = c1TB.TextLength * 12
                c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)

            Else

                If menuDepth = 3 Then
                    testOptionsBertBertModeTransmitOrReceive()
                End If

                If ml2 = "bert" And menuDepth = 4 Then
                    SyncChoicesDown()
                End If

                If ml4 = "y/n" Or ml5 = "y/n" Or ml6 = "y/n" Then
                    YesNoChoice()
                End If

                If ml2 = "optional tests" Then
                    OptionalTestsSubMenu()
                End If

                If ml2 = "wideband tests" Then
                    WidebandMenuScrollDown()
                End If

                If ml4 = "3 to 8 min" Then
                    YesNoChoice()
                End If

                TestOptionsScrollDown()

                If ml3 = "tx rx" And menuDepth = 3 Then
                    If c1TB.Text = "TX" Then
                        c1TB.Text = "RX"
                        c1TB.Width = 28
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    ElseIf c1TB.Text = "RX" Then
                        c1TB.Text = "TX"
                        c1TB.Width = 28
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    End If
                End If

                If (ml4 = "tx" Or ml4 = "rx") And menuDepth = 4 Then
                    If c1TB.Text = "HIGHBAND" Then
                        c1TB.Text = "LOWBAND"
                        c1TB.Width = 94
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    ElseIf c1TB.Text = "LOWBAND" Then
                        c1TB.Text = "HIGHBAND"
                        c1TB.Width = 100
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    End If
                End If

                If ml3 = "rx sensitivity" Or ml3 = "tx power" Or ml3 = "tx frequency" Or ml3 = "full duplex" And menuDepth = 3 Then
                    If c1TB.Text = "HIGHBAND" Then
                        c1TB.Text = "LOWBAND"
                        c1TB.Width = 94
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    ElseIf c1TB.Text = "LOWBAND" Then
                        c1TB.Text = "HIGHBAND"
                        c1TB.Width = 100
                        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
                    End If
                End If

                If (ml5 = "highband" Or ml5 = "lowband") And menuDepth = 5 Then
                    If c1TB.Text = "5000 KHz" Then
                        c1TB.Text = "2500 KHz"
                    ElseIf c1TB.Text = "2500 KHz" Then
                        c1TB.Text = "1250 KHz"
                    ElseIf c1TB.Text = "1250 KHz" Then
                        c1TB.Text = "5000 KHz"
                    End If
                End If

                If (ml4 = "highband" Or ml4 = "lowband") And menuDepth = 4 Then
                    If c1TB.Text = "5000 KHz" Then
                        c1TB.Text = "2500 KHz"
                    ElseIf c1TB.Text = "2500 KHz" Then
                        c1TB.Text = "1250 KHz"
                    ElseIf c1TB.Text = "1250 KHz" Then
                        c1TB.Text = "5000 KHz"
                    End If
                End If

                If ml2 = "keypad test" And ml3 = "press any key" Then
                    c1TB.Text = "DOWN ARROW"
                    PositionAndHighlight()
                End If

            End If
        End If




        'for using buttons as a keyboard
        If (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And (nameBox1.Visible = True Or ip1.Visible = True) Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text

            If lastClick <> 9 Then
                lastClick = 9 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            If myCount = 5 Then 'sets the highest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "Y"
                Case 2
                    highlightedNameBox.Text = "Z"
                Case 3
                    highlightedNameBox.Text = "?"
                Case 4
                    highlightedNameBox.Text = "9"
            End Select

            ArrangeNameboxes()


            myCount += 1
            lastClick = 9

        End If

        HelperUpdate()

        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

    End Sub

    Private Sub YesNoChoice()
        If c1TB.Text = "NO" Then
            c1TB.Text = "YES"
        ElseIf c1TB.Text.ToUpperInvariant = "YES" Then
            c1TB.Text = "NO"
        End If
        SetWidth(c1TB)
        CenterMe(c1TB)
    End Sub

    'NEXT button


    Public Sub btnLeftArrow_Click(sender As Object, e As EventArgs) Handles btnLeftArrow.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        direction = "left"
        Dim ipHighlightMoveAttempted = TransitionIPboxes()
        If ipHighlightMoveAttempted = True Then
            Exit Sub
        End If

        Dim nameBoxAttemptedMove = TransitionNameboxes()
        If nameBoxAttemptedMove = True Then
            Exit Sub
        End If

        If ml3 = "max retrans attempts" Or ml3 = "ike timeout" Then
            If ip2.BackColor = Color.Black Then
                SetBackBlack(ip1)
                SetBackGreen(ip2)
            End If
            Exit Sub
        End If


        If ml3 = "beacon tx duration" Or ml3 = "beacon off duration" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Then
            If nameBox3.BackColor = Color.Black Then
                SetBackBlack(nameBox2)
                SetBackGreen(nameBox3)
            End If
            Exit Sub
        End If


        If ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Or ml3 = "voice key up timeout time" Then
            GetHighlightedNamebox()
            If nameBox1.BackColor = Color.Black Then
                'do nothing
            Else
                PresetNameMoveLeft()
            End If

            Exit Sub
        End If

        If ml3 = "squelch level" Then
            manualSquelchSetting -= 5
            If manualSquelchSetting < 0 Then
                manualSquelchSetting = 0
            End If
            tbFront.Width = manualSquelchSetting
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then

            If nameBox3.BackColor = Color.Black Then
                SetBackBlack(nameBox2)
                SetBackGreen(nameBox3)
            ElseIf nameBox2.BackColor = Color.Black Then
                SetBackBlack(nameBox1)
                SetBackGreen(nameBox2)
            End If



            Exit Sub
        End If


        If ml1 = "lock keypad" Then 'locks the keypad
        Else
            If ml2 = "keypad test" And ml3 = "press any key" Then
                c1TB.Text = "LEFT ARROW"
                PositionAndHighlight()

            ElseIf (ml3 = "beacon frequency" Or ml3 = "system preset name" Or ml3 = "preset description" Or ml3 = "general config" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq") Then
                PresetNameMoveLeft()

            ElseIf ml2 = "ping in progress" Or ml3 = "gps sleep cycle" Or ml3 = "port config ip address" Or ml3 = "port config gateway address" Or ml3 = "port config peer ip address" Or ml3 = "port config subnet mask" Then
                IPdigitLeft()
            Else

                direction = "backward"

                If digit9.BackColor = Color.Black Then 'moves the cursor to the left
                    digit9.BackColor = Color.MediumSeaGreen
                    digit9.ForeColor = Color.Black
                    digit8.BackColor = Color.Black
                    digit8.ForeColor = Color.MediumSeaGreen
                ElseIf digit8.BackColor = Color.Black Then
                    digit8.BackColor = Color.MediumSeaGreen
                    digit8.ForeColor = Color.Black
                    digit7.BackColor = Color.Black
                    digit7.ForeColor = Color.MediumSeaGreen
                ElseIf digit7.BackColor = Color.Black Then
                    digit7.BackColor = Color.MediumSeaGreen
                    digit7.ForeColor = Color.Black
                    digit6.BackColor = Color.Black
                    digit6.ForeColor = Color.MediumSeaGreen
                ElseIf digit6.BackColor = Color.Black Then
                    digit6.BackColor = Color.MediumSeaGreen
                    digit6.ForeColor = Color.Black
                    digit4.BackColor = Color.Black
                    digit4.ForeColor = Color.MediumSeaGreen
                ElseIf digit4.BackColor = Color.Black Then
                    digit4.BackColor = Color.MediumSeaGreen
                    digit4.ForeColor = Color.Black
                    digit3.BackColor = Color.Black
                    digit3.ForeColor = Color.MediumSeaGreen
                ElseIf digit3.BackColor = Color.Black Then
                    digit3.BackColor = Color.MediumSeaGreen
                    digit3.ForeColor = Color.Black
                    digit2.BackColor = Color.Black
                    digit2.ForeColor = Color.MediumSeaGreen
                ElseIf digit2.BackColor = Color.Black Then
                    digit2.BackColor = Color.MediumSeaGreen
                    digit2.ForeColor = Color.Black
                    digit1.BackColor = Color.Black
                    digit1.ForeColor = Color.MediumSeaGreen
                End If

                If ml2 = "lcd test" Then '3-18
                    checkArray()
                End If

            End If
        End If

        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

    End Sub

    Public Sub btnRightArrow_Click(sender As Object, e As EventArgs) Handles btnRightArrow.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        direction = "right"
        Dim ipHighlightMoveAttempted = TransitionIPboxes()
        If ipHighlightMoveAttempted = True Then
            Exit Sub
        End If

        Dim nameBoxAttemptedMove = TransitionNameboxes()
        If nameBoxAttemptedMove = True Then
            Exit Sub
        End If

        If ml3 = "max retrans attempts" Or ml3 = "ike timeout" Then
            If ip1.BackColor = Color.Black Then
                SetBackBlack(ip2)
                SetBackGreen(ip1)
            End If
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "beacon off duration" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Then
            If nameBox2.BackColor = Color.Black Then
                SetBackBlack(nameBox3)
                SetBackGreen(nameBox2)
            End If
            Exit Sub
        End If

        If ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            GetHighlightedNamebox()
            If nameBox5.BackColor = Color.Black Then
                'do nothing
            Else
                PresetNameMoveRight()
            End If

            Exit Sub
        End If

        If vulosDisplayed = True Then
            Exit Sub
        End If

        If ml3 = "squelch level" Then
            manualSquelchSetting += 5
            If manualSquelchSetting > 100 Then
                manualSquelchSetting = 100
            End If
            tbFront.Width = manualSquelchSetting
            Exit Sub
        End If


        If ml3 = "satcom ch num" Then

            If nameBox1.BackColor = Color.Black Then
                SetBackBlack(nameBox2)
                SetBackGreen(nameBox1)
            ElseIf nameBox2.BackColor = Color.Black Then
                SetBackBlack(nameBox3)
                SetBackGreen(nameBox2)
            End If



            Exit Sub
        End If

        If vulosDisplayed = True And ml1 = "" Then
            Highlight(b1TB)
        End If

        If ml3 = "system preset number" Then 'for changing preset numbers in the program menu
            Highlight(c1TB)
        End If

        If (ml3 = "beacon frequency" Or ml3 = "voice key up timeout time" Or ml3 = "confirm maint pswd" Or ml3 = "change maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "system preset name" Or ml3 = "preset description" Or ml3 = "general config" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq") Then
            If b6PB.Visible = True Then
                Exit Sub
            End If
            PresetNameMoveRight()
            If ml3 = "change maint pswd" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Then
                HideCharacters()
            End If
        End If


        If ml1 = "lock keypad" Then 'locks the keypad
        Else
            If ml2 = "keypad test" And ml3 = "press any key" Then
                c1TB.Text = "RIGHT ARROW"
                PositionAndHighlight()
            ElseIf ml2 = "ping in progress" Or ml3 = "gps sleep cycle" Or ml3 = "port config ip address" Or ml3 = "port config gateway address" Or ml3 = "port config subnet mask" Or ml3 = "port config peer ip address" Then
                IPdigitRight()
            Else


                direction = "forward"

                If digit1.BackColor = Color.Black Then 'moves the cursor to the right
                    digit1.BackColor = Color.MediumSeaGreen
                    digit1.ForeColor = Color.Black
                    digit2.BackColor = Color.Black
                    digit2.ForeColor = Color.MediumSeaGreen
                ElseIf digit2.BackColor = Color.Black Then
                    digit2.BackColor = Color.MediumSeaGreen
                    digit2.ForeColor = Color.Black
                    digit3.BackColor = Color.Black
                    digit3.ForeColor = Color.MediumSeaGreen
                ElseIf digit3.BackColor = Color.Black Then
                    digit3.BackColor = Color.MediumSeaGreen
                    digit3.ForeColor = Color.Black
                    digit4.BackColor = Color.Black
                    digit4.ForeColor = Color.MediumSeaGreen
                ElseIf digit4.BackColor = Color.Black Then
                    digit4.BackColor = Color.MediumSeaGreen
                    digit4.ForeColor = Color.Black
                    digit6.BackColor = Color.Black
                    digit6.ForeColor = Color.MediumSeaGreen
                ElseIf digit6.BackColor = Color.Black Then
                    digit6.BackColor = Color.MediumSeaGreen
                    digit6.ForeColor = Color.Black
                    digit7.BackColor = Color.Black
                    digit7.ForeColor = Color.MediumSeaGreen
                ElseIf digit7.BackColor = Color.Black Then
                    digit7.BackColor = Color.MediumSeaGreen
                    digit7.ForeColor = Color.Black
                    digit8.BackColor = Color.Black
                    digit8.ForeColor = Color.MediumSeaGreen
                ElseIf digit8.BackColor = Color.Black Then
                    digit8.BackColor = Color.MediumSeaGreen
                    digit8.ForeColor = Color.Black
                    digit9.BackColor = Color.Black
                    digit9.ForeColor = Color.MediumSeaGreen

                End If

                If ml2 = "lcd test" Then '3-18
                    checkArray()
                End If
            End If
        End If

        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()

    End Sub

    Private Sub TurnOnCheck()



        If image = False Then 'image is FALSE only when the mode knob was OFF. 

            'kdu.StartDisplayTimer() 'starts a timer for duplicating the display on the kdu

            't = New Thread(AddressOf Me.timeDelay)  'Create thread for display update

            'CheckForIllegalCrossThreadCalls = False
            'timeDelayCount = 0

            't.Start()

            image = True 'sets the image to TRUE indicating the mode knob is set to either CT or PT

            startTimerCount = 0
            StartTimer.Enabled = True
            StartTimer.Interval = 1000

        End If
    End Sub

    Private Sub StartTimer_Tick(sender As Object, e As EventArgs) Handles StartTimer.Tick

        startTimerCount += 1


        displayPic.Visible = True 'turns the display background image to visible

        If startTimerCount = 1 Then
            displayPic.BackgroundImage = My.Resources.Initializing_Screen 'displays INITIALIZING logo after 1 second
            kdu.displayPic.BackgroundImage = My.Resources.Initializing_Screen
            kdu.displayPic.Visible = True

        End If

        If startTimerCount = 2 Then
            displayPic.BackgroundImage = My.Resources.BlankGreen  'after 2 seconds background changes to green
            kdu.displayPic.BackgroundImage = My.Resources.BlankGreen
            screenReady = True
        End If

        If startTimerCount > 2 Then
            StartTimer.Stop()
            kdu.displayPic.Visible = False
        End If

        If ml3 = "zeroize alert" Then
            Exit Sub
        End If

        If ml2 = "memory test" And menuDepth = 6 Then
            MemoryTestInProgress()
        ElseIf knobIndex = 1 Or knobIndex = 2 Then
            DisplayVulosPage1()
        ElseIf knobIndex = 3 Then
            DisplayLoadPage1()
        ElseIf knobIndex = 4 Then

        End If

    End Sub


    Private Sub timeDelay()

        'this section was modified on 3-30-15. The idea was to get rid of the thread in favor of timers. This will
        'allow easier coding for the KDU because the threads were making it dificult (and unnecessarily complicated)
        'in determining when items changed on the PRC display.


        'timeStart = 0 'variable used to store a start time reference
        'timeEnd = 0 'variable used to store an end time variable 
        'displayPic.Visible = True 'turns the display background image to visible



        'Do While (timeEnd - 2) <> timeStart 'begin new thread to time display

        '    If formIsClosed = True Then 'checks to see if the main form is closed
        '        Exit Do 'exits do loop and closes thread if form is closed
        '    End If

        '    System.Threading.Thread.Sleep(1000)
        '    timeEnd = timeEnd + 1


        '    If (timeEnd - 1) = timeStart Then   'checks for 5 second duration

        '        Try
        '            displayPic.BackgroundImage = My.Resources.Initializing_Screen 'displays INITIALIZING logo after additional 5 seconds
        '            kdu.displayPic.BackgroundImage = My.Resources.Initializing_Screen

        '        Catch ex As Exception

        '        End Try
        '    End If

        '    If (timeEnd - 2) = timeStart Then   'checks for 6 second duration

        '        Try
        '            displayPic.BackgroundImage = My.Resources.BlankGreen  'after 20 seconds background changes to green
        '            kdu.displayPic.BackgroundImage = My.Resources.BlankGreen
        '            screenReady = True
        '        Catch ex As Exception

        '        End Try
        '    End If
        '    timeDelayCount = timeDelayCount + 1

        'Loop
        'If ml2 = "memory test" And menuDepth = 6 Then
        '    MemoryTestInProgress()
        'ElseIf knobIndex = 1 Or knobIndex = 2 Then
        '    DisplayVulosPage1()
        'ElseIf knobIndex = 3 Then
        '    DisplayLoadPage1()
        'ElseIf knobIndex = 4 Then

        'End If



    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed


        formIsClosed = True
    End Sub

    Private Sub WhichScreenToShow()



        If knobIndex = 1 Then

            a7TB.Text = "CT"
            a7TB.BackColor = Color.MediumSeaGreen
            a7TB.ForeColor = Color.Black

        End If

        If knobIndex = 2 Then

            a7TB.Text = "PT"
            a7TB.BackColor = Color.Black
            a7TB.ForeColor = Color.MediumSeaGreen
        End If


    End Sub

    Public Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        If ButtonBypass() = True Then
            Exit Sub
        End If

        thisNum = "0"

        Dim isNumPushed = checkNumPushed() 'calling function to insert pushed number into digit
        If isNumPushed = True Then
            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            satcomChannelUpdate()
            Exit Sub
        End If

        If ml3 = "beacon tx duration" Or ml3 = "voice key up timeout time" Or ml3 = "hang time duration" Or ml3 = "hold time duration" Or ml3 = "beacon off duration" Or ml3 = "beacon frequency" Or ml3 = "vulos rx freq" Or ml3 = "enter tx freq" Or ml3 = "ctcss user entry" Or ml3 = "ctcss rx user entry" Then
            SetNumberFromKeypad(thisNum)
            Exit Sub
        End If


        'checks if the VULOS 1 page is active
        If vulosDisplayed = True Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If b1TB.Text.Contains(dash) = True Then
                    b1TB.Text = "0"
                Else
                    'if dash is not present, concatenate the text
                    b1TB.Text = b1TB.Text + "0"

                    'used to ensure the string does not exceed two digits
                    If b1TB.TextLength > 2 Then
                        b1TB.Text = GetChar(b1TB.Text, 2) + GetChar(b1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If




        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                'if the dash is present, override the current text with new text
                If c1TB.Text.Contains(dash) = True Then
                    c1TB.Text = "0"
                Else
                    'if dash is not present, concatenate the text
                    c1TB.Text = c1TB.Text + "0"

                    'used to ensure the string does not exceed two digits
                    If c1TB.TextLength > 2 Then
                        c1TB.Text = GetChar(c1TB.Text, 2) + GetChar(c1TB.Text, 3)
                    End If

                End If
                Exit Sub
            End If


        End If





        If ml1 = "lock keypad" Then 'locks the keypad
        ElseIf ml1 = "network options" And ml2 = "ping in progress" Then
            numberPushed = 0
            EnterNumber()
        Else
            If ml2 = "keypad test" And ml3 = "press any key" Then
                c1TB.Text = "0 BUTTON"
                PositionAndHighlight()
            Else
                If vulosDisplayed = True And pageDisplayed = 1 Then
                    DisplayVulosPage2()
                ElseIf vulosDisplayed = True And pageDisplayed = 2 Then
                    DisplayVulosPage3()
                ElseIf vulosDisplayed = True And pageDisplayed = 3 Then
                    DisplayVulosPage4()
                ElseIf vulosDisplayed = True And pageDisplayed = 4 Then
                    Me.Controls.Remove(page4TB1)
                    Me.Controls.Remove(page4TB2)
                    DisplayVulosPage1()
                End If



                If ml4 = "receive" Then

                    If currentPageNum = 1 Then
                        BertPage2Display()
                    ElseIf currentPageNum = 2 Then
                        BertPage1Display()
                    End If


                End If
            End If
        End If

        'for using buttons as a keyboard
        If (ml3 = "system preset name" Or ml3 = "maintenance password" Or ml3 = "sa name" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd" Or ml3 = "change maint pswd" Or ml3 = "preset description" Or ml3 = "general config") And nameBox1.Visible = True Then

            GetRidOfINSERTDESCRIPTION() 'deletes the INSERT DESCRIPTION text


            If lastClick <> 0 Then
                lastClick = 0 'used for tacking how many times a button is pushed
                myCount = 1
            End If

            If myCount = 0 Then 'sets the lowest possible value
                myCount = 1
            End If

            GetHighlightedNamebox() 'gets the name of the highlighted namebox

            Select Case myCount
                Case 1
                    highlightedNameBox.Text = "0"

            End Select

            ArrangeNameboxes()


            lastClick = 0

        End If

        MyCreateMyNameboxes()   'addedto update the nameboxes on the kdu display
        MyCreateIPboxes()


    End Sub

    'Form Load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        GetInstanceOfProcess()

        senderName = "Form_Load"

        AboutBox1.ShowDialog()

        DataSetForm.Show() 'loads the dataset form
        'DataSetForm.Hide()

        SatcomPresets.Show()

        HelperForm.Show()

        OptionsCodes.Show()

        CTCSS.Show()

        MyGlobalData.Show()

        Readme.Show()

        'kdu.Show()


        RecallPreset() 'gets data from the datagridview
        GetMyGlobalData()

        CreateTextboxes()
        SetVisibilityOFF()
        ChainGenerate()

    End Sub

    Public Sub SetVisibilityOFF()

        a7TB.Visible = False
        a6TB.Visible = False
        a5TB.Visible = False
        a4TB.Visible = False
        a3PB.Visible = False
        a2TB.Visible = False
        a1TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False
        b1TB.Visible = False
        b2TB.Visible = False
        c1TB.Visible = False
        c3TB.Visible = False
        c4TB.Visible = False
        d6TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        d7TB.Visible = False
        d4TB.Visible = False
        d3TB.Visible = False
        d1TB.Visible = False

        digit1.Visible = False
        digit2.Visible = False
        digit3.Visible = False
        digit4.Visible = False
        digit5.Visible = False
        digit6.Visible = False
        digit7.Visible = False
        digit8.Visible = False
        digit9.Visible = False

        Try
            nameBox1.Visible = False
            nameBox2.Visible = False
            nameBox3.Visible = False
            nameBox4.Visible = False
            nameBox5.Visible = False
            nameBox6.Visible = False
            nameBox7.Visible = False
            nameBox8.Visible = False
            nameBox9.Visible = False
            nameBox10.Visible = False
            nameBox11.Visible = False
            nameBox12.Visible = False
            nameBox13.Visible = False
            nameBox14.Visible = False
            nameBox15.Visible = False
            nameBox16.Visible = False
            nameBox17.Visible = False
            nameBox18.Visible = False
            nameBox19.Visible = False
            nameBox20.Visible = False

            nameBox1.Text = ""
            nameBox2.Text = ""
            nameBox3.Text = ""
            nameBox4.Text = ""
            nameBox5.Text = ""
            nameBox6.Text = ""
            nameBox7.Text = ""
            nameBox8.Text = ""
            nameBox9.Text = ""
            nameBox10.Text = ""
            nameBox11.Text = ""
            nameBox12.Text = ""
            nameBox13.Text = ""
            nameBox14.Text = ""
            nameBox15.Text = ""
            nameBox16.Text = ""
            nameBox17.Text = ""
            nameBox18.Text = ""
            nameBox19.Text = ""
            nameBox20.Text = ""
        Catch
        End Try

        MyCreateTextBoxes()


    End Sub

    Private Sub DisplayVulosPage1()
        senderName = "DisplayVulosPage1"


        If screenReady = True Then 'does not allow the button press to make changes to the display until startup is complete
            If alarm = True Then
                ZeroizeAlert()
                Exit Sub
            End If

            DisplayReset()
            WhichScreenToShow()
            vulosDisplayed = True
            pageDisplayed = 1
            a1TB.Visible = True
            a1TB.Text = "R"
            a2TB.Visible = True
            a2TB.Text = "BAT"
            a3PB.Visible = True
            a4TB.Visible = True
            If storedWaveform = " " Then
                a4TB.Text = "- - -"
            Else
                a4TB.Text = storedWaveform
            End If

            a5TB.Visible = True
            ShowSquelch()

            a6TB.Visible = True
            ShowCrypto()

            a7TB.Visible = True

            b1TB.Visible = True
            b1TB.Text = storedNumber

            b2TB.Visible = True
            b2TB.Text = storedName
            b6PB.Visible = True
            b7PB.Visible = True


            If storedType = "SATCOM" Then
                c1TB.Text = "SAT"
            Else
                c1TB.Text = storedType
            End If

            c1TB.Width = 47
            c1TB.Visible = True
            c3TB.Visible = True
            c3TB.Location = New Point(432, 178)

            If storedTraffic = "VOICE" Then
                c3TB.Text = "VOC"
            ElseIf storedTraffic = "VOICE AND DATA" Then
                c3TB.Text = "D/V"
            ElseIf storedTraffic = "DATA" Then
                c3TB.Text = "DAT"
            Else
                c3TB.Text = storedTraffic
            End If
            c3TB.Width = 47
            c4TB.Visible = True

            If storedMod = "MS181" Then
                c4TB.Text = storedOptMod
            Else
                c4TB.Text = storedMod
            End If
            SetWidth(c4TB)
            c4TB.Location = New Point((d4TB.Location.X + (d4TB.Width) / 2) - (c4TB.Width / 2), c1TB.Location.Y)
            c5TB.Visible = True
            c5TB.Text = storedChannel

            Dim tempKey As String = Microsoft.VisualBasic.Strings.Right(storedCryptoKey, 2)

            If knobIndex = 2 Then
                tempKey = "- -"
            End If
            c7TB.Text = tempKey

            c7TB.Visible = True

            d1TB.Visible = True
            d1TB.Text = "TYPE"
            d3TB.Visible = True
            d3TB.Text = "TRF"
            d3TB.Width = 47
            d4TB.Visible = True
            d4TB.Text = "MOD"

            'wrapped the d6TB with an IF statement to hide it when there is no channel assignment
            If c1TB.Text = "SAT" Then
                c5TB.Visible = True
                If storedSatcomChannel = "250" Then
                    c5TB.Text = "999"
                Else
                    c5TB.Text = storedSatcomChannel
                End If

                d6TB.Visible = True
                d6TB.Text = "CHAN"
            Else
                d6TB.Visible = False
            End If
            'end wrap
            d7TB.Visible = True
            d7TB.Text = "KEY"

        End If

        ml1 = ""
        menuDepth = 0
        HelperUpdate()




    End Sub

    Private Sub DisplayVulosPage2()
        senderName = "DisplayVulosPage2"

        If screenReady = True Then

            DisplayReset()
            WhichScreenToShow()
            vulosDisplayed = True
            pageDisplayed = 2


            a1TB.Visible = True
            a1TB.Text = "R"
            a2TB.Visible = True
            a2TB.Text = "BAT"
            a3PB.Visible = True
            a4TB.Visible = True
            If storedWaveform = " " Then
                a4TB.Text = "- - -"
            Else
                a4TB.Text = storedWaveform
            End If

            a5TB.Visible = True
            ShowSquelch()

            a6TB.Visible = True
            ShowCrypto()

            a7TB.Visible = True

            b1TB.Text = "R:"
            b1TB.TextAlign = HorizontalAlignment.Left

            CheckFreqFormat(storedRXfreq)

            b2TB.Text = storedRXfreq
            b2TB.TextAlign = HorizontalAlignment.Left


            c1TB.Text = "T:"
            c1TB.TextAlign = HorizontalAlignment.Left



            If storedTXfreq = " " Then
                c3TB.Text = "RX ONLY"
            Else
                CheckFreqFormat(storedTXfreq)
                c3TB.Text = storedTXfreq
            End If

            c3TB.Width = 119
            c3TB.Location = New Point(412, 178)
            c3TB.TextAlign = HorizontalAlignment.Left

            d3TB.Width = 90
            d3TB.Text = "FREQUENCY"
            d3TB.Location = New Point(412, 198)
            d3TB.TextAlign = HorizontalAlignment.Left

            c4TB.Visible = False

            c5TB.Visible = False

            'if in satcom mode, display channel number
            If storedType = "SATCOM" Then
                c7TB.Text = storedSatcomChannel
            Else
                c7TB.Text = "- - -"
            End If


            d1TB.Visible = False

            d4TB.Visible = False

            d6TB.Visible = False

            d7TB.Text = "CHAN"





        End If
    End Sub


    Private Sub DisplayVulosPage3()
        DisplayReset()
        WhichScreenToShow()
        vulosDisplayed = True
        pageDisplayed = 1
        a1TB.Visible = True
        a1TB.Text = "R"
        a2TB.Visible = True
        a2TB.Text = "BAT"
        a3PB.Visible = True
        a4TB.Visible = True

        If storedWaveform = " " Then
            a4TB.Text = "- - -"
        Else
            a4TB.Text = storedWaveform
        End If

        a5TB.Visible = True
        ShowSquelch()

        a6TB.Visible = True
        ShowCrypto()

        a7TB.Visible = True

        b1TB.Location = New Point(b1TB.Location.X + 7, b1TB.Location.Y)
        If storedBW = " " Then
            b1TB.Text = "- - -"
        Else
            b1TB.Text = storedBW
        End If

        SetWidth(b1TB)
        b1TB.Visible = True


        b2TB.Location = New Point(b1TB.Location.X + b1TB.Width + 17, b2TB.Location.Y)
        If storedBPS = " " Then
            b2TB.Text = "- - -"
        Else
            b2TB.Text = storedBPS
        End If
        SetWidth(b2TB)
        b2TB.Visible = True


        modBox.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        modBox.TextAlign = HorizontalAlignment.Center
        SetBackGreen(modBox)
        modBox.BorderStyle = BorderStyle.None
        SetWidth(modBox)
        modBox.Location = New Point(b1TB.Location.X + 115, b2TB.Location.Y)
        Me.Controls.Add(modBox)
        If storedMod = " " Then
            modBox.Text = "- - -"
        Else
            modBox.Text = storedMod
        End If
        SetWidth(modBox)

        modBox.Visible = True
        modBox.BringToFront()


        b6PB.Visible = True
        b7PB.Visible = True


        If storedOption = " " Then
            c1TB.Text = "- - -"
        Else
            c1TB.Text = storedOption
        End If

        c1TB.Width = 47
        c1TB.Visible = True
        c3TB.Visible = True

        If storedDataMode = "SYNCRONOUS" Then
            c3TB.Text = "SYNC"
        ElseIf storedDataMode = "ASYNCRONOUS" Then
            c3TB.Text = "ASYNC"
        Else
            c3TB.Text = "- - -"
        End If

        SetWidth(c3TB)
        c3TB.Location = New Point((d3TB.Location.X + 26) - (c3TB.Width / 2), 178)

        If storedTraffic = "DATA" Then
            c4TB.Text = "- - - -"
        Else
            If storedVoiceMode = "MELP 2400" Then
                c4TB.Text = "MELP"
            ElseIf storedVoiceMode = "LPC 2400" Then
                c4TB.Text = "LPC"
            ElseIf storedVoiceMode = " " Then
                c4TB.Text = "CLR"
            End If

        End If
        SetWidth(c4TB)
        d4TB.Location = New Point(d4TB.Location.X + 7, d4TB.Location.Y)
        c4TB.Location = New Point((d4TB.Location.X + (d4TB.Width / 2)) - c4TB.Width / 2, c4TB.Location.Y)
        c4TB.Visible = True

        If storedOption = " " Then
            storedInterleave = " "
        End If

        If storedInterleave = " " Then
            c5TB.Text = "- -"
        Else
            c5TB.Text = storedInterleave
        End If
        SetWidth(c5TB)
        c5TB.Location = New Point((d6TB.Location.X + (d6TB.Width / 2)) - c5TB.Width / 2, c5TB.Location.Y)
        c5TB.Visible = True


        If storedFWDerror = " " Then
            c7TB.Text = "OFF"
        Else
            c7TB.Text = storedFWDerror
        End If


        SetWidth(c7TB)
        c7TB.Visible = True



        d1TB.Visible = True
        d1TB.Text = "OPT"
        d3TB.Visible = True
        d3TB.Text = "DATA"
        d3TB.Width = 47

        d4TB.Visible = True
        d4TB.Text = "VOICE"
        d6TB.Location = New Point(d6TB.Location.X + 4, d6TB.Location.Y)
        d6TB.Text = "INTLV"
        d6TB.Visible = True
        d7TB.Text = "FEC"
        d7TB.Visible = True

        KDUpage3()

        pageDisplayed = 3

    End Sub

    Private Sub DisplayVulosPage4()
        DisplayReset()
        WhichScreenToShow()
        vulosDisplayed = True
        pageDisplayed = 1
        a1TB.Visible = True
        a1TB.Text = "R"
        a2TB.Visible = True
        a2TB.Text = "BAT"
        a3PB.Visible = True
        a4TB.Visible = True
        If storedWaveform = " " Then
            a4TB.Text = "- - -"
        Else
            a4TB.Text = storedWaveform
        End If

        a5TB.Visible = True
        ShowSquelch()

        a6TB.Visible = True
        ShowCrypto()

        a7TB.Visible = True
        page4TB1.Location = New Point(b1TB.Location)

        page4TB1.Font = New Font("Arial Narrow", 26, FontStyle.Bold)
        page4TB1.TextAlign = HorizontalAlignment.Center
        page4TB1.ForeColor = Color.Black
        page4TB1.BorderStyle = BorderStyle.None
        page4TB1.BackColor = Color.MediumSeaGreen
        Me.Controls.Add(page4TB1)
        page4TB1.Width = 50
        page4TB1.Text = storedNumber
        page4TB1.BringToFront()
        page4TB1.Visible = True

        page4TB2.Location = New Point(page4TB1.Location.X + page4TB1.Width, page4TB1.Location.Y)

        page4TB2.Font = New Font("Arial Narrow", 26, FontStyle.Bold)
        page4TB2.TextAlign = HorizontalAlignment.Left
        page4TB2.ForeColor = Color.Black
        page4TB2.BorderStyle = BorderStyle.None
        page4TB2.BackColor = Color.MediumSeaGreen
        Me.Controls.Add(page4TB2)
        page4TB2.Width = 200
        page4TB2.Text = storedName
        page4TB2.BringToFront()
        page4TB2.Visible = True
        

        b6PB.Visible = False
        b7PB.Visible = False


        KDUpage4()

        pageDisplayed = 4
    End Sub

    Private Sub PostFail()  'method used to display a failed boot up procedure

        If screenReady = True Then 'does not allow the button press to make changes to the display until startup is complete


            postFailDisplayed = True
            vulosDisplayed = False

            DisplayReset()
            a7TB.Visible = False
            a6TB.Visible = False
            a5TB.Visible = False
            a4TB.Visible = False
            a3PB.Visible = False
            a2TB.Visible = False
            a1TB.Visible = False
            b6PB.Visible = False
            b7PB.Visible = False
            b1TB.Visible = True
            b1TB.Text = "* *     POST FAILED     * *"
            b1TB.Width = 250
            b2TB.Text = ""
            b2TB.Visible = False
            c1TB.Text = "RUN SELF TEST"
            c1TB.Width = 250
            c1TB.Visible = True
            c3TB.Visible = False
            c4TB.Visible = False
            c5TB.Visible = False
            c7TB.Visible = False
            d6TB.Visible = False
            d7TB.Visible = False
            d4TB.Visible = False
            d3TB.Visible = False
            d1TB.Visible = True
            d1TB.Text = "PRESS CLR/ENT TO EXIT"
            d1TB.Width = 250

        End If
    End Sub

    Private Sub ScrollTextDown()

        If d1TB.Text <> "MEMORY TEST" Then
            b1TB.Text = c1TB.Text
            b1TB.Width = c1TB.Width

            c1TB.Text = d1TB.Text
            c1TB.Width = d1TB.Width
            scrollingDown = d1TB.Text
        End If



        Select Case scrollingDown
            Case "OPTIONAL TESTS"
                d1TB.Text = "WIDEBAND TESTS"
                d1TB.Width = 148
                b7PB.BackgroundImage = My.Resources.ScrollBar4
            Case "WIDEBAND TESTS"
                d1TB.Text = "LCD TEST"
                d1TB.Width = 85
                b7PB.BackgroundImage = My.Resources.scrollbar5
            Case "LCD TEST"
                d1TB.Text = "SW VALIDATION"
                d1TB.Width = 130
                b7PB.BackgroundImage = My.Resources.scrollbar6
            Case "SW VALIDATION"
                d1TB.Text = "KEYPAD TEST"
                d1TB.Width = 115
                b7PB.BackgroundImage = My.Resources.scrollbar7
            Case "KEYPAD TEST"
                d1TB.Text = "MEMORY TEST"
                d1TB.Width = 125
                b7PB.BackgroundImage = My.Resources.ScrollBar8

        End Select
    End Sub

    Private Sub scrollTextUp()

        If b1TB.Text <> "BERT" Then 'stops scrolling when it reaches the top
            d1TB.Text = c1TB.Text
            d1TB.Width = c1TB.Width

            c1TB.Text = b1TB.Text
            c1TB.Width = b1TB.Width
            scrollingUp = b1TB.Text
        End If



        Select Case scrollingUp
            Case "SELF TEST"
                b1TB.Text = "BERT"
                b1TB.Width = 46
                b7PB.BackgroundImage = My.Resources.ScrollBar1
            Case "OPTIONAL TESTS"
                b1TB.Text = "SELF TEST"
                b1TB.Width = 90
                b7PB.BackgroundImage = My.Resources.scrollbar2
            Case "WIDEBAND TESTS"
                b1TB.Text = "OPTIONAL TESTS"
                b1TB.Width = 142
                b7PB.BackgroundImage = My.Resources.scrollbar3
            Case "LCD TEST"
                b1TB.Text = "WIDEBAND TESTS"
                b1TB.Width = 148
                b7PB.BackgroundImage = My.Resources.ScrollBar4
            Case "SW VALIDATION"
                b1TB.Text = "LCD TEST"
                b1TB.Width = 85
                b7PB.BackgroundImage = My.Resources.scrollbar5



        End Select
    End Sub


    'ENTER button

    Public Sub btnEnt_Click(sender As Object, e As EventArgs) Handles btnEnt.Click
        If ButtonBypass() = True Then
            If ml3 = "zeroize alert" Then
            Else
                Exit Sub
            End If
        End If

        If ml3 = "zeroize alert" Then
            If knobIndex = 1 Or knobIndex = 2 Then
                DisplayVulosPage1()
            ElseIf knobIndex = 3 Then
                DisplayLoadPage1()
            End If
            ml3 = ""
            Exit Sub
        End If

        'start ZEROIZE menu selections
        Dim isZeroMenuUsed As Boolean = CheckZeroizeMenu()
        If isZeroMenuUsed = True Then
            Exit Sub
        End If

        If ml3 = "erasing plans successful" Then
            MainZeroizeMenu()
            Exit Sub
        End If

        If ml3 = "erase mission plans" Then
            If c1TB.Text = "YES" Then
                EraseMissionPlanInProgress()
            Else
                MainZeroizeMenu()
            End If
            Exit Sub
        End If

        If ml3 = "confirm zeroize generic" Then
            If c1TB.Text = "NO" Then
                MainZeroizeMenu()
            Else
                ZeroizeInProgress()
            End If
            Exit Sub
        End If

        If ml3 = "zeroize haipe" Then
            ConfirmZeroGeneric(ml3)
            Exit Sub
        End If

        If ml3 = "confirm zero" Or ml3 = "zeroize gps" Then
            If c1TB.Text = "NO" Then
                MainZeroizeMenu()
            Else
                ZeroizeInProgress()
            End If
            Exit Sub
        End If

        If ml3 = "zeroize tek page" Then
            ConfirmZero()
            Exit Sub
        End If

        If ml3 = "selective zeroize crypto mode" Then
            tempCryptoMode = c1TB.Text
            If tempKeyType = "TEK" And (tempCryptoMode = "ZEROIZE VOICE TEK" Or tempCryptoMode = "KG84" Or tempCryptoMode = "ANDVT" Or tempCryptoMode = "VINSON" Or tempCryptoMode = "FASCINATOR" Or tempCryptoMode = "AES") Then
                ZeroizeTekPage()

            End If

            Exit Sub
        End If

        If ml3 = "select zeroize key type" Then
            tempKeyType = c1TB.Text
            If tempKeyType = "TEK" Then
                SelectiveZeroizeCryptoMode()
            ElseIf tempKeyType = "WOD" Then
                ZeroizeSWOD()
            ElseIf tempKeyType = "TSK" Then
                ZeroizeTSK()
            ElseIf tempKeyType = "TRKEK" Then
                ZeroizeTRKEK()
            End If

            Exit Sub
        End If

        If ml3 = "select waveform to zeroize" Then
            tempWaveform = c1TB.Text
            SelectZeroizeKeyType(tempWaveform)
            Exit Sub
        End If


        If ml3 = "factory defaults restored" Then
            RestartingRadio()
            Exit Sub
        End If

        If ml3 = "restore defaults yes no" Then
            If c1TB.Text = "NO" Then
                RadioMaintenance()
            Else
                RestoringDefaults()
            End If
            Exit Sub
        End If

        If ml3 = "reset factory defaults" Then
            RestoreDefaultsYesNo()
            Exit Sub
        End If

        If ml3 = "hub has been reset" Then
            RadioMaintenance()
            Exit Sub
        End If

        If ml3 = "reset hub capacity confirm" Then
            If c1TB.Text = "NO" Then
                RadioMaintenance()
            Else
                HubHasBeenReset()
            End If
            Exit Sub
        End If

        If ml3 = "reset hub capacity" Then
            ResetHubCapacityConfirm()
            Exit Sub
        End If

        If ml3 = "maintenance password" Or ml3 = "zeroize waveform" Then
            tempMaintPswd = ip1.Text + ip2.Text + ip3.Text + ip4.Text + ip5.Text + ip6.Text + ip7.Text + ip8.Text + ip9.Text + ip10.Text + ip11.Text + ip12.Text
            tempMaintPswd = tempMaintPswd.Trim("*")
            If newMaintPswd = "" Then
                If tempMaintPswd <> defaultMaintPswd Then
                    If ml3 = "zeroize waveform" Then
                        ZeroizeWaveform()
                    Else
                        MaintenancePassword()
                    End If
                    Exit Sub
                ElseIf tempMaintPswd = defaultMaintPswd Then
                    'goto highlighted page
                    If ml3 = "zeroize waveform" Then
                        SelectWaveformToZeroize()
                    ElseIf storedMaintSelection = "RESET HUB CAPACITY" Then
                        ResetHubCapacity()
                    ElseIf storedMaintSelection = "RESET FACTORY DEFAULT" Then
                        ResetFactoryDefaults()
                    End If
                    Exit Sub
                End If
            ElseIf newMaintPswd <> "" Then
                If tempMaintPswd <> newMaintPswd Then
                    If ml3 = "zeroize waveform" Then
                        ZeroizeWaveform()
                    Else
                        MaintenancePassword()
                    End If
                    Exit Sub
                ElseIf tempMaintPswd = newMaintPswd Then
                    'goto highlighted page
                    If ml3 = "zeroize waveform" Then
                        SelectWaveformToZeroize()
                    ElseIf storedMaintSelection = "RESET HUB CAPACITY" Then
                        ResetHubCapacity()
                    ElseIf storedMaintSelection = "RESET FACTORY DEFAULT" Then
                        ResetFactoryDefaults()
                    End If
                    Exit Sub
                End If
            End If
            Exit Sub
        End If

        If ml3 = "radio maintenance" Then
            If b1TB.BackColor = Color.Black Then
                storedMaintSelection = "RESET HUB CAPACITY"
            Else
                storedMaintSelection = "RESET FACTORY DEFAULT"
            End If
            MaintenancePassword()
            Exit Sub
        End If

        If ml3 = "leap seconds" Then
            RadioSystemClock()
            Exit Sub
        End If

        If ml3 = "time format" Then
            LeapSeconds()
            Exit Sub
        End If

        If ml3 = "date format" Then
            TimeFormat()
            Exit Sub
        End If

        If ml3 = "utc offset message" Then
            EnterUTCoffset()
            Exit Sub
        End If

        If ml3 = "system clock current time" Or ml3 = "system current date" Then
            RadioSystemClock()
            Exit Sub
        End If


        If ml3 = "vpod config" Then
            RadioGeneralConfig()
            Exit Sub
        End If

        If ml3 = "local sa report" Then
            SAconfig()
            Exit Sub
        End If

        If ml3 = "sa port" Then
            LocalSaReport()
            Exit Sub
        End If

        If ml3 = "sa custom ip" Then
            SaPort()
            Exit Sub
        End If

        If ml3 = "sa destination" Then
            If c1TB.Text = "CUSTOM IP" Then
                SaDestCustomIP()
            Else
                SaPort()
            End If
            Exit Sub
        End If

        If ml3 = "cot expiration" Then
            SaDestination()
            Exit Sub
        End If

        If ml3 = "sa packet type" Then
            If c1TB.Text = "HARRIS" Then
                SaDestination()
            Else
                CotExpiration()
            End If
            Exit Sub
        End If

        If ml3 = "sa receive" Then
            If c1TB.Text = "ON" Then
                SaPacketType()
            Else
                SAconfig()
            End If
            Exit Sub
        End If

        If ml3 = "sa vulos range" Then
            SaReceive()
            Exit Sub
        End If

        If ml3 = "vulos sa config" Then
            storedTransmitMode = c1TB.Text
            If storedTransmitMode = "AUTO" Then
                SaVulosRange()
            Else
                SaReceive()
            End If
            Exit Sub
        End If

        If ml3 = "report format" Then
            SAconfig()
            Exit Sub
        End If

        If ml3 = "sa name" Then
            ReportFormat()
            Exit Sub
        End If


        If ml3 = "combat id" Then
            SAconfig()
            Exit Sub
        End If


        If ml3 = "port parity" Then
            PPPstopBits()
            Exit Sub
        End If

        If ml3 = "port character length" Then
            PPPparity()
            Exit Sub
        End If

        If ml3 = "port baudrate" Then
            PPPcharacterLength()
            Exit Sub
        End If

        If ml3 = "port j3" Then
            PPPbaudRate()
            Exit Sub
        End If

        If ml3 = "red ethernet port" Then
            NetworkConfigMenu()
            Exit Sub
        End If

        If ml3 = "ike timeout" Then
            MaxRetransAttempts()
            Exit Sub
        End If

        If ml3 = "red ping reply" Or ml3 = "max retrans attempts" Or ml3 = "tcp accel config" Then
            IPV4ConfigSubmenu()
            Exit Sub
        End If

        If ml3 = "message processing" Then
            If c1TB.Text = "ENABLE" Then
                RedPingReply()
            Else
                IPV4ConfigSubmenu()
            End If
            Exit Sub
        End If

        If ml3 = "datum programming" Or ml3 = "port stop bits" Then
            RadioGeneralConfig()
            Exit Sub
        End If

        If ml3 = "grid digits" Then
            DatumProgramming()
            Exit Sub
        End If

        If ml3 = "angular units" Then
            If storedPositionFormat = "MGRS-OLD" Or storedPositionFormat = "MGRS-NEW" Or storedPositionFormat = "UTM/UPS" Then
                GridDigits()
            Else
                DatumProgramming()
            End If
            Exit Sub
        End If

        If ml3 = "elevation basis" Then
            AngularUnits()
            Exit Sub
        End If

        If ml3 = "linear units" Then
            ElevationBasis()
            Exit Sub
        End If

        If ml3 = "position format" Then
            storedPositionFormat = c1TB.Text
            LinearUnits()
            Exit Sub
        End If

        If ml3 = "gps sleep cycle" Then
            storedGPSsleepEnable = c1TB.Text
            If storedGPSsleepEnable = "ENABLED" Then
                GPSsleepTime()
            Else
                PositionFormat()
            End If
            Exit Sub
        End If

        If ml3 = "gps type" Then
            storedGPStype = c1TB.Text
            If storedGPStype <> "DISABLED" Then
                GPSsleepCycle()
            Else
                RadioGeneralConfig()
            End If
            Exit Sub
        End If

        If ml3 = "external keyline" Then
            RadioGeneralConfig()
            Exit Sub
        End If

        If ml3 = "kdu not connected" Then
            PPPconfig()
            Exit Sub
        End If

        If ml3 = "antenna lna" Then
            ExternalDeviceMenu()
            Exit Sub
        End If

        If ml3 = "port config gateway address" Then
            PPPconfig()
            Exit Sub
        End If

        If ml3 = "port config subnet mask" Then
            PortConfigGatewayAddress()
            Exit Sub
        End If

        If ml3 = "port config peer ip address" Then
            PortConfigSubnetMask()
            Exit Sub
        End If

        If ml3 = "port config ip address" Then
            PortConfigPeerIPaddress()
            Exit Sub
        End If

        If ml3 = "ppp flow control" Then
            PPPconfig()
            Exit Sub
        End If

        If ml3 = "ppp stop bits" Then
            PPPflowControl()
            Exit Sub
        End If

        If ml3 = "ppp parity" Then
            PPPstopBits()
            Exit Sub
        End If

        If ml3 = "ppp character length" Then
            PPPparity()
            Exit Sub
        End If

        If ml3 = "ppp baud rate" Then
            PPPcharacterLength()
            Exit Sub
        End If


        If ml3 = "async flow control" Then
            DataPortConfigSubMenu()
            Exit Sub
        End If

        If ml3 = "async stop bits" Then
            AsyncFlowControl()
            Exit Sub
        End If

        If ml3 = "async parity" Then
            AsyncStopBits()
            Exit Sub
        End If

        If ml3 = "async character length" Then
            AsyncParity()
            Exit Sub
        End If

        If ml3 = "async config" Then
            AsyncCharacterLength()
            Exit Sub
        End If

        If ml3 = "sync edge" Then
            DataPortConfigSubMenu()
            Exit Sub
        End If

        If ml3 = "sync config" Then
            SyncEdge()
            Exit Sub
        End If

        If ml3 = "polarity config" Then
            DataPortConfigSubMenu()
            Exit Sub
        End If

        If ml3 = "async config" Then
            DataPortConfigSubMenu()
            Exit Sub
        End If

        If ml3 = "sync config" Then
            DataPortConfigSubMenu()
            Exit Sub
        End If


        If ml3 = "general hw config" Then
            Polarityconfig()
            Exit Sub
        End If

        If ml3 = "voice key up timeout time" Or ml3 = "retransmit config" Or ml3 = "ct override" Then
            RadioGeneralConfig()
            Exit Sub
        End If

        If ml3 = "voice key up timeout" Then
            If c1TB.Text = "DISABLED" Then
                RadioGeneralConfig()
            Else
                VoiceKeyUpTimeoutTime()
            End If
            Exit Sub
        End If

        If ml3 = "audio sidetone" Then
            VoiceKeyUpTimeout()
            Exit Sub
        End If


        If ml3 = "pswd change successful" Then
            RadioConfig()
            Exit Sub
        End If

        If ml3 = "confirm maint pswd" Then
            ValidateNewPassword()
            Exit Sub
        End If

        If ml3 = "password warnings" Then
            ChangeMaintPswd()
            Exit Sub
        End If

        If ml3 = "change maint pswd" Then
            ValidateMaintPswd()
            Exit Sub
        End If

        If ml3 = "enter maint pswd" Or ml3 = "reenter maint pswd" Then
            ValidatePswdEntry()
            Exit Sub
        End If


        If ml2 = "radio config" And (ml3 = "" Or ml3 = "radio system clock" Or ml3 = "sa config menu" Or ml3 = "ipv4 configuration menu" Or ml3 = "network configuration menu" Or ml3 = "external device menu" Or ml3 = "general config" Or ml3 = "ppp config" Or ml3 = "data port config" Or ml3 = "net config") Then
            Dim myHighlight As String = ""
            checkHighlights(myHighlight)


            'start of RADIO CONFIG main menu
            If myHighlight = "CHANGE MAINT PSWD" Then
                EnterMaintPswd()
            ElseIf myHighlight = "GENERAL CONFIG" Then
                RadioGeneralConfig()
            ElseIf myHighlight = "SYSTEM CLOCK" Then
                RadioSystemClock()
            ElseIf myHighlight = "MAINTENANCE" Then
                RadioMaintenance()
                'end of main menu selections

                'start Maintenance Sub Menu
            ElseIf myHighlight = "RESET HUB CAPACITY" Then
                ResetHubCapacity()
            ElseIf myHighlight = "RESET FACTORY DEFAULTS" Then
                ResetFactoryDefaults()

                'start of GENERAL CONFIG submenu
            ElseIf myHighlight = "AUDIO CONFIG" Then
                AudioConfig()
            ElseIf myHighlight = "AUTOSAVE CONFIG" Then
                AutoSaveConfig()
            ElseIf myHighlight = "CT OVERRIDE CONFIG" Then
                CtOverride()
            ElseIf myHighlight = "DATA PORT CONFIG" And a1TB.Text = "PGM-RADIO-GENERAL" Then
                DataPortConfigSubMenu()
            ElseIf myHighlight = "EXTERNAL DEVICE" Then
                ExternalDeviceMenu()
            ElseIf myHighlight = "EXTERNAL KEYLINE" Then
                ExternalKeylineMenu()
            ElseIf myHighlight = "GPS CONFIG" Then
                GpsType()
            ElseIf myHighlight = "NETWORK CONFIG" Then
                NetworkConfigMenu()
            ElseIf myHighlight = "PORT CONFIG" Then
                PortJ3()
            ElseIf myHighlight = "RETRANSMIT CONFIG" Then
                RetransmitConfig()
            ElseIf myHighlight = "SA CONFIG" Then
                SAconfig()
            ElseIf myHighlight = "VPOD CONFIG" Then
                VPODconfig()
                'end of GENERAL CONFIG submenu

                'start of DATA PORT CONFIG submenu
            ElseIf myHighlight = "GENERAL HW CONFIG" Then
                GeneralHWconfig()
            ElseIf myHighlight = "SYNC CONFIG" Then
                SyncConfig()
            ElseIf myHighlight = "ASYNC CONFIG" Then
                AsyncConfig()
            ElseIf myHighlight = "PPP CONFIG" Then
                PPPconfig()
                'end DATA PORT CONFIG

                'start of PPP CONFIG submenu
            ElseIf myHighlight = "DATA PORT CONFIG" Then
                PPPbaudRate()
            ElseIf myHighlight = "NET CONFIG" Then
                PortConfigIPaddress()
                'end PPP CONFIG

                'start EXTERNAL DEVICE submenu
            ElseIf myHighlight = "ANTENNA" Then
                ExternalAntenna()
            ElseIf myHighlight = "REMOTE KDU" Then
                RemoteKDUnotConnected()
                'end EXTERNAL DEVICE
                'start NETWORK CONFIG MENU submenu
            ElseIf myHighlight = "IPV4 CONFIG" Then
                IPV4ConfigSubmenu()
            ElseIf myHighlight = "RED ICMP CONFIG" Then
                MessageProcessing()
            ElseIf myHighlight = "IKE CONFIG" Then
                IkeTimeout()
            ElseIf myHighlight = "TCP ACCEL CONFIG" Then
                TcpAccelConfig()
            ElseIf myHighlight = "RED ETHERNET CONFIG" Then
                RedEthernetPort()
                'start SA CONFIG menu
            ElseIf myHighlight = "COMBAT ID" Then
                CombatID()
            ElseIf myHighlight = "SA NAME" Then
                SAName()
            ElseIf myHighlight = "VULOS SA CONFIG" Then
                VULOSsaConfig()


                'start SYSTEM CLOCK menu
            ElseIf myHighlight = "CURRENT TIME" Then
                SystemClockCurrentTime()
            ElseIf myHighlight = "CURRENT DATE" Then
                SystemCurrentDate()
            ElseIf myHighlight = "UTC OFFSET" Then
                UtcOffsetMessage()
            ElseIf myHighlight = "SYSTEM CLOCK CONFIG" Then
                SystemClockConfig()

            End If





            Exit Sub
        End If


        If ml3 = "hold time duration" Then
            temp = nameBox2.Text + nameBox3.Text

            CheckValidityOfHangHoldTime(temp)

            If temp = "1" Then
                nameBox2.Text = "0"
                nameBox3.Text = "1"
                SetBackBlack(nameBox2)
                SetBackGreen(nameBox3)
            Else
                storedHoldTimeDuration = temp
                MyGlobalData.GlobalSavedItemsDataGridView.Item(7, 0).Value = storedHoldTimeDuration
                MyGlobalData.UpdateDB()

                ScanConfig()
            End If
            Exit Sub
        End If


        If ml3 = "enable hold time" Then
            storedEnableHoldTime = c1TB.Text
            MyGlobalData.GlobalSavedItemsDataGridView.Item(6, 0).Value = storedEnableHoldTime
            MyGlobalData.UpdateDB()

            If storedEnableHoldTime = "DISABLE" Then
                ScanConfig()
            ElseIf storedEnableHoldTime = "ENABLE" Then
                HoldTimeDuration()
            End If

            Exit Sub
        End If



        If ml3 = "hang time duration" Then
            temp = nameBox2.Text + nameBox3.Text

            CheckValidityOfHangHoldTime(temp)

            If temp = "1" Then
                nameBox2.Text = "0"
                nameBox3.Text = "1"
                SetBackBlack(nameBox2)
                SetBackGreen(nameBox3)
            Else
                storedHangTime = temp
                MyGlobalData.GlobalSavedItemsDataGridView.Item(5, 0).Value = storedHangTime
                MyGlobalData.UpdateDB()

                EnableHoldTime()
            End If
            Exit Sub
        End If


        If ml3 = "view scan list" Then
            ScanList()
            Exit Sub
        End If


        If ml3 = "priority rx preset" Then
            storedPriorityRx = c1TB.Text
            MyGlobalData.GlobalSavedItemsDataGridView.Item(4, 0).Value = storedPriorityRx
            MyGlobalData.UpdateDB()

            ScanConfig()
            Exit Sub
        End If



        If ml3 = "rx priority scanning" Then
            storedRxPriorityScanning = c1TB.Text
            MyGlobalData.GlobalSavedItemsDataGridView.Item(3, 0).Value = storedRxPriorityScanning
            MyGlobalData.UpdateDB()

            If storedRxPriorityScanning = "DISABLE" Then
                ScanConfig()
            ElseIf storedRxPriorityScanning = "ENABLE" Then
                PriorityRxPreset()
            End If

            Exit Sub
        End If


        If ml3 = "priority tx preset" Then
            storedPriorityTx = c1TB.Text
            MyGlobalData.GlobalSavedItemsDataGridView.Item(2, 0).Value = storedPriorityTx
            MyGlobalData.UpdateDB()

            EnableRxPriorityScanning()
            Exit Sub
        End If


        If ml3 = "confirm remove" Then

            If c1TB.Text = "NO" Then
                RemovePresetFromScanList()
                Exit Sub
            End If

            Dim scanRow As Integer
            Dim scanSearchString As String

            scanSearchString = Microsoft.VisualBasic.Left(removalCandidate, 5)
            scanSearchString = Microsoft.VisualBasic.Right(scanSearchString, 2)
            scanRow = CInt(scanSearchString) - 1

            DataSetForm.PRCtrainerDataGridView.Item(50, scanRow).Value = ""
            DataSetForm.UpdateDB()

            RemovePresetFromScanList()

            Exit Sub
        End If


        If ml3 = "remove preset" Then

            If b1TB.BackColor = Color.Black Then
                removalCandidate = b1TB.Text
            ElseIf c1TB.BackColor = Color.Black Then
                removalCandidate = c1TB.Text
            ElseIf d1TB.BackColor = Color.Black Then
                removalCandidate = d1TB.Text
            End If
            ConfirmRemove()
            Exit Sub
        End If


        If ml3 = "add another preset" Then
            If c1TB.Text = "YES" Then
                AddScanList()
            Else
                ScanList()
            End If

            Exit Sub
        End If


        If ml3 = "add scan list" Then

            If DataSetForm.PRCtrainerDataGridView.Item(50, presetRowNum).Value.Equals("YES") = True Then
                'display PRESET ALREADY EXISTS
                PresetAlreadyExists()
                Exit Sub
            End If

            storedInScanList = "YES"
            DataSetForm.PRCtrainerDataGridView.Item(50, presetRowNum).Value = storedInScanList
            DataSetForm.UpdateDB()
            AddAnotherPreset()
            Exit Sub
        End If


        If ml3 = "scan list" Then
            If b1TB.BackColor = Color.Black Then
                AddScanList()
            ElseIf c1TB.BackColor = Color.Black Then
                ViewScanList()
            ElseIf d1TB.BackColor = Color.Black Then
                RemovePresetFromScanList()
            End If
            Exit Sub
        End If


        If ml3 = "scan config" Or ml3 = "scan list empty" Or ml3 = "view scan list" Then

            GetMyGlobalData()

            Dim myText As String = ""

            GetMyHighlitedText(myText)

            If myText = "SCAN LIST" Then
                ScanList()
            ElseIf myText = "PRIORITY" Then
                PriorityTxPreset()
            ElseIf myText = "HANG/HOLD TIME" Then
                HangHoldTime()
            ElseIf myText = "EXIT" Then
                SystemPresetsMenu()
            End If

            Exit Sub
        End If


        If ml3 = "scan preset waveform" Then
            ScanConfig()
            Exit Sub
        End If


        If ml3 = "scan preset enable" Then

            storedScanEnable = c1TB.Text
            MyGlobalData.GlobalSavedItemsDataGridView.Item(1, 0).Value = storedScanEnable
            'DataSetForm.PRCtrainerDataGridView.Item(49, presetRowNum).Value = storedScanEnable
            MyGlobalData.UpdateDB()

            If c1TB.Text = "YES" Then
                ScanPresetWaveform()
            Else
                ml3 = ""
                HelperUpdate()
                SystemPresetsMenu()
            End If
            Exit Sub
        End If


        If ml3 = "beacon tx power" Then
            storedBeaconTxPower = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(48, presetRowNum).Value = storedBeaconTxPower
            DataSetForm.UpdateDB()
            ml3 = ""
            VulosConfigSubMenus()
            HelperUpdate()
            Exit Sub
        End If


        If ml3 = "beacon off duration" Then
            storedBeaconOffDuration = nameBox2.Text + nameBox3.Text
            DataSetForm.PRCtrainerDataGridView.Item(47, presetRowNum).Value = storedBeaconOffDuration
            DataSetForm.UpdateDB()
            BeaconTxPower()
            Exit Sub
        End If


        If ml3 = "beacon tx duration" Then
            storedBeaconTxDuration = nameBox2.Text + nameBox3.Text
            DataSetForm.PRCtrainerDataGridView.Item(46, presetRowNum).Value = storedBeaconTxDuration
            DataSetForm.UpdateDB()
            BeaconOffDuration()
            Exit Sub
        End If


        If ml3 = "beacon modulation" Then
            If c1TB.Text = "AM" Then
                storedOption = "200"
                DataSetForm.PRCtrainerDataGridView.Item(11, presetRowNum).Value = storedOption

            ElseIf c1TB.Text = "FM" Then
                storedOption = "201"
                DataSetForm.PRCtrainerDataGridView.Item(11, presetRowNum).Value = storedOption

            End If
            storedBeaconMod = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(45, presetRowNum).Value = storedBeaconMod
            DataSetForm.UpdateDB()
            BeaconTxDuration()
            Exit Sub
        End If



        If ml3 = "beacon frequency" Then

            Try
                testFreq = CDbl(nameBox1.Text + nameBox2.Text + nameBox3.Text + nameBox4.Text + nameBox5.Text + nameBox6.Text + nameBox7.Text + nameBox8.Text)

            Catch ex As Exception

            End Try

            If testFreq >= 90.0 And testFreq <= 511.995 Then
                'goto next page and store new freq
                storedBeaconFreq = nameBox1.Text + nameBox2.Text + nameBox3.Text + nameBox4.Text + nameBox5.Text + nameBox6.Text + nameBox7.Text + nameBox8.Text
                DataSetForm.PRCtrainerDataGridView.Item(44, presetRowNum).Value = storedBeaconFreq
                DataSetForm.UpdateDB()
                BeaconModulation()
            Else
                BreakApartFrequency(storedBeaconFreq)
                c1TB.Location = New Point(b1TB.Location.X + 48, c1TB.Location.Y)
                ArrangeNameboxes()
            End If

            Exit Sub
        End If


        If ml3 = "vinson compatibility" Then
            storedVinsonCompatibility = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(43, presetRowNum).Value = storedVinsonCompatibility
            DataSetForm.UpdateDB()
            ml3 = ""
            VulosConfigSubMenus()
            HelperUpdate()
            Exit Sub
        End If



        If ml3 = "cdcss rx code" Then
            storedCDCSSrxCode = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(42, presetRowNum).Value = storedCDCSSrxCode
            DataSetForm.UpdateDB()
            ChannelBusyPriority()
            Exit Sub
        End If

        If ml3 = "cdcss tx code" Then
            storedCDCSStxCode = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(41, presetRowNum).Value = storedCDCSStxCode
            DataSetForm.UpdateDB()
            RXsquelchTypeCDCSS()
            Exit Sub
        End If


        If ml3 = "channel busy priority" Then
            ml3 = " "
            DataSetForm.PRCtrainerDataGridView.Item(40, presetRowNum).Value = storedChannelBusyPriority
            DataSetForm.UpdateDB()
            If ml1 = "" And ml2 = "" And senderName = "squelch button pushed" Then
                ml3 = ""
                DisplayVulosPage1()
                Exit Sub
            End If
            SystemPresetsMenu()
            Exit Sub
        End If

        If ml3 = "fm tx tone" Then

            If (storedSquelch = "OFF" Or storedSquelch = "NOISE") And storedMod = "AM" Then
                SquelchLevel()
            ElseIf ml1 = "" And ml2 = "" And senderName = "squelch button pushed" Then
                ml3 = ""
                DisplayVulosPage1()
                Exit Sub

            Else
                ml3 = " "
                SystemPresetsMenu()
            End If

            Exit Sub
        End If

        If ml3 = "rx squelch type" Or ml3 = "rx squelch type cdcss" Then
            storedRxSquelch = c1TB.Text
            If storedRxSquelch = "CDCSS" Then
                DataSetForm.PRCtrainerDataGridView.Item(36, presetRowNum).Value = storedRxSquelch
                DataSetForm.UpdateDB()
                CDCSSrxTone()
                Exit Sub
            ElseIf storedRxSquelch <> "CTCSS" Then
                ml3 = " "
                DataSetForm.PRCtrainerDataGridView.Item(36, presetRowNum).Value = storedRxSquelch
                DataSetForm.UpdateDB()
                SystemPresetsMenu()
                Exit Sub
            ElseIf storedRxSquelch = "CTCSS" Then
                DataSetForm.PRCtrainerDataGridView.Item(36, presetRowNum).Value = storedRxSquelch
                DataSetForm.UpdateDB()
                CTCSSrxTone()
                Exit Sub
            End If
        End If

        If ml3 = "ctcss rx user entry" Then
            ValidateCTCSSentry(forcedback)
            If forcedback = True Then
                Exit Sub
            End If
            storedCTCSSrxUserEntry = nameBox1.Text + nameBox2.Text + nameBox3.Text + "." + nameBox5.Text
            DataSetForm.PRCtrainerDataGridView.Item(39, presetRowNum).Value = storedCTCSSrx
            DataSetForm.PRCtrainerDataGridView.Item(38, presetRowNum).Value = storedCTCSSrxUserEntry
            DataSetForm.UpdateDB()
            ChannelBusyPriority()
        End If


        If ml3 = "ctcss user entry" Then
            ValidateCTCSSentry(forcedback)
            If forcedback = True Then
                Exit Sub
            End If
            storedCTCSSuserEntry = nameBox1.Text + nameBox2.Text + nameBox3.Text + "." + nameBox5.Text
            DataSetForm.PRCtrainerDataGridView.Item(35, presetRowNum).Value = storedCTCSS
            DataSetForm.PRCtrainerDataGridView.Item(37, presetRowNum).Value = storedCTCSSuserEntry
            DataSetForm.UpdateDB()
            RXsquelchType()
        End If

        If ml3 = "ctcss rx tone" Then
            If c1TB.Text = " USER" Then
                CTCSSrxUserEntry()
            Else
                DataSetForm.PRCtrainerDataGridView.Item(39, presetRowNum).Value = storedCTCSSrx
                DataSetForm.UpdateDB()
                ChannelBusyPriority()
            End If
        End If


        If ml3 = "ctcss tx tone" Then
            If c1TB.Text = " USER" Then
                CTCSSuserEntry()
            Else
                DataSetForm.PRCtrainerDataGridView.Item(35, presetRowNum).Value = storedCTCSS
                DataSetForm.UpdateDB()
                RXsquelchType()
            End If
        End If

        If ml3 = "squelch level" Then
            DataSetForm.PRCtrainerDataGridView.Item(34, presetRowNum).Value = manualSquelchSetting
            DataSetForm.UpdateDB()

            If (storedSquelch = "NOISE" Or storedSquelch = "OFF") And storedMod = "AM" Then
                ml3 = " "
                If ml1 = "" And ml2 = "" And senderName = "squelch button pushed" Then
                    ml3 = ""
                    DisplayVulosPage1()
                    Exit Sub
                End If
                SystemPresetsMenu()
            ElseIf storedSquelch = "CTCSS" And storedMod = "FM" Then
                CTCSStxTone()
            End If
            Exit Sub
        End If

        If ml3 = "analog squelch type" Then
            storedSquelch = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value = storedSquelch
            DataSetForm.UpdateDB()



            If storedSquelch = "NOISE" And storedMod = "AM" Then
                FMtransmitTone()
            ElseIf storedSquelch = "OFF" And storedMod = "FM" Then
                FMtransmitTone()
            ElseIf storedSquelch = "OFF" And storedMod = "AM" Then
                FMtransmitTone()
            ElseIf storedSquelch = "CTCSS" And storedMod = "FM" Then
                CTCSStxTone()
            ElseIf storedSquelch = "NOISE" And storedMod = "MS181" Then
                CTCSStxTone()
            ElseIf storedSquelch = "NOISE" And storedMod = "FM" Then
                FMtransmitTone()
            ElseIf storedSquelch = "TONE" Then
                ml3 = " "
                If ml1 = "" And ml2 = "" And senderName = "squelch button pushed" Then
                    ml3 = ""
                    DisplayVulosPage1()
                    Exit Sub
                End If
                SystemPresetsMenu()
            ElseIf storedSquelch = "CDCSS" Then
                CDCSStxCode()
            End If



            Exit Sub
        End If

        If ml3 = "user power level" Then
            storedTXpowerDown = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(33, presetRowNum).Value = storedTXpowerDown
            DataSetForm.UpdateDB()

            AnalogSquelchType()
            Exit Sub
        End If

        If ml3 = "power level" Then
            storedTXpower = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(32, presetRowNum).Value = storedTXpower
            DataSetForm.UpdateDB()

            If storedTXpower = "USER" Then
                UserPowerLevel()
            Else
                AnalogSquelchType()
            End If
            Exit Sub
        End If

        If ml3 = "interleaver" Then
            storedInterleave = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(15, presetRowNum).Value = storedInterleave
            DataSetForm.UpdateDB()

            TransmitPower()
            Exit Sub
        End If

        If ml3 = "option code" Then
            storedOption = b2TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(11, presetRowNum).Value = storedOption
            DataSetForm.PRCtrainerDataGridView.Item(12, presetRowNum).Value = storedBW
            DataSetForm.PRCtrainerDataGridView.Item(31, presetRowNum).Value = storedOptMod
            DataSetForm.PRCtrainerDataGridView.Item(13, presetRowNum).Value = storedBPS
            DataSetForm.PRCtrainerDataGridView.Item(16, presetRowNum).Value = storedFWDerror
            DataSetForm.UpdateDB()

            If storedOptMod = "CPM" And storedFWDerror = "ON" Then
                Interleaver()
            Else
                TransmitPower()
            End If
            Exit Sub

        End If

        If ml3 = "fm deviation" Then
            storedDeviation = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(30, presetRowNum).Value = storedDeviation
            DataSetForm.UpdateDB()

            TransmitPower()
            Exit Sub
        End If

        If ml3 = "modulation type" Then
            storedMod = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(4, presetRowNum).Value = storedMod
            DataSetForm.UpdateDB()

            If storedMod = "FM" Or storedMod = "FSK" Then
                FMdeviation()
            ElseIf storedMod = "MS181" Then
                OptionCode()
            ElseIf storedMod = "AM" Then
                TransmitPower()
            End If

            If storedMod <> "MS181" Then
                storedOption = " "
                DataSetForm.PRCtrainerDataGridView.Item(11, presetRowNum).Value = storedOption
                DataSetForm.UpdateDB()
            End If
            Exit Sub

        End If

        If ml3 = "lpc codebook" Then
            storedCodebook = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(29, presetRowNum).Value = storedCodebook
            DataSetForm.UpdateDB()


            ModulationType()
            Exit Sub
        End If

        If ml3 = "voice mode select" Then
            storedVoiceMode = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(14, presetRowNum).Value = storedVoiceMode
            DataSetForm.UpdateDB()
            LPCcodebook()

            Exit Sub
        End If

        If ml3 = "key source" Then
            storedKeySource = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(28, presetRowNum).Value = storedKeySource
            DataSetForm.UpdateDB()

            VoiceSelections()

            Exit Sub
        End If



        If ml3 = "data mode select" Then
            storedDataMode = c1TB.Text

            DataSetForm.PRCtrainerDataGridView.Item(21, presetRowNum).Value = storedDataMode
            DataSetForm.UpdateDB()

            If storedTraffic = "VOICE AND DATA" Then
                Keysource()

            ElseIf storedTraffic = "VOICE" Then
                VoiceSelections()
            ElseIf storedTraffic = "DATA" Then
                ModulationType()
            End If

            Exit Sub
        End If

        If ml3 = "traffic mode" Then
            DataSetForm.PRCtrainerDataGridView.Item(3, presetRowNum).Value = storedTraffic
            DataSetForm.UpdateDB()

            If storedTraffic = "VOICE AND DATA" Or storedTraffic = "DATA" Then
                DataSelections()
            Else
                VoiceSelections()
            End If

            Exit Sub
        End If

        If ml3 = "satcom ch num" Then
            If c1TB.Text <> "USER" Then
                CryptoModePage()
            ElseIf c1TB.Text = "USER" Then
                VulosRxFreq()
            End If
            Exit Sub
        End If

        If ml3 = "voice autoswitch" Then
            storedAutoswitch = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(27, presetRowNum).Value = storedAutoswitch
            DataSetForm.UpdateDB()

            TrafficMode()
            Exit Sub
        End If

        If ml3 = "rx fade priority" Then
            storedRXfade = c1TB.Text
            DataSetForm.PRCtrainerDataGridView.Item(26, presetRowNum).Value = storedRXfade
            DataSetForm.UpdateDB()

            VoiceAutoswitch()
            Exit Sub
        End If

        If ml3 = "check submode" Then

            If b1TB.Text = "TRAINING FRAMES" Then
                storedTrainingFrames = c1TB.Text
                DataSetForm.PRCtrainerDataGridView.Item(25, presetRowNum).Value = storedTrainingFrames
                DataSetForm.UpdateDB()

                RxFadePriority()
                Exit Sub
            End If

            If b1TB.Text = "FASCINATOR MODE" Then
                storedFascinatorMode = c1TB.Text
                DataSetForm.PRCtrainerDataGridView.Item(22, presetRowNum).Value = storedFascinatorMode
                DataSetForm.UpdateDB()

            End If
            If b1TB.Text = "KG84 SYNC MODE" Then
                storedKG84Mode = c1TB.Text
                DataSetForm.PRCtrainerDataGridView.Item(24, presetRowNum).Value = storedKG84Mode
                DataSetForm.UpdateDB()
            End If

            If b1TB.Text = "AES MODE" Then
                storedAESmode = c1TB.Text
                DataSetForm.PRCtrainerDataGridView.Item(23, presetRowNum).Value = storedAESmode
                DataSetForm.UpdateDB()
            End If

            TrafficMode()
            Exit Sub
        End If

        If ml3 = "encryption key" Then
            SaveCryptoKey()
            CheckForSubmodeAfterEncryptionKey()
        End If

        If ml3 = "crypto mode" Then
            SaveCryptoMode()
            If c1TB.Text = "NONE" Then
                TrafficMode()
                Exit Sub
            End If
            EncryptionKey()
            Exit Sub
        End If

        If ml3 = "enter tx freq" Then
            SaveTxFreq()
            CryptoModePage()
            Exit Sub
        End If

        If ml3 = "vulos rx only" Then
            If c1TB.Text = "NO" Then
                SelectTXfrequencySource()
            ElseIf c1TB.Text = "YES" Then
                CryptoModePage()
            End If
            Exit Sub
        End If

        If ml3 = "tx freq source" Then
            transmitChoice = c1TB.Text
            EnterTxFreq()
            Exit Sub
        End If

        If ml3 = "preset type" Then

            If c1TB.Text = "SATCOM" Then
                SatcomChannelNumber()
            ElseIf c1TB.Text = "LOS" Then
                DataSetForm.PRCtrainerDataGridView.Item(2, presetRowNum).Value = "LOS"
                VulosRxFreq()
            End If
            Exit Sub
        End If

        If ml3 = "vulos rx freq" Then
            Try
                testFreq = CDbl(nameBox1.Text + nameBox2.Text + nameBox3.Text + nameBox4.Text + nameBox5.Text + nameBox6.Text + nameBox7.Text + nameBox8.Text)

            Catch ex As Exception

            End Try

            If testFreq >= 30.0 And testFreq <= 511.995 Then
                'goto next page and store new freq
                PresetRxFreqDBupdate()
                RxOnly()
            Else
                BreakApartFrequency(storedRXfreq)

            End If

            Exit Sub
        End If

        '''''''''''''''''''''''''''determines if the preset number input is valid, changes the color of the preset label, and converts to the new preset number

        'checks if the VULOS 1 page is active
        If vulosDisplayed = True And ml1 = "" Then
            ''verifies the text is highlighted
            If b1TB.BackColor = Color.Black Then
                presetRowNum = CInt(b1TB.Text) - 1
                'add a dash to the end of the string
                'b1TB.Text = b1TB.Text + dash

                'change colors back to normal
                b1TB.BackColor = Color.MediumSeaGreen
                b1TB.ForeColor = Color.Black

                RecallPreset()


            End If
            Exit Sub

        End If

        '''''''''''''''''''''''end determines


        '''''''''''''''''''''''''''determines if the preset number input is valid, changes the color of the preset label, and converts to the new preset number

        'checks if ml3= system preset number
        If ml3 = "system preset number" Then
            ''verifies the text is highlighted
            If c1TB.BackColor = Color.Black Then
                presetRowNum = CInt(c1TB.Text) - 1
                'add a dash to the end of the string
                'c1TB.Text = c1TB.Text + dash

                'change colors back to normal
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black

                RecallPreset()
                SystemPresetNumber()

            ElseIf c1TB.BackColor <> Color.Black Then
                PresetDescription()


            End If
            Exit Sub

        End If

        '''''''''''''''''''''''end determines

        ''''''''''load preset type
        If ml3 = "general config" Then
            PresetNameDBupdate()
            PresetType()
            Exit Sub
        End If




        If senderName = "scanPage" Then
            If c1TB.Text = "ENABLE" Then
                ScanChangingPreset()
                Exit Sub
            Else
                Exit Sub
            End If
        End If

        If ml1 = "lock keypad" Then 'locks the keypad
        Else
            If ml2 = "keypad test" And ml3 = "press any key" Then 'allows for keypad test
                c1TB.Text = "ENTER"
                PositionAndHighlight()
            ElseIf ml1 = "view key info" And ml2 <> "" And ml3 = "" Then 'added for viewing key information
                ml3 = c1TB.Text.ToLower
                checkArray()
                direction = "forward"
            ElseIf ml1 = "mode" And ml2 = "beacon" And ml3 = "" Then
                ml3 = "start"
                checkArray()
            ElseIf ml1 = "mode" And ml2 = "otar transmit" And ml3 = "YES" Then
                OtarTransmitting()
            ElseIf ml1 = "mode" And ml2 = "otar transmit" And ml3 = "transmitting" Then
                'do nothing
            ElseIf ml1 = "mode" And ml2 = "otar transmit" And (ml3 = "NO" Or ml3 = "aborted") Then
                ml4 = ""
                ml3 = ""
                ml2 = ""
                ml1 = "mode"
                ModeMainPage()
            ElseIf ml1 = "mode" And ml2 = "otar receive" And ml3 = "select" Then
                If ml4 = "" Then
                    OtarCryptoModeScreen()
                ElseIf ml4 = "crypto mode" Then
                    OtarAssignmentScreen()
                ElseIf ml4 = "otar assignment" Then
                    OtarStoreScreen()
                ElseIf ml4 = "successful" Then
                    ml4 = ""
                    ml3 = ""
                    ml2 = ""
                    ml1 = "mode"
                    ModeMainPage()
                End If

            ElseIf ml1 = "mode" And ml2 = "otar receive" And (ml3 = "receive mk" Or ml3 = "receive ak") And ml4 = "" Then
                OTARinProgress()
            ElseIf ml1 = "mode" And ml2 = "otar receive" And (ml3 = "receive mk" Or ml3 = "receive ak") And ml4 = "complete" Then
                WaveformSelect()
            ElseIf ml1 = "mode" And ml2 = "otar receive" And (ml3 = "receive mk" Or ml3 = "receive ak") And ml4 = "receiving" Then
                'disables button
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "receive clone" And c1TB.Text = "TRANSMIT CLONE" Then
                ml3 = c1TB.Text.ToLower
                TxCloneSelectFile()
            ElseIf ml1 = "mode" And ml2 = "clone mode" And ml3 = "all plan files" And ml4 = "" Then
                TxConfiguringClone()
            ElseIf ml1 = "mode" And ml2 = "clone mode" And (ml3 = "receive clone" Or ml3 = "all plan files") And ml4 = "complete" Then
                ml3 = ""
                ml2 = ""
                checkArray()


                'PROGRAM MENU SELECTION
            ElseIf ml1 = "program" And ml2 = "system presets" Then
                If b1TB.BackColor = Color.Black And ml3 = "" Then
                    SystemPresetNumber()
                ElseIf c1TB.BackColor = Color.Black And ml3 = "" Then
                    ResetSystemPreset()
                ElseIf d1TB.BackColor = Color.Black And ml3 = "" Then
                    SystemScanConfig()
                ElseIf ml3 = "preset description" Then
                    CheckValidityOfNewDesc()
                    UpdateDescInDB()
                    PresetWaveform()
                ElseIf ml3 = "system preset name" Then
                    CheckValidityOfNewName()
                    UpdateNameInDB()
                ElseIf ml3 = "preset waveform" Then
                    storedWaveform = c1TB.Text
                    DataSetForm.PRCtrainerDataGridView.Item(8, presetRowNum).Value = storedWaveform
                    DataSetForm.UpdateDB()
                    ProgrammingMenu()
                ElseIf ml3 = "programming menu" Then
                    GetHighlitedText()
                    SelectCases()


                End If

            ElseIf ml1 = "program" And ml2 = "vulos config" Then
                If b1TB.BackColor = Color.Black Then
                    BeaconFrequency()
                ElseIf c1TB.BackColor = Color.Black Then
                    VinsonCompatibilityScreen()
                End If





                'END PROGRAM MENU



            Else
                checkArray()
                direction = "forward"

            End If
        End If
        HelperUpdate()

    End Sub 'ENTER BUTTON

    Private Sub checkForHighlitedText()

        If menuDepth = 0 And ml1 = "" Then
            If b1TB.BackColor = Color.Black Then
                ml1 = b1TB.Text.ToLower
            ElseIf c1TB.BackColor = Color.Black Then
                ml1 = c1TB.Text.ToLower
            ElseIf d1TB.BackColor = Color.Black Then
                ml1 = d1TB.Text.ToLower
            End If
        ElseIf menuDepth = 1 Then
            If b1TB.BackColor = Color.Black Then
                ml2 = b1TB.Text.ToLower
            ElseIf c1TB.BackColor = Color.Black Then
                ml2 = c1TB.Text.ToLower
            ElseIf d1TB.BackColor = Color.Black Then
                ml2 = d1TB.Text.ToLower
            End If
        ElseIf ml1 = "gps options" And menuDepth = 2 Then
            If b1TB.BackColor = Color.Black Then
                ml3 = b1TB.Text.ToLower
            ElseIf c1TB.BackColor = Color.Black Then
                ml3 = c1TB.Text.ToLower
            ElseIf d1TB.BackColor = Color.Black Then
                ml3 = d1TB.Text.ToLower
            End If
        ElseIf ml1 = "network options" And ml2 = "interfaces" Then
            ml2 = ""
        ElseIf ml1 = "network options" And ml2 = "keychain verification" Then
            ml2 = ""
        ElseIf ml1 = "radio options" And ml2 = "remote kdu" Then
            ml2 = ""
            DisplayOptionsMenu()
        ElseIf ml1 = "system information" And ml2 = "versions" And ml3 = "" Then
            ml2 = c1TB.Text.ToLower
        ElseIf ml1 = "system information" And ml2 <> "versions" And ml3 <> "" Then
            ml2 = "versions"
            ml3 = ""
            ml4 = ""
        ElseIf ml1 = "mode" And ml2 = "beacon" Then
            ml4 = c1TB.Text.ToLower




        End If

        If ml1 = "fill" And ml2 = "fill device type" And ml3 <> "classifications" Then
            ml3 = c1TB.Text.ToLower
        End If

        If menuDepth = 2 And ml2 = "on" Then
            If c1TB.Text = "SYNC/ASYNC" Then
                SyncAsyncPage()
            ElseIf c1TB.Text = "PPP" Then
                PPPpage()
            Else
                DataModeSyncAsyncPPP()
            End If

        End If



        If menuDepth = 3 Then
            ml4 = c1TB.Text.ToLower
        End If

        If ml2 = "bert" And menuDepth = 4 Then
            ml5 = "sync pattern"
            ml6 = c1TB.Text.ToLower
        End If

        If ml2 = "self test" And menuDepth = 4 Then
            If c1TB.BackColor = Color.Black Then
                ml5 = c1TB.Text.ToLower
            End If
        End If

        If ml2 = "self test" And menuDepth = 5 Then
            If c1TB.BackColor = Color.Black Then
                ml6 = c1TB.Text.ToLower
            End If
        End If

        If ml2 = "optional tests" And menuDepth = 2 Then
            If c1TB.BackColor = Color.Black Then
                ml3 = c1TB.Text.ToLower
            End If
        End If

        If ml2 = "optional tests" And menuDepth = 4 Then
            If c1TB.BackColor = Color.Black Then
                ml5 = c1TB.Text.ToLower
            End If
        End If

        If ml2 = "wideband tests" Then
            If ml6 <> "duration" Then
                If c1TB.BackColor = Color.Black Then
                    If menuDepth = 2 Then
                        ml3 = c1TB.Text.ToLower
                    ElseIf menuDepth = 3 Then
                        ml4 = c1TB.Text.ToLower
                    ElseIf menuDepth = 4 Then
                        ml5 = c1TB.Text.ToLower
                    ElseIf menuDepth = 5 Then
                        ml5 = c1TB.Text.ToLower
                    End If
                End If
            End If
        End If


        If ml4 = "rx" Then
            If ml5 <> "input frequency" And menuDepth = 5 Then
                ml5 = "input frequency"
            ElseIf ml5 = "input frequency" And ml6 = "" Then
                ml6 = "duration"
            ElseIf ml6 = "duration" Then
                ml6 = "y/n"
            ElseIf ml6 = "y/n" Then
                If c1TB.Text = "NO" Then
                    TestOptions()
                ElseIf c1TB.Text = "YES" Then
                    ml6 = "test in progress"
                End If
            End If

        ElseIf ml4 = "tx" Then
            If ml5 <> "input frequency" And menuDepth = 5 Then
                ml5 = "input frequency"
            ElseIf ml5 = "input frequency" And ml6 = "" Then
                ml6 = "db from full"
            ElseIf ml6 = "db from full" Then
                ml6 = "y/n"
            ElseIf ml6 = "y/n" Then
                If c1TB.Text = "NO" Then
                    TestOptions()
                ElseIf c1TB.Text = "YES" Then
                    ml6 = "test in progress"
                End If
            End If

        ElseIf ml3 = "rx sensitivity" Then
            If ml4 <> "input frequency" And menuDepth = 4 Then
                ml4 = "input frequency"
                ml5 = "duration"
            ElseIf ml5 = "duration" Then
                ml5 = "y/n"
            ElseIf ml5 = "no" Then
                TestOptions()
            ElseIf ml5 = "yes" Then
                If ml6 <> "test complete" Then
                    ml6 = "test in progress"
                End If

            End If


        ElseIf ml3 = "tx power" Then
            If ml4 <> "input frequency" And menuDepth = 4 Then
                ml4 = "input frequency"
            ElseIf ml4 = "input frequency" And ml5 <> "tx pwr db from full" And ml5 <> "duration" And ml5 <> "y/n" And ml5 <> "no" And ml5 <> "yes" Then
                ml5 = "tx pwr db from full"
            ElseIf ml5 = "tx pwr db from full" Then
                ml5 = "duration"
            ElseIf ml5 = "duration" Then
                ml5 = "y/n"
            ElseIf ml5 = "no" Then
                TestOptions()
            ElseIf ml5 = "yes" Then
                If ml6 <> "test complete" Then
                    ml6 = "test in progress"
                End If
            End If

        ElseIf ml3 = "tx frequency" Then
            If ml4 <> "input frequency" And menuDepth = 4 Then
                ml4 = "input frequency"
            ElseIf ml4 = "input frequency" And ml5 <> "tx pwr db from full" And ml5 <> "duration" And ml5 <> "y/n" And ml5 <> "no" And ml5 <> "yes" Then
                ml5 = "duration"
            ElseIf ml5 = "duration" Then
                ml5 = "y/n"
            ElseIf ml5 = "no" Then
                TestOptions()
            ElseIf ml5 = "yes" Then
                If ml6 <> "test complete" Then
                    ml6 = "test in progress"
                End If
            End If

        ElseIf ml3 = "full duplex" Then
            If ml4 <> "input rx frequency" And menuDepth = 4 Then
                ml4 = "input rx frequency"
            ElseIf ml4 = "input rx frequency" And ml5 <> "input tx frequency" And ml5 <> "tx pwr db from full" And ml5 <> "duration" And ml5 <> "y/n" And ml5 <> "no" And ml5 <> "yes" Then
                ml5 = "input tx frequency"
            ElseIf ml5 = "input tx frequency" Then
                ml5 = "tx pwr db from full"
            ElseIf ml5 = "tx pwr db from full" Then
                ml5 = "duration"
            ElseIf ml5 = "duration" Then
                ml5 = "y/n"
            ElseIf ml5 = "no" Then
                TestOptions()
            ElseIf ml5 = "yes" Then
                If ml6 <> "test complete" Then
                    ml6 = "test in progress"
                End If
            End If


        End If

        LCDchecks()

        If ml3 = "maintenance password" Then
            If ml5 = "y/n" Then
                ml6 = c1TB.Text.ToLower
            End If
        End If

        If ml2 = "memory test" And c1TB.Text = "WILL RESET RADIO" Then
            ml3 = "will reset radio"
        End If

        If ml2 = "memory test" And ml3 = "will reset radio" And menuDepth = 4 Then
            ml5 = "memory test in progress"
        End If
        HelperUpdate()

    End Sub 'determines how to select text when the enter button is pressed

    Private Sub checkArray()
        checkForHighlitedText()
        Select Case ml1
            Case "program"
                Select Case ml2
                    Case "radio config"
                        RadioConfig()
                    Case "system presets"
                        SystemPresetsMenu()
                    Case "anw2b config"
                    Case "anw2 config"
                    Case "vulos config"
                        VulosConfigSubMenus()
                    Case "havequick config"
                    Case "sincgars config"

                End Select
            Case "mode"
                If ml2 = "" Then
                    ModeMainPage()
                End If
                Select Case ml2
                    Case "beacon"
                        If ml3 = "" Then
                            BeaconPage()
                        End If
                        Select Case ml3
                            Case "start"
                                EnteringBeaconMode()
                                BeaconStartup()
                            Case "running"
                                Select Case ml4
                                    Case "yes"
                                        ExitingBeaconMode()
                                        BeaconShutdown()
                                End Select
                        End Select
                    Case "clone mode"
                        If ml3 = "" Then
                            ClonePage()
                        ElseIf ml3 = "receive clone" Then
                            If ml4 = "receive clone" Then
                                ReceiveClone()
                            End If

                        End If


                    Case "scan"
                        ScanPage()
                    Case "otar receive"
                        OtarRxPage()
                    Case "otar transmit"
                        OtarTxPage()
                End Select





            Case "fill"
                If ml2 = "" Then
                    FillMenu()
                End If
                Select Case ml2
                    Case "otar tek"
                        InitiateFill()
                    Case "waveform"
                        FillWaveform()
                    Case "fill device type"
                        If ml4 = "" Then
                            FillDeviceType()
                        End If
                        Select Case ml3
                            Case "dtd (cyz-10)/kik-20"
                                fillDevice = "dtd (cyz-10)/kik-20"
                                FillPortType()
                            Case "skl (pyq-10)"
                                fillDevice = "skl (pyq-10)"
                                FillPortType()
                            Case "koi-18"
                                fillDevice = "koi-18"
                                FillPortType()
                            Case "kyx-15"
                                fillDevice = "kyx-15"
                                FillPortType()
                            Case "kyk-13"
                                fillDevice = "kyk-13"
                                FillPortType()
                            Case "mx-18290"
                                fillDevice = "mx-18290"
                                FillPortType()
                            Case "ds-101"
                                fillPort = "ds-101"
                                InitiateFill()
                            Case "ds-102"
                                fillPort = "ds-102"
                                InitiateFill()
                            Case "mode 1 (eset)"
                                fillPort = "mode 1 (eset)"
                                InitiateFill()
                            Case "mode 2/3 (loadset)"
                                fillPort = "mode 2/3 (loadset)"
                                InitiateFill()
                            Case "vinson"
                                FillKeyType()
                            Case "andvt"
                                FillKeyType()
                            Case "kg84"
                                FillKeyType()
                            Case "satellite"
                                FillKeyType()
                            Case "aes"
                                FillKeyType()
                            Case "ds-101"
                                FillKeyType()
                            Case "fascinator"
                                FillKeyType()
                            Case "key number:"
                                keyType = b2TB.Text
                                If keyType = "TEK" Then
                                    KeyNumber()
                                Else
                                    FillClassification()
                                End If
                            Case "classifications"
                                FillClassification()
                            Case "initiate fill"
                                Select Case ml4
                                    Case "fill in progress"
                                        fillProgressScreen()

                                End Select
                        End Select
                End Select
            Case "lock keypad"
                LockKeypad()
            Case "view key info"
                If ml3 = "" Then
                    If ml2 = "" Then
                        ViewKeyInfo()
                    ElseIf ml2 <> "" Then
                        SelectType()
                    End If
                End If
                Select Case ml3
                    Case "tek"
                        TekPage()
                    Case "lockout"
                        LockoutPage()
                    Case "tsk"
                        TskPage()
                    Case "hopset"
                        HopsetPage()
                    Case "kek"
                        KekPage()
                    Case "trkek"
                        TrkekPage()
                    Case "wod"
                        WodPage()
                    Case "vector"
                        VectorPage()

                End Select
            Case "tx power options"
                If ml2 = "" Then
                    TxPowerOptions()
                End If
                Select Case ml2
                    Case "user"
                        If ml3 = "" Then
                            TxPowerUser()
                            ml2 = "user"
                            Exit Select
                        End If

                        Select Case ml3
                            Case "end"
                                ml4 = ""
                                ml3 = ""
                                ml2 = ""
                                TxPowerOptions()
                        End Select
                    Case "high"
                        TxPowerHigh()
                        ml2 = ""
                        Exit Select
                    Case "medium"
                        TxPowerMedium()
                        ml2 = ""
                        Exit Select
                    Case "low"
                        TxPowerLow()
                        ml2 = ""
                        Exit Select
                End Select
            Case "system information"
                If ml2 = "" Then
                    SystemInfoPage()
                End If
                Select Case ml2
                    Case "versions"
                        VersionSelect()
                    Case "hardware"
                        VersionHardware()
                        ml3 = "hardware"
                        Exit Select
                    Case "system"
                        VersionSystem()
                        ml3 = "system"
                        Exit Select
                    Case "software"
                        VersionSoftware()
                        ml3 = "software"
                        Exit Select
                    Case "infosec"
                        VersionInfosec()
                        ml3 = "infosec"
                        Exit Select
                    Case "serial number"
                        SerialNumber()
                        ml2 = ""
                        Exit Select
                    Case "part number"
                        PartNumber()
                        ml2 = ""
                        Exit Select
                    Case "sw options"
                        SWoptions()
                        ml2 = ""
                        Exit Select
                    Case "elapsed time"
                        ElapsedTime()
                        ml2 = "radio uptime"
                        Exit Select
                    Case "radio uptime"
                        RadioUptime()
                        ml2 = ""
                        Exit Select
                    Case "tcxo tuning"
                        TcxoTuning()
                        ml2 = ""
                        Exit Select
                End Select
            Case "sa options"
                If ml2 = "" Then
                    SAtransmit()
                End If
                Select Case ml2
                    Case "enable"
                        DisplayOptionsMenu()
                    Case "disable"
                        DisplayOptionsMenu()
                End Select
            Case "radio options"
                If ml2 = "" Then
                    RadioOptionsMenu()
                End If
                Select Case ml2
                    Case "on"
                        PresetAutosave()
                        ml2 = "preset autosave"
                        Exit Select
                    Case "off"
                        PresetAutosave()
                        ml2 = "preset autosave"
                        Exit Select
                    Case "preset autosave"
                        RfFaultsPersist()
                        ml2 = "rf faults persist"
                        Exit Select
                    Case "rf faults persist"
                        PAfailsafe()
                        ml2 = "pa failsafe"
                        Exit Select
                    Case "pa failsafe"
                        If c1TB.Text = "DISABLED" Then
                            PaFailsafeWarning()
                            ml2 = "pa warning"
                        ElseIf c1TB.Text = "ENABLED" Then
                            RemoteKDU()
                            ml2 = "remote kdu"
                        End If
                        Exit Select
                    Case "pa warning"
                        RemoteKDU()
                        ml2 = "remote kdu"
                        Exit Select

                End Select
            Case "radio information"
                RadioInfoTopMenu()
                ml3 = ""
                Select Case ml2
                    Case "system clock"
                        SystemClock()
                        ml2 = "utc offset"
                        Exit Select
                    Case "utc offset"
                        UTCoffset()
                        ml2 = ""
                        Exit Select
                    Case "battery information"
                        BatteryVoltage()
                        ml2 = "hub capacity"
                        Exit Select
                    Case "hub capacity"
                        HubCapacity()
                        ml2 = ""
                        Exit Select
                    Case "network status"
                        NetworkStatus()
                        If pppState = "ONLINE" Then
                            ml2 = "ppp ip address" 'if online, allows access to next screen
                        Else
                            ml2 = "" 'if offline, throws user back to RadioInfoTopMenu
                        End If
                        Exit Select
                    Case "ppp ip address"
                        PPPipAddress()
                        ml2 = "peer address"
                        Exit Select
                    Case "peer address"
                        PeerIpAddress()
                        ml2 = ""
                        Exit Select

                End Select
            Case "mission plan"
                If ml2 = "" Then
                    MissionPlanMain()
                End If
                Select Case ml2
                    Case "activate mission plan"
                        MissionPlanFilePage1()
                        ml2 = "mission plan page 2"
                        Exit Select
                    Case "mission plan page 2"
                        MissionPlanFilePage2()
                        ml2 = "mission plan page 3"
                        Exit Select
                    Case "mission plan page 3"
                        MissionPlanFilePage3()
                        ml2 = "activate plan"
                        Exit Select
                    Case "activate plan"
                        ActivateMissionPlan()
                        ml2 = "mission plan loading"
                        Exit Select
                    Case "mission plan loading"
                        If c1TB.Text = "YES" Then
                            MissionPlanLoading()
                        ElseIf c1TB.Text = "NO" Then
                            ml2 = ""
                            MissionPlanMain()
                        ElseIf b1TB.Text = "PLAN COMPLETE" Then
                            CheckMissionArray()
                            ml2 = ""
                            MissionPlanMain()
                        End If

                    Case "mission plan history"
                        MissionHistoryDisplay()

                End Select
            Case "data mode"
                DataMode()
                Select Case ml2
                    Case "off"
                        DisplayOptionsMenu()
                    Case "on"
                        DataModeSyncAsyncPPP()
                End Select
            Case "gps options"
                If ml2 = "" Then
                    GPSstatusList()
                End If
                Select Case ml2
                    Case "gps status"
                        If ml3 = "" Then
                            ml3 = "gps status"
                        End If
                        Select Case ml3
                            Case "gps status"
                                GPSstatusPage()
                                ml3 = "gps position"
                                Exit Select
                            Case "gps position"
                                GPSpositionPage()
                                ml3 = "gps heading/velocity"
                                Exit Select
                            Case "gps heading/velocity"
                                GPSheadingPage()
                                ml3 = "gps altitude/epe"
                                Exit Select
                            Case "gps altitude/epe"
                                GPSaltitudePage()
                                ml3 = "gps fom/key stat"
                                Exit Select
                            Case "gps fom/key stat"
                                GPSfomKeyPage()
                                ml3 = "gps sat info"
                                Exit Select
                            Case "gps sat info"
                                GPSsatInfoPage()
                                ml4 = ""
                                ml3 = ""
                                ml2 = ""
                        End Select
                    Case "gps key info"
                        If ml3 = "" Then
                            ml3 = "gps cv status"
                        End If
                        Select Case ml3
                            Case "gps cv status"
                                GPScvStatus()
                                ml3 = "days with keys"
                                Exit Select
                            Case "days with keys"
                                DaysWithKeys()
                                ml4 = ""
                                ml3 = ""
                                ml2 = ""
                        End Select
                    Case "passthru mode"
                        If ml3 = "" Then
                            ml3 = "passthru mode"
                        End If
                        Select Case ml3
                            Case "passthru mode"
                                PassthruMode()
                                ml4 = ""
                                ml3 = ""
                                ml2 = ""
                        End Select


                End Select
            Case "network options"
                If ml2 = "" Then
                    NetworkOptionsBasePageLoad()
                End If
                Select Case ml2
                    Case "send ping"
                        SendPingPage()
                        ml2 = "ping by"
                        Exit Select
                    Case "ping by"
                        If c1TB.Text = "HOST NAME" Then
                            PingByHostName()
                        ElseIf c1TB.Text = "IP ADDRESS" Then
                            PingByIP()
                        End If
                        ml2 = "ping in progress"
                        Exit Select
                    Case "ping in progress"
                        PingInProgress()
                        ml2 = "ping success"
                        Exit Select
                    Case "ping success"
                        ml2 = ""
                        NetworkOptionsBasePageLoad()
                        Exit Select

                    Case "interfaces"
                        InterfacesPage()
                        Exit Select

                    Case "keychain verification"
                        KeychainPage()
                        Exit Select

                End Select
            Case "test options"
                ml1 = "test options"
                If ml2 = "" Then
                    TestOptionsBasePageLoad()
                End If

                Select Case ml2
                    Case "bert"
                        ml1 = "test options"
                        ml2 = "bert"
                        ml3 = "bert mode"
                        BertSubMenu()
                        Select Case ml3
                            Case "bert mode"
                                ml1 = "test options"
                                ml2 = "bert"
                                ml3 = "bert mode"
                                Select Case ml4
                                    Case "transmit"
                                        ml1 = "test options"
                                        ml2 = "bert"
                                        ml3 = "bert mode"
                                        ml4 = "transmit"
                                        BertTransmitSubMenu()
                                        Select Case ml5
                                            Case "sync pattern"
                                                ml1 = "test options"
                                                ml2 = "bert"
                                                ml3 = "bert mode"
                                                ml4 = "transmit"
                                                ml5 = "sync pattern"
                                                CheckSyncNumber()
                                                Select Case ml6
                                                    Case "63"
                                                        ml1 = "test options"
                                                        ml2 = "bert"
                                                        ml3 = "bert mode"
                                                        ml4 = "transmit"
                                                        ml5 = "sync pattern"
                                                        ml6 = "63"

                                                End Select

                                        End Select
                                    Case "receive"
                                        ml1 = "test options"
                                        ml2 = "bert"
                                        ml3 = "bert mode"
                                        ml4 = "receive"
                                        BertReceiveSubMenu()
                                        Select Case ml5
                                            Case "sync pattern"
                                                ml1 = "test options"
                                                ml2 = "bert"
                                                ml3 = "bert mode"
                                                ml4 = "receive"
                                                ml5 = "sync pattern"
                                                CheckSyncNumber()
                                                Select Case ml6
                                                    Case "63"
                                                        ml1 = "test options"
                                                        ml2 = "bert"
                                                        ml3 = "bert mode"
                                                        ml4 = "receive"
                                                        ml5 = "sync pattern"
                                                        ml6 = "63"

                                                End Select

                                        End Select
                                End Select
                        End Select
                    Case "self test"
                        ml1 = "test options"
                        ml2 = "self test"
                        ml3 = "run self test"
                        SelfTestMenu()
                        Select Case ml5
                            Case "no"
                                SelfTestNo()
                            Case "yes"
                                SelfTestYes()
                                Select Case ml6
                                    Case "no"
                                        SelfTestInProgress()
                                    Case "yes"
                                        SelfTestInProgress()
                                    Case "test passed"
                                        TestOptions()
                                End Select
                        End Select
                    Case "optional tests"
                        ml1 = "test options"
                        ml2 = "optional tests"
                        OptionalTestsMenu()
                        Select Case ml3
                            Case "gps"
                                GPStest()
                                Select Case ml4
                                    Case "3 to 8 min"
                                        RunTestYes()
                                        Select Case ml5
                                            Case "yes"
                                                GPStestRunning()
                                            Case "no"
                                                TestOptions()
                                        End Select
                                End Select
                            Case "res flash"
                                RESFlash()
                                Select Case ml4
                                    Case "3 to 8 min"
                                        RunTestYes()
                                        Select Case ml5
                                            Case "yes"
                                                GPStestRunning()
                                            Case "no"
                                                TestOptions()
                                        End Select
                                End Select
                        End Select
                    Case "wideband tests"
                        ml1 = "test options"
                        ml2 = "wideband tests"
                        WidebandTestsMenu()
                        Select Case ml3
                            Case "tx rx"
                                SelectTXorRX()
                                Select Case ml4
                                    Case "tx"
                                        TX()
                                        Select Case ml5
                                            Case "highband"
                                                Highband()
                                                rfPath = "highband"
                                            Case "lowband"
                                                Highband()
                                                rfPath = "lowband"
                                            Case "5000 khz"
                                                SelectTXfrequency()
                                            Case "2500 khz"
                                                SelectTXfrequency()
                                            Case "1250 khz"
                                                SelectTXfrequency()
                                            Case "input frequency"
                                                SelectTXfrequency()
                                                Select Case ml6
                                                    Case "db from full"
                                                        TxPwrDbFromFull()
                                                    Case "y/n"
                                                        RunTestYes()
                                                    Case "test in progress"
                                                        RXtestInProgress()
                                                    Case "test complete"
                                                        TestOptions()
                                                End Select

                                        End Select
                                    Case "rx"
                                        RX()
                                        Select Case ml5
                                            Case "highband"
                                                Highband()
                                                rfPath = "highband"
                                            Case "lowband"
                                                Highband()
                                                rfPath = "lowband"
                                            Case "5000 khz"
                                                SelectTXfrequency()
                                            Case "2500 khz"
                                                SelectTXfrequency()
                                            Case "1250 khz"
                                                SelectTXfrequency()
                                            Case "input frequency"
                                                SelectTXfrequency()
                                                Select Case ml6
                                                    Case "duration"
                                                        TestDuration()
                                                    Case "y/n"
                                                        RunTestYes()
                                                    Case "test in progress"
                                                        RXtestInProgress()
                                                    Case "test complete"
                                                        TestOptions()
                                                End Select
                                        End Select

                                End Select
                            Case "rx sensitivity"
                                RX()
                                Select Case ml4
                                    Case "highband"
                                        SelectTXfrequency()
                                        rfPath = "highband"
                                    Case "lowband"
                                        SelectTXfrequency()
                                        rfPath = "lowband"
                                    Case "input frequency"
                                        SelectTXfrequency()
                                        Select Case ml5
                                            Case "duration"
                                                TestDuration()
                                            Case "y/n"
                                                RunTestYes()
                                            Case "yes"
                                                Select Case ml6
                                                    Case "test in progress"
                                                        RXtestInProgress()
                                                    Case "test complete"
                                                        TestOptions()
                                                End Select
                                        End Select
                                End Select
                            Case "tx power"
                                TX()
                                Select Case ml4
                                    Case "highband"
                                        Highband()
                                        rfPath = "highband"
                                    Case "lowband"
                                        Highband()
                                        rfPath = "lowband"
                                    Case "input frequency"
                                        SelectTXfrequency()
                                        Select Case ml5
                                            Case "5000 khz"
                                                SelectTXfrequency()
                                            Case "2500 khz"
                                                SelectTXfrequency()
                                            Case "1250 khz"
                                                SelectTXfrequency()

                                            Case "tx pwr db from full"
                                                TxPwrDbFromFull()
                                            Case "duration"
                                                TestDuration()
                                            Case "y/n"
                                                RunTestYes()
                                            Case "yes"
                                                Select Case ml6
                                                    Case "test in progress"
                                                        RXtestInProgress()
                                                    Case "test complete"
                                                        TestOptions()
                                                End Select
                                        End Select

                                End Select
                            Case "tx frequency"
                                TX()
                                Select Case ml4
                                    Case "highband"
                                        Highband()
                                        rfPath = "highband"
                                    Case "lowband"
                                        Highband()
                                        rfPath = "lowband"
                                    Case "5000 khz"
                                        SelectTXfrequency()
                                    Case "2500 khz"
                                        SelectTXfrequency()
                                    Case "1250 khz"
                                        SelectTXfrequency()
                                    Case "input frequency"
                                        SelectTXfrequency()
                                        Select Case ml5
                                            Case "duration"
                                                TestDuration()
                                            Case "y/n"
                                                RunTestYes()
                                            Case "yes"
                                                Select Case ml6
                                                    Case "test in progress"
                                                        RXtestInProgress()
                                                    Case "test complete"
                                                        TestOptions()
                                                End Select
                                        End Select

                                End Select
                            Case "full duplex"
                                TX()
                                Select Case ml4
                                    Case "highband"
                                        Highband()
                                        rfPath = "highband"
                                    Case "lowband"
                                        Highband()
                                        rfPath = "lowband"
                                    Case "5000 khz"
                                        SelectTXfrequency()
                                    Case "2500 khz"
                                        SelectTXfrequency()
                                    Case "1250 khz"
                                        SelectTXfrequency()
                                    Case "input rx frequency"
                                        SelectTXfrequency()
                                        Select Case ml5
                                            Case "input tx frequency"
                                                SelectTXfrequency()
                                            Case "tx pwr db from full"
                                                TxPwrDbFromFull()
                                            Case "duration"
                                                TestDuration()
                                            Case "y/n"
                                                RunTestYes()
                                            Case "yes"
                                                Select Case ml6
                                                    Case "test in progress"
                                                        RXtestInProgress()
                                                    Case "test complete"
                                                        TestOptions()
                                                End Select
                                        End Select

                                End Select
                        End Select
                    Case "lcd test"
                        InitiateLCDtest()
                    Case "sw validation"
                        ml3 = "maintenance password"
                        SWValidation()
                    Case "keypad test"
                        KeypadTestMenu()
                    Case "memory test"
                        If menuDepth < 3 Then
                            MemoryTest()
                        End If
                        Select Case ml3
                            Case "will reset radio"
                                If menuDepth < 4 Then
                                    RunMemoryTest()
                                End If
                                Select Case ml5
                                    Case "memory test in progress"
                                        ml6 = c1TB.Text.ToLower
                                        If ml6 = "yes" Then
                                            Reboot()
                                            MemoryTestComplete()
                                        ElseIf ml6 = "no" Or ml6 = "passed" Then
                                            TestOptions()
                                        End If

                                End Select
                        End Select
                End Select
        End Select
    End Sub 'determines which submenu to use for page displays and button pushes, etc

    Private Sub TestOptions() 'loads the higest level options menu

        DisplayReset() 'starts from scratch
        WhichScreenToShow()

        ml1 = "test options"
        ml2 = "" 'change to null on initial page load
        ml3 = ""
        ml4 = ""
        ml5 = ""
        ml6 = ""
        HelperUpdate()

        TestOptionsBasePageLoad()

    End Sub

    Private Sub TestOptionsBasePageLoad()

        'the following builds the base page for the test options display
        DisplayReset()
        showRowA()


        b1TB.Text = "BERT"
        b1TB.Width = 46
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Location = New Point(386, 160)
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.BackgroundImage = My.Resources.ScrollBar1

        c1TB.Text = "SELF TEST"
        c1TB.Width = 90
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(386, 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "OPTIONAL TESTS"
        d1TB.Width = 142
        d1TB.Height = 19
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(386, 196)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertSubMenu() 'initiate the base BERT menu

        DisplayReset()
        showRowA()
        WhichScreenToShow()
        bertMode()


    End Sub

    Private Sub bertMode()
        b1TB.Text = "BERT MODE"
        b1TB.Location = New Point(458, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Location = New Point(410, 200) 'relocates b6PB for use as up/dn arrows
        b6PB.Height = 6
        b6PB.BackgroundImage = My.Resources.UpAndDown
        b7PB.Visible = False

        c1TB.Text = "TRANSMIT"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(465, 178)
        c1TB.Width = c1TB.TextLength * 12
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "TO SCROLL / ENT TO CONT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(434, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False



    End Sub

    Private Sub BertTransmitSubMenu()


        DisplayReset()
        showRowA()
        WhichScreenToShow()

        b1TB.Text = "SYNC PATTERN"
        b1TB.Location = New Point(438, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Location = New Point(410, 200) 'relocates b6PB for use as up/dn arrows
        b6PB.Height = 6
        b6PB.BackgroundImage = My.Resources.UpAndDown
        b7PB.Visible = False

        c1TB.Text = "63"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(498, 178)
        c1TB.Width = c1TB.TextLength * 12
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "TO SCROLL / ENT TO CONT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(434, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertTransmit63SubMenu()
        showRowA()
        WhichScreenToShow()

        b1TB.Text = "TRANSMITTING"
        b1TB.Location = New Point(434, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "SYNC PATTERN:  63"
        c1TB.Location = New Point(410, 178)
        c1TB.Width = c1TB.TextLength * 11
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "PRESS CLR TO EXIT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(442, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertTransmit511SubMenu()
        a1TB.Text = "R"
        a2TB.Text = "BAT"
        a4TB.Text = "VULOS"
        a5TB.Text = "OFF"
        a6TB.Text = "- - - - - - -"
        WhichScreenToShow()

        b1TB.Text = "TRANSMITTING"
        b1TB.Location = New Point(434, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "SYNC PATTERN: 511"
        c1TB.Location = New Point(410, 178)
        c1TB.Width = c1TB.TextLength * 11
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "PRESS CLR TO EXIT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(442, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertTransmit2047SubMenu()
        a1TB.Text = "R"
        a2TB.Text = "BAT"
        a4TB.Text = "VULOS"
        a5TB.Text = "OFF"
        a6TB.Text = "- - - - - - -"
        WhichScreenToShow()

        b1TB.Text = "TRANSMITTING"
        b1TB.Location = New Point(434, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "SYNC PATTERN:2047"
        c1TB.Location = New Point(410, 178)
        c1TB.Width = c1TB.TextLength * 11
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "PRESS CLR TO EXIT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(442, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertTransmit4095SubMenu()
        a1TB.Text = "R"
        a2TB.Text = "BAT"
        a4TB.Text = "VULOS"
        a5TB.Text = "OFF"
        a6TB.Text = "- - - - - - -"
        WhichScreenToShow()

        b1TB.Text = "TRANSMITTING"
        b1TB.Location = New Point(434, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "SYNC PATTERN:4095"
        c1TB.Location = New Point(410, 178)
        c1TB.Width = c1TB.TextLength * 11
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "PRESS CLR TO EXIT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(442, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertTransmitMarkSubMenu()
        a1TB.Text = "R"
        a2TB.Text = "BAT"
        a4TB.Text = "VULOS"
        a5TB.Text = "OFF"
        a6TB.Text = "- - - - - - -"
        WhichScreenToShow()

        b1TB.Text = "TRANSMITTING"
        b1TB.Location = New Point(434, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "SYNC PATTERN:MARK"
        c1TB.Location = New Point(410, 178)
        c1TB.Width = c1TB.TextLength * 11
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "PRESS CLR TO EXIT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(442, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertTransmitSpaceSubMenu()
        a1TB.Text = "R"
        a2TB.Text = "BAT"
        a4TB.Text = "VULOS"
        a5TB.Text = "OFF"
        a6TB.Text = "- - - - - - -"
        WhichScreenToShow()

        b1TB.Text = "TRANSMITTING"
        b1TB.Location = New Point(434, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "SYNC PATTERN:SPACE"
        c1TB.Location = New Point(410, 178)
        c1TB.Width = c1TB.TextLength * 11
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "PRESS CLR TO EXIT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(442, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertTransmit1Colon1SubMenu()
        a1TB.Text = "R"
        a2TB.Text = "BAT"
        a4TB.Text = "VULOS"
        a5TB.Text = "OFF"
        a6TB.Text = "- - - - - - -"
        WhichScreenToShow()

        b1TB.Text = "TRANSMITTING"
        b1TB.Location = New Point(434, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "SYNC PATTERN: 1:1"
        c1TB.Location = New Point(410, 178)
        c1TB.Width = c1TB.TextLength * 11
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "PRESS CLR TO EXIT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(442, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertTransmit0011SubMenu()
        a1TB.Text = "R"
        a2TB.Text = "BAT"
        a4TB.Text = "VULOS"
        a5TB.Text = "OFF"
        a6TB.Text = "- - - - - - -"
        WhichScreenToShow()

        b1TB.Text = "TRANSMITTING"
        b1TB.Location = New Point(434, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "SYNC PATTERN:0011"
        c1TB.Location = New Point(410, 178)
        c1TB.Width = c1TB.TextLength * 11
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "PRESS CLR TO EXIT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(442, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub CheckSyncNumber()

        If ml4 = "transmit" Then
            Select Case ml6
                Case "63"
                    BertTransmit63SubMenu()
                Case "511"
                    BertTransmit511SubMenu()
                Case "2047"
                    BertTransmit2047SubMenu()
                Case "4095"
                    BertTransmit4095SubMenu()
                Case "mark"
                    BertTransmitMarkSubMenu()
                Case "space"
                    BertTransmitSpaceSubMenu()
                Case "1:1"
                    BertTransmit1Colon1SubMenu()
                Case "0011"
                    BertTransmit0011SubMenu()

            End Select
        ElseIf ml4 = "receive" Then
            Select Case ml6
                Case "63"
                    BertReceive63SubMenu()
                Case "511"
                    BertReceive511SubMenu()
                Case "2047"
                    BertReceive2047SubMenu()
                Case "4095"
                    BertReceive4095SubMenu()
                Case "mark"
                    BertReceiveMARKSubMenu()
                Case "space"
                    BertReceiveSPACESubMenu()
                Case "1:1"
                    BertReceive1Colon1SubMenu()
                Case "0011"
                    BertReceive0011SubMenu()

            End Select
        End If

    End Sub


    Private Sub BertReceiveSubMenu()

        DisplayReset()
        showRowA()
        WhichScreenToShow()

        b1TB.Text = "SYNC PATTERN"
        b1TB.Location = New Point(438, 158)
        b1TB.Width = b1TB.TextLength * 12
        b2TB.Visible = False
        b6PB.Location = New Point(410, 200) 'relocates b6PB for use as up/dn arrows
        b6PB.Height = 6
        b6PB.BackgroundImage = My.Resources.UpAndDown
        b7PB.Visible = False

        c1TB.Text = "63"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(498, 178)
        c1TB.Width = c1TB.TextLength * 12
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "TO SCROLL / ENT TO CONT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(434, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Private Sub BertPage1Display()
        DisplayReset()
        showRowA()
        WhichScreenToShow()

        b1TB.Text = "BERT  IDLE"
        b1TB.Width = b1TB.TextLength * 10
        b2TB.Visible = False
        b6PB.Location = New Point((255 / 2) + 382, 198)
        b6PB.Size = New Size(13, 13)


        c1TB.Text = "RX: - - - - - - -"
        c1TB.Width = c1TB.TextLength * 6.5
        c3TB.Text = "ERR: - - - - - - -"
        c3TB.Width = c3TB.TextLength * 7
        c3TB.Location = New Point((255 / 2) + 382, 178)
        'formula for finding the center of the display
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "CLR TO EXIT  /"
        d1TB.Width = d1TB.TextLength * 7
        d1TB.Location = New Point(410, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Text = "FOR MORE"
        d6TB.Width = d6TB.TextLength * 9
        d6TB.Location = New Point(524, 198)
        d7TB.Visible = False

        currentPageNum = 1 'updates the current page number

    End Sub

    Private Sub BertPage2Display()
        showRowA()
        WhichScreenToShow()

        b1TB.Text = "BERT  IDLE"
        b1TB.Width = b1TB.TextLength * 10
        b2TB.Visible = False
        b6PB.Location = New Point((255 / 2) + 382, 198)
        b6PB.Size = New Size(13, 13)


        c1TB.Text = "AVG BER:"
        c1TB.Width = c1TB.TextLength * 11
        c3TB.Text = " - - - - - - - - - -"
        c3TB.Width = c3TB.TextLength * 6
        c3TB.Location = New Point((255 / 2) + 382, 178)
        'formula for finding the center of the display
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False



        d1TB.Text = "CLR TO EXIT  /"
        d1TB.Width = d1TB.TextLength * 7
        d1TB.Location = New Point(410, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Text = "FOR MORE"
        d6TB.Width = d6TB.TextLength * 9
        d6TB.Location = New Point(524, 198)
        d7TB.Visible = False

        currentPageNum = 2 'updates the current page number
    End Sub

    Private Sub BertReceive63SubMenu()
        BertPage1Display()
    End Sub

    Private Sub BertReceive511SubMenu()
        BertPage1Display()
    End Sub

    Private Sub BertReceive2047SubMenu()
        BertPage1Display()
    End Sub

    Private Sub BertReceive4095SubMenu()
        BertPage1Display()
    End Sub

    Private Sub BertReceiveMARKSubMenu()
        BertPage1Display()
    End Sub

    Private Sub BertReceiveSPACESubMenu()
        BertPage1Display()
    End Sub

    Private Sub BertReceive1Colon1SubMenu()
        BertPage1Display()
    End Sub

    Private Sub BertReceive0011SubMenu()
        BertPage1Display()
    End Sub 'BERT procedures


    Private Sub SelfTestMenu()

        DisplayReset()
        ml4 = "y/n"
        showRowA()
        ShowToScrollEntToCont()

        b1TB.Text = "RUN SELF TEST"
        b1TB.Width = 250
        b2TB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "NO"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 26
        c1TB.Location = New Point(((250 / 2) - 13) + 382, 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False



    End Sub

    Private Sub SelfTestNo()
        TestOptions()
    End Sub

    Private Sub SelfTestYes()

        DisplayReset()
        showRowA()
        ShowToScrollEntToCont()

        b1TB.Text = "EMIT RF FOR TEST?"
        b1TB.Width = 250
        b2TB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "NO"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 26
        c1TB.Location = New Point(((250 / 2) - 13) + 382, 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        HelperUpdate()
    End Sub

    Private Sub SelfTestInProgress()

        DisplayReset()

        showRowA()
        b1TB.Text = "*** TEST ***"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "IN PROGRESS"
        c1TB.Width = 250
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        d1TB.Text = "...WAIT..."
        d1TB.Width = 250
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

        timeItTakes = 5

        MyTimerSetup()

        'thread2 = New Thread(AddressOf Me.DelayNextScreen)
        'CheckForIllegalCrossThreadCalls = False
        'thread2.Start()


        HelperUpdate()
    End Sub 'self test procedures



    Private Sub OptionalTestsMenu()

        DisplayReset()
        showRowA()
        b1TB.Text = "OPTIONAL TESTS"
        b1TB.Width = 250
        b2TB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "GPS"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 38
        c1TB.Location = New Point(((250 / 2) - 19) + 382, 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        ShowToScrollEntToCont()

        HelperUpdate()
    End Sub

    Private Sub GPStest()

        DisplayReset()
        showRowA()
        b1TB.Text = "TEST MAY TAKE"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "3 TO 8 MIN"
        c1TB.Width = 250
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        EntToCont()
        HelperUpdate()

    End Sub

    Private Sub RunTestYes()

        DisplayReset()
        showRowA()
        b1TB.Text = "RUN TEST"
        b1TB.Width = 250
        b2TB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "YES"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 38
        c1TB.Location = New Point(((250 / 2) - 19) + 382, 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        ShowToScrollEntToCont()
        HelperUpdate()
    End Sub

    Private Sub GPStestRunning()

        DisplayReset()
        a1TB.Visible = False
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "TEST IN PROGRESS"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "...WAIT..."
        c1TB.Width = 250
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        PressClrToAbort()
        HelperUpdate()
    End Sub

    Private Sub RESFlash()
        GPStest() 'uses GPStest method since it is identical 
    End Sub

    Private Sub WidebandTestsMenu()


        DisplayReset()
        showRowA()
        b1TB.Text = "WIDEBAND TESTS"
        b1TB.Width = 250
        b2TB.Visible = False
        'b6PB.Visible = False   
        b7PB.Visible = False
        c1TB.Text = "TX RX"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 56
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        ShowToScrollEntToCont()
        HelperUpdate()
    End Sub

    Private Sub SelectTXorRX()

        DisplayReset()
        showRowA()
        b1TB.Text = "SELECT TX OR RX"
        b1TB.Width = 250
        b2TB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "TX"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 28
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        ShowToScrollEntToCont()
        HelperUpdate()
    End Sub

    Private Sub TX()

        DisplayReset()
        showRowA()
        b1TB.Text = "SELECT RF PATH"
        b1TB.Width = 250
        b2TB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "HIGHBAND"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 98
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        ShowToScrollEntToCont()
        HelperUpdate()
    End Sub

    Private Sub Highband()

        DisplayReset()
        showRowA()
        b1TB.Text = "BANDWIDTH"
        b1TB.Width = 250
        b2TB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "5000 KHz"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 82
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        ShowToScrollEntToCont()
        HelperUpdate()
    End Sub

    Private Sub SelectTXfrequency()

        

        DisplayReset()
        showRowA()
        If ml4 = "tx" Or ml3 = "tx power" Or ml3 = "tx frequency" Or (ml3 = "full duplex" And ml5 = "input tx frequency") Then
            b1TB.Text = "TX FREQUENCY (MHz)"
        ElseIf ml4 = "rx" Or ml3 = "rx sensitivity" Or (ml3 = "full duplex" And ml4 = "input rx frequency") Then
            b1TB.Text = "RX FREQUENCY (MHz)"
        End If

        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False    'added to keep B6PBfrom overlapping text on KDU 4-02-15
        b7PB.Visible = False
        'create new textboxes for each individual digit
        CreateTextboxes()


        c1TB.Visible = False

        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        If rfPath = "highband" Then
            fLow = "227.500"
            fHigh = "1997.500"
        Else
            fLow = "27.500"
            fHigh = "509.500"
        End If

        tempRecall = fLow 'sets tempRecall to the fLow value so it can be used as a starting point for frequency entries


        combinedString = "ENTER " + fLow + " TO " + fHigh
        d1TB.Text = combinedString
        d1TB.Width = 250
        d1TB.Visible = True
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

        If fLow = "27.500" Then 'in lowband, the input should be no less than 27.500. This forces the digit to show 0 instead of 2
            digit2.Text = "0"
        Else
            digit2.Text = GetChar(updatedFreq, 2)
        End If

        HelperUpdate()
    End Sub

    Private Sub RX()

        DisplayReset()
        showRowA()
        b1TB.Text = "SELECT RF PATH"
        b1TB.Width = 250
        b2TB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "HIGHBAND"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 98
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        ShowToScrollEntToCont()
        HelperUpdate()
    End Sub

    Private Sub WidebandTXRXscrollDown()
        If b1TB.Text = "SELECT RF PATH" Then
            b1TB.Text = "BANDWIDTH"
            c1TB.Text = "5000 KHz"
        ElseIf b1TB.Text = "BANDWIDTH" Then
            b1TB.Text = "TX FREQUENCY (MHz)"
            c1TB.Text = updatedFreq
        ElseIf b1TB.Text = "TX FREQUENCY (MHz)" Then
            b1TB.Text = "TX PWR, dB FROM FULL"
            c1TB.Text = "00"
        ElseIf b1TB.Text = "TX PWR, dB FROM FULL" Then
            b1TB.Text = "RUN TEST"
            c1TB.Text = "YES"
        ElseIf b1TB.Text = "RUN TEST" Then
            b1TB.Text = "SELECT RF PATH"
            c1TB.Text = "HIGHBAND"
        End If
    End Sub

    Private Sub WidebandTXRXscrollUp()
        If b1TB.Text = "SELECT RF PATH" Then
            b1TB.Text = "RUN TEST"
            c1TB.Text = "YES"
        ElseIf b1TB.Text = "RUN TEST" Then
            b1TB.Text = "TX PWR, dB FROM FULL"
            c1TB.Text = "00"
        ElseIf b1TB.Text = "TX PWR, dB FROM FULL" Then
            b1TB.Text = "TX FREQUENCY (MHz)"
            c1TB.Text = updatedFreq
        ElseIf b1TB.Text = "TX FREQUENCY (MHz)" Then
            b1TB.Text = "BANDWIDTH"
            c1TB.Text = "5000 KHz"
        ElseIf b1TB.Text = "BANDWIDTH" Then
            b1TB.Text = "SELECT RF PATH"
            c1TB.Text = "HIGHBAND"
        End If
    End Sub

    Private Sub KeypadTestMenu()

        DisplayReset()
        showRowA()

        b1TB.Text = "PRESS KEY TO TEST"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False

        b6PB.Width = 250
        b7PB.Visible = False

        c1TB.Text = "PRESS ANY KEY"
        c1TB.Width = 150
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d6TB.Visible = False
        d7TB.Visible = False
        d4TB.Visible = False
        d3TB.Visible = False
        d1TB.Visible = True
        d1TB.Text = "CLR TO EXIT"
        d1TB.Width = 250

        ml3 = "press any key"


    End Sub

    Private Sub MemoryTest()

        DisplayReset()
        showRowA()

        b1TB.Text = "RUNNING MEMORY TEST"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False

        b6PB.Width = 250
        b7PB.Visible = False

        c1TB.Text = "WILL RESET RADIO"
        c1TB.Width = 250
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        EntToCont()
        d1TB.Text = "CLR TO EXIT/ENT TO CONT"



    End Sub

    Private Sub RunMemoryTest()

        DisplayReset()
        showRowA()

        b1TB.Text = "RUN MEMORY TEST"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False

        b6PB.Width = 250
        b7PB.Visible = False

        c1TB.Text = "YES"
        PositionAndHighlight()
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        ShowToScrollEntToCont()


        ml4 = "y/n"

    End Sub

    Private Sub MemoryTestInProgress()

        DisplayReset()

        a3PB.Visible = False
        a7TB.Visible = False


        b1TB.Text = " * * MEMORY TEST * * "
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "IN PROGRESS"
        c1TB.Width = 250
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = " . . . WAIT . . . "
        d1TB.Width = 250
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False


    End Sub

    Private Sub Reboot()
        DisplayReset()
        ShutDown()
        Restart()

    End Sub

    Private Sub TestPassed()
        If ml6 <> "" Then


            DisplayReset()
            showRowA()
            ml6 = "test passed"
            b1TB.Text = "*** TEST ***"
            b1TB.Width = 250
            b2TB.Visible = False
            b6PB.Visible = False
            b7PB.Visible = False
            c1TB.Text = "PASSED"
            c1TB.Width = 250
            c3TB.Visible = False
            c4TB.Visible = False
            c5TB.Visible = False
            c7TB.Visible = False
            d1TB.Text = "PRESS CLR / ENT TO EXIT"
            d1TB.Width = 250
            d3TB.Visible = False
            d4TB.Visible = False
            d6TB.Visible = False
            d7TB.Visible = False
            HelperUpdate()

        End If
    End Sub

    Private Sub Testcomplete()

        If ml6 <> "" Then


            DisplayReset()
            showRowA()
            ml6 = "test complete"
            b1TB.Text = "*** TEST ***"
            b1TB.Width = 250
            b2TB.Visible = False
            b6PB.Visible = False
            b7PB.Visible = False
            c1TB.Text = "COMPLETE"
            c1TB.Width = 250
            c3TB.Visible = False
            c4TB.Visible = False
            c5TB.Visible = False
            c7TB.Visible = False
            d1TB.Text = "PRESS CLR / ENT TO EXIT"
            d1TB.Width = 250
            d3TB.Visible = False
            d4TB.Visible = False
            d6TB.Visible = False
            d7TB.Visible = False
            HelperUpdate()

        End If
    End Sub

    Private Sub EntToCont()
        d1TB.Text = "ENT TO CONT / CLR TO EXIT"
        d1TB.Width = 250
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub 'displays often used bottom line

    Public Sub showRowA()
        a1TB.Text = "R"
        a2TB.Text = "BAT"
        a4TB.Text = "VULOS"
        a5TB.Text = "OFF"
        a6TB.Text = "- - - - - - -"
        WhichScreenToShow()
    End Sub 'displays often used top line

    Private Sub PressClrToAbort()
        d1TB.Text = "PRESS CLR TO ABORT"
        d1TB.Width = 250
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

    End Sub

    Private Sub ShowWAIT()
        d1TB.Text = ". . . WAIT . . ."
        SetWidth(d1TB)
        CenterMe(d1TB)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
        b6PB.Visible = False

    End Sub

    Private Sub PressCLRtoStop()
        d1TB.Text = "PRESS CLR TO STOP"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
        b6PB.Visible = False

    End Sub

    Public Sub ShowToScrollEntToCont()
        b6PB.Location = New Point(410, 200) 'relocates b6PB for use as up/dn arrows
        b6PB.Height = 6
        b6PB.Width = 24
        b6PB.BackgroundImage = My.Resources.UpAndDown
        b6PB.Visible = True
        d1TB.Text = "TO SCROLL / ENT TO CONT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(434, 198)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub 'displays often used bottom line

    Public Sub ShowToScrollLeftRight()
        b6PB.Location = New Point(410, 200) 'relocates b6PB for use as left/right arrows
        b6PB.Height = 6
        b6PB.Width = 24
        b6PB.BackgroundImage = My.Resources.LeftAndRight
        b6PB.Visible = True
        d1TB.Text = "TO CHANGE / ENT TO CONT"
        d1TB.Width = d1TB.TextLength * 7.5
        d1TB.Location = New Point(434, 198)
        d1TB.Visible = True
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False
    End Sub

    Public Sub HelperUpdate() 'used as a development guide only. hide when finished
        ml2TB.Text = ml2
        ml1TB.Text = ml1
        ml3TB.Text = ml3
        ml4TB.Text = ml4
        ml5TB.Text = ml5
        ml6TB.Text = ml6

        HelperForm.ml2TB.Text = ml2
        HelperForm.ml1TB.Text = ml1
        HelperForm.ml3TB.Text = ml3
        HelperForm.ml4TB.Text = ml4
        HelperForm.ml5TB.Text = ml5
        HelperForm.ml6TB.Text = ml6

        If ml1 = "" And ml2 = "" And ml3 = "" And ml4 = "" And ml5 = "" And ml6 = "" Then
            menuDepth = 0
        ElseIf ml1 <> "" And ml2 = "" And ml3 = "" And ml4 = "" And ml5 = "" And ml6 = "" Then
            menuDepth = 1
        ElseIf ml1 <> "" And ml2 <> "" And ml3 = "" And ml4 = "" And ml5 = "" And ml6 = "" Then
            menuDepth = 2
        ElseIf ml1 <> "" And ml2 <> "" And ml3 <> "" And ml4 = "" And ml5 = "" And ml6 = "" Then
            menuDepth = 3
        ElseIf ml1 <> "" And ml2 <> "" And ml3 <> "" And ml4 <> "" And ml5 = "" And ml6 = "" Then
            menuDepth = 4
        ElseIf ml1 <> "" And ml2 <> "" And ml3 <> "" And ml4 <> "" And ml5 <> "" And ml6 = "" Then
            menuDepth = 5
        ElseIf ml1 <> "" And ml2 <> "" And ml3 <> "" And ml4 <> "" And ml5 <> "" And ml6 <> "" Then
            menuDepth = 6
        Else
            menuDepth = 99
        End If
        menuTB.Text = menuDepth
        HelperForm.menuLevelTB.Text = menuDepth

    End Sub

    Private Sub NumberUp()
        If digit1.BackColor = Color.Black Then
            If digit1.Text = "0" Then
                digit1.Text = "1"
            ElseIf digit1.Text = "1" Then
                digit1.Text = "2"
            ElseIf digit1.Text = "2" Then
                digit1.Text = "3"
            ElseIf digit1.Text = "3" Then
                digit1.Text = "4"
            ElseIf digit1.Text = "4" Then
                digit1.Text = "5"
            ElseIf digit1.Text = "5" Then
                digit1.Text = "6"
            ElseIf digit1.Text = "6" Then
                digit1.Text = "7"
            ElseIf digit1.Text = "7" Then
                digit1.Text = "8"
            ElseIf digit1.Text = "8" Then
                digit1.Text = "9"
            End If

        ElseIf digit2.BackColor = Color.Black Then
            If digit2.Text = "0" Then
                digit2.Text = "1"
            ElseIf digit2.Text = "1" Then
                digit2.Text = "2"
            ElseIf digit2.Text = "2" Then
                digit2.Text = "3"
            ElseIf digit2.Text = "3" Then
                digit2.Text = "4"
            ElseIf digit2.Text = "4" Then
                digit2.Text = "5"
            ElseIf digit2.Text = "5" Then
                digit2.Text = "6"
            ElseIf digit2.Text = "6" Then
                digit2.Text = "7"
            ElseIf digit2.Text = "7" Then
                digit2.Text = "8"
            ElseIf digit2.Text = "8" Then
                digit2.Text = "9"
            End If

        ElseIf digit3.BackColor = Color.Black Then
            If digit3.Text = "0" Then
                digit3.Text = "1"
            ElseIf digit3.Text = "1" Then
                digit3.Text = "2"
            ElseIf digit3.Text = "2" Then
                digit3.Text = "3"
            ElseIf digit3.Text = "3" Then
                digit3.Text = "4"
            ElseIf digit3.Text = "4" Then
                digit3.Text = "5"
            ElseIf digit3.Text = "5" Then
                digit3.Text = "6"
            ElseIf digit3.Text = "6" Then
                digit3.Text = "7"
            ElseIf digit3.Text = "7" Then
                digit3.Text = "8"
            ElseIf digit3.Text = "8" Then
                digit3.Text = "9"
            End If

        ElseIf digit4.BackColor = Color.Black Then
            If digit4.Text = "0" Then
                digit4.Text = "1"
            ElseIf digit4.Text = "1" Then
                digit4.Text = "2"
            ElseIf digit4.Text = "2" Then
                digit4.Text = "3"
            ElseIf digit4.Text = "3" Then
                digit4.Text = "4"
            ElseIf digit4.Text = "4" Then
                digit4.Text = "5"
            ElseIf digit4.Text = "5" Then
                digit4.Text = "6"
            ElseIf digit4.Text = "6" Then
                digit4.Text = "7"
            ElseIf digit4.Text = "7" Then
                digit4.Text = "8"
            ElseIf digit4.Text = "8" Then
                digit4.Text = "9"
            End If

        ElseIf digit6.BackColor = Color.Black Then
            If digit6.Text = "0" Then
                digit6.Text = "1"
            ElseIf digit6.Text = "1" Then
                digit6.Text = "2"
            ElseIf digit6.Text = "2" Then
                digit6.Text = "3"
            ElseIf digit6.Text = "3" Then
                digit6.Text = "4"
            ElseIf digit6.Text = "4" Then
                digit6.Text = "5"
            ElseIf digit6.Text = "5" Then
                digit6.Text = "6"
            ElseIf digit6.Text = "6" Then
                digit6.Text = "7"
            ElseIf digit6.Text = "7" Then
                digit6.Text = "8"
            ElseIf digit6.Text = "8" Then
                digit6.Text = "9"
            End If

        ElseIf digit7.BackColor = Color.Black Then
            If digit7.Text = "0" Then
                digit7.Text = "1"
            ElseIf digit7.Text = "1" Then
                digit7.Text = "2"
            ElseIf digit7.Text = "2" Then
                digit7.Text = "3"
            ElseIf digit7.Text = "3" Then
                digit7.Text = "4"
            ElseIf digit7.Text = "4" Then
                digit7.Text = "5"
            ElseIf digit7.Text = "5" Then
                digit7.Text = "6"
            ElseIf digit7.Text = "6" Then
                digit7.Text = "7"
            ElseIf digit7.Text = "7" Then
                digit7.Text = "8"
            ElseIf digit7.Text = "8" Then
                digit7.Text = "9"
            End If

        ElseIf digit8.BackColor = Color.Black Then
            If digit8.Text = "0" Then
                digit8.Text = "1"
            ElseIf digit8.Text = "1" Then
                digit8.Text = "2"
            ElseIf digit8.Text = "2" Then
                digit8.Text = "3"
            ElseIf digit8.Text = "3" Then
                digit8.Text = "4"
            ElseIf digit8.Text = "4" Then
                digit8.Text = "5"
            ElseIf digit8.Text = "5" Then
                digit8.Text = "6"
            ElseIf digit8.Text = "6" Then
                digit8.Text = "7"
            ElseIf digit8.Text = "7" Then
                digit8.Text = "8"
            ElseIf digit8.Text = "8" Then
                digit8.Text = "9"
            End If

        ElseIf digit9.BackColor = Color.Black Then
            If digit9.Text = "0" Then
                digit9.Text = "1"
            ElseIf digit9.Text = "1" Then
                digit9.Text = "2"
            ElseIf digit9.Text = "2" Then
                digit9.Text = "3"
            ElseIf digit9.Text = "3" Then
                digit9.Text = "4"
            ElseIf digit9.Text = "4" Then
                digit9.Text = "5"
            ElseIf digit9.Text = "5" Then
                digit9.Text = "6"
            ElseIf digit9.Text = "6" Then
                digit9.Text = "7"
            ElseIf digit9.Text = "7" Then
                digit9.Text = "8"
            ElseIf digit9.Text = "8" Then
                digit9.Text = "9"
            End If

        End If
        updatedFreq = digit1.Text + digit2.Text + digit3.Text + digit4.Text + digit5.Text + digit6.Text + digit7.Text + digit8.Text + digit9.Text
    End Sub

    Private Sub CreateTextboxes()


        Me.Controls.Add(digit1)
        digit1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit1.TextAlign = HorizontalAlignment.Center
        digit1.Text = GetChar(updatedFreq, 1)
        digit1.Size = New Size(12, 19)
        digit1.Location = New Point(453, 178)
        digit1.ForeColor = Color.MediumSeaGreen
        digit1.BackColor = Color.Black
        digit1.BorderStyle = BorderStyle.None
        digit1.BringToFront()
        digit1.Visible = True

        Me.Controls.Add(digit2)
        digit2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit2.TextAlign = HorizontalAlignment.Center
        digit2.Text = GetChar(updatedFreq, 2)
        digit2.Size = New Size(12, 19)
        digit2.Location = New Point(453 + digit1.Width, 178)
        digit2.ForeColor = Color.Black
        digit2.BackColor = Color.MediumSeaGreen
        digit2.BorderStyle = BorderStyle.None
        digit2.BringToFront()
        digit2.Visible = True

        Me.Controls.Add(digit3)
        digit3.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit3.TextAlign = HorizontalAlignment.Center
        digit3.Text = GetChar(updatedFreq, 3)
        digit3.Size = New Size(12, 19)
        digit3.Location = New Point(453 + digit1.Width + digit2.Width, 178)
        digit3.ForeColor = Color.Black
        digit3.BackColor = Color.MediumSeaGreen
        digit3.BorderStyle = BorderStyle.None
        digit3.BringToFront()
        digit3.Visible = True

        Me.Controls.Add(digit4)
        digit4.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit4.TextAlign = HorizontalAlignment.Center
        digit4.Text = GetChar(updatedFreq, 4)
        digit4.Size = New Size(12, 19)
        digit4.Location = New Point(453 + digit1.Width + digit2.Width + digit4.Width, 178)
        digit4.ForeColor = Color.Black
        digit4.BackColor = Color.MediumSeaGreen
        digit4.BorderStyle = BorderStyle.None
        digit4.BringToFront()
        digit4.Visible = True

        Me.Controls.Add(digit5)
        digit5.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit5.TextAlign = HorizontalAlignment.Center
        digit5.Text = GetChar(updatedFreq, 5)
        digit5.Size = New Size(12, 19)
        digit5.Location = New Point(453 + digit1.Width + digit2.Width + digit4.Width + digit5.Width, 178)
        digit5.ForeColor = Color.Black
        digit5.BackColor = Color.MediumSeaGreen
        digit5.BorderStyle = BorderStyle.None
        digit5.BringToFront()
        digit5.Visible = True

        Me.Controls.Add(digit6)
        digit6.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit6.TextAlign = HorizontalAlignment.Center
        digit6.Text = GetChar(updatedFreq, 6)
        digit6.Size = New Size(12, 19)
        digit6.Location = New Point(453 + digit1.Width + digit2.Width + digit4.Width + digit5.Width + digit6.Width, 178)
        digit6.ForeColor = Color.Black
        digit6.BackColor = Color.MediumSeaGreen
        digit6.BorderStyle = BorderStyle.None
        digit6.BringToFront()
        digit6.Visible = True

        Me.Controls.Add(digit7)
        digit7.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit7.TextAlign = HorizontalAlignment.Center
        digit7.Text = GetChar(updatedFreq, 7)
        digit7.Size = New Size(12, 19)
        digit7.Location = New Point(453 + digit1.Width + digit2.Width + digit4.Width + digit5.Width + digit6.Width + digit7.Width, 178)
        digit7.ForeColor = Color.Black
        digit7.BackColor = Color.MediumSeaGreen
        digit7.BorderStyle = BorderStyle.None
        digit7.BringToFront()
        digit7.Visible = True

        Me.Controls.Add(digit8)
        digit8.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit8.TextAlign = HorizontalAlignment.Center
        digit8.Text = GetChar(updatedFreq, 8)
        digit8.Size = New Size(12, 19)
        digit8.Location = New Point(453 + digit1.Width + digit2.Width + digit4.Width + digit5.Width + digit6.Width + digit7.Width + digit8.Width, 178)
        digit8.ForeColor = Color.Black
        digit8.BackColor = Color.MediumSeaGreen
        digit8.BorderStyle = BorderStyle.None
        digit8.BringToFront()
        digit8.Visible = True

        Me.Controls.Add(digit9)
        digit9.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit9.TextAlign = HorizontalAlignment.Center
        digit9.Text = GetChar(updatedFreq, 9)
        digit9.Size = New Size(12, 19)
        digit9.Location = New Point(453 + digit1.Width + digit2.Width + digit4.Width + digit5.Width + digit6.Width + digit7.Width + digit8.Width + digit9.Width, 178)
        digit9.ForeColor = Color.Black
        digit9.BackColor = Color.MediumSeaGreen
        digit9.BorderStyle = BorderStyle.None
        digit9.BringToFront()
        digit9.Visible = True

        MyCreateTextBoxes()

    End Sub

    Private Sub NumberDown()

        If digit1.BackColor = Color.Black Then
            If digit1.Text = "9" Then
                digit1.Text = "8"
            ElseIf digit1.Text = "8" Then
                digit1.Text = "7"
            ElseIf digit1.Text = "7" Then
                digit1.Text = "6"
            ElseIf digit1.Text = "6" Then
                digit1.Text = "5"
            ElseIf digit1.Text = "5" Then
                digit1.Text = "4"
            ElseIf digit1.Text = "4" Then
                digit1.Text = "3"
            ElseIf digit1.Text = "3" Then
                digit1.Text = "2"
            ElseIf digit1.Text = "2" Then
                digit1.Text = "1"
            ElseIf digit1.Text = "1" Then
                digit1.Text = "0"
            End If

        ElseIf digit2.BackColor = Color.Black Then
            If digit2.Text = "9" Then
                digit2.Text = "8"
            ElseIf digit2.Text = "8" Then
                digit2.Text = "7"
            ElseIf digit2.Text = "7" Then
                digit2.Text = "6"
            ElseIf digit2.Text = "6" Then
                digit2.Text = "5"
            ElseIf digit2.Text = "5" Then
                digit2.Text = "4"
            ElseIf digit2.Text = "4" Then
                digit2.Text = "3"
            ElseIf digit2.Text = "3" Then
                digit2.Text = "2"
            ElseIf digit2.Text = "2" Then
                digit2.Text = "1"
            ElseIf digit2.Text = "1" Then
                digit2.Text = "0"
            End If

        ElseIf digit3.BackColor = Color.Black Then
            If digit3.Text = "9" Then
                digit3.Text = "8"
            ElseIf digit3.Text = "8" Then
                digit3.Text = "7"
            ElseIf digit3.Text = "7" Then
                digit3.Text = "6"
            ElseIf digit3.Text = "6" Then
                digit3.Text = "5"
            ElseIf digit3.Text = "5" Then
                digit3.Text = "4"
            ElseIf digit3.Text = "4" Then
                digit3.Text = "3"
            ElseIf digit3.Text = "3" Then
                digit3.Text = "2"
            ElseIf digit3.Text = "2" Then
                digit3.Text = "1"
            ElseIf digit3.Text = "1" Then
                digit3.Text = "0"
            End If

        ElseIf digit4.BackColor = Color.Black Then
            If digit4.Text = "9" Then
                digit4.Text = "8"
            ElseIf digit4.Text = "8" Then
                digit4.Text = "7"
            ElseIf digit4.Text = "7" Then
                digit4.Text = "6"
            ElseIf digit4.Text = "6" Then
                digit4.Text = "5"
            ElseIf digit4.Text = "5" Then
                digit4.Text = "4"
            ElseIf digit4.Text = "4" Then
                digit4.Text = "3"
            ElseIf digit4.Text = "3" Then
                digit4.Text = "2"
            ElseIf digit4.Text = "2" Then
                digit4.Text = "1"
            ElseIf digit4.Text = "1" Then
                digit4.Text = "0"
            End If

        ElseIf digit6.BackColor = Color.Black Then
            If digit6.Text = "9" Then
                digit6.Text = "8"
            ElseIf digit6.Text = "8" Then
                digit6.Text = "7"
            ElseIf digit6.Text = "7" Then
                digit6.Text = "6"
            ElseIf digit6.Text = "6" Then
                digit6.Text = "5"
            ElseIf digit6.Text = "5" Then
                digit6.Text = "4"
            ElseIf digit6.Text = "4" Then
                digit6.Text = "3"
            ElseIf digit6.Text = "3" Then
                digit6.Text = "2"
            ElseIf digit6.Text = "2" Then
                digit6.Text = "1"
            ElseIf digit6.Text = "1" Then
                digit6.Text = "0"
            End If

        ElseIf digit7.BackColor = Color.Black Then
            If digit7.Text = "9" Then
                digit7.Text = "8"
            ElseIf digit7.Text = "8" Then
                digit7.Text = "7"
            ElseIf digit7.Text = "7" Then
                digit7.Text = "6"
            ElseIf digit7.Text = "6" Then
                digit7.Text = "5"
            ElseIf digit7.Text = "5" Then
                digit7.Text = "4"
            ElseIf digit7.Text = "4" Then
                digit7.Text = "3"
            ElseIf digit7.Text = "3" Then
                digit7.Text = "2"
            ElseIf digit7.Text = "2" Then
                digit7.Text = "1"
            ElseIf digit7.Text = "1" Then
                digit7.Text = "0"
            End If

        ElseIf digit8.BackColor = Color.Black Then
            If digit8.Text = "9" Then
                digit8.Text = "8"
            ElseIf digit8.Text = "8" Then
                digit8.Text = "7"
            ElseIf digit8.Text = "7" Then
                digit8.Text = "6"
            ElseIf digit8.Text = "6" Then
                digit8.Text = "5"
            ElseIf digit8.Text = "5" Then
                digit8.Text = "4"
            ElseIf digit8.Text = "4" Then
                digit8.Text = "3"
            ElseIf digit8.Text = "3" Then
                digit8.Text = "2"
            ElseIf digit8.Text = "2" Then
                digit8.Text = "1"
            ElseIf digit8.Text = "1" Then
                digit8.Text = "0"
            End If

        ElseIf digit9.BackColor = Color.Black Then
            If digit9.Text = "9" Then
                digit9.Text = "8"
            ElseIf digit9.Text = "8" Then
                digit9.Text = "7"
            ElseIf digit9.Text = "7" Then
                digit9.Text = "6"
            ElseIf digit9.Text = "6" Then
                digit9.Text = "5"
            ElseIf digit9.Text = "5" Then
                digit9.Text = "4"
            ElseIf digit9.Text = "4" Then
                digit9.Text = "3"
            ElseIf digit9.Text = "3" Then
                digit9.Text = "2"
            ElseIf digit9.Text = "2" Then
                digit9.Text = "1"
            ElseIf digit9.Text = "1" Then
                digit9.Text = "0"
            End If

        End If
        updatedFreq = digit1.Text + digit2.Text + digit3.Text + digit4.Text + digit5.Text + digit6.Text + digit7.Text + digit8.Text + digit9.Text


    End Sub

    Private Sub TxPwrDbFromFull()

        DisplayReset()
        showRowA()
        b1TB.Text = "TX PWR ,"
        b1TB.Width = 100
        b2TB.Text = "db FROM FULL"
        b2TB.Location = New Point(479, 158)
        b2TB.Width = 150
        b6PB.Visible = False
        b7PB.Visible = False


        digit1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit1.TextAlign = HorizontalAlignment.Center
        digit1.Text = GetChar(updatedDB, 1)
        digit1.Size = New Size(12, 19)
        digit1.Location = New Point(493, 178)
        digit1.ForeColor = Color.MediumSeaGreen
        digit1.BackColor = Color.Black
        digit1.BorderStyle = BorderStyle.None
        digit1.BringToFront()
        digit1.Visible = True

        digit2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit2.TextAlign = HorizontalAlignment.Center
        digit2.Text = GetChar(updatedDB, 2)
        digit2.Size = New Size(12, 19)
        digit2.Location = New Point(493 + digit1.Width, 178)
        digit2.ForeColor = Color.Black
        digit2.BackColor = Color.MediumSeaGreen
        digit2.BorderStyle = BorderStyle.None
        digit2.BringToFront()
        digit2.Visible = True
        c1TB.Visible = False
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "ENTER 0 TO 13"
        d1TB.Width = 250
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

        'If rfPath = "highband" Then
        '    fLow = "227.500"
        '    fHigh = "1997.500"
        'Else
        '    fLow = "27.500"
        '    fHigh = "509.500"
        'End If

        'combinedString = "ENTER " + fLow + " TO " + fHigh
        'd1TB.Text = combinedString
        'd1TB.Width = 250
        'd3TB.Visible = False
        'd4TB.Visible = False
        'd6TB.Visible = False
        'd7TB.Visible = False


    End Sub

    Private Sub TestDuration()

        DisplayReset()
        showRowA()
        b1TB.Text = "TEST DURATION (SECS)"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False


        digit1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit1.TextAlign = HorizontalAlignment.Center
        digit1.Text = GetChar(updatedDuration, 1)
        digit1.Size = New Size(12, 19)
        digit1.Location = New Point(487, 178)
        digit1.ForeColor = Color.MediumSeaGreen
        digit1.BackColor = Color.Black
        digit1.BorderStyle = BorderStyle.None
        digit1.BringToFront()
        digit1.Visible = True

        digit2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit2.TextAlign = HorizontalAlignment.Center
        digit2.Text = GetChar(updatedDuration, 2)
        digit2.Size = New Size(12, 19)
        digit2.Location = New Point(487 + digit1.Width, 178)
        digit2.ForeColor = Color.Black
        digit2.BackColor = Color.MediumSeaGreen
        digit2.BorderStyle = BorderStyle.None
        digit2.BringToFront()
        digit2.Visible = True

        digit3.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        digit3.TextAlign = HorizontalAlignment.Center
        digit3.Text = GetChar(updatedDuration, 3)
        digit3.Size = New Size(12, 19)
        digit3.Location = New Point(487 + digit1.Width + digit3.Width, 178)
        digit3.ForeColor = Color.Black
        digit3.BackColor = Color.MediumSeaGreen
        digit3.BorderStyle = BorderStyle.None
        digit3.BringToFront()
        digit3.Visible = True


        c1TB.Visible = False
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "ENTER 1 TO 600"
        d1TB.Width = 250
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

    End Sub

    Public Sub DisplayReset()
        vulosDisplayed = False

        a1TB.Visible = True
        a1TB.Width = 11
        a1TB.Location = New Point(385, 144)
        a1TB.TextAlign = HorizontalAlignment.Center
        a1TB.Text = ""

        a2TB.Visible = True
        a2TB.Width = 31
        a2TB.Location = New Point(401, 144)
        a2TB.TextAlign = HorizontalAlignment.Center
        a2TB.Text = ""

        a3PB.Visible = True
        a3PB.Width = 47
        a3PB.Location = New Point(432, 144)

        a4TB.Visible = True
        a4TB.Width = 47
        a4TB.Location = New Point(479, 144)
        a4TB.TextAlign = HorizontalAlignment.Center
        a4TB.Text = ""

        a5TB.Visible = True
        a5TB.Width = 40
        a5TB.Location = New Point(526, 144)
        a5TB.TextAlign = HorizontalAlignment.Center
        a5TB.Text = ""

        a6TB.Visible = True
        a6TB.Width = 46
        a6TB.Location = New Point(564, 144)
        a6TB.TextAlign = HorizontalAlignment.Center
        a6TB.Text = ""

        a7TB.Visible = True
        a7TB.Width = 21
        a7TB.Location = New Point(611, 144)
        a7TB.TextAlign = HorizontalAlignment.Center
        a7TB.Text = ""

        b1TB.Visible = True
        b1TB.Width = 31
        b1TB.Location = New Point(385, 158)
        b1TB.TextAlign = HorizontalAlignment.Center
        b1TB.Text = ""
        b1TB.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        b1TB.BackColor = Color.MediumSeaGreen
        b1TB.ForeColor = Color.Black


        b2TB.Visible = True
        b2TB.Width = 119
        b2TB.Location = New Point(412, 158)
        b2TB.TextAlign = HorizontalAlignment.Center
        b2TB.Text = ""
        b2TB.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        SetBackGreen(b2TB)

        b6PB.Visible = True
        b6PB.Height = 20
        b6PB.Width = 27
        b6PB.Location = New Point(557, 158)
        b6PB.BackgroundImage = My.Resources.NextIndicator


        b7PB.Visible = True
        b7PB.Width = 47
        b7PB.Height = 20
        b7PB.Location = New Point(584, 158)
        b7PB.BackgroundImage = My.Resources.RxTxPowerScale

        c1TB.Visible = True
        c1TB.Width = 47
        c1TB.Location = New Point(385, 178)
        c1TB.TextAlign = HorizontalAlignment.Center
        c1TB.Text = ""
        c1TB.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        c1TB.BackColor = Color.MediumSeaGreen
        c1TB.ForeColor = Color.Black



        c3TB.Visible = True
        c3TB.Width = 47
        c3TB.Location = New Point(432, 178)
        c3TB.TextAlign = HorizontalAlignment.Center
        c3TB.Text = ""
        c3TB.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        c3TB.BackColor = Color.MediumSeaGreen
        c3TB.ForeColor = Color.Black

        c4TB.Visible = True
        c4TB.Width = 31
        c4TB.Location = New Point(495, 178)
        c4TB.TextAlign = HorizontalAlignment.Center
        c4TB.Text = ""
        c4TB.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        SetBackGreen(c4TB)

        c5TB.Visible = True
        c5TB.Width = 43
        c5TB.Location = New Point(545, 178)
        c5TB.TextAlign = HorizontalAlignment.Center
        c5TB.Text = ""
        c5TB.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        SetBackGreen(c5TB)

        c7TB.Visible = True
        c7TB.Width = 31
        c7TB.Location = New Point(594, 178)
        c7TB.TextAlign = HorizontalAlignment.Center
        c7TB.Text = ""
        c7TB.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        SetBackGreen(c7TB)

        d1TB.Visible = True
        d1TB.Width = 47
        d1TB.Location = New Point(385, 198)
        d1TB.TextAlign = HorizontalAlignment.Center
        d1TB.Text = ""
        d1TB.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
        d1TB.BackColor = Color.MediumSeaGreen
        d1TB.ForeColor = Color.Black

        d3TB.Visible = True
        d3TB.Width = 47
        d3TB.Location = New Point(432, 198)
        d3TB.TextAlign = HorizontalAlignment.Center
        d3TB.Text = ""
        d3TB.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
        SetBackGreen(d3TB)

        d4TB.Visible = True
        d4TB.Width = 47
        d4TB.Location = New Point(488, 198)
        d4TB.TextAlign = HorizontalAlignment.Center
        d4TB.Text = ""
        d4TB.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
        SetBackGreen(d4TB)

        d6TB.Visible = True
        d6TB.Width = 40
        d6TB.Location = New Point(547, 198)
        d6TB.TextAlign = HorizontalAlignment.Center
        d6TB.Text = ""
        d6TB.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
        SetBackGreen(d6TB)

        d7TB.Visible = True
        d7TB.Width = 40
        d7TB.Location = New Point(591, 198)
        d7TB.TextAlign = HorizontalAlignment.Center
        d7TB.Text = ""
        d7TB.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
        SetBackGreen(d7TB)

        digit1.Visible = False
        digit2.Visible = False
        digit3.Visible = False
        digit4.Visible = False
        digit5.Visible = False
        digit6.Visible = False
        digit7.Visible = False
        digit8.Visible = False
        digit9.Visible = False

        ip1.Visible = False
        ip2.Visible = False
        ip3.Visible = False
        ip4.Visible = False
        ip5.Visible = False
        ip6.Visible = False
        ip7.Visible = False
        ip8.Visible = False
        ip9.Visible = False
        ip10.Visible = False
        ip11.Visible = False
        ip12.Visible = False
        ip13.Visible = False
        ip14.Visible = False
        ip15.Visible = False

        page4TB1.Visible = False
        page4TB2.Visible = False
        kdu.page4TB1.Visible = False
        kdu.page4TB2.Visible = False
        modBox.Visible = False
        kdu.modBox.Visible = False
        'MyCreateTextBoxes()


        tbBorder1.Visible = False
        tbBack.Visible = False
        tbFront.Visible = False

        direction = ""

    End Sub 'used to set the display to the base starting point before modifying any text boxes for a new display

    Private Sub testOptionsBertBertModeTransmitOrReceive()
        If ml1 = "test options" And ml2 = "bert" And ml3 = "bert mode" Then
            If c1TB.Text = "TRANSMIT" Then
                c1TB.Text = "RECEIVE"
            ElseIf c1TB.Text = "RECEIVE" Then
                c1TB.Text = "TRANSMIT"
            End If
        End If
    End Sub

    Private Sub SyncChoicesUp()

        If c1TB.Text = "63" Then
            c1TB.Text = "511"
        ElseIf c1TB.Text = "511" Then
            c1TB.Text = "2047"
        ElseIf c1TB.Text = "2047" Then
            c1TB.Text = "4095"
        ElseIf c1TB.Text = "4095" Then
            c1TB.Text = "MARK"
        ElseIf c1TB.Text = "MARK" Then
            c1TB.Text = "SPACE"
        ElseIf c1TB.Text = "SPACE" Then
            c1TB.Text = "1:1"
        ElseIf c1TB.Text = "1:1" Then
            c1TB.Text = "0011"
        ElseIf c1TB.Text = "0011" Then
            c1TB.Text = "63"
        End If

        c1TB.Width = c1TB.TextLength * 12.5
        c1TB.Location = New Point(((255 / 2) - ((c1TB.TextLength * 12) / 2)) + 382, 178) 'formula for finding the center of the display

    End Sub

    Private Sub SyncChoicesDown()

        If c1TB.Text = "1:1" Then
            c1TB.Text = "SPACE"
        ElseIf c1TB.Text = "SPACE" Then
            c1TB.Text = "MARK"
        ElseIf c1TB.Text = "MARK" Then
            c1TB.Text = "4095"
        ElseIf c1TB.Text = "4095" Then
            c1TB.Text = "2047"
        ElseIf c1TB.Text = "2047" Then
            c1TB.Text = "511"
        ElseIf c1TB.Text = "511" Then
            c1TB.Text = "63"
        ElseIf c1TB.Text = "63" Then
            c1TB.Text = "0011"
        ElseIf c1TB.Text = "0011" Then
            c1TB.Text = "1:1"
        End If

        c1TB.Width = c1TB.TextLength * 12.5
        c1TB.Location = New Point(((255 / 2) - ((c1TB.TextLength * 12) / 2)) + 382, 178) 'formula for finding the center of the display

    End Sub

    Private Sub OptionsScrollUp()

        If ml1 = "" Then
            If d1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                d1TB.BackColor = Color.MediumSeaGreen
                d1TB.ForeColor = Color.Black
                If knobIndex = 3 Then
                    b7PB.BackgroundImage = My.Resources.scrollbarFull
                Else
                    b7PB.BackgroundImage = My.Resources.ScrollBar8
                End If


            ElseIf c1TB.BackColor = Color.Black Then
                b1TB.BackColor = Color.Black
                b1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                If knobIndex = 3 Then
                    b7PB.BackgroundImage = My.Resources.scrollbarFull
                Else
                    b7PB.BackgroundImage = My.Resources.scrollbar7
                End If

            Else
                If knobIndex = 3 Then 'if in LOAD, bypass the next piece of code
                Else
                    OptionsMoveUp()
                End If

            End If
        End If

    End Sub 'moves the cursor up on the options home page

    Private Sub OptionsMoveUp()

        If b1TB.Text <> "DATA MODE" Then 'stops scrolling when it reaches the top
            d1TB.Text = c1TB.Text

            c1TB.Text = b1TB.Text
            scrollingUp = b1TB.Text
        End If



        Select Case scrollingUp
            
            Case "GPS OPTIONS"
                b1TB.Text = "DATA MODE"
                b7PB.BackgroundImage = My.Resources.ScrollBar1
            Case "LOCK KEYPAD"
                b1TB.Text = "GPS OPTIONS"
                b7PB.BackgroundImage = My.Resources.scrollbar2
            Case "MISSION PLAN"
                b1TB.Text = "LOCK KEYPAD"
                b7PB.BackgroundImage = My.Resources.scrollbar2
            Case "RADIO OPTIONS"
                b1TB.Text = "RADIO INFORMATION"
                b7PB.BackgroundImage = My.Resources.scrollbar5
            Case "SA OPTIONS"
                b1TB.Text = "RADIO OPTIONS"
                b7PB.BackgroundImage = My.Resources.scrollbar5
            Case "SYSTEM INFORMATION"
                b1TB.Text = "SA OPTIONS"
                b7PB.BackgroundImage = My.Resources.scrollbar6
            Case "TEST OPTIONS"
                b1TB.Text = "SYSTEM INFORMATION"
                b7PB.BackgroundImage = My.Resources.scrollbar6
            Case "TX POWER OPTIONS"
                b1TB.Text = "TEST OPTIONS"
                b7PB.BackgroundImage = My.Resources.scrollbar7
            Case "VIEW KEY INFO"
                b1TB.Text = "TX POWER OPTIONS"
                b7PB.BackgroundImage = My.Resources.scrollbar7
            Case "WAVEFORM DEP OPTIONS"
                b1TB.Text = "VIEW KEY INFO"
                b7PB.BackgroundImage = My.Resources.ScrollBar8
            Case "RADIO INFORMATION"
                b1TB.Text = "NETWORK OPTIONS"
                b7PB.BackgroundImage = My.Resources.ScrollBar4
            Case "NETWORK OPTIONS"
                b1TB.Text = "MISSION PLAN"
                b7PB.BackgroundImage = My.Resources.scrollbar3

        End Select
        b1TB.Width = b1TB.TextLength * 11
        c1TB.Width = c1TB.TextLength * 11
        d1TB.Width = d1TB.TextLength * 11

        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.TextAlign = HorizontalAlignment.Left
        d1TB.TextAlign = HorizontalAlignment.Left

    End Sub 'aids OptionsScollUp() to move through the options menu

    Private Sub OptionsScrollDown()

        If ml1 = "" Then
            If b1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                b1TB.BackColor = Color.MediumSeaGreen
                b1TB.ForeColor = Color.Black
                If knobIndex = 3 Then
                    b7PB.BackgroundImage = My.Resources.scrollbarFull
                Else
                    b7PB.BackgroundImage = My.Resources.scrollbar2
                End If



            ElseIf c1TB.BackColor = Color.Black Then
                d1TB.BackColor = Color.Black
                d1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                If knobIndex = 3 Then
                    b7PB.BackgroundImage = My.Resources.scrollbarFull
                Else
                    b7PB.BackgroundImage = My.Resources.scrollbar3
                End If

            Else
                If knobIndex = 3 Then 'if in LOAD, bypass the next piece of code
                Else
                    ScrollOptionsDown()
                End If
            End If
        End If

    End Sub 'moves the cursor down on the options home page

    Private Sub ScrollOptionsDown()

        If d1TB.Text <> "WAVEFORM DEP OPTIONS" Then 'stops the process when the end of the list is reached
            b1TB.Text = c1TB.Text

            c1TB.Text = d1TB.Text
            scrollingDown = d1TB.Text
        End If



        Select Case scrollingDown
            Case "LOCK KEYPAD"
                d1TB.Text = "MISSION PLAN"
                b7PB.BackgroundImage = My.Resources.ScrollBar4
            Case "MISSION PLAN"
                d1TB.Text = "NETWORK OPTIONS"
                b7PB.BackgroundImage = My.Resources.ScrollBar4
            Case "NETWORK OPTIONS"
                d1TB.Text = "RADIO INFORMATION"
                b7PB.BackgroundImage = My.Resources.scrollbar5
            Case "RADIO INFORMATION"
                d1TB.Text = "RADIO OPTIONS"
                b7PB.BackgroundImage = My.Resources.scrollbar5
            Case "RADIO OPTIONS"
                d1TB.Text = "SA OPTIONS"
                b7PB.BackgroundImage = My.Resources.scrollbar6
            Case "SA OPTIONS"
                d1TB.Text = "SYSTEM INFORMATION"
                b7PB.BackgroundImage = My.Resources.scrollbar6
            Case "SYSTEM INFORMATION"
                d1TB.Text = "TEST OPTIONS"
                b7PB.BackgroundImage = My.Resources.scrollbar7
            Case "TEST OPTIONS"
                d1TB.Text = "TX POWER OPTIONS"
                b7PB.BackgroundImage = My.Resources.scrollbar7
            Case "TX POWER OPTIONS"
                d1TB.Text = "VIEW KEY INFO"
                b7PB.BackgroundImage = My.Resources.ScrollBar8
            Case "VIEW KEY INFO"
                d1TB.Text = "WAVEFORM DEP OPTIONS"
                b7PB.BackgroundImage = My.Resources.ScrollBar8

        End Select
        b1TB.Width = b1TB.TextLength * 11
        c1TB.Width = c1TB.TextLength * 11
        d1TB.Width = d1TB.TextLength * 11

        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.TextAlign = HorizontalAlignment.Left
        d1TB.TextAlign = HorizontalAlignment.Left


    End Sub 'aids OptionsScollSDown() to move through the options menu

    Private Sub TestOptionsScrollDown()

        If ml1 = "test options" And ml2 = "" Then
            If b1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                b1TB.BackColor = Color.MediumSeaGreen
                b1TB.ForeColor = Color.Black
                b7PB.BackgroundImage = My.Resources.scrollbar2


            ElseIf c1TB.BackColor = Color.Black Then
                d1TB.BackColor = Color.Black
                d1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                b7PB.BackgroundImage = My.Resources.scrollbar3

            Else
                ScrollTextDown()

            End If
        End If

    End Sub

    Private Sub TestOptionsScrollUp()

        If ml1 = "test options" And ml2 = "" Then
            If d1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                d1TB.BackColor = Color.MediumSeaGreen
                d1TB.ForeColor = Color.Black
                b7PB.BackgroundImage = My.Resources.scrollbar7


            ElseIf c1TB.BackColor = Color.Black Then
                b1TB.BackColor = Color.Black
                b1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                b7PB.BackgroundImage = My.Resources.scrollbar6

            Else
                scrollTextUp()

            End If
        End If

    End Sub

    Private Sub OptionalTestsSubMenu()

        If c1TB.Text = "GPS" Then
            c1TB.Text = "RES FLASH"
            c1TB.Width = 102
            c1TB.Location = New Point(((250 / 2) - 51) + 382, 178)
        ElseIf c1TB.Text = "RES FLASH" Then
            c1TB.Text = "GPS"
            c1TB.Width = 38
            c1TB.Location = New Point(((250 / 2) - 19) + 382, 178)
        End If

    End Sub

    Private Sub RXtestInProgress()

        DisplayReset()

        showRowA()
        b1TB.Text = "*** TEST ***"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False
        c1TB.Text = "IN PROGRESS"
        c1TB.Width = 250
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False
        d1TB.Text = "PRESS CLR TO ABORT"
        d1TB.Width = 250
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

        timeItTakes = 5

        MyTimerSetup()

        'thread2 = New Thread(AddressOf Me.DelayNextScreen)
        'CheckForIllegalCrossThreadCalls = False
        'thread2.Start()


        HelperUpdate()

    End Sub

    Private Sub WidebandMenuScrollDown()
        If c1TB.Text = "TX RX" Then
            c1TB.Text = "RX SENSITIVITY"
            c1TB.Width = 150
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        ElseIf c1TB.Text = "RX SENSITIVITY" Then
            c1TB.Text = "TX POWER"
            c1TB.Width = 98
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        ElseIf c1TB.Text = "TX POWER" Then
            c1TB.Text = "TX FREQUENCY"
            c1TB.Width = 144
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        ElseIf c1TB.Text = "TX FREQUENCY" Then
            c1TB.Text = "FULL DUPLEX"
            c1TB.Width = 124
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        ElseIf c1TB.Text = "FULL DUPLEX" Then
            c1TB.Text = "TX RX"
            c1TB.Width = 60
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        End If
    End Sub

    Private Sub WidebandMenuScrollUp()
        If c1TB.Text = "TX RX" Then
            c1TB.Text = "FULL DUPLEX"
            c1TB.Width = 124
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        ElseIf c1TB.Text = "RX SENSITIVITY" Then
            c1TB.Text = "TX RX"
            c1TB.Width = 60
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        ElseIf c1TB.Text = "TX POWER" Then
            c1TB.Text = "RX SENSITIVITY"
            c1TB.Width = 150
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        ElseIf c1TB.Text = "TX FREQUENCY" Then
            c1TB.Text = "TX POWER"
            c1TB.Width = 98
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        ElseIf c1TB.Text = "FULL DUPLEX" Then
            c1TB.Text = "TX FREQUENCY"
            c1TB.Width = 144
            c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)

            
        End If
    End Sub

    Private Sub InitiateLCDtest()

        DisplayReset()

        If ml3 = "page1" Then

            a1TB.Visible = False
            a2TB.Visible = False
            a3PB.Visible = False
            a4TB.Visible = False
            a5TB.Visible = False
            a6TB.Visible = False
            a7TB.Visible = False

            b1TB.Text = "INSPECT LCD FOR DEFECTS"
            b1TB.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            b1TB.Width = 250
            b1TB.Visible = True
            b2TB.Visible = False
            b6PB.Visible = False
            b7PB.Visible = False

            c1TB.Text = ">  OR  ENT TO GO FORWARD"
            c1TB.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            c1TB.Visible = True
            c1TB.Width = 250
            c3TB.Visible = False
            c4TB.Visible = False
            c5TB.Visible = False
            c7TB.Visible = False

            d1TB.Text = "<  OR  CLR TO GO BACKWARD"
            d1TB.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
            d1TB.Visible = True
            d1TB.Width = 250
            d3TB.Visible = False
            d4TB.Visible = False
            d6TB.Visible = False
            d7TB.Visible = False

        End If

        If ml3 = "page2" Then
            a1TB.Visible = False
            a2TB.Visible = False
            a3PB.Visible = False
            a4TB.Visible = False
            a5TB.Visible = False
            a6TB.Visible = False
            a7TB.Visible = False

            b1TB.Visible = False
            b2TB.Visible = False
            b6PB.Visible = True
            b6PB.Location = New Point(385, 144)
            b6PB.Size = New Size(250, 70)
            b6PB.BackgroundImage = My.Resources.LCD1
            b7PB.Visible = False

            c1TB.Visible = False
            c3TB.Visible = False
            c4TB.Visible = False
            c5TB.Visible = False
            c7TB.Visible = False

            d1TB.Visible = False
            d3TB.Visible = False
            d4TB.Visible = False
            d6TB.Visible = False
            d7TB.Visible = False

            MyImageUpdated()

        End If

    End Sub

    Private Sub LCDchecks()

        If ml2 = "lcd test" Then
            If ml3 = "" Then
                ml3 = "page1"
            End If
        End If


        If direction = "forward" Then
            If ml4 = ">  or  ent to go forward" Then
                If ml3 = "page1" Then
                    ml3 = "page2"
                ElseIf ml3 = "page2" Then
                    ml3 = "page1"
                End If
            End If
        ElseIf direction = "backward" Then
            If ml3 = "page2" Then
                ml3 = "page1"
            ElseIf ml3 = "page1" Then
                ml3 = "page2"
            End If
        End If


    End Sub

    Private Sub SWValidation()

        Select Case ml3
            Case "maintenance password"
                ShowTestMayTakeUpTo30Min()
        End Select

        Select Case ml4
            Case "up to 30 min"
                ShowValidateFileSystem()
                ml5 = "y/n"
                Select Case ml6
                    Case "yes"
                        ShowSWValidationInProgress()
                    Case "no"
                        TestOptions()
                End Select
        End Select

    End Sub

    Private Sub ShowTestMayTakeUpTo30Min()

        DisplayReset()
        showRowA()

        b1TB.Text = "TEST MAY TAKE"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "UP TO 30 MIN"
        c1TB.Width = 250
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        EntToCont()

    End Sub

    Private Sub ShowValidateFileSystem()

        DisplayReset()
        showRowA()

        b1TB.Text = "VALIDATE FILE SYSTEM"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = True
        b7PB.Visible = False

        c1TB.Text = "YES"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 38
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        ShowToScrollEntToCont()


    End Sub

    Private Sub ShowSWValidationInProgress()

        DisplayReset()
        showRowA()

        b1TB.Text = "SW VALIDATION"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False

        b6PB.Width = 250
        b7PB.Visible = False

        c1TB.Visible = False
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = " . . . WAIT . . . "
        d1TB.Width = 250
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

        timeItTakes = 10
        ShowProgressbar()
        

       
        
    End Sub

    Private Sub ShowProgressbar()

        

        Me.Controls.Add(tbBorder1)
        tbBorder1.BorderStyle = BorderStyle.None
        tbBorder1.AutoSize = False
        tbBorder1.Location = New Point(507 - (52), 180)
        tbBorder1.BackColor = Color.Black
        tbBorder1.Height = 13
        tbBorder1.Width = 104
        tbBorder1.Visible = True
        tbBorder1.BringToFront()

        Me.Controls.Add(tbBack)
        tbBack.AutoSize = False
        tbBack.BorderStyle = BorderStyle.None
        tbBack.BringToFront()
        tbBack.Width = 100
        tbBack.Height = 9
        tbBack.Location = New Point(507 - (50), 182)
        tbBack.BackColor = Color.MediumSeaGreen
        tbBack.Visible = True

        Me.Controls.Add(tbFront)
        tbFront.Visible = False
        tbFront.AutoSize = False
        tbFront.BorderStyle = BorderStyle.None
        tbFront.Width = 0
        tbFront.Height = 9
        tbFront.Location = New Point(507 - (50), 182)
        tbFront.BackColor = Color.Black
        tbFront.Visible = True
        tbFront.BringToFront()

        MyCreateProgressbar()
        MyTimerSetup()

       
    End Sub

    Private Sub GeneralUseTimer_Tick(sender As Object, e As EventArgs) Handles generalUseTimer.Tick
        'uses timeItTakes from sender to determine length of delay

        timeStart = 0 'variable used to store a start time reference
        

        If formIsClosed = True Then 'checks to see if the main form is closed
            Exit Sub 'exits if form is closed
        ElseIf (timeEnd - timeItTakes) <> timeStart Then 'begin to time display

            timeEnd = timeEnd + 1

        ElseIf (timeEnd - timeItTakes) = timeStart Then

            generalUseTimer.Stop()

            If ml2 = "sw validation" Then
                SWValPassed()
            ElseIf ml2 = "memory test" Then
                MemoryTestTimer()
            ElseIf ml2 = "self test" Then
                TestPassed()
            ElseIf ml2 = "mission plan loading" Then
                MissionPlanComplete()
            ElseIf ml2 = "ping success" Then
                PingSuccess()
            ElseIf ml2 = "fill device type" Then
                FillCryptoMode()
            ElseIf ml1 = "fill" And ml3 = "abort" Then
                FillMenu()
            ElseIf ml1 = "mode" And ml2 = "beacon" And ml4 <> "yes" Then
                BeaconMode()
            ElseIf ml1 = "mode" And ml2 = "beacon" And ml4 = "yes" Then
                ModeMainPage()
                ml2 = ""
                ml3 = ""
                HelperUpdate()
            ElseIf from = "receive clone" Then
                RxCloneInProgress()
            ElseIf from = "receiving" Then
                RxCloneComplete()
            ElseIf from = "configuring" Then
                TxCloneInProgress()
            ElseIf from = "transmitting" Then
                TxCloneComplete()
            ElseIf from = "OTAR receiving" Then
                OTARrecComplete()
            End If

            If ml4 = "rx" Or ml4 = "tx" Or ml3 = "rx sensitivity" Or ml3 = "tx power" Or ml3 = "tx frequency" Or ml3 = "full duplex" Then 'if in transmit or receive, show the test complete page
                Testcomplete()
            Else
                TestPassed() 'if in gps, show the test passed page
            End If

        End If

       

        meterReading = meterReading + (100 / timeItTakes)
        tbFront.Width = meterReading
        MyCreateProgressbar()

    End Sub

    Private Sub SWValPassed()

        DisplayReset()
        showRowA()

        b1TB.Text = "SW VALIDATION"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False

        b6PB.Width = 250
        b7PB.Visible = False

        c1TB.Text = "PASSED"
        c1TB.Width = 250
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d6TB.Visible = False
        d7TB.Visible = False
        d4TB.Visible = False
        d3TB.Visible = False
        d1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO EXIT"
        d1TB.Width = 250


    End Sub

    Private Sub PositionAndHighlight()
        SetWidth(c1TB)
        'c1TB.Width = c1TB.TextLength * 12.5
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
    End Sub

    Private Sub ShutDown()

        SetVisibilityOFF()
        image = False 'resets the variable to false indicating a reset of the display
        Try
            t.Abort() 'aborts the thread used for display timing
        Catch ex As Exception

        End Try

        IPshutdown()

        displayPic.BackgroundImage = My.Resources.Blank 'sets the display background image to blank when the knob is OFF

        screenReady = False
    End Sub

    Private Sub Restart()

        TurnOnCheck() 'checks if the system has just been turned on
    End Sub

    Private Sub MemoryTestComplete()

        timeItTakes = 5

        MyTimerSetup()

    End Sub

    Private Sub MemoryTestTimer()


        DisplayReset()

        ShowRowAnot()

        b1TB.Text = " * * MEMORY TEST * * "
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = False

        b6PB.Width = 250
        b7PB.Visible = False

        c1TB.Text = "PASSED"
        c1TB.Width = 250
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d6TB.Visible = False
        d7TB.Visible = False
        d4TB.Visible = False
        d3TB.Visible = False
        d1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO EXIT"
        d1TB.Width = 250

        ml6 = "memory test passed"

        HelperUpdate()

    End Sub

    Private Sub ShowRowAnot()
        a1TB.Visible = False
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
    End Sub

    Private Sub DisplayOptionsMenu()

        DisplayReset()
        vulosDisplayed = False

        ml1 = ""
        ml2 = "" 'change to null on initial page load
        ml3 = ""
        ml4 = ""
        ml5 = ""
        ml6 = ""
        HelperUpdate()

        'the following builds the base page for the test options display
        showRowA()


        b1TB.Text = "DATA MODE"
        b1TB.Width = b1TB.TextLength * 11
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Location = New Point(386, 160)
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.BackgroundImage = My.Resources.ScrollBar1

        c1TB.Text = "GPS OPTIONS"
        c1TB.Width = c1TB.TextLength * 11
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(386, 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "LOCK KEYPAD"
        d1TB.Width = d1TB.TextLength * 11
        d1TB.Height = 19
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(386, 196)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Visible = True
        b7PB.Visible = True

        c1TB.Visible = True

        d1TB.Visible = True


    End Sub

    Private Sub LockKeypad()
        DisplayReset()
        ShowRowAnot()

        b1TB.Visible = False
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

        c1TB.Text = "KEYPAD LOCKED"
        c1TB.Width = 250
        c1TB.Location = New Point(385, 168)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "ENTER 1379 TO UNLOCK"
        d1TB.Width = 250
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False


    End Sub

    Private Sub DataMode()
        DisplayReset()
        showRowA()

        b1TB.Text = "DATA AUTOSWITCH"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = True
        b7PB.Visible = False

        c1TB.Text = "OFF"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 38
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        ShowToScrollEntToCont()
        d1TB.Text = "TO CHANGE / ENT TO CONT"
    End Sub

    Private Sub OffOnChoice()
        If c1TB.Text = "ON" Then
            c1TB.Text = "OFF"
        ElseIf c1TB.Text = "OFF" Then
            c1TB.Text = "ON"
        End If
        SetWidth(c1TB)
        CenterMe(c1TB)
    End Sub

    Private Sub DataModeSyncAsyncPPP()
        DisplayReset()
        showRowA()

        b1TB.Text = "DATA MODE"
        b1TB.Width = 250
        b2TB.Visible = False
        b6PB.Visible = True
        b7PB.Visible = False

        c1TB.Text = "SYNC/ASYNC"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = c1TB.TextLength * 12
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        ShowToScrollEntToCont()
        d1TB.Text = "TO CHANGE / ENT TO CONT"
    End Sub

    Private Sub SyncAsyncPage()
        DisplayOptionsMenu()
    End Sub

    Private Sub PPPpage()
        DisplayOptionsMenu()
    End Sub

    Private Sub GPSstatusList()
        DisplayReset()
        showRowA()

        b1TB.Text = "GPS STATUS"
        b1TB.Width = b1TB.TextLength * 11
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Location = New Point(386, 160)
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.BackgroundImage = My.Resources.scrollbarFull

        c1TB.Text = "GPS KEY INFO"
        c1TB.Width = c1TB.TextLength * 10
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(386, 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "PASSTHRU MODE"
        d1TB.Width = d1TB.TextLength * 11.5
        d1TB.Height = 19
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(386, 196)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Visible = True
        b7PB.Visible = True

        c1TB.Visible = True

        d1TB.Visible = True


    End Sub

    Private Sub GenericScrollUp()

        If d1TB.BackColor = Color.Black Then
            c1TB.BackColor = Color.Black
            c1TB.ForeColor = Color.MediumSeaGreen
            d1TB.BackColor = Color.MediumSeaGreen
            d1TB.ForeColor = Color.Black
            b7PB.BackgroundImage = My.Resources.ScrollBar8


        ElseIf c1TB.BackColor = Color.Black Then
            b1TB.BackColor = Color.Black
            b1TB.ForeColor = Color.MediumSeaGreen
            c1TB.BackColor = Color.MediumSeaGreen
            c1TB.ForeColor = Color.Black
            b7PB.BackgroundImage = My.Resources.scrollbar7

        End If

    End Sub

    Private Sub GenericScrollDown()

        If b1TB.BackColor = Color.Black Then
            c1TB.BackColor = Color.Black
            c1TB.ForeColor = Color.MediumSeaGreen
            b1TB.BackColor = Color.MediumSeaGreen
            b1TB.ForeColor = Color.Black
            b7PB.BackgroundImage = My.Resources.scrollbar2


        ElseIf c1TB.BackColor = Color.Black Then
            d1TB.BackColor = Color.Black
            d1TB.ForeColor = Color.MediumSeaGreen
            c1TB.BackColor = Color.MediumSeaGreen
            c1TB.ForeColor = Color.Black
            b7PB.BackgroundImage = My.Resources.scrollbar3

        End If

    End Sub

    Private Sub GPSstatusChoices()
        DisplayReset()
        showRowA()

        b1TB.Text = "GPS STATUS"
        b1TB.Width = b1TB.TextLength * 11
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Location = New Point(386, 160)
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.BackgroundImage = My.Resources.ScrollBar1

        c1TB.Text = "GPS POSITION"
        c1TB.Width = c1TB.TextLength * 10
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(386, 178)
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "GPS HEADING/VELOCITY"
        d1TB.Width = d1TB.TextLength * 11
        d1TB.Height = 19
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(386, 196)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Visible = True
        b7PB.Visible = True

        c1TB.Visible = True

        d1TB.Visible = True

        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.TextAlign = HorizontalAlignment.Left
        d1TB.TextAlign = HorizontalAlignment.Left

    End Sub

    Private Sub ScrollGPSstatusUp()

        If b1TB.BackColor <> Color.Black Then
            GenericScrollUp()
        ElseIf b1TB.Text <> "GPS STATUS" Then 'stops the process when the end of the list is reached
            d1TB.Text = c1TB.Text
            c1TB.Text = b1TB.Text
            scrollingUp = b1TB.Text




            Select Case scrollingUp
                Case "GPS ALTITUDE/EPE"
                    b1TB.Text = "GPS HEADING/VELOCITY"
                    b7PB.BackgroundImage = My.Resources.ScrollBar4
                Case "GPS HEADING/VELOCITY"
                    b1TB.Text = "GPS POSITION"
                    b7PB.BackgroundImage = My.Resources.ScrollBar4
                Case "GPS POSITION"
                    b1TB.Text = "GPS STATUS"
                    b7PB.BackgroundImage = My.Resources.scrollbar5

            End Select
        End If

        b1TB.Width = b1TB.TextLength * 11
        c1TB.Width = c1TB.TextLength * 11
        d1TB.Width = d1TB.TextLength * 11

        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.TextAlign = HorizontalAlignment.Left
        d1TB.TextAlign = HorizontalAlignment.Left
    End Sub

    Private Sub ScrollGPSstatusDown()

        If d1TB.BackColor <> Color.Black Then
            GenericScrollDown()
        ElseIf d1TB.Text <> "GPS SAT INFO" Then 'stops the process when the end of the list is reached
            b1TB.Text = c1TB.Text
            c1TB.Text = d1TB.Text
            scrollingDown = d1TB.Text




            Select Case scrollingDown
                Case "GPS HEADING/VELOCITY"
                    d1TB.Text = "GPS ALTITUDE/EPE"
                    b7PB.BackgroundImage = My.Resources.ScrollBar4
                Case "GPS ALTITUDE/EPE"
                    d1TB.Text = "GPS FOM/KEY STAT"
                    b7PB.BackgroundImage = My.Resources.ScrollBar4
                Case "GPS FOM/KEY STAT"
                    d1TB.Text = "GPS SAT INFO"
                    b7PB.BackgroundImage = My.Resources.scrollbar5

            End Select

        End If



        b1TB.Width = b1TB.TextLength * 11
        c1TB.Width = c1TB.TextLength * 11
        d1TB.Width = d1TB.TextLength * 11

        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.TextAlign = HorizontalAlignment.Left
        d1TB.TextAlign = HorizontalAlignment.Left
    End Sub

    Private Sub GPSstatusPage()

        Dim theDate As Date
        theDate = Now()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "GPS STATUS"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "TRACKING SPS"
        c1TB.Width = 250
        c1TB.Visible = True

        d1TB.Text = "SATS08            " + theDate.ToString("M/dd/yy") + "            " + theDate.ToUniversalTime.ToString("hh:mm:ss")

        d1TB.Width = 250
        d1TB.Visible = True



    End Sub

    Private Sub GPSpositionPage()

        Dim theDate As Date
        theDate = Now()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "LAT:   N  43'  08'  51.  26"
        b1TB.Width = 250
        b1TB.Visible = True
        b1TB.TextAlign = HorizontalAlignment.Left


        c1TB.Text = "LNG:  W  77'  33'  26.  64"
        c1TB.Width = 250
        c1TB.Visible = True
        c1TB.TextAlign = HorizontalAlignment.Left


        d1TB.Text = "SATS08            " + theDate.ToString("M/dd/yy") + "            " + theDate.ToUniversalTime.ToString("hh:mm:ss")

        d1TB.Width = 250
        d1TB.Visible = True

    End Sub

    Private Sub GPSheadingPage()
        Dim theDate As Date
        theDate = Now()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "HEADING:"
        b1TB.Width = 100
        b1TB.Visible = True
        b1TB.TextAlign = HorizontalAlignment.Left
        b2TB.Text = "212 deg "
        b2TB.Width = 70
        b2TB.Visible = True
        b2TB.TextAlign = HorizontalAlignment.Right
        b2TB.Location = New Point(562, 158)


        c1TB.Text = "VELOCITY:"
        c1TB.Width = 100
        c1TB.Visible = True
        c1TB.TextAlign = HorizontalAlignment.Left
        c3TB.Text = "0.3 kph "
        c3TB.Width = 70
        c3TB.Visible = True
        c3TB.TextAlign = HorizontalAlignment.Right
        c3TB.Location = New Point(562, 178)


        d1TB.Text = "SATS08            " + theDate.ToString("M/dd/yy") + "            " + theDate.ToUniversalTime.ToString("hh:mm:ss")

        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub GPSaltitudePage()
        Dim theDate As Date
        theDate = Now()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "ALTITUDE:"
        b1TB.Width = 100
        b1TB.Visible = True
        b1TB.TextAlign = HorizontalAlignment.Left
        b2TB.Text = "158.20 m "
        b2TB.Width = 110
        b2TB.Visible = True
        b2TB.TextAlign = HorizontalAlignment.Right
        b2TB.Location = New Point(b1TB.Location.X + b1TB.Width, 158)


        c1TB.Text = "EPE:"
        c1TB.Width = 100
        c1TB.Visible = True
        c1TB.TextAlign = HorizontalAlignment.Left
        c3TB.Text = "+/- 25.00 m "
        c3TB.Width = 110
        c3TB.Visible = True
        c3TB.TextAlign = HorizontalAlignment.Right
        c3TB.Location = New Point(c1TB.Location.X + c1TB.Width, 178)


        d1TB.Text = "SATS08            " + theDate.ToString("M/dd/yy") + "            " + theDate.ToUniversalTime.ToString("hh:mm:ss")

        d1TB.Width = 250
        d1TB.Visible = True
    End Sub


    Private Sub GPSfomKeyPage()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "FOM:          3"
        b1TB.Width = 110
        b1TB.Visible = True
        b1TB.TextAlign = HorizontalAlignment.Left
        b2TB.Text = "TFOM:        4"
        b2TB.Width = 130
        b2TB.Visible = True
        b2TB.TextAlign = HorizontalAlignment.Right
        b2TB.Location = New Point(b1TB.Location.X + b1TB.Width, 158)


        c1TB.Text = "KEY STAT:"
        c1TB.Width = 100
        c1TB.Visible = True
        c1TB.TextAlign = HorizontalAlignment.Left
        c3TB.Text = "CVS "
        c3TB.Width = 70
        c3TB.Visible = True
        c3TB.TextAlign = HorizontalAlignment.Right
        c3TB.Location = New Point(562, 178)


        d1TB.Text = "LAST KNOWN POSITION INFO"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub GPSsatInfoPage()
        Dim theDate As Date
        theDate = Now()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "SAT# "
        b1TB.Width = 50
        b1TB.Visible = True
        b1TB.TextAlign = HorizontalAlignment.Left
        b2TB.Text = "21V"
        b2TB.Width = 50
        b2TB.Visible = True
        b2TB.TextAlign = HorizontalAlignment.Left
        b2TB.Location = New Point(b1TB.Location.X + b1TB.Width, 158)
        c7TB.Text = "ELEV: 84"
        c7TB.Location = New Point(b2TB.Location.X + b2TB.Width + 60, 158)
        c7TB.TextAlign = HorizontalAlignment.Left
        c7TB.Width = 90
        c7TB.Visible = True



        c1TB.Text = "SNR: 0"
        c1TB.Width = 100
        c1TB.Visible = True
        c1TB.TextAlign = HorizontalAlignment.Left
        c3TB.Text = "AZIM: 314"
        c3TB.Width = 90
        c3TB.Location = New Point(b2TB.Location.X + b2TB.Width + 60, 178)
        c3TB.TextAlign = HorizontalAlignment.Left
        c3TB.Visible = True



        d1TB.Text = "01 OF 12    USE"
        d1TB.Width = 100
        d1TB.Visible = True

        b6PB.Location = New Point(d1TB.Location.X + d1TB.Width, 200) 'relocates b6PB for use as up/dn arrows
        b6PB.Height = 6
        b6PB.Width = 28
        b6PB.BackgroundImage = My.Resources.UpAndDown
        b6PB.Visible = True

        d3TB.Text = "TO SCROLL"
        d3TB.Location = New Point(b6PB.Location.X + b6PB.Width, 198)
        d3TB.Width = 110
        d3TB.TextAlign = HorizontalAlignment.Left
        d3TB.Visible = True
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

    End Sub

    Private Sub GPScvStatus()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "GPS CV STATUS"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "CONTAINS TODAY'S KEY"
        c1TB.Width = 250
        c1TB.Visible = True

        d1TB.Text = "PRESS ENTER TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub DaysWithKeys()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "DAYS WITH KEYS"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "1"
        c1TB.Width = 250
        c1TB.Visible = True

        d1TB.Text = "PRESS ENTER TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub PassthruMode()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "PASSTHRU MODE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "RS232 MODE"
        c1TB.Width = c1TB.TextLength * 11.5
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True

    End Sub

    Private Sub MissionPlanMain()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "ACTIVATE MISSION PLAN"
        b1TB.Width = 220
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "MISSION PLAN HISTORY"
        c1TB.Width = 215
        c1TB.Visible = True

        b7PB.BackgroundImage = My.Resources.scrollbarFull
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.Visible = True


    End Sub

    Private Sub MissionPlanMainScroll()
        If b1TB.BackColor = Color.Black Then
            b1TB.BackColor = Color.MediumSeaGreen
            b1TB.ForeColor = Color.Black
            c1TB.BackColor = Color.Black
            c1TB.ForeColor = Color.MediumSeaGreen
        ElseIf c1TB.BackColor = Color.Black Then
            c1TB.BackColor = Color.MediumSeaGreen
            c1TB.ForeColor = Color.Black
            b1TB.BackColor = Color.Black
            b1TB.ForeColor = Color.MediumSeaGreen
        End If
    End Sub

    Private Sub MissionPlanFilePage1()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "MISSION PLAN FILE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "FACTORY.FIL"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 120
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True

    End Sub

    Private Sub MissionPlanFilePage2()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "MISSION PLAN FILE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "ANW2SAMPL..NESA.MSFF"
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 220
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True
    End Sub

    Private Sub MissionPlanFilePage3()
        DisplayReset()
        SetVisibilityOFF()
        a1TB.Text = "SELECT STATION /"
        a1TB.Width = a1TB.TextLength * 8
        b6PB.BackgroundImage = My.Resources.LeftAndRight
        b6PB.Location = New Point(a1TB.Location.X + a1TB.Width, a1TB.Location.Y)
        b6PB.Height = 13
        b6PB.Width = 16
        a2TB.Text = "SCROLL PAGE"
        a2TB.Location = New Point(b6PB.Location.X + b6PB.Width, a1TB.Location.Y)
        a2TB.Width = a2TB.TextLength * 8
        a2TB.Visible = True
        b6PB.Visible = True
        a1TB.Visible = True
        
        d1TB.Text = "117G1"
        d3TB.Text = "117G2"
        d4TB.Text = "117G3"
        d1TB.BackColor = Color.Black
        d1TB.ForeColor = Color.MediumSeaGreen
        d1TB.Location = New Point(a1TB.Location.X, a1TB.Location.Y + 18)
        d1TB.Visible = True
        d3TB.Location = New Point(a1TB.Location.X, d1TB.Location.Y + 18)
        d3TB.Visible = True
        d4TB.Location = New Point(a1TB.Location.X, d3TB.Location.Y + 18)
        d4TB.Visible = True

        b7PB.BackgroundImage = My.Resources.scrollbarFull
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.Visible = True



    End Sub

    Private Sub ActivateMissionPlan()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "ACTIVATE PLAN"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "YES"
        PositionAndHighlight()

        c1TB.Visible = True


        d1TB.Text = "PRESS CLR / ENT TO EXIT"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub MissionPlanLoading()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "FACTORY.FIL"
        b1TB.Width = 250
        b1TB.Visible = True

        d1TB.Text = "PRESS CLR TO CANCEL"
        d1TB.Width = 250
        d1TB.Visible = True

        timeItTakes = 3 'sets the progressbar to 3 sec
        ShowProgressbar()

    End Sub

    Private Sub MissionPlanComplete()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "PLAN COMPLETE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "FACTORY.FIL"
        c1TB.Width = 250
        c1TB.Visible = True

        d1TB.Text = "PRESS CLR / ENT TO EXIT"
        d1TB.Width = 250
        d1TB.Visible = True

    End Sub

    Private Sub SelectStationScrollDown()
        If d1TB.BackColor = Color.Black Then
            d1TB.BackColor = Color.MediumSeaGreen
            d1TB.ForeColor = Color.Black
            d3TB.BackColor = Color.Black
            d3TB.ForeColor = Color.MediumSeaGreen
        ElseIf d3TB.BackColor = Color.Black Then
            d3TB.BackColor = Color.MediumSeaGreen
            d3TB.ForeColor = Color.Black
            d4TB.BackColor = Color.Black
            d4TB.ForeColor = Color.MediumSeaGreen
        End If
    End Sub 'used in mission plans to scroll the stations

    Private Sub SelectStationScrollUp()
        If d4TB.BackColor = Color.Black Then
            d4TB.BackColor = Color.MediumSeaGreen
            d4TB.ForeColor = Color.Black
            d3TB.BackColor = Color.Black
            d3TB.ForeColor = Color.MediumSeaGreen
        ElseIf d3TB.BackColor = Color.Black Then
            d3TB.BackColor = Color.MediumSeaGreen
            d3TB.ForeColor = Color.Black
            d1TB.BackColor = Color.Black
            d1TB.ForeColor = Color.MediumSeaGreen
        End If
    End Sub 'used in mission plans to scroll the stations

    Private Sub CheckMissionArray()

        For i = 0 To 98
            If missionLoaded(i) = "" Then
                missionLoaded(i) = c1TB.Text
                missionPlanDateTime(i) = Now

                Exit For
            End If
        Next

    End Sub

    Private Sub MissionHistoryDisplay()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        If missionLoaded(0) = "" Then
            b1TB.Text = "PLAN:    EMPTY"
            c1TB.Text = "TIME:   "
        Else
            b1TB.Text = "PLAN:   " + missionLoaded(0)
            c1TB.Text = "TIME:   " + missionPlanDateTime(0).ToString("M-dd-yy") + "   " + missionPlanDateTime(0).ToUniversalTime.ToString("hh:mm:ss")
        End If
        b1TB.Width = 250
        b1TB.TextAlign = HorizontalAlignment.Left
        b1TB.Visible = True


        c1TB.Width = 250
        c1TB.TextAlign = HorizontalAlignment.Left
        c1TB.Visible = True

        d1TB.Text = Now.ToString("MM/yy")
        d1TB.Width = 38
        d1TB.Visible = True

        b6PB.Location = New Point(422, 200) 'relocates b6PB for use as up/dn arrows
        b6PB.Height = 6
        b6PB.Width = 28
        b6PB.BackgroundImage = My.Resources.UpAndDown
        b6PB.Visible = True
        d3TB.Text = "TO SCROLL"
        d3TB.Width = d3TB.TextLength * 8
        d3TB.Location = New Point(446, 198)
        d3TB.Visible = True
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False


    End Sub

    Private Sub NetworkOptionsBasePageLoad()
        NormalTopPage()

        b1TB.Text = "SEND PING"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.Width = b1TB.TextLength * 10.5
        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.Text = "INTERFACES"
        c1TB.Font = b1TB.Font
        c1TB.Width = c1TB.TextLength * 10.5
        c1TB.TextAlign = HorizontalAlignment.Left
        c1TB.Location = New Point(c1TB.Location.X, c1TB.Location.Y - 2)
        d1TB.Text = "KEYCHAIN VERIFICATION"
        d1TB.Font = b1TB.Font
        d1TB.Width = d1TB.TextLength * 9.5
        d1TB.TextAlign = HorizontalAlignment.Left
        d1TB.Location = New Point(d1TB.Location.X, d1TB.Location.Y - 4)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True
        c1TB.Visible = True
        d1TB.Visible = True

        b7PB.BackgroundImage = My.Resources.scrollbarFull
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.Visible = True
    End Sub

    Private Sub SendPingPage()
        NormalTopPage()

        b1TB.Text = "PING BY"
        b1TB.Visible = True
        b1TB.Width = 250

        c1TB.Text = "HOST NAME"
        c1TB.Width = c1TB.TextLength * 12
        c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True


    End Sub

    Private Sub NormalTopPage()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True
    End Sub 'resets the display, sets visibility off and displays the top row

    Private Sub PingScroll()
        If c1TB.Text = "HOST NAME" Then
            c1TB.Text = "IP ADDRESS"
        ElseIf c1TB.Text = "IP ADDRESS" Then
            c1TB.Text = "HOST NAME"
        End If
        c1TB.Width = c1TB.TextLength * 12
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
    End Sub

    Private Sub PingByHostName()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "SELECT HOST / "
        a1TB.Width = a1TB.TextLength * 8
        a1TB.Visible = True
        ShowToScrollEntToCont()
        b6PB.Location = New Point(a1TB.Location.X + a1TB.Width, a1TB.Location.Y + 4)
        a2TB.Text = "SCROLL PAGE"
        a2TB.Width = a2TB.TextLength * 8
        a2TB.Location = New Point(b6PB.Location.X + b6PB.Width, a1TB.Location.Y)
        a2TB.Visible = True

        b1TB.Text = "PC1"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.Width = b1TB.TextLength * 11
        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.Text = "PC2"
        c1TB.Font = b1TB.Font
        c1TB.Width = c1TB.TextLength * 11
        c1TB.TextAlign = HorizontalAlignment.Left
        c1TB.Location = New Point(c1TB.Location.X, c1TB.Location.Y - 2)
        d1TB.Text = "RADIO1"
        d1TB.Font = b1TB.Font
        d1TB.Width = d1TB.TextLength * 11
        d1TB.TextAlign = HorizontalAlignment.Left
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 4)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True
        c1TB.Visible = True
        d1TB.Visible = True

        ipAddress = "fixed"

        b7PB.BackgroundImage = My.Resources.scrollbarFull
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.Visible = True



    End Sub

    Private Sub PingByIP()
        NormalTopPage()
        b1TB.Text = "IP ADDRESS"
        b1TB.Width = 250
        b1TB.Visible = True

        CreateIPTextboxes()

        ip1.Location = New Point(415, 178)
        ip2.Location = New Point(ip1.Location.X + ip1.Width, 178)
        ip3.Location = New Point(ip2.Location.X + ip2.Width, 178)
        ip4.Location = New Point(ip3.Location.X + ip3.Width, 178)
        ip5.Location = New Point(ip4.Location.X + ip4.Width, 178)
        ip6.Location = New Point(ip5.Location.X + ip5.Width, 178)
        ip7.Location = New Point(ip6.Location.X + ip6.Width, 178)
        ip8.Location = New Point(ip7.Location.X + ip7.Width, 178)
        ip9.Location = New Point(ip8.Location.X + ip8.Width, 178)
        ip10.Location = New Point(ip9.Location.X + ip9.Width, 178)
        ip11.Location = New Point(ip10.Location.X + ip10.Width, 178)
        ip12.Location = New Point(ip11.Location.X + ip11.Width, 178)
        ip13.Location = New Point(ip12.Location.X + ip12.Width, 178)
        ip14.Location = New Point(ip13.Location.X + ip13.Width, 178)
        ip15.Location = New Point(ip14.Location.X + ip14.Width, 178)


        ip1.Visible = True
        ip2.Visible = True
        ip3.Visible = True
        ip4.Visible = True
        ip5.Visible = True
        ip6.Visible = True
        ip7.Visible = True
        ip8.Visible = True
        ip9.Visible = True
        ip10.Visible = True
        ip11.Visible = True
        ip12.Visible = True
        ip13.Visible = True
        ip14.Visible = True
        ip15.Visible = True

        MyCreateIPboxes()


        d1TB.Text = "ENTER IP ADDRESS TO PING"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub PingInProgress()

        If ipAddress = "fixed" Then 'if we come from the host names screen, we fix the ip address. Otherwise, we read and store the address.
            ipAddress = "192.168.001.101"
        Else
            StoreIPaddress()
        End If


        NormalTopPage()
        b1TB.Text = "PING IN PROGRESS"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = ". . ."
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "CLR TO ABORT"
        d1TB.Width = 250
        d1TB.Visible = True

        If ipAddress = "000.000.000.000" Then
            timeItTakes = 10
        Else
            timeItTakes = 4 'delay time before next screen
        End If

        MyCreateIPboxes()
        MyTimerSetup()

        
    End Sub

    Private Sub PingSuccess()
        NormalTopPage()
        If ipAddress = "000.000.000.000" Then
            b1TB.Text = "NO RESPONSE"
        Else
            b1TB.Text = "SUCCESS 570 MSEC"
        End If

        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = ipAddress
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True


    End Sub

    Private Sub CreateIPTextboxes()


        ip1.Visible = False
        Me.Controls.Add(ip1)
        ip1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip1.TextAlign = HorizontalAlignment.Center
        ip1.Text = "0"
        ip1.Size = New Size(12, 19)
        ip1.ForeColor = Color.MediumSeaGreen
        ip1.BackColor = Color.Black
        ip1.BorderStyle = BorderStyle.None
        ip1.BringToFront()

        ip2.Visible = False
        Me.Controls.Add(ip2)
        ip2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip2.TextAlign = HorizontalAlignment.Center
        ip2.Text = "0"
        ip2.Size = New Size(12, 19)
        SetBackGreen(ip2)
        ip2.BorderStyle = BorderStyle.None
        ip2.BringToFront()

        If ml3 = "ike timeout" Then
            Exit Sub
        End If

        ip3.Visible = False
        Me.Controls.Add(ip3)
        ip3.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip3.TextAlign = HorizontalAlignment.Center
        ip3.Text = "0"
        ip3.Size = New Size(12, 19)
        SetBackGreen(ip3)
        ip3.BorderStyle = BorderStyle.None
        ip3.BringToFront()

        ip4.Visible = False
        Me.Controls.Add(ip4)
        ip4.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip4.TextAlign = HorizontalAlignment.Center
        ip4.Text = "."
        ip4.Size = New Size(12, 19)
        SetBackGreen(ip4)
        ip4.BorderStyle = BorderStyle.None
        ip4.BringToFront()

        If ml3 = "gps sleep cycle" Then
            Exit Sub
        End If


        ip5.Visible = False
        Me.Controls.Add(ip5)
        ip5.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip5.TextAlign = HorizontalAlignment.Center
        ip5.Text = "0"
        ip5.Size = New Size(12, 19)
        SetBackGreen(ip5)
        ip5.BorderStyle = BorderStyle.None
        ip5.BringToFront()

        ip6.Visible = False
        Me.Controls.Add(ip6)
        ip6.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip6.TextAlign = HorizontalAlignment.Center
        ip6.Text = "0"
        ip6.Size = New Size(12, 19)
        SetBackGreen(ip6)
        ip6.BorderStyle = BorderStyle.None
        ip6.BringToFront()

        ip7.Visible = False
        Me.Controls.Add(ip7)
        ip7.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip7.TextAlign = HorizontalAlignment.Center
        ip7.Text = "0"
        ip7.Size = New Size(12, 19)
        SetBackGreen(ip7)
        ip7.BorderStyle = BorderStyle.None
        ip7.BringToFront()

        ip8.Visible = False
        Me.Controls.Add(ip8)
        ip8.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip8.TextAlign = HorizontalAlignment.Center
        ip8.Text = "."
        ip8.Size = New Size(12, 19)
        SetBackGreen(ip8)
        ip8.BorderStyle = BorderStyle.None
        ip8.BringToFront()

        ip9.Visible = False
        Me.Controls.Add(ip9)
        ip9.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip9.TextAlign = HorizontalAlignment.Center
        ip9.Text = "0"
        ip9.Size = New Size(12, 19)
        SetBackGreen(ip9)
        ip9.BorderStyle = BorderStyle.None
        ip9.BringToFront()

        ip10.Visible = False
        Me.Controls.Add(ip10)
        ip10.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip10.TextAlign = HorizontalAlignment.Center
        ip10.Text = "0"
        ip10.Size = New Size(12, 19)
        SetBackGreen(ip10)
        ip10.BorderStyle = BorderStyle.None
        ip10.BringToFront()

        ip11.Visible = False
        Me.Controls.Add(ip11)
        ip11.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip11.TextAlign = HorizontalAlignment.Center
        ip11.Text = "0"
        ip11.Size = New Size(12, 19)
        SetBackGreen(ip11)
        ip11.BorderStyle = BorderStyle.None
        ip11.BringToFront()

        ip12.Visible = False
        Me.Controls.Add(ip12)
        ip12.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip12.TextAlign = HorizontalAlignment.Center
        ip12.Text = "."
        ip12.Size = New Size(12, 19)
        SetBackGreen(ip12)
        ip12.BorderStyle = BorderStyle.None
        ip12.BringToFront()

        ip13.Visible = False
        Me.Controls.Add(ip13)
        ip13.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip13.TextAlign = HorizontalAlignment.Center
        ip13.Text = "0"
        ip13.Size = New Size(12, 19)
        SetBackGreen(ip13)
        ip13.BorderStyle = BorderStyle.None
        ip13.BringToFront()

        ip14.Visible = False
        Me.Controls.Add(ip14)
        ip14.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip14.TextAlign = HorizontalAlignment.Center
        ip14.Text = "0"
        ip14.Size = New Size(12, 19)
        SetBackGreen(ip14)
        ip14.BorderStyle = BorderStyle.None
        ip14.BringToFront()

        ip15.Visible = False
        Me.Controls.Add(ip15)
        ip15.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip15.TextAlign = HorizontalAlignment.Center
        ip15.Text = "0"
        ip15.Size = New Size(12, 19)
        SetBackGreen(ip15)
        ip15.BorderStyle = BorderStyle.None
        ip15.BringToFront()



    End Sub

    Private Sub StoreIPaddress()
        ipAddress = ip1.Text + ip2.Text + ip3.Text + ip4.Text + ip5.Text + ip6.Text + ip7.Text + ip8.Text + ip9.Text + ip10.Text + ip11.Text + ip12.Text + ip13.Text + ip14.Text + ip15.Text

    End Sub

    Private Sub PingAddressUP()
        If ip1.BackColor = Color.Black Then
            If ip1.Text = "0" Then
                ip1.Text = "1"
            ElseIf ip1.Text = "1" Then
                ip1.Text = "2"
            ElseIf ip1.Text = "2" Then
                ip1.Text = "3"
            ElseIf ip1.Text = "3" Then
                ip1.Text = "4"
            ElseIf ip1.Text = "4" Then
                ip1.Text = "5"
            ElseIf ip1.Text = "5" Then
                ip1.Text = "6"
            ElseIf ip1.Text = "6" Then
                ip1.Text = "7"
            ElseIf ip1.Text = "7" Then
                ip1.Text = "8"
            ElseIf ip1.Text = "8" Then
                ip1.Text = "9"
            End If

        ElseIf ip2.BackColor = Color.Black Then
            If ip2.Text = "0" Then
                ip2.Text = "1"
            ElseIf ip2.Text = "1" Then
                ip2.Text = "2"
            ElseIf ip2.Text = "2" Then
                ip2.Text = "3"
            ElseIf ip2.Text = "3" Then
                ip2.Text = "4"
            ElseIf ip2.Text = "4" Then
                ip2.Text = "5"
            ElseIf ip2.Text = "5" Then
                ip2.Text = "6"
            ElseIf ip2.Text = "6" Then
                ip2.Text = "7"
            ElseIf ip2.Text = "7" Then
                ip2.Text = "8"
            ElseIf ip2.Text = "8" Then
                ip2.Text = "9"
            End If

        ElseIf ip3.BackColor = Color.Black Then
            If ip3.Text = "0" Then
                ip3.Text = "1"
            ElseIf ip3.Text = "1" Then
                ip3.Text = "2"
            ElseIf ip3.Text = "2" Then
                ip3.Text = "3"
            ElseIf ip3.Text = "3" Then
                ip3.Text = "4"
            ElseIf ip3.Text = "4" Then
                ip3.Text = "5"
            ElseIf ip3.Text = "5" Then
                ip3.Text = "6"
            ElseIf ip3.Text = "6" Then
                ip3.Text = "7"
            ElseIf ip3.Text = "7" Then
                ip3.Text = "8"
            ElseIf ip3.Text = "8" Then
                ip3.Text = "9"
            End If

        ElseIf ip5.BackColor = Color.Black Then
            If ip5.Text = "0" Then
                ip5.Text = "1"
            ElseIf ip5.Text = "1" Then
                ip5.Text = "2"
            ElseIf ip5.Text = "2" Then
                ip5.Text = "3"
            ElseIf ip5.Text = "3" Then
                ip5.Text = "4"
            ElseIf ip5.Text = "4" Then
                ip5.Text = "5"
            ElseIf ip5.Text = "5" Then
                ip5.Text = "6"
            ElseIf ip5.Text = "6" Then
                ip5.Text = "7"
            ElseIf ip5.Text = "7" Then
                ip5.Text = "8"
            ElseIf ip5.Text = "8" Then
                ip5.Text = "9"
            End If

        ElseIf ip6.BackColor = Color.Black Then
            If ip6.Text = "0" Then
                ip6.Text = "1"
            ElseIf ip6.Text = "1" Then
                ip6.Text = "2"
            ElseIf ip6.Text = "2" Then
                ip6.Text = "3"
            ElseIf ip6.Text = "3" Then
                ip6.Text = "4"
            ElseIf ip6.Text = "4" Then
                ip6.Text = "5"
            ElseIf ip6.Text = "5" Then
                ip6.Text = "6"
            ElseIf ip6.Text = "6" Then
                ip6.Text = "7"
            ElseIf ip6.Text = "7" Then
                ip6.Text = "8"
            ElseIf ip6.Text = "8" Then
                ip6.Text = "9"
            End If

        ElseIf ip7.BackColor = Color.Black Then
            If ip7.Text = "0" Then
                ip7.Text = "1"
            ElseIf ip7.Text = "1" Then
                ip7.Text = "2"
            ElseIf ip7.Text = "2" Then
                ip7.Text = "3"
            ElseIf ip7.Text = "3" Then
                ip7.Text = "4"
            ElseIf ip7.Text = "4" Then
                ip7.Text = "5"
            ElseIf ip7.Text = "5" Then
                ip7.Text = "6"
            ElseIf ip7.Text = "6" Then
                ip7.Text = "7"
            ElseIf ip7.Text = "7" Then
                ip7.Text = "8"
            ElseIf ip7.Text = "8" Then
                ip7.Text = "9"
            End If

        ElseIf ip9.BackColor = Color.Black Then
            If ip9.Text = "0" Then
                ip9.Text = "1"
            ElseIf ip9.Text = "1" Then
                ip9.Text = "2"
            ElseIf ip9.Text = "2" Then
                ip9.Text = "3"
            ElseIf ip9.Text = "3" Then
                ip9.Text = "4"
            ElseIf ip9.Text = "4" Then
                ip9.Text = "5"
            ElseIf ip9.Text = "5" Then
                ip9.Text = "6"
            ElseIf ip9.Text = "6" Then
                ip9.Text = "7"
            ElseIf ip9.Text = "7" Then
                ip9.Text = "8"
            ElseIf ip9.Text = "8" Then
                ip9.Text = "9"
            End If

        ElseIf ip10.BackColor = Color.Black Then
            If ip10.Text = "0" Then
                ip10.Text = "1"
            ElseIf ip10.Text = "1" Then
                ip10.Text = "2"
            ElseIf ip10.Text = "2" Then
                ip10.Text = "3"
            ElseIf ip10.Text = "3" Then
                ip10.Text = "4"
            ElseIf ip10.Text = "4" Then
                ip10.Text = "5"
            ElseIf ip10.Text = "5" Then
                ip10.Text = "6"
            ElseIf ip10.Text = "6" Then
                ip10.Text = "7"
            ElseIf ip10.Text = "7" Then
                ip10.Text = "8"
            ElseIf ip10.Text = "8" Then
                ip10.Text = "9"
            End If

        ElseIf ip11.BackColor = Color.Black Then
            If ip11.Text = "0" Then
                ip11.Text = "1"
            ElseIf ip11.Text = "1" Then
                ip11.Text = "2"
            ElseIf ip11.Text = "2" Then
                ip11.Text = "3"
            ElseIf ip11.Text = "3" Then
                ip11.Text = "4"
            ElseIf ip11.Text = "4" Then
                ip11.Text = "5"
            ElseIf ip11.Text = "5" Then
                ip11.Text = "6"
            ElseIf ip11.Text = "6" Then
                ip11.Text = "7"
            ElseIf ip11.Text = "7" Then
                ip11.Text = "8"
            ElseIf ip11.Text = "8" Then
                ip11.Text = "9"
            End If

        ElseIf ip13.BackColor = Color.Black Then
            If ip13.Text = "0" Then
                ip13.Text = "1"
            ElseIf ip13.Text = "1" Then
                ip13.Text = "2"
            ElseIf ip13.Text = "2" Then
                ip13.Text = "3"
            ElseIf ip13.Text = "3" Then
                ip13.Text = "4"
            ElseIf ip13.Text = "4" Then
                ip13.Text = "5"
            ElseIf ip13.Text = "5" Then
                ip13.Text = "6"
            ElseIf ip13.Text = "6" Then
                ip13.Text = "7"
            ElseIf ip13.Text = "7" Then
                ip13.Text = "8"
            ElseIf ip13.Text = "8" Then
                ip13.Text = "9"
            End If

        ElseIf ip14.BackColor = Color.Black Then
            If ip14.Text = "0" Then
                ip14.Text = "1"
            ElseIf ip14.Text = "1" Then
                ip14.Text = "2"
            ElseIf ip14.Text = "2" Then
                ip14.Text = "3"
            ElseIf ip14.Text = "3" Then
                ip14.Text = "4"
            ElseIf ip14.Text = "4" Then
                ip14.Text = "5"
            ElseIf ip14.Text = "5" Then
                ip14.Text = "6"
            ElseIf ip14.Text = "6" Then
                ip14.Text = "7"
            ElseIf ip14.Text = "7" Then
                ip14.Text = "8"
            ElseIf ip14.Text = "8" Then
                ip14.Text = "9"
            End If

        ElseIf ip15.BackColor = Color.Black Then
            If ip15.Text = "0" Then
                ip15.Text = "1"
            ElseIf ip15.Text = "1" Then
                ip15.Text = "2"
            ElseIf ip15.Text = "2" Then
                ip15.Text = "3"
            ElseIf ip15.Text = "3" Then
                ip15.Text = "4"
            ElseIf ip15.Text = "4" Then
                ip15.Text = "5"
            ElseIf ip15.Text = "5" Then
                ip15.Text = "6"
            ElseIf ip15.Text = "6" Then
                ip15.Text = "7"
            ElseIf ip15.Text = "7" Then
                ip15.Text = "8"
            ElseIf ip15.Text = "8" Then
                ip15.Text = "9"
            End If

        End If
    End Sub

    Private Sub PingAddressDown()

        If ip1.BackColor = Color.Black Then
            If ip1.Text = "9" Then
                ip1.Text = "8"
            ElseIf ip1.Text = "8" Then
                ip1.Text = "7"
            ElseIf ip1.Text = "7" Then
                ip1.Text = "6"
            ElseIf ip1.Text = "6" Then
                ip1.Text = "5"
            ElseIf ip1.Text = "5" Then
                ip1.Text = "4"
            ElseIf ip1.Text = "4" Then
                ip1.Text = "3"
            ElseIf ip1.Text = "3" Then
                ip1.Text = "2"
            ElseIf ip1.Text = "2" Then
                ip1.Text = "1"
            ElseIf ip1.Text = "1" Then
                ip1.Text = "0"
            End If

        ElseIf ip2.BackColor = Color.Black Then
            If ip2.Text = "9" Then
                ip2.Text = "8"
            ElseIf ip2.Text = "8" Then
                ip2.Text = "7"
            ElseIf ip2.Text = "7" Then
                ip2.Text = "6"
            ElseIf ip2.Text = "6" Then
                ip2.Text = "5"
            ElseIf ip2.Text = "5" Then
                ip2.Text = "4"
            ElseIf ip2.Text = "4" Then
                ip2.Text = "3"
            ElseIf ip2.Text = "3" Then
                ip2.Text = "2"
            ElseIf ip2.Text = "2" Then
                ip2.Text = "1"
            ElseIf ip2.Text = "1" Then
                ip2.Text = "0"
            End If

        ElseIf ip3.BackColor = Color.Black Then
            If ip3.Text = "9" Then
                ip3.Text = "8"
            ElseIf ip3.Text = "8" Then
                ip3.Text = "7"
            ElseIf ip3.Text = "7" Then
                ip3.Text = "6"
            ElseIf ip3.Text = "6" Then
                ip3.Text = "5"
            ElseIf ip3.Text = "5" Then
                ip3.Text = "4"
            ElseIf ip3.Text = "4" Then
                ip3.Text = "3"
            ElseIf ip3.Text = "3" Then
                ip3.Text = "2"
            ElseIf ip3.Text = "2" Then
                ip3.Text = "1"
            ElseIf ip3.Text = "1" Then
                ip3.Text = "0"
            End If

        ElseIf ip5.BackColor = Color.Black Then
            If ip5.Text = "9" Then
                ip5.Text = "8"
            ElseIf ip5.Text = "8" Then
                ip5.Text = "7"
            ElseIf ip5.Text = "7" Then
                ip5.Text = "6"
            ElseIf ip5.Text = "6" Then
                ip5.Text = "5"
            ElseIf ip5.Text = "5" Then
                ip5.Text = "4"
            ElseIf ip5.Text = "4" Then
                ip5.Text = "3"
            ElseIf ip5.Text = "3" Then
                ip5.Text = "2"
            ElseIf ip5.Text = "2" Then
                ip5.Text = "1"
            ElseIf ip5.Text = "1" Then
                ip5.Text = "0"
            End If

        ElseIf ip6.BackColor = Color.Black Then
            If ip6.Text = "9" Then
                ip6.Text = "8"
            ElseIf ip6.Text = "8" Then
                ip6.Text = "7"
            ElseIf ip6.Text = "7" Then
                ip6.Text = "6"
            ElseIf ip6.Text = "6" Then
                ip6.Text = "5"
            ElseIf ip6.Text = "5" Then
                ip6.Text = "4"
            ElseIf ip6.Text = "4" Then
                ip6.Text = "3"
            ElseIf ip6.Text = "3" Then
                ip6.Text = "2"
            ElseIf ip6.Text = "2" Then
                ip6.Text = "1"
            ElseIf ip6.Text = "1" Then
                ip6.Text = "0"
            End If

        ElseIf ip7.BackColor = Color.Black Then
            If ip7.Text = "9" Then
                ip7.Text = "8"
            ElseIf ip7.Text = "8" Then
                ip7.Text = "7"
            ElseIf ip7.Text = "7" Then
                ip7.Text = "6"
            ElseIf ip7.Text = "6" Then
                ip7.Text = "5"
            ElseIf ip7.Text = "5" Then
                ip7.Text = "4"
            ElseIf ip7.Text = "4" Then
                ip7.Text = "3"
            ElseIf ip7.Text = "3" Then
                ip7.Text = "2"
            ElseIf ip7.Text = "2" Then
                ip7.Text = "1"
            ElseIf ip7.Text = "1" Then
                ip7.Text = "0"
            End If

        ElseIf ip9.BackColor = Color.Black Then
            If ip9.Text = "9" Then
                ip9.Text = "8"
            ElseIf ip9.Text = "8" Then
                ip9.Text = "7"
            ElseIf ip9.Text = "7" Then
                ip9.Text = "6"
            ElseIf ip9.Text = "6" Then
                ip9.Text = "5"
            ElseIf ip9.Text = "5" Then
                ip9.Text = "4"
            ElseIf ip9.Text = "4" Then
                ip9.Text = "3"
            ElseIf ip9.Text = "3" Then
                ip9.Text = "2"
            ElseIf ip9.Text = "2" Then
                ip9.Text = "1"
            ElseIf ip9.Text = "1" Then
                ip9.Text = "0"
            End If
        
        ElseIf ip10.BackColor = Color.Black Then
            If ip10.Text = "9" Then
                ip10.Text = "8"
            ElseIf ip10.Text = "8" Then
                ip10.Text = "7"
            ElseIf ip10.Text = "7" Then
                ip10.Text = "6"
            ElseIf ip10.Text = "6" Then
                ip10.Text = "5"
            ElseIf ip10.Text = "5" Then
                ip10.Text = "4"
            ElseIf ip10.Text = "4" Then
                ip10.Text = "3"
            ElseIf ip10.Text = "3" Then
                ip10.Text = "2"
            ElseIf ip10.Text = "2" Then
                ip10.Text = "1"
            ElseIf ip10.Text = "1" Then
                ip10.Text = "0"
            End If

        ElseIf ip11.BackColor = Color.Black Then
            If ip11.Text = "9" Then
                ip11.Text = "8"
            ElseIf ip11.Text = "8" Then
                ip11.Text = "7"
            ElseIf ip11.Text = "7" Then
                ip11.Text = "6"
            ElseIf ip11.Text = "6" Then
                ip11.Text = "5"
            ElseIf ip11.Text = "5" Then
                ip11.Text = "4"
            ElseIf ip11.Text = "4" Then
                ip11.Text = "3"
            ElseIf ip11.Text = "3" Then
                ip11.Text = "2"
            ElseIf ip11.Text = "2" Then
                ip11.Text = "1"
            ElseIf ip11.Text = "1" Then
                ip11.Text = "0"
            End If

        ElseIf ip13.BackColor = Color.Black Then
            If ip13.Text = "9" Then
                ip13.Text = "8"
            ElseIf ip13.Text = "8" Then
                ip13.Text = "7"
            ElseIf ip13.Text = "7" Then
                ip13.Text = "6"
            ElseIf ip13.Text = "6" Then
                ip13.Text = "5"
            ElseIf ip13.Text = "5" Then
                ip13.Text = "4"
            ElseIf ip13.Text = "4" Then
                ip13.Text = "3"
            ElseIf ip13.Text = "3" Then
                ip13.Text = "2"
            ElseIf ip13.Text = "2" Then
                ip13.Text = "1"
            ElseIf ip13.Text = "1" Then
                ip13.Text = "0"
            End If

        ElseIf ip14.BackColor = Color.Black Then
            If ip14.Text = "9" Then
                ip14.Text = "8"
            ElseIf ip14.Text = "8" Then
                ip14.Text = "7"
            ElseIf ip14.Text = "7" Then
                ip14.Text = "6"
            ElseIf ip14.Text = "6" Then
                ip14.Text = "5"
            ElseIf ip14.Text = "5" Then
                ip14.Text = "4"
            ElseIf ip14.Text = "4" Then
                ip14.Text = "3"
            ElseIf ip14.Text = "3" Then
                ip14.Text = "2"
            ElseIf ip14.Text = "2" Then
                ip14.Text = "1"
            ElseIf ip14.Text = "1" Then
                ip14.Text = "0"
            End If

        ElseIf ip15.BackColor = Color.Black Then
            If ip15.Text = "9" Then
                ip15.Text = "8"
            ElseIf ip15.Text = "8" Then
                ip15.Text = "7"
            ElseIf ip15.Text = "7" Then
                ip15.Text = "6"
            ElseIf ip15.Text = "6" Then
                ip15.Text = "5"
            ElseIf ip15.Text = "5" Then
                ip15.Text = "4"
            ElseIf ip15.Text = "4" Then
                ip15.Text = "3"
            ElseIf ip15.Text = "3" Then
                ip15.Text = "2"
            ElseIf ip15.Text = "2" Then
                ip15.Text = "1"
            ElseIf ip15.Text = "1" Then
                ip15.Text = "0"
            End If

        End If


    End Sub

    Private Sub IPdigitRight()
        If ip1.BackColor = Color.Black Then 'moves the cursor to the right
            ip1.BackColor = Color.MediumSeaGreen
            ip1.ForeColor = Color.Black
            ip2.BackColor = Color.Black
            ip2.ForeColor = Color.MediumSeaGreen
        ElseIf ip2.BackColor = Color.Black Then
            ip2.BackColor = Color.MediumSeaGreen
            ip2.ForeColor = Color.Black
            ip3.BackColor = Color.Black
            ip3.ForeColor = Color.MediumSeaGreen
        ElseIf ip3.BackColor = Color.Black Then
            ip3.BackColor = Color.MediumSeaGreen
            ip3.ForeColor = Color.Black
            If ml3 = "gps sleep cycle" Then
                ip4.BackColor = Color.Black
                ip4.ForeColor = Color.MediumSeaGreen
                Exit Sub
            Else
                ip5.BackColor = Color.Black
                ip5.ForeColor = Color.MediumSeaGreen
            End If
        ElseIf ip5.BackColor = Color.Black Then
            ip5.BackColor = Color.MediumSeaGreen
            ip5.ForeColor = Color.Black
            ip6.BackColor = Color.Black
            ip6.ForeColor = Color.MediumSeaGreen
        ElseIf ip6.BackColor = Color.Black Then
            ip6.BackColor = Color.MediumSeaGreen
            ip6.ForeColor = Color.Black
            ip7.BackColor = Color.Black
            ip7.ForeColor = Color.MediumSeaGreen
        ElseIf ip7.BackColor = Color.Black Then
            ip7.BackColor = Color.MediumSeaGreen
            ip7.ForeColor = Color.Black
            ip9.BackColor = Color.Black
            ip9.ForeColor = Color.MediumSeaGreen
        ElseIf ip9.BackColor = Color.Black Then
            ip9.BackColor = Color.MediumSeaGreen
            ip9.ForeColor = Color.Black
            ip10.BackColor = Color.Black
            ip10.ForeColor = Color.MediumSeaGreen
        ElseIf ip10.BackColor = Color.Black Then
            ip10.BackColor = Color.MediumSeaGreen
            ip10.ForeColor = Color.Black
            ip11.BackColor = Color.Black
            ip11.ForeColor = Color.MediumSeaGreen
        ElseIf ip11.BackColor = Color.Black Then
            ip11.BackColor = Color.MediumSeaGreen
            ip11.ForeColor = Color.Black
            ip13.BackColor = Color.Black
            ip13.ForeColor = Color.MediumSeaGreen
        ElseIf ip13.BackColor = Color.Black Then
            ip13.BackColor = Color.MediumSeaGreen
            ip13.ForeColor = Color.Black
            ip14.BackColor = Color.Black
            ip14.ForeColor = Color.MediumSeaGreen
        ElseIf ip14.BackColor = Color.Black Then
            ip14.BackColor = Color.MediumSeaGreen
            ip14.ForeColor = Color.Black
            ip15.BackColor = Color.Black
            ip15.ForeColor = Color.MediumSeaGreen

        End If
    End Sub

    Private Sub IPdigitLeft()

        If ip15.BackColor = Color.Black Then 'moves the cursor to the left
            ip15.BackColor = Color.MediumSeaGreen
            ip15.ForeColor = Color.Black
            ip14.BackColor = Color.Black
            ip14.ForeColor = Color.MediumSeaGreen
        ElseIf ip14.BackColor = Color.Black Then
            ip14.BackColor = Color.MediumSeaGreen
            ip14.ForeColor = Color.Black
            ip13.BackColor = Color.Black
            ip13.ForeColor = Color.MediumSeaGreen
        ElseIf ip13.BackColor = Color.Black Then
            ip13.BackColor = Color.MediumSeaGreen
            ip13.ForeColor = Color.Black
            ip11.BackColor = Color.Black
            ip11.ForeColor = Color.MediumSeaGreen
        ElseIf ip11.BackColor = Color.Black Then
            ip11.BackColor = Color.MediumSeaGreen
            ip11.ForeColor = Color.Black
            ip10.BackColor = Color.Black
            ip10.ForeColor = Color.MediumSeaGreen
        ElseIf ip10.BackColor = Color.Black Then
            ip10.BackColor = Color.MediumSeaGreen
            ip10.ForeColor = Color.Black
            ip9.BackColor = Color.Black
            ip9.ForeColor = Color.MediumSeaGreen
        ElseIf ip9.BackColor = Color.Black Then
            ip9.BackColor = Color.MediumSeaGreen
            ip9.ForeColor = Color.Black
            ip7.BackColor = Color.Black
            ip7.ForeColor = Color.MediumSeaGreen
        ElseIf ip7.BackColor = Color.Black Then
            ip7.BackColor = Color.MediumSeaGreen
            ip7.ForeColor = Color.Black
            ip6.BackColor = Color.Black
            ip6.ForeColor = Color.MediumSeaGreen
        ElseIf ip6.BackColor = Color.Black Then 'moves the cursor to the left
            ip6.BackColor = Color.MediumSeaGreen
            ip6.ForeColor = Color.Black
            ip5.BackColor = Color.Black
            ip5.ForeColor = Color.MediumSeaGreen
        ElseIf ip5.BackColor = Color.Black Then
            ip5.BackColor = Color.MediumSeaGreen
            ip5.ForeColor = Color.Black
            ip3.BackColor = Color.Black
            ip3.ForeColor = Color.MediumSeaGreen
        ElseIf ip4.BackColor = Color.Black Then
            ip4.BackColor = Color.MediumSeaGreen
            ip4.ForeColor = Color.Black
            ip3.BackColor = Color.Black
            ip3.ForeColor = Color.MediumSeaGreen
        ElseIf ip3.BackColor = Color.Black Then
            ip3.BackColor = Color.MediumSeaGreen
            ip3.ForeColor = Color.Black
            ip2.BackColor = Color.Black
            ip2.ForeColor = Color.MediumSeaGreen
        ElseIf ip2.BackColor = Color.Black Then
            ip2.BackColor = Color.MediumSeaGreen
            ip2.ForeColor = Color.Black
            ip1.BackColor = Color.Black
            ip1.ForeColor = Color.MediumSeaGreen

        End If

    End Sub

    Private Sub InterfacesPage()
        NormalTopPage()
        b1TB.Text = "VIEW INTERFACE AND IP ADDRESS:"
        b1TB.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "RED ETH:                       192.168.0.3"
        c1TB.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Width = 250
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d3TB.Text = "TO SCROLL / "
        d3TB.Location = New Point(b6PB.Location.X + b6PB.Width, 198)
        d3TB.Width = d3TB.TextLength * 7
        d3TB.Visible = True
        b7PB.BackgroundImage = My.Resources.LeftAndRight
        b7PB.Location = New Point(d3TB.Location.X + d3TB.Width, 198)
        b7PB.Size = New Size(16, 13)
        b7PB.Visible = True
        d6TB.Text = "TOGGLES"
        d6TB.Width = d6TB.TextLength * 10
        d6TB.Location = New Point(b7PB.Location.X + 16, 198)
        d6TB.Visible = True



    End Sub

    Private Sub KeychainPage()
        NormalTopPage()
        b1TB.Text = "KEYCHAIN ENTRY NUM: "
        b1TB.Width = b1TB.TextLength * 10.5
        b1TB.Visible = True
        b2TB.Text = "1"
        b2TB.Location = New Point(a7TB.Location.X + 10, 158)
        b2TB.BackColor = Color.Black
        b2TB.ForeColor = Color.MediumSeaGreen
        b2TB.Width = b2TB.TextLength * 11
        b2TB.Visible = True



        c1TB.Text = keychain(1)
        c1TB.Width = 240
        c1TB.TextAlign = HorizontalAlignment.Right
        c1TB.Visible = True


        ShowToScrollEntToCont()
        d1TB.Visible = True


    End Sub

    Private Sub ChainGenerate()
        Dim storage As String = ""

        For i = 1 To 10
            For x = 1 To 16
                keychainDigit(x) = CInt(Int((15 * Rnd()) + 1))

                If keychainDigit(x) > 9 Then
                    Select Case keychainDigit(x)
                        Case "10"
                            storage = "a"
                        Case "11"
                            storage = "b"
                        Case "12"
                            storage = "c"
                        Case "13"
                            storage = "d"
                        Case "14"
                            storage = "e"
                        Case "15"
                            storage = "f"

                    End Select

                ElseIf keychainDigit(x) <= 9 Then
                    storage = CStr(keychainDigit(x))

                End If

                keychain(i) = keychain(i) + storage
            Next

        Next

    End Sub 'generates random hexadecimal numbers for the keychain

    Private Sub KeychainUp()
        If b2TB.BackColor = Color.Black Then
            If b2TB.Text = "9" Then
                b2TB.Text = "10"
            ElseIf b2TB.Text = "1" Then
                b2TB.Text = "2"
            ElseIf b2TB.Text = "2" Then
                b2TB.Text = "3"
            ElseIf b2TB.Text = "3" Then
                b2TB.Text = "4"
            ElseIf b2TB.Text = "4" Then
                b2TB.Text = "5"
            ElseIf b2TB.Text = "5" Then
                b2TB.Text = "6"
            ElseIf b2TB.Text = "6" Then
                b2TB.Text = "7"
            ElseIf b2TB.Text = "7" Then
                b2TB.Text = "8"
            ElseIf b2TB.Text = "8" Then
                b2TB.Text = "9"
            End If
        End If
        b2TB.Width = b2TB.TextLength * 11
        If b2TB.Text = "10" Then
            b2TB.Location = New Point(a7TB.Location.X, 158)
        Else
            b2TB.Location = New Point(a7TB.Location.X + 10, 158)
        End If
        KeychainHex()
    End Sub

    Private Sub KeychainHex()
        If b2TB.Text = "9" Then
            c1TB.Text = keychain(9)
        ElseIf b2TB.Text = "1" Then
            c1TB.Text = keychain(1)
        ElseIf b2TB.Text = "2" Then
            c1TB.Text = keychain(2)
        ElseIf b2TB.Text = "3" Then
            c1TB.Text = keychain(3)
        ElseIf b2TB.Text = "4" Then
            c1TB.Text = keychain(4)
        ElseIf b2TB.Text = "5" Then
            c1TB.Text = keychain(5)
        ElseIf b2TB.Text = "6" Then
            c1TB.Text = keychain(6)
        ElseIf b2TB.Text = "7" Then
            c1TB.Text = keychain(7)
        ElseIf b2TB.Text = "8" Then
            c1TB.Text = keychain(8)
        ElseIf b2TB.Text = "10" Then
            c1TB.Text = keychain(10)
        End If
    End Sub

    Private Sub KeychainDown()
        If b2TB.BackColor = Color.Black Then
            If b2TB.Text = "10" Then
                b2TB.Text = "9"
            ElseIf b2TB.Text = "9" Then
                b2TB.Text = "8"
            ElseIf b2TB.Text = "8" Then
                b2TB.Text = "7"
            ElseIf b2TB.Text = "7" Then
                b2TB.Text = "6"
            ElseIf b2TB.Text = "6" Then
                b2TB.Text = "5"
            ElseIf b2TB.Text = "5" Then
                b2TB.Text = "4"
            ElseIf b2TB.Text = "4" Then
                b2TB.Text = "3"
            ElseIf b2TB.Text = "3" Then
                b2TB.Text = "2"
            ElseIf b2TB.Text = "2" Then
                b2TB.Text = "1"
            End If
        End If
        b2TB.Width = b2TB.TextLength * 11
        If b2TB.Text = "10" Then
            b2TB.Location = New Point(a7TB.Location.X, 158)
        Else
            b2TB.Location = New Point(a7TB.Location.X + 10, 158)
        End If
        KeychainHex()
    End Sub

    Private Sub EnterNumber()

        If ml1 = "network options" And ml2 = "ping in progress" Or ml3 = "zeroize waveform" Or ml3 = "maintenance password" Or ml3 = "enter utc offset" Or ml3 = "system current date" Or ml3 = "system clock current time" Or ml3 = "sa custom ip" Or ml3 = "sa port" Or ml3 = "cot expiration" Or ml3 = "combat id" Or ml3 = "max retrans attempts" Or ml3 = "ike timeout" Or ml3 = "gps sleep cycle" Or ml3 = "port config ip address" Or ml3 = "port config peer ip address" Or ml3 = "port config gateway address" Or ml3 = "port config subnet mask" Then
            If ip1.BackColor = Color.Black Then
                If ml3 = "enter utc offset" Then 'bypass button push for UTC offset
                    If thisNum = "6" Or thisNum = "9" Then
                        If ip1.Text = "+" Then
                            ip1.Text = "-"
                        Else
                            ip1.Text = "+"
                        End If
                    End If
                Else
                    ip1.Text = numberPushed
                End If
            ElseIf ip2.BackColor = Color.Black Then
                ip2.Text = numberPushed
            ElseIf ip3.BackColor = Color.Black Then
                ip3.Text = numberPushed
            ElseIf ip4.BackColor = Color.Black Then
                ip4.Text = numberPushed
            ElseIf ip5.BackColor = Color.Black Then
                ip5.Text = numberPushed
            ElseIf ip6.BackColor = Color.Black Then
                ip6.Text = numberPushed
            ElseIf ip7.BackColor = Color.Black Then
                ip7.Text = numberPushed
            ElseIf ip8.BackColor = Color.Black Then
                ip8.Text = numberPushed
            ElseIf ip9.BackColor = Color.Black Then
                ip9.Text = numberPushed
            ElseIf ip10.BackColor = Color.Black Then
                ip10.Text = numberPushed
            ElseIf ip11.BackColor = Color.Black Then
                ip11.Text = numberPushed
            ElseIf ip12.BackColor = Color.Black Then
                ip12.Text = numberPushed
            ElseIf ip13.BackColor = Color.Black Then
                ip13.Text = numberPushed
            ElseIf ip14.BackColor = Color.Black Then
                ip14.Text = numberPushed
            ElseIf ip15.BackColor = Color.Black Then
                ip15.Text = numberPushed
            End If

        End If
    End Sub

    Private Sub RadioInfoTopMenu()

        NormalTopPage()

        b1TB.Text = "SYSTEM CLOCK"
        c1TB.Text = "BATTERY INFORMATION"
        d1TB.Text = "NETWORK STATUS"
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Font = New Font("Micosoft san serif", 11, FontStyle.Bold)
        c1TB.Font = New Font("Micosoft san serif", 11, FontStyle.Bold)
        d1TB.Font = New Font("Micosoft san serif", 11, FontStyle.Bold)
        b1TB.Width = b1TB.TextLength * 11.2
        b1TB.Location = New Point(b1TB.Location.X, b1TB.Location.Y - 1)
        c1TB.Width = b1TB.TextLength * 16.2
        c1TB.Location = New Point(c1TB.Location.X, c1TB.Location.Y - 2)
        d1TB.Width = b1TB.TextLength * 13
        d1TB.Location = New Point(d1TB.Location.X, d1TB.Location.Y - 3)
        b1TB.Visible = True
        c1TB.Visible = True
        d1TB.Visible = True
        b7PB.BackgroundImage = My.Resources.scrollbarFull
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.Visible = True
    End Sub

    Private Sub SystemClock()
        currentDateTime = Now

        NormalTopPage()
        b1TB.Text = "DATE:"
        c1TB.Text = "TIME:"
        b1TB.Width = 52
        c1TB.Width = 52
        b2TB.Location = New Point(b2TB.Location.X + 60, b2TB.Location.Y)
        b2TB.Text = currentDateTime.ToString("MM-dd-yy")
        c3TB.Location = New Point(b2TB.Location.X, c1TB.Location.Y)
        c3TB.Text = currentDateTime.ToUniversalTime.ToString("hh:mm:ss")
        c3TB.Width = b2TB.Width
        d1TB.Text = "ENT TO CONTINUE/CLR TO EXIT"
        d1TB.Width = 250
        b1TB.Visible = True
        c1TB.Visible = True
        b2TB.Visible = True
        c3TB.Visible = True
        d1TB.Visible = True

    End Sub

    Private Sub UTCoffset()
        NormalTopPage()
        b1TB.Text = "UTC OFFSET"
        b1TB.Width = 250
        c1TB.Text = "+00:00"
        d1TB.Text = "PRESS ENT TO CONTINUE"
        d1TB.Width = 250
        c1TB.Width = 250
        b1TB.Visible = True
        c1TB.Visible = True
        d1TB.Visible = True
    End Sub

    Private Sub BatteryVoltage()
        NormalTopPage()
        b1TB.Text = "VOLTAGE:"
        c1TB.Text = "STATUS:"
        b1TB.Width = 88
        c1TB.Width = 78
        b2TB.Location = New Point(b2TB.Location.X + 94, b2TB.Location.Y)
        b2TB.Text = "29.7V"
        c3TB.Location = New Point(b2TB.Location.X, c1TB.Location.Y)
        c3TB.Text = "NOMINAL"
        c3TB.Width = b2TB.Width
        d1TB.Text = "PRESS ENT TO CONTINUE"
        d1TB.Width = 250
        b1TB.Visible = True
        c1TB.Visible = True
        b2TB.Visible = True
        c3TB.Visible = True
        d1TB.Visible = True
    End Sub

    Private Sub HubCapacity()

        NormalTopPage()

        b1TB.Text = "HUB CAPACITY"

        b1TB.Width = 250

        Me.Controls.Add(tbBorder1)
        tbBorder1.BorderStyle = BorderStyle.None
        tbBorder1.AutoSize = False
        tbBorder1.Location = New Point(507 - (52), 180)
        tbBorder1.BackColor = Color.Black
        tbBorder1.Height = 13
        tbBorder1.Width = 104
        tbBorder1.Visible = True
        tbBorder1.BringToFront()

        Me.Controls.Add(tbBack)
        tbBack.AutoSize = False
        tbBack.BorderStyle = BorderStyle.None
        tbBack.BringToFront()
        tbBack.Width = 100
        tbBack.Height = 9
        tbBack.Location = New Point(507 - (50), 182)
        tbBack.BackColor = Color.MediumSeaGreen
        tbBack.Visible = True

        Me.Controls.Add(tbFront)
        tbFront.Visible = False
        tbFront.AutoSize = False
        tbFront.BorderStyle = BorderStyle.None
        tbFront.Width = 71
        tbFront.Height = 9
        tbFront.Location = New Point(507 - (50), 182)
        tbFront.BackColor = Color.Black
        tbFront.Visible = True
        tbFront.BringToFront()

        MyCreateProgressbar()

        d1TB.Text = "ESTIMATED DAYS REMAINING: 260"
        d1TB.Width = 250
        b1TB.Visible = True
        d1TB.Visible = True
    End Sub

    Private Sub NetworkStatus()
        NormalTopPage()
        b1TB.Text = "DATA PPP STATE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = pppState
        c1TB.Width = 250
        c1TB.Visible = True

        If pppState = "OFFLINE" Then
            d1TB.Text = "PRESS CLR / ENT TO EXIT"
        Else
            d1TB.Text = "ENT TO CONTINUE / CLR TO EXIT"
        End If
        d1TB.Width = 250
        d1TB.Visible = True


    End Sub

    Private Sub PPPipAddress()
        NormalTopPage()
        b1TB.Text = "IP ADDRESS"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = PPPAddress
        c1TB.Width = 250
        c1TB.Visible = True

        d1TB.Text = "ENT TO CONTINUE / CLR TO EXIT"
        d1TB.Width = 250
        d1TB.Visible = True

    End Sub

    Private Sub PeerIpAddress()
        NormalTopPage()
        b1TB.Text = "PEER IP ADDRESS"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = peerAddress
        c1TB.Width = 250
        c1TB.Visible = True

        d1TB.Text = "ENT TO CONTINUE / CLR TO EXIT"
        d1TB.Width = 250
        d1TB.Visible = True

        ml3 = "end"


    End Sub

    Private Sub RadioOptionsMenu()
        NormalTopPage()
        b1TB.Text = "RADIO SILENCE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = radioSilenceState
        c1TB.Width = c1TB.TextLength * 14
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True

    End Sub

    Private Sub FlashRon()
        Timer3.Enabled = True
        Timer3.Interval = 1000
        FlashRtimer()

    End Sub

    Private Sub FlashRoff()
        Timer3.Stop()
        radioSilenceState = "OFF"
        a1TB.Visible = True

    End Sub

    Private Sub FlashRtimer() Handles Timer3.Tick

        If formIsClosed = True Then 'checks to see if the main form is closed
            Exit Sub 'exits if form is closed
        End If


        If a1TB.Visible = True Then
            a1TB.Visible = False
        ElseIf a1TB.Visible = False Then
            a1TB.Visible = True
        End If


    End Sub

    Private Sub PresetAutosave()
        NormalTopPage()
        b1TB.Text = "PRESET AUTOSAVE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "ON"
        c1TB.Width = 250
        c1TB.Visible = True

        d1TB.Text = "PRESS ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub RfFaultsPersist()
        NormalTopPage()
        b1TB.Text = "RF FAULTS PERSIST"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "ON"
        c1TB.Width = c1TB.TextLength * 14
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True
    End Sub

    Private Sub PAfailsafe()
        NormalTopPage()
        b1TB.Text = "PA FAILSAFE OVR"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "DISABLED"
        c1TB.Width = c1TB.TextLength * 12
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True
    End Sub

    Private Sub PaFailsafeWarning()
        NormalTopPage()
        b1TB.Text = "WARNING :  DISABLED"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "TEMPERATURE CUTBACKS"
        c1TB.Width = 250
        c1TB.Visible = True

        d1TB.Text = "ENT TO CONTINUE / CLR TO ABORT"
        d1TB.Width = 250
        d1TB.Visible = True

    End Sub 'display PA fail warning page

    Private Sub RemoteKDU()
        NormalTopPage()
        b1TB.Text = "REMOTE KDU"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "ENABLED"
        c1TB.Width = c1TB.TextLength * 12
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True
    End Sub 'display KDU page

    Private Sub SAtransmit()
        NormalTopPage()
        b1TB.Text = "SA TRANSMIT"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "ENABLE"
        c1TB.Width = c1TB.TextLength * 12
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True

    End Sub 'display SA page

    Private Sub SystemInfoPage()
        NormalTopPage()
        b1TB.Text = "VERSIONS"
        c1TB.Text = "SERIAL NUMBER"
        d1TB.Text = "PART NUMBER"
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Font = New Font("Micosoft san serif", 11, FontStyle.Bold)
        c1TB.Font = New Font("Micosoft san serif", 11, FontStyle.Bold)
        d1TB.Font = New Font("Micosoft san serif", 11, FontStyle.Bold)
        b1TB.Width = b1TB.TextLength * 11.2
        b1TB.Location = New Point(b1TB.Location.X, b1TB.Location.Y - 1)
        c1TB.Width = b1TB.TextLength * 17
        c1TB.Location = New Point(c1TB.Location.X, c1TB.Location.Y - 2)
        d1TB.Width = b1TB.TextLength * 15
        d1TB.Location = New Point(d1TB.Location.X, d1TB.Location.Y - 3)
        b1TB.Visible = True
        c1TB.Visible = True
        d1TB.Visible = True
        b7PB.BackgroundImage = My.Resources.scrollbarFull
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.Visible = True
    End Sub 'displays system page

    Private Sub SysInfoScrollDown()

        If d1TB.BackColor <> Color.Black Or d1TB.Text <> "TCXO TUNING" Then


            If b1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                b1TB.BackColor = Color.MediumSeaGreen
                b1TB.ForeColor = Color.Black
                b7PB.BackgroundImage = My.Resources.scrollbar2


            ElseIf c1TB.BackColor = Color.Black Then
                d1TB.BackColor = Color.Black
                d1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                b7PB.BackgroundImage = My.Resources.scrollbar3

            Else
                If d1TB.BackColor = Color.Black Then
                    b1TB.Text = c1TB.Text
                    c1TB.Text = d1TB.Text
                    Select Case c1TB.Text
                        Case "PART NUMBER"
                            d1TB.Text = "SW OPTIONS"
                        Case "SW OPTIONS"
                            d1TB.Text = "ELAPSED TIME"
                        Case "ELAPSED TIME"
                            d1TB.Text = "TCXO TUNING"
                    End Select
                End If

            End If

        End If
        b1TB.Width = b1TB.TextLength * 11
        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.Width = c1TB.TextLength * 11
        c1TB.TextAlign = HorizontalAlignment.Left
        d1TB.Width = d1TB.TextLength * 11
        d1TB.TextAlign = HorizontalAlignment.Left
    End Sub 'scrolls system page down

    Private Sub SysInfoScrollUp()
        If b1TB.BackColor <> Color.Black Or b1TB.Text <> "VERSIONS" Then


            If d1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                d1TB.BackColor = Color.MediumSeaGreen
                d1TB.ForeColor = Color.Black
                b7PB.BackgroundImage = My.Resources.ScrollBar8


            ElseIf c1TB.BackColor = Color.Black Then
                b1TB.BackColor = Color.Black
                b1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
                b7PB.BackgroundImage = My.Resources.scrollbar7

            Else
                If b1TB.BackColor = Color.Black Then
                    d1TB.Text = c1TB.Text
                    c1TB.Text = b1TB.Text
                    Select Case b1TB.Text
                        Case "SW OPTIONS"
                            b1TB.Text = "PART NUMBER"
                        Case "PART NUMBER"
                            b1TB.Text = "SERIAL NUMBER"
                        Case "SERIAL NUMBER"
                            b1TB.Text = "VERSIONS"
                    End Select

                End If

            End If

        End If
        b1TB.Width = b1TB.TextLength * 11
        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.Width = c1TB.TextLength * 11
        c1TB.TextAlign = HorizontalAlignment.Left
        d1TB.Width = d1TB.TextLength * 11
        d1TB.TextAlign = HorizontalAlignment.Left


    End Sub 'scrolls system page up

    Private Sub VersionSelect()
        NormalTopPage()
        b1TB.Text = "VERSIONS SELECT"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "HARDWARE"
        c1TB.Width = c1TB.TextLength * 13.5
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Location = New Point(507 - (c1TB.Width / 2), c1TB.Location.Y)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True
    End Sub 'used to display version page

    Private Sub VersionScrollDown()
        If c1TB.Text = "HARDWARE" Then
            c1TB.Text = "SYSTEM"
        ElseIf c1TB.Text = "SYSTEM" Then
            c1TB.Text = "SOFTWARE"
        ElseIf c1TB.Text = "SOFTWARE" Then
            c1TB.Text = "INFOSEC"
        ElseIf c1TB.Text = "INFOSEC" Then
            c1TB.Text = "HARDWARE"
        End If
        c1TB.Width = c1TB.TextLength * 14
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
    End Sub 'used to scroll version page down

    Private Sub VersionScrollUp()
        If c1TB.Text = "INFOSEC" Then
            c1TB.Text = "SOFTWARE"
        ElseIf c1TB.Text = "SOFTWARE" Then
            c1TB.Text = "SYSTEM"
        ElseIf c1TB.Text = "SYSTEM" Then
            c1TB.Text = "HARDWARE"
        ElseIf c1TB.Text = "HARDWARE" Then
            c1TB.Text = "INFOSEC"
        End If
        c1TB.Width = c1TB.TextLength * 14
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
    End Sub 'used to scroll version page up

    Private Sub VersionHardware()
        NormalTopPage()
        b1TB.Text = "NAME:"
        c1TB.Text = "ID:"
        b1TB.TextAlign = HorizontalAlignment.Left
        b1TB.Width = 55
        c1TB.Width = 55
        c1TB.TextAlign = HorizontalAlignment.Left
        b2TB.Text = "POWER SUPPLY"
        b2TB.Width = b2TB.TextLength * 12
        b2TB.Location = New Point(a7TB.Location.X + a7TB.Width - b2TB.Width, b2TB.Location.Y)
        b2TB.TextAlign = HorizontalAlignment.Center
        b2TB.BackColor = Color.Black
        b2TB.ForeColor = Color.MediumSeaGreen
        c3TB.Location = New Point(b2TB.Location.X, c1TB.Location.Y)
        c3TB.Text = "A2"
        c3TB.TextAlign = HorizontalAlignment.Right
        c3TB.Width = b2TB.Width
        d3TB.Text = "TO SCROLL /"
        d3TB.Width = 85
        b7PB.BackgroundImage = My.Resources.UpAndDown
        b7PB.Width = 28
        b7PB.Height = 6
        b7PB.Location = New Point(d3TB.Location.X - b7PB.Width, 200)
        b6PB.Location = New Point(d3TB.Location.X + d3TB.Width, 198)
        b6PB.Height = 16
        b6PB.Width = b6PB.Height
        d6TB.Text = " FOR MORE"
        d6TB.Width = 70
        d6TB.Location = New Point(b6PB.Location.X + b6PB.Width, 198)



        b1TB.Visible = True
        c1TB.Visible = True
        b2TB.Visible = True
        c3TB.Visible = True
        d3TB.Visible = True
        b7PB.Visible = True
        b6PB.Visible = True
        d6TB.Visible = True


    End Sub 'shows version hardware page

    Private Sub VersionSystem()
        NormalTopPage()
        b1TB.Text = "NAME:"
        c1TB.Text = "12043-8911 4.0.0"
        c1TB.TextAlign = HorizontalAlignment.Right
        c1TB.Width = 240
        b1TB.TextAlign = HorizontalAlignment.Left
        b1TB.Width = 55
        b2TB.Text = "SW"
        b2TB.Width = b2TB.TextLength * 17
        b2TB.Location = New Point(a7TB.Location.X + a7TB.Width - b2TB.Width, b2TB.Location.Y)
        b2TB.TextAlign = HorizontalAlignment.Center
        b2TB.BackColor = Color.Black
        b2TB.ForeColor = Color.MediumSeaGreen
        d3TB.Text = "TO SCROLL /"
        d3TB.Width = 85
        b7PB.BackgroundImage = My.Resources.UpAndDown
        b7PB.Width = 28
        b7PB.Height = 6
        b7PB.Location = New Point(d3TB.Location.X - b7PB.Width, 200)
        b6PB.Location = New Point(d3TB.Location.X + d3TB.Width, 198)
        b6PB.Height = 16
        b6PB.Width = b6PB.Height
        d6TB.Text = " FOR MORE"
        d6TB.Width = 70
        d6TB.Location = New Point(b6PB.Location.X + b6PB.Width, 198)



        b1TB.Visible = True
        c1TB.Visible = True
        b2TB.Visible = True
        d3TB.Visible = True
        b7PB.Visible = True
        b6PB.Visible = True
        d6TB.Visible = True
    End Sub 'shows version system page

    Private Sub VersionSoftware()
        NormalTopPage()
        b1TB.Text = "NAME:"
        c1TB.Text = "10511-8820-05 1.7"
        c1TB.TextAlign = HorizontalAlignment.Right
        c1TB.Width = 240
        b1TB.TextAlign = HorizontalAlignment.Left
        b1TB.Width = 55
        b2TB.Text = "RKDU_FIRMWARE"
        b2TB.Width = b2TB.TextLength * 12.5
        b2TB.Location = New Point(a7TB.Location.X + a7TB.Width - b2TB.Width, b2TB.Location.Y)
        b2TB.TextAlign = HorizontalAlignment.Center
        b2TB.BackColor = Color.Black
        b2TB.ForeColor = Color.MediumSeaGreen
        d3TB.Text = "TO SCROLL /"
        d3TB.Width = 85
        b7PB.BackgroundImage = My.Resources.UpAndDown
        b7PB.Width = 28
        b7PB.Height = 6
        b7PB.Location = New Point(d3TB.Location.X - b7PB.Width, 200)
        b6PB.Location = New Point(d3TB.Location.X + d3TB.Width, 198)
        b6PB.Height = 16
        b6PB.Width = b6PB.Height
        d6TB.Text = " FOR MORE"
        d6TB.Width = 70
        d6TB.Location = New Point(b6PB.Location.X + b6PB.Width, 198)



        b1TB.Visible = True
        c1TB.Visible = True
        b2TB.Visible = True
        d3TB.Visible = True
        b7PB.Visible = True
        b6PB.Visible = True
        d6TB.Visible = True
    End Sub 'shows version software page

    Private Sub VersionInfosec()
        NormalTopPage()
        b1TB.Text = "NAME:"
        c1TB.Text = "REV:"
        b1TB.TextAlign = HorizontalAlignment.Left
        b1TB.Width = 55
        c1TB.Width = 55
        c1TB.TextAlign = HorizontalAlignment.Left
        b2TB.Text = "SINCGARS_CC"
        b2TB.Width = b2TB.TextLength * 12
        b2TB.Location = New Point(a7TB.Location.X + a7TB.Width - b2TB.Width, b2TB.Location.Y)
        b2TB.TextAlign = HorizontalAlignment.Center
        b2TB.BackColor = Color.Black
        b2TB.ForeColor = Color.MediumSeaGreen
        c3TB.Location = New Point(b2TB.Location.X, c1TB.Location.Y)
        c3TB.Text = "2.8.0"
        c3TB.TextAlign = HorizontalAlignment.Right
        c3TB.Width = b2TB.Width
        d3TB.Text = "TO SCROLL /"
        d3TB.Width = 85
        b7PB.BackgroundImage = My.Resources.UpAndDown
        b7PB.Width = 28
        b7PB.Height = 6
        b7PB.Location = New Point(d3TB.Location.X - b7PB.Width, 200)
        b6PB.Location = New Point(d3TB.Location.X + d3TB.Width, 198)
        b6PB.Height = 16
        b6PB.Width = b6PB.Height
        d6TB.Text = " FOR MORE"
        d6TB.Width = 70
        d6TB.Location = New Point(b6PB.Location.X + b6PB.Width, 198)



        b1TB.Visible = True
        c1TB.Visible = True
        b2TB.Visible = True
        c3TB.Visible = True
        d3TB.Visible = True
        b7PB.Visible = True
        b6PB.Visible = True
        d6TB.Visible = True
    End Sub 'shows version infosec page

    Private Sub SerialNumber()
        NormalTopPage()
        b1TB.Text = "SERIAL NUMBER"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "A1234"
        c1TB.Width = 250
        c1TB.Visible = True

        PressClrToAbort()
        d1TB.Text = "PRESS CLR/ENT TO EXIT"
        d1TB.Visible = True
        HelperUpdate()

    End Sub

    Private Sub PartNumber()
        NormalTopPage()
        b1TB.Text = "PART NUMBER"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "0N707070-7"
        c1TB.Width = 250
        c1TB.Visible = True

        PressClrToAbort()
        d1TB.Text = "PRESS CLR/ENT TO EXIT"
        d1TB.Visible = True
    End Sub

    Private Sub SWoptions()
        NormalTopPage()
        b1TB.Text = "NAME:"
        c1TB.Text = "ROVER WAVEFORM OPTION"
        b1TB.TextAlign = HorizontalAlignment.Left
        b1TB.Width = 55
        c1TB.Width = 250
        b2TB.Text = "ROVER"
        b2TB.Width = b2TB.TextLength * 20
        b2TB.Location = New Point(b1TB.Location.X + b1TB.Width, b2TB.Location.Y)
        b2TB.TextAlign = HorizontalAlignment.Center
        d3TB.Text = "TO SCROLL /"
        d3TB.Width = 85
        b7PB.BackgroundImage = My.Resources.UpAndDown
        b7PB.Width = 28
        b7PB.Height = 6
        b7PB.Location = New Point(d3TB.Location.X - b7PB.Width, 200)
        b6PB.Location = New Point(d3TB.Location.X + d3TB.Width, 198)
        b6PB.Height = 16
        b6PB.Width = b6PB.Height
        d6TB.Text = " FOR MORE"
        d6TB.Width = 70
        d6TB.Location = New Point(b6PB.Location.X + b6PB.Width, 198)



        b1TB.Visible = True
        c1TB.Visible = True
        b2TB.Visible = True
        d3TB.Visible = True
        b7PB.Visible = True
        b6PB.Visible = True
        d6TB.Visible = True
    End Sub

    Private Sub ElapsedTime()
        NormalTopPage()
        b1TB.Text = "HOURS UP"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "15.51 HR"
        c1TB.Width = 250
        c1TB.Visible = True

        PressClrToAbort()
        d1TB.Text = "PRESS ENT TO CONTINUE"
        d1TB.Visible = True
    End Sub

    Private Sub RadioUptime()
        NormalTopPage()
        b1TB.Text = "HOURS TX"
        c1TB.Text = "TIMES KEYED"
        b1TB.TextAlign = HorizontalAlignment.Left
        b1TB.Width = 100
        c1TB.Width = 120
        c1TB.TextAlign = HorizontalAlignment.Left
        b2TB.Text = "0.45 HR"
        b2TB.Width = b2TB.TextLength * 12
        b2TB.Location = New Point(a7TB.Location.X + a7TB.Width - b2TB.Width, b2TB.Location.Y)
        b2TB.TextAlign = HorizontalAlignment.Right
        b2TB.BackColor = Color.MediumSeaGreen
        b2TB.ForeColor = Color.Black
        c3TB.Location = New Point(b2TB.Location.X, c1TB.Location.Y)
        c3TB.Text = "24"
        c3TB.TextAlign = HorizontalAlignment.Right
        c3TB.Width = b2TB.Width
        d1TB.Text = "PRESS ENT TO CONTINUE"
        d1TB.Width = 250

        d1TB.Visible = True
        b1TB.Visible = True
        c1TB.Visible = True
        b2TB.Visible = True
        c3TB.Visible = True
        
    End Sub

    Private Sub TcxoTuning()
        NormalTopPage()
        b1TB.Text = "ENTER MAINTENANCE PASSWORD"
        b1TB.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "________"
        c1TB.Width = 250
        c1TB.Visible = True

        PressClrToAbort()
        d1TB.Text = "PRESS CLR/ENT TO EXIT"
        d1TB.Visible = True
    End Sub

    Private Sub TxPowerOptions()
        NormalTopPage()

        b1TB.Text = "TX POWER LEVEL"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = txPower
        c1TB.Width = c1TB.TextLength * 13.5
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True


    End Sub 'transmit power options page

    Private Sub TxPowerUser()
        txPower = "USER"
        UserTXpowerPage()
    End Sub

    Private Sub TxPowerHigh()
        txPower = "HIGH"
        DisplayOptionsMenu()
    End Sub

    Private Sub TxPowerMedium()
        txPower = "MEDIUM"
        DisplayOptionsMenu()
    End Sub

    Private Sub TxPowerLow()
        txPower = "LOW"
        DisplayOptionsMenu()
    End Sub

    Private Sub TxPowerScroll()
        If direction = "up" Then
            If c1TB.Text = "USER" Then
                c1TB.Text = "LOW"
            ElseIf c1TB.Text = "LOW" Then
                c1TB.Text = "MEDIUM"
            ElseIf c1TB.Text = "MEDIUM" Then
                c1TB.Text = "HIGH"
            ElseIf c1TB.Text = "HIGH" Then
                c1TB.Text = "USER"
            End If
        ElseIf direction = "down" Then
            If c1TB.Text = "USER" Then
                c1TB.Text = "HIGH"
            ElseIf c1TB.Text = "HIGH" Then
                c1TB.Text = "MEDIUM"
            ElseIf c1TB.Text = "MEDIUM" Then
                c1TB.Text = "LOW"
            ElseIf c1TB.Text = "LOW" Then
                c1TB.Text = "USER"
            End If
        End If
        c1TB.Width = c1TB.TextLength * 13.5
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
    End Sub

    Private Sub UserTXpowerPage()
        NormalTopPage()
        b1TB.Text = "USER TX POWER LEVEL"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = txPwr
        c1TB.Width = 200
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "end"

    End Sub

    Private Sub TxPowerUserScroll()
        If direction = "down" Then
            If txPowerDB < 10 Then
                txPowerDB = txPowerDB + 1
            End If

        ElseIf direction = "up" Then
            If txPowerDB >= 1 Then
                txPowerDB = txPowerDB - 1
            End If

        End If
        c1TB.Text = txPowerDB.ToString + " DB DOWN (+10.0 W)"
        txPwr = c1TB.Text

    End Sub

    Private Sub ViewKeyInfo()
        NormalTopPage()

        b1TB.Text = "SELECT WAVEFORM"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = waveform
        c1TB.Width = c1TB.TextLength * 13.5
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True
    End Sub

    Private Sub KeyInfoNameScroll()
        If direction = "up" Then
            Select Case c1TB.Text
                Case "SINCGARS"
                    c1TB.Text = "HAVEQUICK"
                Case "HAVEQUICK"
                    c1TB.Text = "VULOS"
                Case "VULOS"
                    c1TB.Text = "IW"
                Case "DAMA"
                    c1TB.Text = "ANW2"
                Case "DSS PUBLIC KEY"
                    c1TB.Text = "SCM"
                Case "HAIPE"
                    c1TB.Text = "ANW2B"
                Case "ANW2"
                    c1TB.Text = "HAIPE"
                Case "ANW2B"
                    c1TB.Text = "DSS PUBLIC KEY"
                Case "SCM"
                    c1TB.Text = "HPW"
                Case "HPW"
                    c1TB.Text = "SINCGARS"
                Case "IW"
                    c1TB.Text = "DAMA"
            End Select
        ElseIf direction = "down" Then
            Select Case c1TB.Text
                Case "SINCGARS"
                    c1TB.Text = "HPW"
                Case "HAVEQUICK"
                    c1TB.Text = "SINCGARS"
                Case "VULOS"
                    c1TB.Text = "HAVEQUICK"
                Case "DAMA"
                    c1TB.Text = "IW"
                Case "DSS PUBLIC KEY"
                    c1TB.Text = "ANW2B"
                Case "HAIPE"
                    c1TB.Text = "ANW2"
                Case "ANW2"
                    c1TB.Text = "DAMA"
                Case "ANW2B"
                    c1TB.Text = "HAIPE"
                Case "SCM"
                    c1TB.Text = "DSS PUBLIC KEY"
                Case "HPW"
                    c1TB.Text = "SCM"
                Case "IW"
                    c1TB.Text = "VULOS"
            End Select
        End If
        waveform = c1TB.Text
        c1TB.Width = c1TB.TextLength * 13.5
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
    End Sub

    Private Sub KeyTypeScroll()

        'buid the array of encryption types

        'encryptionType(0, 0) = "ANW2B"
        'encryptionType(0, 1) = "TEK"
        'encryptionType(0, 2) = "LOCKOUT"
        'encryptionType(0, 3) = "TSK"
        'encryptionType(0, 4) = "HOPSET"
        'encryptionType(0, 5) = "KEK"
        'encryptionType(0, 6) = "TRKEK"
        encryptionType(1, 0) = "HAVEQUICK"
        encryptionType(1, 1) = "TEK"
        encryptionType(1, 2) = "WOD"
        encryptionType(1, 3) = "TRKEK"
        encryptionType(2, 0) = "VULOS"
        encryptionType(2, 1) = "TEK"
        encryptionType(2, 2) = "KEK"
        encryptionType(2, 3) = "TRKEK"
        encryptionType(3, 0) = "DAMA"
        encryptionType(3, 1) = "TEK"
        encryptionType(3, 2) = "TSK"
        encryptionType(3, 3) = "TRKEK"
        encryptionType(4, 0) = "DSS PUBLIC KEY"
        encryptionType(5, 0) = "HAIPE"
        encryptionType(5, 1) = "TEK"
        encryptionType(5, 2) = "VECTOR"
        encryptionType(6, 0) = "ANW2"
        encryptionType(6, 1) = "TEK"
        encryptionType(6, 2) = "TSK"
        encryptionType(7, 0) = "ANW2B"
        encryptionType(7, 1) = "TEK"
        encryptionType(7, 2) = "TSK"
        encryptionType(8, 0) = "SCM"
        encryptionType(8, 1) = "TEK"
        encryptionType(8, 2) = "TRKEK"
        encryptionType(9, 0) = "SINCGARS"
        encryptionType(9, 1) = "TEK"
        encryptionType(9, 2) = "LOCKOUT"
        encryptionType(9, 3) = "TSK"
        encryptionType(9, 4) = "HOPSET"
        encryptionType(9, 5) = "KEK"
        encryptionType(9, 6) = "TRKEK"
        encryptionType(10, 0) = "HPW"
        encryptionType(10, 1) = "TEK"
        encryptionType(10, 2) = "TSK"
        encryptionType(10, 3) = "TRKEK"
        encryptionType(11, 0) = "IW"
        encryptionType(11, 1) = "TEK"
        encryptionType(11, 2) = "TSK"
        encryptionType(11, 3) = "TRKEK"


       



        Do Until (encryptionType(waveVal, 0) = waveform) 'finds the correct waveform
            waveVal = waveVal + 1
            typeVal = 0
            If waveVal >= 12 Then 'checks the upper limits of the array
                waveVal = 1 'resets the array 
            End If
        Loop

        If direction = "down" Then
            typeVal = typeVal + 1
            If typeVal = 0 Then
                typeVal = 1
            End If
            If encryptionType(waveVal, typeVal) = "" Then
                typeVal = 1
            End If
        End If

        If direction = "up" Then
            typeVal = typeVal - 1
            If typeVal = 0 Then
                typeVal = 7
            End If

            Do While encryptionType(waveVal, typeVal) = "" 'finds the high level of the array
                typeVal = typeVal - 1

            Loop


        End If


        If direction = "" Then
            typeVal = 1
        End If

        c1TB.Text = encryptionType(waveVal, typeVal)


        c1TB.Width = c1TB.TextLength * 13.5
        If c1TB.Text = "WOD" Then
            c1TB.Width = c1TB.TextLength * 16 'WOD highlight was a little short
        End If
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
    End Sub

    Private Sub SelectType()
        NormalTopPage()

        b1TB.Text = "SELECT TYPE"
        b1TB.Width = 250
        b1TB.Visible = True

        KeyTypeScroll()
        c1TB.Width = c1TB.TextLength * 13.5
        
        c1TB.Location = New Point(507 - (c1TB.Width / 2), 178)
        c1TB.BackColor = Color.Black
        c1TB.ForeColor = Color.MediumSeaGreen
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True
        If c1TB.Text = "" Then
            DssPublicKey()
        End If
    End Sub

    Private Sub TekPage()
        NormalTopPage()
        b1TB.Text = "**           TEK NOT           **"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = "FOUND"
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True

    End Sub

    Private Sub LockoutPage()
        NormalTopPage()
        b1TB.Text = "**        LOCKOUT NOT        **"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = "FOUND"
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub TskPage()
        NormalTopPage()
        b1TB.Text = "**           TSK NOT           **"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = "FOUND"
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub HopsetPage()
        NormalTopPage()
        b1TB.Text = "**        HOPSET NOT        **"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = "FOUND"
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub KekPage()
        NormalTopPage()
        b1TB.Text = "**           KEK NOT           **"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = "FOUND"
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub TrkekPage()
        NormalTopPage()
        b1TB.Text = "**         TRKEK NOT          **"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = "FOUND"
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub WodPage()
        NormalTopPage()
        b1TB.Text = "**           WOD NOT           **"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = "FOUND"
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub VectorPage()
        NormalTopPage()
        b1TB.Text = "**        VECTOR NOT        **"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = "FOUND"
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub DssPublicKey()
        NormalTopPage()
        b1TB.Text = "**        DSS KEY NOT        **"
        b1TB.Width = 250
        b1TB.Visible = True
        c1TB.Text = "FOUND"
        c1TB.Width = 250
        c1TB.Visible = True
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        d1TB.Width = 250
        d1TB.Visible = True
    End Sub

    Private Sub DisplayLoadPage1()

        If alarm = True Then
            ZeroizeAlert()
            Exit Sub
        End If

        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "LOAD MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "FILL"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.Location = New Point(385, 158)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen


        c1TB.Text = "INSTALL"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)



        d1TB.Text = "TERMINAL MODE"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)



        b7PB.BackgroundImage = My.Resources.scrollbarFull
        b7PB.Width = 21
        b7PB.Height = 50
        b7PB.Location = New Point(607, 158)
        b7PB.Visible = True


        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        b1TB.Visible = True
        c1TB.Visible = True
        d1TB.Visible = True

        SetWidth(b1TB)
        SetWidth(c1TB)
        SetWidth(d1TB)


    End Sub 'displays the initial LOAD page

    Public Sub SetWidth(i As TextBox)

        Dim widthVariable As Decimal 'represents the differences in test width
        Dim iTextLength As Integer 'represents the textlength of the item
        Dim iPosition As Integer = 0 'represents the current cursor position in the string
        Dim iCharacter As Char 'represents the character at position iPosition
        iTextLength = i.TextLength 'sets the variable equivilent to the string's textlength


        Do While iTextLength > iPosition
            iCharacter = i.Text.Substring(iPosition, 1)
            iPosition = iPosition + 1
            If iCharacter = "A" Then
                widthVariable = widthVariable + 12.1
            ElseIf iCharacter = "B" Then
                widthVariable = widthVariable + 12
            ElseIf iCharacter = "C" Then
                widthVariable = widthVariable + 12.1
            ElseIf iCharacter = "D" Then
                widthVariable = widthVariable + 13.1
            ElseIf iCharacter = "E" Then
                widthVariable = widthVariable + 12.1
            ElseIf iCharacter = "F" Then
                widthVariable = widthVariable + 11.1
            ElseIf iCharacter = "G" Then
                widthVariable = widthVariable + 12.1
            ElseIf iCharacter = "H" Then
                widthVariable = widthVariable + 13
            ElseIf iCharacter = "I" Then
                widthVariable = widthVariable + 6
            ElseIf iCharacter = "J" Then
                widthVariable = widthVariable + 9.1
            ElseIf iCharacter = "K" Or iCharacter = "k" Then
                widthVariable = widthVariable + 11.1
            ElseIf iCharacter = "L" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "M" Then
                widthVariable = widthVariable + 13.1
            ElseIf iCharacter = "N" Then
                widthVariable = widthVariable + 12
            ElseIf iCharacter = "O" Then
                widthVariable = widthVariable + 13.1
            ElseIf iCharacter = "P" Then
                widthVariable = widthVariable + 11.1
            ElseIf iCharacter = "Q" Then
                widthVariable = widthVariable + 13.1
            ElseIf iCharacter = "R" Then
                widthVariable = widthVariable + 13.1
            ElseIf iCharacter = "S" Then
                widthVariable = widthVariable + 12
            ElseIf iCharacter = "T" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "U" Then
                widthVariable = widthVariable + 13.1
            ElseIf iCharacter = "V" Then
                widthVariable = widthVariable + 12
            ElseIf iCharacter = "W" Then
                widthVariable = widthVariable + 13.1
            ElseIf iCharacter = "X" Then
                widthVariable = widthVariable + 12
            ElseIf iCharacter = "Y" Then
                widthVariable = widthVariable + 12
            ElseIf iCharacter = "Z" Or iCharacter = "z" Then
                widthVariable = widthVariable + 11.1
            ElseIf iCharacter = "0" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "1" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "2" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "3" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "4" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "5" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "6" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "7" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "8" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "9" Then
                widthVariable = widthVariable + 10.1
            ElseIf iCharacter = "-" Then
                widthVariable = widthVariable + 6.1
            ElseIf iCharacter = "/" Then
                widthVariable = widthVariable + 5.1
            ElseIf iCharacter = "(" Then
                widthVariable = widthVariable + 5.1
            ElseIf iCharacter = ")" Then
                widthVariable = widthVariable + 5.1
            ElseIf iCharacter = ":" Then
                widthVariable = widthVariable + 5.1
            ElseIf iCharacter = "." Then
                widthVariable = widthVariable + 5.1
            ElseIf iCharacter = "*" Then
                widthVariable = widthVariable + 7.1
            ElseIf iCharacter = "<" Then
                widthVariable = widthVariable + 7.1
            ElseIf iCharacter = ">" Then
                widthVariable = widthVariable + 7.1
            ElseIf iCharacter = " " Then
                widthVariable = widthVariable + 5.1
            ElseIf iCharacter = "?" Then
                widthVariable = widthVariable + 9.1
            ElseIf iCharacter = "&" Then
                widthVariable = widthVariable + 13.2
            End If
        Loop

        If i.Font.SizeInPoints = 10 Then
            widthVariable = widthVariable * 0.85
        ElseIf i.Font.SizeInPoints = 11 Then
            widthVariable = widthVariable * 0.95
        ElseIf i.Font.SizeInPoints = 8.25 Then
            widthVariable = widthVariable * 0.75
        End If
        i.Width = widthVariable + 4

    End Sub 'automatically fixes the width of a textbox

    Private Sub FillMenu()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "WAVEFORM"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "HAIPE"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "OTAR TEK"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True

        
        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        
        JustificationAndSetWidth()



        menuChoices = "fill menu"
        SelectMenu()

        MeasureArray()
        AutoScrollbar()


    End Sub

    Private Sub MeasureArray()
        
        Do While menuItems(0, xHi) <> ""
            xHi = xHi + 1
        Loop


        Do While menuItems(0, xHi) = "" 'finds the high level of the array and sets it as xHi. xHi is set to 15 in the 
            xHi = xHi - 1               'variables declaration but can be set to anything
        Loop

        ArrayUpperLimit = xHi ' stores the array upper limit as an integer

        If b1TB.BackColor = Color.Black Then
            xHighlitedText = b1TB.Text
        ElseIf c1TB.BackColor = Color.Black Then
            xHighlitedText = c1TB.Text
        ElseIf d1TB.BackColor = Color.Black Then
            xHighlitedText = d1TB.Text
        ElseIf b2TB.BackColor = Color.Black Then
            xHighlitedText = b2TB.Text

        End If



        Do While xHighlitedText <> menuItems(0, xCurrent)
            If direction = "down" Or direction = "" Then
                xCurrent = xCurrent + 1
            ElseIf direction = "up" Then
                xCurrent = xCurrent - 1
            End If

        Loop


    End Sub

    Private Sub GenericMenuScroll()

        If direction = "down" Then
            If b1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                b1TB.BackColor = Color.MediumSeaGreen
                b1TB.ForeColor = Color.Black

            ElseIf c1TB.BackColor = Color.Black Then
                d1TB.BackColor = Color.Black
                d1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black

            Else
                If d1TB.Text <> menuItems(0, xHi) Then 'stops the process when the end of the list is reached
                    b1TB.Text = c1TB.Text
                    c1TB.Text = d1TB.Text
                    d1TB.Text = menuItems(0, xCurrent + 1)

                End If
            End If
        ElseIf direction = "up" Then
            If d1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                d1TB.BackColor = Color.MediumSeaGreen
                d1TB.ForeColor = Color.Black

            ElseIf c1TB.BackColor = Color.Black Then
                b1TB.BackColor = Color.Black
                b1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black

            Else
                If b1TB.Text <> menuItems(0, 1) Then 'stops the process when the end of the list is reached
                    d1TB.Text = c1TB.Text
                    c1TB.Text = b1TB.Text
                    Try
                        b1TB.Text = menuItems(0, xCurrent - 1)
                    Catch
                    End Try

                End If
            End If
        End If
        JustificationAndSetWidth()
        MeasureArray()
        AutoScrollbar()

    End Sub 'will scroll through an array up and down, highliting the text as needed

    Private Sub ScanScroll()
        If direction = "down" Then
            If b1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                b1TB.BackColor = Color.MediumSeaGreen
                b1TB.ForeColor = Color.Black

            ElseIf c1TB.BackColor = Color.Black Then
                d1TB.BackColor = Color.Black
                d1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black

            Else
                If d1TB.Text <> menuItems(0, xHi) Then 'stops the process when the end of the list is reached
                    b1TB.Text = c1TB.Text
                    c1TB.Text = d1TB.Text
                    d1TB.Text = menuItems(0, xCurrent + 1)

                End If
            End If
        ElseIf direction = "up" Then
            If d1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                d1TB.BackColor = Color.MediumSeaGreen
                d1TB.ForeColor = Color.Black

            ElseIf c1TB.BackColor = Color.Black Then
                b1TB.BackColor = Color.Black
                b1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black

            Else
                If b1TB.Text <> menuItems(0, 0) Then 'stops the process when the end of the list is reached
                    d1TB.Text = c1TB.Text
                    c1TB.Text = b1TB.Text
                    Try
                        b1TB.Text = menuItems(0, xCurrent - 1)
                    Catch
                    End Try

                End If
            End If
        End If
        JustificationAndSetWidth()
        MeasureArray()
        AutoScrollbar()
    End Sub

    Private Sub JustificationAndSetWidth()

        SetWidth(b1TB)
        SetWidth(c1TB)
        SetWidth(d1TB)

        If ml1 = "main zeroize menu" Then
        ElseIf (ml1 <> "mode" And ml4 <> "yes") Then
            b1TB.TextAlign = HorizontalAlignment.Left
            c1TB.TextAlign = HorizontalAlignment.Left
            d1TB.TextAlign = HorizontalAlignment.Left
        End If


    End Sub 'call this subroutine to automatically set the width of b1, c1, and d1                                                        'textboxes and justify them to the left

    Private Sub AutoScrollbar()



        Dim tabLoc As Integer 'represent the location of the scrollbar tab

        b6PB.Height = (28 / (ArrayUpperLimit))

        Dim start As Integer = 0

        If (b6PB.Height * (xCurrent - 1)) < 0 Then
            start = 0
        Else
            start = (b6PB.Height * (xCurrent - 1))
        End If

        tabLoc = 164 + (28 / (ArrayUpperLimit + 1)) + start


        b7PB.BackgroundImage = My.Resources.scrollbarNull
        b7PB.BackgroundImageLayout = ImageLayout.Stretch
        b6PB.BackgroundImage = My.Resources.BlackBackground
        b6PB.BackgroundImageLayout = ImageLayout.Stretch
        b6PB.Width = 9

        b6PB.Location = New Point((b7PB.Location.X + 1), tabLoc) '(b7PB.Location.Y + 7)) + (b6PB.Height * (xCurrent - 1))
        b6PB.Visible = True
    End Sub 'use this after declaring menuitems array elements and calling MeasureArray(). sub will automatically create a scrollbar based on the calculations of MeasureArray().

    Private Sub SelectMenu()

        menuItems(0, 0) = ""
        menuItems(0, 1) = ""
        menuItems(0, 2) = ""
        menuItems(0, 3) = ""
        menuItems(0, 4) = ""
        menuItems(0, 5) = ""
        menuItems(0, 6) = ""
        menuItems(0, 7) = ""
        menuItems(0, 8) = ""
        menuItems(0, 9) = ""
        menuItems(0, 10) = ""
        menuItems(0, 11) = ""


        If menuChoices = "data port config" Then
            menuItems(0, 0) = "GENERAL HW CONFIG"
            menuItems(0, 1) = "SYNC CONFIG"
            menuItems(0, 2) = "ASYNC CONFIG"
            menuItems(0, 3) = "PPP CONFIG"
        End If
        

        If menuChoices = "general radio config" Then
            menuItems(0, 0) = "AUDIO CONFIG"
            menuItems(0, 1) = "AUTOSAVE CONFIG"
            menuItems(0, 2) = "CT OVERRIDE CONFIG"
            menuItems(0, 3) = "DATA PORT CONFIG"
            menuItems(0, 4) = "EXTERNAL DEVICE"
            menuItems(0, 5) = "EXTERNAL KEYLINE"
            menuItems(0, 6) = "GPS CONFIG"
            menuItems(0, 7) = "NETWORK CONFIG"
            menuItems(0, 8) = "PORT CONFIG"
            menuItems(0, 9) = "RETRANSMIT CONFIG"
            menuItems(0, 10) = "SA CONFIG"
            menuItems(0, 11) = "VPOD CONFIG"
        End If

        If menuChoices = "radio config" Then
            menuItems(0, 0) = "CHANGE MAINT PSWD"
            menuItems(0, 1) = "GENERAL CONFIG"
            menuItems(0, 2) = "SYSTEM CLOCK"
            menuItems(0, 3) = "MAINTENANCE"
        End If

        If menuChoices = "scan config" Then
            menuItems(0, 0) = "SCAN LIST"
            menuItems(0, 1) = "PRIORITY"
            menuItems(0, 2) = "HANG/HOLD TIME"
            menuItems(0, 3) = "EXIT"
        End If

        If menuChoices = "fill menu" Then
            menuItems(0, 0) = "FILL MENU"
            menuItems(0, 1) = "WAVEFORM"
            menuItems(0, 2) = "HAIPE"
            menuItems(0, 3) = "OTAR TEK"
            menuItems(0, 4) = "GPS"
            menuItems(0, 5) = "DSS PUBLIC KEY"
        End If

        If menuChoices = "fill waveform menu" Then
            menuItems(0, 0) = "SINCGARS"
        End If

        If menuChoices = "fill device type menu" Then
            menuItems(0, 0) = "DTD (CYZ-10)/KIK-20"
            menuItems(0, 1) = "SKL (PYQ-10)"
            menuItems(0, 2) = "KOI-18"
            menuItems(0, 3) = "KYX-15"
            menuItems(0, 4) = "KYK-13"
            menuItems(0, 5) = "MX-18290"
        End If

        If menuChoices = "fill port type menu" Then
            menuItems(0, 0) = "DS-101"
            menuItems(0, 1) = "DS-102"
            menuItems(0, 2) = "MODE 1 (ESET)" 'SINCGARS ONLY
            menuItems(0, 3) = "MODE 2/3 (LOADSET)" 'SINCGARS ONLY
        End If

        If menuChoices = "fill crypto mode" Then
            menuItems(0, 0) = "ANDVT"
            menuItems(0, 1) = "KG84"
            menuItems(0, 2) = "SATELLITE"
            menuItems(0, 3) = "VINSON"
            menuItems(0, 4) = "AES"
            menuItems(0, 5) = "DS-101"
            menuItems(0, 6) = "FASCINATOR"
        End If

        If menuChoices = "fill key type" Then
            menuItems(0, 0) = "TEK"
            menuItems(0, 1) = "KEK"
            menuItems(0, 2) = "TSK"
            menuItems(0, 3) = "TRKEK"
            
        End If

        If menuChoices = "classifications" Then
            menuItems(0, 0) = "UNCLASSIFIED"
            menuItems(0, 1) = "CONFIDENTIAL"
            menuItems(0, 2) = "SECRET"
            menuItems(0, 3) = "TOP SECRET"
        End If

        If menuChoices = "mode main page" Then
            menuItems(0, 0) = "MODE PAGE"
            menuItems(0, 1) = "BEACON"
            menuItems(0, 2) = "CLONE MODE"
            menuItems(0, 3) = "SCAN"
            menuItems(0, 4) = "OTAR RECEIVE"
            menuItems(0, 5) = "OTAR TRANSMIT"
        End If

        If menuChoices = "program main page" Then

            menuItems(0, 0) = "RADIO CONFIG"
            menuItems(0, 1) = "SYSTEM PRESETS"
            menuItems(0, 2) = "VULOS CONFIG"
            

        End If

        If menuChoices = "system presets menu" Then

            menuItems(0, 0) = "SYSTEM PRESET CONFIG"
            menuItems(0, 1) = "RESET SYSTEM PRESET"
            menuItems(0, 2) = "SYSTEM SCAN CONFIG"

        End If

        If menuChoices = "programming menu" Then

            menuItems(0, 0) = "GENERAL CONFIG"
            menuItems(0, 1) = "FREQUENCY"
            menuItems(0, 2) = "COMSEC"
            menuItems(0, 3) = "TRAFFIC"
            menuItems(0, 4) = "TX POWER"
            menuItems(0, 5) = "SQUELCH"
            menuItems(0, 6) = "EXIT"

        End If



        xHi = 15
        xCurrent = 0

    End Sub 'add menu items here. set menuChoices in the calling sub.

    Private Sub FillWaveform()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "WAVEFORM FOR KEY"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "SINCGARS"
        c1TB.Visible = True
        PositionAndHighlight()


        ShowToScrollEntToCont()
        d1TB.Visible = True

        menuChoices = "fill waveform menu"
        SelectMenu()

        MeasureArray()
        'AutoScrollbar()
        ml2 = "fill device type"


    End Sub

    Private Sub FillDeviceType()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "FILL DEVICE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "DTD (CYZ-10)/KIK-20"
        c1TB.Visible = True
        SetWidth(c1TB)
        PositionAndHighlight()


        ShowToScrollEntToCont()
        d1TB.Visible = True

        menuChoices = "fill device type menu"
        SelectMenu()

        MeasureArray()
        
    End Sub

    Private Sub SingleLineScroll()

        Do While menuItems(0, xHi) = "" 'finds the high level of the array and sets it as xHi. xHi is set to 15 in the 
            xHi = xHi - 1               'variables declaration but can be set to anything
        Loop

        ArrayUpperLimit = xHi ' stores the array upper limit as an integer

        If c1TB.BackColor = Color.Black Then
            xHighlitedText = c1TB.Text
        ElseIf b2TB.BackColor = Color.Black Then
            xHighlitedText = b2TB.Text
        End If


        If direction = "down" Or direction = "" Then
            If xCurrent = xHi Then
                xCurrent = -1
            End If
            xCurrent = xCurrent + 1
        ElseIf direction = "up" Then
            If xCurrent = 0 Then
                xCurrent = xHi + 1
            End If
            xCurrent = xCurrent - 1
        End If

        If xHighlitedText = c1TB.Text Then
            c1TB.Text = menuItems(0, xCurrent).ToString
            SetWidth(c1TB)
            PositionAndHighlight()
        ElseIf xHighlitedText = b2TB.Text Then
            b2TB.Text = menuItems(0, xCurrent).ToString
            SetWidth(b2TB)
            If ml4 = "fill in progress" Then
                b2TB.Location = New Point(382 + 195 - b2TB.Width, b1TB.Location.Y)
            End If
        End If
        


    End Sub

    Private Sub FillPortType()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "FILL PORT TYPE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "DS-101"
        c1TB.Visible = True
        SetWidth(c1TB)
        PositionAndHighlight()


        ShowToScrollEntToCont()
        d1TB.Visible = True

        menuChoices = "fill port type menu"
        SelectMenu()

        MeasureArray()
    End Sub

    Private Sub InitiateFill()
        If ml2 = "otar tek" Or fillPort = "ds-101" And (fillDevice <> "koi-18" And fillDevice <> "kyx-15" And fillDevice <> "kyk-13" And fillDevice <> "mx-18290") Then
            AtDevice()
        ElseIf fillDevice = "koi-18" Or fillDevice = "kyx-15" Or fillDevice = "kyk-13" Or fillDevice = "mx-18290" Then
            OnRadio()
        End If
    End Sub

    Private Sub AtDevice()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "INITIATE FILL"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "AT FILL DEVICE"
        c1TB.Width = 250
        c1TB.Visible = True
    End Sub

    Private Sub OnRadio()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "PRESS ENT TO"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "INITIATE FILL"
        c1TB.Width = 250
        c1TB.Visible = True
        ml4 = "fill in progress"

    End Sub

    Private Sub fillProgressScreen()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "FILL IN PROGRESS"
        b1TB.Width = 250
        b1TB.Visible = True

        d1TB.Text = ". . . WAIT . . ."
        d1TB.Width = 250
        d1TB.Visible = True

        timeItTakes = 5

        MyTimerSetup()

    End Sub

    Private Sub FillFailed()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "FILL FAILED"
        b1TB.Width = 250
        b1TB.Visible = True
    End Sub

    Private Sub FillCryptoMode()

        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "CRYPTO MODE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "VINSON"
        c1TB.Width = 250
        c1TB.Visible = True

        SetWidth(c1TB)
        PositionAndHighlight()

        ShowToScrollEntToCont()
        d1TB.Visible = True

        menuChoices = "fill crypto mode"
        SelectMenu()

        MeasureArray()

    End Sub

    Private Sub FillKeyType()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "KEY TYPE:"
        b1TB.Width = 128
        b1TB.TextAlign = HorizontalAlignment.Right
        b1TB.Visible = True

        c1TB.Text = "KEY NUMBER:"
        c1TB.Width = 128
        c1TB.TextAlign = HorizontalAlignment.Right
        c1TB.Visible = True

        b2TB.Text = "TEK"
        SetWidth(b2TB)
        b2TB.Location = New Point(382 + 195 - b2TB.Width, b1TB.Location.Y)
        b2TB.BackColor = Color.Black
        b2TB.ForeColor = Color.MediumSeaGreen
        b2TB.Visible = True

        c3TB.Text = "01"
        SetWidth(c3TB)
        c3TB.Location = New Point(382 + 195 - c3TB.Width, c1TB.Location.Y)
        c3TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True

        menuChoices = "fill key type"
        SelectMenu()

        MeasureArray()

    End Sub

    Private Sub KeyNumber()
        b2TB.BackColor = Color.MediumSeaGreen
        b2TB.ForeColor = Color.Black
        c3TB.BackColor = Color.Black
        c3TB.ForeColor = Color.MediumSeaGreen

        d1TB.Text = "TO SCROLL / ENT TO STORE"
        SetWidth(d1TB)
        ml3 = "classifications"

    End Sub

    Private Sub FillClassification()
        DisplayReset()
        SetVisibilityOFF()

        a1TB.Text = "FILL MENU"
        a1TB.Width = 250
        a1TB.Visible = True

        b1TB.Text = "CLASSIFICATION"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "UNCLASSIFIED"
        c1TB.Width = 250
        c1TB.Visible = True

        SetWidth(c1TB)
        PositionAndHighlight()

        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "classifications"
        menuChoices = "classifications"
        SelectMenu()

        MeasureArray()
    End Sub

    Private Sub GenericNumberScroll()

        Dim num As Integer 'represents the number cast from a string
        Dim numText As String 'temp storage for the number as a string

        Try
            num = CInt(c3TB.Text) 'attempts the cast

            If direction = "up" Then 'adds or subtracts depending on direcion state
                num = num + 1
            ElseIf direction = "down" Then
                num = num - 1
            End If

            If num = 26 Then 'sets the limits for the number
                num = 1
            ElseIf num = 0 Then
                num = 25
            End If

            numText = num.ToString 'casts the integer to a string

            If numText.Length = 1 Then 'adds the leading "0", if needed
                numText = "0" + numText
            End If

            c3TB.Text = numText 'sets the text


        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillStoreAbort()
        b1TB.Text = "FILL STORE"
        c1TB.Text = "ABORTED"
        ml3 = "abort"

    End Sub

    Private Sub ModeMainPage()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True


        b1TB.Text = "BEACON"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "CLONE MODE"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "SCAN"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        menuChoices = "mode main page"
        SelectMenu()
        MeasureArray()

        AutoScrollbar()
        JustificationAndSetWidth()
        ml4 = ""


    End Sub

    Private Sub BeaconPage()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "BEACON MODE OFF:"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "PRESS ENT TO START"
        c1TB.Width = 250
        c1TB.Visible = True

        d1TB.Text = "PRESS CLR TO EXIT"
        d1TB.Width = 250
        d1TB.Visible = True

    End Sub

    Private Sub ClonePage()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "CLONE TYPE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "RECEIVE CLONE"
        c1TB.Width = 250
        c1TB.Visible = True
        PositionAndHighlight()


        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = c1TB.Text.ToLower


    End Sub

    Private Sub ScanPage()
        senderName = "scanPage"
        ml2 = "scan"
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "SCAN"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "ENABLE"
        SetWidth(c1TB)
        c1TB.Visible = True
        PositionAndHighlight()


        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = c1TB.Text.ToLower

    End Sub

    Private Sub OtarRxPage()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "OTAR RX"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "RECEIVE MK"
        c1TB.Width = 250
        c1TB.Visible = True
        PositionAndHighlight()


        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = c1TB.Text.ToLower
    End Sub

    Private Sub OtarTxPage()
        ml4 = ""
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "TRANSMIT OTAR MK"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "NO"
        c1TB.Width = 250
        c1TB.Visible = True
        PositionAndHighlight()


        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = c1TB.Text
    End Sub

    Private Sub BeaconStartup()
        timeItTakes = 5

       MyTimerSetup()

    End Sub

    Private Sub BeaconMode()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a4TB.Text = "BEACON"
        SetWidth(a4TB)
        SetWidth(a5TB)
        SetWidth(a6TB)
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Location = New Point(a4TB.Location.X + a4TB.Width, a4TB.Location.Y)
        a5TB.Visible = True
        a6TB.Visible = True

        b1TB.Text = "BEACON"
        SetWidth(b1TB)
        b1TB.Visible = True
        b7PB.Visible = True




        c1TB.Text = "T:"
        SetWidth(c1TB)
        If GetChar(storedBeaconFreq, 1) = "0" Then
            tempBeaconFreq = Microsoft.VisualBasic.Strings.Right(storedBeaconFreq, 7)
        Else
            tempBeaconFreq = storedBeaconFreq
        End If
        c3TB.Text = tempBeaconFreq
        SetWidth(c3TB)
        c5TB.Text = "MOD:"
        SetWidth(c5TB)
        c7TB.Text = storedBeaconMod
        SetWidth(c7TB)
        c1TB.Visible = True
        c3TB.Visible = True
        c5TB.Visible = True
        c7TB.Visible = True


        d1TB.Text = "BEACON CONSTANT TX / CLR TO STOP"
        d1TB.Width = 250
        d1TB.Visible = True

        ml3 = "running"
        HelperUpdate()


    End Sub

    Private Sub EnteringBeaconMode()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "ENTERING BEACON MODE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = " . . . WAIT . . . "
        c1TB.Width = 250
        c1TB.Visible = True

    End Sub

    Private Sub TerminateBeaconMode()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a4TB.Text = "BEACON"
        SetWidth(a4TB)
        SetWidth(a5TB)
        SetWidth(a6TB)
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Location = New Point(a4TB.Location.X + a4TB.Width, a4TB.Location.Y)
        a5TB.Visible = True
        a6TB.Visible = True

        b1TB.Text = "TERMINATE BEACON?"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "NO"
        PositionAndHighlight()
        c1TB.Visible = True

    End Sub

    Private Sub ExitingBeaconMode()
        EnteringBeaconMode()
        b1TB.Text = "EXITING BEACON MODE"
    End Sub

    Private Sub BeaconShutdown()
        timeItTakes = 5

       MyTimerSetup()

    End Sub

    Private Sub ReceiveClone()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "READY TO"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "RECEIVE CLONE"
        c1TB.Width = 250
        c1TB.Visible = True


        PressClrToAbort()
        d1TB.Visible = True

        from = "receive clone"

        timeItTakes = 3

       MyTimerSetup()

    End Sub

    Private Sub RxCloneInProgress()
        ml4 = "receiving"
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "RECEIVE CLONE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "IN PROGRESS"
        c1TB.Width = 250
        c1TB.Visible = True


        PressClrToAbort()
        d1TB.Visible = True
        HelperUpdate()

        from = "receiving"

        timeItTakes = 5

       MyTimerSetup()

        'thread3 = New Thread(AddressOf Me.NewThread)
        'CheckForIllegalCrossThreadCalls = False


        'thread3.Start()

    End Sub

    Private Sub RxCloneComplete()
        ml4 = "complete"
        HelperUpdate()

        c1TB.Text = "COMPLETE"
        d1TB.Text = "PRESS CLR/ENT TO EXIT"
        'thread3.Abort()

    End Sub

    Private Sub TxCloneSelectFile()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "SELECT FILE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "ALL PLAN FILES"
        c1TB.Width = 250
        c1TB.Visible = True
        PositionAndHighlight()


        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = c1TB.Text.ToLower
    End Sub

    Private Sub TxConfiguringClone()
        ml4 = "configuring"
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "CONFIGURING"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "CLONE MODE"
        c1TB.Width = 250
        c1TB.Visible = True


        PressClrToAbort()
        d1TB.Visible = True
        HelperUpdate()

        from = "configuring"

        timeItTakes = 5

        MyTimerSetup()

    End Sub

    Private Sub TxCloneInProgress()
        ml4 = "transmitting"
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        b1TB.Text = "TRANSMIT CLONE"
        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "IN PROGRESS"
        c1TB.Width = 250
        c1TB.Visible = True


        PressClrToAbort()
        d1TB.Visible = True
        HelperUpdate()

        from = "transmitting"

        timeItTakes = 5

        MyTimerSetup()

        'thread3 = New Thread(AddressOf Me.NewThread)
        'CheckForIllegalCrossThreadCalls = False


        'thread3.Start()
    End Sub

    Private Sub TxCloneComplete()
        ml4 = "complete"
        HelperUpdate()

        c1TB.Text = "COMPLETE"
        d1TB.Text = "PRESS CLR/ENT TO EXIT"
        'thread3.Abort()
    End Sub

    Private Sub OTARinProgress()
        ml4 = "receiving"
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a2TB.Visible = True
        a3PB.Visible = True
        a4TB.Visible = True
        a5TB.Visible = True
        a6TB.Visible = True
        a7TB.Visible = True

        If ml3 = "receive mk" Then
            b1TB.Text = "OTAR RX MK"
        ElseIf ml3 = "receive ak" Then
            b1TB.Text = "OTAR RX AK"
        End If

        b1TB.Width = 250
        b1TB.Visible = True

        c1TB.Text = "AWAITING RECEPTION"
        c1TB.Width = 250
        c1TB.Visible = True


        PressClrToAbort()
        d1TB.Visible = True
        HelperUpdate()

        from = "OTAR receiving"

        timeItTakes = 5

        MyTimerSetup()

        'thread3 = New Thread(AddressOf Me.NewThread)
        'CheckForIllegalCrossThreadCalls = False


        'thread3.Start()
    End Sub

    Private Sub OTARrecComplete()
        If ml5 = "" Then
            ml4 = "complete"
            HelperUpdate()

            b1TB.Text = "KEY"
            c1TB.Text = "RECEIVED"
            d1TB.Text = "ENT TO CONTINUE/CLR TO ABORT"
        ElseIf ml5 = "aborted" Then
            ml4 = "complete"
            HelperUpdate()

            If ml3 = "receive ak" Then
                b1TB.Text = "OTAR RX AK"
            Else
                b1TB.Text = "OTAR RX MK"
            End If

            c1TB.Text = "ABORTED"
            d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        End If
        ml5 = ""
        'thread3.Abort()
    End Sub

    Private Sub WaveformSelect()
        ml3 = "select"
        ml4 = ""
        HelperUpdate()

        b1TB.Text = "WAVEFORM FOR KEY"
        c1TB.Text = "VULOS"
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"

        PositionAndHighlight()
    End Sub

    Private Sub OtarCryptoModeScreen()
        ml3 = "select"
        ml4 = "crypto mode"
        HelperUpdate()

        b1TB.Text = "CRYPTO MODE"
        c1TB.Text = "VINSON"
        ShowToScrollEntToCont()
        d1TB.Visible = True


        PositionAndHighlight()
    End Sub

    Private Sub OtarAssignmentScreen()
        ml3 = "select"
        ml4 = "otar assignment"

        b1TB.Location = New Point(400, 158)
        b1TB.Width = 200
        b1TB.Text = "KEY TYPE : TEK"
        c1TB.Location = New Point(402, 178)
        c1TB.Width = 130
        c1TB.ForeColor = Color.Black
        c1TB.BackColor = Color.MediumSeaGreen
        c1TB.Text = "KEY NUMBER :"
        c3TB.Text = "01"
        SetWidth(c3TB)
        c3TB.BackColor = Color.Black
        c3TB.ForeColor = Color.MediumSeaGreen
        c3TB.Location = New Point(404 + c1TB.Width, 178)
        c3TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Width = d1TB.Width + 5
        d1TB.Text = "TO SCROLL / ENT TO STORE"

    End Sub

    
    Private Sub OtarStoreScreen()
        ml3 = "select"
        ml4 = "otar store"

        b1TB.Location = New Point(405, 158)
        b1TB.Width = 200
        b1TB.Text = "COMPLETING FILL"
        c1TB.Location = New Point(402, 178)
        c1TB.Visible = False

        c3TB.Text = ""
        SetWidth(c3TB)
        c3TB.BackColor = Color.Black
        c3TB.ForeColor = Color.MediumSeaGreen
        c3TB.Location = New Point(404 + c1TB.Width, 178)
        c3TB.Visible = False
        d1TB.Width = d1TB.Width + 5
        b6PB.Visible = False
        d1TB.Location = New Point(d1TB.Location.X - 20, d1TB.Location.Y)
        d1TB.Text = " . . . WAIT . . . "



        'Setting up a timer
        senderName = "OtarStoreScreen"  'variable representing the sending sub
        Timer1.Enabled = True       'enables the timer
        Timer1.Interval = 3000      'sets the tick interval to 3 seconds



    End Sub

    Private Sub OTARstoreSuccess()
        senderName = "OTARstoreSuccess"
        ml4 = "successful"
        HelperUpdate()

        b1TB.Text = "KEY STORE"
        CenterMe(b1TB)
        c1TB.Text = "SUCCESSFUL"
        CenterMe(c1TB)
        c1TB.Visible = True

        d1TB.Text = "PRESS CLR/ENT TO EXIT"
    End Sub

    Private Sub OtarTransmitting()
        ml3 = "transmitting"
        ml4 = ""

        b1TB.Text = "OTAR MK"
        SetWidth(b1TB)
        CenterMe(b1TB)
        c1TB.Visible = False

        c3TB.Text = "TRANSMITTING"
        SetWidth(c3TB)
        CenterMe(c3TB)
        c3TB.Visible = True

        PressClrToAbort()
        CenterMe(d1TB)
        
        'Setting up a timer
        senderName = "OtarTransmitting"  'variable representing the sending sub
        Timer1.Enabled = True       'enables the timer
        Timer1.Interval = 3000      'sets the tick interval to 3 seconds
    End Sub

    Private Sub OtarTxAborted()
        ml3 = "aborted"
        ml4 = ""

        b1TB.Text = "OTAR MK TRANSMIT"
        SetWidth(b1TB)
        CenterMe(b1TB)
        c1TB.Visible = False

        c3TB.Text = "ABORTED"
        SetWidth(c3TB)
        CenterMe(c3TB)
        c3TB.Visible = True

        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
    End Sub

    Private Sub OtarMKtransmitSuccessful()
        ml3 = "aborted" 'the code for aborted is the same for successful so I just left the abort code alone instead of adding anything to it.
        ml4 = ""

        b1TB.Text = "OTAR MK TRANSMIT"
        SetWidth(b1TB)
        CenterMe(b1TB)
        c1TB.Visible = False

        c3TB.Text = "SUCCESSFUL"
        SetWidth(c3TB)
        CenterMe(c3TB)
        c3TB.Visible = True

        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
    End Sub

    Private Sub ScanChangingPreset()
        'Setting up a timer
        senderName = "ScanChangingPreset"  'variable representing the sending sub
        Timer1.Enabled = True       'enables the timer
        Timer1.Interval = 3000      'sets the tick interval to 3 seconds

        ml3 = "changing"
        ml4 = ""

        a4TB.Text = "SCAN"

        b1TB.Text = "CHANGING PRESET"
        SetWidth(b1TB)
        CenterMe(b1TB)
        c1TB.Visible = False

        c3TB.Text = "100-SCAN"
        SetWidth(c3TB)
        CenterMe(c3TB)
        c3TB.Visible = True

        ShowWAIT()
        'CenterMe(d1TB)
        HelperUpdate()

    End Sub

    Private Sub Scanning()

        'Setting up a timer
        Timer2.Enabled = True       'enables the timer
        Timer2.Interval = 1000      'sets the tick interval to 1 seconds

        senderName = "Scanning"
        ml3 = "scanning"
        ml4 = ""

        b1TB.Text = "SCANNING. . . ."
        SetWidth(b1TB)
        CenterMe(b1TB)
        c1TB.Visible = False

        c3TB.Text = ""
        SetWidth(c3TB)
        CenterMe(c3TB)
        c3TB.Visible = True

        PressCLRtoStop()
        HelperUpdate()
    End Sub


    Private Sub ChangeVolume() 'sets the stage for the volume control when the up or down volumes are pressed

        'check to see if the unit is off
        

        If Timer1.Enabled = True Then
            Timer1.Stop()
        End If
        Timer1.Enabled = True
        Timer1.Interval = 4000



        If senderName = "volumeDown" Then
            If a2TB.Text = "BAT" Or a2TB.Text = "VOL" Then
                a2TB.Text = "VOL"

                If volBar >= 432 Then
                    volBar -= 5
                    If volBar < 432 Then
                        volBar = 432
                    End If
                    ShowVolBar()
                End If


            End If
        End If

        If senderName = "volumeUp" Then
            If a2TB.Text = "BAT" Or a2TB.Text = "VOL" Then
                a2TB.Text = "VOL"

                If volBar <= 478 Then
                    volBar += 5
                    If volBar > 478 Then
                        volBar = 478
                    End If
                    ShowVolBar()
                End If


            End If
        End If
    End Sub

    Private Sub ShowVolBar()

        a3PB.Visible = False


        Me.Controls.Add(volumeBarOutline)
        volumeBarOutline.BorderStyle = BorderStyle.None
        volumeBarOutline.AutoSize = False
        volumeBarOutline.Location = New Point(431, 145)
        volumeBarOutline.BackColor = Color.Black
        volumeBarOutline.Height = 11
        volumeBarOutline.Width = 48
        volumeBarOutline.Visible = True
        volumeBarOutline.BringToFront()

        Me.Controls.Add(volumeBarBackground)
        volumeBarBackground.BorderStyle = BorderStyle.None
        volumeBarBackground.AutoSize = False
        volumeBarBackground.Location = New Point(volBar, 146)
        volumeBarBackground.BackColor = Color.MediumSeaGreen
        volumeBarBackground.Height = 9
        volumeBarBackground.Width = 478 - volBar
        volumeBarBackground.Visible = True
        volumeBarBackground.BringToFront()


        kdu.volumeBarOutline.BorderStyle = BorderStyle.None
        kdu.volumeBarOutline.AutoSize = False
        kdu.volumeBarOutline.Location = New Point(431 - xfactor, 145 - yfactor)
        kdu.volumeBarOutline.BackColor = Color.Black
        kdu.volumeBarOutline.Height = 11
        kdu.volumeBarOutline.Width = 48
        kdu.volumeBarOutline.Visible = True
        kdu.volumeBarOutline.BringToFront()


        kdu.volumeBarBackground.BorderStyle = BorderStyle.None
        kdu.volumeBarBackground.AutoSize = False
        kdu.volumeBarBackground.Location = New Point(volBar - xfactor, 146 - yfactor)
        kdu.volumeBarBackground.BackColor = Color.MediumSeaGreen
        kdu.volumeBarBackground.Height = 9
        kdu.volumeBarBackground.Width = 478 - volBar
        kdu.volumeBarBackground.Visible = True
        kdu.volumeBarBackground.BringToFront()



    End Sub



    'Handles the timing for the delay on screen changes
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        
        Timer1.Stop() 'after 1 tick (set by interval property), the timer stops 

        If knobIndex = 0 Then
            Exit Sub
        End If

        If ml3 = "erasing plans in progress" Then
            ErasingPlansSuccessful()
            Exit Sub
        End If

        If ml3 = "clear plan in progress" Then
            ClearPlanSuccessful()
            Exit Sub
        End If

        If ml3 = "zeroize in progress" Then
            ZeroizeSuccessful()
            Exit Sub
        End If

        If ml3 = "factory defaults restored" Then
            Reboot()
            Exit Sub
        End If

        If ml3 = "restoring factory defaults" Then
            DefaultsReset()
            Exit Sub
        End If

        If ml3 = "scan list full" Then
            ScanList()
            Exit Sub
        End If

        If ml3 = "preset exists" Then
            AddAnotherPreset()
            Exit Sub
        End If

        If senderName = "ChangingPreset" Then
            DisplayVulosPage1()
            Exit Sub
        End If

        If senderName = "RecallPreset" Then
            ChangingPreset()
            Exit Sub
        End If

        If senderName = "Scanning" Then
            a4TB.Visible = True
            Timer2.Enabled = True
            Timer2.Interval = 1000
            Exit Sub
        End If

        If senderName = "ScanChangingPreset" Then
            Scanning()
            Exit Sub
        End If

        If ml3 <> "aborted" Then 'added this to stop SUCCESSFUL from overwriting ABORTED
            If senderName = "OtarStoreScreen" Then
                OTARstoreSuccess()
            ElseIf senderName = "OtarTransmitting" Then
                OtarMKtransmitSuccessful()
            End If
        End If

        If senderName = "volumeUp" Or senderName = "volumeDown" Then
            volumeBarOutline.Visible = False
            volumeBarBackground.Visible = False
            a3PB.Visible = True
            a2TB.Text = "BAT"

            kdu.volumeBarOutline.Visible = False
            kdu.volumeBarBackground.Visible = False
            kdu.a3PB.Visible = True
            kdu.a2TB.Text = "BAT"

        End If
    End Sub

    'alternate timing for the delay on screens
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Timer2.Stop() 'after 1 tick (set by interval property), the timer stops
        a4TB.Visible = False
        Timer1.Enabled = True
        Timer1.Interval = 1000

        
    End Sub



    'centers a textbox on the display
    Public Sub CenterMe(textBox As TextBox)
        textBox.Location = New Point(508 - (textBox.Width / 2), textBox.Location.Y)
    End Sub



    Private Sub RecallPreset()
        If senderName = "Form_Load" Then 'on initial load, this keeps the timer from displaying data on the screen when it shouldn't

        ElseIf senderName = "BtnPreUp" Or senderName = "BtnPreDown" Or senderName = "DisplayVulosPage1" Then 'this line keeps the timer from over-riding the button push
            Timer1.Stop()
            senderName = "RecallPreset"
        Else
            senderName = "RecallPreset"

        End If



        'initially, the preset number and name will change as the preset up or down button is clicked. Rows C and D on the display will change for two seconds 

        Try
            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(0, presetRowNum).Value) = True Then
                storedNumber = " "
            Else
                storedNumber = DataSetForm.PRCtrainerDataGridView.Item(0, presetRowNum).Value 'gets the data from the datagridview on DataSetForm
            End If
            b1TB.Text = storedNumber 'assigns value


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(1, presetRowNum).Value) = True Then
                storedName = " "
            Else
                storedName = DataSetForm.PRCtrainerDataGridView.Item(1, presetRowNum).Value 'same as above to assign the data for the stored recall name
            End If
            b2TB.Text = storedName 'assigns value


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(2, presetRowNum).Value) = True Then
                storedType = " "
            Else
                storedType = DataSetForm.PRCtrainerDataGridView.Item(2, presetRowNum).Value 'same as above to assign the data for the stored recall type
            End If
            c1TB.Text = storedType 'assigns value


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(3, presetRowNum).Value) = True Then
                storedTraffic = " "
            Else
                storedTraffic = DataSetForm.PRCtrainerDataGridView.Item(3, presetRowNum).Value 'same as above to assign the data for the stored recall traffic
            End If
            c3TB.Text = storedTraffic 'assigns value


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(4, presetRowNum).Value) = True Then
                storedMod = " "
            Else
                storedMod = DataSetForm.PRCtrainerDataGridView.Item(4, presetRowNum).Value 'same as above to assign the data for the stored recall modulation
            End If
            c4TB.Text = storedMod 'assigns value

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(5, presetRowNum).Value) = True Then
                storedDescription = " "
            Else
                storedDescription = DataSetForm.PRCtrainerDataGridView.Item(5, presetRowNum).Value 'same as above to assign the data for the stored recall modulation
            End If



            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(6, presetRowNum).Value) = True Then
                storedRXfreq = " "
            Else
                storedRXfreq = DataSetForm.PRCtrainerDataGridView.Item(6, presetRowNum).Value 'same as above to assign the data for the stored recall modulation
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(7, presetRowNum).Value) = True Then
                storedTXfreq = " "
            Else
                storedTXfreq = DataSetForm.PRCtrainerDataGridView.Item(7, presetRowNum).Value 'same as above to assign the data for the stored recall modulation
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(8, presetRowNum).Value) = True Then
                storedWaveform = " "
            Else
                storedWaveform = DataSetForm.PRCtrainerDataGridView.Item(8, presetRowNum).Value 'same as above to assign the data for the stored recall channel
            End If


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(9, presetRowNum).Value) = True Then
                storedChannel = " "
            Else
                storedChannel = DataSetForm.PRCtrainerDataGridView.Item(9, presetRowNum).Value 'same as above to assign the data for the stored recall channel
            End If
            c5TB.Text = storedChannel 'assigns value


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(10, presetRowNum).Value) = True Then
                storedKey = " "
            Else
                storedKey = DataSetForm.PRCtrainerDataGridView.Item(10, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If
            c7TB.Text = storedKey 'assigns value

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(11, presetRowNum).Value) = True Then
                storedOption = " "
            Else
                storedOption = DataSetForm.PRCtrainerDataGridView.Item(11, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(12, presetRowNum).Value) = True Then
                storedBW = " "
            Else
                storedBW = DataSetForm.PRCtrainerDataGridView.Item(12, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(13, presetRowNum).Value) = True Then
                storedBPS = " "
            Else
                storedBPS = DataSetForm.PRCtrainerDataGridView.Item(13, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(14, presetRowNum).Value) = True Then
                storedVoiceMode = " "
            Else
                storedVoiceMode = DataSetForm.PRCtrainerDataGridView.Item(14, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(15, presetRowNum).Value) = True Then
                storedInterleave = " "
            Else
                storedInterleave = DataSetForm.PRCtrainerDataGridView.Item(15, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(16, presetRowNum).Value) = True Then
                storedFWDerror = " "
            Else
                storedFWDerror = DataSetForm.PRCtrainerDataGridView.Item(16, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value) = True Then
                storedSquelch = " "
            Else
                storedSquelch = DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(18, presetRowNum).Value) = True Then
                storedCryptoMode = " "
            Else
                storedCryptoMode = DataSetForm.PRCtrainerDataGridView.Item(18, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(19, presetRowNum).Value) = True Then
                storedCryptoKey = " "
            Else
                storedCryptoKey = DataSetForm.PRCtrainerDataGridView.Item(19, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(20, presetRowNum).Value) = True Then
                storedSatcomChannel = " "
            Else
                storedSatcomChannel = DataSetForm.PRCtrainerDataGridView.Item(20, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(21, presetRowNum).Value) = True Then
                storedDataMode = " "
            Else
                storedDataMode = DataSetForm.PRCtrainerDataGridView.Item(21, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(22, presetRowNum).Value) = True Then
                storedFascinatorMode = " "
            Else
                storedFascinatorMode = DataSetForm.PRCtrainerDataGridView.Item(22, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(23, presetRowNum).Value) = True Then
                storedAESmode = " "
            Else
                storedAESmode = DataSetForm.PRCtrainerDataGridView.Item(23, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(24, presetRowNum).Value) = True Then
                storedKG84Mode = " "
            Else
                storedKG84Mode = DataSetForm.PRCtrainerDataGridView.Item(24, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(25, presetRowNum).Value) = True Then
                storedTrainingFrames = " "
            Else
                storedTrainingFrames = DataSetForm.PRCtrainerDataGridView.Item(25, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(26, presetRowNum).Value) = True Then
                storedRXfade = " "
            Else
                storedRXfade = DataSetForm.PRCtrainerDataGridView.Item(26, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(27, presetRowNum).Value) = True Then
                storedAutoswitch = " "
            Else
                storedAutoswitch = DataSetForm.PRCtrainerDataGridView.Item(27, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(28, presetRowNum).Value) = True Then
                storedKeySource = " "
            Else
                storedKeySource = DataSetForm.PRCtrainerDataGridView.Item(28, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(29, presetRowNum).Value) = True Then
                storedCodebook = " "
            Else
                storedCodebook = DataSetForm.PRCtrainerDataGridView.Item(29, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(30, presetRowNum).Value) = True Then
                storedDeviation = " "
            Else
                storedDeviation = DataSetForm.PRCtrainerDataGridView.Item(30, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(31, presetRowNum).Value) = True Then
                storedOptMod = " "
            Else
                storedOptMod = DataSetForm.PRCtrainerDataGridView.Item(31, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(32, presetRowNum).Value) = True Then
                storedTXpower = " "
            Else
                storedTXpower = DataSetForm.PRCtrainerDataGridView.Item(32, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(33, presetRowNum).Value) = True Then
                storedTXpowerDown = " "
            Else
                storedTXpowerDown = DataSetForm.PRCtrainerDataGridView.Item(33, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(34, presetRowNum).Value) = True Then
                manualSquelchSetting = 0
            Else
                manualSquelchSetting = DataSetForm.PRCtrainerDataGridView.Item(34, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(35, presetRowNum).Value) = True Then
                storedCTCSS = " "
            Else
                storedCTCSS = DataSetForm.PRCtrainerDataGridView.Item(35, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(36, presetRowNum).Value) = True Then
                storedCTCSSrx = " "
            Else
                storedCTCSSrx = DataSetForm.PRCtrainerDataGridView.Item(36, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(37, presetRowNum).Value) = True Then
                storedCTCSSuserEntry = " "
            Else
                storedCTCSSuserEntry = DataSetForm.PRCtrainerDataGridView.Item(37, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(38, presetRowNum).Value) = True Then
                storedCTCSSrxUserEntry = " "
            Else
                storedCTCSSrxUserEntry = DataSetForm.PRCtrainerDataGridView.Item(38, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(39, presetRowNum).Value) = True Then
                storedCTCSSrx = " "
            Else
                storedCTCSSrx = DataSetForm.PRCtrainerDataGridView.Item(39, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(40, presetRowNum).Value) = True Then
                storedChannelBusyPriority = " "
            Else
                storedChannelBusyPriority = DataSetForm.PRCtrainerDataGridView.Item(40, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(41, presetRowNum).Value) = True Then
                storedCDCSStxCode = " "
            Else
                storedCDCSStxCode = DataSetForm.PRCtrainerDataGridView.Item(41, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(42, presetRowNum).Value) = True Then
                storedCDCSSrxCode = " "
            Else
                storedCDCSSrxCode = DataSetForm.PRCtrainerDataGridView.Item(42, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(43, presetRowNum).Value) = True Then
                storedVinsonCompatibility = " "
            Else
                storedVinsonCompatibility = DataSetForm.PRCtrainerDataGridView.Item(43, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(44, presetRowNum).Value) = True Then
                storedBeaconFreq = " "
            Else
                storedBeaconFreq = DataSetForm.PRCtrainerDataGridView.Item(44, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(45, presetRowNum).Value) = True Then
                storedBeaconMod = " "
            Else
                storedBeaconMod = DataSetForm.PRCtrainerDataGridView.Item(45, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(46, presetRowNum).Value) = True Then
                storedBeaconTxDuration = " "
            Else
                storedBeaconTxDuration = DataSetForm.PRCtrainerDataGridView.Item(46, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(47, presetRowNum).Value) = True Then
                storedBeaconOffDuration = " "
            Else
                storedBeaconOffDuration = DataSetForm.PRCtrainerDataGridView.Item(47, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(48, presetRowNum).Value) = True Then
                storedBeaconTxPower = " "
            Else
                storedBeaconTxPower = DataSetForm.PRCtrainerDataGridView.Item(48, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(49, presetRowNum).Value) = True Then
                storedSpare = " "
            Else
                storedSpare = DataSetForm.PRCtrainerDataGridView.Item(49, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(50, presetRowNum).Value) = True Then
                storedInScanList = " "
            Else
                storedInScanList = DataSetForm.PRCtrainerDataGridView.Item(50, presetRowNum).Value 'same as above to assign the data for the stored recall key
            End If

            'RecallOptions() 'gets the Options table data

            GetMyGlobalData() 'recalls the data from the global table

        Catch

        End Try

        If ml3 = "system preset number" Or ml3 = "add scan list" Then
            Exit Sub
        End If

        If storedDescription = " " Then
            c1TB.Text = "INSERT DESCRIPTION"
        Else
            c1TB.Text = storedDescription

        End If

        SetWidth(c1TB)
        CenterMe(c1TB)
        b6PB.Visible = False
        b7PB.Visible = False
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

        d1TB.Text = "WAIT/ENT TO SELECT/CLR TO EXIT"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

        'start the 2 second timer
        If senderName <> "Form_Load" Then 'the only time this IF statement should be invoked is on the initial form load
            Timer1.Start()
            Timer1.Interval = 2000

        End If






    End Sub



    Private Sub ChangingPreset()
        senderName = "ChangingPreset"


        HideRowB()
        HideRowC()
        HideRowD()

        b1TB.Text = "CHANGING PRESET"
        b1TB.Visible = True
        SetWidth(b1TB)
        CenterMe(b1TB)

        c1TB.Text = storedNumber + storedName
        c1TB.Visible = True
        SetWidth(c1TB)
        CenterMe(c1TB)

        ShowWAIT()
        d1TB.Visible = True


        Timer1.Start()
        Timer1.Interval = 1000

    End Sub

    

    
    Private Sub Backlight() 'determines the state of the displays backlight
        If light = 1 Then
            BacklightOff()
        ElseIf light = 0 Then
            BacklightOn()
        End If
    End Sub

    Private Sub BacklightOff()
        light = 0 'sets the light variable to OFF
        mycolor = Color.ForestGreen


    End Sub

    Private Sub BacklightOn()
        light = 1 'sets the light variable to ON
        mycolor = Color.MediumSeaGreen
        



    End Sub

    Private Sub HideRowB()
        b1TB.Visible = False
        b2TB.Visible = False
        b6PB.Visible = False
        b7PB.Visible = False

    End Sub

    Private Sub HideRowC()
        c1TB.Visible = False
        c3TB.Visible = False
        c4TB.Visible = False
        c5TB.Visible = False
        c7TB.Visible = False

    End Sub

    Private Sub HideRowD()
        d1TB.Visible = False
        d3TB.Visible = False
        d4TB.Visible = False
        d6TB.Visible = False
        d7TB.Visible = False

    End Sub

    'used to highlight text
    Private Sub Highlight(tb As TextBox)
        tb.BackColor = Color.Black
        tb.ForeColor = Color.MediumSeaGreen

    End Sub

    Private Sub ProgramMain()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        CreateNewScrollingMenu("RADIO CONFIG", "SYSTEM PRESETS", "VULOS CONFIG") 'works with up to 11 items and creates scrollbar

        
        ml2 = ""
        ml3 = ""
        ml4 = ""

    End Sub


    Private Sub ProgramScrollUp()
        If ml1 = "program" Then
            If d1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                d1TB.BackColor = Color.MediumSeaGreen
                d1TB.ForeColor = Color.Black
               


            ElseIf c1TB.BackColor = Color.Black Then
                b1TB.BackColor = Color.Black
                b1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black
               

            Else
                
                ProgramMoveUp()


            End If
        End If

        MeasureArray()
        AutoScrollbar()


    End Sub

    Private Sub ProgramMoveUp()
        If b1TB.Text <> "RADIO CONFIG" Then 'stops scrolling when it reaches the top
            d1TB.Text = c1TB.Text

            c1TB.Text = b1TB.Text
            scrollingUp = b1TB.Text
        End If



        Select Case scrollingUp

            Case "SYSTEM PRESETS"
                b1TB.Text = "RADIO CONFIG"
                b7PB.BackgroundImage = My.Resources.ScrollBar1
            Case "ANW2B CONFIG"
                b1TB.Text = "SYSTEM PRESETS"
                b7PB.BackgroundImage = My.Resources.scrollbar2
            Case "ANW2 CONFIG"
                b1TB.Text = "ANW2B CONFIG"
                b7PB.BackgroundImage = My.Resources.scrollbar2
            Case "VULOS CONFIG"
                b1TB.Text = "ANW2 CONFIG"
                b7PB.BackgroundImage = My.Resources.scrollbar3
            Case "HAVEQUICK CONFIG"
                b1TB.Text = "VULOS CONFIG"
                b7PB.BackgroundImage = My.Resources.ScrollBar4
            Case "SINCGARS CONFIG"
                b1TB.Text = "HAVEQUICK CONFIG"
                b7PB.BackgroundImage = My.Resources.scrollbar5
            
            
            

        End Select
        SetWidth(b1TB)
        SetWidth(c1TB)
        SetWidth(d1TB)

        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.TextAlign = HorizontalAlignment.Left
        d1TB.TextAlign = HorizontalAlignment.Left
    End Sub

    Private Sub ProgramScrollDn()
        If ml1 = "program" Then
            If b1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                b1TB.BackColor = Color.MediumSeaGreen
                b1TB.ForeColor = Color.Black


            ElseIf c1TB.BackColor = Color.Black Then
                d1TB.BackColor = Color.Black
                d1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black

            Else
                
                ProgramMoveDn()

            End If
        End If

        MeasureArray()
        AutoScrollbar()

    End Sub

    Private Sub ProgramMoveDn()
        If d1TB.Text <> "SINCGARS CONFIG" Then 'stops scrolling when it reaches the bottom
            b1TB.Text = c1TB.Text

            c1TB.Text = d1TB.Text
            scrollingUp = d1TB.Text
        End If



        Select Case scrollingUp

            Case "ANW2B CONFIG"
                d1TB.Text = "ANW2 CONFIG"
                b7PB.BackgroundImage = My.Resources.ScrollBar1
            Case "ANW2 CONFIG"
                d1TB.Text = "VULOS CONFIG"
                b7PB.BackgroundImage = My.Resources.scrollbar2
            Case "VULOS CONFIG"
                d1TB.Text = "HAVEQUICK CONFIG"
                b7PB.BackgroundImage = My.Resources.scrollbar2
            Case "HAVEQUICK CONFIG"
                d1TB.Text = "SINCGARS CONFIG"
                b7PB.BackgroundImage = My.Resources.scrollbar3
            




        End Select
        SetWidth(b1TB)
        SetWidth(c1TB)
        SetWidth(d1TB)

        b1TB.TextAlign = HorizontalAlignment.Left
        c1TB.TextAlign = HorizontalAlignment.Left
        d1TB.TextAlign = HorizontalAlignment.Left
    End Sub

    Private Sub SystemPresetsMenu()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-SYS PRESETS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "SYSTEM PRESET CONFIG"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "RESET SYSTEM PRESET"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "SYSTEM SCAN CONFIG"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        menuChoices = "system presets menu"
        SelectMenu()
        MeasureArray()

        AutoScrollbar()
        JustificationAndSetWidth()
        ml3 = ""
        ml4 = ""
    End Sub

    Private Sub ScrollDown()
        If b1TB.BackColor = Color.Black Then
            c1TB.BackColor = Color.Black
            c1TB.ForeColor = Color.MediumSeaGreen
            b1TB.BackColor = Color.MediumSeaGreen
            b1TB.ForeColor = Color.Black


        ElseIf c1TB.BackColor = Color.Black Then
            d1TB.BackColor = Color.Black
            d1TB.ForeColor = Color.MediumSeaGreen
            c1TB.BackColor = Color.MediumSeaGreen
            c1TB.ForeColor = Color.Black
        End If

    End Sub

    Private Sub ScrollUp()
        If d1TB.BackColor = Color.Black Then
            c1TB.BackColor = Color.Black
            c1TB.ForeColor = Color.MediumSeaGreen
            d1TB.BackColor = Color.MediumSeaGreen
            d1TB.ForeColor = Color.Black



        ElseIf c1TB.BackColor = Color.Black Then
            b1TB.BackColor = Color.Black
            b1TB.ForeColor = Color.MediumSeaGreen
            c1TB.BackColor = Color.MediumSeaGreen
            c1TB.ForeColor = Color.Black
        End If

    End Sub

    Private Sub SystemPresetNumber()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-SYS PRESETS-CFG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "SYSTEM PRESET NUMBER"
        b1TB.Visible = True
        SetWidth(b1TB)

        c1TB.Text = storedNumber
        c1TB.Visible = True
        SetWidth(c1TB)



        If storedName.Contains("PRESET") And storedName.IndexOf("P") = 1 = True Then
            c3TB.Text = "<EMPTY>"
        Else
            c3TB.Text = storedName
        End If

        SetWidth(c3TB)
        c3TB.Location = New Point(c3TB.Location.X - 15, c3TB.Location.Y)
        c3TB.TextAlign = HorizontalAlignment.Left
        c3TB.Visible = True


        d1TB.Text = "ENTER 01-99/PRE +/- TO SCROLL"
        d1TB.Visible = True
        SetWidth(d1TB)
        CenterMe(d1TB)

        ml1 = "program"
        ml3 = "system preset number"

    End Sub

    Private Sub ResetSystemPreset()

    End Sub

    Private Sub PresetDescription()  'preset description page

        Dim myChannel As String
        myChannel = storedNumber.Trim("-")
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-SYS PRESETS-CFG-" + myChannel
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "PRESET DESCRIPTION"
        b1TB.Visible = True
        SetWidth(b1TB)
        CenterMe(b1TB)

        If storedDescription = " " Then

            BreakMeUp("INSERT DESCRIPTION")
            DescriptionEntry()

        Else

            'split apart stored name into individual characters and place them in the nameboxes
            BreakMeUp(storedDescription)
            DescriptionEntry()

        End If

        nameBox1.Visible = True



        d1TB.Text = "ENTER DESCRIPTION"
        d1TB.Visible = True
        SetWidth(d1TB)
        CenterMe(d1TB)


        ml3 = "preset description"
        HelperUpdate()

    End Sub

    
    Private Sub DescriptionEntry()

        'add the textboxes to store the information



        nameBox1.Visible = False
        nameBox2.Visible = False
        nameBox3.Visible = False
        nameBox4.Visible = False
        nameBox5.Visible = False
        nameBox6.Visible = False
        nameBox7.Visible = False
        nameBox8.Visible = False
        nameBox9.Visible = False
        nameBox10.Visible = False
        nameBox11.Visible = False
        nameBox12.Visible = False
        nameBox13.Visible = False
        nameBox14.Visible = False
        nameBox15.Visible = False
        nameBox16.Visible = False
        nameBox17.Visible = False
        nameBox18.Visible = False
        nameBox19.Visible = False
        nameBox20.Visible = False



        Me.Controls.Add(nameBox1)
        Me.Controls.Add(nameBox2)
        Me.Controls.Add(nameBox3)
        Me.Controls.Add(nameBox4)
        Me.Controls.Add(nameBox5)
        Me.Controls.Add(nameBox6)
        Me.Controls.Add(nameBox7)
        Me.Controls.Add(nameBox8)
        Me.Controls.Add(nameBox9)
        Me.Controls.Add(nameBox10)
        Me.Controls.Add(nameBox11)
        Me.Controls.Add(nameBox12)
        Me.Controls.Add(nameBox13)
        Me.Controls.Add(nameBox14)
        Me.Controls.Add(nameBox15)
        Me.Controls.Add(nameBox16)
        Me.Controls.Add(nameBox17)
        Me.Controls.Add(nameBox18)
        Me.Controls.Add(nameBox19)
        Me.Controls.Add(nameBox20)




        CreateNameboxes()



        nameBox1.Visible = True
        nameBox2.Visible = True
        nameBox3.Visible = True
        nameBox4.Visible = True
        nameBox5.Visible = True
        nameBox6.Visible = True
        nameBox7.Visible = True
        nameBox8.Visible = True
        nameBox9.Visible = True
        nameBox10.Visible = True
        nameBox11.Visible = True
        nameBox12.Visible = True
        nameBox13.Visible = True
        nameBox14.Visible = True
        nameBox15.Visible = True
        nameBox16.Visible = True
        nameBox17.Visible = True
        nameBox18.Visible = True
        nameBox19.Visible = True
        nameBox20.Visible = True




    End Sub
    

    Private Sub BreakMeUp(name As String) 'splits a string into individual characters

        Try
            nameBox1.Text = GetChar(name, 1)
            nameBox2.Text = GetChar(name, 2)
            nameBox3.Text = GetChar(name, 3)
            nameBox4.Text = GetChar(name, 4)
            nameBox5.Text = GetChar(name, 5)
            nameBox6.Text = GetChar(name, 6)
            nameBox7.Text = GetChar(name, 7)
            nameBox8.Text = GetChar(name, 8)
            nameBox9.Text = GetChar(name, 9)
            nameBox10.Text = GetChar(name, 10)
            nameBox11.Text = GetChar(name, 11)
            nameBox12.Text = GetChar(name, 12)
            nameBox13.Text = GetChar(name, 13)
            nameBox14.Text = GetChar(name, 14)
            nameBox15.Text = GetChar(name, 15)
            nameBox16.Text = GetChar(name, 16)
            nameBox17.Text = GetChar(name, 17)
            nameBox18.Text = GetChar(name, 18)
            nameBox19.Text = GetChar(name, 19)
            nameBox20.Text = GetChar(name, 20)
        Catch
        End Try




    End Sub


    Private Sub b1TB_ForeColorChanged(sender As Object, e As EventArgs) Handles b1TB.ForeColorChanged
        If b1TB.Text <> "PRESET DESCRIPTION" Then


            Try
                nameBox1.Visible = False
                nameBox2.Visible = False
                nameBox3.Visible = False
                nameBox4.Visible = False
                nameBox5.Visible = False
                nameBox6.Visible = False
                nameBox7.Visible = False
                nameBox8.Visible = False
                nameBox9.Visible = False
                nameBox10.Visible = False
                nameBox11.Visible = False
                nameBox12.Visible = False
                nameBox13.Visible = False
                nameBox14.Visible = False
                nameBox15.Visible = False
                nameBox16.Visible = False
                nameBox17.Visible = False
                nameBox18.Visible = False
                nameBox19.Visible = False
                nameBox20.Visible = False

                nameBox1.Text = ""
                nameBox2.Text = ""
                nameBox3.Text = ""
                nameBox4.Text = ""
                nameBox5.Text = ""
                nameBox6.Text = ""
                nameBox7.Text = ""
                nameBox8.Text = ""
                nameBox9.Text = ""
                nameBox10.Text = ""
                nameBox11.Text = ""
                nameBox12.Text = ""
                nameBox13.Text = ""
                nameBox14.Text = ""
                nameBox15.Text = ""
                nameBox16.Text = ""
                nameBox17.Text = ""
                nameBox18.Text = ""
                nameBox19.Text = ""
                nameBox20.Text = ""
            Catch
            End Try



        End If


    End Sub


    Private Sub GetHighlightedNamebox()

        If nameBox1.BackColor = Color.Black Then
            highlightedNameBox = nameBox1
            lastBox = nameBox1
            nextBox = nameBox2

        ElseIf nameBox2.BackColor = Color.Black Then
            highlightedNameBox = nameBox2
            lastBox = nameBox1
            nextBox = nameBox3

        ElseIf nameBox3.BackColor = Color.Black Then
            highlightedNameBox = nameBox3
            lastBox = nameBox2
            nextBox = nameBox4

        ElseIf nameBox4.BackColor = Color.Black Then
            highlightedNameBox = nameBox4
            lastBox = nameBox3
            nextBox = nameBox5

        ElseIf nameBox5.BackColor = Color.Black Then
            highlightedNameBox = nameBox5
            lastBox = nameBox4
            nextBox = nameBox6

        ElseIf nameBox6.BackColor = Color.Black Then
            highlightedNameBox = nameBox6
            lastBox = nameBox5
            nextBox = nameBox7

        ElseIf nameBox7.BackColor = Color.Black Then
            highlightedNameBox = nameBox7
            lastBox = nameBox6
            nextBox = nameBox8

        ElseIf nameBox8.BackColor = Color.Black Then
            highlightedNameBox = nameBox8
            lastBox = nameBox7
            nextBox = nameBox9

        ElseIf nameBox9.BackColor = Color.Black Then
            highlightedNameBox = nameBox9
            lastBox = nameBox8
            nextBox = nameBox10

        ElseIf nameBox10.BackColor = Color.Black Then
            highlightedNameBox = nameBox10
            lastBox = nameBox9
            nextBox = nameBox11

        ElseIf nameBox11.BackColor = Color.Black Then
            highlightedNameBox = nameBox11
            lastBox = nameBox10
            nextBox = nameBox12

        ElseIf nameBox12.BackColor = Color.Black Then
            highlightedNameBox = nameBox12
            lastBox = nameBox11
            nextBox = nameBox13

        ElseIf nameBox13.BackColor = Color.Black Then
            highlightedNameBox = nameBox13
            lastBox = nameBox12
            nextBox = nameBox14

        ElseIf nameBox14.BackColor = Color.Black Then
            highlightedNameBox = nameBox14
            lastBox = nameBox13
            nextBox = nameBox15

        ElseIf nameBox15.BackColor = Color.Black Then
            highlightedNameBox = nameBox15
            lastBox = nameBox14
            nextBox = nameBox16

        ElseIf nameBox16.BackColor = Color.Black Then
            highlightedNameBox = nameBox16
            lastBox = nameBox15
            nextBox = nameBox17

        ElseIf nameBox17.BackColor = Color.Black Then
            highlightedNameBox = nameBox17
            lastBox = nameBox16
            nextBox = nameBox18

        ElseIf nameBox18.BackColor = Color.Black Then
            highlightedNameBox = nameBox18
            lastBox = nameBox17
            nextBox = nameBox19

        ElseIf nameBox19.BackColor = Color.Black Then
            highlightedNameBox = nameBox19
            lastBox = nameBox18
            nextBox = nameBox20

        ElseIf nameBox20.BackColor = Color.Black Then
            highlightedNameBox = nameBox20
            lastBox = nameBox19
            nextBox = nameBox20

        End If
    End Sub

    Private Sub CreateNameboxes()


        'sets the location of the textboxes
        Dim vertLoc As Integer
        vertLoc = c1TB.Location.Y



        'sets the color of the boxes and show them
        nameBox1.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox1.TextAlign = HorizontalAlignment.Center
        nameBox1.ForeColor = Color.MediumSeaGreen
        nameBox1.BorderStyle = BorderStyle.None
        nameBox1.BackColor = Color.Black
        SetWidth(nameBox1)
        nameBox1.Location = New Point(c1TB.Location)
        nameBox1.BringToFront()

        nameBox2.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox2.TextAlign = HorizontalAlignment.Center
        nameBox2.ForeColor = Color.Black
        nameBox2.BorderStyle = BorderStyle.None
        nameBox2.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox2)
        nameBox2.Location = New Point(nameBox1.Location.X + nameBox1.Width, vertLoc)
        nameBox2.BringToFront()

        nameBox3.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox3.TextAlign = HorizontalAlignment.Center
        nameBox3.ForeColor = Color.Black
        nameBox3.BorderStyle = BorderStyle.None
        nameBox3.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox3)
        nameBox3.Location = New Point(nameBox2.Location.X + nameBox2.Width, vertLoc)
        nameBox3.BringToFront()

        nameBox4.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox4.TextAlign = HorizontalAlignment.Center
        nameBox4.ForeColor = Color.Black
        nameBox4.BorderStyle = BorderStyle.None
        nameBox4.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox4)
        nameBox4.Location = New Point(nameBox3.Location.X + nameBox3.Width, vertLoc)
        nameBox4.BringToFront()

        nameBox5.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox5.TextAlign = HorizontalAlignment.Center
        nameBox5.ForeColor = Color.Black
        nameBox5.BorderStyle = BorderStyle.None
        nameBox5.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox5)
        nameBox5.Location = New Point(nameBox4.Location.X + nameBox4.Width, vertLoc)
        nameBox5.BringToFront()

        nameBox6.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox6.TextAlign = HorizontalAlignment.Center
        nameBox6.ForeColor = Color.Black
        nameBox6.BorderStyle = BorderStyle.None
        nameBox6.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox6)
        nameBox6.Location = New Point(nameBox5.Location.X + nameBox5.Width, vertLoc)
        nameBox6.BringToFront()

        nameBox7.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox7.TextAlign = HorizontalAlignment.Center
        nameBox7.ForeColor = Color.Black
        nameBox7.BorderStyle = BorderStyle.None
        nameBox7.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox7)
        nameBox7.Location = New Point(nameBox6.Location.X + nameBox6.Width, vertLoc)
        nameBox7.BringToFront()

        nameBox8.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox8.TextAlign = HorizontalAlignment.Center
        nameBox8.ForeColor = Color.Black
        nameBox8.BorderStyle = BorderStyle.None
        nameBox8.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox8)
        nameBox8.Location = New Point(nameBox7.Location.X + nameBox7.Width, vertLoc)
        nameBox8.BringToFront()

        nameBox9.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox9.TextAlign = HorizontalAlignment.Center
        nameBox9.ForeColor = Color.Black
        nameBox9.BorderStyle = BorderStyle.None
        nameBox9.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox9)
        nameBox9.Location = New Point(nameBox8.Location.X + nameBox8.Width, vertLoc)
        nameBox9.BringToFront()

        nameBox10.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox10.TextAlign = HorizontalAlignment.Center
        nameBox10.ForeColor = Color.Black
        nameBox10.BorderStyle = BorderStyle.None
        nameBox10.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox10)
        nameBox10.Location = New Point(nameBox9.Location.X + nameBox9.Width, vertLoc)
        nameBox10.BringToFront()

        nameBox11.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox11.TextAlign = HorizontalAlignment.Center
        nameBox11.ForeColor = Color.Black
        nameBox11.BorderStyle = BorderStyle.None
        nameBox11.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox11)
        nameBox11.Location = New Point(nameBox10.Location.X + nameBox10.Width, vertLoc)
        nameBox11.BringToFront()

        nameBox12.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox12.TextAlign = HorizontalAlignment.Center
        nameBox12.ForeColor = Color.Black
        nameBox12.BorderStyle = BorderStyle.None
        nameBox12.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox12)
        nameBox12.Location = New Point(nameBox11.Location.X + nameBox11.Width, vertLoc)
        nameBox12.BringToFront()

        nameBox13.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox13.TextAlign = HorizontalAlignment.Center
        nameBox13.ForeColor = Color.Black
        nameBox13.BorderStyle = BorderStyle.None
        nameBox13.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox13)
        nameBox13.Location = New Point(nameBox12.Location.X + nameBox12.Width, vertLoc)
        nameBox13.BringToFront()

        nameBox14.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox14.TextAlign = HorizontalAlignment.Center
        nameBox14.ForeColor = Color.Black
        nameBox14.BorderStyle = BorderStyle.None
        nameBox14.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox14)
        nameBox14.Location = New Point(nameBox13.Location.X + nameBox13.Width, vertLoc)
        nameBox14.BringToFront()

        nameBox15.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox15.TextAlign = HorizontalAlignment.Center
        nameBox15.ForeColor = Color.Black
        nameBox15.BorderStyle = BorderStyle.None
        nameBox15.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox15)
        nameBox15.Location = New Point(nameBox14.Location.X + nameBox14.Width, vertLoc)
        nameBox15.BringToFront()

        nameBox16.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox16.TextAlign = HorizontalAlignment.Center
        nameBox16.ForeColor = Color.Black
        nameBox16.BorderStyle = BorderStyle.None
        nameBox16.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox16)
        nameBox16.Location = New Point(nameBox15.Location.X + nameBox15.Width, vertLoc)
        nameBox16.BringToFront()

        nameBox17.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox17.TextAlign = HorizontalAlignment.Center
        nameBox17.ForeColor = Color.Black
        nameBox17.BorderStyle = BorderStyle.None
        nameBox17.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox17)
        nameBox17.Location = New Point(nameBox16.Location.X + nameBox16.Width, vertLoc)
        nameBox17.BringToFront()

        nameBox18.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox18.TextAlign = HorizontalAlignment.Center
        nameBox18.ForeColor = Color.Black
        nameBox18.BorderStyle = BorderStyle.None
        nameBox18.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox18)
        nameBox18.Location = New Point(nameBox17.Location.X + nameBox17.Width, vertLoc)
        nameBox18.BringToFront()

        nameBox19.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox19.TextAlign = HorizontalAlignment.Center
        nameBox19.ForeColor = Color.Black
        nameBox19.BorderStyle = BorderStyle.None
        nameBox19.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox19)
        nameBox19.Location = New Point(nameBox18.Location.X + nameBox18.Width, vertLoc)
        nameBox19.BringToFront()

        nameBox20.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox20.TextAlign = HorizontalAlignment.Center
        nameBox20.ForeColor = Color.Black
        nameBox20.BorderStyle = BorderStyle.None
        nameBox20.BackColor = Color.MediumSeaGreen
        SetWidth(nameBox20)
        nameBox20.Location = New Point(nameBox19.Location.X + nameBox19.Width, vertLoc)
        nameBox20.BringToFront()




    End Sub

    Private Sub PresetNameMoveRight()

        GetRidOfINSERTDESCRIPTION()

        GetHighlightedNamebox() 'gets the name of the highlighted TB

        If (ml3 = "change maint pswd" Or ml3 = "confirm maint pswd" Or ml3 = "enter maint pswd") And highlightedNameBox.Text = "*" Then
            Exit Sub
        End If


        If nameBox1.Text = "" Then

        ElseIf nameBox15.BackColor = Color.Black Then

        ElseIf nameBox8.BackColor = Color.Black And (ml3 = "beacon frequency" Or ml3 = "vulos rx freq") Then

        ElseIf nameBox12.BackColor = Color.Black And (ml3 = "change maint pswd" Or ml3 = "confirm maint pswd" Or ml3 = "reenter maint pswd" Or ml3 = "enter maint pswd") Then

        ElseIf nameBox3.BackColor = Color.Black And ml3 = "voice key up timeout time" Then


        Else

            lastBox = highlightedNameBox
            highlightedNameBox = nextBox

            lastBox.BackColor = Color.MediumSeaGreen
            lastBox.ForeColor = Color.Black

            highlightedNameBox.BackColor = Color.Black
            highlightedNameBox.ForeColor = Color.MediumSeaGreen

            If highlightedNameBox.Text = "." Then
                lastBox = nameBox4
                highlightedNameBox = nameBox5


                lastBox.BackColor = Color.MediumSeaGreen
                lastBox.ForeColor = Color.Black

                highlightedNameBox.BackColor = Color.Black
                highlightedNameBox.ForeColor = Color.MediumSeaGreen

            End If



        End If



    End Sub

    Private Sub PresetNameMoveLeft()

        GetRidOfINSERTDESCRIPTION()

        GetHighlightedNamebox() 'gets the name of the highlighted TB

        If nameBox1.Text = "" Then

        Else
            nextBox = highlightedNameBox
            highlightedNameBox = lastBox

            nextBox.BackColor = Color.MediumSeaGreen
            nextBox.ForeColor = Color.Black

            highlightedNameBox.BackColor = Color.Black
            highlightedNameBox.ForeColor = Color.MediumSeaGreen

            If highlightedNameBox.Text = "." Then
                lastBox = nameBox4
                highlightedNameBox = nameBox3


                lastBox.BackColor = Color.MediumSeaGreen
                lastBox.ForeColor = Color.Black

                highlightedNameBox.BackColor = Color.Black
                highlightedNameBox.ForeColor = Color.MediumSeaGreen

            End If

        End If



    End Sub

    Private Sub ArrangeNameboxes()


        'sets the location of the textboxes
        Dim vertLoc As Integer
        vertLoc = c1TB.Location.Y



        SetWidth(nameBox1)
        nameBox1.Location = New Point(c1TB.Location)
        nameBox1.BringToFront()

       
        SetWidth(nameBox2)
        nameBox2.Location = New Point(nameBox1.Location.X + nameBox1.Width, vertLoc)
        nameBox2.BringToFront()

       
        SetWidth(nameBox3)
        nameBox3.Location = New Point(nameBox2.Location.X + nameBox2.Width, vertLoc)
        nameBox3.BringToFront()

       
        SetWidth(nameBox4)
        nameBox4.Location = New Point(nameBox3.Location.X + nameBox3.Width, vertLoc)
        nameBox4.BringToFront()

        
        SetWidth(nameBox5)
        nameBox5.Location = New Point(nameBox4.Location.X + nameBox4.Width, vertLoc)
        nameBox5.BringToFront()

        
        SetWidth(nameBox6)
        nameBox6.Location = New Point(nameBox5.Location.X + nameBox5.Width, vertLoc)
        nameBox6.BringToFront()

       
        SetWidth(nameBox7)
        nameBox7.Location = New Point(nameBox6.Location.X + nameBox6.Width, vertLoc)
        nameBox7.BringToFront()

       
        SetWidth(nameBox8)
        nameBox8.Location = New Point(nameBox7.Location.X + nameBox7.Width, vertLoc)
        nameBox8.BringToFront()

       
        SetWidth(nameBox9)
        nameBox9.Location = New Point(nameBox8.Location.X + nameBox8.Width, vertLoc)
        nameBox9.BringToFront()

       
        SetWidth(nameBox10)
        nameBox10.Location = New Point(nameBox9.Location.X + nameBox9.Width, vertLoc)
        nameBox10.BringToFront()

       
        SetWidth(nameBox11)
        nameBox11.Location = New Point(nameBox10.Location.X + nameBox10.Width, vertLoc)
        nameBox11.BringToFront()

        
        SetWidth(nameBox12)
        nameBox12.Location = New Point(nameBox11.Location.X + nameBox11.Width, vertLoc)
        nameBox12.BringToFront()

        
        SetWidth(nameBox13)
        nameBox13.Location = New Point(nameBox12.Location.X + nameBox12.Width, vertLoc)
        nameBox13.BringToFront()

       
        SetWidth(nameBox14)
        nameBox14.Location = New Point(nameBox13.Location.X + nameBox13.Width, vertLoc)
        nameBox14.BringToFront()

        
        SetWidth(nameBox15)
        nameBox15.Location = New Point(nameBox14.Location.X + nameBox14.Width, vertLoc)
        nameBox15.BringToFront()

        
        SetWidth(nameBox16)
        nameBox16.Location = New Point(nameBox15.Location.X + nameBox15.Width, vertLoc)
        nameBox16.BringToFront()

       
        SetWidth(nameBox17)
        nameBox17.Location = New Point(nameBox16.Location.X + nameBox16.Width, vertLoc)
        nameBox17.BringToFront()

        
        SetWidth(nameBox18)
        nameBox18.Location = New Point(nameBox17.Location.X + nameBox17.Width, vertLoc)
        nameBox18.BringToFront()

       
        SetWidth(nameBox19)
        nameBox19.Location = New Point(nameBox18.Location.X + nameBox18.Width, vertLoc)
        nameBox19.BringToFront()

        
        SetWidth(nameBox20)
        nameBox20.Location = New Point(nameBox19.Location.X + nameBox19.Width, vertLoc)
        nameBox20.BringToFront()


    End Sub

    Private Sub GetRidOfINSERTDESCRIPTION() 'used in the program menu to auto delete the characters in the nameBoxes

        testString = nameBox1.Text + nameBox2.Text + nameBox3.Text + nameBox4.Text + nameBox5.Text + nameBox6.Text + nameBox7.Text + nameBox8.Text + nameBox9.Text + nameBox10.Text + nameBox11.Text + nameBox12.Text + nameBox13.Text + nameBox14.Text + nameBox15.Text + nameBox16.Text + nameBox17.Text + nameBox18.Text

        If testString = "INSERT DESCRIPTION" Then

            nameBox1.Text = ""
            nameBox2.Text = ""
            nameBox3.Text = ""
            nameBox4.Text = ""
            nameBox5.Text = ""
            nameBox6.Text = ""
            nameBox7.Text = ""
            nameBox8.Text = ""
            nameBox9.Text = ""
            nameBox10.Text = ""
            nameBox11.Text = ""
            nameBox12.Text = ""
            nameBox13.Text = ""
            nameBox14.Text = ""
            nameBox15.Text = ""
            nameBox16.Text = ""
            nameBox17.Text = ""
            nameBox18.Text = ""
            nameBox19.Text = ""
            nameBox20.Text = ""




        End If

    End Sub

    Private Sub UpdateNameInDB()

        
        DataSetForm.PRCtrainerDataGridView.Item(1, presetRowNum).Value = newName
        DataSetForm.UpdateDB()


        storedName = newName


    End Sub

    Private Sub CheckValidityOfNewName()

        newName = nameBox1.Text + nameBox2.Text + nameBox3.Text + nameBox4.Text + nameBox5.Text + nameBox6.Text + nameBox7.Text + nameBox8.Text + nameBox9.Text '+ nameBox10.Text + nameBox11.Text + nameBox12.Text + nameBox13.Text + nameBox14.Text + nameBox15.Text + nameBox16.Text + nameBox17.Text + nameBox18.Text

        'check for leading blanks
        If newName.StartsWith(" ") Then
            newName = storedName

            'reload into nameBoxes
            BreakMeUp(newName)
            ArrangeNameboxes()

            GetHighlightedNamebox()
            highlightedNameBox.BackColor = Color.MediumSeaGreen
            highlightedNameBox.ForeColor = Color.Black

            nextBox = nameBox2
            lastBox = nameBox1
            highlightedNameBox = nameBox1


            nextBox.BackColor = Color.MediumSeaGreen
            nextBox.ForeColor = Color.Black

            highlightedNameBox.BackColor = Color.Black
            highlightedNameBox.ForeColor = Color.MediumSeaGreen

        End If


    End Sub

    Private Sub PresetWaveform()


        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-SYS PRESETS-CFG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "PRESET WAVEFORM"

        b1TB.Visible = True
        SetWidth(b1TB)
        CenterMe(b1TB)

        c1TB.Text = "VULOS"
        newWave = c1TB.Text
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True


        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "preset waveform"
        HelperUpdate()


    End Sub

    Private Sub SetBackGreen(textBox As TextBox)
        textBox.BackColor = Color.MediumSeaGreen
        textBox.ForeColor = Color.Black
    End Sub

    Public Sub SetBackBlack(textBox As TextBox)
        textBox.BackColor = Color.Black
        textBox.ForeColor = Color.MediumSeaGreen
    End Sub

    Private Sub ProgrammingMenu()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-SYS PRESETS-CFG-" + storedNumber + newWave
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "GENERAL CONFIG"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "FREQUENCY"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "COMSEC"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        menuChoices = "programming menu"
        SelectMenu()
        MeasureArray()

        AutoScrollbar()
        JustificationAndSetWidth()

        ml3 = "programming menu"
        HelperUpdate()

    End Sub

    Private Sub ProgrammingMenuMoveDn()
        If d1TB.BackColor = Color.Black Then


            If d1TB.Text <> "EXIT" Then 'stops scrolling when it reaches the bottom
                b1TB.Text = c1TB.Text

                c1TB.Text = d1TB.Text
                scrollingDown = d1TB.Text
            End If



            Select Case scrollingDown

                Case "COMSEC"
                    d1TB.Text = "TRAFFIC"

                Case "TRAFFIC"
                    d1TB.Text = "TX POWER"

                Case "TX POWER"
                    d1TB.Text = "SQUELCH"

                Case "SQUELCH"
                    d1TB.Text = "EXIT"






            End Select
            SetWidth(b1TB)
            SetWidth(c1TB)
            SetWidth(d1TB)

            b1TB.TextAlign = HorizontalAlignment.Left
            c1TB.TextAlign = HorizontalAlignment.Left
            d1TB.TextAlign = HorizontalAlignment.Left

        Else
            ScrollDown()


        End If

    End Sub

    Private Sub ProgrammingMenuMoveUp()

        If b1TB.BackColor = Color.Black Then



            If d1TB.Text <> "COMSEC" Then 'stops scrolling when it reaches the TOP
                d1TB.Text = c1TB.Text

                c1TB.Text = b1TB.Text
                scrollingUp = b1TB.Text
            End If



            Select Case scrollingUp

                Case "TX POWER"
                    b1TB.Text = "TRAFFIC"

                Case "TRAFFIC"
                    b1TB.Text = "COMSEC"

                Case "COMSEC"
                    b1TB.Text = "FREQUENCY"

                Case "FREQUENCY"
                    b1TB.Text = "GENERAL CONFIG"




            End Select
            SetWidth(b1TB)
            SetWidth(c1TB)
            SetWidth(d1TB)

            b1TB.TextAlign = HorizontalAlignment.Left
            c1TB.TextAlign = HorizontalAlignment.Left
            d1TB.TextAlign = HorizontalAlignment.Left

        Else
            ScrollUp()

        End If
    End Sub

    Private Sub CheckValidityOfNewDesc()
        newDesc = nameBox1.Text + nameBox2.Text + nameBox3.Text + nameBox4.Text + nameBox5.Text + nameBox6.Text + nameBox7.Text + nameBox8.Text + nameBox9.Text + nameBox10.Text + nameBox11.Text + nameBox12.Text + nameBox13.Text + nameBox14.Text + nameBox15.Text '+ nameBox16.Text + nameBox17.Text + nameBox18.Text

        'check for leading blanks
        If newDesc.StartsWith(" ") Or newDesc.Contains("INSERT DESC") Then
            newDesc = storedDescription

            'reload into nameBoxes
            BreakMeUp(newDesc)
            ArrangeNameboxes()

            GetHighlightedNamebox()
            highlightedNameBox.BackColor = Color.MediumSeaGreen
            highlightedNameBox.ForeColor = Color.Black

            nextBox = nameBox2
            lastBox = nameBox1
            highlightedNameBox = nameBox1


            nextBox.BackColor = Color.MediumSeaGreen
            nextBox.ForeColor = Color.Black

            highlightedNameBox.BackColor = Color.Black
            highlightedNameBox.ForeColor = Color.MediumSeaGreen

        End If
    End Sub

    Private Sub UpdateDescInDB()

        DataSetForm.PRCtrainerDataGridView.Item(5, presetRowNum).Value = newDesc
        DataSetForm.UpdateDB()


        storedDescription = newDesc

    End Sub

    Private Sub GetHighlitedText()
        If b1TB.BackColor = Color.Black Then
            ml3 = b1TB.Text.ToLower
        ElseIf c1TB.BackColor = Color.Black Then
            ml3 = c1TB.Text.ToLower
        ElseIf d1TB.BackColor = Color.Black Then
            ml3 = d1TB.Text.ToLower
        End If
        HelperUpdate()

    End Sub

    Private Sub SelectCases()
        Select Case ml3
            Case "general config"
                GeneralConfig()
            Case "frequency"
                If storedType = "SATCOM" Then
                    SatcomChannelNumber()
                ElseIf storedType = "LOS" Then
                    VulosRxFreq()
                End If
            Case "comsec"
                CryptoModePage()
            Case "traffic"
                TrafficMode()
            Case "tx power"
                TransmitPower()
            Case "squelch"
                AnalogSquelchType()
            Case "exit"
                ml3 = " "
                ml2 = "system presets"
                SystemPresetsMenu()



        End Select
    End Sub

    Private Sub GeneralConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PRESET NAME"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True


        'split apart stored name into individual characters and place them in the nameboxes
        BreakMeUp(storedName)
        DescriptionEntry()
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y)
        ArrangeNameboxes()


        nameBox1.Visible = True



        d1TB.Text = "ENTER ALPHANUMERIC PRESET NAME"
        d1TB.Visible = True
        d1TB.Width = 250
        CenterMe(d1TB)


        
        
    End Sub

    Private Sub PresetType()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PRESET TYPE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If newWave = "VULOS" Then ''''if VULOS, switch between LOS and SATCOM


            c1TB.Text = storedType
            SetBackBlack(c1TB)
            SetWidth(c1TB)
            CenterMe(c1TB)
            c1TB.Visible = True


        End If

        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "preset type"
        HelperUpdate()


    End Sub

    Private Sub SatcomChannelNumber()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . YS PRESETS-CFG-" + storedNumber + newWave + "-FREQ"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CHANNEL NUMBER:  "
        SetWidth(b1TB)
        b1TB.TextAlign = HorizontalAlignment.Left
        b1TB.Visible = True

        DataSetForm.PRCtrainerDataGridView.Item(2, presetRowNum).Value = "SATCOM"
        DataSetForm.UpdateDB()

        If storedSatcomChannel = " " Then
            storedSatcomChannel = "001"
            DataSetForm.PRCtrainerDataGridView.Item(6, presetRowNum).Value = "250.3500"
            DataSetForm.PRCtrainerDataGridView.Item(7, presetRowNum).Value = ""
            DataSetForm.PRCtrainerDataGridView.Item(20, presetRowNum).Value = "001"
            DataSetForm.UpdateDB()
        Else
            storedSatcomChannel = storedSatcomChannel.Trim("-")

            If storedSatcomChannel.Length = 3 Then
            ElseIf storedSatcomChannel.Length = 2 Then
                storedSatcomChannel = "0" + storedSatcomChannel
            ElseIf storedChannel.Length = 1 Then
                storedSatcomChannel = "00" + storedSatcomChannel

            End If

        End If

        
            b2TB.Text = storedSatcomChannel




        SetWidth(b2TB)
        b2TB.Location = New Point(b1TB.Location.X + b1TB.Width, b2TB.Location.Y)

        'sets the color of the boxes and show them
        nameBox1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        nameBox1.TextAlign = HorizontalAlignment.Center
        nameBox1.ForeColor = Color.Black
        nameBox1.BorderStyle = BorderStyle.None
        nameBox1.BackColor = Color.MediumSeaGreen
        nameBox1.Text = GetChar(storedSatcomChannel, 1)
        SetWidth(nameBox1)
        nameBox1.Location = New Point(b2TB.Location)
        nameBox1.BringToFront()
        nameBox1.Visible = True

        Highlight(nameBox1)

        nameBox2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        nameBox2.TextAlign = HorizontalAlignment.Center
        nameBox2.ForeColor = Color.Black
        nameBox2.BorderStyle = BorderStyle.None
        nameBox2.BackColor = Color.MediumSeaGreen
        nameBox2.Text = GetChar(storedSatcomChannel, 2)
        SetWidth(nameBox2)
        nameBox2.Location = New Point(nameBox1.Location.X + nameBox1.Width, b2TB.Location.Y)
        nameBox2.BringToFront()
        nameBox2.Visible = True


        nameBox3.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        nameBox3.TextAlign = HorizontalAlignment.Center
        nameBox3.ForeColor = Color.Black
        nameBox3.BorderStyle = BorderStyle.None
        nameBox3.BackColor = Color.MediumSeaGreen
        nameBox3.Text = GetChar(storedSatcomChannel, 3)
        SetWidth(nameBox3)
        nameBox3.Location = New Point(nameBox2.Location.X + nameBox2.Width, b2TB.Location.Y)
        nameBox3.BringToFront()
        nameBox3.Visible = True



        storedSatcomChannel = CInt(storedSatcomChannel) '- 1

        GetSatcomStoredInfo() ''''retrieves the stored frequencies based on the SATCOM table

        CheckForNullFreq()

        If storedSatcomChannel = "999" Or storedSatcomChannel = "249" Or storedSatcomChannel = "248" Then
            c1TB.Text = "USER"
            c3TB.Text = "USER"
        Else
            c1TB.Text = newRXfreq
            c3TB.Text = newTXfreq
        End If

        SetWidth(c1TB)
        c1TB.Location = New Point(446 - (c1TB.Width / 2), c1TB.Location.Y) '(c1TB.Location.X + 20, c1TB.Location.Y)

        SetWidth(c3TB)
        c3TB.Location = New Point(570 - (c3TB.Width / 2), c3TB.Location.Y) '(c1TB.Location.X + c1TB.Width + 34, c3TB.Location.Y)
        c1TB.Visible = True
        c3TB.Visible = True



        d1TB.Text = "RX FREQ                  TX FREQ"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True


        ml3 = "satcom ch num"
        HelperUpdate()
    End Sub

    Private Sub VulosRxFreq()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . YS PRESETS-CFG-" + storedNumber + newWave + "-FREQ"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "RX FREQUENCY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True


        BreakApartFrequency(storedRXfreq)


        freqRange = "30.0000 TO 511.9950"
        d1TB.Text = "ENTER " + freqRange
        d1TB.Visible = True
        d1TB.Width = 250
        CenterMe(d1TB)

        ml3 = "vulos rx freq"
        HelperUpdate()

    End Sub

    Private Sub GetSatcomStoredInfo()

        mySatcomInt = CInt(storedSatcomChannel) - 1

        If mySatcomInt = 998 Then
            mySatcomInt = 249
        End If

        newRXfreq = SatcomPresets.SATCOMpresetsDataGridView.Item(2, mySatcomInt).Value

        If IsDBNull(SatcomPresets.SATCOMpresetsDataGridView.Item(1, mySatcomInt).Value) = True Then
            newTXfreq = "RX ONLY"
        Else
            newTXfreq = SatcomPresets.SATCOMpresetsDataGridView.Item(1, mySatcomInt).Value
        End If
        

    End Sub

    Private Sub satcomChannelUpdate() 'used to update the channel number for SATCOM presets
        If nameBox1.BackColor = Color.Black Then
            nameBox1.Text = thisNum
            wasNumBx1Changed = True
        ElseIf nameBox2.BackColor = Color.Black Then
            nameBox2.Text = thisNum
            wasNumBx2Changed = True
        ElseIf nameBox3.BackColor = Color.Black Then
            nameBox3.Text = thisNum
            wasNumBx3Changed = True

            If ml3 = "satcom ch num" Then
                If wasNumBx1Changed = True And wasNumBx2Changed = True And wasNumBx3Changed = True Then

                    newSatcomChannel = CInt(nameBox1.Text + nameBox2.Text + nameBox3.Text) '- 1
                    storedSatcomChannel = newSatcomChannel.ToString

                    If storedSatcomChannel = "999" Then
                        mySatcomInt = "250"
                    End If

                    GetSatcomStoredInfo()

                    If storedSatcomChannel = "999" Or storedSatcomChannel = "249" Or storedSatcomChannel = "248" Then
                        c1TB.Text = "USER"
                        c3TB.Text = "USER"
                    Else
                        c1TB.Text = newRXfreq
                        c3TB.Text = newTXfreq
                    End If

                    

                    SetWidth(c1TB)
                    c1TB.Location = New Point(446 - (c1TB.Width / 2), c1TB.Location.Y) '(c1TB.Location.X + 20, c1TB.Location.Y)

                    SetWidth(c3TB)
                    c3TB.Location = New Point(570 - (c3TB.Width / 2), c3TB.Location.Y) '(c1TB.Location.X + c1TB.Width + 34, c3TB.Location.Y)
                    c1TB.Visible = True
                    c3TB.Visible = True

                    DataSetForm.PRCtrainerDataGridView.Item(6, presetRowNum).Value = newRXfreq
                    DataSetForm.PRCtrainerDataGridView.Item(7, presetRowNum).Value = newTXfreq
                    DataSetForm.PRCtrainerDataGridView.Item(20, presetRowNum).Value = storedSatcomChannel
                    DataSetForm.UpdateDB()


                    wasNumBx1Changed = False
                    wasNumBx2Changed = False
                    wasNumBx3Changed = False
                    Exit Sub

                Else
                    'restore previous channel
                    SatcomChannelNumber()


                End If
            End If


        End If

    End Sub

    Private Sub PresetNameDBupdate()
        storedName = nameBox1.Text + nameBox2.Text + nameBox3.Text + nameBox4.Text + nameBox5.Text + nameBox6.Text + nameBox7.Text + nameBox8.Text + nameBox9.Text + nameBox10.Text + nameBox11.Text + nameBox12.Text + nameBox13.Text + nameBox14.Text + nameBox15.Text '+ nameBox16.Text + nameBox17.Text + nameBox18.Text
        DataSetForm.PRCtrainerDataGridView.Item(1, presetRowNum).Value = storedName
        DataSetForm.UpdateDB()

    End Sub

    Private Sub SetNumberFromKeypad(thisNum As String)
        GetHighlightedNamebox()
        highlightedNameBox.Text = thisNum
        MyCreateMyNameboxes()
    End Sub

    Private Sub BreakApartFrequency(i As String)
        'split apart stored name into individual characters and place them in the nameboxes

        If i.Contains(".") Then
        Else
            i += "."
        End If

        Do Until (i.IndexOf(".") = 3)
            i = "0" + i
        Loop

        Do Until (i.Length < 8 = False)
            i += "0"
        Loop


        nameBox1.Text = GetChar(i, 1)
        nameBox2.Text = GetChar(i, 2)
        nameBox3.Text = GetChar(i, 3)
        nameBox4.Text = "."
        nameBox5.Text = GetChar(i, 5)
        nameBox6.Text = GetChar(i, 6)
        nameBox7.Text = GetChar(i, 7)
        nameBox8.Text = GetChar(i, 8)

        DescriptionEntry()
        c1TB.Location = New Point(b1TB.Location.X + 20, c1TB.Location.Y)
        ArrangeNameboxes()


        nameBox1.Visible = True
    End Sub

    Private Sub PresetRxFreqDBupdate()
        storedRXfreq = testFreq
        DataSetForm.PRCtrainerDataGridView.Item(6, presetRowNum).Value = storedRXfreq
        DataSetForm.UpdateDB()
    End Sub

    Private Sub RxOnly()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . YS PRESETS-CFG-" + storedNumber + newWave + "-FREQ"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "RX ONLY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "NO"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "vulos rx only"
        HelperUpdate()
    End Sub

    Private Sub CryptoModePage()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . YS PRESETS-CFG-" + storedNumber + newWave + "-COMSEC"
        a1TB.Width = 250
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CRYPTO MODE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedCryptoMode = "" Or storedCryptoMode = " " Then
            c1TB.Text = "ANDVT"
        Else
            c1TB.Text = storedCryptoMode
        End If


        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "crypto mode"
        HelperUpdate()
    End Sub

    Private Sub SelectTXfrequencySource()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . YS PRESETS-CFG-" + storedNumber + newWave + "-FREQ"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "TX FREQUENCY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "USE RX FREQ"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "tx freq source"
        HelperUpdate()
    End Sub 'A-27

    Private Sub EnterTxFreq()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . YS PRESETS-CFG-" + storedNumber + newWave + "-FREQ"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "TX FREQUENCY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True


        If transmitChoice = "EDIT TX FREQ" Then
            BreakApartFrequency(storedTXfreq)
        ElseIf transmitChoice = "USE RX FREQ" Then
            BreakApartFrequency(storedRXfreq)
            SetBackGreen(nameBox1)
        End If


        If transmitChoice = "EDIT TX FREQ" Then
            freqRange = "30.0000 TO 511.9999"
            d1TB.Text = "ENTER " + freqRange
        ElseIf transmitChoice = "USE RX FREQ" Then
            d1TB.Text = "PRESS ENT TO CONTINUE"
        End If
        


        d1TB.Visible = True
        SetWidth(d1TB)
        CenterMe(d1TB)

        ml3 = "enter tx freq"
        HelperUpdate()
    End Sub 'A-27

    Private Sub EncryptionKey()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . YS PRESETS-CFG-" + storedNumber + newWave + "-COMSEC"
        a1TB.Width = 250
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CRYPTO KEY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "TEK01"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "encryption key"
        HelperUpdate()
    End Sub 'A-27

    Private Sub SaveTxFreq()
        Try
            testFreq = CDbl(nameBox1.Text + nameBox2.Text + nameBox3.Text + nameBox4.Text + nameBox5.Text + nameBox6.Text + nameBox7.Text + nameBox8.Text)

        Catch ex As Exception

        End Try
        storedTXfreq = testFreq
        DataSetForm.PRCtrainerDataGridView.Item(7, presetRowNum).Value = storedTXfreq
        DataSetForm.UpdateDB()
    End Sub

    Private Sub SaveCryptoMode()
        storedCryptoMode = c1TB.Text
        DataSetForm.PRCtrainerDataGridView.Item(18, presetRowNum).Value = storedCryptoMode
        DataSetForm.UpdateDB()
    End Sub

    Private Sub SaveCryptoKey()
        storedCryptoKey = c1TB.Text
        DataSetForm.PRCtrainerDataGridView.Item(19, presetRowNum).Value = storedCryptoKey
        DataSetForm.UpdateDB()
    End Sub

    Private Sub TekConversion()

        tekNum = GetChar(c1TB.Text, 4)
        tekNum += GetChar(c1TB.Text, 5)
        convertedTekNum = CInt(tekNum)

        If thisNum = 6 Then
            convertedTekNum += 1
            If convertedTekNum = 26 Then
                convertedTekNum = 1
            End If
        ElseIf thisNum = 9 Then
            convertedTekNum -= 1
            If convertedTekNum = 0 Then
                convertedTekNum = 25
            End If
        End If

        tekString = convertedTekNum.ToString
        If tekString.Length = 1 Then
            tekString = "0" + tekString
        End If
        c1TB.Text = "TEK" + tekString

    End Sub

    Private Sub CheckForSubmodeAfterEncryptionKey()

        If DataSetForm.PRCtrainerDataGridView.Item(18, presetRowNum).Value = "VINSON" Or DataSetForm.PRCtrainerDataGridView.Item(18, presetRowNum).Value = "NONE" Then
            TrafficMode()
            Exit Sub
        End If

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . YS PRESETS-CFG-" + storedNumber + newWave + "-COMSEC"
        a1TB.Width = 250
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        'check the condition of the submode
        Select Case DataSetForm.PRCtrainerDataGridView.Item(18, presetRowNum).Value
            Case "FASCINATOR"
                b1TB.Text = "FASCINATOR MODE"
                c1TB.Text = "STANDARD"
            Case "AES"
                b1TB.Text = "AES MODE"
                c1TB.Text = "CTR1 (MIN ERR PROP)"
            Case "KG84"
                b1TB.Text = "KG84 SYNC MODE"
                c1TB.Text = "REDUNDANT (MODE1)"
            Case "ANDVT"
                b1TB.Text = "TRAINING FRAMES"
                c1TB.Text = "6"

        End Select


        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True


        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "check submode"
        HelperUpdate()
    End Sub

    Private Sub TrafficMode()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-TRAFFIC"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "TRAFFIC MODE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        DetermineTrafficModeSelection()

        If storedCryptoMode = "FASCINATOR" Then
            storedTraffic = "VOICE"
        ElseIf storedCryptoMode = "KG84" Or storedCryptoMode = "ANDVT" Then
            storedTraffic = "DATA"
        End If
        c1TB.Text = storedTraffic
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "traffic mode"
        HelperUpdate()
    End Sub

    Private Sub RxFadePriority()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-COMSEC"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "ANDVT RX FADE PRI"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "ENABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "rx fade priority"
        HelperUpdate()
    End Sub

    Private Sub VoiceAutoswitch()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-COMSEC"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "VOICE AUTOSWITCH"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "ENABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "voice autoswitch"
        HelperUpdate()
    End Sub

    Private Sub CheckFreqFormat(ByRef i As String)
        If i.Contains(".") Then
        Else
            i += "."
        End If

        Do Until (i.IndexOf(".") = 3)
            i = "0" + i
        Loop

        Do Until (i.Length < 8 = False)
            i += "0"
        Loop


    End Sub

    Private Sub CheckForNullFreq()

        If storedSatcomChannel = "999" Then
            MySatcomChannel = "249"
        Else
            MySatcomChannel = storedSatcomChannel
        End If

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(6, presetRowNum).Value) = True Then
            storedRXfreq = SatcomPresets.SATCOMpresetsDataGridView.Item(2, CInt(MySatcomChannel)).Value
        End If

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(7, presetRowNum).Value) = True Then
            storedTXfreq = SatcomPresets.SATCOMpresetsDataGridView.Item(1, CInt(MySatcomChannel)).Value
        End If



    End Sub

    

    Private Sub RecallOptions()

        If storedBW = "25K" Then

            If IsDBNull(OptionsCodes.OptionCodes25kHzDataGridView.Item(0, presetRowNum).Value) = True Then
                storedOption = " "
            Else
                storedOption = OptionsCodes.OptionCodes25kHzDataGridView.Item(0, presetRowNum).Value
            End If

            If IsDBNull(OptionsCodes.OptionCodes25kHzDataGridView.Item(1, presetRowNum).Value) = True Then
                storedBPS = " "
            Else
                storedBPS = OptionsCodes.OptionCodes25kHzDataGridView.Item(1, presetRowNum).Value
            End If

            If IsDBNull(OptionsCodes.OptionCodes25kHzDataGridView.Item(2, presetRowNum).Value) = True Then
                storedMod = " "
            Else
                storedMod = OptionsCodes.OptionCodes25kHzDataGridView.Item(2, presetRowNum).Value
            End If

            If IsDBNull(OptionsCodes.OptionCodes25kHzDataGridView.Item(6, presetRowNum).Value) = True Then
                storedMod = " "
            Else
                storedFWDerror = OptionsCodes.OptionCodes25kHzDataGridView.Item(6, presetRowNum).Value
            End If

            'need something to determine crypto mode


        ElseIf storedBW = "5K" Then

            If IsDBNull(OptionsCodes.OptionCodes5kHzDataGridView.Item(0, presetRowNum).Value) = True Then
                storedOption = " "
            Else
                storedOption = OptionsCodes.OptionCodes5kHzDataGridView.Item(0, presetRowNum).Value
            End If

            If IsDBNull(OptionsCodes.OptionCodes5kHzDataGridView.Item(1, presetRowNum).Value) = True Then
                storedBPS = " "
            Else
                storedBPS = OptionsCodes.OptionCodes5kHzDataGridView.Item(1, presetRowNum).Value
            End If

            If IsDBNull(OptionsCodes.OptionCodes5kHzDataGridView.Item(2, presetRowNum).Value) = True Then
                storedMod = " "
            Else
                storedMod = OptionsCodes.OptionCodes5kHzDataGridView.Item(2, presetRowNum).Value
            End If

            If IsDBNull(OptionsCodes.OptionCodes5kHzDataGridView.Item(6, presetRowNum).Value) = True Then
                storedMod = " "
            Else
                storedFWDerror = OptionsCodes.OptionCodes5kHzDataGridView.Item(6, presetRowNum).Value
            End If

            'need something to determine crypto mode
        End If


    End Sub

    Private Sub DetermineTrafficModeSelection()

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(3, presetRowNum).Value) = True Then
            storedTraffic = " "
        Else
            storedTraffic = DataSetForm.PRCtrainerDataGridView.Item(3, presetRowNum).Value
        End If


        If storedTraffic = " " Then

            Select Case storedCryptoMode
                Case "KG84"
                    storedTraffic = "DATA"
                Case "NONE"
                    storedTraffic = "VOICE"
                Case "VINSON"
                    storedTraffic = "VOICE AND DATA"
                Case "ANDVT"
                    storedTraffic = "DATA"
                Case "FASCINATOR"
                    storedTraffic = "VOICE"
                Case "AES"
                    storedTraffic = "VOICE"
            End Select

        End If

    End Sub


    Private Sub DataModeSelect()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-TRAFFIC"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "DATA MODE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(21, presetRowNum).Value) = True Then
            storedDataMode = " "
        Else
            storedDataMode = DataSetForm.PRCtrainerDataGridView.Item(21, presetRowNum).Value 'GET VALUE FORM DATAGRID
        End If
        
        If storedDataMode = " " Then
            storedDataMode = "SYNCRONOUS"
        End If
        c1TB.Text = storedDataMode

        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "data mode select"
        HelperUpdate()


    End Sub

    Private Sub VoiceSelect()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-TRAFFIC"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "VOICE MODE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        DetermineVoiceModeSelection()

        c1TB.Text = storedVoiceMode
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "voice mode select"
        HelperUpdate()
    End Sub

    Private Sub VoiceSelections()
        If storedTraffic = "VOICE AND DATA" Then

            VoiceSelect()

        ElseIf storedTraffic = "VOICE" Then
            VoiceSelect()
        End If
    End Sub

    Private Sub DataSelections()
        If storedTraffic = "VOICE AND DATA" Then
            DataModeSelect()

        ElseIf storedTraffic = "DATA" Then
            DataModeSelect()

        End If
    End Sub

    Private Sub DetermineVoiceModeSelection()

        Select Case storedTraffic
            Case "VOICE"
                storedVoiceMode = "CLEAR"
            Case "VOICE AND DATA"
                If storedCryptoMode = "VINSON" Then
                    storedVoiceMode = "CVSD"
                ElseIf storedCryptoMode = "ANDVT" Then
                    storedVoiceMode = "LPC 2400"
                End If

        End Select

    End Sub

    Private Sub Keysource()

        If storedDataMode = "ASYNCRONOUS" Then

            DisplayReset()
            SetVisibilityOFF()
            showRowA()
            a1TB.Visible = True
            a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-TRAFFIC"
            SetWidth(a1TB)
            a1TB.TextAlign = HorizontalAlignment.Left
            a2TB.Visible = False
            a3PB.Visible = False
            a4TB.Visible = False
            a5TB.Visible = False
            a6TB.Visible = False
            a7TB.Visible = False

            b1TB.Text = "KEY SOURCE"
            SetWidth(b1TB)
            CenterMe(b1TB)
            b1TB.Visible = True

            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(28, presetRowNum).Value) = True Then
                storedKeySource = " "
            Else
                storedKeySource = DataSetForm.PRCtrainerDataGridView.Item(28, presetRowNum).Value
            End If


            If storedKeySource = " " Then
                c1TB.Text = "RTS"
            End If
            c1TB.Text = storedKeySource

            SetWidth(c1TB)
            CenterMe(c1TB)
            SetBackBlack(c1TB)
            c1TB.Visible = True



            ShowToScrollEntToCont()
            d1TB.Visible = True

            ml3 = "key source"

        Else

            VoiceSelections()

        End If


        HelperUpdate()

    End Sub

    Private Sub LPCcodebook()

        If storedCryptoMode = "ANDVT" And storedTraffic = "VOICE AND DATA" Then


            DisplayReset()
            SetVisibilityOFF()
            showRowA()
            a1TB.Visible = True
            a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-TRAFFIC"
            SetWidth(a1TB)
            a1TB.TextAlign = HorizontalAlignment.Left
            a2TB.Visible = False
            a3PB.Visible = False
            a4TB.Visible = False
            a5TB.Visible = False
            a6TB.Visible = False
            a7TB.Visible = False

            b1TB.Text = "LPC CODEBOOK"
            SetWidth(b1TB)
            CenterMe(b1TB)
            b1TB.Visible = True


            c1TB.Text = "ENGLISH"
            SetWidth(c1TB)
            CenterMe(c1TB)
            SetBackBlack(c1TB)
            c1TB.Visible = True



            ShowToScrollEntToCont()
            d1TB.Visible = True

            ml3 = "lpc codebook"
            HelperUpdate()
        Else
            ModulationType()
        End If

        


    End Sub

    Private Sub ModulationType()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-TRAFFIC"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "MODULATION TYPE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(4, presetRowNum).Value) = True Then
            storedMod = " "
        Else
            storedMod = DataSetForm.PRCtrainerDataGridView.Item(4, presetRowNum).Value
        End If


        If storedMod = " " Then
            storedMod = "AM"
        ElseIf storedCryptoMode = "FASCINATOR" Then
            storedMod = "FSK"
        ElseIf storedCryptoMode = "AES" Or storedCryptoMode = "NONE" Then
            If storedMod = " " Or storedMod = "FSK" Or storedMod = "MS181" Then
                storedMod = "FM"
            End If

        End If
            c1TB.Text = storedMod

            SetWidth(c1TB)
            CenterMe(c1TB)
            SetBackBlack(c1TB)
            c1TB.Visible = True



            ShowToScrollEntToCont()
            d1TB.Visible = True

            ml3 = "modulation type"
            HelperUpdate()

    End Sub

    Private Sub FMdeviation()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-TRAFFIC"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "FM DEVIATION"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(30, presetRowNum).Value) = True Then
            storedDeviation = " "
        Else
            storedDeviation = DataSetForm.PRCtrainerDataGridView.Item(30, presetRowNum).Value
        End If


        If storedDeviation = " " Then
            storedDeviation = "6.5 kHz"
        End If
        c1TB.Text = storedDeviation

        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "fm deviation"
        HelperUpdate()
    End Sub

    Private Sub OptionCode()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-TRAFFIC"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "  OPTION CODE:"
        SetWidth(b1TB)
        b1TB.Visible = True

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(11, presetRowNum).Value) = True Then
            storedOption = " "
        Else
            storedOption = DataSetForm.PRCtrainerDataGridView.Item(11, presetRowNum).Value
        End If


        CheckOptions(storedCryptoMode, storedOption) 'finds the starting point for the option number based on the crypto being used


        b2TB.Text = storedOption
        SetWidth(b2TB)
        b2TB.Location = New Point(b1TB.Location.X + b1TB.Width + 50, b1TB.Location.Y)
        b2TB.Visible = True
        b7PB.BackgroundImage = My.Resources.UpDown
        b7PB.Width = 10
        b7PB.Height = 14
        b7PB.Location = New Point(b2TB.Location.X + b2TB.Width + 5, b2TB.Location.Y + 3)
        b7PB.Visible = True


        GetOptionsData(storedOption, storedBW, storedOptMod, storedBPS, storedFWDerror)

        d1TB.Text = "BW"
        d1TB.Visible = True
        d3TB.Text = "MOD TYPE"
        SetWidth(d3TB)
        d3TB.Visible = True
        d6TB.Text = "RATE"
        d6TB.Location = New Point(((d3TB.Location.X + d3TB.Width + d7TB.Location.X) / 2) - (d6TB.Width / 2), d6TB.Location.Y)
        d6TB.Visible = True
        d7TB.Text = "FEC"
        d7TB.Visible = True

        c1TB.Text = storedBW
        SetWidth(c1TB)
        c1TB.Location = New Point((d1TB.Location.X + (d1TB.Width / 2)) - (c1TB.Width / 2), c1TB.Location.Y)
        c1TB.Visible = True
        c3TB.Text = storedOptMod
        SetWidth(c3TB)
        c3TB.Location = New Point((d3TB.Location.X + (d3TB.Width) / 2) - (c3TB.Width / 2), c1TB.Location.Y)
        c3TB.Visible = True
        c4TB.Text = storedBPS
        SetWidth(c4TB)
        c4TB.Location = New Point((d6TB.Location.X + (d6TB.Width / 2)) - (c4TB.Width / 2), c1TB.Location.Y)
        c4TB.Visible = True
        c7TB.Text = storedFWDerror
        SetWidth(c7TB)
        c7TB.Location = New Point((d7TB.Location.X + (d7TB.Width / 2)) - (c7TB.Width / 2), c1TB.Location.Y)
        c7TB.Visible = True

        ml3 = "option code"
        HelperUpdate()




    End Sub

    Private Sub Interleaver()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-TRAFFIC"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "INTERLEAVER"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(15, presetRowNum).Value) = True Then
            storedInterleave = " "
        Else
            storedInterleave = DataSetForm.PRCtrainerDataGridView.Item(15, presetRowNum).Value
        End If


        If storedInterleave = " " Then
            storedInterleave = "- -"
        End If
        c1TB.Text = storedInterleave

        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "interleaver"
        HelperUpdate()
    End Sub


    Private Sub TransmitPower()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-POWER"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "TX POWER LEVEL"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True


        If storedTXpower = " " Then
            c1TB.Text = "HIGH"
        Else
            c1TB.Text = storedTXpower
        End If

        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "power level"
        HelperUpdate()
    End Sub

    Private Sub UserPowerLevel()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " . . PRESETS-CFG-" + storedNumber + newWave + "-POWER"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "USER TX POWER LEVEL"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True


        If storedTXpowerDown = " " Then
            If myDBdown = "" Then
                myDBdown = "00"
            End If
            c1TB.Text = myDBdown + " DB DOWN"
        Else
            c1TB.Text = storedTXpowerDown
        End If

        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True


        ml3 = "user power level"
        HelperUpdate()
    End Sub

    Public Sub AnalogSquelchType()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "SQUELCH TYPE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedType = "SATCOM" Then
            storedSquelch = "DISABLED"
            c1TB.Text = storedSquelch
        Else
            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value) = False Then
                c1TB.Text = DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value

            ElseIf IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value) = True Then
                Select Case storedMod
                    Case "AM"
                        c1TB.Text = "OFF"
                    Case "FM"
                        c1TB.Text = "OFF"
                    Case "MS181"
                        c1TB.Text = "NOISE"

                End Select

            End If

            Select Case storedMod
                Case "AM"
                    Select Case c1TB.Text
                        Case "OFF"
                        Case "TONE"
                            c1TB.Text = "OFF"
                        Case "NOISE"
                        Case "CTCSS"
                            c1TB.Text = "OFF"
                        Case "CDCSS"
                            c1TB.Text = "OFF"
                    End Select

                Case "FM"
                    Select Case c1TB.Text
                        Case "OFF"
                        Case "TONE"
                        Case "NOISE"
                        Case "CTCSS"
                        Case "CDCSS"
                    End Select

                Case "MS181"
                    Select Case c1TB.Text
                        Case "OFF"
                            c1TB.Text = "TONE"
                        Case "TONE"
                        Case "NOISE"
                        Case "CTCSS"
                        Case "CDCSS"
                    End Select

            End Select


            End If


            SetWidth(c1TB)
            CenterMe(c1TB)
            If c1TB.Text <> "DISABLED" Then
                SetBackBlack(c1TB)
                ShowToScrollEntToCont()
            Else
                d1TB.Text = "PRESS ENT TO CONTINUE"
                SetWidth(d1TB)
                CenterMe(d1TB)
            End If

            c1TB.Visible = True

            d1TB.Visible = True


            ml3 = "analog squelch type"
            HelperUpdate()

    End Sub

    Private Sub SquelchLevel()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "ANALOG SQUELCH LEVEL"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        Me.Controls.Add(tbBorder1)
        tbBorder1.BorderStyle = BorderStyle.None
        tbBorder1.AutoSize = False
        tbBorder1.Location = New Point(507 - (52), 180)
        tbBorder1.BackColor = Color.Black
        tbBorder1.Height = 13
        tbBorder1.Width = 104
        tbBorder1.Visible = True
        tbBorder1.BringToFront()

        Me.Controls.Add(tbBack)
        tbBack.AutoSize = False
        tbBack.BorderStyle = BorderStyle.None
        tbBack.BringToFront()
        tbBack.Width = 100
        tbBack.Height = 9
        tbBack.Location = New Point(507 - (50), 182)
        tbBack.BackColor = Color.MediumSeaGreen
        tbBack.Visible = True

        Me.Controls.Add(tbFront)
        tbFront.Visible = False
        tbFront.AutoSize = False
        tbFront.BorderStyle = BorderStyle.None
        tbFront.Width = manualSquelchSetting
        tbFront.Height = 9
        tbFront.Location = New Point(507 - (50), 182)
        tbFront.BackColor = Color.Black
        tbFront.Visible = True
        tbFront.BringToFront()

        ShowToScrollLeftRight()



        ml3 = "squelch level"
        HelperUpdate()

    End Sub

    Private Sub CTCSStxTone()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CTCSS TX TONE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(35, presetRowNum).Value) = True Then
            storedCTCSStemp = " "
        Else
            storedCTCSStemp = DataSetForm.PRCtrainerDataGridView.Item(35, presetRowNum).Value 'same as above to assign the data for the stored recall key
        End If

        If storedCTCSStemp = " " Then
            storedCTCSS = 1
        Else
            storedCTCSS = CInt(storedCTCSStemp)
        End If


        If storedCTCSS = 0 Then
            storedCTCSS = 1
        End If
        
        CTCSSsquelchLoad(storedCTCSS - 1, storedCTCSSfreq, storedCTCSSeia, storedCTCSSham)

        If storedCTCSS <> 43 Then
            c1TB.Text = " " + storedCTCSSfreq
        Else
            c1TB.Text = " USER"
        End If

        c1TB.TextAlign = HorizontalAlignment.Left
        c1TB.Location = New Point(c1TB.Location.X + 51, c1TB.Location.Y)
        c1TB.Width = 75
        c3TB.Text = storedCTCSSeia
        c3TB.TextAlign = HorizontalAlignment.Left
        c3TB.Location = New Point(c3TB.Location.X + 77, c1TB.Location.Y)
        c3TB.Width = 60
        c4TB.Text = storedCTCSSham
        c4TB.Location = New Point(c4TB.Location.X + 55, c1TB.Location.Y)
        SetBackBlack(c1TB)
        SetBackBlack(c3TB)
        SetBackBlack(c4TB)
        c1TB.Visible = True
        c3TB.Visible = True
        c4TB.Visible = True

        b7PB.BackgroundImage = My.Resources.UpDown
        b7PB.Location = New Point(c4TB.Location.X + c4TB.Width + 2, c4TB.Location.Y + 2)
        b7PB.Size = New Size(10, 15)
        b7PB.Visible = True
        b7PB.BringToFront()
        

        
        d3TB.Text = "FREQ"
        SetWidth(d3TB)
        d3TB.Location = New Point(d3TB.Location.X + 6, d3TB.Location.Y)
        d3TB.Visible = True
        d6TB.Text = "EIA"
        d6TB.Location = New Point((((d3TB.Location.X + d3TB.Width + d7TB.Location.X) / 2) - (d6TB.Width / 2)) - 16, d6TB.Location.Y)
        d6TB.Visible = True
        d7TB.Text = "HAM"
        d7TB.Location = New Point(d7TB.Location.X - 45, d7TB.Location.Y)
        d7TB.Visible = True

        

        ml3 = "ctcss tx tone"
        HelperUpdate()
    End Sub

    Private Sub RecallMainProgramPage()
        If knobIndex = 1 Or knobIndex = 2 Then
            vulosDisplayed = False
            ml1 = "program"
            ml2 = ""
            ml3 = ""
            ProgramMain()
            HelperUpdate()

        End If
    End Sub

    Private Sub CTCSSuserEntry()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CTCSS TX USER ENTRY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        nameBox1.Location = New Point(474, nameBox1.Location.Y)
        nameBox2.Location = New Point(nameBox1.Location.X + 12, nameBox1.Location.Y)
        nameBox3.Location = New Point(nameBox2.Location.X + 12, nameBox1.Location.Y)
        nameBox4.Location = New Point(nameBox3.Location.X + 12, nameBox1.Location.Y)
        nameBox5.Location = New Point(nameBox4.Location.X + 12, nameBox1.Location.Y)

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(37, presetRowNum).Value) = True Then
            nameBox1.Text = "0"
            nameBox2.Text = "6"
            nameBox3.Text = "7"
            nameBox4.Text = "."
            nameBox5.Text = "0"
        Else
            storedCTCSSuserEntry = DataSetForm.PRCtrainerDataGridView.Item(37, presetRowNum).Value
            Dim i As String = storedCTCSSuserEntry
            nameBox1.Text = i.Chars(0)
            nameBox2.Text = i.Chars(1)
            nameBox3.Text = i.Chars(2)
            nameBox4.Text = i.Chars(3)
            nameBox5.Text = i.Chars(4)
        End If
        
        SetWidth(nameBox1)
        SetWidth(nameBox2)
        SetWidth(nameBox3)
        SetWidth(nameBox4)
        SetWidth(nameBox5)
        SetBackBlack(nameBox1)

        nameBox1.Visible = True
        nameBox2.Visible = True
        nameBox3.Visible = True
        nameBox4.Visible = True
        nameBox5.Visible = True



        d1TB.Text = "ENTER VALUE BETWEEN 67.0-254.1"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True


        ml3 = "ctcss user entry"
        HelperUpdate()

    End Sub

    Private Sub RXsquelchType()

        If storedSquelch = "CTCSS" Or storedSquelch = "CDCSS" Then
            DisplayReset()
            SetVisibilityOFF()
            showRowA()
            a1TB.Visible = True
            a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
            SetWidth(a1TB)
            a1TB.TextAlign = HorizontalAlignment.Left
            a2TB.Visible = False
            a3PB.Visible = False
            a4TB.Visible = False
            a5TB.Visible = False
            a6TB.Visible = False
            a7TB.Visible = False

            b1TB.Text = "RX SQUELCH TYPE"
            SetWidth(b1TB)
            CenterMe(b1TB)
            b1TB.Visible = True


            If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value) = False Then
                c1TB.Text = DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value
            
            End If




            SetWidth(c1TB)
            SetBackBlack(c1TB)
            CenterMe(c1TB)
            
            ShowToScrollEntToCont()



            c1TB.Visible = True

            d1TB.Visible = True


            ml3 = "rx squelch type"
            HelperUpdate()
        End If

    End Sub

    Private Sub CTCSSrxTone()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CTCSS RX TONE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True


        If storedCTCSSrx = 0 Then
            storedCTCSSrx = 1
        End If

        CTCSSsquelchLoad(storedCTCSSrx - 1, storedCTCSSrxFreq, storedCTCSSrxEIA, storedCTCSSrxHAM)

        If storedCTCSSrx <> 43 Then
            c1TB.Text = " " + storedCTCSSrxFreq
        Else
            c1TB.Text = " USER"
        End If

        c1TB.TextAlign = HorizontalAlignment.Left
        c1TB.Location = New Point(c1TB.Location.X + 51, c1TB.Location.Y)
        c1TB.Width = 75
        c3TB.Text = storedCTCSSrxEIA
        c3TB.TextAlign = HorizontalAlignment.Left
        c3TB.Location = New Point(c3TB.Location.X + 77, c1TB.Location.Y)
        c3TB.Width = 60
        c4TB.Text = storedCTCSSrxHAM
        c4TB.Location = New Point(c4TB.Location.X + 55, c1TB.Location.Y)
        SetBackBlack(c1TB)
        SetBackBlack(c3TB)
        SetBackBlack(c4TB)
        c1TB.Visible = True
        c3TB.Visible = True
        c4TB.Visible = True

        b7PB.BackgroundImage = My.Resources.UpDown
        b7PB.Location = New Point(c4TB.Location.X + c4TB.Width + 2, c4TB.Location.Y + 2)
        b7PB.Size = New Size(10, 15)
        b7PB.Visible = True
        b7PB.BringToFront()



        d3TB.Text = "FREQ"
        SetWidth(d3TB)
        d3TB.Location = New Point(d3TB.Location.X + 6, d3TB.Location.Y)
        d3TB.Visible = True
        d6TB.Text = "EIA"
        d6TB.Location = New Point((((d3TB.Location.X + d3TB.Width + d7TB.Location.X) / 2) - (d6TB.Width / 2)) - 16, d6TB.Location.Y)
        d6TB.Visible = True
        d7TB.Text = "HAM"
        d7TB.Location = New Point(d7TB.Location.X - 45, d7TB.Location.Y)
        d7TB.Visible = True



        ml3 = "ctcss rx tone"
        HelperUpdate()
    End Sub

    Private Sub CTCSSrxUserEntry()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CTCSS RX USER ENTRY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        nameBox1.Location = New Point(474, nameBox1.Location.Y)
        nameBox2.Location = New Point(nameBox1.Location.X + 12, nameBox1.Location.Y)
        nameBox3.Location = New Point(nameBox2.Location.X + 12, nameBox1.Location.Y)
        nameBox4.Location = New Point(nameBox3.Location.X + 12, nameBox1.Location.Y)
        nameBox5.Location = New Point(nameBox4.Location.X + 12, nameBox1.Location.Y)

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(38, presetRowNum).Value) = True Then
            nameBox1.Text = "0"
            nameBox2.Text = "6"
            nameBox3.Text = "7"
            nameBox4.Text = "."
            nameBox5.Text = "0"
        Else
            storedCTCSSrxUserEntry = DataSetForm.PRCtrainerDataGridView.Item(38, presetRowNum).Value
            Dim i As String = storedCTCSSrxUserEntry
            nameBox1.Text = i.Chars(0)
            nameBox2.Text = i.Chars(1)
            nameBox3.Text = i.Chars(2)
            nameBox4.Text = i.Chars(3)
            nameBox5.Text = i.Chars(4)
        End If

        SetWidth(nameBox1)
        SetWidth(nameBox2)
        SetWidth(nameBox3)
        SetWidth(nameBox4)
        SetWidth(nameBox5)
        SetBackBlack(nameBox1)

        nameBox1.Visible = True
        nameBox2.Visible = True
        nameBox3.Visible = True
        nameBox4.Visible = True
        nameBox5.Visible = True



        d1TB.Text = "ENTER VALUE BETWEEN 67.0-254.1"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True


        ml3 = "ctcss rx user entry"
        HelperUpdate()

    End Sub

    Private Sub CDCSSrxCode()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CDCSS RX CODE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True


        If storedCDCSSrxCode = " " Then
            storedCDCSSrxCode = "023"
        End If
        c1TB.Text = storedCDCSSrxCode
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True

        b7PB.BackgroundImage = My.Resources.UpDown
        b7PB.Location = New Point(c4TB.Location.X + c4TB.Width + 2, c4TB.Location.Y + 2)
        b7PB.Size = New Size(10, 15)
        b7PB.Visible = True
        b7PB.BringToFront()


        d3TB.Text = "CDCSS EIA CODE"
        SetWidth(d3TB)
        CenterMe(d3TB)
        d3TB.Visible = True


        ml3 = "cdcss rx code"
        HelperUpdate()
    End Sub

    Private Sub ChannelBusyPriority()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CHAN BUSY PRIORITY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True


        If storedChannelBusyPriority = " " Then
            storedChannelBusyPriority = "TRANSMIT"
        End If
        c1TB.Text = storedChannelBusyPriority
        SetBackBlack(c1TB)
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "channel busy priority"
        HelperUpdate()


    End Sub

    Private Sub ValidateCTCSSentry(ByRef i As Boolean)
        Dim nb1 As Integer = CInt(nameBox1.Text)
        Dim nb2 As Integer = CInt(nameBox2.Text)
        Dim nb3 As Integer = CInt(nameBox3.Text)
        Dim nb5 As Integer = CInt(nameBox5.Text)
        i = False


        If nb1 = 0 And nb2 < 6 Then 'checks the lower limit of the entry
            ResetNameboxes()
            i = True
        ElseIf nb1 = 0 And nb2 = 6 And nb3 < 7 Then
            ResetNameboxes()
            i = True
        End If

        If nb1 >= 3 Then 'checks the higher limit of the entry
            ResetNameboxes()
            i = True
        ElseIf nb1 = 2 And nb2 >= 6 Then
            ResetNameboxes()
            i = True
        ElseIf nb1 = 2 And nb2 = 5 And nb3 >= 5 Then
            ResetNameboxes()
            i = True
        ElseIf nb1 = 2 And nb2 = 5 And nb3 = 4 And nb5 >= 2 Then
            ResetNameboxes()
            i = True
        End If


    End Sub

    Private Sub ResetNameboxes()
        nameBox1.Text = "0"
        nameBox2.Text = "6"
        nameBox3.Text = "7"
        nameBox5.Text = "0"
        SetBackBlack(nameBox1)
        SetBackGreen(nameBox2)
        SetBackGreen(nameBox3)
        SetBackGreen(nameBox5)
    End Sub

    Private Sub CDCSStxCode()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CDCSS TX CODE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedCDCSStxCode = " " Then
            storedCDCSStxCode = "023"
        End If
        c1TB.Text = storedCDCSStxCode
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True

        b7PB.BackgroundImage = My.Resources.UpDown
        b7PB.Location = New Point(c4TB.Location.X + c4TB.Width + 2, c4TB.Location.Y + 2)
        b7PB.Size = New Size(10, 15)
        b7PB.Visible = True
        b7PB.BringToFront()


        d3TB.Text = "CDCSS EIA CODE"
        SetWidth(d3TB)
        CenterMe(d3TB)
        d3TB.Visible = True

        ml3 = "cdcss tx code"
        HelperUpdate()
    End Sub

    Private Sub FMtransmitTone()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "FM TRANSMIT TONE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "DISABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)

        If storedMod = "AM" Then
            SetBackGreen(c1TB)
        Else
            SetBackBlack(c1TB)
        End If

        c1TB.Visible = True


        ShowToScrollEntToCont()

        d1TB.Visible = True

        ml3 = "fm tx tone"
        HelperUpdate()
    End Sub

    Private Sub ShowSquelch()
        If storedSquelch = " " Then
            a5TB.Text = "- - -"
        Else
            a5TB.Text = Microsoft.VisualBasic.Strings.Left(storedSquelch, 3)
        End If
        
    End Sub

    Private Sub ShowCrypto()
        If storedCryptoMode = "NONE" Or storedCryptoMode = " " Then
            a6TB.Text = "- - - - -"
        Else
            a6TB.Text = storedCryptoMode
        End If
    End Sub

    Private Sub VulosConfigSubMenus()
        If ml3 = "" Then
            'generate scrolling top menu
            DisplayReset()
            SetVisibilityOFF()
            showRowA()
            a1TB.Visible = True
            a1TB.Text = "PGM-VULOS"
            SetWidth(a1TB)
            a1TB.TextAlign = HorizontalAlignment.Left
            a2TB.Visible = False
            a3PB.Visible = False
            a4TB.Visible = False
            a5TB.Visible = False
            a6TB.Visible = False
            a7TB.Visible = False


            b1TB.Text = "BEACON CONFIG"
            b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
            b1TB.BackColor = Color.Black
            b1TB.ForeColor = Color.MediumSeaGreen
            b1TB.Visible = True

            c1TB.Text = "VINSON COMPATIBILITY"
            c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
            c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
            c1TB.Visible = True



            b7PB.Width = 11
            b7PB.Height = 44
            b7PB.Location = New Point(612, 161)
            b7PB.Visible = True


            NewScrollbar(2)
            JustificationAndSetWidth()
            ml3 = ""
            ml4 = ""
        End If
    End Sub

    Private Sub NewScrollbar(i As Integer) 'i is the total items in the scrollable list

        If i = 1 Then
            i = 2
        End If
        b6PB.Height = (28 / (i - 1))


        b7PB.BackgroundImage = My.Resources.scrollbarNull
        b7PB.BackgroundImageLayout = ImageLayout.Stretch
        b6PB.BackgroundImage = My.Resources.BlackBackground
        b6PB.BackgroundImageLayout = ImageLayout.Stretch
        b6PB.Width = 9

        b6PB.Location = New Point((b7PB.Location.X + 1), b7PB.Location.Y + 8)
        b6PB.Visible = True
    End Sub

    Private Sub VinsonCompatibilityScreen()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " PGM-VULOS-VINSON MODE"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "VINSON COMPATIBILITY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedVinsonCompatibility = " " Then
            storedVinsonCompatibility = "OFF"
        End If
        c1TB.Text = storedVinsonCompatibility
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)

        c1TB.Visible = True


        ShowToScrollEntToCont()

        d1TB.Visible = True

        ml3 = "vinson compatibility"
        HelperUpdate()
    End Sub

    Private Sub BeaconFrequency()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " PGM-VULOS-BEACON"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "BEACON FREQUENCY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedBeaconFreq = " " Then
            storedBeaconFreq = "090.0000"
        End If

        BreakApartFrequency(storedBeaconFreq)
        c1TB.Location = New Point(b1TB.Location.X + 48, c1TB.Location.Y)
        ArrangeNameboxes()


        freqRange = "90.0000 TO 511.9950"
        d1TB.Text = "ENTER " + freqRange
        d1TB.Visible = True
        SetWidth(d1TB)
        CenterMe(d1TB)

        ml3 = "beacon frequency"
        HelperUpdate()
    End Sub

    Private Sub BeaconModulation()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " PGM-VULOS-BEACON"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "BEACON MODULATION"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedBeaconMod = " " Then
            storedBeaconMod = "AM"
        End If

        c1TB.Text = storedBeaconMod
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "beacon modulation"
        HelperUpdate()
    End Sub

    Private Sub BeaconTxDuration()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " PGM-VULOS-BEACON"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "BEACON TX DURATION"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedBeaconTxDuration = " " Then
            storedBeaconTxDuration = "01"
        End If

        BreakApartFrequency(storedBeaconTxDuration)
        c1TB.Location = New Point(b1TB.Location.X + 72, c1TB.Location.Y)
        ArrangeNameboxes()
        nameBox1.Visible = False
        SetBackGreen(nameBox1)
        nameBox4.Visible = False
        nameBox5.Visible = False
        nameBox6.Visible = False
        nameBox7.Visible = False
        nameBox8.Visible = False
        SetBackBlack(nameBox2)



        d1TB.Text = "ENTER TX DURATION FROM 01-99"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "beacon tx duration"
        HelperUpdate()
    End Sub

    Private Sub BeaconOffDuration()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " PGM-VULOS-BEACON"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "BEACON OFF DURATION"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedBeaconOffDuration = " " Then
            storedBeaconOffDuration = "00"
        End If

        BreakApartFrequency(storedBeaconOffDuration)
        c1TB.Location = New Point(b1TB.Location.X + 80, c1TB.Location.Y)
        ArrangeNameboxes()
        nameBox1.Visible = False
        SetBackGreen(nameBox1)
        nameBox4.Visible = False
        nameBox5.Visible = False
        nameBox6.Visible = False
        nameBox7.Visible = False
        nameBox8.Visible = False
        SetBackBlack(nameBox2)



        d1TB.Text = "ENTER 0 FOR CONSTANT BEACON TX"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "beacon off duration"
        HelperUpdate()
    End Sub

    Private Sub BeaconTxPower()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " PGM-VULOS-BEACON"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "BEACON TX POWER"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedBeaconTxPower = " " Then
            storedBeaconTxPower = "MEDIUM"
        End If

        c1TB.Text = storedBeaconTxPower
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "beacon tx power"
        HelperUpdate()
    End Sub

    Private Sub SystemScanConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " PGM-SYS PRESETS-SCAN"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "ENABLE SCAN"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        

        c1TB.Text = "YES"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "scan preset enable"
        HelperUpdate()
    End Sub

    Private Sub ScanPresetWaveform()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " PGM-SYS PRESETS-SCAN"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "SCAN WAVEFORM"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True



        c1TB.Text = "VULOS"
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "scan preset waveform"
        HelperUpdate()
    End Sub

    Private Sub ScanConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-SYS PRESETS-SCAN-VULOS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "SCAN LIST"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "PRIORITY"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "HANG/HOLD TIME"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        menuChoices = "scan config"
        SelectMenu()
        MeasureArray()

        AutoScrollbar()
        JustificationAndSetWidth()
        ml3 = "scan config"
        HelperUpdate()
    End Sub

    Private Sub ScanList()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..-SYS PRESETS-SCAN-VULOS-LIST"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "ADD"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "VIEW"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "REMOVE"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        

        NewScrollbar(2)
        JustificationAndSetWidth()
        ml3 = "scan list"
        HelperUpdate()
    End Sub

    Private Sub AddScanList()

        
        CheckScanIsFull()

        If scanListFull = True Then

            DisplayReset()
            SetVisibilityOFF()
            showRowA()
            a1TB.Visible = True
            a1TB.Text = ".. PRESETS-SCAN-VULOS-LIST-ADD"
            SetWidth(a1TB)
            a1TB.TextAlign = HorizontalAlignment.Left
            a2TB.Visible = False
            a3PB.Visible = False
            a4TB.Visible = False
            a5TB.Visible = False
            a6TB.Visible = False
            a7TB.Visible = False

            b1TB.Text = "SCAN LIST"
            SetWidth(b1TB)
            CenterMe(b1TB)
            b1TB.Visible = True



            c1TB.Text = "FULL"
            c1TB.Visible = True
            SetWidth(c1TB)
            CenterMe(c1TB)




            ml3 = "scan list full"
            HelperUpdate()

            'Setting up a timer
            ml3 = "scan list full"  'variable representing the sending sub
            Timer1.Enabled = True       'enables the timer
            Timer1.Interval = 2000      'sets the tick interval to 2 seconds

        Else
            DisplayReset()
            SetVisibilityOFF()
            showRowA()
            a1TB.Visible = True
            a1TB.Text = ".. PRESETS-SCAN-VULOS-LIST-ADD"
            SetWidth(a1TB)
            a1TB.TextAlign = HorizontalAlignment.Left
            a2TB.Visible = False
            a3PB.Visible = False
            a4TB.Visible = False
            a5TB.Visible = False
            a6TB.Visible = False
            a7TB.Visible = False

            b1TB.Text = "SCAN PRESET TO ADD"
            SetWidth(b1TB)
            CenterMe(b1TB)
            b1TB.Visible = True



            c1TB.Text = storedNumber
            c1TB.Visible = True
            SetWidth(c1TB)



            If storedName.Contains("PRESET") And storedName.IndexOf("P") = 1 = True Then
                c3TB.Text = "<EMPTY>"
            Else
                c3TB.Text = storedName
            End If

            SetWidth(c3TB)
            c3TB.Location = New Point(c3TB.Location.X - 15, c3TB.Location.Y)
            c3TB.TextAlign = HorizontalAlignment.Left
            c3TB.Visible = True


            d1TB.Text = "ENTER 01-99/PRE +/- TO SCROLL"
            d1TB.Visible = True
            SetWidth(d1TB)
            CenterMe(d1TB)

            ml3 = "add scan list"
            HelperUpdate()
        End If


        
    End Sub

    Private Sub ViewScanList()

        CheckScanList()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = ".. PRESETS-SCAN-VULOS-LIST-VIEW"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        If IsDBNull(ScanListTA) = True Then
            b1TB.Text = "SCAN LIST"
            SetWidth(b1TB)
            CenterMe(b1TB)
            b1TB.Visible = True

            c1TB.Text = "EMPTY"
            SetWidth(c1TB)
            CenterMe(c1TB)
            c1TB.Visible = True

            d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
            SetWidth(d1TB)
            CenterMe(d1TB)
            d1TB.Visible = True
            ml3 = "view scan list"
            HelperUpdate()

        Else
            'create the remainder of the page
            CreateScanList()
        End If

        
        If ml3 = "scan list empty" Then

        Else
            ml3 = "view scan list"
        End If

        HelperUpdate()
    End Sub

    Private Sub AddAnotherPreset()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = ".. PRESETS-SCAN-VULOS-LIST-ADD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "ADD ANOTHER PRESET?"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True



        c1TB.Text = "YES"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "add another preset"
        HelperUpdate()
    End Sub

    Private Sub CheckScanList()
        ScanListTA.ScanListQuery()
    End Sub

    Private Sub CreateScanList()

        CheckScanIsFull()


        If scanListIsEmpty = True Then
            'show SCAN LIST EMPTY
            ScanListEmpty()
            Exit Sub
        End If

        b1TB.Text = scanListComplete(0)
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        SetWidth(b1TB)
        b1TB.Visible = True

        If scanListComplete(1) <> "" Then
            c1TB.Text = scanListComplete(1)
            c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
            c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
            SetWidth(c1TB)
            c1TB.Visible = True
        Else
            c1TB.Visible = False
        End If

        If scanListComplete(2) <> "" Then
            d1TB.Text = scanListComplete(2)
            d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
            d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
            SetWidth(d1TB)
            d1TB.Visible = True
        Else
            d1TB.Visible = False
        End If
        



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True



        NewScrollbar(2)
        JustificationAndSetWidth()
    End Sub

    Private Sub PresetAlreadyExists()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = ".. PRESETS-SCAN-VULOS-LIST-ADD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PRESET ALREADY EXISTS"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True



        c1TB.Text = "IN SCAN LIST"
        c1TB.Visible = True
        SetWidth(c1TB)
        CenterMe(c1TB)




        ml3 = "preset exists"
        HelperUpdate()

        'Setting up a timer
        ml3 = "preset exists"  'variable representing the sending sub
        Timer1.Enabled = True       'enables the timer
        Timer1.Interval = 2000      'sets the tick interval to 2 seconds
    End Sub

    Private Sub ScanListEmpty()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..-SYS PRESETS-SCAN-VULOS-LIST"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "SCAN LIST"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True



        c1TB.Text = "EMPTY"
        c1TB.Visible = True
        SetWidth(c1TB)
        CenterMe(c1TB)

        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True



        ml3 = "scan list empty"
        HelperUpdate()
    End Sub

    Private Sub CheckScanIsFull()
        Dim j As Integer = 0



        Try
            For i = 0 To 98

                If DataSetForm.PRCtrainerDataGridView.Item(50, i).Value.Equals("YES") = True Then

                    scanNum(i) = DataSetForm.PRCtrainerDataGridView.Item(0, i).Value
                    scanName(i) = "SCN" + scanNum(i) + DataSetForm.PRCtrainerDataGridView.Item(1, i).Value

                    scanListComplete(j) = scanName(i)
                    j += 1

                End If
                If j = 5 Then 'no more than 6 scan items are allowed
                    scanListFull = True
                    scanListIsEmpty = False

                    Exit For

                ElseIf j = 0 Then
                    scanListFull = False
                    scanListIsEmpty = True
                    scanListComplete(j) = ""

                ElseIf 0 < j < 5 Then
                    scanListFull = False
                    scanListIsEmpty = False
                    scanListComplete(j) = ""
                End If

            Next






        Catch ex As Exception

        End Try
    End Sub
    
    Private Sub RemovePresetFromScanList()
        CheckScanList()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = ".. ESETS-SCAN-VULOS-LIST-REMOVE"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        If IsDBNull(ScanListTA) = True Then
            b1TB.Text = "SCAN LIST"
            SetWidth(b1TB)
            CenterMe(b1TB)
            b1TB.Visible = True

            c1TB.Text = "EMPTY"
            SetWidth(c1TB)
            CenterMe(c1TB)
            c1TB.Visible = True

            d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
            SetWidth(d1TB)
            CenterMe(d1TB)
            d1TB.Visible = True
            ml3 = "remove preset"
            HelperUpdate()

        Else
            'create the remainder of the page
            CreateScanList()
        End If


        If ml3 = "scan list empty" Then

        Else
            ml3 = "remove preset"
        End If

        HelperUpdate()
    End Sub

    Private Sub ConfirmRemove()

        Dim myString As String

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..AN-VULOS-LIST-REMOVE-CONFIRM"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        myString = removalCandidate.Remove(0, 6)

        b1TB.Text = "REMOVE" + " " + myString
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True



        c1TB.Text = "YES"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "confirm remove"
        HelperUpdate()
    End Sub

    Private Sub ScanListScroll()

        Dim arrayIndex As Integer



        If thisNum = 9 Then

            GetArrayIndex(d1TB, arrayIndex)

            If arrayIndex = 4 Or scanListComplete(arrayIndex + 1) = "" Then
                Exit Sub
            End If

            b1TB.Text = c1TB.Text
            c1TB.Text = d1TB.Text
            d1TB.Text = scanListComplete(arrayIndex + 1)


        ElseIf thisNum = 6 Then

            GetArrayIndex(b1TB, arrayIndex)

            If arrayIndex = 0 Then
                Exit Sub
            End If

            d1TB.Text = c1TB.Text
            c1TB.Text = b1TB.Text
            b1TB.Text = scanListComplete(arrayIndex - 1)



        End If
    End Sub

    Private Sub GetArrayIndex(ByVal x As TextBox, ByRef i As Integer)

        For n = 0 To 5

            If x.Text = scanListComplete(n) Then
                i = n
            End If

        Next

    End Sub

    Private Sub PriorityTxPreset()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..PRESETS-SCAN-VULOS-PRIORITY"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PRIORITY TX PRESET"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        CheckScanIsFull()

        If scanListComplete(0) = "" Then
            c1TB.Text = "SCAN LIST EMPTY"
        Else
            c1TB.Text = MyGlobalData.GlobalSavedItemsDataGridView.Item(2, 0).Value
        End If


        SetWidth(c1TB)
        CenterMe(c1TB)

        If c1TB.Text = "SCAN LIST EMPTY" Then
        Else
            SetBackBlack(c1TB)
        End If

        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "priority tx preset"
        HelperUpdate()
    End Sub

    Private Sub GetMyHighlitedText(ByRef i As String)
        If b1TB.BackColor = Color.Black Then
            i = b1TB.Text
        ElseIf c1TB.BackColor = Color.Black Then
            i = c1TB.Text
        ElseIf d1TB.BackColor = Color.Black Then
            i = d1TB.Text
        End If
    End Sub

    Private Sub HangHoldTime()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..PRESETS-SCAN-VULOS-HANG/HOLD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "HANG TIME DURATION"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedHangTime = " " Then
            storedHangTime = "01"
        End If

        BreakApartFrequency(storedHangTime)
        c1TB.Location = New Point(b1TB.Location.X + 32, c1TB.Location.Y)
        ArrangeNameboxes()
        nameBox1.Visible = False
        SetBackGreen(nameBox1)
        nameBox4.Visible = False
        nameBox5.Visible = False
        nameBox6.Visible = False
        nameBox7.Visible = False
        nameBox8.Visible = False
        SetBackBlack(nameBox2)




        c4TB.Location = New Point(nameBox3.Location.X + 14, nameBox3.Location.Y)
        c4TB.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        c4TB.Text = "SECONDS"
        SetWidth(c4TB)
        c4TB.Visible = True
        c4TB.BringToFront()



        d1TB.Text = "ENTER HANG TIME FROM 01-99"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "hang time duration"
        HelperUpdate()
    End Sub

    Private Sub GetMyGlobalData()

        If IsDBNull(MyGlobalData.GlobalSavedItemsDataGridView.Item(1, 0).Value) = True Then
            storedScanEnable = " "
        Else
            storedScanEnable = MyGlobalData.GlobalSavedItemsDataGridView.Item(1, 0).Value

        End If

        If IsDBNull(MyGlobalData.GlobalSavedItemsDataGridView.Item(2, 0).Value) = True Then
            storedPriorityTx = " "
        Else
            storedPriorityTx = MyGlobalData.GlobalSavedItemsDataGridView.Item(2, 0).Value

        End If

        If IsDBNull(MyGlobalData.GlobalSavedItemsDataGridView.Item(3, 0).Value) = True Then
            storedPriorityRxEnable = " "
        Else
            storedPriorityRxEnable = MyGlobalData.GlobalSavedItemsDataGridView.Item(3, 0).Value

        End If

        If IsDBNull(MyGlobalData.GlobalSavedItemsDataGridView.Item(4, 0).Value) = True Then
            storedPriorityRx = " "
        Else
            storedPriorityRx = MyGlobalData.GlobalSavedItemsDataGridView.Item(4, 0).Value

        End If

        If IsDBNull(MyGlobalData.GlobalSavedItemsDataGridView.Item(5, 0).Value) = True Then
            storedHangTime = " "
        Else
            storedHangTime = MyGlobalData.GlobalSavedItemsDataGridView.Item(5, 0).Value

        End If

        If IsDBNull(MyGlobalData.GlobalSavedItemsDataGridView.Item(6, 0).Value) = True Then
            storedEnableHoldTime = " "
        Else
            storedEnableHoldTime = MyGlobalData.GlobalSavedItemsDataGridView.Item(6, 0).Value

        End If

        If IsDBNull(MyGlobalData.GlobalSavedItemsDataGridView.Item(7, 0).Value) = True Then
            storedHoldTimeDuration = " "
        Else
            storedHoldTimeDuration = MyGlobalData.GlobalSavedItemsDataGridView.Item(7, 0).Value

        End If

        
    End Sub

    Private Sub EnableRxPriorityScanning()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..PRESETS-SCAN-VULOS-PRIORITY"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "RX PRIORITY SCANNING"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True



        c1TB.Text = "ENABLE"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "rx priority scanning"
        HelperUpdate()
    End Sub

    Private Sub PriorityRxPreset()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..PRESETS-SCAN-VULOS-PRIORITY"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PRIORITY RX PRESET"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        CheckScanIsFull()

        If scanListComplete(0) = "" Then
            c1TB.Text = "SCAN LIST EMPTY"
        Else
            c1TB.Text = MyGlobalData.GlobalSavedItemsDataGridView.Item(4, 0).Value
        End If


        SetWidth(c1TB)
        CenterMe(c1TB)

        If c1TB.Text = "SCAN LIST EMPTY" Then
        Else
            SetBackBlack(c1TB)
        End If

        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "priority rx preset"
        HelperUpdate()
    End Sub

    Private Sub EnableDisable(ByRef i As String)
        If i = "ENABLE" Then
            i = "DISABLE"
        Else
            i = "ENABLE"
        End If
    End Sub

    Private Sub HoldTimeDuration()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..PRESETS-SCAN-VULOS-HANG/HOLD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "HOLD TIME DURATION"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedHoldTimeDuration = " " Then
            storedHoldTimeDuration = "01"
        End If

        BreakApartFrequency(storedHoldTimeDuration)
        c1TB.Location = New Point(b1TB.Location.X + 32, c1TB.Location.Y)
        ArrangeNameboxes()
        nameBox1.Visible = False
        SetBackGreen(nameBox1)
        nameBox4.Visible = False
        nameBox5.Visible = False
        nameBox6.Visible = False
        nameBox7.Visible = False
        nameBox8.Visible = False
        SetBackBlack(nameBox2)




        c4TB.Location = New Point(nameBox3.Location.X + 14, nameBox3.Location.Y)
        c4TB.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        c4TB.Text = "SECONDS"
        SetWidth(c4TB)
        c4TB.Visible = True
        c4TB.BringToFront()



        d1TB.Text = "ENTER HOLD TIME FROM 01-99"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "hold time duration"
        HelperUpdate()
    End Sub

    Private Sub CheckValidityOfHangHoldTime(ByRef i As String)
        Dim val As Integer
        val = CInt(i)
        If val < 1 Then
            i = 1
        End If
    End Sub

    Private Sub EnableHoldTime()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..PRESETS-SCAN-VULOS-HANG/HOLD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "HOLD TIME"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True



        c1TB.Text = "ENABLE"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "enable hold time"
        HelperUpdate()
    End Sub

    Private Sub RadioConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "CHANGE MAINT PSWD"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "GENERAL CONFIG"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "SYSTEM CLOCK"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        menuChoices = "radio config"
        SelectMenu()
        MeasureArray()

        NewScrollbar(4)
        JustificationAndSetWidth()

        ml3 = ""
        ml4 = ""

        HelperUpdate()
    End Sub

    Private Sub ScrollingMenu()

        If direction = "down" Then
            If b1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                b1TB.BackColor = Color.MediumSeaGreen
                b1TB.ForeColor = Color.Black

            ElseIf c1TB.BackColor = Color.Black Then
                d1TB.BackColor = Color.Black
                d1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black

            Else
                If d1TB.Text <> menuItems(0, xHi) Then 'stops the process when the end of the list is reached
                    b1TB.Text = c1TB.Text
                    c1TB.Text = d1TB.Text
                    d1TB.Text = menuItems(0, xCurrent + 1)

                End If
            End If
        ElseIf direction = "up" Then
            If d1TB.BackColor = Color.Black Then
                c1TB.BackColor = Color.Black
                c1TB.ForeColor = Color.MediumSeaGreen
                d1TB.BackColor = Color.MediumSeaGreen
                d1TB.ForeColor = Color.Black

            ElseIf c1TB.BackColor = Color.Black Then
                b1TB.BackColor = Color.Black
                b1TB.ForeColor = Color.MediumSeaGreen
                c1TB.BackColor = Color.MediumSeaGreen
                c1TB.ForeColor = Color.Black

            Else
                If b1TB.Text <> menuItems(0, 0) Then 'stops the process when the end of the list is reached
                    d1TB.Text = c1TB.Text
                    c1TB.Text = b1TB.Text
                    Try
                        b1TB.Text = menuItems(0, xCurrent - 1)
                    Catch
                    End Try

                End If
            End If
        End If
        JustificationAndSetWidth()
        MeasureArray()
        AutoScrollbar()

    End Sub 'will scroll through an array up and down, highliting the text as needed

    Private Sub checkHighlights(ByRef p1 As String)
        If b1TB.BackColor = Color.Black Then
            p1 = b1TB.Text
        ElseIf c1TB.BackColor = Color.Black Then
            p1 = c1TB.Text
        ElseIf d1TB.BackColor = Color.Black Then
            p1 = d1TB.Text
        End If
    End Sub

    Private Sub EnterMaintPswd()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-CHANGE PSWD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "MAINTENANCE PASSWORD"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        DescriptionEntry()
        CreateNameboxes()

        nameBox1.Text = "*"
        nameBox2.Text = "*"
        nameBox3.Text = "*"
        nameBox4.Text = "*"
        nameBox5.Text = "*"
        nameBox6.Text = "*"
        nameBox7.Text = "*"
        nameBox8.Text = "*"
        nameBox9.Text = "*"
        nameBox10.Text = "*"
        nameBox11.Text = "*"
        nameBox12.Text = "*"

        nameBox13.Visible = False
        nameBox14.Visible = False
        nameBox15.Visible = False
        nameBox16.Visible = False
        nameBox17.Visible = False
        nameBox18.Visible = False
        nameBox19.Visible = False
        nameBox20.Visible = False

        c1TB.Location = New Point(c1TB.Location.X + 60, c1TB.Location.Y)
        ArrangeNameboxes()



        d1TB.Text = "ENTER ALPHANUMERIC PASSWORD"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        tempMaintPswd2 = ""

        ml3 = "enter maint pswd"
        HelperUpdate()
    End Sub


    Private Sub ChangeMaintPswd()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-CHANGE PSWD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "ENTER NEW PASSWORD"
        b1TB.Width = 250
        CenterMe(b1TB)
        b1TB.Visible = True

        DescriptionEntry()
        CreateNameboxes()

        nameBox1.Text = "*"
        nameBox2.Text = "*"
        nameBox3.Text = "*"
        nameBox4.Text = "*"
        nameBox5.Text = "*"
        nameBox6.Text = "*"
        nameBox7.Text = "*"
        nameBox8.Text = "*"
        nameBox9.Text = "*"
        nameBox10.Text = "*"
        nameBox11.Text = "*"
        nameBox12.Text = "*"

        nameBox13.Visible = False
        nameBox14.Visible = False
        nameBox15.Visible = False
        nameBox16.Visible = False
        nameBox17.Visible = False
        nameBox18.Visible = False
        nameBox19.Visible = False
        nameBox20.Visible = False

        c1TB.Location = New Point(c1TB.Location.X + 60, c1TB.Location.Y)
        ArrangeNameboxes()



        d1TB.Text = "ENTER ALPHANUMERIC PASSWORD"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        tempMaintPswd2 = ""

        ml3 = "change maint pswd"
        HelperUpdate()
    End Sub

    Private Sub RadioGeneralConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "AUDIO CONFIG"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "AUTOSAVE CONFIG"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "CT OVERRIDE CONFIG"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        menuChoices = "general radio config"
        SelectMenu()
        MeasureArray()

        NewScrollbar(12)
        JustificationAndSetWidth()

        ml3 = "general config"
        ml4 = ""

        HelperUpdate()
    End Sub

    Private Sub HideCharacters()
        If nameBox1.Text <> "*" Then
            pswd1 = nameBox1.Text
            nameBox1.Text = "*"
        End If

        If nameBox2.Text <> "*" Then
            pswd2 = nameBox2.Text
            nameBox2.Text = "*"
        End If

        If nameBox3.Text <> "*" Then
            pswd3 = nameBox3.Text
            nameBox3.Text = "*"
        End If

        If nameBox4.Text <> "*" Then
            pswd4 = nameBox4.Text
            nameBox4.Text = "*"
        End If

        If nameBox5.Text <> "*" Then
            pswd5 = nameBox5.Text
            nameBox5.Text = "*"
        End If

        If nameBox6.Text <> "*" Then
            pswd6 = nameBox6.Text
            nameBox6.Text = "*"
        End If

        If nameBox7.Text <> "*" Then
            pswd7 = nameBox7.Text
            nameBox7.Text = "*"
        End If

        If nameBox8.Text <> "*" Then
            pswd8 = nameBox8.Text
            nameBox8.Text = "*"
        End If

        If nameBox9.Text <> "*" Then
            pswd9 = nameBox9.Text
            nameBox9.Text = "*"
        End If

        If nameBox10.Text <> "*" Then
            pswd10 = nameBox10.Text
            nameBox10.Text = "*"
        End If

        If nameBox11.Text <> "*" Then
            pswd11 = nameBox11.Text
            nameBox11.Text = "*"
        End If

        If nameBox12.Text <> "*" Then
            pswd12 = nameBox12.Text
            nameBox12.Text = "*"
        End If


    End Sub

    Private Sub ValidateMaintPswd()
        tempMaintPswd = pswd1 + pswd2 + pswd3 + pswd4 + pswd5 + pswd6 + pswd7 + pswd8 + pswd9 + pswd10 + pswd11 + pswd12

        If tempMaintPswd.Length < 10 Then   'checks for 10 character minimum length
            b1Warning = "* INVALID PASSWORD *"
            c1Warning = "TOO SHORT"
            PasswordWarnings(b1Warning, c1Warning)
            Exit Sub
        End If

        If tempMaintPswd = defaultMaintPswd Then  'checks for default password match
            b1Warning = "* INVALID PASSWORD *"
            c1Warning = "CANNOT BE DEFAULT"
            PasswordWarnings(b1Warning, c1Warning)
            Exit Sub
        End If

        Dim j As Boolean = False

        CheckForRepeat(j)
        If j = True Then  'checks for repeating characters
            b1Warning = "* INVALID PASSWORD *"
            c1Warning = "REPEAT DETECTED"
            PasswordWarnings(b1Warning, c1Warning)
            Exit Sub
        End If

        CheckForConsecutive(j)
        If j = True Then  'checks for repeating characters
            b1Warning = "* INVALID PASSWORD *"
            c1Warning = "SEQUENCE DETECTED"
            PasswordWarnings(b1Warning, c1Warning)
            Exit Sub
        End If

        'checks for at least two letters
        CheckForTwoLetters(j)
        If j = True Then  'checks for repeating characters
            b1Warning = "* PASSWORD MUST HAVE *"
            c1Warning = "AT LEAST 2 LETTERS"
            PasswordWarnings(b1Warning, c1Warning)
            Exit Sub
        End If

        'checks for at least two numbers
        CheckForTwoNumbers(j)
        If j = True Then  'checks for repeating characters
            b1Warning = "* PASSWORD MUST HAVE *"
            c1Warning = "AT LEAST 2 NUMBERS"
            PasswordWarnings(b1Warning, c1Warning)
            Exit Sub
        End If

        'past this point, confirm password is the same as second entry
        If tempMaintPswd2 = "" Then
            tempMaintPswd2 = tempMaintPswd
            ConfirmNewPassword()
        End If
        

    End Sub

    Private Sub PasswordWarnings(b1Warning, c1Warning)
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-CHANGE PSWD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = b1Warning
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = c1Warning
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "password warnings"
        HelperUpdate()
    End Sub

    Private Sub CheckForRepeat(ByRef j As Boolean)

        Dim pswdArray() As String = {pswd1, pswd2, pswd3, pswd4, pswd5, pswd6, pswd7, pswd8, pswd9, pswd10, pswd11, pswd12}

        Dim i As Integer = 0

        Do While j <> True And i < 11
            If pswdArray(i) <> "" And pswdArray(i) = pswdArray(i + 1) Then
                If pswdArray(i + 1) = pswdArray(i + 2) Then
                    j = True
                    Exit Sub
                Else
                    j = False
                End If
            End If
            i += 1
        Loop
    End Sub

    Private Sub CheckForConsecutive(ByRef j As Boolean)
        Dim pswdArray() As String = {pswd1, pswd2, pswd3, pswd4, pswd5, pswd6, pswd7, pswd8, pswd9, pswd10, pswd11, pswd12}

        Dim i As Integer = 0

        Try
            Do While j <> True And i < 11
                If Asc(pswdArray(i)) = Asc(pswdArray(i + 1)) - 1 Then
                    If Asc(pswdArray(i + 1)) = Asc(pswdArray(i + 2)) - 1 Then
                        j = True
                        Exit Sub
                    Else
                        j = False
                    End If
                End If

                If Asc(pswdArray(i)) - 1 = Asc(pswdArray(i + 1)) Then
                    If Asc(pswdArray(i + 1)) - 1 = Asc(pswdArray(i + 2)) Then
                        j = True
                        Exit Sub
                    Else
                        j = False
                    End If
                End If
                i += 1
            Loop

        Catch

        End Try

    End Sub

    Private Sub ConfirmNewPassword()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-CHANGE PSWD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CONFIRM NEW PASSWORD"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        DescriptionEntry()
        CreateNameboxes()

        nameBox1.Text = "*"
        nameBox2.Text = "*"
        nameBox3.Text = "*"
        nameBox4.Text = "*"
        nameBox5.Text = "*"
        nameBox6.Text = "*"
        nameBox7.Text = "*"
        nameBox8.Text = "*"
        nameBox9.Text = "*"
        nameBox10.Text = "*"
        nameBox11.Text = "*"
        nameBox12.Text = "*"

        nameBox13.Visible = False
        nameBox14.Visible = False
        nameBox15.Visible = False
        nameBox16.Visible = False
        nameBox17.Visible = False
        nameBox18.Visible = False
        nameBox19.Visible = False
        nameBox20.Visible = False

        c1TB.Location = New Point(c1TB.Location.X + 60, c1TB.Location.Y)
        ArrangeNameboxes()



        d1TB.Text = "ENTER ALPHANUMERIC PASSWORD"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True


        ml3 = "confirm maint pswd"
        HelperUpdate()
    End Sub

    Private Sub ValidatePswdEntry()
        
        tempMaintPswd = pswd1 + pswd2 + pswd3 + pswd4 + pswd5 + pswd6 + pswd7 + pswd8 + pswd9 + pswd10 + pswd11 + pswd12



        If tempMaintPswd2 = "" Then
            If newMaintPswd = "" Then
                If tempMaintPswd <> defaultMaintPswd Then
                    b1Warning = "** INVALID **"
                    c1Warning = "PASSWORD"
                    PasswordWarnings(b1Warning, c1Warning)
                    Exit Sub
                ElseIf tempMaintPswd = defaultMaintPswd Then
                    tempMaintPswd2 = tempMaintPswd
                    ReEnterMaintPswd()
                    Exit Sub
                End If
            ElseIf newMaintPswd <> "" Then
                If tempMaintPswd <> newMaintPswd Then
                    b1Warning = "** INVALID **"
                    c1Warning = "PASSWORD"
                    PasswordWarnings(b1Warning, c1Warning)
                    Exit Sub
                ElseIf tempMaintPswd = newMaintPswd Then
                    tempMaintPswd2 = tempMaintPswd
                    ReEnterMaintPswd()
                    Exit Sub
                End If
            End If
        Else

            If tempMaintPswd2 = tempMaintPswd Then
                ChangeMaintPswd()
            Else
                b1Warning = "** INVALID **"
                c1Warning = "PASSWORD"
                PasswordWarnings(b1Warning, c1Warning)
                Exit Sub
            End If

        End If


    End Sub

    Private Sub ReEnterMaintPswd()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-CHANGE PSWD"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "OLD PASSWORD"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        DescriptionEntry()
        CreateNameboxes()

        nameBox1.Text = "*"
        nameBox2.Text = "*"
        nameBox3.Text = "*"
        nameBox4.Text = "*"
        nameBox5.Text = "*"
        nameBox6.Text = "*"
        nameBox7.Text = "*"
        nameBox8.Text = "*"
        nameBox9.Text = "*"
        nameBox10.Text = "*"
        nameBox11.Text = "*"
        nameBox12.Text = "*"

        nameBox13.Visible = False
        nameBox14.Visible = False
        nameBox15.Visible = False
        nameBox16.Visible = False
        nameBox17.Visible = False
        nameBox18.Visible = False
        nameBox19.Visible = False
        nameBox20.Visible = False

        c1TB.Location = New Point(c1TB.Location.X + 60, c1TB.Location.Y)
        ArrangeNameboxes()



        d1TB.Text = "ENTER ALPHANUMERIC PASSWORD"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True



        ml3 = "reenter maint pswd"
        HelperUpdate()
    End Sub

    Private Sub CheckForTwoLetters(ByRef j As Boolean)
        Dim pswdArray() As String = {pswd1, pswd2, pswd3, pswd4, pswd5, pswd6, pswd7, pswd8, pswd9, pswd10, pswd11, pswd12}

        Dim i As Integer = 0
        Dim k As Integer = 0

        Do While j <> True And i < 12
            If String.IsNullOrEmpty(pswdArray(i)) = True Then

            Else
                If Char.IsLetter(pswdArray(i).Chars(0)) Then
                    k += 1
                End If
            End If
            i += 1
        Loop
        If k >= 2 Then
            j = False
        Else
            j = True
        End If

    End Sub

    Private Sub CheckForTwoNumbers(ByRef j As Boolean)
        Dim pswdArray() As String = {pswd1, pswd2, pswd3, pswd4, pswd5, pswd6, pswd7, pswd8, pswd9, pswd10, pswd11, pswd12}

        Dim i As Integer = 0
        Dim k As Integer = 0

        Do While j <> True And i < 12
            If String.IsNullOrEmpty(pswdArray(i)) = True Then

            Else
                If Char.IsNumber(pswdArray(i).Chars(0)) Then
                    k += 1
                End If
            End If
            i += 1
        Loop
        If k >= 2 Then
            j = False
        Else
            j = True
        End If
    End Sub

    Private Sub ValidateNewPassword()
        If tempMaintPswd2 = tempMaintPswd Then
            PasswordChangeSuccessful()
        Else
            ValidateMaintPswd()
        End If
    End Sub

    Private Sub PasswordChangeSuccessful()
        b1Warning = "PASSWORD CHANGE"
        c1Warning = "SUCCESSFUL"
        PasswordWarnings(b1Warning, c1Warning)
        newMaintPswd = tempMaintPswd2
        ml3 = "pswd change successful"
        HelperUpdate()
    End Sub

    Private Sub AudioConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-AUDIO"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "AUDIO SIDETONE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "ENABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "audio sidetone"
        HelperUpdate()
    End Sub

    Private Sub VoiceKeyUpTimeout()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-AUDIO"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "VOICE KEY UP TIMEOUT"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "DISABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "voice key up timeout"
        HelperUpdate()
    End Sub

    Private Sub VoiceKeyUpTimeoutTime()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-AUDIO"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "VOICE KEY UP TIMEOUT"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        DescriptionEntry()
        CreateNameboxes()

        nameBox1.Text = "1"
        nameBox2.Text = "2"
        nameBox3.Text = "0"

        nameBox4.Visible = False
        nameBox5.Visible = False
        nameBox6.Visible = False
        nameBox7.Visible = False
        nameBox8.Visible = False
        nameBox9.Visible = False
        nameBox10.Visible = False
        nameBox11.Visible = False
        nameBox12.Visible = False
        nameBox13.Visible = False
        nameBox14.Visible = False
        nameBox15.Visible = False
        nameBox16.Visible = False
        nameBox17.Visible = False
        nameBox18.Visible = False
        nameBox19.Visible = False
        nameBox20.Visible = False

        c1TB.Location = New Point(c1TB.Location.X + 100, c1TB.Location.Y)
        ArrangeNameboxes()

        d1TB.Text = "ENTER 10 TO 120 SECONDS"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "voice key up timeout time"
        HelperUpdate()
    End Sub

    Private Sub AutoSaveConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-AUTOSAVE"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PRESET AUTOSAVE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "ON"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "autosave config"
        HelperUpdate()
    End Sub

    Private Sub CtOverride()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-CT OVERRIDE"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CT OVERRIDE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "DISABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "ct override"
        HelperUpdate()
    End Sub

    Private Sub DataPortConfigSubMenu()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-DATA PORT"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "GENERAL HW CONFIG"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "SYNC CONFIG"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "ASYNC CONFIG"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        menuChoices = "data port config"
        SelectMenu()
        MeasureArray()

        NewScrollbar(3)
        JustificationAndSetWidth()

        ml3 = "data port config"
        ml4 = ""

        HelperUpdate()
    End Sub

    Private Sub PPPconfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..GENERAL-DATA PORT-PPP CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "DATA PORT CONFIG"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "NET CONFIG"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        

        NewScrollbar(2)
        JustificationAndSetWidth()

        ml3 = "ppp config"
        ml4 = ""

        HelperUpdate()
    End Sub

    Private Sub AsyncConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..NERAL-DATA PORT-ASYNC CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "DATA RATE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "1200"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "async config"
        HelperUpdate()
    End Sub

    Private Sub SyncConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..ENERAL-DATA PORT-SYNC CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "TX CLOCK SOURCE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "INTERNAL ON CTS"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "sync config"
        HelperUpdate()
    End Sub

    Private Sub GeneralHWconfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "-DATA PORT-GENERAL HW CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "HW INTERFACE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "RS232"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "general hw config"
        HelperUpdate()
    End Sub

    Private Sub Polarityconfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "-DATA PORT-GENERAL HW CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "POLARITY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "NORMAL"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "polarity config"
        HelperUpdate()
    End Sub

    Private Sub SyncEdge()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..ENERAL-DATA PORT-SYNC CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "EDGE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "FALLING"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "sync edge"
        HelperUpdate()
    End Sub

    Private Sub AsyncCharacterLength()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..NERAL-DATA PORT-ASYNC CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CHARACTER LENGTH"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "8"
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "async character length"
        HelperUpdate()
    End Sub

    Private Sub AsyncParity()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..NERAL-DATA PORT-ASYNC CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PARITY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "NONE"
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "async parity"
        HelperUpdate()
    End Sub

    Private Sub AsyncStopBits()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..NERAL-DATA PORT-ASYNC CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "STOP BITS"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "1"
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "async stop bits"
        HelperUpdate()
    End Sub

    Private Sub AsyncFlowControl()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..NERAL-DATA PORT-ASYNC CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "FLOW CONTROL"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "NONE"
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "async flow control"
        HelperUpdate()
    End Sub

    Private Sub PPPbaudRate()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        If ml3 = "port j3" Then
            a1TB.Text = "PGM-RADIO-GENERAL-PORTS"
        Else
            a1TB.Text = "..PPP CONFIG-DATA PORT CONFIG"
        End If
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "BAUDRATE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "115200"
        SetWidth(c1TB)
        CenterMe(c1TB)
        If ml3 = "port j3" Then
            SetBackBlack(c1TB)
        End If
        c1TB.Visible = True

        If ml3 = "port j3" Then
            ml3 = "port baudrate"
            ShowToScrollEntToCont()
        Else
            ml3 = "ppp baud rate"
            d1TB.Text = "PRESS ENT TO CONTINUE"
            SetWidth(d1TB)
            CenterMe(d1TB)
        End If

        
        d1TB.Visible = True

        

        HelperUpdate()
    End Sub

    Private Sub PortConfigIPaddress()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..A PORT-PPP CONFIG-NET CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "IP ADDRESS"
        b1TB.Width = 250
        b1TB.Visible = True

        CreateIPTextboxes()

        ip1.Location = New Point(415, 178)
        ip2.Location = New Point(ip1.Location.X + ip1.Width, 178)
        ip3.Location = New Point(ip2.Location.X + ip2.Width, 178)
        ip4.Location = New Point(ip3.Location.X + ip3.Width, 178)
        ip5.Location = New Point(ip4.Location.X + ip4.Width, 178)
        ip6.Location = New Point(ip5.Location.X + ip5.Width, 178)
        ip7.Location = New Point(ip6.Location.X + ip6.Width, 178)
        ip8.Location = New Point(ip7.Location.X + ip7.Width, 178)
        ip9.Location = New Point(ip8.Location.X + ip8.Width, 178)
        ip10.Location = New Point(ip9.Location.X + ip9.Width, 178)
        ip11.Location = New Point(ip10.Location.X + ip10.Width, 178)
        ip12.Location = New Point(ip11.Location.X + ip11.Width, 178)
        ip13.Location = New Point(ip12.Location.X + ip12.Width, 178)
        ip14.Location = New Point(ip13.Location.X + ip13.Width, 178)
        ip15.Location = New Point(ip14.Location.X + ip14.Width, 178)


        ip1.Visible = True
        ip2.Visible = True
        ip3.Visible = True
        ip4.Visible = True
        ip5.Visible = True
        ip6.Visible = True
        ip7.Visible = True
        ip8.Visible = True
        ip9.Visible = True
        ip10.Visible = True
        ip11.Visible = True
        ip12.Visible = True
        ip13.Visible = True
        ip14.Visible = True
        ip15.Visible = True


        d1TB.Text = "ENTER IP ADDRESS"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "port config ip address"
        HelperUpdate()
    End Sub

    Private Sub PortConfigPeerIPaddress()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..A PORT-PPP CONFIG-NET CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PEER IP ADDRESS"
        b1TB.Width = 250
        b1TB.Visible = True

        CreateIPTextboxes()

        ip1.Location = New Point(415, 178)
        ip2.Location = New Point(ip1.Location.X + ip1.Width, 178)
        ip3.Location = New Point(ip2.Location.X + ip2.Width, 178)
        ip4.Location = New Point(ip3.Location.X + ip3.Width, 178)
        ip5.Location = New Point(ip4.Location.X + ip4.Width, 178)
        ip6.Location = New Point(ip5.Location.X + ip5.Width, 178)
        ip7.Location = New Point(ip6.Location.X + ip6.Width, 178)
        ip8.Location = New Point(ip7.Location.X + ip7.Width, 178)
        ip9.Location = New Point(ip8.Location.X + ip8.Width, 178)
        ip10.Location = New Point(ip9.Location.X + ip9.Width, 178)
        ip11.Location = New Point(ip10.Location.X + ip10.Width, 178)
        ip12.Location = New Point(ip11.Location.X + ip11.Width, 178)
        ip13.Location = New Point(ip12.Location.X + ip12.Width, 178)
        ip14.Location = New Point(ip13.Location.X + ip13.Width, 178)
        ip15.Location = New Point(ip14.Location.X + ip14.Width, 178)


        ip1.Visible = True
        ip2.Visible = True
        ip3.Visible = True
        ip4.Visible = True
        ip5.Visible = True
        ip6.Visible = True
        ip7.Visible = True
        ip8.Visible = True
        ip9.Visible = True
        ip10.Visible = True
        ip11.Visible = True
        ip12.Visible = True
        ip13.Visible = True
        ip14.Visible = True
        ip15.Visible = True


        d1TB.Text = "ENTER PEER IP ADDRESS"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "port config peer ip address"
        HelperUpdate()
    End Sub

    Private Sub PortConfigSubnetMask()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..A PORT-PPP CONFIG-NET CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "SUBNET MASK"
        b1TB.Width = 250
        b1TB.Visible = True

        CreateIPTextboxes()

        ip1.Location = New Point(415, 178)
        ip2.Location = New Point(ip1.Location.X + ip1.Width, 178)
        ip3.Location = New Point(ip2.Location.X + ip2.Width, 178)
        ip4.Location = New Point(ip3.Location.X + ip3.Width, 178)
        ip5.Location = New Point(ip4.Location.X + ip4.Width, 178)
        ip6.Location = New Point(ip5.Location.X + ip5.Width, 178)
        ip7.Location = New Point(ip6.Location.X + ip6.Width, 178)
        ip8.Location = New Point(ip7.Location.X + ip7.Width, 178)
        ip9.Location = New Point(ip8.Location.X + ip8.Width, 178)
        ip10.Location = New Point(ip9.Location.X + ip9.Width, 178)
        ip11.Location = New Point(ip10.Location.X + ip10.Width, 178)
        ip12.Location = New Point(ip11.Location.X + ip11.Width, 178)
        ip13.Location = New Point(ip12.Location.X + ip12.Width, 178)
        ip14.Location = New Point(ip13.Location.X + ip13.Width, 178)
        ip15.Location = New Point(ip14.Location.X + ip14.Width, 178)


        ip1.Visible = True
        ip2.Visible = True
        ip3.Visible = True
        ip4.Visible = True
        ip5.Visible = True
        ip6.Visible = True
        ip7.Visible = True
        ip8.Visible = True
        ip9.Visible = True
        ip10.Visible = True
        ip11.Visible = True
        ip12.Visible = True
        ip13.Visible = True
        ip14.Visible = True
        ip15.Visible = True


        d1TB.Text = "ENTER SUBNET MASK"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "port config subnet mask"
        HelperUpdate()
    End Sub

    Private Sub PPPcharacterLength()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        If ml3 = "port baudrate" Then
            a1TB.Text = "PGM-RADIO-GENERAL-PORTS"
        Else
            a1TB.Text = "..PPP CONFIG-DATA PORT CONFIG"
        End If

        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CHARACTER LENGTH"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "8"
        SetWidth(c1TB)
        CenterMe(c1TB)
        If ml3 = "port baudrate" Then
            SetBackBlack(c1TB)
        End If
        c1TB.Visible = True

        If ml3 = "port baudrate" Then
            ml3 = "port character length"
            ShowToScrollEntToCont()
        Else
            ml3 = "ppp character length"
            d1TB.Text = "PRESS ENT TO CONTINUE"
            SetWidth(d1TB)
            CenterMe(d1TB)
        End If

        
        d1TB.Visible = True

        

        HelperUpdate()
    End Sub

    Private Sub PPPparity()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        If ml3 = "port character length" Then
            a1TB.Text = "PGM-RADIO-GENERAL-PORTS"
        Else
            a1TB.Text = "..PPP CONFIG-DATA PORT CONFIG"
        End If

        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PARITY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "NONE"
        SetWidth(c1TB)
        CenterMe(c1TB)
        If ml3 = "port character length" Then
            SetBackBlack(c1TB)
        End If
        c1TB.Visible = True


        If ml3 = "port character length" Then
            ml3 = "port parity"
            ShowToScrollEntToCont()
        Else
            ml3 = "ppp parity"
            d1TB.Text = "PRESS ENT TO CONTINUE"
            SetWidth(d1TB)
            CenterMe(d1TB)
        End If
        d1TB.Visible = True


        HelperUpdate()
    End Sub

    Private Sub PPPstopBits()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        If ml3 = "port parity" Then
            a1TB.Text = "PGM-RADIO-GENERAL-PORTS"
        Else
            a1TB.Text = "..PPP CONFIG-DATA PORT CONFIG"
        End If

        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "STOP BITS"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "1"
        SetWidth(c1TB)
        CenterMe(c1TB)
        If ml3 = "port parity" Then
            SetBackBlack(c1TB)
        End If
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        If ml3 = "port parity" Then
            ml3 = "port stop bits"
            ShowToScrollEntToCont()
        Else
            ml3 = "ppp stop bits"
            d1TB.Text = "PRESS ENT TO CONTINUE"
            SetWidth(d1TB)
            CenterMe(d1TB)
        End If


        HelperUpdate()
    End Sub

    Private Sub PPPflowControl()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..PPP CONFIG-DATA PORT CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "FLOW CONTROL"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "NONE"
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "ppp flow control"
        HelperUpdate()
    End Sub

    Private Sub PortConfigGatewayAddress()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..A PORT-PPP CONFIG-NET CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "GATEWAY ADDRESS"
        b1TB.Width = 250
        b1TB.Visible = True

        CreateIPTextboxes()

        ip1.Location = New Point(415, 178)
        ip2.Location = New Point(ip1.Location.X + ip1.Width, 178)
        ip3.Location = New Point(ip2.Location.X + ip2.Width, 178)
        ip4.Location = New Point(ip3.Location.X + ip3.Width, 178)
        ip5.Location = New Point(ip4.Location.X + ip4.Width, 178)
        ip6.Location = New Point(ip5.Location.X + ip5.Width, 178)
        ip7.Location = New Point(ip6.Location.X + ip6.Width, 178)
        ip8.Location = New Point(ip7.Location.X + ip7.Width, 178)
        ip9.Location = New Point(ip8.Location.X + ip8.Width, 178)
        ip10.Location = New Point(ip9.Location.X + ip9.Width, 178)
        ip11.Location = New Point(ip10.Location.X + ip10.Width, 178)
        ip12.Location = New Point(ip11.Location.X + ip11.Width, 178)
        ip13.Location = New Point(ip12.Location.X + ip12.Width, 178)
        ip14.Location = New Point(ip13.Location.X + ip13.Width, 178)
        ip15.Location = New Point(ip14.Location.X + ip14.Width, 178)


        ip1.Visible = True
        ip2.Visible = True
        ip3.Visible = True
        ip4.Visible = True
        ip5.Visible = True
        ip6.Visible = True
        ip7.Visible = True
        ip8.Visible = True
        ip9.Visible = True
        ip10.Visible = True
        ip11.Visible = True
        ip12.Visible = True
        ip13.Visible = True
        ip14.Visible = True
        ip15.Visible = True


        d1TB.Text = "ENTER GATEWAY ADDRESS"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "port config gateway address"
        HelperUpdate()
    End Sub

    Private Sub ExternalDeviceMenu()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-EXT"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "ANTENNA"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "REMOTE KDU"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True



        NewScrollbar(2)
        JustificationAndSetWidth()

        ml3 = "external device menu"
        ml4 = ""

        HelperUpdate()
    End Sub

    Private Sub ExternalAntenna()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-EXT-ANT"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "ANTENNA LNA"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "DISABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True



        ShowToScrollEntToCont()
        d1TB.Visible = True

        ml3 = "antenna lna"
        HelperUpdate()
    End Sub

    Private Sub RemoteKDUnotConnected()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-EXT-RKDU"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "REMOTE KDU"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "NOT CONNECTED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "kdu not connected"
        HelperUpdate()
    End Sub

    Private Sub ExternalKeylineMenu()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-KEYLINE"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "EXTERNAL KEYLINE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "DISABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "external keyline"
        HelperUpdate()
    End Sub

    Private Sub GpsType()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-GPS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "GPS TYPE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "INTERNAL"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "gps type"
        HelperUpdate()
    End Sub

    Private Sub GPSsleepCycle()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-GPS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "GPS SLEEP CYCLE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "ENABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "gps sleep cycle"
        HelperUpdate()
    End Sub

    Private Sub GPSsleepTime()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-GPS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "GPS SLEEP TIME"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        ml3 = "gps sleep cycle"
        CreateIPTextboxes()

        ip1.Location = New Point(485, 178)
        ip2.Location = New Point(ip1.Location.X + ip1.Width, 178)
        ip3.Text = "1"
        ip3.Location = New Point(ip2.Location.X + ip2.Width, 178)
        ip4.Text = "5"
        ip4.Location = New Point(ip3.Location.X + ip3.Width, 178)


        ip1.Visible = True
        ip2.Visible = True
        ip3.Visible = True
        ip4.Visible = True
        

        d1TB.Text = "ENTER SLEEP TIME - 1 TO 9999"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        HelperUpdate()
    End Sub

    Private Sub PositionFormat()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-GPS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "POSITION FORMAT"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "LAT LONG DMS"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "position format"
        HelperUpdate()
    End Sub

    Private Sub LinearUnits()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-GPS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "LINEAR UNITS"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "METRIC"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "linear units"
        HelperUpdate()
    End Sub

    Private Sub ElevationBasis()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-GPS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "ELEVATION BASIS"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "MEAN SEA LEVEL"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "elevation basis"
        HelperUpdate()
    End Sub

    Private Sub AngularUnits()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-GPS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "ANGULAR UNITS"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "DEGREES MAGNETIC"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "angular units"
        HelperUpdate()
    End Sub

    Private Sub GridDigits()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-GPS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "GRID DIGITS"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "8"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "grid digits"
        HelperUpdate()
    End Sub

    Private Sub DatumProgramming()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-GPS-DATUMS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        b1TB.Text = "GROUP:COMMON NAME: "
        SetWidth(b1TB)
        b2TB.Location = New Point(b1TB.Location.X + b1TB.Width, b1TB.Location.Y)
        b2TB.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        b2TB.Text = "WGD"
        SetWidth(b2TB)
        SetBackBlack(b2TB)
        b2TB.Width += 1
        b2TB.Visible = True


        b1TB.Visible = True
        c1TB.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        c1TB.Text = "WORLD GEODETIC DATUM"
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "datum programming"
        HelperUpdate()
    End Sub

    Private Sub NetworkConfigMenu()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-NETWORK"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "IPV4 CONFIG"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "RED ETHERNET CONFIG"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True



        NewScrollbar(2)
        JustificationAndSetWidth()

        ml3 = "network configuration menu"
        ml4 = ""

        HelperUpdate()
    End Sub

    Private Sub IPV4ConfigSubmenu()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-NETWORK"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False


        b1TB.Text = "RED ICMP CONFIG"
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = "IKE CONFIG"
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = "TCP ACCEL CONFIG"
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True



        NewScrollbar(2)
        JustificationAndSetWidth()

        ml3 = "ipv4 configuration menu"
        ml4 = ""

        HelperUpdate()
    End Sub

    Private Sub MessageProcessing()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..-IPV4 CONFIG-RED ICMP CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "MESSAGE PROCESSING"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "DISABLE"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "message processing"
        HelperUpdate()
    End Sub

    Private Sub IkeTimeout()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..TWORK-IPV4 CONFIG-IKE CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "TIMEOUT (SECONDS)"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        ml3 = "ike timeout"
        CreateIPTextboxes()

        ip1.Location = New Point(495, 178)
        ip2.Location = New Point(ip1.Location.X + ip1.Width, 178)
        ip1.Text = "1"
        ip1.Visible = True
        ip2.Visible = True
        
        d1TB.Text = "ENTER 5 TO 30"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        HelperUpdate()
    End Sub

    Private Sub TcpAccelConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..IPV4 CONFIG-TCP ACCEL CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "TCP ACCEL CONFIG"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "ENABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "tcp accel config"
        HelperUpdate()
    End Sub

    Private Sub RedEthernetPort()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..-NETWORK-RED ETHERNET CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "RED ETHERNET PORT"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "BUILT IN"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "red ethernet port"
        HelperUpdate()
    End Sub

    Private Sub RedPingReply()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..-IPV4 CONFIG-RED ICMP CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "RED PING REPLY"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "DISABLED"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "red ping reply"
        HelperUpdate()
    End Sub

    Private Sub MaxRetransAttempts()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "..TWORK-IPV4 CONFIG-IKE CONFIG"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "MAX RETRANS ATTEMPTS"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        ml3 = "max retrans attempts"
        CreateIPTextboxes()

        ip1.Location = New Point(495, 178)
        ip2.Location = New Point(ip1.Location.X + ip1.Width, 178)
        ip1.Text = "0"
        ip2.Text = "5"
        ip1.Visible = True
        ip2.Visible = True

        d1TB.Text = "ENTER 0 TO 10"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        HelperUpdate()
    End Sub

    Private Sub PortJ3()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-PORTS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "PORT J3"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = "ASCII"
        SetWidth(c1TB)
        CenterMe(c1TB)
        c1TB.Visible = True



        d1TB.Text = "ENT TO CONTINUE/CLR TO EXIT"
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True

        ml3 = "port j3"
        HelperUpdate()
    End Sub

    Private Sub RetransmitConfig()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = "PGM-RADIO-GENERAL-RETRANS"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
        b1TB.Text = "RETRANSMIT ANALOG"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True
        c1TB.Text = "ON"
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True
        ShowToScrollEntToCont()
        d1TB.Visible = True
        ml3 = "retransmit config"
        HelperUpdate()
    End Sub

    'Private Sub SAconfig()
    '    DisplayReset()
    '    SetVisibilityOFF()
    '    showRowA()
    '    a1TB.Visible = True
    '    a1TB.Text = "PGM-RADIO-GENERAL-SA"
    '    SetWidth(a1TB)
    '    a1TB.TextAlign = HorizontalAlignment.Left
    '    a2TB.Visible = False
    '    a3PB.Visible = False
    '    a4TB.Visible = False
    '    a5TB.Visible = False
    '    a6TB.Visible = False
    '    a7TB.Visible = False


    '    b1TB.Text = "COMBAT ID"
    '    b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
    '    b1TB.BackColor = Color.Black
    '    b1TB.ForeColor = Color.MediumSeaGreen
    '    b1TB.Visible = True

    '    c1TB.Text = "SA NAME"
    '    c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
    '    c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
    '    c1TB.Visible = True

    '    d1TB.Text = "VULOS SA CONFIG"
    '    d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
    '    d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
    '    d1TB.Visible = True



    '    b7PB.Width = 11
    '    b7PB.Height = 44
    '    b7PB.Location = New Point(612, 161)
    '    b7PB.Visible = True



    '    NewScrollbar(2)
    '    JustificationAndSetWidth()

    '    ml3 = "sa config menu"
    '    ml4 = ""

    '    HelperUpdate()
    'End Sub

    Private Sub SAconfig()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA") 'creates the first row

        CreateNewScrollingMenu("COMBAT ID", "SA NAME", "VULOS SA CONFIG") 'works with up to 11 items and creates scrollbar
        ml3 = "sa config menu"
        ml4 = ""

        HelperUpdate()
    End Sub

    Private Sub CreateNewScrollingMenu(i1 As String, i2 As String, Optional i3 As String = "", Optional i4 As String = "", Optional i5 As String = "", Optional i6 As String = "", Optional i7 As String = "", Optional i8 As String = "", Optional i9 As String = "", Optional i10 As String = "", Optional i11 As String = "", Optional i12 As String = "")
        b1TB.Text = i1
        b1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        b1TB.BackColor = Color.Black
        b1TB.ForeColor = Color.MediumSeaGreen
        b1TB.Visible = True

        c1TB.Text = i2
        c1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        c1TB.Location = New Point(b1TB.Location.X, c1TB.Location.Y - 3)
        c1TB.Visible = True

        d1TB.Text = i3
        d1TB.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        d1TB.Location = New Point(b1TB.Location.X, d1TB.Location.Y - 6)
        d1TB.Visible = True



        b7PB.Width = 11
        b7PB.Height = 44
        b7PB.Location = New Point(612, 161)
        b7PB.Visible = True

        menuChoices = "data port config"
        SelectNewMenu(i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12)
        MeasureArray()

        NewScrollbar(xHi)
        JustificationAndSetWidth()
    End Sub

    Private Sub SelectNewMenu(i1 As String, i2 As String, Optional i3 As String = "", Optional i4 As String = "", Optional i5 As String = "", Optional i6 As String = "", Optional i7 As String = "", Optional i8 As String = "", Optional i9 As String = "", Optional i10 As String = "", Optional i11 As String = "", Optional i12 As String = "")
        menuItems(0, 0) = ""
        menuItems(0, 1) = ""
        menuItems(0, 2) = ""
        menuItems(0, 3) = ""
        menuItems(0, 4) = ""
        menuItems(0, 5) = ""
        menuItems(0, 6) = ""
        menuItems(0, 7) = ""
        menuItems(0, 8) = ""
        menuItems(0, 9) = ""
        menuItems(0, 10) = ""
        menuItems(0, 11) = ""

        menuItems(0, 0) = i1
        menuItems(0, 1) = i2
        menuItems(0, 2) = i3
        menuItems(0, 3) = i4
        menuItems(0, 4) = i5
        menuItems(0, 5) = i6
        menuItems(0, 6) = i7
        menuItems(0, 7) = i8
        menuItems(0, 8) = i9
        menuItems(0, 9) = i10
        menuItems(0, 10) = i11
        menuItems(0, 11) = i12


        xHi = 15
        xCurrent = 0
    End Sub

    Private Function ScrollingNewMenu() As Boolean
        Dim result As Boolean = False

        If b7PB.Visible = False Then
            Return result
        End If

        If ml3 = "sa config menu" Or ml3 = "radio system clock" Or ml3 = "selective zero" Or ml1 = "main zeroize menu" Or (ml1 = "program" And ml2 = "" And ml3 = "") Then



            If direction = "down" Then
                If b1TB.BackColor = Color.Black Then
                    c1TB.BackColor = Color.Black
                    c1TB.ForeColor = Color.MediumSeaGreen
                    b1TB.BackColor = Color.MediumSeaGreen
                    b1TB.ForeColor = Color.Black

                ElseIf c1TB.BackColor = Color.Black Then
                    d1TB.BackColor = Color.Black
                    d1TB.ForeColor = Color.MediumSeaGreen
                    c1TB.BackColor = Color.MediumSeaGreen
                    c1TB.ForeColor = Color.Black

                Else
                    If d1TB.Text <> menuItems(0, xHi) Then 'stops the process when the end of the list is reached
                        b1TB.Text = c1TB.Text
                        c1TB.Text = d1TB.Text
                        d1TB.Text = menuItems(0, xCurrent + 1)

                    End If
                End If
            ElseIf direction = "up" Then
                If d1TB.BackColor = Color.Black Then
                    c1TB.BackColor = Color.Black
                    c1TB.ForeColor = Color.MediumSeaGreen
                    d1TB.BackColor = Color.MediumSeaGreen
                    d1TB.ForeColor = Color.Black

                ElseIf c1TB.BackColor = Color.Black Then
                    b1TB.BackColor = Color.Black
                    b1TB.ForeColor = Color.MediumSeaGreen
                    c1TB.BackColor = Color.MediumSeaGreen
                    c1TB.ForeColor = Color.Black

                Else
                    If b1TB.Text <> menuItems(0, 0) Then 'stops the process when the end of the list is reached
                        d1TB.Text = c1TB.Text
                        c1TB.Text = b1TB.Text
                        Try
                            b1TB.Text = menuItems(0, xCurrent - 1)
                        Catch
                        End Try

                    End If
                End If
            End If
            JustificationAndSetWidth()
            MeasureArray()
            NewScrollbarMovement(xHi, xCurrent)
            result = True

        End If
        Return result
    End Function

    Private Sub NewScrollbarMovement(xHi As Integer, xCurrent As Integer)
        Dim tabLoc As Integer 'represent the location of the scrollbar tab
        Dim tabStep As Integer

        If xHi <= 2 Then
            Exit Sub
        Else
            If xHi = 3 Then
                tabStep = 18 / xHi
            ElseIf xHi = 4 Then
                tabStep = 20 / xHi
            ElseIf xHi = 5 Then
                tabStep = 20 / xHi
            ElseIf xHi = 6 Then
                tabStep = 20 / xHi
            ElseIf xHi = 7 Then
                tabStep = 21 / xHi
            ElseIf xHi = 8 Then
                tabStep = 22 / xHi
            ElseIf xHi = 9 Then
                tabStep = 23 / xHi
            ElseIf xHi = 10 Then
                tabStep = 24 / xHi
            ElseIf xHi = 11 Then
                tabStep = 25 / xHi
            End If

        End If

        Dim start As Integer = 0

        
        start = (tabStep * (xCurrent - 1))


        tabLoc = 173 + start


        b7PB.BackgroundImage = My.Resources.scrollbarNull
        b7PB.BackgroundImageLayout = ImageLayout.Stretch
        b6PB.BackgroundImage = My.Resources.BlackBackground
        b6PB.BackgroundImageLayout = ImageLayout.Stretch
        b6PB.Width = 9

        b6PB.Location = New Point((b7PB.Location.X + 1), tabLoc) '(b7PB.Location.Y + 7)) + (b6PB.Height * (xCurrent - 1))
        b6PB.Visible = True
    End Sub

    Private Sub BuildMenuPageRowA(ByRef i As String)
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = i
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False
    End Sub

    Private Sub CombatID()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-COMBAT ID")
        CreateStandardPageWithDigits("COMBAT ID", 6, "ENTER CID FROM 000001-524000")
        ip5.Text = "9"
        ip6.Text = "3"
        ml3 = "combat id"
        HelperUpdate()
    End Sub

    Private Sub CreateStandardPageWithDigits(p1 As String, p2 As Integer, p3 As String)
        b1TB.Text = p1
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        CreateDigitBoxes(p2) 'creates up to 15 digit boxes

        d1TB.Text = p3
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True
    End Sub





    Private Sub CreateDigitBoxes(p2 As Integer)

        Dim myWidth As Integer


        ip1.Visible = False
        Me.Controls.Add(ip1)
        ip1.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip1.TextAlign = HorizontalAlignment.Center
        ip1.Text = "0"
        ip1.Size = New Size(12, 19)
        ip1.ForeColor = Color.MediumSeaGreen
        ip1.BackColor = Color.Black
        ip1.BorderStyle = BorderStyle.None
        ip1.Visible = True
        ip1.BringToFront()

        If p2 = 1 Then
            ip1.Location = New Point(c1TB.Location.X, c1TB.Location.Y)
            CenterMe(ip1)
            Exit Sub
        End If

        ip2.Visible = False
        Me.Controls.Add(ip2)
        ip2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip2.TextAlign = HorizontalAlignment.Center
        ip2.Text = "0"
        ip2.Size = New Size(12, 19)
        ip2.BackColor = Color.MediumSeaGreen
        ip2.ForeColor = Color.Black
        ip2.BorderStyle = BorderStyle.None
        ip2.Visible = True
        ip2.BringToFront()

        If p2 = 2 Then
            myWidth = ip1.Width + ip2.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip3.Visible = False
        Me.Controls.Add(ip3)
        ip3.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip3.TextAlign = HorizontalAlignment.Center
        ip3.Text = "0"
        ip3.Size = New Size(12, 19)
        ip3.BackColor = Color.MediumSeaGreen
        ip3.ForeColor = Color.Black
        ip3.BorderStyle = BorderStyle.None
        ip3.Visible = True
        ip3.BringToFront()

        If p2 = 3 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip4.Visible = False
        Me.Controls.Add(ip4)
        ip4.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip4.TextAlign = HorizontalAlignment.Center
        ip4.Text = "0"
        ip4.Size = New Size(12, 19)
        ip4.BackColor = Color.MediumSeaGreen
        ip4.ForeColor = Color.Black
        ip4.BorderStyle = BorderStyle.None
        ip4.Visible = True
        ip4.BringToFront()

        If p2 = 4 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip5.Visible = False
        Me.Controls.Add(ip5)
        ip5.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip5.TextAlign = HorizontalAlignment.Center
        ip5.Text = "0"
        ip5.Size = New Size(12, 19)
        ip5.BackColor = Color.MediumSeaGreen
        ip5.ForeColor = Color.Black
        ip5.BorderStyle = BorderStyle.None
        ip5.Visible = True
        ip5.BringToFront()

        If p2 = 5 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip6.Visible = False
        Me.Controls.Add(ip6)
        ip6.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip6.TextAlign = HorizontalAlignment.Center
        ip6.Text = "0"
        ip6.Size = New Size(12, 19)
        ip6.BackColor = Color.MediumSeaGreen
        ip6.ForeColor = Color.Black
        ip6.BorderStyle = BorderStyle.None
        ip6.Visible = True
        ip6.BringToFront()

        If p2 = 6 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip7.Visible = False
        Me.Controls.Add(ip7)
        ip7.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip7.TextAlign = HorizontalAlignment.Center
        ip7.Text = "0"
        ip7.Size = New Size(12, 19)
        ip7.BackColor = Color.MediumSeaGreen
        ip7.ForeColor = Color.Black
        ip7.BorderStyle = BorderStyle.None
        ip7.Visible = True
        ip7.BringToFront()

        If p2 = 7 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width + ip7.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            ip7.Location = New Point(ip6.Location.X + ip6.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip8.Visible = False
        Me.Controls.Add(ip8)
        ip8.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip8.TextAlign = HorizontalAlignment.Center
        ip8.Text = "0"
        ip8.Size = New Size(12, 19)
        ip8.BackColor = Color.MediumSeaGreen
        ip8.ForeColor = Color.Black
        ip8.BorderStyle = BorderStyle.None
        ip8.Visible = True
        ip8.BringToFront()

        If p2 = 8 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width + ip7.Width + ip8.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            ip7.Location = New Point(ip6.Location.X + ip6.Width, c1TB.Location.Y)
            ip8.Location = New Point(ip7.Location.X + ip7.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip9.Visible = False
        Me.Controls.Add(ip9)
        ip9.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip9.TextAlign = HorizontalAlignment.Center
        ip9.Text = "0"
        ip9.Size = New Size(12, 19)
        ip9.BackColor = Color.MediumSeaGreen
        ip9.ForeColor = Color.Black
        ip9.BorderStyle = BorderStyle.None
        ip9.Visible = True
        ip9.BringToFront()

        If p2 = 9 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width + ip7.Width + ip8.Width + ip9.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            ip7.Location = New Point(ip6.Location.X + ip6.Width, c1TB.Location.Y)
            ip8.Location = New Point(ip7.Location.X + ip7.Width, c1TB.Location.Y)
            ip9.Location = New Point(ip8.Location.X + ip8.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip10.Visible = False
        Me.Controls.Add(ip10)
        ip10.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip10.TextAlign = HorizontalAlignment.Center
        ip10.Text = "0"
        ip10.Size = New Size(12, 19)
        ip10.BackColor = Color.MediumSeaGreen
        ip10.ForeColor = Color.Black
        ip10.BorderStyle = BorderStyle.None
        ip10.Visible = True
        ip10.BringToFront()

        If p2 = 10 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width + ip7.Width + ip8.Width + ip9.Width + ip10.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            ip7.Location = New Point(ip6.Location.X + ip6.Width, c1TB.Location.Y)
            ip8.Location = New Point(ip7.Location.X + ip7.Width, c1TB.Location.Y)
            ip9.Location = New Point(ip8.Location.X + ip8.Width, c1TB.Location.Y)
            ip10.Location = New Point(ip9.Location.X + ip9.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip11.Visible = False
        Me.Controls.Add(ip11)
        ip11.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip11.TextAlign = HorizontalAlignment.Center
        ip11.Text = "0"
        ip11.Size = New Size(12, 19)
        ip11.BackColor = Color.MediumSeaGreen
        ip11.ForeColor = Color.Black
        ip11.BorderStyle = BorderStyle.None
        ip11.Visible = True
        ip11.BringToFront()

        If p2 = 11 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width + ip7.Width + ip8.Width + ip9.Width + ip10.Width + ip11.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            ip7.Location = New Point(ip6.Location.X + ip6.Width, c1TB.Location.Y)
            ip8.Location = New Point(ip7.Location.X + ip7.Width, c1TB.Location.Y)
            ip9.Location = New Point(ip8.Location.X + ip8.Width, c1TB.Location.Y)
            ip10.Location = New Point(ip9.Location.X + ip9.Width, c1TB.Location.Y)
            ip11.Location = New Point(ip10.Location.X + ip10.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip12.Visible = False
        Me.Controls.Add(ip12)
        ip12.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip12.TextAlign = HorizontalAlignment.Center
        ip12.Text = "."
        ip12.Size = New Size(12, 19)
        ip12.BackColor = Color.MediumSeaGreen
        ip12.ForeColor = Color.Black
        ip12.BorderStyle = BorderStyle.None
        ip12.Visible = True
        ip12.BringToFront()

        If p2 = 12 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width + ip7.Width + ip8.Width + ip9.Width + ip10.Width + ip11.Width + ip12.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            ip7.Location = New Point(ip6.Location.X + ip6.Width, c1TB.Location.Y)
            ip8.Location = New Point(ip7.Location.X + ip7.Width, c1TB.Location.Y)
            ip9.Location = New Point(ip8.Location.X + ip8.Width, c1TB.Location.Y)
            ip10.Location = New Point(ip9.Location.X + ip9.Width, c1TB.Location.Y)
            ip11.Location = New Point(ip10.Location.X + ip10.Width, c1TB.Location.Y)
            ip12.Location = New Point(ip11.Location.X + ip11.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip13.Visible = False
        Me.Controls.Add(ip13)
        ip13.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip13.TextAlign = HorizontalAlignment.Center
        ip13.Text = "0"
        ip13.Size = New Size(12, 19)
        ip13.BackColor = Color.MediumSeaGreen
        ip13.ForeColor = Color.Black
        ip13.BorderStyle = BorderStyle.None
        ip13.Visible = True
        ip13.BringToFront()

        If p2 = 13 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width + ip7.Width + ip8.Width + ip9.Width + ip10.Width + ip11.Width + ip12.Width + ip13.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            ip7.Location = New Point(ip6.Location.X + ip6.Width, c1TB.Location.Y)
            ip8.Location = New Point(ip7.Location.X + ip7.Width, c1TB.Location.Y)
            ip9.Location = New Point(ip8.Location.X + ip8.Width, c1TB.Location.Y)
            ip10.Location = New Point(ip9.Location.X + ip9.Width, c1TB.Location.Y)
            ip11.Location = New Point(ip10.Location.X + ip10.Width, c1TB.Location.Y)
            ip12.Location = New Point(ip11.Location.X + ip11.Width, c1TB.Location.Y)
            ip13.Location = New Point(ip12.Location.X + ip12.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip14.Visible = False
        Me.Controls.Add(ip14)
        ip14.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip14.TextAlign = HorizontalAlignment.Center
        ip14.Text = "0"
        ip14.Size = New Size(12, 19)
        ip14.BackColor = Color.MediumSeaGreen
        ip14.ForeColor = Color.Black
        ip14.BorderStyle = BorderStyle.None
        ip14.Visible = True
        ip14.BringToFront()

        If p2 = 14 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width + ip7.Width + ip8.Width + ip9.Width + ip10.Width + ip11.Width + ip12.Width + ip13.Width + ip14.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            ip7.Location = New Point(ip6.Location.X + ip6.Width, c1TB.Location.Y)
            ip8.Location = New Point(ip7.Location.X + ip7.Width, c1TB.Location.Y)
            ip9.Location = New Point(ip8.Location.X + ip8.Width, c1TB.Location.Y)
            ip10.Location = New Point(ip9.Location.X + ip9.Width, c1TB.Location.Y)
            ip11.Location = New Point(ip10.Location.X + ip10.Width, c1TB.Location.Y)
            ip12.Location = New Point(ip11.Location.X + ip11.Width, c1TB.Location.Y)
            ip13.Location = New Point(ip12.Location.X + ip12.Width, c1TB.Location.Y)
            ip14.Location = New Point(ip13.Location.X + ip13.Width, c1TB.Location.Y)
            Exit Sub
        End If

        ip15.Visible = False
        Me.Controls.Add(ip15)
        ip15.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        ip15.TextAlign = HorizontalAlignment.Center
        ip15.Text = "0"
        ip15.Size = New Size(12, 19)
        ip15.BackColor = Color.MediumSeaGreen
        ip15.ForeColor = Color.Black
        ip15.BorderStyle = BorderStyle.None
        ip15.Visible = True
        ip15.BringToFront()

        If p2 = 15 Then
            myWidth = ip1.Width + ip2.Width + ip3.Width + ip4.Width + ip5.Width + ip6.Width + ip7.Width + ip8.Width + ip9.Width + ip10.Width + ip11.Width + ip12.Width + ip13.Width + ip14.Width + ip15.Width
            ip1.Location = New Point(510 - (myWidth / 2), c1TB.Location.Y)
            ip2.Location = New Point(ip1.Location.X + ip1.Width, c1TB.Location.Y)
            ip3.Location = New Point(ip2.Location.X + ip2.Width, c1TB.Location.Y)
            ip4.Location = New Point(ip3.Location.X + ip3.Width, c1TB.Location.Y)
            ip5.Location = New Point(ip4.Location.X + ip4.Width, c1TB.Location.Y)
            ip6.Location = New Point(ip5.Location.X + ip5.Width, c1TB.Location.Y)
            ip7.Location = New Point(ip6.Location.X + ip6.Width, c1TB.Location.Y)
            ip8.Location = New Point(ip7.Location.X + ip7.Width, c1TB.Location.Y)
            ip9.Location = New Point(ip8.Location.X + ip8.Width, c1TB.Location.Y)
            ip10.Location = New Point(ip9.Location.X + ip9.Width, c1TB.Location.Y)
            ip11.Location = New Point(ip10.Location.X + ip10.Width, c1TB.Location.Y)
            ip12.Location = New Point(ip11.Location.X + ip11.Width, c1TB.Location.Y)
            ip13.Location = New Point(ip12.Location.X + ip12.Width, c1TB.Location.Y)
            ip14.Location = New Point(ip13.Location.X + ip13.Width, c1TB.Location.Y)
            ip15.Location = New Point(ip14.Location.X + ip14.Width, c1TB.Location.Y)

            Exit Sub
        End If


    End Sub

    Private Function TransitionIPboxes() As Boolean
        Dim result As Boolean = False

        If ml3 = "combat id" Or ml3 = "zeroize waveform" Or ml3 = "enter utc offset" Or ml3 = "system current date" Or ml3 = "system clock current time" Or ml3 = "cot expiration" Or ml3 = "sa custom ip" Or ml3 = "sa port" And ip1.Visible = True Then
            If direction = "right" Then
                If ip1.BackColor = Color.Black And ip2.Visible = True And ip2.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip2)
                    SetBackGreen(ip1)

                ElseIf ip2.BackColor = Color.Black And ip3.Visible = True And ip3.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "system clock current time" Or ml3 = "system current date" Then 'used to format time or date
                        SetBackBlack(ip4)
                        SetBackGreen(ip2)
                    Else
                        SetBackBlack(ip3)
                        SetBackGreen(ip2)
                    End If

                ElseIf ip3.BackColor = Color.Black And ip4.Visible = True And ip4.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "sa custom ip" Or ml3 = "enter utc offset" Then 'used to format ip addresses or UTC offset
                        SetBackBlack(ip5)
                        SetBackGreen(ip3)
                    Else
                        SetBackBlack(ip4)
                        SetBackGreen(ip3)
                    End If

                ElseIf ip4.BackColor = Color.Black And ip5.Visible = True And ip5.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip5)
                    SetBackGreen(ip4)

                ElseIf ip5.BackColor = Color.Black And ip6.Visible = True And ip6.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "system clock current time" Or ml3 = "system current date" Then 'used to format time or date
                        SetBackBlack(ip7)
                        SetBackGreen(ip5)
                    Else
                        SetBackBlack(ip6)
                        SetBackGreen(ip5)
                    End If

                ElseIf ip6.BackColor = Color.Black And ip7.Visible = True And ip7.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip7)
                    SetBackGreen(ip6)

                ElseIf ip7.BackColor = Color.Black And ip8.Visible = True And ip8.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "sa custom ip" Then 'used to format ip addresses
                        SetBackBlack(ip9)
                        SetBackGreen(ip7)
                    Else
                        SetBackBlack(ip8)
                        SetBackGreen(ip7)
                    End If

                ElseIf ip8.BackColor = Color.Black And ip9.Visible = True And ip9.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip9)
                    SetBackGreen(ip8)

                ElseIf ip9.BackColor = Color.Black And ip10.Visible = True And ip10.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip10)
                    SetBackGreen(ip9)

                ElseIf ip10.BackColor = Color.Black And ip11.Visible = True And ip11.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip11)
                    SetBackGreen(ip10)

                ElseIf ip11.BackColor = Color.Black And ip12.Visible = True And ip12.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "sa custom ip" Then 'used to format ip addresses
                        SetBackBlack(ip13)
                        SetBackGreen(ip11)
                    Else
                        SetBackBlack(ip12)
                        SetBackGreen(ip11)
                    End If

                ElseIf ip12.BackColor = Color.Black And ip13.Visible = True And ip13.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip13)
                    SetBackGreen(ip12)

                ElseIf ip13.BackColor = Color.Black And ip14.Visible = True And ip14.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip14)
                    SetBackGreen(ip13)

                ElseIf ip14.BackColor = Color.Black And ip15.Visible = True And ip15.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip15)
                    SetBackGreen(ip14)

                End If

            ElseIf direction = "left" Then
                If ip15.BackColor = Color.Black And ip14.Visible = True And ip14.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip14)
                    SetBackGreen(ip15)

                ElseIf ip14.BackColor = Color.Black And ip13.Visible = True And ip13.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip13)
                    SetBackGreen(ip14)

                ElseIf ip13.BackColor = Color.Black And ip12.Visible = True And ip12.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "sa custom ip" Then 'used to format ip addresses
                        SetBackBlack(ip11)
                        SetBackGreen(ip13)
                    Else
                        SetBackBlack(ip12)
                        SetBackGreen(ip13)
                    End If


                ElseIf ip12.BackColor = Color.Black And ip11.Visible = True And ip11.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip11)
                    SetBackGreen(ip12)

                ElseIf ip11.BackColor = Color.Black And ip10.Visible = True And ip10.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip10)
                    SetBackGreen(ip11)

                ElseIf ip10.BackColor = Color.Black And ip9.Visible = True And ip9.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip9)
                    SetBackGreen(ip10)

                ElseIf ip9.BackColor = Color.Black And ip8.Visible = True And ip8.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "sa custom ip" Then 'used to format ip addresses
                        SetBackBlack(ip7)
                        SetBackGreen(ip9)
                    Else
                        SetBackBlack(ip8)
                        SetBackGreen(ip9)
                    End If


                ElseIf ip8.BackColor = Color.Black And ip7.Visible = True And ip7.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip7)
                    SetBackGreen(ip8)

                ElseIf ip7.BackColor = Color.Black And ip6.Visible = True And ip6.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "system clock current time" Or ml3 = "system current date" Then 'used to format time or date
                        SetBackBlack(ip5)
                        SetBackGreen(ip7)
                    Else
                        SetBackBlack(ip6)
                        SetBackGreen(ip7)
                    End If

                ElseIf ip6.BackColor = Color.Black And ip5.Visible = True And ip5.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip5)
                    SetBackGreen(ip6)

                ElseIf ip5.BackColor = Color.Black And ip4.Visible = True And ip4.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "sa custom ip" Or ml3 = "enter utc offset" Then 'used to format ip addresses or UTC offset
                        SetBackBlack(ip3)
                        SetBackGreen(ip5)
                    Else
                        SetBackBlack(ip4)
                        SetBackGreen(ip5)
                    End If


                ElseIf ip4.BackColor = Color.Black And ip3.Visible = True And ip3.BackColor = Color.MediumSeaGreen Then
                    If ml3 = "system clock current time" Or ml3 = "system current date" Then 'used to format time or date
                        SetBackBlack(ip2)
                        SetBackGreen(ip4)
                    Else
                        SetBackBlack(ip3)
                        SetBackGreen(ip4)
                    End If

                ElseIf ip3.BackColor = Color.Black And ip2.Visible = True And ip2.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip2)
                    SetBackGreen(ip3)

                ElseIf ip2.BackColor = Color.Black And ip1.Visible = True And ip1.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(ip1)
                    SetBackGreen(ip2)

                End If

            End If

            result = True
        Else
            result = False
        End If

        MyCreateIPboxes()
        Return result
    End Function

    Private Sub SAName()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-SA NAME")
        CreateStandardPageWithNameboxes("SA NAME", 14, "ENTER NAME")
        ml3 = "sa name"
        HelperUpdate()
    End Sub

    Private Sub CreateStandardPageWithNameboxes(p1 As String, p2 As Integer, p3 As String)
        b1TB.Text = p1
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        CreateUpTo14Nameboxes(p2) 'creates up to 14 nameboxes

        d1TB.Text = p3
        SetWidth(d1TB)
        CenterMe(d1TB)
        d1TB.Visible = True
    End Sub

    Private Sub CreateUpTo14Nameboxes(p2 As Integer)
        'sets the location of the textboxes
        Dim vertLoc As Integer
        vertLoc = c1TB.Location.Y

        Dim horzLoc As Integer
        horzLoc = c1TB.Location.X


        If ml3 = "maintenance password" Then
            horzLoc += 60
        End If



        'sets the color of the boxes and show them
        Me.Controls.Add(nameBox1)
        nameBox1.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox1.TextAlign = HorizontalAlignment.Center
        nameBox1.ForeColor = Color.MediumSeaGreen
        nameBox1.BorderStyle = BorderStyle.None
        nameBox1.BackColor = Color.Black
        nameBox1.Width = 10
        nameBox1.Location = New Point(horzLoc, vertLoc)
        nameBox1.Visible = True
        nameBox1.BringToFront()

        If p2 = 1 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox2)
        nameBox2.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox2.TextAlign = HorizontalAlignment.Center
        nameBox2.ForeColor = Color.Black
        nameBox2.BorderStyle = BorderStyle.None
        nameBox2.BackColor = Color.MediumSeaGreen
        nameBox2.Width = 10
        nameBox2.Location = New Point(nameBox1.Location.X + nameBox1.Width, vertLoc)
        nameBox2.Visible = True
        nameBox2.BringToFront()

        If p2 = 2 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox3)
        nameBox3.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox3.TextAlign = HorizontalAlignment.Center
        nameBox3.ForeColor = Color.Black
        nameBox3.BorderStyle = BorderStyle.None
        nameBox3.BackColor = Color.MediumSeaGreen
        nameBox3.Width = 10
        nameBox3.Location = New Point(nameBox2.Location.X + nameBox2.Width, vertLoc)
        nameBox3.Visible = True
        nameBox3.BringToFront()

        If p2 = 3 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox4)
        nameBox4.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox4.TextAlign = HorizontalAlignment.Center
        nameBox4.ForeColor = Color.Black
        nameBox4.BorderStyle = BorderStyle.None
        nameBox4.BackColor = Color.MediumSeaGreen
        nameBox4.Width = 10
        nameBox4.Location = New Point(nameBox3.Location.X + nameBox3.Width, vertLoc)
        nameBox4.Visible = True
        nameBox4.BringToFront()

        If p2 = 4 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox5)
        nameBox5.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox5.TextAlign = HorizontalAlignment.Center
        nameBox5.ForeColor = Color.Black
        nameBox5.BorderStyle = BorderStyle.None
        nameBox5.BackColor = Color.MediumSeaGreen
        nameBox5.Width = 10
        nameBox5.Location = New Point(nameBox4.Location.X + nameBox4.Width, vertLoc)
        nameBox5.Visible = True
        nameBox5.BringToFront()

        If p2 = 5 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox6)
        nameBox6.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox6.TextAlign = HorizontalAlignment.Center
        nameBox6.ForeColor = Color.Black
        nameBox6.BorderStyle = BorderStyle.None
        nameBox6.BackColor = Color.MediumSeaGreen
        nameBox6.Width = 10
        nameBox6.Location = New Point(nameBox5.Location.X + nameBox5.Width, vertLoc)
        nameBox6.Visible = True
        nameBox6.BringToFront()

        If p2 = 6 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox7)
        nameBox7.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox7.TextAlign = HorizontalAlignment.Center
        nameBox7.ForeColor = Color.Black
        nameBox7.BorderStyle = BorderStyle.None
        nameBox7.BackColor = Color.MediumSeaGreen
        nameBox7.Width = 10
        nameBox7.Location = New Point(nameBox6.Location.X + nameBox6.Width, vertLoc)
        nameBox7.Visible = True
        nameBox7.BringToFront()

        If p2 = 7 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox8)
        nameBox8.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox8.TextAlign = HorizontalAlignment.Center
        nameBox8.ForeColor = Color.Black
        nameBox8.BorderStyle = BorderStyle.None
        nameBox8.BackColor = Color.MediumSeaGreen
        nameBox8.Width = 10
        nameBox8.Location = New Point(nameBox7.Location.X + nameBox7.Width, vertLoc)
        nameBox8.Visible = True
        nameBox8.BringToFront()

        If p2 = 8 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox9)
        nameBox9.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox9.TextAlign = HorizontalAlignment.Center
        nameBox9.ForeColor = Color.Black
        nameBox9.BorderStyle = BorderStyle.None
        nameBox9.BackColor = Color.MediumSeaGreen
        nameBox9.Width = 10
        nameBox9.Location = New Point(nameBox8.Location.X + nameBox8.Width, vertLoc)
        nameBox9.Visible = True
        nameBox9.BringToFront()

        If p2 = 9 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox10)
        nameBox10.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox10.TextAlign = HorizontalAlignment.Center
        nameBox10.ForeColor = Color.Black
        nameBox10.BorderStyle = BorderStyle.None
        nameBox10.BackColor = Color.MediumSeaGreen
        nameBox10.Width = 10
        nameBox10.Location = New Point(nameBox9.Location.X + nameBox9.Width, vertLoc)
        nameBox10.Visible = True
        nameBox10.BringToFront()

        If p2 = 10 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox11)
        nameBox11.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox11.TextAlign = HorizontalAlignment.Center
        nameBox11.ForeColor = Color.Black
        nameBox11.BorderStyle = BorderStyle.None
        nameBox11.BackColor = Color.MediumSeaGreen
        nameBox11.Width = 10
        nameBox11.Location = New Point(nameBox10.Location.X + nameBox10.Width, vertLoc)
        nameBox11.Visible = True
        nameBox11.BringToFront()

        If p2 = 11 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox12)
        nameBox12.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox12.TextAlign = HorizontalAlignment.Center
        nameBox12.ForeColor = Color.Black
        nameBox12.BorderStyle = BorderStyle.None
        nameBox12.BackColor = Color.MediumSeaGreen
        nameBox12.Width = 10
        nameBox12.Location = New Point(nameBox11.Location.X + nameBox11.Width, vertLoc)
        nameBox12.Visible = True
        nameBox12.BringToFront()

        If p2 = 12 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox13)
        nameBox13.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox13.TextAlign = HorizontalAlignment.Center
        nameBox13.ForeColor = Color.Black
        nameBox13.BorderStyle = BorderStyle.None
        nameBox13.BackColor = Color.MediumSeaGreen
        nameBox13.Width = 10
        nameBox13.Location = New Point(nameBox12.Location.X + nameBox12.Width, vertLoc)
        nameBox13.Visible = True
        nameBox13.BringToFront()

        If p2 = 13 Then
            Exit Sub
        End If
        Me.Controls.Add(nameBox14)
        nameBox14.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        nameBox14.TextAlign = HorizontalAlignment.Center
        nameBox14.ForeColor = Color.Black
        nameBox14.BorderStyle = BorderStyle.None
        nameBox14.BackColor = Color.MediumSeaGreen
        nameBox14.Width = 10
        nameBox14.Location = New Point(nameBox13.Location.X + nameBox13.Width, vertLoc)
        nameBox14.Visible = True
        nameBox14.BringToFront()
    End Sub

    Private Function TransitionNameboxes() As Boolean
        Dim result As Boolean = False

        If ml3 = "sa name" Or ml3 = "maintenance password" And nameBox1.Visible = True Then
            If direction = "right" Then
                If nameBox1.BackColor = Color.Black And nameBox2.Visible = True And nameBox2.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox2)
                    SetBackGreen(nameBox1)

                ElseIf nameBox2.BackColor = Color.Black And nameBox3.Visible = True And nameBox3.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox3)
                    SetBackGreen(nameBox2)

                ElseIf nameBox3.BackColor = Color.Black And nameBox4.Visible = True And nameBox4.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox4)
                    SetBackGreen(nameBox3)

                ElseIf nameBox4.BackColor = Color.Black And nameBox5.Visible = True And nameBox5.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox5)
                    SetBackGreen(nameBox4)

                ElseIf nameBox5.BackColor = Color.Black And nameBox6.Visible = True And nameBox6.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox6)
                    SetBackGreen(nameBox5)

                ElseIf nameBox6.BackColor = Color.Black And nameBox7.Visible = True And nameBox7.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox7)
                    SetBackGreen(nameBox6)

                ElseIf nameBox7.BackColor = Color.Black And nameBox8.Visible = True And nameBox8.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox8)
                    SetBackGreen(nameBox7)

                ElseIf nameBox8.BackColor = Color.Black And nameBox9.Visible = True And nameBox9.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox9)
                    SetBackGreen(nameBox8)

                ElseIf nameBox9.BackColor = Color.Black And nameBox10.Visible = True And nameBox10.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox10)
                    SetBackGreen(nameBox9)

                ElseIf nameBox10.BackColor = Color.Black And nameBox11.Visible = True And nameBox11.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox11)
                    SetBackGreen(nameBox10)

                ElseIf nameBox11.BackColor = Color.Black And nameBox12.Visible = True And nameBox12.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox12)
                    SetBackGreen(nameBox11)

                ElseIf nameBox12.BackColor = Color.Black And nameBox13.Visible = True And nameBox13.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox13)
                    SetBackGreen(nameBox12)

                ElseIf nameBox13.BackColor = Color.Black And nameBox14.Visible = True And nameBox14.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox14)
                    SetBackGreen(nameBox13)

                End If

            ElseIf direction = "left" Then
                If nameBox14.BackColor = Color.Black And nameBox13.Visible = True And nameBox13.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox13)
                    SetBackGreen(nameBox14)

                ElseIf nameBox13.BackColor = Color.Black And nameBox12.Visible = True And nameBox12.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox12)
                    SetBackGreen(nameBox13)

                ElseIf nameBox12.BackColor = Color.Black And nameBox11.Visible = True And nameBox11.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox11)
                    SetBackGreen(nameBox12)

                ElseIf nameBox11.BackColor = Color.Black And nameBox10.Visible = True And nameBox10.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox10)
                    SetBackGreen(nameBox11)

                ElseIf nameBox10.BackColor = Color.Black And nameBox9.Visible = True And nameBox9.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox9)
                    SetBackGreen(nameBox10)

                ElseIf nameBox9.BackColor = Color.Black And nameBox8.Visible = True And nameBox8.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox8)
                    SetBackGreen(nameBox9)

                ElseIf nameBox8.BackColor = Color.Black And nameBox7.Visible = True And nameBox7.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox7)
                    SetBackGreen(nameBox8)

                ElseIf nameBox7.BackColor = Color.Black And nameBox6.Visible = True And nameBox6.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox6)
                    SetBackGreen(nameBox7)

                ElseIf nameBox6.BackColor = Color.Black And nameBox5.Visible = True And nameBox5.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox5)
                    SetBackGreen(nameBox6)

                ElseIf nameBox5.BackColor = Color.Black And nameBox4.Visible = True And nameBox4.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox4)
                    SetBackGreen(nameBox5)

                ElseIf nameBox4.BackColor = Color.Black And nameBox3.Visible = True And nameBox3.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox3)
                    SetBackGreen(nameBox4)

                ElseIf nameBox3.BackColor = Color.Black And nameBox2.Visible = True And nameBox2.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox2)
                    SetBackGreen(nameBox3)

                ElseIf nameBox2.BackColor = Color.Black And nameBox1.Visible = True And nameBox1.BackColor = Color.MediumSeaGreen Then
                    SetBackBlack(nameBox1)
                    SetBackGreen(nameBox2)

                End If

            End If

            result = True
        Else
            result = False
        End If
        Return result
    End Function

    Private Sub ReportFormat()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-SA NAME")
        StandardShowToScrollPage("REPORT FORMAT", "CID")
        ml3 = "report format"
        HelperUpdate()
    End Sub

    Private Sub StandardShowToScrollPage(p1 As String, p2 As String)
        b1TB.Text = p1
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        c1TB.Text = p2
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True

        ShowToScrollEntToCont()
        d1TB.Visible = True
    End Sub

    Private Sub VULOSsaConfig()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-VULOS")
        StandardShowToScrollPage("SA TRANSMIT MODE", "AUTO")
        ml3 = "vulos sa config"
        HelperUpdate()
    End Sub

    Private Sub SaVulosRange()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-VULOS")
        StandardShowToScrollPage("VULOS VOICE TX ONLY", "30.0000-511.9950")
        SetBackGreen(c1TB)
        d1TB.Text = "PRESS ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "sa vulos range"
        HelperUpdate()
    End Sub

    Private Sub SaReceive()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-VULOS")
        StandardShowToScrollPage("SA RECEIVE", "ON")
        ml3 = "sa receive"
        HelperUpdate()
    End Sub

    Private Sub SaPacketType()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-VULOS")
        StandardShowToScrollPage("SA PACKET TYPE", "HARRIS")
        ml3 = "sa packet type"
        HelperUpdate()
    End Sub

    Private Sub SaDestination()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-VULOS")
        StandardShowToScrollPage("SA DEST IP ADDRESS", "CUSTOM IP")
        ml3 = "sa destination"
        HelperUpdate()
    End Sub

    Private Sub CotExpiration()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-VULOS")
        CreateStandardPageWithDigits("COT EXPIRATION", 5, "ENTER TIME IN MINUTES")
        ip4.Text = "1"
        ml3 = "cot expiration"
        HelperUpdate()
    End Sub

    Private Sub SaDestCustomIP()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-VULOS")
        CreateStandardPageWithDigits("SA DEST IP ADDRESS", 15, "ENTER SA CLIENT IP")
        ip2.Text = "1"
        ip4.Text = "."
        ip8.Text = "."
        ip12.Text = "."
        ip15.Text = "2"
        ml3 = "sa custom ip"
        HelperUpdate()
    End Sub

    Private Sub SaPort()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-VULOS")
        CreateStandardPageWithDigits("SA PORT", 5, "ENTER PORT FROM 00001-65535")
        ip1.Text = "1"
        ip4.Text = "1"
        ip5.Text = "1"
        ml3 = "sa port"
        HelperUpdate()
    End Sub

    Private Sub LocalSaReport()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-SA-VULOS")
        StandardShowToScrollPage("LOCAL SA REPORT", "ON")
        ml3 = "local sa report"
        HelperUpdate()
    End Sub

    Private Sub VPODconfig()
        BuildMenuPageRowA("PGM-RADIO-GENERAL-VPOD")
        StandardShowToScrollPage("VPOD", "VOICE PRIORITY")
        ml3 = "vpod config"
        HelperUpdate()
    End Sub

    Private Sub RadioSystemClock()
        BuildMenuPageRowA("PGM-RADIO-CLOCK")
        CreateNewScrollingMenu("CURRENT TIME", "CURRENT DATE", "UTC OFFSET", "SYSTEM CLOCK CONFIG")
        ml3 = "radio system clock"
        ml4 = ""
        HelperUpdate()
    End Sub

    Private Sub SystemClockCurrentTime()
        BuildMenuPageRowA("PGM-RADIO-CLOCK-TIME")
        CreateStandardPageWithDigits("CURRENT LOCAL TIME", 8, "ENTER 24 HOUR TIME")
        ip3.Text = ":"
        ip6.Text = ":"
        ml3 = "system clock current time"
        HelperUpdate()
    End Sub

    Private Sub SystemCurrentDate()
        BuildMenuPageRowA("PGM-RADIO-CLOCK-DATE")
        CreateStandardPageWithDigits("CURRENT DATE", 8, "ENTER MONTH DAY YEAR")
        ip3.Text = "-"
        ip6.Text = "-"
        ml3 = "system current date"
        HelperUpdate()
    End Sub

    Private Sub EnterUTCoffset()
        BuildMenuPageRowA("PGM-RADIO-CLOCK-UTC")
        CreateStandardPageWithDigits("UTC OFFSET", 6, "ENTER +/-HH:MM/USE UP-DN FOR +/-")
        ip1.Text = "+"
        ip4.Text = ":"
        ml3 = "enter utc offset"
        HelperUpdate()
    End Sub

    Private Sub UtcOffsetMessage()
        BuildMenuPageRowA("PGM-RADIO-CLOCK-UTC")
        StandardShowToScrollPage("UTC OFFSET CHANGES", "DISPLAYED TIME")
        b6PB.Visible = False
        d1TB.Text = "ENT TO CONTINUE / CLR TO EXIT"
        SetWidth(d1TB)
        CenterMe(d1TB)
        SetBackGreen(c1TB)
        ml3 = "utc offset message"
        HelperUpdate()
    End Sub

    Private Sub SystemClockConfig()
        BuildMenuPageRowA("PGM-RADIO-CLOCK-CONFIG")
        StandardShowToScrollPage("DATE FORMAT", "MM-DD-YY")
        ml3 = "date format"
        HelperUpdate()
    End Sub

    Private Sub TimeFormat()
        BuildMenuPageRowA("PGM-RADIO-CLOCK-CONFIG")
        StandardShowToScrollPage("TIME FORMAT", "LOCAL 24-HOUR")
        ml3 = "time format"
        HelperUpdate()
    End Sub

    Private Sub LeapSeconds()
        BuildMenuPageRowA("PGM-RADIO-CLOCK-CONFIG")
        StandardShowToScrollPage("LEAP SECONDS", "14")
        ml3 = "leap seconds"
        HelperUpdate()
    End Sub

    Private Sub ChangeLeapSeconds(ByRef i As String)
        Dim leap As Integer = CInt(i)
        If thisNum = "6" Then
            leap += 1
        ElseIf thisNum = "9" Then
            leap -= 1
        End If
        If leap = 60 Then
            leap = 59
        ElseIf leap = -1 Then
            leap = 0
        End If
        i = CStr(leap)
    End Sub

    Private Sub RadioMaintenance()
        BuildMenuPageRowA("PGM-RADIO-MAINTENANCE")
        CreateNewScrollingMenu("RESET HUB CAPACITY", "RESET FACTORY DEFAULT")
        ml3 = "radio maintenance"
        ml4 = ""
        HelperUpdate()
    End Sub

    Private Sub ResetHubCapacity()
        BuildMenuPageRowA("PGM-RADIO-MAINTENANCE-HUB")
        StandardShowToScrollPage("HUB CAPACITY", "WILL BE RESET")
        SetBackGreen(c1TB)
        d1TB.Text = "ENT TO CONTINUE / CLR TO EXIT"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "reset hub capacity"
        HelperUpdate()
    End Sub

    Private Sub ResetFactoryDefaults()
        BuildMenuPageRowA("PGM-RADIO-MAINTENANCE-FACTORY")
        StandardShowToScrollPage("ALL COMSEC, CONFIG &", "PLANS WILL BE ERASED")
        SetBackGreen(c1TB)
        d1TB.Text = "ENT TO CONTINUE / CLR TO EXIT"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "reset factory defaults"
        HelperUpdate()
    End Sub

    Private Sub MaintenancePassword()
        BuildMenuPageRowA("PGM-RADIO-INSTALL-PASSWORD")
        CreateStandardPageWithNameboxes("ADMIN PASSWORD", 12, "ENTER ALPHANUMERIC PASSWORD")
        nameBox1.Text = "*"
        nameBox2.Text = "*"
        nameBox3.Text = "*"
        nameBox4.Text = "*"
        nameBox5.Text = "*"
        nameBox6.Text = "*"
        nameBox7.Text = "*"
        nameBox8.Text = "*"
        nameBox9.Text = "*"
        nameBox10.Text = "*"
        nameBox11.Text = "*"
        nameBox12.Text = "*"
        MyCreateMyNameboxes()
        ml3 = "maintenance password"
        HelperUpdate()
    End Sub

    Private Function checkNumPushed() As Boolean
        Dim NumPushed As Boolean = False
        If ml3 = "port config ip address" Or ml3 = "zeroize waveform" Or ml3 = "enter utc offset" Or ml3 = "system current date" Or ml3 = "system clock current time" Or ml3 = "sa custom ip" Or ml3 = "sa port" Or ml3 = "cot expiration" Or ml3 = "combat id" Or ml3 = "sa config menu" Or ml3 = "max retrans attempts" Or ml3 = "ike timeout" Or ml3 = "gps sleep cycle" Or ml3 = "port config peer ip address" Or ml3 = "port config gateway address" Or ml3 = "port config subnet mask" Then
            numberPushed = thisNum
            EnterNumber()
            NumPushed = True
        End If
        Return NumPushed
    End Function

    Private Sub ResetHubCapacityConfirm()
        BuildMenuPageRowA("PGM-RADIO-MAINTENANCE-HUB")
        StandardShowToScrollPage("RESET HUB CAPACITY", "NO")
        ml3 = "reset hub capacity confirm"
        HelperUpdate()
    End Sub

    Private Sub HubHasBeenReset()
        BuildMenuPageRowA("PGM-RADIO-MAINTENANCE-HUB")
        StandardShowToScrollPage("HUB CAPACITY", "HAS BEEN RESET")
        SetBackGreen(c1TB)
        d1TB.Text = "PRESS CLR/ENT TO EXIT"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "hub has been reset"
        HelperUpdate()
    End Sub

    Private Sub RestoreDefaultsYesNo()
        BuildMenuPageRowA("PGM-RADIO-MAINTENANCE-FACTORY")
        StandardShowToScrollPage("RESTORE DEFAULTS", "NO")
        ml3 = "restore defaults yes no"
        HelperUpdate()
    End Sub

    Private Sub RestoringDefaults()
        BuildMenuPageRowA("PGM-RADIO-MAINTENANCE-FACTORY")
        StandardShowToScrollPage("**  RESTORING  **", "FACTORY DEFAULTS")
        SetBackGreen(c1TB)
        d1TB.Text = "..  WAIT  .."
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "restoring factory defaults"
        HelperUpdate()
        

        StartTimer1(ml3, True, 3000)
    End Sub

    Private Sub StartTimer1(ml3 As String, p2 As Boolean, p3 As Integer)
        'Setting up a timer
        senderName = ml3  'variable representing the sending sub
        Timer1.Enabled = p2       'enables the timer
        Timer1.Interval = p3      'sets the tick interval to 3 seconds
    End Sub

    Private Sub DefaultsReset()
        BuildMenuPageRowA("PGM-RADIO-MAINTENANCE-FACTORY")
        StandardShowToScrollPage("FACTORY DEFAULTS", "HAVE BEEN RESET")
        SetBackGreen(c1TB)
        d1TB.Text = "PRESS CLR/ENT TO EXIT"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "factory defaults restored"
        HelperUpdate()
    End Sub

    Private Sub RestartingRadio()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("*SOFTWARE CHANGE*", "RESTARTING RADIO")
        SetBackGreen(c1TB)
        d1TB.Text = "..  WAIT  .."
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "factory defaults restored"
        HelperUpdate()

        StartTimer1("restarting radio", True, 9000)
    End Sub

    Private Sub MainZeroizeMenu()

        BuildMenuPageRowA("")
        ml1 = "main zeroize menu"
        ml2 = ""
        ml3 = ""
        ml4 = ""
        CreateNewScrollingMenu("ZEROIZE ALL", "DEACTIVATE MSN PLAN", "SELECTIVE ZEROIZE", "ERASE MISSION PLANS")
        

        HelperUpdate()


    End Sub

    Private Sub VULOSpageRowA()
        'DisplayReset()
        a1TB.Visible = True
        a1TB.Text = "R"
        a2TB.Visible = True
        a2TB.Text = "BAT"
        a3PB.Visible = True
        a4TB.Visible = True
        If storedWaveform = " " Then
            a4TB.Text = "- - -"
        Else
            a4TB.Text = storedWaveform
        End If

        a5TB.Visible = True
        ShowSquelch()

        a6TB.Visible = True
        ShowCrypto()

        'a7TB.Visible = True
    End Sub

    Private Function CheckZeroizeMenu() As Boolean
        Dim result As Boolean = False

        If ml1 = "main zeroize menu" Then
            Dim myHighlight As String = ""
            checkHighlights(myHighlight)


            'start of ZEROIZE ALL submenu
            If myHighlight = "ZEROIZE ALL" Then
                ZeroizeAll()
                result = True
                Return result
                Exit Function
            End If

            If ml3 = "zeroize radio" Then
                If myHighlight = "YES" Then
                    ZeroizeInProgress()
                Else
                    MainZeroizeMenu()
                End If
                result = True
                Return result
                Exit Function
            End If

            If ml3 = "zeroize successful" Or ml3 = "clear plan successful" Then
                MainZeroizeMenu()
                result = True
                Return result
                Exit Function
            End If

            'start of DEACTIVATE MSN PLAN submenu
            If myHighlight = "DEACTIVATE MSN PLAN" Then
                DeactivatePlan()
                result = True
                Return result
                Exit Function
            End If

            If ml3 = "deactivate plan" Then
                If myHighlight = "YES" Then
                    DeactivationInProgress()
                Else
                    MainZeroizeMenu()
                End If
                result = True
                Return result
                Exit Function
            End If

            'START OF erase mission plans
            If myHighlight = "ERASE MISSION PLANS" Then
                EraseMissionPlans()
                result = True
                Return result
                Exit Function
            End If

            'start of selective zeroize submenu
            If myHighlight = "SELECTIVE ZEROIZE" Then
                SelectiveZero()
                result = True
                Return result
                Exit Function
            End If

            If myHighlight = "ZEROIZE WAVEFORM" Then
                ZeroizeWaveform()
                result = True
                Return result
                Exit Function
            End If

            If myHighlight = "ZEROIZE GPS" Then
                ZeroizeGPS()
                result = True
                Return result
                Exit Function
            End If

            If myHighlight = "ZEROIZE HAIPE" Then
                ZeroizeHAIPE()
                result = True
                Return result
                Exit Function
            End If

        End If
        Return result
    End Function

    Private Sub ZeroizeAll()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("ZEROIZE RADIO", "NO")
        ml3 = "zeroize radio"
    End Sub

    Private Function CheckYesNo() As Boolean
        Dim result As Boolean = False
        If ml3 = "scan preset enable" Or ml3 = "erase mission plans" Or ml3 = "confirm zeroize generic" Or ml3 = "zeroize gps" Or ml3 = "confirm zero" Or ml3 = "deactivate plan" Or ml3 = "zeroize radio" Or ml3 = "restore defaults yes no" Or ml3 = "reset hub capacity confirm" Or ml3 = "add another preset" Or ml3 = "confirm remove" Then
            If c1TB.Text = "YES" Then
                c1TB.Text = "NO"
            Else
                c1TB.Text = "YES"
            End If
            SetWidth(c1TB)
            CenterMe(c1TB)
            result = True
        End If
        Return result
    End Function

    Private Sub ZeroizeInProgress()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("* * ZEROIZE * *", "IN PROGRESS")
        SetBackGreen(c1TB)
        d1TB.Text = ". . WAIT . ."
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "zeroize in progress"
        HelperUpdate()

        StartTimer1("zeroize in progress", True, 3000)
    End Sub

    Private Sub ZeroizeSuccessful()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("* * ZEROIZE * *", "SUCCESSFUL")
        SetBackGreen(c1TB)
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "zeroize successful"
        HelperUpdate()
    End Sub

    Private Sub DeactivatePlan()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("DEACTIVATE PLAN", "NO")
        ml3 = "deactivate plan"
    End Sub

    Private Sub DeactivationInProgress()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("* * CLEAR PLAN * *", "IN PROGRESS")
        SetBackGreen(c1TB)
        d1TB.Text = ". . WAIT . ."
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "clear plan in progress"
        HelperUpdate()

        StartTimer1("clear plan in progress", True, 3000)
    End Sub

    Private Sub ClearPlanSuccessful()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("* * CLEAR PLAN * *", "SUCCESSFUL")
        SetBackGreen(c1TB)
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "clear plan successful"
        HelperUpdate()
    End Sub

    Private Sub SelectiveZero()
        BuildMenuPageRowA("")
        CreateNewScrollingMenu("ZEROIZE WAVEFORM", "ZEROIZE GPS", "ZEROIZE HAIPE")
        ml3 = "selective zero"
        ml4 = ""

        HelperUpdate()

    End Sub

    Private Sub ZeroizeWaveform()
        MaintenancePassword()
        ml3 = "zeroize waveform"
        HelperUpdate()
    End Sub

    Private Sub SelectWaveformToZeroize()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("SELECT WAVEFORM", "HAVEQUICKII")
        ml3 = "select waveform to zeroize"
        HelperUpdate()
    End Sub

    Private Function ListCollections(i As String, ByRef j As String, Optional ByRef k As String = "") As Boolean
        Dim result As Boolean = False

        If i = "select waveform to zeroize" Then
            Select Case j
                Case "HAVEQUICKII"
                    j = "HPW"
                Case "HPW"
                    j = "SINCGARS"
                Case "SINCGARS"
                    j = "VULOS"
                Case "VULOS"
                    j = "ANW2"
                Case "ANW2"
                    j = "HAVEQUICKII"

            End Select
            result = True
        ElseIf i = "select zeroize key type" Then
            Select Case j

                Case "HAVEQUICKII"
                    If k = "TEK" Then
                        k = "WOD"
                    ElseIf k = "WOD" Then
                        k = "TRKEK"
                    ElseIf k = "TRKEK" Then
                        k = "TEK"
                    ElseIf k = "" Then
                        k = "TEK"
                    End If

                Case "HPW"
                    If k = "TEK" Then
                        k = "TSK"
                    ElseIf k = "TSK" Then
                        k = "TRKEK"
                    ElseIf k = "TRKEK" Then
                        k = "TEK"
                    ElseIf k = "" Then
                        k = "TEK"
                    End If

                Case "SINCGARS"
                    k = "TEK"

                Case "VULOS"
                    k = "TEK"

                Case "ANW2"
                    If k = "TEK" Then
                        k = "TSK"
                    ElseIf k = "TSK" Then
                        k = "TEK"
                    ElseIf k = "" Then
                        k = "TEK"
                    End If

            End Select
            result = True

        ElseIf i = "selective zeroize crypto mode" Then

            Select Case tempWaveform

                Case "VULOS"
                    If k = "ANDVT" Then
                        k = "VINSON"
                    ElseIf k = "VINSON" Then
                        k = "AES"
                    ElseIf k = "AES" Then
                        k = "FASCINATOR"
                    ElseIf k = "FASCINATOR" Then
                        k = "KG84"
                    ElseIf k = "KG84" Then
                        k = "ANDVT"
                    ElseIf k = "" Then
                        k = "ANDVT"
                    End If

                Case "HAVEQUICKII"
                    k = "VINSON"

                Case "SINCGARS"
                    k = "VINSON"

                Case "HPW"
                    k = "KG84"

                Case "ANW2"
                    k = "ZEROIZE VOICE TEK"




            End Select
            result = True
        End If

        Return result
    End Function

    Private Sub SelectZeroizeKeyType(tempWaveform As String)
        BuildMenuPageRowA("")
        Dim k As String = ""
        ListCollections("select zeroize key type", tempWaveform, k)
        StandardShowToScrollPage("SELECT TYPE", k)
        ml3 = "select zeroize key type"
        HelperUpdate()
    End Sub

    Private Sub ChangeListValue()
        If ml3 = "select zeroize key type" Then
            Dim k As String = c1TB.Text
            ListCollections("select zeroize key type", tempWaveform, k)
            StandardShowToScrollPage("SELECT TYPE", k)
        End If
    End Sub

    Private Sub SelectiveZeroizeCryptoMode()
        ml3 = "selective zeroize crypto mode"
        BuildMenuPageRowA("")
        Dim k As String = c1TB.Text
        ListCollections(ml3, tempWaveform, k)
        StandardShowToScrollPage("SELECT CRYPTO MODE", k)
        HelperUpdate()
    End Sub

    Private Function CheckMyList() As Boolean
        Dim result As Boolean = False
        If ml3 = "selective zeroize crypto mode" Then

            Dim k As String = c1TB.Text
            ListCollections(ml3, tempWaveform, k)
            c1TB.Text = k
            SetWidth(c1TB)
            CenterMe(c1TB)
            result = True
        End If

        Return result
    End Function

    Private Sub ZeroizeTekPage()
        BuildMenuPageRowA("")
        Dim i As String = tempCryptoMode
        If tempCryptoMode = "ZEROIZE VOICE TEK" Then
            i = "VOICE"
        End If
        StandardShowToScrollPage("ZEROIZE " + i + " TEK", "TEK01")
        ml3 = "zeroize tek page"
        HelperUpdate()
    End Sub

    Private Sub ConfirmZero()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("ZEROIZE TEK01", "YES")
        ml3 = "confirm zero"
        HelperUpdate()
    End Sub

    Private Sub ZeroizeSWOD()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("ZEROIZE SWOD", "YES")
        ml3 = "confirm zero"
        HelperUpdate()
    End Sub

    Private Sub ZeroizeTRKEK()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("ZEROIZE TRKEK", "YES")
        ml3 = "confirm zero"
        HelperUpdate()
    End Sub

    Private Sub ZeroizeTSK()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("ZEROIZE TSK", "YES")
        ml3 = "confirm zero"
        HelperUpdate()
    End Sub

    Private Sub ZeroizeGPS()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("ZEROIZE GPS", "YES")
        ml3 = "zeroize gps"
        HelperUpdate()
    End Sub

    Private Sub ZeroizeHAIPE()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("SELECT TYPE", "TEK")
        ml3 = "zeroize haipe"
        HelperUpdate()
    End Sub

    Private Sub ConfirmZeroGeneric(ByRef ml3 As String)
        BuildMenuPageRowA("")
        StandardShowToScrollPage(ml3.ToUpper, "YES")
        ml3 = "confirm zeroize generic"
        HelperUpdate()
    End Sub

    Private Sub EraseMissionPlans()
        BuildMenuPageRowA("")
        ml3 = "erase mission plans"
        StandardShowToScrollPage(ml3.ToUpper, "YES")
        HelperUpdate()
    End Sub

    Private Sub EraseMissionPlanInProgress()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("* * ERASING PLANS * *", "IN PROGRESS")
        SetBackGreen(c1TB)
        d1TB.Text = ". . WAIT . ."
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "erasing plans in progress"
        HelperUpdate()

        StartTimer1(ml3, True, 3000)
    End Sub

    Private Sub ErasingPlansSuccessful()
        BuildMenuPageRowA("")
        StandardShowToScrollPage("* * ERASING PLANS * *", "SUCCESSFUL")
        SetBackGreen(c1TB)
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "erasing plans successful"
        HelperUpdate()
    End Sub

    Private Function AlarmOccurred() As Boolean
        alarm = True
        BuildMenuPageRowA("")
        StandardShowToScrollPage("ALARM OCCURRED", "")
        SetBackGreen(c1TB)
        d1TB.Text = "POWER CYCLE THE RADIO"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "alarm occurred"
        HelperUpdate()
        Return alarm
    End Function

    Private Function ZeroizeAlert() As Boolean
        alarm = False
        a1TB.Visible = True
        a1TB.Width = 250
        a1TB.Location = New Point(385, 144)
        a1TB.TextAlign = HorizontalAlignment.Center
        a1TB.Text = "PRIOR ALERT DETECTED"
        a1TB.BringToFront()
        StandardShowToScrollPage("CRYPTO ALERT", "PANIC ZEROIZE")
        SetBackGreen(c1TB)
        d1TB.Text = "PRESS CLR/ENT TO CONTINUE"
        SetWidth(d1TB)
        CenterMe(d1TB)
        b6PB.Visible = False
        ml3 = "zeroize alert"
        HelperUpdate()
        Return alarm
    End Function

    Public Function ButtonBypass() As Boolean
        Dim result As Boolean = False
        If ml3 = "alarm occurred" Or ml3 = "zeroize alert" Or knobIndex = 0 Or screenReady = False Then
            result = True
        End If
        Return result
    End Function

    Private Sub RXsquelchTypeCDCSS()

        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "RX SQUELCH TYPE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If IsDBNull(DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value) = False Then
            c1TB.Text = DataSetForm.PRCtrainerDataGridView.Item(17, presetRowNum).Value

        End If


        SetWidth(c1TB)
        SetBackBlack(c1TB)
        CenterMe(c1TB)

        ShowToScrollEntToCont()



        c1TB.Visible = True

        d1TB.Visible = True


        ml3 = "rx squelch type cdcss"
        HelperUpdate()

    End Sub

    Private Sub CDCSSrxTone()
        DisplayReset()
        SetVisibilityOFF()
        showRowA()
        a1TB.Visible = True
        a1TB.Text = " .. PRESETS-CFG-" + storedNumber + newWave + "-SQUELCH"
        SetWidth(a1TB)
        a1TB.TextAlign = HorizontalAlignment.Left
        a2TB.Visible = False
        a3PB.Visible = False
        a4TB.Visible = False
        a5TB.Visible = False
        a6TB.Visible = False
        a7TB.Visible = False

        b1TB.Text = "CDCSS RX CODE"
        SetWidth(b1TB)
        CenterMe(b1TB)
        b1TB.Visible = True

        If storedCDCSSrxCode = " " Then
            storedCDCSSrxCode = "023"
        End If
        c1TB.Text = storedCDCSSrxCode
        SetWidth(c1TB)
        CenterMe(c1TB)
        SetBackBlack(c1TB)
        c1TB.Visible = True

        b7PB.BackgroundImage = My.Resources.UpDown
        b7PB.Location = New Point(c4TB.Location.X + c4TB.Width + 2, c4TB.Location.Y + 2)
        b7PB.Size = New Size(10, 15)
        b7PB.Visible = True
        b7PB.BringToFront()


        d3TB.Text = "CDCSS EIA CODE"
        SetWidth(d3TB)
        CenterMe(d3TB)
        d3TB.Visible = True

        ml3 = "cdcss rx code"
        HelperUpdate()
    End Sub

    
    Private Sub VisibilityChanged(sender As Object, e As EventArgs) Handles a1TB.VisibleChanged, a2TB.VisibleChanged, a3PB.VisibleChanged, a4TB.VisibleChanged, a5TB.VisibleChanged, a6TB.VisibleChanged, a7TB.VisibleChanged, b1TB.VisibleChanged, b2TB.VisibleChanged, b6PB.VisibleChanged, b7PB.VisibleChanged, c1TB.VisibleChanged, c3TB.VisibleChanged, c4TB.VisibleChanged, c5TB.VisibleChanged, c7TB.VisibleChanged, d1TB.VisibleChanged, d3TB.VisibleChanged, d4TB.VisibleChanged, d6TB.VisibleChanged, d7TB.VisibleChanged

        kdu.a1TB.Visible = a1TB.Visible
        kdu.a2TB.Visible = a2TB.Visible
        kdu.a3PB.Visible = a3PB.Visible
        kdu.a4TB.Visible = a4TB.Visible
        kdu.a5TB.Visible = a5TB.Visible
        kdu.a6TB.Visible = a6TB.Visible
        kdu.a7TB.Visible = a7TB.Visible

        kdu.b1TB.Visible = b1TB.Visible
        kdu.b2TB.Visible = b2TB.Visible
        kdu.b6PB.Visible = b6PB.Visible
        kdu.b7PB.Visible = b7PB.Visible

        kdu.c1TB.Visible = c1TB.Visible
        kdu.c3TB.Visible = c3TB.Visible
        kdu.c4TB.Visible = c4TB.Visible
        kdu.c5TB.Visible = c5TB.Visible
        kdu.c7TB.Visible = c7TB.Visible

        kdu.d1TB.Visible = d1TB.Visible
        kdu.d3TB.Visible = d3TB.Visible
        kdu.d4TB.Visible = d4TB.Visible
        kdu.d6TB.Visible = d6TB.Visible
        kdu.d7TB.Visible = d7TB.Visible

        kdu.tbBorder1.Visible = tbBorder1.Visible
        kdu.tbBack.Visible = tbBack.Visible
        kdu.tbFront.Visible = tbFront.Visible


    End Sub
   

    Private Sub MyLocationChanged(sender As Object, e As EventArgs) Handles a1TB.LocationChanged, a2TB.LocationChanged, a3PB.LocationChanged, a4TB.LocationChanged, a5TB.LocationChanged, a6TB.LocationChanged, a7TB.LocationChanged, b1TB.LocationChanged, b2TB.LocationChanged, b6PB.LocationChanged, b7PB.LocationChanged, c1TB.LocationChanged, c3TB.LocationChanged, c4TB.LocationChanged, c5TB.LocationChanged, c7TB.LocationChanged, d1TB.LocationChanged, d3TB.LocationChanged, d4TB.LocationChanged, d6TB.LocationChanged, d7TB.LocationChanged

        


        kdu.a1TB.Location = New Point(a1TB.Location.X - xfactor, a1TB.Location.Y - yfactor)
        kdu.a2TB.Location = New Point(a2TB.Location.X - xfactor, a2TB.Location.Y - yfactor)
        kdu.a3PB.Location = New Point(a3PB.Location.X - xfactor, a3PB.Location.Y - yfactor)
        kdu.a4TB.Location = New Point(a4TB.Location.X - xfactor, a4TB.Location.Y - yfactor)
        kdu.a5TB.Location = New Point(a5TB.Location.X - xfactor, a5TB.Location.Y - yfactor)
        kdu.a6TB.Location = New Point(a6TB.Location.X - xfactor, a6TB.Location.Y - yfactor)
        kdu.a7TB.Location = New Point(a7TB.Location.X - xfactor, a7TB.Location.Y - yfactor)

        kdu.b1TB.Location = New Point(b1TB.Location.X - xfactor, b1TB.Location.Y - yfactor)
        kdu.b2TB.Location = New Point(b2TB.Location.X - xfactor, b2TB.Location.Y - yfactor)
        kdu.b6PB.Location = New Point(b6PB.Location.X - xfactor, b6PB.Location.Y - yfactor)
        kdu.b7PB.Location = New Point(b7PB.Location.X - xfactor, b7PB.Location.Y - yfactor)

        

        kdu.c1TB.Location = New Point(c1TB.Location.X - xfactor, c1TB.Location.Y - yfactor)
        kdu.c3TB.Location = New Point(c3TB.Location.X - xfactor, c3TB.Location.Y - yfactor)
        kdu.c4TB.Location = New Point(c4TB.Location.X - xfactor, c4TB.Location.Y - yfactor)
        kdu.c5TB.Location = New Point(c5TB.Location.X - xfactor, c5TB.Location.Y - yfactor)
        kdu.c7TB.Location = New Point(c7TB.Location.X - xfactor, c7TB.Location.Y - yfactor)

        kdu.d1TB.Location = New Point(d1TB.Location.X - xfactor, d1TB.Location.Y - yfactor)
        kdu.d3TB.Location = New Point(d3TB.Location.X - xfactor, d3TB.Location.Y - yfactor)
        kdu.d4TB.Location = New Point(d4TB.Location.X - xfactor, d4TB.Location.Y - yfactor)
        kdu.d6TB.Location = New Point(d6TB.Location.X - xfactor, d6TB.Location.Y - yfactor)
        kdu.d7TB.Location = New Point(d7TB.Location.X - xfactor, d7TB.Location.Y - yfactor)

        kdu.tbBorder1.Location = New Point(tbBorder1.Location.X - xfactor, tbBorder1.Location.Y - yfactor)
        kdu.tbBack.Location = New Point(tbBack.Location.X - xfactor, tbBack.Location.Y - yfactor)
        kdu.tbFront.Location = New Point(tbFront.Location.X - xfactor, tbFront.Location.Y - yfactor)

        
    End Sub

    Private Sub MySizeChanged(sender As Object, e As EventArgs) Handles a1TB.SizeChanged, a2TB.SizeChanged, a3PB.SizeChanged, a4TB.SizeChanged, a5TB.SizeChanged, a6TB.SizeChanged, a7TB.SizeChanged, b1TB.SizeChanged, b2TB.SizeChanged, b6PB.SizeChanged, b7PB.SizeChanged, c1TB.SizeChanged, c3TB.SizeChanged, c4TB.SizeChanged, c5TB.SizeChanged, c7TB.SizeChanged, d1TB.SizeChanged, d3TB.SizeChanged, d4TB.SizeChanged, d6TB.SizeChanged, d7TB.SizeChanged

        kdu.a1TB.Size = a1TB.Size
        kdu.a2TB.Size = a2TB.Size
        kdu.a3PB.Size = a3PB.Size
        kdu.a4TB.Size = a4TB.Size
        kdu.a5TB.Size = a5TB.Size
        kdu.a6TB.Size = a6TB.Size
        kdu.a7TB.Size = a7TB.Size

        kdu.b1TB.Size = b1TB.Size
        kdu.b2TB.Size = b2TB.Size
        kdu.b6PB.Size = b6PB.Size
        kdu.b7PB.Size = b7PB.Size

        kdu.c1TB.Size = c1TB.Size
        kdu.c3TB.Size = c3TB.Size
        kdu.c4TB.Size = c4TB.Size
        kdu.c5TB.Size = c5TB.Size
        kdu.c7TB.Size = c7TB.Size

        kdu.d1TB.Size = d1TB.Size
        kdu.d3TB.Size = d3TB.Size
        kdu.d4TB.Size = d4TB.Size
        kdu.d6TB.Size = d6TB.Size
        kdu.d7TB.Size = d7TB.Size

        kdu.tbBorder1.Size = tbBorder1.Size
        kdu.tbBack.Size = tbBack.Size
        kdu.tbFront.Size = tbFront.Size


        MyImageUpdated()

    End Sub

    Private Sub MyTextChanged(sender As Object, e As EventArgs) Handles a1TB.TextChanged, a2TB.TextChanged, a3PB.TextChanged, a4TB.TextChanged, a5TB.TextChanged, a6TB.TextChanged, a7TB.TextChanged, b1TB.TextChanged, b2TB.TextChanged, b6PB.TextChanged, b7PB.TextChanged, c1TB.TextChanged, c3TB.TextChanged, c4TB.TextChanged, c5TB.TextChanged, c7TB.TextChanged, d1TB.TextChanged, d3TB.TextChanged, d4TB.TextChanged, d6TB.TextChanged, d7TB.TextChanged

        kdu.a1TB.Text = a1TB.Text
        kdu.a2TB.Text = a2TB.Text
        kdu.a3PB.Text = a3PB.Text
        kdu.a4TB.Text = a4TB.Text
        kdu.a5TB.Text = a5TB.Text
        kdu.a6TB.Text = a6TB.Text
        kdu.a7TB.Text = a7TB.Text

        kdu.b1TB.Text = b1TB.Text
        kdu.b2TB.Text = b2TB.Text
        kdu.b2TB.BringToFront() 'something was hiding the beginning of the RX freq on VULOS page 2 of the KDU. This corrected the issue.
        kdu.b6PB.Text = b6PB.Text
        kdu.b7PB.Text = b7PB.Text

        kdu.c1TB.Text = c1TB.Text
        kdu.c3TB.Text = c3TB.Text
        kdu.c3TB.BringToFront() 'something was hiding the beginning of the TX freq on VULOS page 2 of the KDU. This corrected the issue.
        kdu.c4TB.Text = c4TB.Text
        kdu.c5TB.Text = c5TB.Text
        kdu.c7TB.Text = c7TB.Text

        kdu.d1TB.Text = d1TB.Text
        kdu.d3TB.Text = d3TB.Text
        kdu.d4TB.Text = d4TB.Text
        kdu.d6TB.Text = d6TB.Text
        kdu.d7TB.Text = d7TB.Text

        MyImageUpdated()
        MyCreateMyNameboxes()

    End Sub

    Private Sub MyFontChanged(sender As Object, e As EventArgs) Handles a1TB.FontChanged, a2TB.FontChanged, a4TB.FontChanged, a5TB.FontChanged, a6TB.FontChanged, a7TB.FontChanged, b1TB.FontChanged, b2TB.FontChanged, c1TB.FontChanged, c3TB.FontChanged, c4TB.FontChanged, c5TB.FontChanged, c7TB.FontChanged, d1TB.FontChanged, d3TB.FontChanged, d4TB.FontChanged, d6TB.FontChanged, d7TB.FontChanged

        kdu.a1TB.Font = a1TB.Font
        kdu.a2TB.Font = a2TB.Font
        kdu.a4TB.Font = a4TB.Font
        kdu.a5TB.Font = a5TB.Font
        kdu.a6TB.Font = a6TB.Font
        kdu.a7TB.Font = a7TB.Font

        kdu.b1TB.Font = b1TB.Font
        kdu.b2TB.Font = b2TB.Font

        kdu.c1TB.Font = c1TB.Font
        kdu.c3TB.Font = c3TB.Font
        kdu.c4TB.Font = c4TB.Font
        kdu.c5TB.Font = c5TB.Font
        kdu.c7TB.Font = c7TB.Font

        kdu.d1TB.Font = d1TB.Font
        kdu.d3TB.Font = d3TB.Font
        kdu.d4TB.Font = d4TB.Font
        kdu.d6TB.Font = d6TB.Font
        kdu.d7TB.Font = d7TB.Font

    End Sub


    Private Sub MyBackAndForeColorChanged(sender As Object, e As EventArgs) Handles a1TB.ForeColorChanged, a2TB.ForeColorChanged, a3PB.ForeColorChanged, a4TB.ForeColorChanged, a5TB.ForeColorChanged, a6TB.ForeColorChanged, a7TB.ForeColorChanged, b1TB.ForeColorChanged, b2TB.ForeColorChanged, b6PB.ForeColorChanged, b7PB.ForeColorChanged, c1TB.ForeColorChanged, c3TB.ForeColorChanged, c4TB.ForeColorChanged, c5TB.ForeColorChanged, c7TB.ForeColorChanged, d1TB.ForeColorChanged, d3TB.ForeColorChanged, d4TB.ForeColorChanged, d6TB.ForeColorChanged, d7TB.ForeColorChanged, a1TB.BackColorChanged, a2TB.BackColorChanged, a3PB.BackColorChanged, a4TB.BackColorChanged, a5TB.BackColorChanged, a6TB.BackColorChanged, a7TB.BackColorChanged, b1TB.BackColorChanged, b2TB.BackColorChanged, b6PB.BackColorChanged, b7PB.BackColorChanged, c1TB.BackColorChanged, c3TB.BackColorChanged, c4TB.BackColorChanged, c5TB.BackColorChanged, c7TB.BackColorChanged, d1TB.BackColorChanged, d3TB.BackColorChanged, d4TB.BackColorChanged, d6TB.BackColorChanged, d7TB.BackColorChanged

        kdu.a1TB.ForeColor = a1TB.ForeColor
        kdu.a2TB.ForeColor = a2TB.ForeColor
        kdu.a4TB.ForeColor = a4TB.ForeColor
        kdu.a5TB.ForeColor = a5TB.ForeColor
        kdu.a6TB.ForeColor = a6TB.ForeColor
        kdu.a7TB.ForeColor = a7TB.ForeColor
        kdu.b1TB.ForeColor = b1TB.ForeColor
        kdu.b2TB.ForeColor = b2TB.ForeColor
        kdu.c1TB.ForeColor = c1TB.ForeColor
        kdu.c3TB.ForeColor = c3TB.ForeColor
        kdu.c4TB.ForeColor = c4TB.ForeColor
        kdu.c5TB.ForeColor = c5TB.ForeColor
        kdu.c7TB.ForeColor = c7TB.ForeColor
        kdu.d1TB.ForeColor = d1TB.ForeColor
        kdu.d3TB.ForeColor = d3TB.ForeColor
        kdu.d4TB.ForeColor = d4TB.ForeColor
        kdu.d6TB.ForeColor = d6TB.ForeColor
        kdu.d7TB.ForeColor = d7TB.ForeColor

        kdu.a1TB.BackColor = a1TB.BackColor
        kdu.a2TB.BackColor = a2TB.BackColor
        kdu.a4TB.BackColor = a4TB.BackColor
        kdu.a5TB.BackColor = a5TB.BackColor
        kdu.a6TB.BackColor = a6TB.BackColor
        kdu.a7TB.BackColor = a7TB.BackColor
        kdu.b1TB.BackColor = b1TB.BackColor
        kdu.b2TB.BackColor = b2TB.BackColor
        kdu.c1TB.BackColor = c1TB.BackColor
        kdu.c3TB.BackColor = c3TB.BackColor
        kdu.c4TB.BackColor = c4TB.BackColor
        kdu.c5TB.BackColor = c5TB.BackColor
        kdu.c7TB.BackColor = c7TB.BackColor
        kdu.d1TB.BackColor = d1TB.BackColor
        kdu.d3TB.BackColor = d3TB.BackColor
        kdu.d4TB.BackColor = d4TB.BackColor
        kdu.d6TB.BackColor = d6TB.BackColor
        kdu.d7TB.BackColor = d7TB.BackColor

        MyImageUpdated()

    End Sub

    Private Sub MyJustificationChanged(sender As Object, e As EventArgs) Handles a1TB.TextAlignChanged, a2TB.TextAlignChanged, a4TB.TextAlignChanged, a5TB.TextAlignChanged, a6TB.TextAlignChanged, a7TB.TextAlignChanged, b1TB.TextAlignChanged, b2TB.TextAlignChanged, c1TB.TextAlignChanged, c3TB.TextAlignChanged, c4TB.TextAlignChanged, c5TB.TextAlignChanged, c7TB.TextAlignChanged, d1TB.TextAlignChanged, d3TB.TextAlignChanged, d4TB.TextAlignChanged, d6TB.TextAlignChanged, d7TB.TextAlignChanged

        kdu.a1TB.TextAlign = a1TB.TextAlign
        kdu.a2TB.TextAlign = a2TB.TextAlign
        kdu.a4TB.TextAlign = a4TB.TextAlign
        kdu.a5TB.TextAlign = a5TB.TextAlign
        kdu.a6TB.TextAlign = a6TB.TextAlign
        kdu.a7TB.TextAlign = a7TB.TextAlign
        kdu.b1TB.TextAlign = b1TB.TextAlign
        kdu.b2TB.TextAlign = b2TB.TextAlign
        kdu.c1TB.TextAlign = c1TB.TextAlign
        kdu.c3TB.TextAlign = c3TB.TextAlign
        kdu.c4TB.TextAlign = c4TB.TextAlign
        kdu.c5TB.TextAlign = c5TB.TextAlign
        kdu.c7TB.TextAlign = c7TB.TextAlign
        kdu.d1TB.TextAlign = d1TB.TextAlign
        kdu.d3TB.TextAlign = d3TB.TextAlign
        kdu.d4TB.TextAlign = d4TB.TextAlign
        kdu.d6TB.TextAlign = d6TB.TextAlign
        kdu.d7TB.TextAlign = d7TB.TextAlign

    End Sub
    Private Sub MyImageUpdated()

        kdu.a3PB.BackgroundImage = a3PB.BackgroundImage
        kdu.a3PB.Image = a3PB.Image
        kdu.a3PB.BackgroundImageLayout = a3PB.BackgroundImageLayout
        kdu.a3PB.Width = a3PB.Width
        kdu.a3PB.Visible = a3PB.Visible

        kdu.b6PB.BackgroundImage = b6PB.BackgroundImage
        kdu.b6PB.Image = b6PB.Image
        kdu.b6PB.BackgroundImageLayout = b6PB.BackgroundImageLayout
        kdu.b6PB.Width = b6PB.Width
        kdu.b6PB.Visible = b6PB.Visible

        kdu.b7PB.BackgroundImage = b7PB.BackgroundImage
        kdu.b7PB.Image = b7PB.Image
        kdu.b7PB.BackgroundImageLayout = b7PB.BackgroundImageLayout
        kdu.b7PB.Width = b7PB.Width
        kdu.b7PB.Visible = b7PB.Visible
        
        


    End Sub

    Private Sub KDUpage3()

        kdu.modBox.Location = New Point(modBox.Location.X - xfactor, modBox.Location.Y - yfactor)
        kdu.modBox.Font = modBox.Font
        kdu.modBox.Size = modBox.Size
        kdu.modBox.Text = modBox.Text
        kdu.modBox.TextAlign = modBox.TextAlign
        kdu.modBox.BackColor = modBox.BackColor
        kdu.modBox.ForeColor = modBox.ForeColor
        kdu.modBox.BorderStyle = modBox.BorderStyle
        kdu.modBox.Visible = True
        kdu.modBox.BringToFront()

    End Sub

    Private Sub KDUpage4()

        kdu.page4TB1.Location = New Point(page4TB1.Location.X - xfactor, page4TB1.Location.Y - yfactor)
        kdu.page4TB2.Location = New Point(page4TB2.Location.X - xfactor, page4TB2.Location.Y - yfactor)

        kdu.page4TB1.Font = page4TB1.Font
        kdu.page4TB2.Font = page4TB2.Font

        kdu.page4TB1.Size = page4TB1.Size
        kdu.page4TB2.Size = page4TB2.Size

        kdu.page4TB1.Text = page4TB1.Text
        kdu.page4TB2.Text = page4TB2.Text

        kdu.page4TB1.TextAlign = page4TB1.TextAlign
        kdu.page4TB2.TextAlign = page4TB2.TextAlign

        kdu.page4TB1.BackColor = page4TB1.BackColor
        kdu.page4TB2.BackColor = page4TB2.BackColor

        kdu.page4TB1.ForeColor = page4TB1.ForeColor
        kdu.page4TB2.ForeColor = page4TB2.ForeColor

        kdu.page4TB1.BorderStyle = page4TB1.BorderStyle
        kdu.page4TB2.BorderStyle = page4TB2.BorderStyle

        kdu.page4TB1.Visible = True
        kdu.page4TB2.Visible = True

        kdu.page4TB1.BringToFront()
        kdu.page4TB2.BringToFront()



    End Sub

    Private Sub MyCreateTextBoxes()


        kdu.digit1.Location = New Point(digit1.Location.X - xfactor, digit1.Location.Y - yfactor)
        kdu.digit1.Font = digit1.Font
        kdu.digit1.Size = digit1.Size
        kdu.digit1.Text = digit1.Text
        kdu.digit1.TextAlign = digit1.TextAlign
        kdu.digit1.BackColor = digit1.BackColor
        kdu.digit1.ForeColor = digit1.ForeColor
        kdu.digit1.BorderStyle = digit1.BorderStyle
        kdu.digit1.Visible = digit1.Visible
        kdu.digit1.BringToFront()

        kdu.digit2.Location = New Point(digit2.Location.X - xfactor, digit2.Location.Y - yfactor)
        kdu.digit2.Font = digit2.Font
        kdu.digit2.Size = digit2.Size
        kdu.digit2.Text = digit2.Text
        kdu.digit2.TextAlign = digit2.TextAlign
        kdu.digit2.BackColor = digit2.BackColor
        kdu.digit2.ForeColor = digit2.ForeColor
        kdu.digit2.BorderStyle = digit2.BorderStyle
        kdu.digit2.Visible = digit2.Visible
        kdu.digit2.BringToFront()

        kdu.digit3.Location = New Point(digit3.Location.X - xfactor, digit3.Location.Y - yfactor)
        kdu.digit3.Font = digit3.Font
        kdu.digit3.Size = digit3.Size
        kdu.digit3.Text = digit3.Text
        kdu.digit3.TextAlign = digit3.TextAlign
        kdu.digit3.BackColor = digit3.BackColor
        kdu.digit3.ForeColor = digit3.ForeColor
        kdu.digit3.BorderStyle = digit3.BorderStyle
        kdu.digit3.Visible = digit3.Visible
        kdu.digit3.BringToFront()

        kdu.digit4.Location = New Point(digit4.Location.X - xfactor, digit4.Location.Y - yfactor)
        kdu.digit4.Font = digit4.Font
        kdu.digit4.Size = digit4.Size
        kdu.digit4.Text = digit4.Text
        kdu.digit4.TextAlign = digit4.TextAlign
        kdu.digit4.BackColor = digit4.BackColor
        kdu.digit4.ForeColor = digit4.ForeColor
        kdu.digit4.BorderStyle = digit4.BorderStyle
        kdu.digit4.Visible = digit4.Visible
        kdu.digit4.BringToFront()

        kdu.digit5.Location = New Point(digit5.Location.X - xfactor, digit5.Location.Y - yfactor)
        kdu.digit5.Font = digit5.Font
        kdu.digit5.Size = digit5.Size
        kdu.digit5.Text = digit5.Text
        kdu.digit5.TextAlign = digit5.TextAlign
        kdu.digit5.BackColor = digit5.BackColor
        kdu.digit5.ForeColor = digit5.ForeColor
        kdu.digit5.BorderStyle = digit5.BorderStyle
        kdu.digit5.Visible = digit5.Visible
        kdu.digit5.BringToFront()

        kdu.digit6.Location = New Point(digit6.Location.X - xfactor, digit6.Location.Y - yfactor)
        kdu.digit6.Font = digit6.Font
        kdu.digit6.Size = digit6.Size
        kdu.digit6.Text = digit6.Text
        kdu.digit6.TextAlign = digit6.TextAlign
        kdu.digit6.BackColor = digit6.BackColor
        kdu.digit6.ForeColor = digit6.ForeColor
        kdu.digit6.BorderStyle = digit6.BorderStyle
        kdu.digit6.Visible = digit6.Visible
        kdu.digit6.BringToFront()

        kdu.digit7.Location = New Point(digit7.Location.X - xfactor, digit7.Location.Y - yfactor)
        kdu.digit7.Font = digit7.Font
        kdu.digit7.Size = digit7.Size
        kdu.digit7.Text = digit7.Text
        kdu.digit7.TextAlign = digit7.TextAlign
        kdu.digit7.BackColor = digit7.BackColor
        kdu.digit7.ForeColor = digit7.ForeColor
        kdu.digit7.BorderStyle = digit7.BorderStyle
        kdu.digit7.Visible = digit7.Visible
        kdu.digit7.BringToFront()

        kdu.digit8.Location = New Point(digit8.Location.X - xfactor, digit8.Location.Y - yfactor)
        kdu.digit8.Font = digit8.Font
        kdu.digit8.Size = digit8.Size
        kdu.digit8.Text = digit8.Text
        kdu.digit8.TextAlign = digit8.TextAlign
        kdu.digit8.BackColor = digit8.BackColor
        kdu.digit8.ForeColor = digit8.ForeColor
        kdu.digit8.BorderStyle = digit8.BorderStyle
        kdu.digit8.Visible = digit8.Visible
        kdu.digit8.BringToFront()

        kdu.digit9.Location = New Point(digit9.Location.X - xfactor, digit9.Location.Y - yfactor)
        kdu.digit9.Font = digit9.Font
        kdu.digit9.Size = digit9.Size
        kdu.digit9.Text = digit9.Text
        kdu.digit9.TextAlign = digit9.TextAlign
        kdu.digit9.BackColor = digit9.BackColor
        kdu.digit9.ForeColor = digit9.ForeColor
        kdu.digit9.BorderStyle = digit9.BorderStyle
        kdu.digit9.Visible = digit9.Visible
        kdu.digit9.BringToFront()



    End Sub

    Private Sub MyCreateIPboxes()

        kdu.ip1.Location = New Point(ip1.Location.X - xfactor, ip1.Location.Y - yfactor)
        kdu.ip1.Font = ip1.Font()
        kdu.ip1.TextAlign = ip1.TextAlign
        kdu.ip1.Text = ip1.Text
        kdu.ip1.Size = ip1.Size
        kdu.ip1.ForeColor = ip1.ForeColor
        kdu.ip1.BackColor = ip1.BackColor
        kdu.ip1.BorderStyle = ip1.BorderStyle
        kdu.ip1.Visible = ip1.Visible
        kdu.ip1.BringToFront()

        kdu.ip2.Location = New Point(ip2.Location.X - xfactor, ip2.Location.Y - yfactor)
        kdu.ip2.Font = ip2.Font()
        kdu.ip2.TextAlign = ip2.TextAlign
        kdu.ip2.Text = ip2.Text
        kdu.ip2.Size = ip2.Size
        kdu.ip2.ForeColor = ip2.ForeColor
        kdu.ip2.BackColor = ip2.BackColor
        kdu.ip2.BorderStyle = ip2.BorderStyle
        kdu.ip2.Visible = ip2.Visible
        kdu.ip2.BringToFront()

        kdu.ip3.Location = New Point(ip3.Location.X - xfactor, ip3.Location.Y - yfactor)
        kdu.ip3.Font = ip3.Font()
        kdu.ip3.TextAlign = ip3.TextAlign
        kdu.ip3.Text = ip3.Text
        kdu.ip3.Size = ip3.Size
        kdu.ip3.ForeColor = ip3.ForeColor
        kdu.ip3.BackColor = ip3.BackColor
        kdu.ip3.BorderStyle = ip3.BorderStyle
        kdu.ip3.Visible = ip3.Visible
        kdu.ip3.BringToFront()

        kdu.ip4.Location = New Point(ip4.Location.X - xfactor, ip4.Location.Y - yfactor)
        kdu.ip4.Font = ip4.Font()
        kdu.ip4.TextAlign = ip4.TextAlign
        kdu.ip4.Text = ip4.Text
        kdu.ip4.Size = ip4.Size
        kdu.ip4.ForeColor = ip4.ForeColor
        kdu.ip4.BackColor = ip4.BackColor
        kdu.ip4.BorderStyle = ip4.BorderStyle
        kdu.ip4.Visible = ip4.Visible
        kdu.ip4.BringToFront()

        kdu.ip5.Location = New Point(ip5.Location.X - xfactor, ip5.Location.Y - yfactor)
        kdu.ip5.Font = ip5.Font()
        kdu.ip5.TextAlign = ip5.TextAlign
        kdu.ip5.Text = ip5.Text
        kdu.ip5.Size = ip5.Size
        kdu.ip5.ForeColor = ip5.ForeColor
        kdu.ip5.BackColor = ip5.BackColor
        kdu.ip5.BorderStyle = ip5.BorderStyle
        kdu.ip5.Visible = ip5.Visible
        kdu.ip5.BringToFront()

        kdu.ip6.Location = New Point(ip6.Location.X - xfactor, ip6.Location.Y - yfactor)
        kdu.ip6.Font = ip6.Font()
        kdu.ip6.TextAlign = ip6.TextAlign
        kdu.ip6.Text = ip6.Text
        kdu.ip6.Size = ip6.Size
        kdu.ip6.ForeColor = ip6.ForeColor
        kdu.ip6.BackColor = ip6.BackColor
        kdu.ip6.BorderStyle = ip6.BorderStyle
        kdu.ip6.Visible = ip6.Visible
        kdu.ip6.BringToFront()

        kdu.ip7.Location = New Point(ip7.Location.X - xfactor, ip7.Location.Y - yfactor)
        kdu.ip7.Font = ip7.Font()
        kdu.ip7.TextAlign = ip7.TextAlign
        kdu.ip7.Text = ip7.Text
        kdu.ip7.Size = ip7.Size
        kdu.ip7.ForeColor = ip7.ForeColor
        kdu.ip7.BackColor = ip7.BackColor
        kdu.ip7.BorderStyle = ip7.BorderStyle
        kdu.ip7.Visible = ip7.Visible
        kdu.ip7.BringToFront()

        kdu.ip8.Location = New Point(ip8.Location.X - xfactor, ip8.Location.Y - yfactor)
        kdu.ip8.Font = ip8.Font()
        kdu.ip8.TextAlign = ip8.TextAlign
        kdu.ip8.Text = ip8.Text
        kdu.ip8.Size = ip8.Size
        kdu.ip8.ForeColor = ip8.ForeColor
        kdu.ip8.BackColor = ip8.BackColor
        kdu.ip8.BorderStyle = ip8.BorderStyle
        kdu.ip8.Visible = ip8.Visible
        kdu.ip8.BringToFront()

        kdu.ip9.Location = New Point(ip9.Location.X - xfactor, ip9.Location.Y - yfactor)
        kdu.ip9.Font = ip9.Font()
        kdu.ip9.TextAlign = ip9.TextAlign
        kdu.ip9.Text = ip9.Text
        kdu.ip9.Size = ip9.Size
        kdu.ip9.ForeColor = ip9.ForeColor
        kdu.ip9.BackColor = ip9.BackColor
        kdu.ip9.BorderStyle = ip9.BorderStyle
        kdu.ip9.Visible = ip9.Visible
        kdu.ip9.BringToFront()

        kdu.ip10.Location = New Point(ip10.Location.X - xfactor, ip10.Location.Y - yfactor)
        kdu.ip10.Font = ip10.Font()
        kdu.ip10.TextAlign = ip10.TextAlign
        kdu.ip10.Text = ip10.Text
        kdu.ip10.Size = ip10.Size
        kdu.ip10.ForeColor = ip10.ForeColor
        kdu.ip10.BackColor = ip10.BackColor
        kdu.ip10.BorderStyle = ip10.BorderStyle
        kdu.ip10.Visible = ip10.Visible
        kdu.ip10.BringToFront()

        kdu.ip11.Location = New Point(ip11.Location.X - xfactor, ip11.Location.Y - yfactor)
        kdu.ip11.Font = ip11.Font()
        kdu.ip11.TextAlign = ip11.TextAlign
        kdu.ip11.Text = ip11.Text
        kdu.ip11.Size = ip11.Size
        kdu.ip11.ForeColor = ip11.ForeColor
        kdu.ip11.BackColor = ip11.BackColor
        kdu.ip11.BorderStyle = ip11.BorderStyle
        kdu.ip11.Visible = ip11.Visible
        kdu.ip11.BringToFront()

        kdu.ip12.Location = New Point(ip12.Location.X - xfactor, ip12.Location.Y - yfactor)
        kdu.ip12.Font = ip12.Font()
        kdu.ip12.TextAlign = ip12.TextAlign
        kdu.ip12.Text = ip12.Text
        kdu.ip12.Size = ip12.Size
        kdu.ip12.ForeColor = ip12.ForeColor
        kdu.ip12.BackColor = ip12.BackColor
        kdu.ip12.BorderStyle = ip12.BorderStyle
        kdu.ip12.Visible = ip12.Visible
        kdu.ip12.BringToFront()

        kdu.ip13.Location = New Point(ip13.Location.X - xfactor, ip13.Location.Y - yfactor)
        kdu.ip13.Font = ip13.Font()
        kdu.ip13.TextAlign = ip13.TextAlign
        kdu.ip13.Text = ip13.Text
        kdu.ip13.Size = ip13.Size
        kdu.ip13.ForeColor = ip13.ForeColor
        kdu.ip13.BackColor = ip13.BackColor
        kdu.ip13.BorderStyle = ip13.BorderStyle
        kdu.ip13.Visible = ip13.Visible
        kdu.ip13.BringToFront()

        kdu.ip14.Location = New Point(ip14.Location.X - xfactor, ip14.Location.Y - yfactor)
        kdu.ip14.Font = ip14.Font()
        kdu.ip14.TextAlign = ip14.TextAlign
        kdu.ip14.Text = ip14.Text
        kdu.ip14.Size = ip14.Size
        kdu.ip14.ForeColor = ip14.ForeColor
        kdu.ip14.BackColor = ip14.BackColor
        kdu.ip14.BorderStyle = ip14.BorderStyle
        kdu.ip14.Visible = ip14.Visible
        kdu.ip14.BringToFront()

        kdu.ip15.Location = New Point(ip15.Location.X - xfactor, ip15.Location.Y - yfactor)
        kdu.ip15.Font = ip15.Font()
        kdu.ip15.TextAlign = ip15.TextAlign
        kdu.ip15.Text = ip15.Text
        kdu.ip15.Size = ip15.Size
        kdu.ip15.ForeColor = ip15.ForeColor
        kdu.ip15.BackColor = ip15.BackColor
        kdu.ip15.BorderStyle = ip15.BorderStyle
        kdu.ip15.Visible = ip15.Visible
        kdu.ip15.BringToFront()





    End Sub

    Private Sub MyCreateMyNameboxes()

        kdu.namebox1.Location = New Point(nameBox1.Location.X - xfactor, nameBox1.Location.Y - yfactor)
        kdu.namebox1.Font = nameBox1.Font
        kdu.namebox1.Size = nameBox1.Size
        kdu.namebox1.Text = nameBox1.Text
        kdu.namebox1.TextAlign = nameBox1.TextAlign
        kdu.namebox1.BackColor = nameBox1.BackColor
        kdu.namebox1.ForeColor = nameBox1.ForeColor
        kdu.namebox1.BorderStyle = nameBox1.BorderStyle
        kdu.namebox1.Visible = nameBox1.Visible
        kdu.namebox1.BringToFront()

        kdu.namebox2.Location = New Point(nameBox2.Location.X - xfactor, nameBox2.Location.Y - yfactor)
        kdu.namebox2.Font = nameBox2.Font
        kdu.namebox2.Size = nameBox2.Size
        kdu.namebox2.Text = nameBox2.Text
        kdu.namebox2.TextAlign = nameBox2.TextAlign
        kdu.namebox2.BackColor = nameBox2.BackColor
        kdu.namebox2.ForeColor = nameBox2.ForeColor
        kdu.namebox2.BorderStyle = nameBox2.BorderStyle
        kdu.namebox2.Visible = nameBox2.Visible
        kdu.namebox2.BringToFront()

        kdu.namebox3.Location = New Point(nameBox3.Location.X - xfactor, nameBox3.Location.Y - yfactor)
        kdu.namebox3.Font = nameBox3.Font
        kdu.namebox3.Size = nameBox3.Size
        kdu.namebox3.Text = nameBox3.Text
        kdu.namebox3.TextAlign = nameBox3.TextAlign
        kdu.namebox3.BackColor = nameBox3.BackColor
        kdu.namebox3.ForeColor = nameBox3.ForeColor
        kdu.namebox3.BorderStyle = nameBox3.BorderStyle
        kdu.namebox3.Visible = nameBox3.Visible
        kdu.namebox3.BringToFront()

        kdu.namebox4.Location = New Point(nameBox4.Location.X - xfactor, nameBox4.Location.Y - yfactor)
        kdu.namebox4.Font = nameBox4.Font
        kdu.namebox4.Size = nameBox4.Size
        kdu.namebox4.Text = nameBox4.Text
        kdu.namebox4.TextAlign = nameBox4.TextAlign
        kdu.namebox4.BackColor = nameBox4.BackColor
        kdu.namebox4.ForeColor = nameBox4.ForeColor
        kdu.namebox4.BorderStyle = nameBox4.BorderStyle
        kdu.namebox4.Visible = nameBox4.Visible
        kdu.namebox4.BringToFront()

        kdu.namebox5.Location = New Point(nameBox5.Location.X - xfactor, nameBox5.Location.Y - yfactor)
        kdu.namebox5.Font = nameBox5.Font
        kdu.namebox5.Size = nameBox5.Size
        kdu.namebox5.Text = nameBox5.Text
        kdu.namebox5.TextAlign = nameBox5.TextAlign
        kdu.namebox5.BackColor = nameBox5.BackColor
        kdu.namebox5.ForeColor = nameBox5.ForeColor
        kdu.namebox5.BorderStyle = nameBox5.BorderStyle
        kdu.namebox5.Visible = nameBox5.Visible
        kdu.namebox5.BringToFront()

        kdu.namebox6.Location = New Point(nameBox6.Location.X - xfactor, nameBox6.Location.Y - yfactor)
        kdu.namebox6.Font = nameBox6.Font
        kdu.namebox6.Size = nameBox6.Size
        kdu.namebox6.Text = nameBox6.Text
        kdu.namebox6.TextAlign = nameBox6.TextAlign
        kdu.namebox6.BackColor = nameBox6.BackColor
        kdu.namebox6.ForeColor = nameBox6.ForeColor
        kdu.namebox6.BorderStyle = nameBox6.BorderStyle
        kdu.namebox6.Visible = nameBox6.Visible
        kdu.namebox6.BringToFront()

        kdu.namebox7.Location = New Point(nameBox7.Location.X - xfactor, nameBox7.Location.Y - yfactor)
        kdu.namebox7.Font = nameBox7.Font
        kdu.namebox7.Size = nameBox7.Size
        kdu.namebox7.Text = nameBox7.Text
        kdu.namebox7.TextAlign = nameBox7.TextAlign
        kdu.namebox7.BackColor = nameBox7.BackColor
        kdu.namebox7.ForeColor = nameBox7.ForeColor
        kdu.namebox7.BorderStyle = nameBox7.BorderStyle
        kdu.namebox7.Visible = nameBox7.Visible
        kdu.namebox7.BringToFront()

        kdu.namebox8.Location = New Point(nameBox8.Location.X - xfactor, nameBox8.Location.Y - yfactor)
        kdu.namebox8.Font = nameBox8.Font
        kdu.namebox8.Size = nameBox8.Size
        kdu.namebox8.Text = nameBox8.Text
        kdu.namebox8.TextAlign = nameBox8.TextAlign
        kdu.namebox8.BackColor = nameBox8.BackColor
        kdu.namebox8.ForeColor = nameBox8.ForeColor
        kdu.namebox8.BorderStyle = nameBox8.BorderStyle
        kdu.namebox8.Visible = nameBox8.Visible
        kdu.namebox8.BringToFront()

        kdu.namebox9.Location = New Point(nameBox9.Location.X - xfactor, nameBox9.Location.Y - yfactor)
        kdu.namebox9.Font = nameBox9.Font
        kdu.namebox9.Size = nameBox9.Size
        kdu.namebox9.Text = nameBox9.Text
        kdu.namebox9.TextAlign = nameBox9.TextAlign
        kdu.namebox9.BackColor = nameBox9.BackColor
        kdu.namebox9.ForeColor = nameBox9.ForeColor
        kdu.namebox9.BorderStyle = nameBox9.BorderStyle
        kdu.namebox9.Visible = nameBox9.Visible
        kdu.namebox9.BringToFront()

        kdu.namebox10.Location = New Point(nameBox10.Location.X - xfactor, nameBox10.Location.Y - yfactor)
        kdu.namebox10.Font = nameBox10.Font
        kdu.namebox10.Size = nameBox10.Size
        kdu.namebox10.Text = nameBox10.Text
        kdu.namebox10.TextAlign = nameBox10.TextAlign
        kdu.namebox10.BackColor = nameBox10.BackColor
        kdu.namebox10.ForeColor = nameBox10.ForeColor
        kdu.namebox10.BorderStyle = nameBox10.BorderStyle
        kdu.namebox10.Visible = nameBox10.Visible
        kdu.namebox10.BringToFront()

        kdu.namebox11.Location = New Point(nameBox11.Location.X - xfactor, nameBox11.Location.Y - yfactor)
        kdu.namebox11.Font = nameBox11.Font
        kdu.namebox11.Size = nameBox11.Size
        kdu.namebox11.Text = nameBox11.Text
        kdu.namebox11.TextAlign = nameBox11.TextAlign
        kdu.namebox11.BackColor = nameBox11.BackColor
        kdu.namebox11.ForeColor = nameBox11.ForeColor
        kdu.namebox11.BorderStyle = nameBox11.BorderStyle
        kdu.namebox11.Visible = nameBox11.Visible
        kdu.namebox11.BringToFront()

        kdu.namebox12.Location = New Point(nameBox12.Location.X - xfactor, nameBox12.Location.Y - yfactor)
        kdu.namebox12.Font = nameBox12.Font
        kdu.namebox12.Size = nameBox12.Size
        kdu.namebox12.Text = nameBox12.Text
        kdu.namebox12.TextAlign = nameBox12.TextAlign
        kdu.namebox12.BackColor = nameBox12.BackColor
        kdu.namebox12.ForeColor = nameBox12.ForeColor
        kdu.namebox12.BorderStyle = nameBox12.BorderStyle
        kdu.namebox12.Visible = nameBox12.Visible
        kdu.namebox12.BringToFront()

        kdu.namebox13.Location = New Point(nameBox13.Location.X - xfactor, nameBox13.Location.Y - yfactor)
        kdu.namebox13.Font = nameBox13.Font
        kdu.namebox13.Size = nameBox13.Size
        kdu.namebox13.Text = nameBox13.Text
        kdu.namebox13.TextAlign = nameBox13.TextAlign
        kdu.namebox13.BackColor = nameBox13.BackColor
        kdu.namebox13.ForeColor = nameBox13.ForeColor
        kdu.namebox13.BorderStyle = nameBox13.BorderStyle
        kdu.namebox13.Visible = nameBox13.Visible
        kdu.namebox13.BringToFront()

        kdu.namebox14.Location = New Point(nameBox14.Location.X - xfactor, nameBox14.Location.Y - yfactor)
        kdu.namebox14.Font = nameBox14.Font
        kdu.namebox14.Size = nameBox14.Size
        kdu.namebox14.Text = nameBox14.Text
        kdu.namebox14.TextAlign = nameBox14.TextAlign
        kdu.namebox14.BackColor = nameBox14.BackColor
        kdu.namebox14.ForeColor = nameBox14.ForeColor
        kdu.namebox14.BorderStyle = nameBox14.BorderStyle
        kdu.namebox14.Visible = nameBox14.Visible
        kdu.namebox14.BringToFront()

        kdu.namebox15.Location = New Point(nameBox15.Location.X - xfactor, nameBox15.Location.Y - yfactor)
        kdu.namebox15.Font = nameBox15.Font
        kdu.namebox15.Size = nameBox15.Size
        kdu.namebox15.Text = nameBox15.Text
        kdu.namebox15.TextAlign = nameBox15.TextAlign
        kdu.namebox15.BackColor = nameBox15.BackColor
        kdu.namebox15.ForeColor = nameBox15.ForeColor
        kdu.namebox15.BorderStyle = nameBox15.BorderStyle
        kdu.namebox15.Visible = nameBox15.Visible
        kdu.namebox15.BringToFront()

        kdu.namebox16.Location = New Point(nameBox16.Location.X - xfactor, nameBox16.Location.Y - yfactor)
        kdu.namebox16.Font = nameBox16.Font
        kdu.namebox16.Size = nameBox16.Size
        kdu.namebox16.Text = nameBox16.Text
        kdu.namebox16.TextAlign = nameBox16.TextAlign
        kdu.namebox16.BackColor = nameBox16.BackColor
        kdu.namebox16.ForeColor = nameBox16.ForeColor
        kdu.namebox16.BorderStyle = nameBox16.BorderStyle
        kdu.namebox16.Visible = nameBox16.Visible
        kdu.namebox16.BringToFront()

        kdu.namebox17.Location = New Point(nameBox17.Location.X - xfactor, nameBox17.Location.Y - yfactor)
        kdu.namebox17.Font = nameBox17.Font
        kdu.namebox17.Size = nameBox17.Size
        kdu.namebox17.Text = nameBox17.Text
        kdu.namebox17.TextAlign = nameBox17.TextAlign
        kdu.namebox17.BackColor = nameBox17.BackColor
        kdu.namebox17.ForeColor = nameBox17.ForeColor
        kdu.namebox17.BorderStyle = nameBox17.BorderStyle
        kdu.namebox17.Visible = nameBox17.Visible
        kdu.namebox17.BringToFront()

        kdu.namebox18.Location = New Point(nameBox18.Location.X - xfactor, nameBox18.Location.Y - yfactor)
        kdu.namebox18.Font = nameBox18.Font
        kdu.namebox18.Size = nameBox18.Size
        kdu.namebox18.Text = nameBox18.Text
        kdu.namebox18.TextAlign = nameBox18.TextAlign
        kdu.namebox18.BackColor = nameBox18.BackColor
        kdu.namebox18.ForeColor = nameBox18.ForeColor
        kdu.namebox18.BorderStyle = nameBox18.BorderStyle
        kdu.namebox18.Visible = nameBox18.Visible
        kdu.namebox18.BringToFront()

        kdu.namebox19.Location = New Point(nameBox19.Location.X - xfactor, nameBox19.Location.Y - yfactor)
        kdu.namebox19.Font = nameBox19.Font
        kdu.namebox19.Size = nameBox19.Size
        kdu.namebox19.Text = nameBox19.Text
        kdu.namebox19.TextAlign = nameBox19.TextAlign
        kdu.namebox19.BackColor = nameBox19.BackColor
        kdu.namebox19.ForeColor = nameBox19.ForeColor
        kdu.namebox19.BorderStyle = nameBox19.BorderStyle
        kdu.namebox19.Visible = nameBox19.Visible
        kdu.namebox19.BringToFront()

        kdu.namebox20.Location = New Point(nameBox20.Location.X - xfactor, nameBox20.Location.Y - yfactor)
        kdu.namebox20.Font = nameBox20.Font
        kdu.namebox20.Size = nameBox20.Size
        kdu.namebox20.Text = nameBox20.Text
        kdu.namebox20.TextAlign = nameBox20.TextAlign
        kdu.namebox20.BackColor = nameBox20.BackColor
        kdu.namebox20.ForeColor = nameBox20.ForeColor
        kdu.namebox20.BorderStyle = nameBox20.BorderStyle
        kdu.namebox20.Visible = nameBox20.Visible
        kdu.namebox20.BringToFront()

        MyCreateTextBoxes()

    End Sub

    Private Sub MyCreateProgressbar()


        kdu.tbBorder1.BorderStyle = tbBorder1.BorderStyle
        kdu.tbBorder1.AutoSize = tbBorder1.AutoSize
        kdu.tbBorder1.Location = New Point(tbBorder1.Location.X - xfactor, tbBorder1.Location.Y - yfactor)
        kdu.tbBorder1.BackColor = tbBorder1.BackColor
        kdu.tbBorder1.Height = tbBorder1.Height
        kdu.tbBorder1.Width = tbBorder1.Width
        kdu.tbBorder1.Visible = tbBorder1.Visible
        'kdu.tbBorder1.BringToFront()

        kdu.tbBack.BorderStyle = tbBack.BorderStyle
        kdu.tbBack.AutoSize = tbBack.AutoSize
        kdu.tbBack.Location = New Point(tbBack.Location.X - xfactor, tbBack.Location.Y - yfactor)
        kdu.tbBack.BackColor = tbBack.BackColor
        kdu.tbBack.Height = tbBack.Height
        kdu.tbBack.Width = tbBack.Width
        kdu.tbBack.Visible = tbBack.Visible
        kdu.tbBack.BringToFront()

        kdu.tbFront.Visible = tbFront.Visible
        kdu.tbFront.AutoSize = tbFront.AutoSize
        kdu.tbFront.BorderStyle = tbFront.BorderStyle
        kdu.tbFront.Width = tbFront.Width
        kdu.tbFront.Height = tbFront.Height
        kdu.tbFront.Location = New Point(tbFront.Location.X - xfactor, tbFront.Location.Y - yfactor)
        kdu.tbFront.BackColor = tbFront.BackColor
        kdu.tbFront.Visible = tbFront.Visible
        kdu.tbFront.BringToFront()

        

    End Sub

    Private Sub KDUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KDUToolStripMenuItem.Click

        If kdu.Visible = False Then
            kdu.Visible = True
        Else
            kdu.Visible = False
        End If

    End Sub
    Private Sub DisplayPicChanged(sender As Object, e As EventArgs) Handles displayPic.BackgroundImageChanged, displayPic.VisibleChanged



    End Sub
    Private Sub GetInstanceOfProcess()

        Dim radioVal As Integer

        CheckNumOfInstances()
        radioVal = numOfInstances

        currentRadioLBL.Text = "PRC-117G #" + radioVal.ToString()
        kdu.currentKDULBL.Text = "KDU #" + radioVal.ToString()


    End Sub

    Private Sub CheckNumOfInstances()


        Dim myProcess As String
        Dim allProcesses As Process()

        myProcess = Process.GetCurrentProcess.ProcessName.ToString()    'sets myProcess variable to the name of the current process

        'get all the running processes
        allProcesses = Process.GetProcessesByName(myProcess)

        'sets the highest value to this instance
        numOfInstances = allProcesses.Length

    End Sub

   
    Private Sub FlashRtimer(sender As Object, e As EventArgs) Handles Timer3.Tick

    End Sub

    Private Sub MyTimerSetup()

        generalUseTimer.Enabled = True
        generalUseTimer.Interval = 1000
        timeEnd = 0
        meterReading = 0

    End Sub

    Private Sub IPshutdown()

        ip1.Visible = False
        ip2.Visible = False
        ip3.Visible = False
        ip4.Visible = False
        ip5.Visible = False
        ip6.Visible = False
        ip7.Visible = False
        ip8.Visible = False
        ip9.Visible = False
        ip10.Visible = False
        ip11.Visible = False
        ip12.Visible = False
        ip13.Visible = False
        ip14.Visible = False
        ip15.Visible = False

        MyCreateIPboxes()

    End Sub

End Class
