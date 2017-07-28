using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapos
{
    class Program
    {
        static void Main(string[] args)
        {
            Partida partida;

            partida = new Partida();

            while (!partida.comprobarGanador())
            {
                partida.matarPersonaje();
            }

            Console.Write("Pulsa intro para salir...");
            Console.ReadLine();
        }


    }
}
