using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaApp
{
    internal class Utility
    {
        /// <summary>
        /// funzione per porre una domanda all'utente tramite la console
        /// </summary>
        /// <param name="domanda">la domanda da porre all'utente</param>
        /// <returns>quello che l'utete ha scritto in console</returns>
        public static string chiedi(string domanda)
        {
            // scrivo la domanda in console
            Console.Write(domanda + ": ");
            // recupero dal buffer la risposta
            string risposta = Console.ReadLine();
            // la restituisco a chimi ha chiamato
            return risposta;
        }

        public static int chiediNumero(string domanda)
        {
            Console.Write(domanda + ": ");
            string risposta = Console.ReadLine();
            return int.Parse(risposta);
        }



    }
}
