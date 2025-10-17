using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamenUnidad2
{
    public class OperadorPool
    {
       
       private readonly List<Operador> operadores;
       private readonly object lockObject = new object();

        public OperadorPool(int cantidad)
        {
            operadores = new List<Operador>();
            for (int i = 0; i <= 1; i++)
            {
                operadores.Add(new Operador(i + 1));
            }
        }
        public Operador ObtenerOperadorLibre()
        {
            lock (lockObject)
            {
                foreach (var operador in operadores)
                {
                    if (!operador.Ocupado)
                    {
                        return operador;
                    }
                }
            }
            return null;
        }
        
    }
}
