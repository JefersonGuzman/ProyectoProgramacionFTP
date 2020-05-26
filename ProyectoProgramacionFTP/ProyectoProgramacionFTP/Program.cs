using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ConverXmlFiles;
using System.Timers;
using Timer = System.Timers.Timer;
using ProyectoProgramacionFTP.SubProcesos;
//using System.IO.File;
//using System.IO.Directory;

namespace ConsoleApp1
{

    public class SimpleFileCopy
    {
        private static ConvertCsvToXml convertCsvTo;
        private static AgruparXmlColas agruparXmlColas;
        static void Main()
        {
            agruparXmlColas = new AgruparXmlColas();
            convertCsvTo = new ConvertCsvToXml();
            do
            {
                Task.Run(async () =>
                {
                    Task<bool> prueba = agruparXmlColas.AgruparDocumentosXmlCanonicos();
                    MoverArchivosFTP();
                }).GetAwaiter().GetResult();
            } while (true);
        }

        //Este Metodo lo que hace es mover los archivos 
        public static void MoverArchivosFTP()
        {
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/DocumentosCSV");
            string directorioOrigen = Path.GetFullPath(fullPath + "/Documentos/GeneraDocumentosCSV");

            if (!System.IO.Directory.Exists(directorioDesctino))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(directorioDesctino, ""));
            }
            if (System.IO.Directory.Exists(directorioOrigen))
            {
                string[] directory = System.IO.Directory.GetFiles(@directorioOrigen);
                foreach (var files in directory)
                {
                    Thread.Sleep(2000);
                    string nameFile = System.IO.Path.GetFileName(files);
                    string fileDestino = (System.IO.Path.Combine(directorioDesctino, nameFile));
                    System.IO.File.Move(files, fileDestino);
                    Console.WriteLine("Transfiriendo archivos CSV a la carpeta Origen.................... " + nameFile);
                    convertCsvTo.LeerArchivosCSV();
                }
            }
        }


    }

}
