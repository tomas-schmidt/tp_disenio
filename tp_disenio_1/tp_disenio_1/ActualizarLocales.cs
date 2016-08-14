using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1
{
    class ActualizarLocales: Comando
    {
        private string texto;

        private ActualizarLocales(string texto)
        {
            this.texto = texto;
        }

        public override void ejecutar()
        {
            fechaInicio = DateTime.Now;
            string nombre;
            List<string> palabrasClaves = new List<string>();

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
                Poi poi;
                poi = (catalogo.obtenerPoi(nombre));
                poi.actualizarLocal();
                resultado = true;
               
            }
            else
            {
                resultado = false;
            }

            fechaInicio = DateTime.Now;
            this.guardar();
            


        }
    }
}
