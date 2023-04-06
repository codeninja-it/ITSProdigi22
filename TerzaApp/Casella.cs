using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerzaApp
{
    internal class Casella
    {
        public int x;
        public int y;
        public bool muro;

        public Casella(int x, int y, bool muro)
        {
            this.x = x;
            this.y = y;
            this.muro = muro;
        }
    }
}
