using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    class RepositorioComandos
    {
        protected List<Comando> comandos = new List<Comando>();

        private static RepositorioComandos instance;

        private RepositorioComandos()
        {
        }

        public static RepositorioComandos Instance()
        {
            if (instance == null)
            {
                instance = new RepositorioComandos();
            }
            return instance;
        }

    }


}
