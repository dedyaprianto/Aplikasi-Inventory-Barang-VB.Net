Public Class Dashboard

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub BarangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangToolStripMenuItem.Click
        Product.Show()
    End Sub

    Private Sub AdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminToolStripMenuItem.Click
        Admin.Show()
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        Supplier.Show()
    End Sub

    Private Sub PenerimaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenerimaToolStripMenuItem.Click
        Penerima.Show()
    End Sub

    Private Sub BarangMasukToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangMasukToolStripMenuItem.Click
        Product_In.Show()
    End Sub

    Private Sub BarangKeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangKeluarToolStripMenuItem.Click
        Product_Out.Show()
    End Sub

    Private Sub BarangToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangToolStripMenuItem1.Click
        Laporan_Data_Barang.Show()
    End Sub

    Private Sub SupplierToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem1.Click
        Laporan_Data_Supplier.Show()
    End Sub

    Private Sub PenerimaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenerimaToolStripMenuItem1.Click
        Laporan_Data_Penerima.Show()
    End Sub

    Private Sub BarangMasukToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangMasukToolStripMenuItem1.Click
        Laporan_Data_Barang_Masuk.Show()
    End Sub

    Private Sub BarangKeluarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangKeluarToolStripMenuItem1.Click
        Laporan_Data_Barang_Keluar.Show()
    End Sub

    Private Sub AdminToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminToolStripMenuItem1.Click
        Laporan_Data_Admin.Show()
    End Sub

    Private Sub ResetPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetPasswordToolStripMenuItem.Click
        Reset__Password.Show()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        If MessageBox.Show("Apakah Anda Menutup Aplikasi ???", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class