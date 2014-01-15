using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class StartVak : Vak
    {
        public Speler VakEigenaar { get; set; }
        private string kleur;

        public StartVak(string kleur)
        {
            SetImage(kleur + "Start");
            this.kleur = kleur;
        }
    }
}
