
Imports System.Net.NetworkInformation

Public Class Service1

    Public Sub DoThing(UserVpn As String, PassVpn As String, ServerVpn As String)

        Dim niVPN As NetworkInterface() =
         NetworkInterface.GetAllNetworkInterfaces

        Dim blnExist As Boolean =
         niVPN.AsEnumerable().Any(Function(x) x.Name = ServerVpn)

        If blnExist Then



        Else

            Dim cmd = "cmd.exe /c rasdial " & ServerVpn & " " & UserVpn & " " & PassVpn & ""
            Shell(cmd, AppWinStyle.Hide, True)

        End If


    End Sub





    Protected Overrides Sub OnStart(ByVal args() As String)




    End Sub

    Protected Overrides Sub OnStop()



    End Sub




End Class
