Imports MySql.Data.MySqlClient
Public Class Login

    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        Call koneksi()
        Dim sql As String
        sql = "SELECT * FROM admin WHERE username='" & TextBox1.Text & "' AND password='" & TextBox2.Text & "'"
        cmd = New MySqlCommand(sql, conn)
        dr = cmd.ExecuteReader()
        If dr.HasRows = True Then
            MsgBox("Login Sukses!, Selamat Datang " & TextBox1.Text & " ", MsgBoxStyle.Information, "")
            kosong()
            Dashboard.Show()
            Me.Hide()
        Else
            MessageBox.Show("Maaf, Username dan Password Salah", "Konfirmasi",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            kosong()
        End If
    End Sub

    Private Sub Guna2Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button2.Click
        If MessageBox.Show("Apakah Anda Menutup Aplikasi ???", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class