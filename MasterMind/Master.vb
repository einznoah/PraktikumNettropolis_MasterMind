Public Class Master
    ''' <summary>
    ''' 5 elementiges Array, enthält die erratenden Zahlen
    ''' </summary>
    Public zahl(4) As Integer

    Public Sub Master()
        'Starte das Spiel
        start()
    End Sub

    ''' <summary>
    ''' Legt 5 unterschiedliche Zufallszahlen fest
    ''' </summary>
    Sub start()
        'initialsiere den Zufallsgenerator
        Randomize()
        'Erstelle ein Integer HashSet
        Dim RememberSet As New HashSet(Of Integer)
        'Solange unter 5 Werte im HashSet sind, füge zufällige Werte hinzu
        While RememberSet.Count < 5
            Dim randomNumber = Convert.ToInt32(7 * Rnd() + 1)
            RememberSet.Add(randomNumber)
        End While
        'Setze die Zufallszahlen in das Array für die zu erratenden Zahlen
        zahl = RememberSet.ToArray
    End Sub

    ''' <summary>
    ''' Gibt zurück, wie viele Zahlen am richtigem Platz sind
    ''' </summary>
    ''' <param name="zahlen">Array mit Zahlen</param>
    ''' <returns>Anzal von Zahlen am richtigem Platz</returns>
    Function getSchwarz(zahlen As Integer()) As Integer
        'Counter Variable für richtige Zahlen wird deklariert
        Dim richtigeZahlen As Integer = 0
        'Für alle Werte im Werte-Array
        For i = 0 To zahl.Length - 1
            'Wird der Wert mit dem übergeben Wert verglichen
            If zahlen(i) = zahl(i) Then
                'Falls die Werte gleich sind, erhöhe richtigeZahlen um 1
                richtigeZahlen += 1
            End If
        Next
        'und gebe die Anzahl an richtigen Zahlen an der richtigen Stelle zurück
        Return richtigeZahlen
    End Function

    ''' <summary>
    ''' Gibt zurück, wie viele Zahlen vorhanden, aber am falschem Platz sind
    ''' </summary>
    ''' <param name="zahlen">Array mit Zahlen</param>
    ''' <returns>Anzahl von vorhandenen Zahlen am falschem Platz</returns>
    Function getWeiss(zahlen As Integer()) As Integer
        'Erstelle eine Counter Variable für vorhandene Zahlen
        Dim vorhandeneZahlen As Integer = 0
        'Für jeden Wert im Werte-Array
        For i = 0 To zahl.Length - 1
            'wird geprüft ob der übergebene Wert vorhanden ist
            If zahl.Contains(zahlen(i)) Then
                'aber an der falschen Stelle
                If zahl(i) <> zahlen(i) Then
                    'Wenn ja erhöhe vorhandeneZahlen um 1
                    vorhandeneZahlen += 1
                End If
            End If
        Next
        'Gebe die vorhandenen Zahlen zurück
        Return vorhandeneZahlen
    End Function

End Class
