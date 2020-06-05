using ProyectoProgramacionFTP.Clases;
using ProyectoProgramacionFTP.SubProcesos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.Colas
{
    class ColaPrioridadMedia
    {
        private Nodo cabeza;
        public static ColaPrioridadMedia Cola = new ColaPrioridadMedia();
        public static SalidaDocumentosCanonicos salida = new SalidaDocumentosCanonicos();

        private ColaPrioridadMedia() { }

        public bool ListaVacia()
        {
            if (cabeza == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AgregarElementosAlInicio(XmlCanonico valorCola)
        {
            Nodo Nuevo = new Nodo();
            Nuevo.XmlCanonico = valorCola;
            if (ListaVacia())
            {
                cabeza = Nuevo;
            }
            else
            {
                Nuevo.Siguiente = cabeza;
                cabeza = Nuevo;
            }
        }

        public void ExportarDocumento()
        {
            int count = 0;
            if (!ListaVacia())
            {
                Nodo eliminarNodo = cabeza;
                Nodo Referencia = new Nodo();
                while (eliminarNodo != null) //Recorremos la lista
                {
                    if (eliminarNodo.Siguiente != null)
                    {
                        Referencia = eliminarNodo;
                    }
                    eliminarNodo = eliminarNodo.Siguiente;
                    count++;
                }
                if (count == 1)
                {
                    XmlCanonico datosXmlNodo = cabeza.XmlCanonico;
                    salida.ProcesoSalidaDocumentosXml(datosXmlNodo, "Media");
                    if (salida.ProcesoSalidaDocumentosXml(datosXmlNodo, "Media") == true)
                    {
                        cabeza = null;
                    }
                }
                else
                {
                    XmlCanonico datosXmlNodo = Referencia.Siguiente.XmlCanonico;
                    Referencia.Siguiente = null;

                    if (salida.ProcesoSalidaDocumentosXml(datosXmlNodo, "Media") == true)
                    {
                        eliminarNodo = Referencia;
                    }

                }
            }
        }

        public void Imprimir() //Metodo que permite imprimir
        {
            Nodo recorrido = cabeza;
            while (recorrido != null) //Recorre mientras el nodo != null
            {
                Console.Write(recorrido.XmlCanonico.ToString() + " ->"); //Imprime los nodos de la lista
                recorrido = recorrido.Siguiente; //Avanza con el siguiente nodo.
                Console.Write("*\n");
            }
            Console.WriteLine("*\n");
        }

        public bool ValidaFicherosCola()
        {
            string fullPath = @"..\..\";
            string @directorioOrigen = Path.GetFullPath(fullPath + "/Documentos/Cola/Media");
            string directorioDesctino = Path.GetFullPath(fullPath + "/Documentos/Canonicos");
            string[] directory = System.IO.Directory.GetFiles(@directorioOrigen);
            if (directory.Length > 1)
            {
                if (CantidadElementos() == 1)
                {
                    foreach (var files in directory)
                    {
                        string nameFile = System.IO.Path.GetFileName(files);
                        string fileDestino = (System.IO.Path.Combine(directorioDesctino, nameFile));
                        if (File.Exists(System.IO.Path.Combine(directorioDesctino, nameFile)))
                        {
                            File.Delete(fileDestino);
                            File.Move(files, fileDestino);
                            if (File.Exists(files))
                            {
                                File.Delete(files);
                            }
                            cabeza = null;
                            return false;
                        }
                        else
                        {
                            System.IO.File.Move(files, fileDestino);
                            cabeza = null;
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public int CantidadElementos()
        {
            int cantidad = 0;
            if (!ListaVacia())
            {
                Nodo recorrido = cabeza;
                do
                {
                    cantidad++;
                    recorrido = recorrido.Siguiente;
                } while (recorrido != null);
            }

            return cantidad;
        }
    }
}
