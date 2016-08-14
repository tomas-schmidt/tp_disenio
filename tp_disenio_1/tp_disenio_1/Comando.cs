using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    public abstract class Comando
    {
        public DateTime fechaInicio;
        public DateTime fechaFin;
        public Usuario usuario = new Usuario();
        public bool resultado;

        public void guardar()
        {
            RepositorioComandos comandos = RepositorioComandos.Instance();
            comandos.agregarComando(this);
        }

        public abstract void ejecutar();

    }
}
