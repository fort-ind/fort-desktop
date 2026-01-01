Imports EO.WebBrowser
Imports Microsoft.Win32
Imports System.Diagnostics

Public Class Form1

    Private WithEvents colorDialog As New ColorDialog()
    Private WithEvents fontDialog As New FontDialog()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ---------------- Check master policy first ----------------
        If IsPolicyEnabled("ProhibitAccessToFortindDesktop") Then
            MsgBox("Fort.ind Desktop has been disabled by your administrator.", MsgBoxStyle.Critical, "Access Denied")
            Me.Close()
            Return
        End If

        ' Load initial URL
        WebView1.LoadUrl("https://www.fort1nd.com")

        ' Attach NewWindow event to force popups into current WebView
        AddHandler WebView1.NewWindow, AddressOf WebView1_NewWindow
    End Sub

    ' ---------------- Menu Click Handlers ----------------
    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs)
        WebView1.LoadUrl("https://www.fort1nd.com")
    End Sub

    Private Sub GamesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        WebView1.LoadUrl("https://www.fort1nd.com/games")
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs)
        WebView1.LoadUrl("https://files.fort1nd.com")
    End Sub

    Private Sub TheMsnFacilityToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MsgBox("lestercrest.001" & vbCrLf & "", 64, "...")
    End Sub


    Private Sub FortforumsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If IsPolicyEnabled("NoFortForums") Then
            MsgBox("Access to Fort Forums has been disabled by your administrator.", MsgBoxStyle.Critical, "Access Denied")
        Else
            WebView1.LoadUrl("https://forums.fort1nd.com")
        End If
    End Sub

    Private Sub JoinTheCoveforBetasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If IsPolicyEnabled("NoTheCove") Then
            MsgBox("Access to The Cove has been disabled by your administrator.", MsgBoxStyle.Critical, "Access Denied")
        Else
            Process.Start("https://discord.gg/NhYaaPFTYr")
        End If
    End Sub

    Private Sub FortgamesLIVEToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MsgBox("Ask lestercrest.001 about this program.", 64, "fort.games LIVE")
    End Sub

    Private Sub ArtspaceToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If IsPolicyEnabled("ProhibitTextart") Then
            MsgBox("Access to Textart has been disabled by your administrator.", MsgBoxStyle.Critical, "Access Denied")
        Else
            WebView1.LoadUrl("https://www.fort1nd.com/social/textart")
        End If
    End Sub


    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form2.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' Get the current EXE file name (e.g., "MyApp.exe")
        Dim exeName As String = Process.GetCurrentProcess().ProcessName & ".exe"

        ' Use cmd and taskkill to force-kill this EXE
        Process.Start("cmd.exe", "/c taskkill /f /im " & exeName)
    End Sub

    ' ---------------- EO WebBrowser: Force all popups into WebView1 ----------------
    Private Sub WebView1_NewWindow(sender As Object, e As NewWindowEventArgs)
        ' Prevent EO from opening a new WebView
        e.Accepted = False

        ' Load the popup URL in the current WebView1
        Me.BeginInvoke(Sub()
                           If Not String.IsNullOrEmpty(e.TargetUrl) Then
                               WebView1.LoadUrl(e.TargetUrl)
                           End If
                       End Sub)
    End Sub

    ' ---------------- Registry Policy Helper using Registry.GetValue ----------------
    Private Function IsPolicyEnabled(policyName As String) As Boolean
        Try
            Dim regPath As String = "HKEY_CURRENT_USER\Software\Fort.ind\Desktop\Policies"
            Dim value = Registry.GetValue(regPath, policyName, 0)
            Return value IsNot Nothing AndAlso Convert.ToInt32(value) = 1
        Catch ex As Exception
            MsgBox("Error reading registry: " & ex.Message, MsgBoxStyle.Critical, "Registry Error")
            Return False
        End Try
    End Function

    Private Sub EnabledisableFeaturesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim policyForm As New FormPolicyManager()
        policyForm.ShowDialog()
    End Sub

    Private Sub GoToRynizxxyzToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Process.Start("https://rynizx.xyz")
    End Sub

    Private Sub GoToBaldibaldimore1991nekoweborgToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Process.Start("https://baldibaldimore1991.nekoweb.org")
    End Sub

    Private Sub Fort10ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MsgBox("Details:" & vbCrLf & "version: Win10 21H2/22H2" & vbCrLf & "contact: lestercrest.001", 64, "fort10")
    End Sub

    Private Sub FortOSToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MsgBox("Ask Pingu for the fortOS! I do not have it", 64, "Information")
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        WebView1.LoadUrl("https://www.fort1nd.com")
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        WebView1.LoadUrl("https://www.fort1nd.com/games")
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        WebView1.LoadUrl("https://files.fort1nd.com")
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        MsgBox("There will be a betas page soon, during the time being, you can join the cove, contact rynizx or lestercrest.001" & vbCrLf & "", 64, "Information")
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)
        If IsPolicyEnabled("NoFortForums") Then
            MsgBox("Access to Fort Forums has been disabled by your administrator.", MsgBoxStyle.Critical, "Access Denied")
        Else
            WebView1.LoadUrl("https://forums.fort1nd.com")
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs)
        ' Get the current EXE file name (e.g., "MyApp.exe")
        Dim exeName As String = Process.GetCurrentProcess().ProcessName & ".exe"

        ' Use cmd and taskkill to force-kill this EXE
        Process.Start("cmd.exe", "/c taskkill /f /im " & exeName)
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs)
        If IsPolicyEnabled("ProhibitTextart") Then
            MsgBox("Access to Textart has been disabled by your administrator.", MsgBoxStyle.Critical, "Access Denied")
        Else
            WebView1.LoadUrl("https://www.fort1nd.com/social/textart")
        End If
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs)
        If IsPolicyEnabled("NoTheCove") Then
            MsgBox("Access to The Cove has been disabled by your administrator.", MsgBoxStyle.Critical, "Access Denied")
        Else
            Process.Start("https://discord.gg/NhYaaPFTYr")
        End If
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs)
        Process.Start("https://rynizx.xyz")
    End Sub

    Private Sub CoolPplToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs)
        Process.Start("https://baldibaldimore1991.nekoweb.org")
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs)
        Form2.Show()
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub HomeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        WebView1.LoadUrl("https://www.fort1nd.com")
    End Sub

    Private Sub GamesToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        WebView1.LoadUrl("https://www.fort1nd.com/games")
    End Sub

    Private Sub FilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilesToolStripMenuItem.Click
        WebView1.LoadUrl("https://files.fort1nd.com")
    End Sub

    Private Sub MenubarColorToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FortforumsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles FortforumsToolStripMenuItem.Click
        WebView1.LoadUrl("https://forums.fort1nd.com")
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Process.Start("cmd.exe", "/c taskkill /f /im " & Process.GetCurrentProcess().ProcessName & ".exe")
    End Sub

    Private Sub FortsocialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FortsocialToolStripMenuItem.Click
        WebView1.LoadUrl("https://social.fort1nd.com")
    End Sub

    Private Sub AboutToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Form2.Show()
    End Sub
End Class
