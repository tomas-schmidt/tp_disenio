using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    class Servicio
    {
        public string nombre;
        public HorarioDeAtencion horario;

        public Servicio(string nombre, HorarioDeAtencion horario)
        {
            this.nombre = nombre;
            this.horario = horario;
        }
    }


}
