using ProyectoProgramacionFTP.Colas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.SubProcesos
{
    class LeerListaColasPrioridades
    {
        public async Task LeerListasColas() 
        {
            if (ColaPrioridadAlta.Cola.ListaVacia() != true)
            {
                ColaPrioridadAlta.Cola.ExportarDocumento();
                LeerListasColas();
            }
            else if (ColaPrioridadMedia.Cola.ListaVacia() != true)
            {
                ColaPrioridadMedia.Cola.ExportarDocumento();
                LeerListasColas();
            }
            else
            {
                ColaPrioridadBaja.Cola.ExportarDocumento();
                LeerListasColas();
            }
        }

        
    }
}
