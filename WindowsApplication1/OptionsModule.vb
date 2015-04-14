Module OptionsModule
    Public Sub CheckOptions(ByVal i As String, ByRef j As String)
        If i = "KG84" Or i = "ANDVT" Then
            If j = "202" Or j = "132" Or j = " " Then
                j = "008"
            End If

        End If

        If i = "VINSON" Then
            If j = "202" Or j = "132" Then
            Else
                j = "202"
            End If

        End If

        If i = "FASCINATOR" Then
            j = "F12"
        End If

    End Sub

    Public Sub GetOptionsData(ByVal opt As String, ByRef bw As String, ByRef modu As String, ByRef bps As String, ByRef fwderror As String)

        Select Case opt
            Case "008"
                bw = "5K"
                modu = "SBPSK"
                bps = "1200"
                fwderror = "OFF"
            Case "010"
                bw = "5K"
                modu = "SBPSK"
                bps = "2400"
                fwderror = "OFF"
            Case "013"
                bw = "5K"
                modu = "CPM"
                bps = "4800"
                fwderror = "OFF"
            Case "014"
                bw = "5K"
                modu = "CPM"
                bps = "4800"
                fwderror = "ON"
            Case "015"
                bw = "5K"
                modu = "CPM"
                bps = "6000"
                fwderror = "ON"
            Case "016"
                bw = "5K"
                modu = "CPM"
                bps = "6000"
                fwderror = "OFF"
            Case "017"
                bw = "5K"
                modu = "CPM"
                bps = "7200"
                fwderror = "ON"
            Case "018"
                bw = "5K"
                modu = "CPM"
                bps = "7200"
                fwderror = "OFF"
            Case "019"
                bw = "5K"
                modu = "CPM"
                bps = "8000"
                fwderror = "ON"
            Case "020"
                bw = "5K"
                modu = "CPM"
                bps = "8000"
                fwderror = "OFF"
            Case "021"
                bw = "5K"
                modu = "CPM"
                bps = "9600"
                fwderror = "OFF"
            Case "131"
                bw = "25K"
                modu = "CPM"
                bps = "9600"
                fwderror = "OFF"
            Case "132"
                bw = "25K"
                modu = "FSK"
                bps = "16K"
                fwderror = "OFF"
            Case "137"
                bw = "25K"
                modu = "CPM"
                bps = "19.2K"
                fwderror = "OFF"
            Case "138"
                bw = "25K"
                modu = "CPM"
                bps = "28.8K"
                fwderror = "ON"
            Case "139"
                bw = "25K"
                modu = "CPM"
                bps = "28.8K"
                fwderror = "OFF"
            Case "140"
                bw = "25K"
                modu = "CPM"
                bps = "32K"
                fwderror = "ON"
            Case "141"
                bw = "25K"
                modu = "CPM"
                bps = "32K"
                fwderror = "OFF"
            Case "142"
                bw = "25K"
                modu = "CPM"
                bps = "38.4K"
                fwderror = "ON"
            Case "143"
                bw = "25K"
                modu = "CPM"
                bps = "38.4K"
                fwderror = "OFF"
            Case "144"
                bw = "25K"
                modu = "CPM"
                bps = "48K"
                fwderror = "OFF"
            Case "145"
                bw = "25K"
                modu = "CPM"
                bps = "56K"
                fwderror = "OFF"
            Case "200"
                bw = "25K"
                modu = "AM"
                bps = "128K"
                fwderror = "OFF"
            Case "201"
                bw = "25K"
                modu = "FM"
                bps = "128K"
                fwderror = "OFF"
            Case "202"
                bw = "25K"
                modu = "ASK"
                bps = "16K"
                fwderror = "OFF"
            Case "F12"
                bw = "25K"
                modu = "FSK"
                bps = "12K"
                fwderror = "OFF"

        End Select

    End Sub

    Public Sub AvailableOptionsForCrypto(ByVal i As String, ByRef j As String, ByRef k As String)
        Select Case i
            Case "KG84"
                If k = "008" Then
                    k = "010"
                ElseIf k = "010" Then
                    k = "013"
                ElseIf k = "013" Then
                    k = "014"
                ElseIf k = "014" Then
                    k = "015"
                ElseIf k = "015" Then
                    k = "016"
                ElseIf k = "016" Then
                    k = "017"
                ElseIf k = "017" Then
                    k = "018"
                ElseIf k = "018" Then
                    k = "019"
                ElseIf k = "019" Then
                    k = "020"
                ElseIf k = "020" Then
                    k = "021"
                ElseIf k = "021" Then
                    k = "131"
                ElseIf k = "131" Then
                    k = "132"
                ElseIf k = "132" Then
                    k = "137"
                ElseIf k = "137" Then
                    k = "138"
                ElseIf k = "138" Then
                    k = "139"
                ElseIf k = "139" Then
                    k = "140"
                ElseIf k = "140" Then
                    k = "141"
                ElseIf k = "141" Then
                    k = "142"
                ElseIf k = "142" Then
                    k = "143"
                ElseIf k = "143" Then
                    k = "144"
                ElseIf k = "144" Then
                    k = "145"
                ElseIf k = "145" Then
                    k = "200"
                ElseIf k = "200" Then
                    k = "201"
                ElseIf k = "201" Then
                    k = "202"
                ElseIf k = "202" Then
                    k = "008"
                Else
                    k = "008"
                End If
            Case "VINSON"
                If k = "132" Then
                    k = "202"
                ElseIf k = "202" Then
                    k = "132"
                Else
                    k = "132"
                End If
            Case "FASCINATOR"
                k = "F12"
            Case "ANDVT"
                If k = "008" Then
                    k = "010"
                ElseIf k = "010" Then
                    k = "008"
                Else
                    k = "008"
                End If

        End Select
    End Sub

End Module
