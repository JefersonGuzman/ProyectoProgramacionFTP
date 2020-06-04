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
using ProyectoProgramacionFTP.Utilidades;
namespace ConsoleApp1
{
    ///<summary>
    ///Clase principal de la aplicación.
    ///</summary>
    ///<remarks>
    ///Lee archivos de configuración y crea los hilos que ejecutan el resto del programa.
    ///</remarks>
    public class SimpleFileCopy
    {
        public static Utils utl = new Utils(); //Instancia clase de utilidades
        private static ConvertCsvToXml convertCsvTo = new ConvertCsvToXml(); //Instancia clase que realiza el proceso de conversion de csv a xml
        private static AgruparXmlColas agruparXmlColas = new AgruparXmlColas(); //Instancia clase de agrupamiento de colas asyncronico
        private static LeerListaColasPrioridades leerListaColasPrioridades = new LeerListaColasPrioridades(); //Instancia clase de lectura de colas asyncronico

        ///<summary>
        ///Metodo inicia el proceso FTP
        ///</summary>
        ///<remarks>
        ///Proceso continuo que realiza busqueda, conversion de archivos
        ///</remarks>
        static void Main()
        {
            do
            {
                Task.Run(async () =>
                {
                    Task<bool> agrupa = agruparXmlColas.AgruparDocumentosXmlCanonicos();
                    Task lee = leerListaColasPrioridades.LeerListasColas();
                    MoverArchivosFTP();
                }).GetAwaiter().GetResult();
            } while (true);
        }

        ///<summary>
        ///Metodo Dosificador
        ///</summary>
        ///<remarks>
        ///Se encarga de mover los archivos de la carpeta origen a la carpeta CSV comun
        ///</remarks>
        public static void MoverArchivosFTP()
        {
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/DocumentosCSV"); //Define la ruta de destino de los archivos
            string directorioOrigen = Path.GetFullPath(fullPath + "/Documentos/GeneraDocumentosCSV"); //Define la ruta de origen de los archivos

            if (!System.IO.Directory.Exists(directorioDesctino))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(directorioDesctino, "")); //Crea la ruta de destino en caso de que no exista
            }
            if (System.IO.Directory.Exists(directorioOrigen))
            {
                DirectoryInfo directory = new DirectoryInfo(@directorioOrigen);
                FileInfo[] file = directory.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                foreach (var files in file)
                {
                    Thread.Sleep(2000); //Realiza temporalizador de cada 2 segundos
                    string nameFile = files.Name; //Obtiene el nombre del fichero
                    string fileDestino = (System.IO.Path.Combine(directorioDesctino, nameFile)); //Genera ruta del fichero en la ruta de destino
                    if (!File.Exists(fileDestino)) //Valida si el fiechero existe en la carpeta comun
                    {
                        File.Move(files.FullName, fileDestino); //Mueve los fiecheros a la carpeta comun
                        Console.WriteLine("Transfiriendo archivos CSV a la carpeta Origen.................... " + nameFile);
                    }
                    else
                    {
                        File.Delete(fileDestino); //Elimina el fichero existente en la carpeta comun
                        File.Move(files.FullName, fileDestino); //Mueve los fiecheros a la carpeta comun
                        string mensaje = "Archivo existente, archivo: " + fileDestino + " Proceso: Dosificador, se remplaza" + " Fecha proceso: " + DateTime.Today;
                        utl.RegistroLog(mensaje, "FILE_EXIST", "file_exist.txt"); //Registra log de procesos
                    }
                    convertCsvTo.LeerArchivosCSV(); //Realiza llamado a la lectura del fichero csv
                }
            }
            else
            {
                string mensaje = "Directorio NO existe, archivo: (" + directorioOrigen + ") Proceso: Dosificador" + " Fecha proceso: " + DateTime.Today;
                utl.RegistroLog(mensaje, "FILE_EXIST", "file_exist.txt"); //Registra log de procesos
            }

        }


    }

}
