using ProyectoProgramacionFTP.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.SubProcesos
{
    ///<summary>
    ///Clase que convierte los ficheros de XML a XML CANONICO
    ///</summary>
    ///<remarks>
    ///Lee los ficheros convertidos a xml y realiza conversion a un xml canonico para el
    ///proceso final.
    ///</remarks>
    class ConvertXmlToXmlCanonic
    {
        public static Utils util = new Utils(); //Instancia clase de utilidades
        ///<summary>
        ///Metodo que obtiene los ficheros xml para convertirlos
        ///</summary>
        ///<remarks>
        ///Se realiza busqueda en los directorios especificados y el nombre de archivo para realizar la lectura 
        ///de ese archivo, finalmente convertirlo a un fichero XML CANONICO
        ///<param name="directorioOrigen">Directorio del fichero de origen</param>
        ///<param name="nombreArchivoXml">Nombre del fichero a convertir</param>
        ///</remarks>
        public void ObtenerArchivoXml(string directorioOrigen, string nombreArchivoXml) //Instancia clase que convierte archivos a canonicos
        {
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/Canonicos"); //Define la ruta de destino de los archivos
            string[] fichero = File.ReadAllLines(System.IO.Path.Combine(directorioOrigen, nombreArchivoXml)); //Realiza la lectura del fichero obteniendo sus lineas
            int cantFilas = fichero.Length - 2; //Establece la cantidad de filas omitiendo la primera y la ultima
            string[] body = new string[cantFilas]; //Define el tamaño del array del body
            string[] headers = new string[cantFilas]; //Define el tamaño del array del headers
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
            string[] xmlCanonico = util.ObtenerEncabezadosCanonico(headers,body);
            string documentoGenerado = GenerarXmlCanonico(xmlCanonico);
            if (!File.Exists(System.IO.Path.Combine(directorioDesctino, nombreArchivoXml))) 
            {
                byte[] info = new UTF8Encoding(true).GetBytes(documentoGenerado); //Codifica el contenido del documento (Cuerpo XML)
                FileStream fs = File.Create(System.IO.Path.Combine(directorioDesctino, nombreArchivoXml)); //Crea el archivo XML y lo almacena en la carpeta destino
                fs.Write(info, 0, info.Length); //Escribe el documento con el cuerpo obtenido.
                fs.Close();
            }
            else
            {
                string mensaje = "Archivo existente, archivo: " + nombreArchivoXml + " Proceso: Convertir XML a XML_CANONICO" + " Fecha proceso: " + DateTime.Today;
                util.RegistroLog(mensaje, "FILE_EXIST", "file_exist.txt");
            }
        }

        public static string GenerarXmlCanonico(string[] xmlCanonico)
        {
            int cantFilas = xmlCanonico.Length;
            string documento = "";
            documento += "<documento_xml_canonico>\n";
            for (int i = 0; i < cantFilas; i++)
            {
                documento += "\t" + xmlCanonico[i] + "\n";
            }
            documento += "</documento_xml_canonico>\n";

            return documento;
        }
    }
}
