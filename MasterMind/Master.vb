Public Class Master
    ''' <summary>
    ''' 5 elementiges Array, enthält die erratenden Zahlen
    ''' </summary>
    Public zahl(4) As Integer

    Public Sub Master()
        start()
    End Sub

    ''' <summary>
    ''' Legt 5 unterschiedliche Zufallszahlen fest
    ''' </summary>
    Sub start()
        Randomize()
        zahl(0) = Convert.ToInt32(7 * Rnd() + 1)
        zahl(1) = Convert.ToInt32(7 * Rnd() + 1)
        zahl(2) = Convert.ToInt32(7 * Rnd() + 1)
        zahl(3) = Convert.ToInt32(7 * Rnd() + 1)
        zahl(4) = Convert.ToInt32(7 * Rnd() + 1)
    End Sub

    ''' <summary>
    ''' Gibt zurück, wie viele Zahlen am richtigem Platz sind
    ''' </summary>
    ''' <param name="zahlen">Array mit Zahlen</param>
    ''' <returns>Anzal von Zahlen am richtigem Platz</returns>
    Function getSchwarz(zahlen As Integer()) As Integer
        Dim richtigeZahlen As Integer = 0
        For i = 0 To zahl.Length - 1
            If zahlen(i) = zahl(i) Then
                richtigeZahlen += 1
            End If
        Next
        Return richtigeZahlen
    End Function

    ''' <summary>
    ''' Gibt zurück, wie viele Zahlen vorhanden, aber am falschem Platz sind
    ''' </summary>
    ''' <param name="zahlen">Array mit Zahlen</param>
    ''' <returns>Anzahl von vorhandenen Zahlen am falschem Platz</returns>
    Function getWeiss(zahlen As Integer()) As Integer
        Dim vorhandeneZahlen As Integer = 0
        For i = 0 To zahl.Length - 1
            If zahl.Contains(zahlen(i)) Then
                If zahl(i) <> zahlen(i) Then
                    vorhandeneZahlen += 1
                End If
            End If
        Next
        Return vorhandeneZahlen
    End Function

End Class
