Imports System.IO

Public Class ViewSQL
    Private Sub ViewSQL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Item Adder " & Logon.version & " SQL View"
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveFileDialog1.Filter = "Sql files (*.sql)|"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.ShowDialog()
        SaveFileDialog1.RestoreDirectory = True
        Dim path = SaveFileDialog1.FileName & ".sql"
        Dim fs As New FileStream(path, FileMode.Create, FileAccess.Write)
        Dim s As New StreamWriter(fs)
        s.Write(rtxtViewSQL.Text)
        s.Close()
        path = ""
        SaveFileDialog1.FileName = ""
        Me.Close()
    End Sub
End Class