using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    public class ActualizarLocales: Comando
    {
        private string texto;

        public ActualizarLocales(string texto)
        {
            this.texto = texto;
        }

        public override void ejecutar()
        {
            fechaInicio = DateTime.Now;
            try
            {
                resultado = true;
                string nombre;
                HashSet<string> palabrasClaves = new HashSet<string>();

                Char delimiter = ';';
                String[] substrings = texto.Split(delimiter);
                nombre = substrings[0];

                Char delimiter2 = ' ';
                String[] substrings2 = substrings[1].Split(delimiter2);

                foreach (string substring in substrings2)
                {
                    palabrasClaves.Add(substring);
                }

                CatalogoPois catalogo = CatalogoPois.Instance();

                if (catalogo.tieneA(nombre))
                {
                    /*Poi poi;
                    poi = (catalogo.obtenerPoi(nombre));
                    poi.actualizarLocal();*/

                    (catalogo.obtenerPoi(nombre)).actualizarLocal(palabrasClaves);

                }
                else
                {
                HorarioDeAtencion sinHorario;
                sinHorario = new HorarioDeAtencion(new Tuple<int, int>[]{
                new Tuple<int,int>(0,0),
                new Tuple<int,int>(0,0),
                new Tuple<int,int>(0,0),
                new Tuple<int,int>(0,0),
                new Tuple<int,int>(0,0),
                new Tuple<int,int>(0,0),
                new Tuple<int,int>(0,0),
                });

                    PoiFactory pf = new PoiFactory();
                    pf.agregarLocal(0, 0, "", nombre, sinHorario, palabrasClaves, 0);
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

        }
    }
}
