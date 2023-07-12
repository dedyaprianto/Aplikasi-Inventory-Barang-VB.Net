Public Class Laporan_Data_Barang

    Private Sub Laporan_Data_Barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.DataTable' table. You can move, or remove it, as needed.
        Me.DataTableTableAdapter.Fill(Me.DataSet1.DataTable)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class