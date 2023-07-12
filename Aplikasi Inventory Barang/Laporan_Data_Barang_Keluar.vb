Public Class Laporan_Data_Barang_Keluar

    Private Sub Laporan_Data_Barang_Keluar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.DataTable4' table. You can move, or remove it, as needed.
        Me.DataTable4TableAdapter.Fill(Me.DataSet1.DataTable4)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class