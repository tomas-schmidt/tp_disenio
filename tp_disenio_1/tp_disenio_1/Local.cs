using System;

namespace tp_disenio_1
{
    class Local:Poi
    {
        private string rubro;
        private double radioDeCercania;

        public Local(double latitud, double longitud, string nombre, string direccion, HorarioDeAtencion horario, string rubro, int radioDeCercania)
            :base(latitud, longitud, nombre, direccion, horario)
        {
            this.rubro = rubro;
            this.radioDeCercania = radioDeCercania;
        }


        public bool estaDisponible(DateTime fecha, String texto)
        {
            return this.horario.estaDisponibleEnFecha(fecha);
        }

        public void inicializoLocal(double radioDeCercania, string rubro)
        {
            this.radioDeCercania = radioDeCercania;
            this.rubro = rubro;
        }

        public bool estaCercaDe(double latitud, double longitud)
        {
            double metros = this.distanciaDeCoordenadas(latitud, longitud);
            return metros < radioDeCercania;
        }

        public override bool matcheaBusquedaEspecifico(String texto)
        {
            return texto == this.rubro;
        }



        
    }
}
