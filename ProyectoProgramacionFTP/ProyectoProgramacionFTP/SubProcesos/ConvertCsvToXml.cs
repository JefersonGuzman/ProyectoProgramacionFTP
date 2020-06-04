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
    ///<summary>
    ///Clase que convierte los archivos CSV a XML
    ///</summary>
    ///<remarks>
    ///Lee el fichero y convierte su estructura en XML
    ///</remarks>
    class ConvertCsvToXml
    {
        public static Utils utl = new Utils(); //Instancia clase de utilidades
        public static ConvertXmlToXmlCanonic convertXmlToXmlCanonic = new ConvertXmlToXmlCanonic(); //Instancia clase que convierte archivos a canonicos

        ///<summary>
        ///Metodo lectura de fichero CSV
        ///</summary>
        ///<remarks>
        ///Proceso que lee el fichero CSV y convierte la información de este en un fichero XML
        ///para luego almacenarlo en su respectiva carpeta.
        ///</remarks>
        public void LeerArchivosCSV()
        {
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/DocumentosXml"); //Define la ruta de destino de los archivos
            string directorioOrigen = Path.GetFullPath(fullPath + "/Documentos/DocumentosCSV"); //Define la ruta de origen de los archivos
            if (!System.IO.Directory.Exists(directorioDesctino))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(directorioDesctino, "")); //Crea la ruta de destino en caso de que no exista
            }

            if (System.IO.Directory.Exists(directorioOrigen))
            {
                string[] directory = System.IO.Directory.GetFiles(@directorioOrigen); //Obtiene los ficheros de la carpeta de origen
                if (directory.Length >= 1) //Valida que tenga ficheros dentro del el directorio
                {
                    foreach (var files in directory) //Recorre los ficheros obtenidos
                    {

                        string nameFile = System.IO.Path.GetFileName(files); //Obtiene el nombre de los carchivos del directorio
                        string[] lineas = File.ReadAllLines(System.IO.Path.Combine(directorioOrigen, nameFile)); //Lee las lineas del csv
                        if (lineas.Length > 0) //Valida si el archivo tiene mas contenido
                        {
                            string[] headers = lineas[0].Split(';'); //Se almacena la primer fila como headers
                            string[] body = lineas[1].Split(';'); //Se almacena la segunda fila como el body del documento
                            string nombreArchivoXml = body[0] + "_" + nameFile.Replace(".csv", ".xml"); //Establece el nombre del nuevo XML (tipoDoc_nombreArchivo.xml)
                            string nombrecarpeta = utl.SetNombreCarpSegXml(body[0]);
                            if (!File.Exists(System.IO.Path.Combine(directorioDesctino + "/" + nombrecarpeta, nombreArchivoXml)))
                            {
                                byte[] info = new UTF8Encoding(true).GetBytes(Generar(headers, body)); //Codifica el contenido del documento (Cuerpo XML)
                                FileStream fs = File.Create(System.IO.Path.Combine(directorioDesctino + "/" + nombrecarpeta, nombreArchivoXml)); //Crea el archivo XML y lo almacena en la carpeta destino
                                fs.Write(info, 0, info.Length); //Escribe el documento con el cuerpo obtenido.
                                fs.Close();
                                convertXmlToXmlCanonic.ObtenerArchivoXml(directorioDesctino + "/" + nombrecarpeta, nombreArchivoXml); //Llama a metodo que genera los xml canonicos
                            }
                            else
                            {
                                File.Delete(System.IO.Path.Combine(directorioDesctino + "/" + nombrecarpeta, nombreArchivoXml));
                                byte[] info = new UTF8Encoding(true).GetBytes(Generar(headers, body)); //Codifica el contenido del documento (Cuerpo XML)
                                FileStream fs = File.Create(System.IO.Path.Combine(directorioDesctino + "/" + nombrecarpeta, nombreArchivoXml)); //Crea el archivo XML y lo almacena en la carpeta destino
                                fs.Write(info, 0, info.Length); //Escribe el documento con el cuerpo obtenido.
                                fs.Close();

                                convertXmlToXmlCanonic.ObtenerArchivoXml(directorioDesctino + "/" + nombrecarpeta, nombreArchivoXml); //Llama a metodo que genera los xml canonicos

                                string mensaje = "Archivo existente, archivo: " + nombreArchivoXml + " Proceso: Convertir CSV a XML, se remplaza" + " Fecha proceso: " + DateTime.Today;
                                utl.RegistroLog(mensaje, "FILE_EXIST", "file_exist.txt"); //Realiza registro al log
                            }
                        }
                    }
                }
                else
                {
                    string mensaje = "Directorio VACIO, archivo: (" + directorioOrigen + ") Proceso: Convertir CSV a XML" + " Fecha proceso: " + DateTime.Today;
                    utl.RegistroLog(mensaje, "DIRECTORY_EMPTY", "directory_empty.txt"); //Realiza registro del log
                }

            }
            else
            {
                string mensaje = "Directorio NO existe, archivo: (" + directorioOrigen + ") Proceso: Convertir CSV a XML" + " Fecha proceso: " + DateTime.Today;
                utl.RegistroLog(mensaje, "FILE_EXIST", "file_exist.txt"); //Realiza registro del log
            }
        }

        ///<summary>
        ///Metodo Genera estructura
        ///</summary>
        ///<remarks>
        ///Proceso que realiza la estructuración del documento XML de acuerto a los datos obtenidos por el fichero CSV
        ///</remarks>
        ///<param name="headers">Datos de la cabecera</param>
        ///<param name="body">Datos de la cuerpo</param>
        ///<returns>Devuelve en estructura de texto los datos del XML</returns>
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
