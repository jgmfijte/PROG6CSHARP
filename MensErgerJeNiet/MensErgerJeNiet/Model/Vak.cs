using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MensErgerJeNiet
{
    public class Vak
    {
        public Vak VorigVak { get; set; }
        public Vak VolgendVak { get; set; }
        public Vak ZijVak { get; set; }
        public Pion Pion { get; set; }
        public Pion TempPion { get; set; }
        public Uri BackgroundImage { get; set; }
        public string VakColor { get; set; }

        public Vak()
        {
            SetImage("Leeg");
        }

        public Vak(Pion p)
        {
            Pion = p;
        }

        private void SetImageByObjectType()
        {
            if (this.GetType().ToString() == "Vak")
            {
                SetImage("Leeg");
            }
            else if (this.GetType().ToString() == "PoortVak")
            {
                SetImage("Leeg");
            }
            else if (this.GetType().ToString() == "StartVak")
            {
                SetImage(this.VakColor + "Start");
            }
            else if (this.GetType().ToString() == "ThuisVak")
            {
                SetImage(this.VakColor + "LeegSpelerVak");
            }
            else if (this.GetType().ToString() == "WachtVak")
            {
                SetImage("Leeg");
            }
            else
            {
                SetImage("Leeg");
            }
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
                    SetImageByObjectType();
                    VolgendVak.Verplaats(steps);
                }
                else if (VolgendVak.Pion != null && steps > 1)
                {
                    VolgendVak.TempPion = Pion;
                    Pion = null;
                    SetImageByObjectType();
                    steps -= 1;
                    VolgendVak.Verplaats(steps);
                }
                else if (VolgendVak.Pion != null && steps == 1)
                {
                    VolgendVak.StuurPionTerug(VolgendVak.Pion);
                    VolgendVak.KrijgPion(Pion);
                    Pion = null;
                    SetImageByObjectType();
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
            else if (VolgendVak == null)
            {
                VerplaatsPionTerug(steps);
            }
        }

        public void VerplaatsPionTerug(int steps)
        {
            if (TempPion == null)
            {
                if (VorigVak.Pion == null && steps > 0)
                {
                    VorigVak.KrijgPion(Pion);
                    steps -= 1;
                    Pion = null;
                    SetImageByObjectType();
                    if (steps != 0)
                    {
                        VorigVak.VerplaatsPionTerug(steps);
                    }
                }
                else if (VorigVak.Pion != null && steps > 1)
                {
                    VorigVak.TempPion = Pion;
                    Pion = null;
                    SetImageByObjectType();
                    steps -= 1;
                    VorigVak.VerplaatsPionTerug(steps);
                }
                else if (VorigVak.Pion != null && steps == 1)
                {
                    VorigVak.Pion.Eigenaar.StartVak.KrijgPion(VorigVak.Pion);
                    VorigVak.KrijgPion(Pion);
                    Pion = null;
                    SetImageByObjectType();
                    steps -= 1;
                }
            }
            else if (TempPion != null)
            {
                if (VorigVak.Pion == null && steps > 0)
                {
                    VorigVak.KrijgPion(TempPion);
                    steps -= 1;
                    TempPion = null;
                    if (steps != 0)
                    {
                        VolgendVak.Verplaats(steps);
                    }
                }
                else if (VorigVak.Pion != null && steps > 1)
                {
                    VorigVak.TempPion = TempPion;
                    TempPion = null;
                    steps -= 1;
                    VorigVak.Verplaats(steps);
                }
                else if (VorigVak.Pion != null && steps == 1)
                {
                    VorigVak.Pion.Eigenaar.StartVak.KrijgPion(VorigVak.Pion);
                    VorigVak.KrijgPion(TempPion);
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
                    BackgroundImage = new Uri("./Media/Vak.png", UriKind.Relative);
                    break;
                case "ZwartLeegSpelerVak":
                    //thuis en wachtvak zwarte speler
                    BackgroundImage = new Uri("./Media/ZwartThuisVak.png", UriKind.Relative);
                    break;
                case "GeelLeegSpelerVak":
                    //thuis en wachtvak gele speler
                    BackgroundImage = new Uri("./Media/GeelThuisVak.png", UriKind.Relative);
                    break;
                case "RoodLeegSpelerVak":
                    //thuis en wachtvak rode speler
                    BackgroundImage = new Uri("./Media/RoodThuisVak.png", UriKind.Relative);
                    break;
                case "BlauwLeegSpelerVak":
                    //thuis en wachtvak blauwe speler
                    BackgroundImage = new Uri("./Media/BlauwThuisVak.png", UriKind.Relative);
                    break;
                case "ZwartPion":
                    //pion zwarte speler
                    BackgroundImage = new Uri("./Media/ZwartPionVak.png", UriKind.Relative);
                    break;
                case "GeelPion":
                    //pion gele speler
                    BackgroundImage = new Uri("./Media/GeelPionVak.png", UriKind.Relative);
                    break;
                case "RoodPion":
                    //pion rode speler
                    BackgroundImage = new Uri("./Media/RoodPionVak.png", UriKind.Relative);
                    break;
                case "BlauwPion":
                    //pion blauwe speler
                    BackgroundImage = new Uri("./Media/BlauwPionVak.png", UriKind.Relative);
                    break;
                case "ZwartStart":
                    //pion blauwe speler
                    BackgroundImage = new Uri("./Media/ZwartStartVak.png", UriKind.Relative);
                    break;
                case "GeelStart":
                    //pion blauwe speler
                    BackgroundImage = new Uri("./Media/GeelStartVak.png", UriKind.Relative);
                    break;
                case "RoodStart":
                    //pion blauwe speler
                    BackgroundImage = new Uri("./Media/RoodStartVak.png", UriKind.Relative);
                    break;
                case "BlauwStart":
                    //pion blauwe speler
                    BackgroundImage = new Uri("./Media/BlauwStartVak.png", UriKind.Relative);
                    break;
                default:
                    break;
            }
        }
    }
}
