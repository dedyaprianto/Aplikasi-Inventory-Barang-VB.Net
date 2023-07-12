Imports MySql.Data.MySqlClient
Public Class Reset__Password
    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Label6.Text = ""
        Label7.Text = ""
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        koneksi()
        cmd = New MySqlCommand("SELECT PASSWORD FROM admin WHERE username ='" & TextBox1.Text & "'", conn)
        Dim pass As String = cmd.ExecuteScalar
        If (pass = TextBox2.Text) Then
            Label6.Text = "BENAR"
            Label6.ForeColor = Color.Lime
        Else
            Label6.Text = "SALAH"
            Label6.ForeColor = Color.Red
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        If (TextBox3.Text = TextBox4.Text) Then
            Label7.Text = "SESUAI"
            Label7.ForeColor = Color.Lime
        Else
            Label7.Text = "TIDAK SESUAI"
            Label7.ForeColor = Color.Red
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If TextBox2.UseSystemPasswordChar = True Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If

        If TextBox3.UseSystemPasswordChar = True Then
            TextBox3.UseSystemPasswordChar = False
        Else
            TextBox3.UseSystemPasswordChar = True
        End If

        If TextBox4.UseSystemPasswordChar = True Then
            TextBox4.UseSystemPasswordChar = False
        Else
            TextBox4.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        koneksi()
        If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            TextBox1.Focus()
            MsgBox("Maaf, Username dan Password Salah")
            Call kosong()
        Else
            If MessageBox.Show("Apakah Anda Yakin Mengganti Password!", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                cmd = New MySqlCommand("UPDATE admin SET password=('" & TextBox4.Text & "') WHERE username=('" & TextBox1.Text & "')", conn)
                Dim rts As String = cmd.ExecuteNonQuery()
                MsgBox("Password Berhasil Dirubah")
                Call kosong()
                Login.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Guna2Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button2.Click
        kosong()

    End Sub
End Class