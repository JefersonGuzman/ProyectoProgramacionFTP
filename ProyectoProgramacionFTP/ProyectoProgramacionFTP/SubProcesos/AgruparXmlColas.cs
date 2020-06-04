using ProyectoProgramacionFTP.Clases;
using ProyectoProgramacionFTP.Colas;
using ProyectoProgramacionFTP.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.SubProcesos
{
    class AgruparXmlColas
    {
        public static Utils utl = new Utils();
        public async Task<bool> AgruparDocumentosXmlCanonicos()
        {
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/Cola");
            string directorioOrigen = Path.GetFullPath(fullPath + "/Documentos/Canonicos");
            if (!System.IO.Directory.Exists(directorioDesctino))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(directorioDesctino, ""));
            }
            if (System.IO.Directory.Exists(directorioOrigen))
            {
                string[] directory = System.IO.Directory.GetFiles(@directorioOrigen);
                foreach (var files in directory)
                {
                    string nameFile = System.IO.Path.GetFileName(files);
                    String[] TipoArchivo = nameFile.Split('_');
                    string[] fichero = File.ReadAllLines(System.IO.Path.Combine(directorioOrigen, nameFile));
                    string nombreCarpeta = utl.SetNombreCarpetaCola(TipoArchivo[0]);
                    string fileDestino = (System.IO.Path.Combine(directorioDesctino + "/" + nombreCarpeta, nameFile));
                    System.IO.File.Move(files, fileDestino);
                    InsertarColaSegunPrioridad(fichero, nombreCarpeta);
                }
            }
            else
            {
                string mensaje = "Directorio NO existe, archivo: (" + directorioOrigen + ") Proceso: Agrupar en carpeta colas" + " Fecha proceso: " + DateTime.Today;
                utl.RegistroLog(mensaje, "FILE_EXIST", "file_exist.txt");
            }
            return true;
        }

        public void InsertarColaSegunPrioridad(string[] fichero, string cola)
        {
            XmlCanonico datos = GetFormaListaDatos(fichero);
            if (cola.Equals("Alta"))
            {
                ColaPrioridadAlta.Cola.AgregarElementosAlInicio(datos);
            }
            else if (cola.Equals("Media"))
            {
                ColaPrioridadAlta.Cola.AgregarElementosAlInicio(datos);
            }
            else
            {
                ColaPrioridadAlta.Cola.AgregarElementosAlInicio(datos);
            }
            
        }

        public static XmlCanonico GetFormaListaDatos(string[] fichero)
        {
            int cantFilas = fichero.Length - 2;
            string[] body = new string[cantFilas];
            string[] headers = new string[cantFilas];
            for (int i = 1; i < (fichero.Length - 1); i++)
            {
                string[] auxiliar = fichero[i].Split('<');
                if (!String.IsNullOrEmpty(auxiliar[1]))
                {
                    string[] auxiliar2 = auxiliar[1].Split('>');
                    headers[i-1] = auxiliar2[0];
                    body[i-1] = auxiliar2[1];
                }
            }

            Utils ult = new Utils();
            XmlCanonico documento = ult.GenerarObjetoXmlCanonico(headers,body);
            return documento;
        }

    }
}
