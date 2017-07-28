using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapos
{
    public enum CharacterEnum : int
    {
        DRMARIO = 'a',
        MARIO = 'b',
        LUIGI = 'c',
        BOWSER = 'd',
        PEACH = 'e',
        YOSHI = 'f',
        DK = 'g',
        CFALCON = 'h',
        GANON = 'i',
        FALCO = 'j',
        FOX = 'k',
        NESS = 'l',
        IC = 'm',
        KIRBY = 'n',
        SAMUS = 'o',
        ZELDA = 'p',
        LINK = 'q',
        YLINK = 'r',
        PICHU = 's',
        PIKACHU = 't',
        JIGLY = 'u',
        MEWTWO = 'v',
        GAW = 'w',
        MARTH = 'x',
        ROY = 'y',
        RANDOM = 'z'
    }

    public static class CharacterEnumExtension
    {
        public static String[] characterStrings =
        {
            (char)CharacterEnum.DRMARIO +") "+ "Dr. Mario",
            (char)CharacterEnum.MARIO +") "+"Mario",
            (char)CharacterEnum.LUIGI +") "+"Luigi",
            (char)CharacterEnum.BOWSER +") "+"Bowser",
            (char)CharacterEnum.PEACH +") "+"Peach",
            (char)CharacterEnum.YOSHI +") "+"Yoshi",
            (char)CharacterEnum.DK +") "+"Donkey Kong",
            (char)CharacterEnum.CFALCON +") "+"Cpt. Falcon",
            (char)CharacterEnum.GANON +") "+"Ganondorf",
            (char)CharacterEnum.FALCO +") "+"Falco",
            (char)CharacterEnum.FOX +") "+"Fox",
            (char)CharacterEnum.NESS +") "+"Ness",
            (char)CharacterEnum.IC +") "+"Ice Climbers",
            (char)CharacterEnum.KIRBY +") "+"Kirby",
            (char)CharacterEnum.SAMUS +") "+"Samus",
            (char)CharacterEnum.ZELDA +") "+"Zelda",
            (char)CharacterEnum.LINK +") "+"Link",
            (char)CharacterEnum.GANON +") "+"Young Link",
            (char)CharacterEnum.PICHU +") "+"Pichu",
            (char)CharacterEnum.PIKACHU +") "+"Pikachu",
            (char)CharacterEnum.JIGLY +") "+"Jigglypuff",
            (char)CharacterEnum.MEWTWO +") "+"Mewtwo",
            (char)CharacterEnum.GAW +") "+"Game and Watch",
            (char)CharacterEnum.MARTH +") "+"Marth",
            (char)CharacterEnum.ROY +") "+"Roy",
            (char)CharacterEnum.RANDOM + ") "+"Random"
        };

        public static void imprimirPersonajes()
        {
            foreach (string linea in characterStrings)
            {
                Console.WriteLine(linea);
            }
        }

        public static void imprimirPersonajesVivos(LinkedList<CharacterEnum> vivos)
        {
            foreach (CharacterEnum character in vivos)
            {
                Console.WriteLine(characterStrings[(int)(character - 'a')]);
            }
        }

        public static LinkedList<CharacterEnum> crearListaPersonajes()
        {
            LinkedList<CharacterEnum> lista = new LinkedList<CharacterEnum>();

            for(int personaje = (int)CharacterEnum.DRMARIO; personaje <= (int)CharacterEnum.RANDOM; personaje++)
            {
                lista.AddLast((CharacterEnum)personaje);
            }

            return lista;
        }

        public static char pedirLetraPersonaje()
        {
            char res;
            bool status;

            Console.Write("Introduce letra del personaje: ");
            status = Char.TryParse(Console.ReadLine(), out res);
            while(!status){
                Console.Write("Has introducido una letra no valida. Intentalo de nuevo: ");
                status = Char.TryParse(Console.ReadLine(), out res);
            }

            return res;
        }

        public static CharacterEnum pedirPersonaje()
        {
            char res;
            bool status;

            Console.Write("Introduce letra del personaje: ");
            status = Char.TryParse(Console.ReadLine(), out res);

            while (!status || res < 'a' || res >'z')
            {
                Console.Write("Has introducido una letra no valida. Intentalo de nuevo: ");
                status = Char.TryParse(Console.ReadLine(), out res);
            }

            return (CharacterEnum)res;
        }

        public static CharacterEnum pedirPersonajeVivo(LinkedList<CharacterEnum> personajes)
        {
            char res;
            bool status;

            Console.Write("Introduce letra del personaje: ");
            status = Char.TryParse(Console.ReadLine(), out res);

            while (!status || res<'a' || res>'z' || !personajes.Contains((CharacterEnum)res))
            {
                Console.Write("El personaje no esta vivo. Intentalo de nuevo: ");
                status = Char.TryParse(Console.ReadLine(), out res);
            }

            return (CharacterEnum)res;
        }


        public static CharacterEnum eligePersonaje()
        {
            imprimirPersonajes();
            return pedirPersonaje();
        }

        public static CharacterEnum matarPersonaje(LinkedList<CharacterEnum> personajes)
        {
            imprimirPersonajesVivos(personajes);
            CharacterEnum die = pedirPersonajeVivo(personajes);
            personajes.Remove(die);
            return die;
        }
    }
}
