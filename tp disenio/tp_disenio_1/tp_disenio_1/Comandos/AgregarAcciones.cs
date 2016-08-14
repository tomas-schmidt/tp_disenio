using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1.Comandos
{
    class AgregarAcciones : Comando
    {

        private string nombreRol;
        private List<string> acciones = new List<string>();


        private AgregarAcciones(string nombreRol, List<string> acciones)
        {
            this.nombreRol = nombreRol;
            this.acciones = acciones;
        }


        public override void ejecutar()
        {
            fechaInicio = DateTime.Now;
            try
            {
                resultado = true;
                RepositorioRoles repoRoles = RepositorioRoles.Instance();

                foreach (Rol rol in repoRoles.obtenerRoles())
                {
                    if (rol.obtenerNombre() == nombreRol)
                    {
                        foreach (string accion in acciones)
                        {
                            rol.agregarAccion(accion);
                        }
                    }
                }
            }

            catch
            {
                resultado = false;
            }

            fechaFin = DateTime.Now;
            this.guardar();
        }

        public override void undo()
        {
            RepositorioRoles repoRoles = RepositorioRoles.Instance();

            foreach (Rol rol in repoRoles.obtenerRoles())
            {
                if (rol.obtenerNombre() == nombreRol)
                {
                    foreach (string accion in acciones)
                    {
                        rol.removerAccion(accion);
                    }
                }
            }
        }
    }
}
