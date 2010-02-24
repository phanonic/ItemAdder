<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.lblPort = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.proceed = New System.Windows.Forms.Button
        Me.txtDatabase = New System.Windows.Forms.TextBox
        Me.lblE5 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblE4 = New System.Windows.Forms.Label
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.lblE3 = New System.Windows.Forms.Label
        Me.txtHost = New System.Windows.Forms.TextBox
        Me.lblE2 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(189, 32)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(55, 20)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "3306"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblPort.Location = New System.Drawing.Point(186, 16)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(31, 13)
        Me.lblPort.TabIndex = 34
        Me.lblPort.Text = "Port:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(45, 258)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 33
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'proceed
        '
        Me.proceed.Location = New System.Drawing.Point(126, 258)
        Me.proceed.Name = "proceed"
        Me.proceed.Size = New System.Drawing.Size(75, 23)
        Me.proceed.TabIndex = 6
        Me.proceed.Text = "&Proceed"
        Me.proceed.UseVisualStyleBackColor = True
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(6, 187)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(238, 20)
        Me.txtDatabase.TabIndex = 4
        Me.txtDatabase.Text = "world"
        '
        'lblE5
        '
        Me.lblE5.AutoSize = True
        Me.lblE5.Location = New System.Drawing.Point(6, 171)
        Me.lblE5.Name = "lblE5"
        Me.lblE5.Size = New System.Drawing.Size(56, 13)
        Me.lblE5.TabIndex = 30
        Me.lblE5.Text = "Database:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(6, 132)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(238, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Text = "ascent"
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'lblE4
        '
        Me.lblE4.AutoSize = True
        Me.lblE4.Location = New System.Drawing.Point(6, 116)
        Me.lblE4.Name = "lblE4"
        Me.lblE4.Size = New System.Drawing.Size(135, 13)
        Me.lblE4.TabIndex = 28
        Me.lblE4.Text = "Password:  ascent (default)"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(6, 83)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(238, 20)
        Me.txtUsername.TabIndex = 2
        Me.txtUsername.Text = "root"
        '
        'lblE3
        '
        Me.lblE3.AutoSize = True
        Me.lblE3.Location = New System.Drawing.Point(6, 67)
        Me.lblE3.Name = "lblE3"
        Me.lblE3.Size = New System.Drawing.Size(58, 13)
        Me.lblE3.TabIndex = 26
        Me.lblE3.Text = "Username:"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(6, 32)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(177, 20)
        Me.txtHost.TabIndex = 0
        Me.txtHost.Text = "localhost"
        '
        'lblE2
        '
        Me.lblE2.AutoSize = True
        Me.lblE2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblE2.Location = New System.Drawing.Point(6, 16)
        Me.lblE2.Name = "lblE2"
        Me.lblE2.Size = New System.Drawing.Size(33, 13)
        Me.lblE2.TabIndex = 24
        Me.lblE2.Text = "Host:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Arcemu", "Mangos", "Trinity"})
        Me.ComboBox1.Location = New System.Drawing.Point(142, 222)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(102, 21)
        Me.ComboBox1.TabIndex = 5
        Me.ComboBox1.Text = "Arcemu"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 225)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Pick Your Core:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblE2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtHost)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.lblE3)
        Me.GroupBox1.Controls.Add(Me.txtPort)
        Me.GroupBox1.Controls.Add(Me.txtUsername)
        Me.GroupBox1.Controls.Add(Me.lblPort)
        Me.GroupBox1.Controls.Add(Me.lblE4)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.proceed)
        Me.GroupBox1.Controls.Add(Me.lblE5)
        Me.GroupBox1.Controls.Add(Me.txtDatabase)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 298)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Please enter database information:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(276, 322)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Adder 3.3.2.1e"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents proceed As System.Windows.Forms.Button
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents lblE5 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblE4 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblE3 As System.Windows.Forms.Label
    Friend WithEvents txtHost As System.Windows.Forms.TextBox
    Friend WithEvents lblE2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
