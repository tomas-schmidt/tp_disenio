using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using tp_disenio_1.Reportes;
using System.Data;

namespace tp_disenio_1
{
    class CatalogoPois
    {
        protected List<Poi> pois = new List<Poi>();
        private static CatalogoPois instance;

        private CatalogoPois()
        {
        }

        public static CatalogoPois Instance()
        {
            if (instance == null)
            {
                instance = new CatalogoPois();
            }
            return instance;
        }

        public void agregarPoi(Poi poiNuevo)
        {
           pois.Add(poiNuevo);
        }

        public void eliminarPoi(Poi poiNuevo)
        {
            pois.Remove(poiNuevo);
        }


        public List<Poi> lista()
        {
            return this.pois;
        }


        
       
        public List<Poi> buscar(String texto)
        {
            DateTime inicio = DateTime.Now;
            int inicioSecond = inicio.Second;

            List<Poi> resultado = new List<Poi>();
            foreach (Poi poi in pois)
            {
                if (poi.matcheaBusqueda(texto))
                {
                    resultado.Add(poi);
                }
            }

            DateTime fin = DateTime.Now;
            int finSecond = fin.Second;
            int tiempoConsulta = finSecond - inicioSecond;

            Reporte reporte = new Reporte();
            reporte.ProcesarConsulta(texto, resultado.Count(), tiempoConsulta);            

            return resultado;
        }

        

        public bool tieneA(string nombre)
        {
            foreach (Poi poi in pois)
            {
                if (poi.obtenerNombre() == nombre)
                {
                    return true;
                }
            }
            return false;
        }

        public Poi obtenerPoi(string nombre)
        {
            Poi poi;
            poi =pois.Find(p => p.obtenerNombre() == nombre);
            return poi;
        }


    }
}
