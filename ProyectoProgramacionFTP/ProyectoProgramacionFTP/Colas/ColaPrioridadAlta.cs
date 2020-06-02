using ProyectoProgramacionFTP.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.Colas
{
    class ColaPrioridadAlta
    {
        private Nodo cabeza;
        public static ColaPrioridadAlta Cola = new ColaPrioridadAlta();
        
        private ColaPrioridadAlta() { }

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
            Console.WriteLine(valorCola);
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

        public void EliminarPorPosicion() 
        {
            Nodo eliminarNodo = cabeza;
            if (!ListaVacia())
            {
                eliminarNodo = eliminarNodo.Siguiente;
                cabeza = null;
                cabeza = eliminarNodo;
            }
        }
    }
}
