Module Program
    Public counter = 0
    Sub Main()
        Dim Master As New Master
        Master.Master()
        Dim ConsoleMaster As New ConsoleMaster(Master)
        ConsoleMaster.spielRegel()
        Console.WriteLine()
        ConsoleMaster.eingabe()
        Do While True
            Console.Clear()
            ConsoleMaster.spielRegel()
            Console.WriteLine()
            If counter > 0 Then
                For i = 0 To counter
                    ConsoleMaster.printZeile(counter)
                    ConsoleMaster.printErg(counter)
                Next
            End If
            Console.WriteLine(counter)
            ConsoleMaster.eingabe()
            If ConsoleMaster.gewonnen() Then
                Exit Do
            End If
        Loop

    End Sub
End Module
