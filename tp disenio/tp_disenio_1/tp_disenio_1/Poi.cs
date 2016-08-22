using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    public abstract class Poi 
    {
        protected double longitud;
        protected double latitud;
        public string nombre;
        protected string direccion;
        public HorarioDeAtencion horario;

        public Poi() { }

        public Poi(double latitud, double longitud, string nombre, string direccion, HorarioDeAtencion horario)
        {
            this.longitud = longitud;
            this.latitud = latitud;
            this.nombre = nombre;
            this.direccion = direccion;
            this.horario = horario;
        }

        public string obtenerDireccion()
        {
            return this.direccion;
        }

        public double obtenerLongitud()
        {
            return this.longitud;
        }
        public double obtenerLatitud()
        {
            return this.latitud;
        }
        public string obtenerNombre()
        {
            return this.nombre;
        }

        public void inicializoPoi(double latitud, double longitud, string nombre, string direccion)
        {
            this.longitud = longitud;
            this.latitud = latitud;
            this.nombre = nombre;
            this.direccion = direccion;
        }

    
        public bool esValido()
        {
            return this.nombre != "" && this.longitud != 0 && this.latitud != 0;
        }

        public bool estaCercaDe(double latitud, double longitud)
        {
            double metros = this.distanciaDeCoordenadas(latitud, longitud);
            return metros < 500;
        }

       


        public bool estaDisponible(DateTime fecha, String texto)
        {
            return this.horario.estaDisponibleEnFecha(fecha);
        }

           
        /*public double distanciaDeCoordenadas(double latitud, double longitud)
        {
            double earthRadius = 6371000;
            double dLat = convertToRadians(this.latitud - latitud);
            double dLng = convertToRadians(this.longitud - longitud);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(convertToRadians(latitud)) * Math.Cos(convertToRadians(this.latitud)) *
                       Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            float dist = (float)(earthRadius * c);

            return dist;

        }*/

        
        public double distanciaDeCoordenadas(double latitud, double longitud)
        {
            double resultado = Math.Sqrt(Math.Pow((latitud-this.latitud),2) + Math.Pow((longitud * longitud),2)); 
            return resultado;
        }



        private double convertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public bool matcheaBusqueda(String texto)
        {
            if (texto == direccion || texto == nombre || texto == Convert.ToString(this.latitud) + " " + Convert.ToString(this.longitud))
            {
                return true;
            }
            else
            {
                return this.matcheaBusquedaEspecifico(texto);
            }
        }

        public abstract bool matcheaBusquedaEspecifico(String texto);

        public virtual void actualizarLocal(HashSet<string> palabras) { }



    }
}
