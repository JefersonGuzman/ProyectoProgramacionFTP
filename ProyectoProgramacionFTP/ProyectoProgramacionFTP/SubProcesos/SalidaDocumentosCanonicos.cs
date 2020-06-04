﻿using ProyectoProgramacionFTP.Clases;
using ProyectoProgramacionFTP.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.SubProcesos
{
    class SalidaDocumentosCanonicos
    {
        public static Utils utl = new Utils();
        public void ProcesoSalidaDocumentosXml(XmlCanonico xmlCanonico, string carpetaCola)
        {
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/SalidaDocumentos");
            string directorioOrigen = Path.GetFullPath(fullPath + "/Documentos/Cola");

            if (!System.IO.Directory.Exists(directorioDesctino))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(directorioDesctino, ""));
            }

            if (System.IO.Directory.Exists(directorioOrigen))
            {
                string nombreArchivoXmlOutPut = "OUTPUT_" + utl.SetNombreArchivoSalida(xmlCanonico) + ".xml"; //Establece el nombre del nuevo XML (tipoDoc_nombreArchivo.xml)
                string nombreArchivoXml = xmlCanonico.Type_doc + utl.SetNombreArchivoSalida(xmlCanonico) + ".xml";
                if (File.Exists(System.IO.Path.Combine(directorioOrigen + "/" + carpetaCola, nombreArchivoXml)))
                {
                    string nombreCarpetaOutPut = utl.SetNombreCarpOutPut(xmlCanonico.Type_doc);
                    if (!System.IO.Directory.Exists(System.IO.Path.Combine(directorioDesctino + "/" + nombreCarpetaOutPut, "")))
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.Combine(directorioDesctino + "/" + nombreCarpetaOutPut, ""));
                    }

                    string rutaCompletaOrigen = System.IO.Path.Combine(directorioOrigen + "/" + carpetaCola, nombreArchivoXml);
                    string rutaCompletaDestino = System.IO.Path.Combine(directorioDesctino + "/" + nombreCarpetaOutPut, nombreArchivoXmlOutPut);
                    if (!File.Exists(System.IO.Path.Combine(directorioDesctino + "/" + nombreCarpetaOutPut, nombreArchivoXmlOutPut)))
                    {
                        long length = new System.IO.FileInfo(rutaCompletaOrigen).Length;
                        System.IO.File.Move(rutaCompletaOrigen, rutaCompletaDestino);
                        string mensaje = "Proceso completo, archivo: " + nombreArchivoXml + " - Peso:(" + length + ") bytes - Fecha proceso: " + DateTime.Today; 
                        utl.RegistroLog(mensaje, "OUT_LOG", "out_log.txt");
                    }
                    else
                    {
                        System.IO.File.Delete(rutaCompletaDestino);
                        System.IO.File.Move(rutaCompletaOrigen, rutaCompletaDestino);
                        string mensaje = "Archivo existente, archivo: " + nombreArchivoXml + " Proceso: Exporar documento final, remplazado" + " Fecha proceso: " + DateTime.Today;
                        utl.RegistroLog(mensaje, "FILE_EXIST", "file_exist.txt");
                    }
                 
                }
                else
                {
                    string ruta = System.IO.Path.Combine(directorioOrigen + "/" + carpetaCola, nombreArchivoXml);
                    string mensaje = "Directorio NO existe, archivo: (" + ruta + ") Proceso: Exporar documento final" + " Fecha proceso: " + DateTime.Today;
                    utl.RegistroLog(mensaje, "FILE_EXIST", "file_exist.txt");
                }
            }
        }
    }
}