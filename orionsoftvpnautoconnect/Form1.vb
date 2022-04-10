Imports System.ComponentModel
Imports System.Net.NetworkInformation
Imports System.Text
Imports Microsoft.VisualBasic.Devices

Partial Public Class OrionVpn
    Public Sub New()
        InitializeComponent()
        Timer1.Start()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        'USUARIO


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'contraseña


    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        'SERVIDOR



    End Sub
    Private Sub VpnConnect(uservpn As String, passvpn As String, server As String)

        Dim cmd = "cmd.exe /c rasdial " & server & " " & uservpn & " " & passvpn & ""
        Shell(cmd, AppWinStyle.NormalFocus, True)



    End Sub

    Private Sub VpnDisconnect(server As String)

        Shell("cmd.exe /c rasdial " & server & " /disconnect ", AppWinStyle.NormalFocus, True)

    End Sub
    Private Sub CheckVpnConnection(server As String)


        Dim niVPN As NetworkInterface() =
         NetworkInterface.GetAllNetworkInterfaces

        Dim blnExist As Boolean =
         niVPN.AsEnumerable().Any(Function(x) x.Name = server)

        If blnExist Then

            MessageBox.Show("Vpn Conectada Correctamente")

        Else

            MessageBox.Show("Error vpn no encontrada")

        End If






    End Sub
    Private Sub AutoConnect(server As String)


        Dim niVPN As NetworkInterface() =
         NetworkInterface.GetAllNetworkInterfaces

        Dim blnExist As Boolean =
         niVPN.AsEnumerable().Any(Function(x) x.Name = server)

        If blnExist Then



        Else

            VpnConnect(TextBox2.Text, TextBox1.Text, TextBox3.Text)

        End If






    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'CONECTAR
        VpnConnect(TextBox2.Text, TextBox1.Text, TextBox3.Text)



    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        VpnDisconnect(TextBox3.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CheckVpnConnection(TextBox3.Text)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        AutoConnect(TextBox3.Text)
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
