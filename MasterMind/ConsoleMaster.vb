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
    Function cheat() As String
        Dim result As String = ""
        result += "Lösung: "
        For Each i In m.zahl
            result += " " + Convert.ToString(i)
        Next
        Return result
    End Function

    ''' <summary>
    ''' Eine komplette Benutzereingabes
    ''' </summary>
    Function eingabe() As Boolean
        'Eingabe in Konsole und Umwandlung in einzelne Strings
        Console.Write("Neue Eingabe (getrennt mit Leerzeichen): ")
        Dim eingabeTmp As String = Convert.ToString(Console.ReadLine())
        Dim eingaben = Split(eingabeTmp)
        'For loop für alle 5 Werte
        For i = 0 To 4
            'Wert in Integer umwandeln
            Try
                eingaben(i) = Convert.ToInt32(eingaben(i))
                'Falls dabei ein Fehler auftritt wird dies in der Konsole ausgegeben und False zurückgegeben
            Catch ex As Exception
                Console.WriteLine()
                Console.WriteLine("Ungültige Eingabe!")
                Console.ReadLine()
                Return False
            End Try
            'Wenn alle Werte in Integer umgewandelt wurden, werden diese zum Array hinzugefügt
            Array.Resize(arr, arr.Length + 1)
            arr(arr.Length - 1) = eingaben(i)
        Next
        'und True zurückgegeben
        Return True
    End Function

    ''' <summary>
    ''' Liefert an das Hauptprogramm die Information zurück, ob die Kombination herausgefunden wurde
    ''' </summary>
    Function gewonnen() As Boolean
        'Variablen für die Anzahl an richtigen Zahlen und die letze Eingabe sowie eine Index Variable
        Dim richtigeZahlen As Integer = 0
        Dim letzeEingabe() As Integer = {0, 0, 0, 0, 0}
        Dim index As Integer = 0
        'Falls das Werte-Array keine Einträge hat, False zurückgeben
        If arr.Length = 0 Then
            Return False
        End If
        'Für jeden der letzen 5 Werte (letze Eingabe)
        For i = arr.Length - 5 To arr.Length - 1
            'wird der Wert zum letzeEingabe Array hinzugefügt
            letzeEingabe(index) = arr(i)
            'und der Index um 1 erhöht
            index += 1
        Next
        'Für alle 5 Werte
        For i = 0 To 4
            'wird abgeglichen ob der Wert der Lösung entspricht
            If letzeEingabe(i) = m.zahl(i) Then
                'falls ja, werden die richtigen Zahlen um 1 erhöht
                richtigeZahlen += 1
            End If
        Next
        'Falls 5 richtige Zahlen vorhanden sind, wird eine Nachricht ausgegeben und True zurückgegeben
        If richtigeZahlen = 5 Then
            Console.WriteLine("Du hast gewonnen!" + vbCrLf + "Gebrauchte Versuche: {0}", counter)
            Return True
        Else
            'Andernfalls wird False zurückgegeben
            Return False
        End If
    End Function

    ''' <summary>
    ''' Schreibt die Benutzereingabe an die richtige Stelle des Bildschirms
    ''' </summary>
    ''' <param name="Zeile">Stelle</param>
    Function printZeile(Zeile As Integer)
        'Den Variablen j und k wird der Wert von der übergeben Variable Zeile zugewiesen. Ein leerer String result wird deklariert
        Dim j As Integer = Zeile
        Dim k As Integer = Zeile
        Dim result As String = ""
        'Für alle Werte in der angegebenen Zeile 
        For i = Zeile * 5 To Zeile * 5 + 5
            'wird dem String ein Leerzeichen und der Wert hinzugefügt
            result += " " + Convert.ToString(arr(i))
            'und j um 1 erhöht
            j += 1
            'falls j um 5 erhöht wurde vom Ursprungswert
            If j = k + 5 Then
                'Füge einen Zeilenumbruch zum result hinzu
                'result += vbCrLf
                'und gebe result zurück
                Return result
            End If
        Next
        'Andernfalls übergebe "Error"
        Return "Error"
    End Function

    ''' <summary>
    ''' Schreibt die Anzahl der schwarzen, bzw. weissen Stifte auf den Bildschirm
    ''' </summary>
    ''' <param name="Zeile"></param>
    Function printErg(Zeile As Integer)
        'Der Variable j wird der Wert von der übergebenen Variable Zeile zugewiesen
        Dim j As Integer = Zeile
        'ein Array für die letze Eingabe erstellt
        Dim letzeEingabe() As Integer = {0, 0, 0, 0, 0}
        'und eine Variable Index mit dem Wert 0 deklariert
        Dim index As Integer = 0
        'Für alle Werte in der angegebenen Zeile
        For i = Zeile * 5 To Zeile * 5 + 4
            'Wird versucht den Wert von dem Werte-Array zuzuweisen
            Try
                letzeEingabe(index) = arr(i)
            Catch ex As IndexOutOfRangeException
                'Falls ein Fehler auftritt, breche den For-Loop ab
                Exit For
            End Try
            'erhöhe den Index um 1
            index += 1
        Next
        'Es wird ein Array mit den schwarzen und weißen Stiften der letzten Eingabe erstellt und zurückgegeben
        Dim schwarzeStifte As Integer = m.getSchwarz(letzeEingabe)
        Dim weißeStifte As Integer = m.getWeiss(letzeEingabe)
        Return {schwarzeStifte, weißeStifte}
    End Function

    ''' <summary>
    ''' Zeigt die Spielregeln
    ''' </summary>
    Function spielRegel()
        Return "Ein Spieler legt zu Beginn einen fünfstelligen Farbcode fest, der aus acht Farben ausgewählt wird. Jede Farbe kommt dabei nur einmal vor. Der andere Spieler versucht, den Code herauszufinden. Dazu setzt er einen gleichartigen Farbcode als Frage; beim ersten Zug blind geraten, bei den weiteren Zügen mit Hilfe der Antworten zu den vorangegangenen Zügen. Auf jeden Zug hin bekommt der Rater die Information, wie viele Stifte er in Farbe und Position richtig gesetzt hat und wie viele Stifte zwar die richtige Farbe haben, aber an einer falschen Position stehen. Ein Treffer in Farbe und Position wird durch einen schwarzen Stift angezeigt, ein farblich richtiger Stift an falscher Stelle durch einen weißen Stift. Alle Fragen und Antworten bleiben bis zum Ende des Spiels sichtbar."
    End Function
End Class
