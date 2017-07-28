using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapos
{
    public class Partida
    {
        LinkedList<Jugador> jugadores;
        LinkedList<CharacterEnum> personajesVivos;

        public Partida()
        {
            byte numJugador = introduceNumeroJugadores();
            jugadores = new LinkedList<Jugador>();
            for (int jugador =1; jugador <= numJugador; jugador++)
            {
                jugadores.AddLast(crearJugador(jugador));
            }

            personajesVivos = CharacterEnumExtension.crearListaPersonajes();
        }

        public byte introduceNumeroJugadores()
        {
            byte res;
            bool status;

            //En verdad deberia mandarse el tema de la UI para fuera pero paso de sobreingenierizar mas >_>
            do
            {
                Console.Clear();
                Console.Write("Introduce número de jugadores (2-4): ");
                status = Byte.TryParse(Console.ReadLine(), out res);
            } while (!status || res < 2 || res > 4);

            return res;
        }

        public Jugador crearJugador(int numJugador)
        {
            string nombre;
            CharacterEnum personaje;

            Console.Clear();

            Console.Write("Introduce nombre del jugador " + numJugador+ " ");
            nombre = Console.ReadLine();

            personaje = CharacterEnumExtension.eligePersonaje();

            return new Jugador(nombre, personaje);

        }

        public bool comprobarGanador()
        {
            LinkedList<Jugador> jugadoresVivos = new LinkedList<Jugador>();
            LinkedList<CharacterEnum> personajesVivos = new LinkedList<CharacterEnum>();

            foreach(Jugador jugador in jugadores)
            {
                if (jugador.estaVivo)
                {
                    jugadoresVivos.AddLast(jugador);
                    if (!personajesVivos.Contains(jugador.personaje))
                    {
                        personajesVivos.AddLast(jugador.personaje);
                    }
                }
            }

            if (jugadoresVivos.Count == 1)
            {
                Console.Clear();
                Console.WriteLine("El ganador es " + jugadoresVivos.First.Value.nombre + " con el personaje " + CharacterEnumExtension.characterStrings[(int)(jugadoresVivos.First.Value.personaje - 'a')]);
                return true;
            }else
            {
                if(personajesVivos.Count == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Hay empate. Los ganadores son: ");
                    foreach(Jugador jugador in jugadoresVivos)
                    {
                        Console.WriteLine(jugador.nombre);
                    }
                    Console.WriteLine("Con el personaje: " + CharacterEnumExtension.characterStrings[(int)(jugadoresVivos.First.Value.personaje - 'a')]);
                    //He aprendido por accidente que si tengo un enum, c# me lo transforma auto en su cadena :OOO

                    return true;
                }
                
            }

            return false;
        }

        public void matarPersonaje()
        {
            Console.Clear();
            CharacterEnum die = CharacterEnumExtension.matarPersonaje(personajesVivos);
            foreach(Jugador jugador in jugadores)
            {
                if(jugador.personaje == die)
                {
                    jugador.estaVivo = false;
                }
            }
        }
    }
}
