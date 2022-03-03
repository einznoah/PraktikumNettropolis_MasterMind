Imports NUnit.Framework

Namespace TestProject1

    Public Class Tests
        <SetUp>
        Public Sub Setup()
        End Sub

        <Test>
        Public Sub startTest()
            Dim Master As New MasterMind.Master
            Master.start()
            Assert.IsTrue(Master.zahl(0) <> 0)
        End Sub

        <Test>
        Public Sub getSchwarzTest()
            Dim Master As New MasterMind.Master
            Master.start()
            Dim solution As Integer() = Master.zahl
            Dim richtigeZahlen As Integer = Master.getSchwarz(solution)
            Assert.IsTrue(richtigeZahlen = 5)
        End Sub

        <Test>
        Public Sub getWeissTest()
            Dim Master As New MasterMind.Master
            Master.start()
            Dim solution As Integer() = Master.zahl
            Dim falscherPlatzZahlen As Integer = Master.getWeiss(solution)
            Assert.IsTrue(falscherPlatzZahlen = 0)
        End Sub

        <Test>
        Public Sub printErgTest1()
            Dim Master As New MasterMind.Master
            Master.Master()
            Dim ConsoleMaster As New MasterMind.ConsoleMaster(Master)
            ConsoleMaster.arr = {Master.zahl(0) - 1, Master.zahl(1) - 1, Master.zahl(2) - 1, Master.zahl(3) - 1, Master.zahl(4) - 1}
            Dim Fout() As Integer = ConsoleMaster.printErg(0)
            Assert.AreEqual(Fout(0), 0)
        End Sub

        <Test>
        Public Sub printErgTest2()
            Dim Master As New MasterMind.Master
            Master.Master()
            Dim ConsoleMaster As New MasterMind.ConsoleMaster(Master)
            ConsoleMaster.arr = {Master.zahl(0), Master.zahl(1), Master.zahl(2), Master.zahl(3), Master.zahl(4)}
            Dim Fout() As Integer = ConsoleMaster.printErg(0)
            Assert.AreEqual(Fout(0), 5)
        End Sub

        <Test>
        Public Sub printErgTest3()
            Dim Master As New MasterMind.Master
            Master.Master()
            Dim ConsoleMaster As New MasterMind.ConsoleMaster(Master)
            ConsoleMaster.arr = Master.zahl
            Dim Fout() As Integer = ConsoleMaster.printErg(0)
            Assert.AreEqual(Fout(1), 0)
        End Sub


    End Class

End Namespace