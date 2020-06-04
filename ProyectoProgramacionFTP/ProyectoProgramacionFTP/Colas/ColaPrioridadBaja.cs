using ProyectoProgramacionFTP.Clases;
using ProyectoProgramacionFTP.SubProcesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.Colas
{
    class ColaPrioridadBaja
    {
        private Nodo cabeza;
        public static ColaPrioridadBaja Cola = new ColaPrioridadBaja();
        public static SalidaDocumentosCanonicos salida = new SalidaDocumentosCanonicos();

        private ColaPrioridadBaja() { }

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
            Nodo eliminarNodo = cabeza;
            XmlCanonico datosXmlNodo = cabeza.XmlCanonico;
            if (!ListaVacia())
            {
                eliminarNodo = eliminarNodo.Siguiente;
                cabeza = null;
                cabeza = eliminarNodo;
            }

            salida.ProcesoSalidaDocumentosXml(datosXmlNodo, "Baja");
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
    }
}
