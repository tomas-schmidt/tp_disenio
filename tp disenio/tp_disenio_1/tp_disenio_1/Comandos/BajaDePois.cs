using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1.Comandos
{
    class BajaDePois: Comando
    {
        private DateTime fechaDeBaja;
        private string valorBusqueda;

        public BajaDePois(string valorBusqueda, DateTime fechaDeBaja)
        {
            this.fechaDeBaja = fechaDeBaja;
            this.valorBusqueda = valorBusqueda;
        }

        public override void ejecutar()
        {
            fechaInicio = fechaDeBaja;

            try
            {
                resultado = true;
                List<Poi> poisAEliminar = new List<Poi>();

                CatalogoPois catalogo = CatalogoPois.Instance();

                poisAEliminar = catalogo.buscar(valorBusqueda);


                foreach(Poi poi in poisAEliminar)
                {
                    catalogo.eliminarPoi(poi);
                }
            }

            catch
            {
                resultado = false;
            }

            fechaFin = DateTime.Now;
            this.guardar(); ;
        }

        public override void undo()
        {
        }
    }
}
