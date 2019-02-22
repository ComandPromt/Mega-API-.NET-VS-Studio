<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dialogosubir
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblinfo = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblinfo2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 78)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(551, 34)
        Me.ProgressBar1.TabIndex = 0
        '
        'lblinfo
        '
        Me.lblinfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblinfo.Location = New System.Drawing.Point(12, 58)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(551, 23)
        Me.lblinfo.TabIndex = 1
        '
        'lblinfo2
        '
        Me.lblinfo2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblinfo2.Location = New System.Drawing.Point(12, 115)
        Me.lblinfo2.Name = "lblinfo2"
        Me.lblinfo2.Size = New System.Drawing.Size(551, 23)
        Me.lblinfo2.TabIndex = 10
        '
        'dialogosubir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 189)
        Me.Controls.Add(Me.lblinfo2)
        Me.Controls.Add(Me.lblinfo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dialogosubir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "dialogosubir"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblinfo As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblinfo2 As Label
End Class
