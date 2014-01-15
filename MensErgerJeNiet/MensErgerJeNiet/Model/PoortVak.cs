using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class PoortVak : Vak
    {
        private LinkedList<ThuisVak> _ThuisVakken = new LinkedList<ThuisVak>();

        public PoortVak(/*LinkedList<ThuisVak> thuisVakken*/)
        {
            SetImage("Leeg");
            //this._ThuisVakken = thuisVakken;
            //ZijVak = _ThuisVakken.First();
        }

        public void Verplaats(int steps)
        {
            if (TempPion == null)
            {
                if (((ThuisVak)ZijVak).Kleur.Equals(Pion.Eigenaar.Kleur))
                {
                    VerplaatsPionOpzij(Pion, steps);
                }
                else
                {
                    VerplaatsPion(Pion, steps);
                }
            }
            else if (TempPion != null)
            {

                if (((ThuisVak)ZijVak).Kleur.Equals(TempPion.Eigenaar.Kleur))
                {
                    VerplaatsPionOpzij(TempPion, steps);
                }
                VerplaatsPion(Pion, steps);
            }
        }

        public void VerplaatsPionOpzij(Pion p, int steps)
        {
            if (TempPion == null)
            {
                if (ZijVak.Pion == null && steps > 0)
                {
                    ZijVak.KrijgPion(Pion);
                    steps -= 1;
                    Pion = null;
                    SetImage("leeg");
                    ZijVak.Verplaats(steps);
                }
                else if (ZijVak.Pion != null && steps > 1)
                {
                    ZijVak.TempPion = Pion;
                    Pion = null;
                    SetImage("leeg");
                    steps -= 1;
                    ZijVak.Verplaats(steps);
                }
                else if (ZijVak.Pion != null && steps == 1)
                {
                    steps -= 1;
                }
            }
            else if (TempPion != null)
            {
                if (ZijVak.Pion == null && steps > 0)
                {
                    ZijVak.KrijgPion(TempPion);
                    steps -= 1;
                    TempPion = null;
                    ZijVak.Verplaats(steps);
                }
                else if (ZijVak.Pion != null && steps > 1)
                {
                    ZijVak.TempPion = TempPion;
                    Pion = null;
                    steps -= 1;
                    ZijVak.Verplaats(steps);
                }
                else if (ZijVak.Pion != null && steps == 1)
                {
                    steps -= 1;
                }
            }
        }
    }
}
