using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.Clases
{
    class Nodo
    {
        XmlCanonico xmlCanonico;
        Nodo anterior, siguiente;

        internal XmlCanonico XmlCanonico { get => xmlCanonico; set => xmlCanonico = value; }
        internal Nodo Anterior { get => anterior; set => anterior = value; }
        internal Nodo Siguiente { get => siguiente; set => siguiente = value; }
    }
}
