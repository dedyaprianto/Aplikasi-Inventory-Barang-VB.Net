Public Class Laporan_Data_Admin

    Private Sub Laporan_Data_Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.DataTable5' table. You can move, or remove it, as needed.
        Me.DataTable5TableAdapter.Fill(Me.DataSet1.DataTable5)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class