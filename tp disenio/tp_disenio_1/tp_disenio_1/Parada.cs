using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    class Parada:Poi
    {
        protected string numero;

        public Parada(double latitud, double longitud, string nombre, string direccion, HorarioDeAtencion horario, string valor)
            :base(latitud, longitud, nombre, direccion, horario)
        {
            this.numero = valor;
        }

        public void inicializoParada(string valor)
        {
            this.numero = valor;
        }


        public new bool estaCercaDe(double latitud, double longitud)
        {
            double metros = this.distanciaDeCoordenadas(latitud, longitud);
            return metros < 100;
        }

        public bool estaDisponible(DateTime fecha, String texto)
        {
            return true;
        }

        public override bool matcheaBusquedaEspecifico(String texto)
        {
            return texto == this.numero;
        }
    }
}
