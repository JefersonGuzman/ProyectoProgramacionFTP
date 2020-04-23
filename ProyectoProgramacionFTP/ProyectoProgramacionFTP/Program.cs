using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
        static void Main()
        {
            MoverArchivosFTP();
        }

        //Este Metodo lo que hace es mover los archivos 
        public static void MoverArchivosFTP()
        {

            string NombreArchivo = "prueba_1.csv";
            string CarpOrigen = @"C:\Users\Windows\Desktop\Programacion C·\ProyectoFinalFTP\archivosCSV";
            string CarpDestino = @"C:\Users\Windows\Desktop\Programacion C·\ProyectoFinalFTP\archivos\archivoXML";
            string sourceFile = System.IO.Path.Combine(CarpOrigen, NombreArchivo);
            string destFile = System.IO.Path.Combine(CarpDestino, NombreArchivo);

            System.IO.Directory.CreateDirectory(CarpDestino);
            System.IO.File.Copy(sourceFile, destFile, true);


            if (System.IO.Directory.Exists(CarpOrigen))
            {
                string[] files = System.IO.Directory.GetFiles(CarpOrigen);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    Thread.Sleep(600);
                    NombreArchivo = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(CarpDestino, NombreArchivo);
                    System.IO.File.Copy(s, destFile, true);
                    Console.WriteLine("Trasferiendo el Archivo.................... " + NombreArchivo);
                }
                //File.Delete(destFile);
                if (Directory.Exists(CarpOrigen))
                {
                    foreach (var item in Directory.GetFiles(CarpOrigen, "*.*"))
                    {
                        NombreArchivo = System.IO.Path.GetFileName(item);
                        File.SetAttributes(item, FileAttributes.Normal);
                        Thread.Sleep(600);
                        File.Delete(item);
                        Console.WriteLine("Eliminando el Archivo...................." + NombreArchivo);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Existe El Archivo");
            }


        }


    }

}
