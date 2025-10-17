using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2
{
    public class Operador
    {
        public int Id { get; set; }
        public bool Ocupado { get; set; }

        public Operador(int id)
        {
            Id = id;
            Ocupado = false;
        }

        public async Task AtenderLlamada(string cliente)
        {
            Ocupado = true;
            Console.WriteLine($"Operador {Id} atendiendo llamada de {cliente}...");
            // Simular tiempo de atención
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine($"Operador {Id} terminó la llamada de {cliente}.");
            Ocupado = false;
        }
    }
}
