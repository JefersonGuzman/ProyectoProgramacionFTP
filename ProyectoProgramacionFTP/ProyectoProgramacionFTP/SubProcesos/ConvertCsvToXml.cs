using ProyectoProgramacionFTP.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.SubProcesos
{
    class ConvertCsvToXml
    {
        
        public void LeerArchivosCSV()
        {
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/DocumentosXml");
            string directorioOrigen = Path.GetFullPath(fullPath + "/Documentos/DocumentosCSV");
            if (!System.IO.Directory.Exists(directorioDesctino))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(directorioDesctino, ""));
            }

            if (System.IO.Directory.Exists(directorioOrigen))
            {
                string[] directory = System.IO.Directory.GetFiles(@directorioOrigen);
                if (directory.Length >= 1)
                {
                    foreach (var files in directory)
                    {

                        string nameFile = System.IO.Path.GetFileName(files); //Obtiene el nombre de los carchivos del directorio
                        string[] lineas = File.ReadAllLines(System.IO.Path.Combine(directorioOrigen, nameFile)); //Lee las lineas del csv
                        if (lineas.Length > 0) //Valida si el archivo tiene mas contenido
                        {
                            string[] headers = lineas[0].Split(';'); //Se almacena la primer fila como headers
                            string[] body = lineas[1].Split(';'); //Se almacena la segunda fila como el body del documento
                            string nombreArchivoXml = body[0] + "_" + nameFile.Replace(".csv", ".xml"); //Establece el nombre del nuevo XML (tipoDoc_nombreArchivo.xml)
                            Utils utl = new Utils();
                            string nombrecarpeta = utl.SetNombreCarpSegXml(body[0]);
                            if (!File.Exists(System.IO.Path.Combine(directorioDesctino + "/" + nombrecarpeta, nombreArchivoXml)))
                            {
                                byte[] info = new UTF8Encoding(true).GetBytes(Generar(headers, body)); //Codifica el contenido del documento (Cuerpo XML)
                                FileStream fs = File.Create(System.IO.Path.Combine(directorioDesctino + "/" + nombrecarpeta, nombreArchivoXml)); //Crea el archivo XML y lo almacena en la carpeta destino
                                fs.Write(info, 0, info.Length); //Escribe el documento con el cuerpo obtenido.
                                fs.Close();

                                ConvertXmlToXmlCanonic convertXmlToXmlCanonic = new ConvertXmlToXmlCanonic();
                                convertXmlToXmlCanonic.ObtenerArchivoXml(directorioDesctino + "/" + nombrecarpeta, nombreArchivoXml);
                            }
                        }
                    }
                }
                else
                {
                }

            }
        }
        public static string Generar(string[] headers, string[] body)
        {
            string documento = "";
            documento += "<documento_" + body[0] + ">\n";
            for (int i = 0; i < body.GetLength(0); i++)
            {
                documento += "\t<" + headers[i] + ">" + body[i] + "</" + headers[i] + ">\n";
            }
            documento += "</documento_" + body[0] + ">";
            return documento;
        }
    }
}
