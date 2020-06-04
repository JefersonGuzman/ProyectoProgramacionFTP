using ProyectoProgramacionFTP.Colas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoProgramacionFTP.SubProcesos
{
    ///<summary>
    ///Clase que lee la lista de prioridades
    ///</summary>
    ///<remarks>
    ///Lee las colas y los datos que se encuentran en ellos para realizar el proceso final de exportación
    ///</remarks>
    class LeerListaColasPrioridades
    {
        ///<summary>
        ///Metodo que lee las listas de colas
        ///</summary>
        ///<remarks>
        ///Se lee la lista de colas para obtener los archivos segun sus prioridades
        ///</remarks>
        public async Task LeerListasColas() 
        {
            if (ColaPrioridadAlta.Cola.ListaVacia() != true) //Valida si la lista se encuentra vacia
            {
                ColaPrioridadAlta.Cola.ExportarDocumento();
                LeerListasColas();
            }
            else if (ColaPrioridadMedia.Cola.ListaVacia() != true) //Valida si la lista se encuentra vacia
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
