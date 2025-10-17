using System;
using System.Threading.Tasks;

namespace ExamenUnidad2
{
    public class ControlTelefonico
    {

        private static ControlTelefonico instancia;
        private static readonly object lockObj = new object();
        private readonly OperadorPool operadorPool;

        private ControlTelefonico(int cantidadOperadores)
        {
            operadorPool = new OperadorPool(cantidadOperadores);
        }

        public static ControlTelefonico Instancia(int cantidadOperadores = 3)
        {
            if (instancia == null)
            {
                lock (lockObj)
                {
                    if (instancia == null)
                    {
                        instancia = new ControlTelefonico(cantidadOperadores);
                    }
                }
            }
            return instancia;
        }
        public async Task RecibirLlamada(string cliente)
        {
            var operador = operadorPool.ObtenerOperadorLibre();
            if (operador != null)
            {
                operador.AtenderLlamada(cliente);
            }
            else
            {
                Console.WriteLine($"No hay operadores disponibles para atender la llamada de {cliente}. Por favor, espere.");
            }
        }
    }
}
