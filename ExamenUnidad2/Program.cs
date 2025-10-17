using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamenUnidad2
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            
            var controlTelefonico = ControlTelefonico.Instancia(2);

            string[] clientes = { "Aida", "Angelita", "Jose", "Pedro", "Paolo" };
            List<Task> tareas = new List<Task>();

            foreach (var cliente in clientes)
            {
                tareas.Add(controlTelefonico.RecibirLlamada(cliente));
                await Task.Delay(500); // Simular tiempo entre llamadas
            }
            await Task.WhenAll(tareas);
            Console.WriteLine("Todas las llamadas han sido contestadas.");


            var instancia1 = ControlTelefonico.Instancia();
            var instancia2 = ControlTelefonico.Instancia();
            if (object.ReferenceEquals(instancia1, instancia2))
            {
                Console.WriteLine("Singleton confirmado: ambas referencias apuntan a la misma instancia.");
            }
            else
            {
                Console.WriteLine(" Error: las referencias apuntan a instancias diferentes.");
            }
            Console.ReadLine();
        }
    }
}
