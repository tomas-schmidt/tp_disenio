using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    class CGP:Poi
    {
        int comuna;
        protected List<Servicio> servicios;

        public CGP(double latitud, double longitud, string nombre, string direccion, HorarioDeAtencion horario, int comuna, List<Servicio> servicios)
            :base(latitud, longitud, nombre, direccion, horario)
        {
            this.comuna = comuna;
            this.servicios = servicios;
        }

        public new bool estaCercaDe(double latitud, double longitud)
        {
            return true;
        }



        public bool estaDisponible(DateTime fecha, String texto)
        {
            if (texto == "")
            {
                foreach (Servicio servicio in servicios)
                {
                    if (servicio.horario.estaDisponibleEnFecha(fecha))
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (Servicio servicio in servicios)
                {
                    if (servicio.horario.estaDisponibleEnFecha(fecha) && servicio.nombre == texto)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    


          public override bool matcheaBusquedaEspecifico(String texto)
          {
            foreach (Servicio servicio in servicios)
            {
                if (servicio.nombre.Contains(texto))
                {
                    return true;
                }

            }
            return false;
          }






        }
    }

