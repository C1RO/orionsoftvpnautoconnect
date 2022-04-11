﻿Imports System.ComponentModel
Imports System.Net.NetworkInformation
Imports System.Text
Imports Microsoft.VisualBasic.Devices

Partial Public Class OrionVpn
    Public Sub New()
        InitializeComponent()

        Me.WindowState = FormWindowState.Minimized
        Timer1.Start()
        Timer2.Start()

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
        Shell(cmd, AppWinStyle.Hide, True)
        CheckVpnConnection(TextBox3.Text)


    End Sub

    Private Sub VpnDisconnect(server As String)

        Shell("cmd.exe /c rasdial " & server & " /disconnect ", AppWinStyle.Hide, True)
        CheckVpnConnection(TextBox3.Text)

    End Sub
    Private Sub CheckVpnConnection(server As String)


        Dim niVPN As NetworkInterface() =
         NetworkInterface.GetAllNetworkInterfaces

        Dim blnExist As Boolean =
         niVPN.AsEnumerable().Any(Function(x) x.Name = server)

        If blnExist Then

            MessageBox.Show("Vpn Conectada Correctamente")
            LabelControl1.Text = "Conectado"
            LabelControl1.ForeColor = Color.Green

        Else

            MessageBox.Show("Vpn Desconectada")
            LabelControl1.Text = "Desconectado"
            LabelControl1.ForeColor = Color.Red
        End If






    End Sub
    Private Sub AutoConnect(server As String)


        Dim niVPN As NetworkInterface() =
         NetworkInterface.GetAllNetworkInterfaces

        Dim blnExist As Boolean =
         niVPN.AsEnumerable().Any(Function(x) x.Name = server)

        If blnExist Then

            LabelControl1.Text = "Conectado"
            LabelControl1.ForeColor = Color.Green

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
        'Load saved info
        TextBox1.Text = My.Settings.Password
        TextBox2.Text = My.Settings.User
        TextBox3.Text = My.Settings.Server
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

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'SAVE INFO
        My.Settings.User = TextBox2.Text
        My.Settings.Server = TextBox3.Text
        My.Settings.Password = TextBox1.Text
        My.Settings.Save()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'UNSAVE INFO
        My.Settings.User = ""
        My.Settings.Server = ""
        My.Settings.Password = ""
        My.Settings.Save()
    End Sub

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControl1.Click

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Visible = False
                NotifyIcon1.Visible = True
            End If




        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            NotifyIcon1.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        AutoConnect(TextBox3.Text)
        CheckVpnConnection(TextBox3.Text)
        Timer2.Stop()

    End Sub
End Class
