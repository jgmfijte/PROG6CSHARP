using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class WachtVak : Vak
    {
        public Speler VakEigenaar { get; set; }
        public WachtVak(Pion p, string kleur)
        {
        }
    }
}
