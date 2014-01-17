using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public ImageBrush BackgroundImage { get; set; }
        public string VakColor { get; set; }

        public Vak()
        {
            SetImage("Leeg");
        }

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
                    SetImage(Pion.Eigenaar.Kleur + "Thuis");
                    if (steps != 0)
                    {
                        VorigVak.VerplaatsPionTerug(steps);
                    }
                }
                else if (VorigVak.Pion != null && steps > 1)
                {
                    VorigVak.TempPion = Pion;
                    Pion = null;
                    SetImage(Pion.Eigenaar.Kleur + "Thuis");
                    steps -= 1;
                    VorigVak.VerplaatsPionTerug(steps);
                }
                else if (VorigVak.Pion != null && steps == 1)
                {
                    VorigVak.Pion.Eigenaar.StartVak.KrijgPion(VorigVak.Pion);
                    VorigVak.KrijgPion(Pion);
                    Pion = null;
                    SetImage(Pion.Eigenaar.Kleur + "Thuis");
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
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/Vak.png", UriKind.Relative)));
                    Console.WriteLine("test leeg");
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "ZwartLeegSpelerVak":
                    //thuis en wachtvak zwarte speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/ZwartThuisVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "GeelLeegSpelerVak":
                    //thuis en wachtvak gele speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/GeelThuisVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "RoodLeegSpelerVak":
                    //thuis en wachtvak rode speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/RoodThuisVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "BlauwLeegSpelerVak":
                    //thuis en wachtvak blauwe speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/BlauwThuisVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "ZwartPion":
                    //pion zwarte speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/ZwartPionVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "GeelPion":
                    //pion gele speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/GeelPionVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "RoodPion":
                    //pion rode speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/RoodPionVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "BlauwPion":
                    //pion blauwe speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/BlauwPionVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "ZwartStart":
                    //pion blauwe speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/ZwartStartVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "GeelStart":
                    //pion blauwe speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/GeelStartVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "RoodStart":
                    //pion blauwe speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/RoodStartVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                case "BlauwStart":
                    //pion blauwe speler
                    BackgroundImage = new ImageBrush(new BitmapImage(new Uri("/Media/BlauwStartVak.png", UriKind.Relative)));
                    BackgroundImage.Stretch = Stretch.Uniform;
                    break;
                default:
                    break;
            }
        }
    }
}
