Option Explicit On
Imports System.Net
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Logon
    Public version As String = "3.3.2.2b"
    Public Host As String
    Public Username As String
    Public Password As String
    Public DB As String
    Public Port As Integer

    Public Connection As MySqlConnection

    Public Function ConnectToDB() As Boolean
        Try
            Connection = New MySqlConnection("server=" & Host & ";user id=" & Username & "; password=" & Password & "; port=" & Port & "; database=" & DB & "; pooling=false")
            Connection.Open()
        Catch
            Return False
        End Try
        Return True
    End Function
    Public Sub setsettings()
        My.Settings.host = Host
        My.Settings.username = Username
        My.Settings.password = Password
        My.Settings.db = DB
        My.Settings.port = Port
        My.Settings.type = ComboBox1.Text
    End Sub
    Private Sub lblPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles proceed.Click
        Host = txtHost.Text
        Username = txtUsername.Text
        Password = txtPassword.Text
        DB = txtDatabase.Text
        Port = txtPort.Text
        Me.Enabled = False
        If ComboBox1.Text = "" Then
            MsgBox("Please pick your core")
            Me.Enabled = True

        Else
            If ConnectToDB() = True Then
                setsettings()
                My.Settings.mode = True
                ItemAdder.Show()
                Me.Hide()
                ItemAdder.Text = "Item Adder " & version & " - Database " & My.Settings.db & " on " & My.Settings.host & " "
            Else
                MsgBox("Error while connecting. Two possible problems:" & vbCrLf & "1. The input is wrong. Database connection details are supposed to be the same as those inside the Server config file (and programs like HeidiSQL)." & vbCrLf & "2. Check if your server is running (Mysql).", MsgBoxStyle.Critical, "Error")
                Me.Enabled = True
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = "Item Adder " & version & " Logon"
        If My.Settings.type <> "" Then
            ComboBox1.Text = My.Settings.type
        End If
        If My.Settings.db <> "" Then
            txtDatabase.Text = My.Settings.db
        End If
        If My.Settings.host <> "" Then
            txtHost.Text = My.Settings.host
        End If
        If My.Settings.password <> "" Then
            txtPassword.Text = My.Settings.password
        End If
        If My.Settings.port <> "" Then
            txtPort.Text = My.Settings.port
        End If
        If My.Settings.username <> "" Then
            txtUsername.Text = My.Settings.username
        End If
        Me.Icon = My.Resources.icon
        ItemAdder.Icon = My.Resources.icon
        BackgroundWorker1.RunWorkerAsync()
        ItemAdder.ToolStripStatusLabel1.ForeColor = Color.DarkOrange
        ItemAdder.ToolStripStatusLabel1.Text = "Web connect status: Connecting to the web."
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ItemAdder.Show()
        ItemAdder.Button2.Enabled = False
        My.Settings.mode = False
        Me.Hide()
        ItemAdder.Text = "Item Adder " & version & " - No Database Connection"
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Try
            If GetContents("http://itemadder.googlecode.com/svn/trunk/Item%20Adder/itemadder.ver") = version Then
                SetText(Label1, "No new version available.")
            Else
                SetVisible(Label1, False)
                SetVisible(LinkLabel1, True)

                Dim i As Integer
                i = 0
                Do Until i = 1
                    If Label3.Visible = False Then
                        SetVisible(Label3, True)
                        System.Threading.Thread.Sleep(2000)
                    End If
                    SetVisible(Label3, False)
                    System.Threading.Thread.Sleep(200)
                Loop
            End If
            If My.Computer.FileSystem.FileExists("temp") Then My.Computer.FileSystem.DeleteFile("temp")
        Catch Ex As Exception
            SetText(Label1, "Error while checking.")
            If My.Computer.FileSystem.FileExists("temp") Then My.Computer.FileSystem.DeleteFile("temp")
        End Try
    End Sub

    Public Function GetContents(ByVal URL As String) As String
        Dim FinalString As String = ""

        Dim myWebRequest As WebRequest = WebRequest.Create(URL)
        Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
        Dim ReceiveStream As IO.Stream = myWebResponse.GetResponseStream()
        Dim encode As System.Text.Encoding = System.Text.Encoding.GetEncoding("utf-8")
        Dim readStream As New IO.StreamReader(ReceiveStream, encode)
        Dim Buffer(256) As [Char]
        Dim Count As Integer = readStream.Read(Buffer, 0, 256)

        While Count > 0
            Dim TempString As New [String](Buffer, 0, Count)
            FinalString &= TempString
            Count = readStream.Read(Buffer, 0, 256)
            Application.DoEvents()
        End While

        readStream.Close()
        myWebResponse.Close()

        Return FinalString
    End Function

    Private Delegate Sub SetTextDel(ByVal Label As Label, ByVal Text As String)

    Private Sub SetText(ByVal Label As Label, ByVal Text As String)
        If Label.InvokeRequired Then
            Label.Invoke(New SetTextDel(AddressOf SetText), New Object() {Label, Text})
        Else
            Label.Text = Text
        End If
    End Sub

    Private Delegate Sub SetVisibleDel(ByVal Label As Label, ByVal Visible As Boolean)

    Private Sub SetVisible(ByVal Label As Label, ByVal Visible As Boolean)
        If Label.InvokeRequired Then
            Label.Invoke(New SetVisibleDel(AddressOf SetVisible), New Object() {Label, Visible})
        Else
            Label.Visible = Visible
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.phanonic.smfnew.com/")
    End Sub

    Private Sub txtHost_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHost.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            lblPort_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ItemAdder.ToolStripStatusLabel1.ForeColor = Color.Green
        ItemAdder.ToolStripStatusLabel1.Text = "Web connect status: Connected."
    End Sub
End Class
