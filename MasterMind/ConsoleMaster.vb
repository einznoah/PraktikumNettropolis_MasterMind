Public Class ConsoleMaster
    Private m As Master
    Public Sub New(master As Master)
        m = master
    End Sub
    ''' <summary>
    ''' Feld, das die Benutzereingaben enthält
    ''' </summary>
    Public arr() As Integer = {}
    ''' <summary>
    ''' Ein Objekt der Klasse Master, mit dem die Klasse ConsoleMaster arbeitet.
    ''' </summary>

    ''' <summary>
    ''' Schreibt die Code-Zahlen auf den Bildschirm
    ''' </summary>
    Sub cheat()
        Console.Write("Lösung: ")
        For Each i In m.zahl
            Console.Write("{0} ", i)
        Next
        Console.WriteLine()
    End Sub

    ''' <summary>
    ''' Eine komplette Benutzereingabes
    ''' </summary>
    Sub eingabe()
        Console.Write("Neue Eingabe (getrennt mit Leerzeichen): ")
        Dim eingabeTmp As String = Convert.ToString(Console.ReadLine())
        Dim eingaben = Split(eingabeTmp)
        For i = 0 To 4
            Try
                eingaben(i) = Convert.ToInt32(eingaben(i))
            Catch ex As Exception
                Console.WriteLine()
                Console.WriteLine("Ungültige Eingabe!")
                Console.ReadLine()
                Exit For
            End Try
            Array.Resize(arr, arr.Length + 1)
            arr(arr.Length - 1) = eingaben(i)
            counter += 1
        Next

    End Sub

    ''' <summary>
    ''' Liefert an das Hauptprogramm die Information zurück, ob die Kombination herausgefunden wurde
    ''' </summary>
    Function gewonnen() As Boolean
        Dim richtigeZahlen As Integer = 0
        Dim letzeEingabe() As Integer = {0, 0, 0, 0, 0}
        Dim index As Integer = 0
        If arr.Length = 0 Then
            Return False
        End If
        For i = arr.Length - 5 To arr.Length - 1
            letzeEingabe(index) = arr(i)
            index += 1
        Next
        For i = 0 To 4
            If letzeEingabe(i) = m.zahl(i) Then
                richtigeZahlen += 1
            End If
        Next
        If richtigeZahlen = 5 Then
            Console.WriteLine("Du hast gewonnen!")
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Schreibt die Benutzereingabe an die richtige Stelle des Bildschirms
    ''' </summary>
    ''' <param name="Zeile">Stelle</param>
    Sub printZeile(Zeile As Integer)
        Dim j As Integer = Zeile
        Dim k As Integer = Zeile
        For i = Zeile * 5 To Zeile * 5 + 5
            Try
                Console.Write("{0} ", arr(i))
            Catch ex As IndexOutOfRangeException
                Exit For
            End Try
            j += 1
            If j = k + 5 Then
                Console.WriteLine()
                Exit Sub
            End If
        Next
    End Sub

    ''' <summary>
    ''' Schreibt die Anzahl der schwarzen, bzw. weissen Stifte auf den Bildschirm
    ''' </summary>
    ''' <param name="Zeile"></param>
    Sub printErg(Zeile As Integer)
        Dim j As Integer = Zeile
        Dim letzeEingabe() As Integer = {0, 0, 0, 0, 0}
        Dim index As Integer = 0
        For i = Zeile * 5 To Zeile * 5 + 4
            Try
                letzeEingabe(index) = arr(i)
            Catch ex As IndexOutOfRangeException
                Exit For
            End Try
            index += 1
        Next
        Dim schwarzeStifte As Integer = m.getSchwarz(letzeEingabe)
        Dim weißeStifte As Integer = m.getWeiss(letzeEingabe)
        Console.Write("Anzahl schwarze Stifte: {0} ", schwarzeStifte)
        Console.WriteLine("Anzahl weiße Stifte: {0}", weißeStifte)
    End Sub

    ''' <summary>
    ''' Zeigt die Spielregeln
    ''' </summary>
    Sub spielRegel()
        Console.WriteLine("Ein Spieler legt zu Beginn einen fünfstelligen Farbcode fest, der aus acht Farben ausgewählt wird. Jede Farbe kommt dabei nur einmal vor. Der andere Spieler versucht, den Code herauszufinden. Dazu setzt er einen gleichartigen Farbcode als Frage; beim ersten Zug blind geraten, bei den weiteren Zügen mit Hilfe der Antworten zu den vorangegangenen Zügen. Auf jeden Zug hin bekommt der Rater die Information, wie viele Stifte er in Farbe und Position richtig gesetzt hat und wie viele Stifte zwar die richtige Farbe haben, aber an einer falschen Position stehen. Ein Treffer in Farbe und Position wird durch einen schwarzen Stift angezeigt, ein farblich richtiger Stift an falscher Stelle durch einen weißen Stift. Alle Fragen und Antworten bleiben bis zum Ende des Spiels sichtbar.")
    End Sub
End Class
