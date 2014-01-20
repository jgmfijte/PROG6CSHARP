using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet.Model
{
    class BordMaker
    {
        public BordMaker()
        {
        }

        public List<Vak> maakBord(int spelers)
        {
            Vak[] l = new Vak[72];

            // Bordvakjes initialiseren, thuisvakken worden nog niet gedaan
            if (spelers >= 2)
            {
                // Speler 1 tot speler 2, inclusief poortvak speler 2
                l[0] = new StartVak("Rood");
                for (int c = 1; c < 9; c++)
                {
                    l[c] = new Vak();
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
                l[9] = new PoortVak();
                l[8].VolgendVak = l[9];
                l[9].VorigVak = l[8];

                // Speler 1 tot speler 2, inclusief poortvak speler 2
                l[10] = new StartVak("Blauw");
                l[9].VolgendVak = l[10];
                l[10].VorigVak = l[9];
                for (int c = 11; c < 19; c++)
                {
                    l[c] = new Vak();
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
                l[19] = new PoortVak();
                l[18].VolgendVak = l[19];
                l[19].VorigVak = l[18];
            }

            if (spelers >= 3)
            {
                l[20] = new StartVak("Zwart");
                l[19].VolgendVak = l[20];
                l[20].VorigVak = l[19];
                for (int c = 21; c < 29; c++)
                {
                    l[c] = new Vak();
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
                l[29] = new PoortVak();
                l[28].VolgendVak = l[29];
                l[29].VorigVak = l[28];
            }
            else
            {
                for (int c = 20; c < 30; c++)
                {
                    l[c] = new Vak();
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
            }

            if (spelers == 4)
            {
                l[30] = new StartVak("Geel");
                l[29].VolgendVak = l[30];
                l[30].VorigVak = l[29];
                for (int c = 31; c < 39; c++)
                {
                    l[c] = new Vak();
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
                l[39] = new PoortVak();
                l[38].VolgendVak = l[39];
                l[39].VorigVak = l[38];

                l[39].VolgendVak = l[0];
                l[0].VorigVak = l[39];
            }
            else
            {
                for (int c = 30; c < 40; c++)
                {
                    l[c] = new Vak();
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
                l[39].VolgendVak = l[0];
                l[0].VorigVak = l[39];
            }
            
            // Thuisvakken initialiseren

            if (spelers >= 2)
            {
                // Thuisvakken speler 1
                l[52] = new ThuisVak("Rood");
                l[39].ZijVak = l[52];
                l[52].VorigVak = l[39];
                for (int c = 53; c < 56; c++)
                {
                    l[c] = new ThuisVak("Rood");
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
                
                //Thuisvakken speler 2
                l[40] = new ThuisVak("Blauw");
                l[9].ZijVak = l[40];
                l[40].VorigVak = l[9];
                for (int c = 41; c < 44; c++)
                {
                    l[c] = new ThuisVak("Blauw");
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
            }

            if (spelers >= 3)
            {
                l[44] = new ThuisVak("Zwart");
                l[19].ZijVak = l[44];
                l[44].VorigVak = l[19];
                for (int c = 44; c < 48; c++)
                {
                    l[c] = new ThuisVak("Zwart");
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
            }

            if (spelers == 4)
            {
                l[48] = new ThuisVak("Geel");
                l[29].ZijVak = l[48];
                l[48].VorigVak = l[29];
                for (int c = 48; c < 52; c++)
                {
                    l[c] = new ThuisVak("Geel");
                    l[c - 1].VolgendVak = l[c];
                    l[c].VorigVak = l[c - 1];
                }
            }

            return l.ToList();
        }

        public void MaakWachtVakken(List<Speler> Spelers, List<Vak> Vakken)
        {
            int aantalSpelers = 0;

            foreach (Speler s in Spelers)
            {
                if (s != null)
                {
                    aantalSpelers++;
                }
            }

            if (aantalSpelers >= 2)
            {
                for (int c = 56; c < 60; c++)
                {
                    Vakken[c] = new WachtVak(new Pion(Spelers[0]), "Rood");
                }

                for (int c = 60; c < 64; c++)
                {
                    Vakken[c] = new WachtVak(new Pion(Spelers[1]), "Blauw");
                }
            }

            if (aantalSpelers >= 3)
            {
                for (int c = 64; c < 68; c++)
                {
                    Vakken[c] = new WachtVak(new Pion(Spelers[2]), "Zwart");
                }
            }

            if (aantalSpelers == 4)
            {
                for (int c = 68; c < 72; c++)
                {
                    Vakken[c] = new WachtVak(new Pion(Spelers[3]), "Geel");
                }
            }
        }

    }
}
