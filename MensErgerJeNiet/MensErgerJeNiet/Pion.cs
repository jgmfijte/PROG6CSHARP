using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    class Pion
    {
        public Speler Eigenaar { get; set; }

        public Pion(Speler speler)
        {
            Eigenaar = speler;
        }
    }
}
