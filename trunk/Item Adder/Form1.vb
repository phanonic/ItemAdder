Imports System.Net
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient


Public Class Form1
    Public Connection As MySqlConnection
    Public Host As String
    Public Username As String
    Public Password As String
    Public DB As String
    Public Port As Integer
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
                Form2.Show()
                Me.Hide()
                Form2.Text = "Item Adder (3.3.2.1b) - Database " & My.Settings.db & " on " & My.Settings.host & " "
            Else
                MsgBox("Error while connecting. Two possible problems:" & vbCrLf & "1. The input is wrong. Database connection details are supposed to be the same as those inside the Server config file (and programs like HeidiSQL)." & vbCrLf & "2. Check if your server is running (Mysql).", MsgBoxStyle.Critical, "Error")
                Me.Enabled = True
            End If
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Form2.Icon = My.Resources.icon
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form2.Show()
        Form2.Button2.Enabled = False
        My.Settings.mode = False
        Me.Hide()
        Form2.Text = "Item Adder (3.3.2.1b) - No Database Connection"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub
End Class
