using System;
using System.Collections.Generic;

namespace tp_disenio_1
{
    class Local:Poi
    {
        private HashSet<string> rubros;
        private double radioDeCercania;
        

        public Local(double latitud, double longitud, string nombre, string direccion, HorarioDeAtencion horario, HashSet<string> rubros, int radioDeCercania)
            :base(latitud, longitud, nombre, direccion, horario)
        {
            this.rubros = rubros;
            this.radioDeCercania = radioDeCercania;
        }


        public bool estaDisponible(DateTime fecha, String texto)
        {
            return this.horario.estaDisponibleEnFecha(fecha);
        }

        public void inicializoLocal(double radioDeCercania, HashSet<string> rubros)
        {
            this.radioDeCercania = radioDeCercania;
            this.rubros = rubros;
        }

        public bool estaCercaDe(double latitud, double longitud)
        {
            double metros = this.distanciaDeCoordenadas(latitud, longitud);
            return metros < radioDeCercania;
        }

        public override bool matcheaBusquedaEspecifico(String texto)
        {
            return rubros.Contains(texto);
        }

        public void actualizarLocal(HashSet<string> palabras)
        {
            foreach(string palabra in palabras)
                this.rubros.Add(palabra);
        }




        
    }
}
