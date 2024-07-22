using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forosema8
{
    // Clase que representa un Proceso en el sistema
    class Proceso
    {
        public string Nombre { get; set; } // Nombre del proceso
        public int TiempoRestante { get; set; } // Tiempo restante para que el proceso termine

        // Constructor que inicializa el nombre y el tiempo restante del proceso
        public Proceso(string nombre, int tiempoRestante)
        {
            Nombre = nombre;
            TiempoRestante = tiempoRestante;
        }
    }

    // Clase que implementa el algoritmo de planificación Round Robin
    class PlanificadorRoundRobin
    {
        private Queue<Proceso> colaProcesos = new Queue<Proceso>(); // Cola para manejar los procesos
        private int quantum; // Tiempo fijo asignado a cada proceso en cada ciclo

        // Constructor que inicializa el quantum
        public PlanificadorRoundRobin(int quantum)
        {
            this.quantum = quantum;
        }

        // Método para agregar un nuevo proceso a la cola
        public void AgregarProceso(string nombre, int tiempoRestante)
        {
            colaProcesos.Enqueue(new Proceso(nombre, tiempoRestante)); // Se encola un nuevo proceso
            Console.WriteLine($"{nombre} agregado a la cola con {tiempoRestante} unidades de tiempo restantes.");
        }

        // Método para ejecutar la planificación de procesos
        public void Ejecutar()
        {
            // Mientras haya procesos en la cola
            while (colaProcesos.Count > 0)
            {
                Proceso procesoActual = colaProcesos.Dequeue(); // Desencolar el primer proceso
                Console.WriteLine($"Ejecutando {procesoActual.Nombre}...");

                // Si el proceso no puede completarse en el tiempo del quantum
                if (procesoActual.TiempoRestante > quantum)
                {
                    procesoActual.TiempoRestante -= quantum; // Se reduce el tiempo restante del proceso
                    Console.WriteLine($"{procesoActual.Nombre} no ha terminado. Tiempo restante: {procesoActual.TiempoRestante} unidades.");
                    colaProcesos.Enqueue(procesoActual); // Se encola nuevamente el proceso al final de la cola
                }
                else
                {
                    // Si el proceso puede completarse en el tiempo del quantum
                    Console.WriteLine($"{procesoActual.Nombre} ha terminado su ejecución.");
                }
            }
        }
    }
}
