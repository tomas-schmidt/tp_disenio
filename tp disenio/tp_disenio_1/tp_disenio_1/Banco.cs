using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    class Banco:Poi
    {
        public Banco(double latitud, double longitud, string nombre, string direccion, HorarioDeAtencion horario)
            :base(latitud, longitud, nombre, direccion, horario)
        {
        }

        public bool estaDisponible(DateTime fecha, String texto)
        {
            return this.horario.estaDisponibleEnFecha(fecha);
        }

        public override bool matcheaBusquedaEspecifico(String texto)
        {
            return false;
        }

      
    }
}
