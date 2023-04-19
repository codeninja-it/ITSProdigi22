using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica
{
    internal class Contatto
    {
        public string nome { get; set; }
        public string cognome { get; set; }
        public string telefono { get; set; }
        public DateTime creazione { get; } = DateTime.Now;
    }
}
