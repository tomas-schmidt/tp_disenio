using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    class RepositorioRoles
    {
        List<Rol> roles = new List<Rol>();
        private static RepositorioRoles instance;


        private RepositorioRoles()
        {
        }

        public static RepositorioRoles Instance()
        {
            if (instance == null)
            {
                instance = new RepositorioRoles();
            }
            return instance;
        }

        public List<Rol> obtenerRoles()
        {
            return this.roles;
        }

        private void agregarRol(Rol rol)
        {
            roles.Add(rol);
        }

    }
}
