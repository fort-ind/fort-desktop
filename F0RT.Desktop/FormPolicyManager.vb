Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class FormPolicyManager
    Inherits Form

    ' Controls
    Private chkDesktop As New CheckBox()
    Private chkTextart As New CheckBox()
    Private chkTheCove As New CheckBox()
    Private chkForums As New CheckBox()

    Private btnSavePolicies As New Button()
    Private btnReEnable As New Button()
    Private btnSchoolPolicies As New Button()

    Public Sub New()
        ' Form properties
        Me.Text = "Fort.ind Policy Manager"
        Me.Size = New Drawing.Size(420, 260)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Initialize checkboxes
        chkDesktop.Text = "Prohibit Access to Fort.ind Desktop"
        chkDesktop.AutoSize = True
        chkDesktop.Location = New Drawing.Point(20, 20)

        chkTextart.Text = "Prevent Access to Textart"
        chkTextart.AutoSize = True
        chkTextart.Location = New Drawing.Point(20, 50)

        chkTheCove.Text = "Prevent Access to The Cove"
        chkTheCove.AutoSize = True
        chkTheCove.Location = New Drawing.Point(20, 80)

        chkForums.Text = "Prevent Access to Forums"
        chkForums.AutoSize = True
        chkForums.Location = New Drawing.Point(20, 110)

        ' Initialize buttons
        btnSavePolicies.Text = "Save Policies"
        btnSavePolicies.Size = New Drawing.Size(120, 30)
        btnSavePolicies.Location = New Drawing.Point(20, 150)
        AddHandler btnSavePolicies.Click, AddressOf BtnSavePolicies_Click

        btnReEnable.Text = "Re-enable All"
        btnReEnable.Size = New Drawing.Size(120, 30)
        btnReEnable.Location = New Drawing.Point(150, 150)
        AddHandler btnReEnable.Click, AddressOf BtnReEnable_Click

        btnSchoolPolicies.Text = "School Policies"
        btnSchoolPolicies.Size = New Drawing.Size(120, 30)
        btnSchoolPolicies.Location = New Drawing.Point(280, 150)
        AddHandler btnSchoolPolicies.Click, AddressOf BtnSchoolPolicies_Click

        ' Add controls to form
        Me.Controls.Add(chkDesktop)
        Me.Controls.Add(chkTextart)
        Me.Controls.Add(chkTheCove)
        Me.Controls.Add(chkForums)
        Me.Controls.Add(btnSavePolicies)
        Me.Controls.Add(btnReEnable)
        Me.Controls.Add(btnSchoolPolicies)

        ' Load current policy values
        LoadPolicies()
    End Sub

    ' ---------------- Load current policies from HKCU ----------------
    Private Sub LoadPolicies()
        chkDesktop.Checked = IsPolicyEnabled("ProhibitAccessToFortindDesktop")
        chkTextart.Checked = IsPolicyEnabled("ProhibitTextart")
        chkTheCove.Checked = IsPolicyEnabled("NoTheCove")
        chkForums.Checked = IsPolicyEnabled("NoFortForums")
    End Sub

    ' ---------------- Button Handlers ----------------
    Private Sub BtnSavePolicies_Click(sender As Object, e As EventArgs)
        SavePolicies(chkDesktop.Checked, chkTextart.Checked, chkTheCove.Checked, chkForums.Checked)
    End Sub

    Private Sub BtnReEnable_Click(sender As Object, e As EventArgs)
        SavePolicies(False, False, False, False)
        LoadPolicies()
        MsgBox("All policies re-enabled (cleared).", MsgBoxStyle.Information, "Policies Cleared")
    End Sub

    Private Sub BtnSchoolPolicies_Click(sender As Object, e As EventArgs)
        ' Apply typical school restrictions
        SavePolicies(False, True, True, True)
        LoadPolicies()
        MsgBox("School policies applied.", MsgBoxStyle.Information, "Policies Applied")
    End Sub

    ' ---------------- Save policies to registry ----------------
    Private Sub SavePolicies(desktop As Boolean, textart As Boolean, cove As Boolean, forums As Boolean)
        Try
            Using key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\Fort.ind\Desktop\Policies")
                key.SetValue("ProhibitAccessToFortindDesktop", If(desktop, 1, 0), RegistryValueKind.DWord)
                key.SetValue("ProhibitTextart", If(textart, 1, 0), RegistryValueKind.DWord)
                key.SetValue("NoTheCove", If(cove, 1, 0), RegistryValueKind.DWord)
                key.SetValue("NoFortForums", If(forums, 1, 0), RegistryValueKind.DWord)
            End Using
            MsgBox("Policies saved successfully!", MsgBoxStyle.Information, "Success")
        Catch ex As Exception
            MsgBox("Error saving policies: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    ' ---------------- Helper: Check if policy is enabled ----------------
    Private Function IsPolicyEnabled(policyName As String) As Boolean
        Try
            Dim regPath As String = "HKEY_CURRENT_USER\Software\Fort.ind\Desktop\Policies"
            Dim value = Registry.GetValue(regPath, policyName, 0)
            Return value IsNot Nothing AndAlso Convert.ToInt32(value) = 1
        Catch
            Return False
        End Try
    End Function

End Class
