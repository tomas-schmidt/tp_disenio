using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_disenio_1.Comandos
{
    class Multiple: Comando
    {
        List<Comando> comandos = new List<Comando>();

        public override void ejecutar()
        {
            fechaInicio = DateTime.Now;
            try
            {
                resultado = true;
                foreach (Comando comando in comandos)
                {
                    comando.ejecutar();
                }
            }
            catch
            {
                resultado = false;
            }
            fechaFin = DateTime.Now;
        }

        public override void undo()
        { 
        
        }

    }
}
