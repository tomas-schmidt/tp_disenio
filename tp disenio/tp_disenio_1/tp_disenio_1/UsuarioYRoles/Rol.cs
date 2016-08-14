using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    class Rol
    {
        string nombre;
        List<string> acciones = new List<string>();

        public void agregarAccion(string accion)
        {
            acciones.Add(accion);
        }

        public void removerAccion(string accion)
        {
            acciones.Remove(accion);
        }

        public string obtenerNombre()
        {
            return this.nombre;
        }
    }
}
