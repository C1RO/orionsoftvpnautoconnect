﻿Imports System.Net.NetworkInformation


Partial Public Class OrionVpn
    Public Sub New()
        InitializeComponent()
        Timer1.Start()
        Me.WindowState = FormWindowState.Minimized

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

            LabelControl1.Text = "Conectado"
            LabelControl1.ForeColor = Color.Green

        Else

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

        Timer1.Start()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        VpnDisconnect(TextBox3.Text)
        Timer1.Stop()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LabelControl1.Text = "Checking"
        LabelControl1.ForeColor = Color.Yellow
        CheckVpnConnection(TextBox3.Text)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load saved info
        TextBox1.Text = My.Settings.Password
        TextBox2.Text = My.Settings.User
        TextBox3.Text = My.Settings.Server
        VpnConnect(TextBox2.Text, TextBox1.Text, TextBox3.Text)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        AutoConnect(TextBox3.Text)
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
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.Visible = False
                NotifyIcon1.Visible = True
            End If




        Catch ex As Exception




        End Try
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Try
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
            NotifyIcon1.Visible = False

        Catch ex As Exception


        End Try
    End Sub
    Dim ShortcutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "/OrionVpnAuto.lnk"

    Private Sub CreateShortCut(File As String, ShortCutPath As String)
        Dim oShell As Object
        Dim oLink As Object


        Try

            oShell = CreateObject("WScript.Shell")
            oLink = oShell.CreateShortcut(ShortCutPath)
            oLink.IconLocation = File
            oLink.TargetPath = File
            oLink.Arguments = ""
            oLink.WindowStyle = 1
            oLink.Save()
        Catch ex As Exception

        End Try
    End Sub








    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CreateShortCut(Application.ExecutablePath, ShortcutPath)
    End Sub
End Class


