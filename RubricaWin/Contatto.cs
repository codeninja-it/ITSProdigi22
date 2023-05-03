using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaWin
{
    internal class Contatto
    {
        public string nome { get; set; }
        public string cognome { get; set; }
        public string telefono { get; set; }
        public Contatto(string nome, string cognome, string telefono) {
            this.nome = nome;
            this.cognome = cognome;
            this.telefono = telefono;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
