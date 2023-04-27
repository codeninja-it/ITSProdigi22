using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica
{
    internal class Contatto
    {
        public static int quanti { get; set; }
        public int idContatto { get; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string telefono { get; set; }
        public DateTime creazione { get; } = DateTime.Now;

        public Contatto(string nome, string cognome, string telefono)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.telefono = telefono;
            quanti++;
            this.idContatto = quanti;
        }

        public override string ToString()
        {
            return $"{nome}\t{cognome}\t{telefono}\t{creazione}";
        }
    }
}
