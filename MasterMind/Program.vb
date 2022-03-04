Module Program
    Public counter = 0
    Sub Main()
        'Create new Master Class Object
        Dim Master As New Master
        'Run the Master method from Master
        Master.Master()
        'Create a new ConsoleMaster Object and pass the Master object
        Dim ConsoleMaster As New ConsoleMaster(Master)
        'Create an empty string for recent inputs
        Dim bisherigeEingabe As String = ""
        'Create a boolean to check if an error occured
        Dim err As Boolean = False
        'While True loop during the game
        Do While True
            'Clear console and show game rules
            Console.Clear()
            Console.WriteLine(ConsoleMaster.spielRegel() + vbCrLf)
            'ConsoleMaster.cheat()
            'Do not try to print recent guesses if there are none
            If counter > 0 Then
                'Check if an error occured during the last input
                If Not err Then
                    bisherigeEingabe += "-----" + vbCrLf
                    bisherigeEingabe += ConsoleMaster.printZeile(counter - 1) + " - "
                    Dim Erg As Integer() = ConsoleMaster.printErg(counter - 1)
                    bisherigeEingabe += "Schwarze Stifte: " + Convert.ToString(Erg(0)) + "  Weiﬂe Stifte: " + Convert.ToString(Erg(1)) + vbCrLf
                    bisherigeEingabe += "-----" + vbCrLf
                End If
                'Write the recent guesses to the console
                Console.WriteLine(bisherigeEingabe)
                'Check if the game has been won
                If ConsoleMaster.gewonnen() Then
                    Exit Do
                End If
            End If
            'Get user input and check if it's valid
            If Not ConsoleMaster.eingabe() Then
                err = True
                Continue Do
            Else
                err = False
            End If
            'Increase the counter by 1 every guess
            counter += 1
        Loop

    End Sub
End Module
