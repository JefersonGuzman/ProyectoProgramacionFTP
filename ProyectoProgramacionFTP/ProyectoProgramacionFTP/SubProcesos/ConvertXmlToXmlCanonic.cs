using ProyectoProgramacionFTP.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.SubProcesos
{
    class ConvertXmlToXmlCanonic
    {
        public static Utils util = new Utils();
        public void ObtenerArchivoXml(string directorioOrigen, string nombreArchivoXml)
        {
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/Canonicos");
            string[] fichero = File.ReadAllLines(System.IO.Path.Combine(directorioOrigen, nombreArchivoXml));
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
