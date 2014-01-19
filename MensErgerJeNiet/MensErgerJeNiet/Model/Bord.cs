using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.Model
{
    public class Bord
    {
        public List<Vak> SpelVakken { get; set; }
        public List<Speler> Spelers { get; set; }

        private BordMaker bordMaker = new BordMaker();

        public Bord(int realSpelers, int computerSpelers)
        {
            SpelVakken = new List<Vak>();
            Spelers = new List<Speler>();

            SpelVakken = bordMaker.maakBord(realSpelers + computerSpelers);
            MaakSpelers(realSpelers, computerSpelers);
            GeefSpelersThuisvakken(realSpelers + computerSpelers);
            bordMaker.MaakWachtVakken(Spelers, SpelVakken);
        }

        private void MaakSpelers(int realSpelers, int computerSpelers)
        {
            Speler[] spelerArray = new Speler[4];
            List<string> colorList = new List<String>();

            colorList.Add("Rood");
            colorList.Add("Blauw");
            colorList.Add("Zwart");
            colorList.Add("Geel");

            if (realSpelers >= 1 && realSpelers <= 4)
            {
                spelerArray[0] = new Speler(colorList[0], (StartVak)SpelVakken[0], false);

                if (realSpelers >= 2)
                {
                    spelerArray[1] = new Speler(colorList[1], (StartVak)SpelVakken[10], false);
                }

                if (realSpelers >= 3)
                {
                    spelerArray[2] = new Speler(colorList[2], (StartVak)SpelVakken[20], false);
                }

                if (realSpelers == 4)
                {
                    spelerArray[3] = new Speler(colorList[3], (StartVak)SpelVakken[30], false);
                }
            }

            if (realSpelers != 4 && computerSpelers > 0 && computerSpelers < 4)
            {
                int count = 0;

                if (computerSpelers >= 3)
                {
                    spelerArray[realSpelers + count] = new Speler(colorList[realSpelers + count], (StartVak)SpelVakken[((realSpelers * 10) + (count * 10))], true);
                    count++;
                }

                if (computerSpelers >= 2)
                {
                    spelerArray[realSpelers + count] = new Speler(colorList[realSpelers + count], (StartVak)SpelVakken[((realSpelers * 10) + (count * 10))], true);
                    count++;
                }

                if (computerSpelers >= 1)
                {
                    spelerArray[realSpelers + count] = new Speler(colorList[realSpelers + count], (StartVak)SpelVakken[((realSpelers * 10) + (count * 10))], true);
                    count++;
                }
            }

            Spelers = spelerArray.ToList();
        }

        private void GeefSpelersThuisvakken(int spelers)
        {
            Spelers[0].ThuisVakken[0] = SpelVakken[52];
            Spelers[0].ThuisVakken[1] = SpelVakken[53];
            Spelers[0].ThuisVakken[2] = SpelVakken[54];
            Spelers[0].ThuisVakken[3] = SpelVakken[55];
            Spelers[1].ThuisVakken[0] = SpelVakken[40];
            Spelers[1].ThuisVakken[1] = SpelVakken[41];
            Spelers[1].ThuisVakken[2] = SpelVakken[42];
            Spelers[1].ThuisVakken[3] = SpelVakken[43];

            if (spelers >= 3)
            {
                Spelers[2].ThuisVakken[0] = SpelVakken[44];
                Spelers[2].ThuisVakken[1] = SpelVakken[45];
                Spelers[2].ThuisVakken[2] = SpelVakken[46];
                Spelers[2].ThuisVakken[3] = SpelVakken[47];
            }

            if (spelers == 4){
                Spelers[3].ThuisVakken[0] = SpelVakken[48];
                Spelers[3].ThuisVakken[1] = SpelVakken[49];
                Spelers[3].ThuisVakken[2] = SpelVakken[50];
                Spelers[3].ThuisVakken[3] = SpelVakken[51];
            }
        }
    }
}
