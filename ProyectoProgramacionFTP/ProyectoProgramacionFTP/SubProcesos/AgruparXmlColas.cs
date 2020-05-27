using ProyectoProgramacionFTP.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.SubProcesos
{
    class AgruparXmlColas
    {
        public async Task<bool> AgruparDocumentosXmlCanonicos()
        {
            string fullPath = @"..\..\";
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/Cola");
            string directorioOrigen = Path.GetFullPath(fullPath + "/Documentos/Canonicos");
            if (!System.IO.Directory.Exists(directorioDesctino))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(directorioDesctino, ""));
            }
            if (System.IO.Directory.Exists(directorioOrigen))
            {
                string[] directory = System.IO.Directory.GetFiles(@directorioOrigen);
                foreach (var files in directory)
                {
                    string nameFile = System.IO.Path.GetFileName(files);
                    Utils utl = new Utils();
                    String[] TipoArchivo = nameFile.Split('_');
                    string nombreCarpeta = utl.SetNombreCarpetaCola(TipoArchivo[0]);
                    string fileDestino = (System.IO.Path.Combine(directorioDesctino + "/" + nombreCarpeta, nameFile));
                    System.IO.File.Move(files, fileDestino);
                    Console.WriteLine("Transfiriendo archivos CANONICOS a la carpeta Origen.................... " + nameFile);
                }
            }
            return true;
        }
    }
}
