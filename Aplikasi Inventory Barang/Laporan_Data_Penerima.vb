Public Class Laporan_Data_Penerima

    Private Sub Laporan_Data_Penerima_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.DataTable2' table. You can move, or remove it, as needed.
        Me.DataTable2TableAdapter.Fill(Me.DataSet1.DataTable2)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class