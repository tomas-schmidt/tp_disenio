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

       
            /*if (catalogo.tieneA(nombre))
            {
                (catalogo.obtenerPoi(nombre)).actualizarLocal;
            }*/


        }
    }
}
