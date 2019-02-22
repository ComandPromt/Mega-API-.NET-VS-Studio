Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports CG.Web.MegaApiClient
Public Class dialogosubir
    'Declaración de un hilo
    Private t As Thread

    'Evento Shown que instancia y ejecuta el hilo (este evento se ejecuta después del Load).
    ' Método que se encarga de subir el archivo a la nube con la Api "Mega".
    Private Sub subir_AMega()
        Try
            ' Actualizar el label para informar al usuario.
            lblinfo.Invoke(New MethodInvoker(Sub() lblinfo.Text = "Conectando como 'correo'"))
            ' Aumentar la barra de progreso.
            ProgressBar1.Invoke(New MethodInvoker(Sub() ProgressBar1.PerformStep()))
            ' Instancia de un cliente para conectar con mega.
            Dim cliente As New MegaApiClient()                    'z
            ' Inicio de sesión con el cliente, pasando el correo y la contraseña de la cuenta mega a la que se sube el archivo.
            cliente.Login("micorreo.com", "mypassword")

            ' Aumentar la barra de progreso.
            ProgressBar1.Invoke(New MethodInvoker(Sub() ProgressBar1.PerformStep()))
            ' Actualizar el label para informar al usuario.
            lblinfo.Invoke(New MethodInvoker(Sub() lblinfo.Text = "Obteniendo directorios..."))
            ' Obtenemos los nodos (directorios/archivos) de la cuenta dentro de una variable.
            Dim nodos = cliente.GetNodes()

            ' Actualizar el label para informar al usuario.
            lblinfo.Invoke(New MethodInvoker(Sub() lblinfo.Text = "Buscando carpeta 'SUBIR_MEGA'..."))
            ' Comprobar si existe algún nodo (directorio) que se llame "SUBIR_MEGA" (en mi caso quiero subir el archivo a dicha carpeta).
            Dim existe As Boolean = cliente.GetNodes().Any(Function(n) n.Name = "SUBIR_MEGA")

            ' Crear dos nodos.
            Dim root As INode
            Dim carpeta As INode

            ' Si el directorio SUBIR_MEGA existe, se obtiene. Si no existe, se crea.
            If existe = True Then
                ' Actualizar el label para informar al usuario.
                lblinfo.Invoke(New MethodInvoker(Sub() lblinfo.Text = "Obteniendo la carpeta 'SUBIR_MEGA'...."))
                ' Aumentar la barra de progreso.
                ' ProgressBar1.Invoke(New MethodInvoker(Sub() ProgressBar1.PerformStep()))

                ' Obtenemos el directorio.
                carpeta = nodos.[Single](Function(n) n.Name = "SUBIR_MEGA")
            Else
                ' Actualizar label para informar al usuario.
                lblinfo.Invoke(New MethodInvoker(Sub() lblinfo.Text = "Creando carpeta 'SUBIR_MEGA'..."))
                ' Aumentar la barra de progreso.
                ' ProgressBar1.Invoke(New MethodInvoker(Sub() ProgressBar1.PerformStep()))

                'Obtenemos el nodo raíz.
                root = nodos.[Single](Function(n) n.Type = NodeType.Root)
                ' Creamos el directorio llamado "SUBIR_MEGA" en la raíz.
                carpeta = cliente.CreateFolder("SUBIR_MEGA", root)
            End If

            ' Aumentar la barra de progreso.
            ProgressBar1.Invoke(New MethodInvoker(Sub() ProgressBar1.PerformStep()))
            ' Actualizar label para informar al usuario.
            lblinfo.Invoke(New MethodInvoker(Sub() lblinfo.Text = "Subiendo archivo..."))
            ' Aumentar la barra de progreso.
            ' ProgressBar1.Invoke(New MethodInvoker(Sub() ProgressBar1.PerformStep()))

            ' Subimos el archivo al directorio "SUBIR_MEGA", pasando la ruta del archivo a subir y el directorio de mega donde debe subirlo.
            'BackgroundWorker1.RunWorkerAsync()
            Dim archivo As INode = cliente.UploadFile(Form1.txtruta.Text, carpeta)

            ' Obtener el link de descarga del archivo subido por si se requiere para algo.
            ProgressBar1.Invoke(New MethodInvoker(Sub() ProgressBar1.PerformStep()))
            Dim downloadUrl As Uri = cliente.GetDownloadLink(archivo)
            ' Actualizar label para informar al usuario.
            lblinfo.Invoke(New MethodInvoker(Sub() lblinfo.Text = "Archivo subido con éxito."))
            MsgBox("Archivo subido con éxito.", vbExclamation)
        Catch [error] As Exception

            ' Algo ha fallado, abortamos el subproceso.

            ' Mensaje en pantalla para informar al usuario del error.
            MessageBox.Show("Error al intentar subir el archivo. " + [error].Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            t.Abort()
        End Try

        ' No se puede cerrar el form desde un subproceso ya que no es desde donde se ha creado. Con este código podemos cerrarlo.
        Me.Invoke(DirectCast(Sub() Me.Close(), MethodInvoker))
    End Sub
    Private Sub dialogosubir_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            'Instancia un hilo para ejecutar el método "subirArchivoAMega".
            t = New Thread(AddressOf subir_AMega)
            t.Start()
        Catch ex As Exception
            ex.ToString()
        End Try

    End Sub
End Class
