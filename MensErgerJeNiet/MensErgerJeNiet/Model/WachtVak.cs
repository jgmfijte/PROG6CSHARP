using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MensErgerJeNiet
{
    public class WachtVak : Vak
    {
        public Speler VakEigenaar { get; set; }

        public WachtVak(Pion p, string kleur)
        {
            Pion = p;
            base.SetImage(kleur + "Pion");
        }

        public void BrengPionInSpel()
        {
            if (Pion != null)
            {
                if (Pion.Eigenaar.StartVak.Pion != null)
                {
                    StuurPionTerug(Pion.Eigenaar.StartVak.Pion);
                }
                Pion.Eigenaar.StartVak.KrijgPion(Pion);
                Pion = null;
                base.SetImage("Leeg");
            }
        }
    }
}
