Imports System.Windows.Forms

Public Class Readme

    Dim myText1 As String
    Dim myText2 As String
    Dim myText3 As String
    Dim myText4 As String
    Dim myText5 As String
    Dim myText6 As String
    Dim myText7 As String






    Private Sub Readme_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        '"A VHF/UHF Line of Sight (VULOS) net allows the user to receive and transmit voice and/or data using fixed receive and transmit frequencies. Antenna type, antenna height, output power, terrain, external terrain, and obstructions between AN/PRC-117G radios are all factors in range of communications. VULOS can be operated in either Plain Text (PT) or Cipher Text (CT) mode." + vbNewLine + "There are twenty-eight steps to program VULOS presets into the AN/PRC-117G radio." + vbNewLine + "" + vbNewLine +

        myText1 = "Step 1" + vbNewLine + "Rotate the Function Switch to CT to place the Radio in Cipher Text Mode" + vbNewLine + "" + vbNewLine +
            "Step 2 " + vbNewLine + "Press the PGM button (keypad button [8]) to enter Programming Mode." + vbNewLine + "" + vbNewLine +
            "Step 3 " + vbNewLine + "" + "This will display seven different selections for the configuration: " + vbNewLine + "• Radio Configuration " + vbNewLine + "• System Presets " + vbNewLine + "• DAMA Configuration " + vbNewLine + "• ANW2 Configuration " + vbNewLine + "• VULOS Configuration " + vbNewLine + "• SINCGARS Configuration " + vbNewLine + "• HAVEQUICKII Configuration " + vbNewLine + "This simulator is limited to three of those options." + vbNewLine + "" + vbNewLine + "Use the Up ([6]) and Down ([9]) keys to navigate to SYSTEM PRESETS and press ENT (Enter). " + vbNewLine + "" + vbNewLine +
            "Step 4 " + vbNewLine + "Select SYSTEM PRESET CONFIG and press ENT " + vbNewLine + "" + vbNewLine +
            "Step 5 " + vbNewLine + "Use the PRE Up/Down Button to navigate to an empty preset (as indicated by PRESETxx). Press the ENT button to select the empty slot. " + vbNewLine + "" + vbNewLine +
            "Step 6 " + vbNewLine + "You may enter a description of the preset if you wish. Press the ENT button again to continue " + vbNewLine + "" + vbNewLine +
            "Step 7 " + vbNewLine + "Using arrow buttons select VULOS and press ENT (this simulator only allows the VULOS waveform selection) " + vbNewLine + "" + vbNewLine +
            "Step 8 " + vbNewLine + "The seven different selections for the configuration are: " + vbNewLine + "• General Configuration " + vbNewLine + "• Frequency " + vbNewLine + "• COMSEC " + vbNewLine + "• Traffic " + vbNewLine + "• TX Power " + vbNewLine + "• Squelch " + vbNewLine + "• Exit " + vbNewLine + "" + vbNewLine + "Use the UP and DOWN arrow buttons to select GENERAL CONFIG and press ENT " + vbNewLine + "" + vbNewLine +
            "Step 9 " + vbNewLine + "This is where you will enter the present name that you are configuring. " + vbNewLine + "Using the numeric keypad and LEFT/RIGHT arrow buttons, toggle through the alphanumeric characters to spell out TEST04 and then press ENT. " + vbNewLine + "" + vbNewLine +
            "Step 10 " + vbNewLine + "Use the UP/DOWN arrow buttons to select LOS and press ENT " + vbNewLine + "" + vbNewLine +
            "Step 11 " + vbNewLine + "Use the number pad to enter the frequency or press the ENT button to select the default value " + vbNewLine + "" + vbNewLine +
            "Step 12 " + vbNewLine + "When prompted to enter Receive Only mode, use UP/DOWN arrow buttons to select NO and press ENT. " + vbNewLine + "" + vbNewLine +
            "Step 13 " + vbNewLine + "Use the arrow buttons to select USE RX FREQ and press ENT. " + vbNewLine + "" + vbNewLine +
            "Step 14 " + vbNewLine + "Press the ENT button again to continue " + vbNewLine + "" + vbNewLine +
            "Step 15 " + vbNewLine + "Use the arrow UP/DOWN buttons to select VINSON and press ENT " + vbNewLine + "" + vbNewLine +
            "Step 16 " + vbNewLine + "The operator can choose from 25 possible TEK positions " + vbNewLine + "Use the UP/DOWN arrow buttons to select TEK01 and press ENT " + vbNewLine + "TEK01 should be the default " + vbNewLine + "" + vbNewLine +
            "Step 17 " + vbNewLine + "Use the UP/DOWN arrow buttons to select VOICE AND DATA and press ENT " + vbNewLine + "" + vbNewLine +
            "Step 18 " + vbNewLine + "Use the UP/DOWN arrow buttons to select SYNCHRONOUS and press ENT " + vbNewLine + "" + vbNewLine +
            "Step 19 " + vbNewLine + "Press the ENT button again to continue. " + vbNewLine + "" + vbNewLine +
            "Step 20 " + vbNewLine + "Use the UP/DOWN arrow buttons to select AM and press ENT " + vbNewLine + "Note: The valid settings are AM, FM or MS181. In this example we are using AM. If FM or MS181 are selected, follow the instructions listed in Appendix A of the Operator’s Manual 10515-0319-4200. " + vbNewLine + "" + vbNewLine +
            "Step 21 " + vbNewLine + "Set TX POWER to HIGH and press ENT " + vbNewLine + "" + vbNewLine +
            "Step 22 " + vbNewLine + "Set SQUELCH to NOISE and press ENT " + vbNewLine + "" + vbNewLine +
            "Step 23 " + vbNewLine + "Press ENT again at the FM TONE DISABLED screen." + vbNewLine + "" + vbNewLine +
            "Step 24 " + vbNewLine + "Adjust the analog squelch level as desired and press ENT." + vbNewLine + "" + vbNewLine +
            "Step 25 " + vbNewLine + "This will take you back to the main menu. Press CLR twice to return to the main screen." + vbNewLine + "" + vbNewLine +
            "Step 26 " + vbNewLine + "The preset is entered."

        myText2 = "Step 1" + vbNewLine + "Rotate the Function Switch to CT to place the Radio in Cipher Text Mode" + vbNewLine + "" + vbNewLine +
            "Step 2 " + vbNewLine + "Press the + or - on the PRE button to scroll through the presets." + vbNewLine + "" + vbNewLine +
            "Step 3 " + vbNewLine + "Pressing the button quickly allows you to scroll through the presets with the description of the preset visible." + vbNewLine + "" + vbNewLine +
            "Step 4 " + vbNewLine + "If you press the button slowly, the preset description will display for a short time and then the preset will automatically load."

        myText3 = "This is the first preset screen shown. Pressing the 0 button will cycle through the different preset screens." + vbNewLine + "" + vbNewLine +
            "The system preset number identifies the current system preset" + vbNewLine + "" + vbNewLine +
            "Preset type is the waveform used by the preset such as LOS or SATCOM" + vbNewLine + "" + vbNewLine +
            "Traffic type represents the type of traffic such as VOICE, DATA, or DATA/VOICE" + vbNewLine + "" + vbNewLine +
            "System preset name is the name you give the preset" + vbNewLine + "" + vbNewLine +
            "Modulation type is how the waveform carries information. Modulation types can be SBPSK, CPM, AM, or FM" + vbNewLine + "" + vbNewLine +
            "Squelch type values include OFF, NOISE, TONE, CTCSS, CDCSS, or BSY" + vbNewLine + "" + vbNewLine +
            "Channel number is only used in SATCOM operation. Valid SATCOM channels are 001 to 249 and 999" + vbNewLine + "" + vbNewLine +
            "The last item on this page is the Crypto key number. This field represents the key number in use while in CT mode. In PT mode, this field wil show --"

        myText4 = "The second VULOS screen displays the RX frequency, TX frequency, and channel number (if in SATCOM mode)."

        myText5 = "The third VULOS screen displays data parameters. Option code represents parameters for transmitting and receiving data by this preset.Option code parameters include bandwidth, modulation mode, bits per second rate, interleave depth, and forward error correction. " + vbNewLine + "" + vbNewLine +
            "Bandwidth will very dependent upon the option code selected. The bandwidth can be either 5 kHz or 25 kHz channel width. " + vbNewLine + "" + vbNewLine +
            "Data mode specifies the synchronization mode that is used when transmitting and receiving DTE data. " + vbNewLine + "" + vbNewLine +
            "The bits per second rate is defined by the option code and is not selectable. It specifies the bits per second rate that is used for transmitting and receiving data. " + vbNewLine + "" + vbNewLine +
            "Voice mode allows for changes when the traffic mode is set to VOC or D/V (data/voice). " + vbNewLine + "" + vbNewLine +
            "Interleave depth is not selectable. It specifies the interleave depth if the option is supported. " + vbNewLine + "" + vbNewLine +
            "The forward error correction field is defined by the option code and is not selectable."

        myText6 = "The large font screen is the last main screen. Pressing the zero but on the keypad will advance the screen back to the original screen. The top row of information will remain the same on the large font screen as it does on any other screen."

        myText7 = "Welcome to the PRC-117G Desktop Trainer. This trainer is designed for the beginner operator interested in learning how to operate the PRC-117G. This trainer covers the VULOS waveform. While this trainer tries to be as acurate as possible, there may be differences between software revisions of an actual radio and the software revision this trainer was based upon. Because of this, it is best to have an instructor close by in case questions need to be answered. Also, the PRC-11G operators manual is a wonderful reference while using this trainer (The manual is located on the computer desktop for your convieince)."


        TabTB1.Text = myText1
        TabTB2.Text = myText2
        TabTB3.Text = myText3
        TabTB4.Text = myText4
        TabTB5.Text = myText5
        TabTB6.Text = myText6
        tabTB7.Text = myText7





    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click

    End Sub

    Private Sub KDUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KDUToolStripMenuItem.Click

        kdu.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        kdu.Show()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Form1.Region = New Region()
        Form1.closeBtn.Visible = False
        Form1.moveBtn.Visible = False


        kdu.TransparencyShow()
        

    End Sub

    Private Sub HideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideToolStripMenuItem.Click

        kdu.TransparencyHide()
        Form1.SetRegion()
    End Sub
End Class