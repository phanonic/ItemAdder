<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSQL
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
        Me.rtxtViewSQL = New System.Windows.Forms.RichTextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'rtxtViewSQL
        '
        Me.rtxtViewSQL.Location = New System.Drawing.Point(12, 12)
        Me.rtxtViewSQL.Name = "rtxtViewSQL"
        Me.rtxtViewSQL.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtxtViewSQL.Size = New System.Drawing.Size(825, 195)
        Me.rtxtViewSQL.TabIndex = 0
        Me.rtxtViewSQL.Text = ""
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(387, 213)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ViewSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 248)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.rtxtViewSQL)
        Me.Name = "ViewSQL"
        Me.Text = "ViewSQL"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtxtViewSQL As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
