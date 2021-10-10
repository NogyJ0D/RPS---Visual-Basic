Public Class Form1
    'Declare Sub Sleep Lib "kernel32" Alias "Sleep" (ByVal dwMilliseconds As Long)

    Dim ImgPiedra As Image = My.Resources.Recursos.Rock
    Dim ImgPapel As Image = My.Resources.Recursos.Paper
    Dim ImgTijera As Image = My.Resources.Recursos.Scissor
    Dim ImgStart As Image = My.Resources.Recursos.rock_paper_scissors

    Dim Seleccion As Integer
    Dim Rondas As Integer = 0
    Dim Ganadas As Integer = 0
    Dim Perdidas As Integer = 0
    Private Sub wait(ByVal interval As Integer)     'Codigo para esperar tiempo, totalmente robado
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblUsuario.Text = Nombre.User
    End Sub

    Private Sub BtnUserPiedra_Click(sender As Object, e As EventArgs) Handles BtnUserPiedra.Click
        Seleccion = 1
        LblUserEleccion.Text = "Tu elección: Piedra"
        PcbUsuario.Image = ImgPiedra
    End Sub

    Private Sub BtnUserPapel_Click(sender As Object, e As EventArgs) Handles BtnUserPapel.Click
        Seleccion = 2
        LblUserEleccion.Text = "Tu elección: Papel"
        PcbUsuario.Image = ImgPapel
    End Sub

    Private Sub BtnUserTijera_Click(sender As Object, e As EventArgs) Handles BtnUserTijera.Click
        Seleccion = 3
        LblUserEleccion.Text = "Tu elección: Tijera"
        PcbUsuario.Image = ImgTijera
    End Sub

    Public Sub BtnComenzar_Click(sender As Object, e As EventArgs) Handles BtnComenzar.Click
        If Seleccion = 1 Or Seleccion = 2 Or Seleccion = 3 Then
            Dim SelMaquina As Integer
            SelMaquina = Int((3 * Rnd()) + 1)
            Dim Resultado As Integer = 0
            LblIndicador.Text = "="

            BtnComenzar.Enabled = False         ' Comenzar conteo
            BtnUserPiedra.Enabled = False
            BtnUserPapel.Enabled = False
            BtnUserTijera.Enabled = False

            BtnComenzar.Text = "Piedra"
            PcbUsuario.Image = ImgPiedra
            PcbMaquina.Image = ImgPiedra
            Console.Beep()
            wait(500)

            BtnComenzar.Text = "Papel"
            PcbUsuario.Image = ImgPapel
            PcbMaquina.Image = ImgPapel
            Console.Beep()
            wait(500)

            BtnComenzar.Text = "Tijera"
            PcbUsuario.Image = ImgTijera
            PcbMaquina.Image = ImgTijera
            Console.Beep()
            wait(500)                           ' Terminar conteo

            If Seleccion = 1 Then
                PcbUsuario.Image = ImgPiedra
            ElseIf Seleccion = 2 Then
                PcbUsuario.Image = ImgPapel
            Else
                PcbUsuario.Image = ImgTijera
            End If

            If SelMaquina = 1 Then
                PcbMaquina.Image = ImgPiedra
                LblMaquinaEleccion.Text = "Su elección: Piedra"
            ElseIf SelMaquina = 2 Then
                PcbMaquina.Image = ImgPapel
                LblMaquinaEleccion.Text = "Su elección: Papel"
            Else
                PcbMaquina.Image = ImgTijera
                LblMaquinaEleccion.Text = "Su elección: Tijera"
            End If

            If Seleccion = 1 And SelMaquina = 3 Then        ' Piedra
                Resultado = 1
            ElseIf Seleccion = 1 And SelMaquina = 1 Then
                Resultado = 2
            ElseIf Seleccion = 1 And SelMaquina = 2 Then
                Resultado = 3
            ElseIf Seleccion = 2 And SelMaquina = 1 Then    ' Papel
                Resultado = 1
            ElseIf Seleccion = 2 And SelMaquina = 2 Then
                Resultado = 2
            ElseIf Seleccion = 2 And SelMaquina = 3 Then
                Resultado = 3
            ElseIf Seleccion = 3 And SelMaquina = 2 Then    ' Tijera
                Resultado = 1
            ElseIf Seleccion = 3 And SelMaquina = 3 Then
                Resultado = 2
            ElseIf Seleccion = 3 And SelMaquina = 1 Then
                Resultado = 3
            End If

            If Resultado = 1 Then
                LblGano.Text = $"Ganó: {LblUsuario.Text}"
                Rondas += 1
                Ganadas += 1
                LblRondas.Text = $"Rondas: {Rondas}"
                LblGanadas.Text = $"Ganadas: {Ganadas}"
                LblPerdidas.Text = $"Perdidas: {Perdidas}"
                LblIndicador.Text = ">"
            ElseIf Resultado = 2 Then
                LblGano.Text = "Empate"
                Rondas += 1
                LblRondas.Text = $"Rondas: {Rondas}"
                LblGanadas.Text = $"Ganadas: {Ganadas}"
                LblPerdidas.Text = $"Perdidas: {Perdidas}"
                LblIndicador.Text = "="
            Else
                LblGano.Text = "Ganó: Máquina"
                Rondas += 1
                Perdidas += 1
                LblRondas.Text = $"Rondas: {Rondas}"
                LblGanadas.Text = $"Ganadas: {Ganadas}"
                LblPerdidas.Text = $"Perdidas: {Perdidas}"
                LblIndicador.Text = "<"
            End If

            ' Codigo de reinicio
            wait(500)
            BtnComenzar.Enabled = True
            BtnComenzar.Text = "Comenzar"
            BtnUserPiedra.Enabled = True
            BtnUserPapel.Enabled = True
            BtnUserTijera.Enabled = True
        Else
            Exit Sub    ' No hacer nada
        End If
    End Sub
End Class
