Imports MySql.Data.MySqlClient
Public Class Product_Out
    Sub kosong()
        TextBox1.Text = ""
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox2.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub
    Sub kodebarang()
        koneksi()
        ComboBox1.Items.Clear()
        cmd = New MySqlCommand("SELECT * FROM barang", conn)
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox1.Items.Add(dr.Item("id_barang"))
        Loop
    End Sub
    Sub kodepenerima()
        koneksi()
        ComboBox2.Items.Clear()
        cmd = New MySqlCommand("SELECT * FROM penerima", conn)
        dr = cmd.ExecuteReader
        Do While dr.Read
            ComboBox2.Items.Add(dr.Item("id_penerima"))
        Loop
    End Sub
    Sub tampil()
        koneksi()
        da = New MySqlDataAdapter("SELECT barang_keluar.id_keluar,barang_keluar.tanggal_keluar,barang_keluar.id_barang,barang_keluar.nama_barang,barang_keluar.qty,barang_keluar.satuan,barang_keluar.id_penerima,barang_keluar.nama_penerima FROM barang_keluar INNER JOIN barang ON barang_keluar.id_barang = barang.id_barang INNER JOIN penerima ON barang_keluar.id_penerima=penerima.id_penerima", conn)
        ds = New DataSet
        da.Fill(ds, "barang_keluar")
        DataGridView1.DataSource = ds.Tables("barang_keluar")
        DataGridView1.ReadOnly = True
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        koneksi()
        cmd = New MySqlCommand("SELECT * FROM barang where id_barang='" & ComboBox1.Text & "' ", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox2.Text = dr.Item("nama_barang")
            TextBox4.Text = dr.Item("satuan")
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        koneksi()
        cmd = New MySqlCommand("SELECT * FROM penerima where id_penerima='" & ComboBox2.Text & "' ", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox5.Text = dr.Item("nama_penerima")
        End If
    End Sub

    Private Sub Product_Out_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        kodebarang()
        kodepenerima()
        tampil()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        TextBox1.Text = DataGridView1.Item(0, i).Value
        DateTimePicker1.Text = DataGridView1.Item(1, i).Value
        ComboBox1.Text = DataGridView1.Item(2, i).Value
        TextBox2.Text = DataGridView1.Item(3, i).Value
        TextBox3.Text = DataGridView1.Item(4, i).Value
        TextBox4.Text = DataGridView1.Item(5, i).Value
        ComboBox2.Text = DataGridView1.Item(6, i).Value
        TextBox5.Text = DataGridView1.Item(7, i).Value
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Private Sub Guna2Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button1.Click
        koneksi()
        'Dim tglmsk As String
        'tglmsk = Format(DateTimePicker1.Value, "dd-MM-yyyy")
        If TextBox1.Text = "" Or ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox2.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Silahkan Isi Formnya")
        Else
            Dim simpan As String = "INSERT INTO barang_keluar VALUES ('" & TextBox1.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & ComboBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox2.Text & "','" & TextBox5.Text & "')"
            cmd = New MySqlCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data Berhasil")
            tampil()
            kosong()
            conn.Dispose()
        End If
    End Sub

    Private Sub Guna2Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button2.Click
        koneksi()
        If MessageBox.Show("Apakah Anda Ingin Merubah Data Barang keluar", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If TextBox1.Text = "" Or ComboBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox2.Text = "" Or TextBox5.Text = "" Then
                MsgBox("Silahkan Isi Formnya")
            Else
                Dim edit As String
                edit = "UPDATE barang_keluar SET tanggal_keluar = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', id_barang = '" & ComboBox1.Text & "', nama_barang = '" & TextBox2.Text & "', qty = '" & TextBox3.Text & "', satuan = '" & TextBox4.Text & "', id_penerima = '" & ComboBox2.Text & "', nama_penerima = '" & TextBox5.Text & "' WHERE id_keluar= '" & TextBox1.Text & "' "
                cmd = New MySqlCommand(edit, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data Berhasil Diubah")
                tampil()
                kosong()
            End If
        End If
    End Sub

    Private Sub Guna2Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button3.Click
        koneksi()
        If TextBox1.Text = "" Then
            MsgBox("Data belum di pilih", vbInformation, "Pesan")
            Exit Sub
        Else
            Dim hapus As String
            hapus = "DELETE FROM barang_keluar WHERE id_keluar='" & TextBox1.Text & "'"
            cmd = New MySqlCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil di hapus", vbInformation, "Pesan")
            tampil()
            kosong()
        End If
    End Sub

    Private Sub Guna2Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button4.Click
        kosong()
    End Sub

    Private Sub Guna2Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button5.Click
        koneksi()
        If TextBox6.Text = "" Then
            MsgBox("Mohon Diisi yang ingin dicari")
        Else
            Dim cari As String
            cari = "SELECT * FROM barang_keluar WHERE id_barang LIKE '%" & TextBox6.Text & "%' OR nama_barang LIKE '%" & TextBox6.Text & "%' "
            da = New MySqlDataAdapter(cari, conn)
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub Guna2Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guna2Button6.Click
        kosong()
        tampil()
    End Sub
End Class