using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<Poi> resultado = new List<Poi>();
            foreach (Poi poi in pois)
            {
                if (poi.matcheaBusqueda(texto))
                {
                    resultado.Add(poi);
                }
            }
            return resultado;
        }

        public void agregarParada(double latitud, double longitud, string direccion, string nombre, HorarioDeAtencion horario, string numero)
        {
            Parada parada = new Parada(latitud, longitud, nombre, direccion, horario, numero);
            this.agregarPoi(parada);
        }

        public void agregarBanco(double latitud, double longitud, string direccion, string nombre, HorarioDeAtencion horario)
        {
            Banco banco = new Banco(latitud, longitud, nombre, direccion, horario);
            this.agregarPoi(banco);
        }

        public void agregarCGP(double latitud, double longitud, string direccion, string nombre, HorarioDeAtencion horario, int comuna, List<Servicio> servicios)
        {
            CGP cgp = new CGP(latitud, longitud, nombre, direccion, horario, comuna, servicios);
            this.agregarPoi(cgp);
        }

        public void agregarLocal(double latitud, double longitud, string direccion, string nombre, HorarioDeAtencion horario, HashSet<string> rubros, int radio)
        {
            Local local = new Local(latitud, longitud, nombre, direccion, horario, rubros, radio);
            this.agregarPoi(local);
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
