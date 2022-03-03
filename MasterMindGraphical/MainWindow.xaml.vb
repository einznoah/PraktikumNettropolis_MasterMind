Class MainWindow
    Public counter = 0
    Dim Master As New MasterMind.Master
    Dim ConsoleMaster As New MasterMind.ConsoleMaster(Master)
    Dim bisherigeEingabe As String
    Dim err As Boolean

    Public Sub Start(sender As Object, e As EventArgs) Handles Me.ContentRendered
        LabelRules.Text = ConsoleMaster.spielRegel()
        'Create an empty string for recent inputs
        bisherigeEingabe = ""
        'Create a boolean to check if an error occured
        err = False
        'While True loop during the game
        'Clear console and show game rules
        LabelLastGuess.Text = ""
        Master.Master()
    End Sub

    Public Sub Game()
        'Get user input and check if it's valid
        If Not eingabe() Then
            err = True
            MessageBox.Show("Ungültige Eingabe")
            Exit Sub
        Else
            err = False
            counter += 1
        End If
        'ConsoleMaster.cheat()
        'Do not try to print recent guesses if there are none
        'Check if an error occured during the last input
        If Not err Then
            bisherigeEingabe += "-----" + vbCrLf
            bisherigeEingabe += ConsoleMaster.printZeile(counter - 1)
            Dim Erg As Integer() = ConsoleMaster.printErg(counter - 1)
            bisherigeEingabe += "Schwarze Stifte: " + Convert.ToString(Erg(0)) + "  Weiße Stifte: " + Convert.ToString(Erg(1)) + vbCrLf
            bisherigeEingabe += "-----" + vbCrLf
            'Increase the counter by 1 every guess
        End If
        'Write the recent guesses to the TextBox
        LabelLastGuess.Text = bisherigeEingabe
        'Check if the game has been won
        If ConsoleMaster.gewonnen() Then
            endGame(counter)
        End If
    End Sub

    Function eingabe() As Boolean
        Dim eingabeTmp As String = Convert.ToString(Console.ReadLine())
        Dim eingaben = {TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text}
        'For loop für alle 5 Werte
        For i = 0 To 4
            'Wert in Integer umwandeln
            Try
                eingaben(i) = Convert.ToInt32(eingaben(i))
                'Falls dabei ein Fehler auftritt wird dies in der Konsole ausgegeben und False zurückgegeben
            Catch ex As Exception
                Return False
            End Try
            'Wenn alle Werte in Integer umgewandelt wurden, werden diese zum Array hinzugefügt
            Array.Resize(ConsoleMaster.arr, ConsoleMaster.arr.Length + 1)
            ConsoleMaster.arr(ConsoleMaster.arr.Length - 1) = eingaben(i)
        Next
        'MessageBox.Show("added values to array: " + Convert.ToString(ConsoleMaster.arr(0)) + " " + Convert.ToString(ConsoleMaster.arr(1)) + " " + Convert.ToString(ConsoleMaster.arr(2)) + " " + Convert.ToString(ConsoleMaster.arr(3)) + " " + Convert.ToString(ConsoleMaster.arr((4))))
        'und True zurückgegeben
        Return True
    End Function

    Sub endGame(counter As Integer)
        MessageBox.Show("Du hast gewonnen! Gebrauchte Versuche: " + Convert.ToString(counter))
    End Sub

    Sub ButtonSubmit_Click(sender As Object, e As RoutedEventArgs) Handles ButtonSubmit.Click
        Game()
    End Sub

    Sub OnKeyDownHandler(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Return Then
            ButtonSubmit_Click(sender, e)
        End If
    End Sub
End Class
