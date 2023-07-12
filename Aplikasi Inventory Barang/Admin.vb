Imports MySql.Data.MySqlClient
Public Class Admin
    Dim jk As String
    Sub tampil()
        koneksi()
        da = New MySqlDataAdapter("SELECT id_admin,username,jk_admin,alamat,telepon FROM admin ", conn)
        ds = New DataSet
        da.Fill(ds, "admin")
        DataGridView1.DataSource = ds.Tables("admin")
        DataGridView1.ReadOnly = True
    End Sub
    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub
    Private Sub Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
        kosong()
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        TextBox3.Enabled = False
        jk = DataGridView1.Item(2, i).Value
        TextBox4.Text = DataGridView1.Item(3, i).Value
        TextBox5.Text = DataGridView1.Item(4, i).Value
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Silahkan Isi Formnya")
        Else
            koneksi()
            If RadioButton1.Checked = True Then
                jk = RadioButton1.Text
            ElseIf RadioButton2.Checked = True Then
                jk = RadioButton2.Text
            End If
            Dim simpan As String = "INSERT INTO admin VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & jk & "','" & TextBox4.Text & "','" & TextBox5.Text & "') "
            cmd = New MySqlCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil")
            tampil()
            kosong()
        End If
    End Sub

    Private Sub Guna2Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button2.Click
        If MessageBox.Show("Apakah Anda Ingin Merubah Data admin", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
                MsgBox("Silahkan Isi Formnya")
            Else
                koneksi()

                If RadioButton1.Checked = True Then
                    jk = RadioButton1.Text
                ElseIf RadioButton2.Checked = True Then
                    jk = RadioButton2.Text
                End If
                Dim edit As String
                edit = "UPDATE admin SET username = '" & TextBox2.Text & "',jk_admin = '" & jk & "', alamat = '" & TextBox4.Text & "', telepon = '" & TextBox5.Text & "' WHERE id_admin= '" & TextBox1.Text & "' "
                cmd = New MySqlCommand(edit, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Diubah")
                TextBox3.Enabled = True
                tampil()
                kosong()
            End If
        End If
    End Sub
    Private Sub Guna2Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("Data belum di pilih", vbInformation, "Pesan")
        Else
            koneksi()
            Dim hapus As String
            hapus = "DELETE FROM admin WHERE id_admin='" & TextBox1.Text & "'"
            cmd = New MySqlCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil di hapus", vbInformation, "Pesan")
            tampil()
            kosong()
        End If
    End Sub

    Private Sub Guna2Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button4.Click
        TextBox3.Enabled = True
        kosong()
    End Sub

    Private Sub Guna2Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button5.Click
        koneksi()
        If TextBox6.Text = "" Then
            MsgBox("Mohon Diisi yang ingin dicari")
        Else
            Dim cari As String
            cari = "SELECT * FROM admin WHERE id_admin LIKE '%" & TextBox6.Text & "%' OR username LIKE '%" & TextBox6.Text & "%' "
            da = New MySqlDataAdapter(cari, conn)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub Guna2Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button6.Click
        tampil()
        kosong()
    End Sub
End Class