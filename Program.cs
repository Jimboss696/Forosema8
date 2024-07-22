using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Forosema8
{
    // Clase principal del programa
class Program
    {
        static void Main()
        {
            // Crear una instancia del planificador con un quantum de 3 unidades de tiempo
            PlanificadorRoundRobin planificador = new PlanificadorRoundRobin(quantum: 3);

            // Agregar procesos al planificador
            planificador.AgregarProceso("Proceso 1", 10);
            planificador.AgregarProceso("Proceso 2", 4);
            planificador.AgregarProceso("Proceso 3", 6);

            // Ejecutar la planificación de procesos
            planificador.Ejecutar();
            Console.Read();
        }
    }
}
