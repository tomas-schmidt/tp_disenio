using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    class PoiFactory
    {
        CatalogoPois catalogo = CatalogoPois.Instance();


        public void agregarParada(double latitud, double longitud, string direccion, string nombre, HorarioDeAtencion horario, string numero)
        {
            Parada parada = new Parada(latitud, longitud, nombre, direccion, horario, numero);
            catalogo.agregarPoi(parada);
        }

        public void agregarBanco(double latitud, double longitud, string direccion, string nombre, HorarioDeAtencion horario)
        {
            Banco banco = new Banco(latitud, longitud, nombre, direccion, horario);
            catalogo.agregarPoi(banco);
        }

        public void agregarCGP(double latitud, double longitud, string direccion, string nombre, HorarioDeAtencion horario, int comuna, List<Servicio> servicios)
        {
            CGP cgp = new CGP(latitud, longitud, nombre, direccion, horario, comuna, servicios);
            catalogo.agregarPoi(cgp);
        }

        public void agregarLocal(double latitud, double longitud, string direccion, string nombre, HorarioDeAtencion horario, HashSet<string> rubros, int radio)
        {
            Local local = new Local(latitud, longitud, nombre, direccion, horario, rubros, radio);
            catalogo.agregarPoi(local);
        }
    }
}
