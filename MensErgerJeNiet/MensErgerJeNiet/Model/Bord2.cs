using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.Model
{
    public class Bord2
    {
        public Collection<Vak> SpelVakken { get; set; }
        public Collection<Speler> Spelers { get; set; }

        public Bord2(int realSpelers, int computerSpelers)
        {
            SpelVakken = new Collection<Vak>();
            Spelers = new Collection<Speler>();
            MaakBord();
            MaakSpelers(realSpelers, computerSpelers);
            GeefSpelersThuisvakken(realSpelers + computerSpelers);
        }

        private void MaakBord()
        {
            BordMaker s = new BordMaker();
            SpelVakken = s.maakBord();
        }

        private void MaakSpelers(int realSpelers, int computerSpelers)
        {
            if (realSpelers >= 1 && realSpelers <= 4)
            {
                Spelers.Add(new Speler("rood", (StartVak)SpelVakken[0], false));

                if (realSpelers >= 2)
                {
                    Spelers.Add(new Speler("blauw", (StartVak)SpelVakken[10], false));
                }

                if (realSpelers >= 3)
                {
                    Spelers.Add(new Speler("groen", (StartVak)SpelVakken[20], false));
                }

                if (realSpelers == 4)
                {
                    Spelers.Add(new Speler("geel", (StartVak)SpelVakken[30], false));
                }
            }

            if (realSpelers != 4 && computerSpelers > 0 && computerSpelers < 4)
            {
                if (computerSpelers <= 4)
                {
                    Spelers.Add(new Speler("geel", (StartVak)SpelVakken[30], true));
                }

                if (realSpelers <= 3)
                {
                    Spelers.Add(new Speler("groen", (StartVak)SpelVakken[20], true));
                }

                if (realSpelers == 2)
                {
                    Spelers.Add(new Speler("blauw", (StartVak)SpelVakken[10], true));
                }
            }

            //if ((realSpelers > 1) && (spelers <= 4))
            //{
            //    switch (spelers)
            //    {
            //        case 2:
            //            Spelers.Add(new Speler("rood", (StartVak)SpelVakken[0]));
            //            Spelers.Add(new Speler("blauw", (StartVak)SpelVakken[10]));
            //            break;
            //        case 3:
            //            Spelers.Add(new Speler("rood", (StartVak)SpelVakken[0]));
            //            Spelers.Add(new Speler("blauw", (StartVak)SpelVakken[10]));
            //            Spelers.Add(new Speler("groen", (StartVak)SpelVakken[30]));
            //            break;
            //        case 4:
            //            Spelers.Add(new Speler("rood", (StartVak)SpelVakken[0]));
            //            Spelers.Add(new Speler("blauw", (StartVak)SpelVakken[10]));
            //            Spelers.Add(new Speler("groen", (StartVak)SpelVakken[20]));
            //            Spelers.Add(new Speler("geel", (StartVak)SpelVakken[30]));
            //            break;
            //
            //    }
            //}
        }

        private void GeefSpelersThuisvakken(int spelers)
        {
            switch (spelers)
            {
                case 2:
                    Spelers[0].ThuisVakken[0] = SpelVakken[52];
                    Spelers[0].ThuisVakken[1] = SpelVakken[53];
                    Spelers[0].ThuisVakken[2] = SpelVakken[54];
                    Spelers[0].ThuisVakken[3] = SpelVakken[55];
                    Spelers[1].ThuisVakken[0] = SpelVakken[40];
                    Spelers[1].ThuisVakken[1] = SpelVakken[41];
                    Spelers[1].ThuisVakken[2] = SpelVakken[42];
                    Spelers[1].ThuisVakken[3] = SpelVakken[43];
                    break;
                case 3:
                    Spelers[0].ThuisVakken[0] = SpelVakken[52];
                    Spelers[0].ThuisVakken[1] = SpelVakken[53];
                    Spelers[0].ThuisVakken[2] = SpelVakken[54];
                    Spelers[0].ThuisVakken[3] = SpelVakken[55];
                    Spelers[1].ThuisVakken[0] = SpelVakken[40];
                    Spelers[1].ThuisVakken[1] = SpelVakken[41];
                    Spelers[1].ThuisVakken[2] = SpelVakken[42];
                    Spelers[1].ThuisVakken[3] = SpelVakken[43];
                    Spelers[2].ThuisVakken[0] = SpelVakken[44];
                    Spelers[2].ThuisVakken[1] = SpelVakken[45];
                    Spelers[2].ThuisVakken[2] = SpelVakken[46];
                    Spelers[2].ThuisVakken[3] = SpelVakken[47];
                    break;
                case 4:
                    Spelers[0].ThuisVakken[0] = SpelVakken[52];//rood
                    Spelers[0].ThuisVakken[1] = SpelVakken[53];
                    Spelers[0].ThuisVakken[2] = SpelVakken[54];
                    Spelers[0].ThuisVakken[3] = SpelVakken[55];
                    Spelers[1].ThuisVakken[0] = SpelVakken[40];//blauw
                    Spelers[1].ThuisVakken[1] = SpelVakken[41];
                    Spelers[1].ThuisVakken[2] = SpelVakken[42];
                    Spelers[1].ThuisVakken[3] = SpelVakken[43];
                    Spelers[2].ThuisVakken[0] = SpelVakken[44];//groen
                    Spelers[2].ThuisVakken[1] = SpelVakken[45];
                    Spelers[2].ThuisVakken[2] = SpelVakken[46];
                    Spelers[2].ThuisVakken[3] = SpelVakken[47];
                    Spelers[3].ThuisVakken[0] = SpelVakken[48];//geel
                    Spelers[3].ThuisVakken[1] = SpelVakken[49];
                    Spelers[3].ThuisVakken[2] = SpelVakken[50];
                    Spelers[3].ThuisVakken[3] = SpelVakken[51];
                    break;
            }
        }

    }
}
