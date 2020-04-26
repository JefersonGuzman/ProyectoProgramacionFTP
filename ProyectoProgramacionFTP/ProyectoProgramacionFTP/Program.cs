using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;


//using System.IO.File;
//using System.IO.Directory;

namespace ConsoleApp1
{

    // Simple synchronous file copy operations with no user interface.
    // To run this sample, first create the following directories and files:
    // C:\Users\Public\TestFolder
    // C:\Users\Public\TestFolder\test.txt
    // C:\Users\Public\TestFolder\SubDir\test.txt
    public class SimpleFileCopy
    {
        static void Main()
        {
            MoverArchivosFTP();
            //ConverXmlFiles.Program convert = new ConverXmlFiles.Program();
        }

        public static void CrearExcelPrueba()
        {
            string parthFile = AppDomain.CurrentDomain.BaseDirectory + "prueba_1.csv";

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
                }
            }
        }


    }

}
