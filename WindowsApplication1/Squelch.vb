﻿Module Squelch


    Public Sub SquelchTypeUpDown()
        Select Case Form1.storedType
            Case "SATCOM"
                Form1.c1TB.Text = "DISABLED"
            Case "LOS"
                If Form1.storedMod = "AM" Then
                    Select Case Form1.c1TB.Text
                        Case "OFF"
                            Form1.c1TB.Text = "NOISE"
                        Case "NOISE"
                            Form1.c1TB.Text = "OFF"
                    End Select

                ElseIf Form1.storedMod = "FM" Then
                    If Form1.storedTraffic = "VOICE AND DATA" Or Form1.storedTraffic = "VOICE" Then
                        Select Case Form1.c1TB.Text
                            Case "OFF"
                                Form1.c1TB.Text = "TONE"
                            Case "TONE"
                                Form1.c1TB.Text = "NOISE"
                            Case "NOISE"
                                Form1.c1TB.Text = "CTCSS"
                            Case "CTCSS"
                                Form1.c1TB.Text = "CDCSS"
                            Case "CDCSS"
                                Form1.c1TB.Text = "OFF"
                        End Select

                    ElseIf Form1.storedTraffic <> "VOICE" And Form1.c1TB.Text <> "VOICE AND DATA" Then
                        Select Case Form1.c1TB.Text
                            Case "OFF"
                                Form1.c1TB.Text = "TONE"
                            Case "TONE"
                                Form1.c1TB.Text = "NOISE"
                            Case "NOISE"
                                Form1.c1TB.Text = "CTCSS"
                            Case "CTCSS"
                                Form1.c1TB.Text = "CDCSS"
                            Case "CDCSS"
                                Form1.c1TB.Text = "OFF"
                        End Select
                    End If

                ElseIf Form1.storedMod = "MS181" Then
                    Select Case Form1.c1TB.Text
                        Case "OFF"
                            Form1.c1TB.Text = "TONE"
                        Case "TONE"
                            Form1.c1TB.Text = "NOISE"
                        Case "NOISE"
                            Form1.c1TB.Text = "CTCSS"
                        Case "CTCSS"
                            Form1.c1TB.Text = "CDCSS"
                        Case "CDCSS"
                            Form1.c1TB.Text = "OFF"
                    End Select
                End If
        End Select


    End Sub

    Public Sub CTCSSsquelchLoad(ByVal i As Integer, ByRef j As String, ByRef k As String, ByRef l As String)

        Try
            If IsDBNull(CTCSS.CTCSSDataGridView.Item(1, i).Value) = True Then
                j = " "
                k = " "
                l = " "
            Else
                j = CTCSS.CTCSSDataGridView.Item(1, i).Value
                k = CTCSS.CTCSSDataGridView.Item(2, i).Value
                l = CTCSS.CTCSSDataGridView.Item(3, i).Value
            End If
            'recall the information from the DB based on the form1.storedCTCSS
            'set return vars
        Catch ex As Exception
            j = " "
            k = " "
            l = " "
        End Try
        
    End Sub

    Public Sub CDCSSupOrDown(ByVal i As String, p2 As String, ByRef j As String)
        Select Case i
            Case "6"
                Select Case p2
                    Case "023"
                        j = "025"
                    Case "025"
                        j = "026"
                    Case "026"
                        j = "031"
                    Case "031"
                        j = "032"
                    Case "032"
                        j = "043"
                    Case "043"
                        j = "047"
                    Case "047"
                        j = "051"
                    Case "051"
                        j = "054"
                    Case "054"
                        j = "065"
                    Case "065"
                        j = "071"
                    Case "071"
                        j = "072"
                    Case "072"
                        j = "073"
                    Case "073"
                        j = "074"
                    Case "074"
                        j = "114"
                    Case "114"
                        j = "115"
                    Case "115"
                        j = "116"
                    Case "116"
                        j = "125"
                    Case "125"
                        j = "131"
                    Case "131"
                        j = "132"
                    Case "132"
                        j = "134"
                    Case "134"
                        j = "143"
                    Case "143"
                        j = "152"
                    Case "152"
                        j = "155"
                    Case "155"
                        j = "156"
                    Case "156"
                        j = "162"
                    Case "162"
                        j = "165"
                    Case "165"
                        j = "172"
                    Case "172"
                        j = "174"
                    Case "174"
                        j = "205"
                    Case "205"
                        j = "223"
                    Case "223"
                        j = "226"
                    Case "226"
                        j = "243"
                    Case "243"
                        j = "244"
                    Case "244"
                        j = "245"
                    Case "245"
                        j = "251"
                    Case "251"
                        j = "261"
                    Case "261"
                        j = "263"
                    Case "263"
                        j = "265"
                    Case "265"
                        j = "271"
                    Case "271"
                        j = "306"
                    Case "306"
                        j = "311"
                    Case "311"
                        j = "315"
                    Case "315"
                        j = "331"
                    Case "331"
                        j = "343"
                    Case "343"
                        j = "346"
                    Case "346"
                        j = "351"
                    Case "351"
                        j = "364"
                    Case "364"
                        j = "365"
                    Case "365"
                        j = "371"
                    Case "371"
                        j = "411"
                    Case "411"
                        j = "412"
                    Case "412"
                        j = "413"
                    Case "413"
                        j = "423"
                    Case "423"
                        j = "431"
                    Case "431"
                        j = "432"
                    Case "432"
                        j = "445"
                    Case "445"
                        j = "464"
                    Case "464"
                        j = "465"
                    Case "465"
                        j = "466"
                    Case "466"
                        j = "503"
                    Case "503"
                        j = "506"
                    Case "506"
                        j = "516"
                    Case "516"
                        j = "532"
                    Case "532"
                        j = "546"
                    Case "546"
                        j = "565"
                    Case "565"
                        j = "606"
                    Case "606"
                        j = "612"
                    Case "612"
                        j = "624"
                    Case "624"
                        j = "627"
                    Case "627"
                        j = "631"
                    Case "631"
                        j = "632"
                    Case "632"
                        j = "654"
                    Case "654"
                        j = "662"
                    Case "662"
                        j = "664"
                    Case "664"
                        j = "703"
                    Case "703"
                        j = "712"
                    Case "712"
                        j = "723"
                    Case "723"
                        j = "731"
                    Case "731"
                        j = "732"
                    Case "732"
                        j = "734"
                    Case "734"
                        j = "743"
                    Case "743"
                        j = "754"
                    Case "754"
                        j = "023"

                End Select
            Case "9"
                Select Case p2
                    Case "023"
                        j = "754"
                    Case "025"
                        j = "023"
                    Case "026"
                        j = "025"
                    Case "031"
                        j = "026"
                    Case "032"
                        j = "031"
                    Case "043"
                        j = "032"
                    Case "047"
                        j = "043"
                    Case "051"
                        j = "047"
                    Case "054"
                        j = "051"
                    Case "065"
                        j = "054"
                    Case "071"
                        j = "065"
                    Case "072"
                        j = "071"
                    Case "073"
                        j = "072"
                    Case "074"
                        j = "073"
                    Case "114"
                        j = "074"
                    Case "115"
                        j = "114"
                    Case "116"
                        j = "115"
                    Case "125"
                        j = "116"
                    Case "131"
                        j = "125"
                    Case "132"
                        j = "131"
                    Case "134"
                        j = "132"
                    Case "143"
                        j = "134"
                    Case "152"
                        j = "143"
                    Case "155"
                        j = "152"
                    Case "156"
                        j = "155"
                    Case "162"
                        j = "156"
                    Case "165"
                        j = "162"
                    Case "172"
                        j = "165"
                    Case "174"
                        j = "172"
                    Case "205"
                        j = "174"
                    Case "223"
                        j = "205"
                    Case "226"
                        j = "223"
                    Case "243"
                        j = "226"
                    Case "244"
                        j = "243"
                    Case "245"
                        j = "244"
                    Case "251"
                        j = "245"
                    Case "261"
                        j = "251"
                    Case "263"
                        j = "261"
                    Case "265"
                        j = "263"
                    Case "271"
                        j = "265"
                    Case "306"
                        j = "271"
                    Case "311"
                        j = "306"
                    Case "315"
                        j = "311"
                    Case "331"
                        j = "315"
                    Case "343"
                        j = "331"
                    Case "346"
                        j = "343"
                    Case "351"
                        j = "346"
                    Case "364"
                        j = "351"
                    Case "365"
                        j = "364"
                    Case "371"
                        j = "365"
                    Case "411"
                        j = "371"
                    Case "412"
                        j = "411"
                    Case "413"
                        j = "412"
                    Case "423"
                        j = "413"
                    Case "431"
                        j = "423"
                    Case "432"
                        j = "431"
                    Case "445"
                        j = "432"
                    Case "464"
                        j = "445"
                    Case "465"
                        j = "464"
                    Case "466"
                        j = "465"
                    Case "503"
                        j = "466"
                    Case "506"
                        j = "503"
                    Case "516"
                        j = "506"
                    Case "532"
                        j = "516"
                    Case "546"
                        j = "532"
                    Case "565"
                        j = "546"
                    Case "606"
                        j = "565"
                    Case "612"
                        j = "606"
                    Case "624"
                        j = "612"
                    Case "627"
                        j = "624"
                    Case "631"
                        j = "627"
                    Case "632"
                        j = "631"
                    Case "654"
                        j = "632"
                    Case "662"
                        j = "654"
                    Case "664"
                        j = "662"
                    Case "703"
                        j = "664"
                    Case "712"
                        j = "703"
                    Case "723"
                        j = "712"
                    Case "731"
                        j = "723"
                    Case "732"
                        j = "731"
                    Case "734"
                        j = "732"
                    Case "743"
                        j = "734"
                    Case "754"
                        j = "743"

                End Select
        End Select
    End Sub


End Module