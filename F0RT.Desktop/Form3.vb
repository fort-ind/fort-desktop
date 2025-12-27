Imports Microsoft.Win32

Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = 100
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)

        If ProgressBar1.Value >= ProgressBar1.Maximum Then
            Timer1.Stop()

            ' --- Check policy before loading Form1 ---
            If IsPolicyEnabled() Then
                MsgBox(
                    "Fort.ind Desktop has been disabled by your administrator.",
                    MsgBoxStyle.Critical,
                    "Access Denied"
                )
                Application.Exit()
            Else
                Form1.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Function IsPolicyEnabled() As Boolean
        Try
            Dim key = Registry.LocalMachine.OpenSubKey(
                "Software\Fort.ind\Desktop\Policies", False)

            If key IsNot Nothing Then
                Dim v = key.GetValue("ProhibitAccessToFortindDesktop", 0)

                If CInt(v) = 1 Then
                    Return True
                End If
            End If

        Catch ex As Exception
            ' Optional: handle registry read error
        End Try

        Return False
    End Function

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
