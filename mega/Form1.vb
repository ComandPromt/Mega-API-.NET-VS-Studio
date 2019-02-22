Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            dialogosubir.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim xlRuta As String = ""
        Dim Open As New OpenFileDialog
        With Open
            .Title = "Seleccionar Archivo"
            .Filter = "Todos los archivos(*.*)|*.*"
            .Multiselect = False
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                txtruta.Text = .FileName

            End If
        End With
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Tokyo")
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim ruta As String
    '        Dim OpenFileDialog As New OpenFileDialog
    '        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    '        OpenFileDialog.Filter = "SQL Compact Edition Database File (*.sdf)|*.sdf|Todos los archivos (*.*)|*.*"
    '        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
    '            Dim FileName As String = OpenFileDialog.FileName
    '            ruta = FileName
    '            txtruta.Text = ruta
    '            ' TODO: agregue código aquí para abrir el archivo.
    '        End If
    '    Catch ex As Exception
    '        MsgBox("error al abrir base de datos", vbCritical)
    '    End Try
    'End Sub
End Class
