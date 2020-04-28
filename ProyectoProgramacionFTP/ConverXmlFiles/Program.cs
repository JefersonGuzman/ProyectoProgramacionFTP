using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConverXmlFiles
{
    public class Program
    {
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
        }

        public void IniciarItervalo()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 600;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += LeerArchivosCSV;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;

            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();
            // Start the timer

        }

        public  static void LeerArchivosCSV(Object source, System.Timers.ElapsedEventArgs e)
        {
            
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/DocumentosXml");
            string directorioOrigen = Path.GetFullPath(fullPath + "/Documentos/DocumentosCSV");
            if (!System.IO.Directory.Exists(directorioDesctino))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(directorioDesctino, ""));
            }
            Console.WriteLine("convert");
            if (System.IO.Directory.Exists(directorioOrigen))
            {
                string[] directory = System.IO.Directory.GetFiles(@directorioOrigen);
                if (directory.Length > 0)
                {
                    foreach (var files in directory)
                    {

                        Thread.Sleep(2000);
                        string nameFile = System.IO.Path.GetFileName(files);
                        var firstColumn = new List<string>();
                        var lastColumn = new List<string>();
                        string[] lineas = File.ReadAllLines(System.IO.Path.Combine(directorioOrigen, nameFile));
                        Console.WriteLine(lineas.Length);
                        if (lineas.Length > 0)
                        {
                            string[] headers = lineas[0].Split(';');
                            string[] body = lineas[1].Split(';');
                            string nameFileXml = body[0] + "_" + nameFile.Replace(".csv", ".xml");
                            FileStream fs = File.Create(System.IO.Path.Combine(directorioDesctino, nameFileXml));
                            byte[] info = new UTF8Encoding(true).GetBytes(Generar(headers, body));
                            fs.Write(info, 0, info.Length);
                        }
                    }
                }
                else
                {
                    aTimer.Enabled = false;
                }

            }
        }

        public void Pruebas()
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
                if (directory.Length > 0)
                {
                    foreach (var files in directory)
                    {

                        Thread.Sleep(2000);
                        string nameFile = System.IO.Path.GetFileName(files);
                        var firstColumn = new List<string>();
                        var lastColumn = new List<string>();
                        string[] lineas = File.ReadAllLines(System.IO.Path.Combine(directorioOrigen, nameFile));
                        Console.WriteLine(lineas.Length);
                        if (lineas.Length > 0)
                        {
                            string[] headers = lineas[0].Split(';');
                            string[] body = lineas[1].Split(';');
                            string nameFileXml = body[0] + "_"+ nameFile.Replace(".csv", ".xml");
                            FileStream fs = File.Create(System.IO.Path.Combine(directorioDesctino, nameFileXml));
                            byte[] info = new UTF8Encoding(true).GetBytes(Generar(headers, body));
                            fs.Write(info, 0, info.Length);
                        }
                    }
                }
                else
                {
                    aTimer.Enabled = false;
                }
                
            }
        }

        public static string Generar(string[] headers, string[] body)
        {
            string documento = "";
            documento += "<documento_" + body[0]+">\n";
            for (int i = 0; i < body.GetLength(0); i++)
            {
                documento += "\t<" + headers[i] + ">" + body[i] +"</"+ headers[i]  + ">\n";
            }
            documento += "</documento_" + body[0] + ">";
            return documento;
        }
        public void FinalizarIntervalo() //Detiene la lectura de archivos csv
        {

        }
    }
}
