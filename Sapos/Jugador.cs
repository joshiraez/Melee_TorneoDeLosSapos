using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapos
{
    public class Jugador
    {
        public string nombre { get; set; }
        public CharacterEnum personaje { get; set; }
        public bool estaVivo { get; set; }

        public Jugador(string nombre, CharacterEnum personaje)
        {
            this.nombre = nombre;
            this.personaje = personaje;
            this.estaVivo = true;
        }


    }
}
