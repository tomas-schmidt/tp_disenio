using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    public abstract class Comando
    {
        DateTime fechaInicio;
        DateTime fechaFin;
        Usuario usuario;
        bool resultado;

        public void guardar()
        {

        }

        public abstract void ejecutar();

    }
}
