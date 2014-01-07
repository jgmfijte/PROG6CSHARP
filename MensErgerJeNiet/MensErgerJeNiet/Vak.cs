using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MensErgerJeNiet
{
    public class Vak
    {
        public Vak VorigVak { get; set; }
        public Vak VolgendVak { get; set; }
        public Pion Pion { get; set; }
        public Pion TempPion { get; set; }
        public Image BackgroundImage { get; set; }
        public Color VakColor { get; set; }

        public Vak(Pion p)
        {
            Pion = p;
        }

        public void VerplaatsPion(Pion p, int steps)
        {
            if (TempPion == null)
            {
                if (VolgendVak.Pion == null && steps > 0)
                {
                    VolgendVak.KrijgPion(Pion);
                    steps -= 1;
                    Pion = null;
                    SetImage("Leeg");
                    VolgendVak.Verplaats(steps);
                }
                else if (VolgendVak.Pion != null && steps > 1)
                {
                    VolgendVak.TempPion = Pion;
                    Pion = null;
                    SetImage("Leeg");
                    steps -= 1;
                    VolgendVak.Verplaats(steps);
                }
                else if (VolgendVak.Pion != null && steps == 1)
                {
                    VolgendVak.StuurPionTerug(VolgendVak.Pion);
                    VolgendVak.KrijgPion(Pion);
                    Pion = null;
                    SetImage("Leeg");
                    steps -= 1;
                }
            }
            else if (TempPion != null)
            {
                if (VolgendVak.Pion == null && steps > 0)
                {
                    VolgendVak.KrijgPion(TempPion);
                    steps -= 1;
                    TempPion = null;
                    VolgendVak.Verplaats(steps);
                }
                else if (VolgendVak.Pion != null && steps > 1)
                {
                    VolgendVak.TempPion = TempPion;
                    TempPion = null;
                    steps -= 1;
                    VolgendVak.Verplaats(steps);
                }
                else if (VolgendVak.Pion != null && steps == 1)
                {
                    VolgendVak.StuurPionTerug(VolgendVak.Pion);
                    VolgendVak.KrijgPion(TempPion);
                    steps -= 1;
                }
            }
        }

        public void Verplaats(int steps)
        {
            if (TempPion != null)
            {
                VerplaatsPion(TempPion, steps);
            }
            else if (Pion != null)
            {
                VerplaatsPion(Pion, steps);
            }
        }

        public void StuurPionTerug(Pion p)
        {
            for (int i = 0; i < p.Eigenaar.WachtVakken.Count; i++)
            {
                if (p.Eigenaar.WachtVakken[i].Pion == null)
                {
                    p.Eigenaar.WachtVakken[1].KrijgPion(p);
                    break;
                }
            }
        }

        public void KrijgPion(Pion p)
        {
            if (p != null)
            {
                Pion = p;
                SetImage(Pion.Eigenaar.Kleur + "Pion");
            }
        }

        public void SetImage(string s)
        {
            switch (s)
            {
                //cases met verschillende plaatjes
                case "Leeg":
                    //normaal vak
                case "ZwartLeegSpelerVak":
                    //thuis en wachtvak zwarte speler
                    break;
                case "GeelLeegSpelerVak":
                    //thuis en wachtvak gele speler
                    break;
                case "RoodLeegSpelerVak":
                    //thuis en wachtvak rode speler
                    break;
                case "BlauwLeegSpelerVak":
                    //thuis en wachtvak blauwe speler
                    break;
                case "ZwartPion":
                    //pion zwarte speler
                    break;
                case "GeelPion":
                    //pion gele speler
                    break;
                case "RoodPion":
                    //pion rode speler
                    break;
                case "BlauwPion":
                    //pion blauwe speler
                    break;
                default:
                    break;
            }
        }
    }
}
