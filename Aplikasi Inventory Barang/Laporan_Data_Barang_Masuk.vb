Public Class Laporan_Data_Barang_Masuk

    Private Sub Laporan_Data_Barang_Masuk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.DataTable3' table. You can move, or remove it, as needed.
        Me.DataTable3TableAdapter.Fill(Me.DataSet1.DataTable3)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class