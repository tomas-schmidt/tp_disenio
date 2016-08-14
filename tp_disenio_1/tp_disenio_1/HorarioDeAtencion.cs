using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    public class HorarioDeAtencion
    {
        public Tuple<int, int>[] horarios = new Tuple<int, int>[6];

        public bool estaDisponibleEnFecha(DateTime fecha)
        {
            return fecha.Hour >= this.horarios[Convert.ToInt32(fecha.DayOfWeek)].Item1 &&
                   fecha.Hour <= this.horarios[Convert.ToInt32(fecha.DayOfWeek)].Item2;
        }

        public HorarioDeAtencion(Tuple<int, int>[] horarios)
        {
            this.horarios = horarios;
        }
    }
}
