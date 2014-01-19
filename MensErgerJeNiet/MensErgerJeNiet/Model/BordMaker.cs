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

        public Collection<Vak> maakBord(int Spelers)
        {
            Collection<Vak> l = new Collection<Vak>();

            l.Add(new StartVak("Rood"));                    //0 Rood start
            for (int i = 1; i < 9; i++)                 //1-8 leeg vakje
            {
                l.Add(new Vak());
                l.ElementAt(i - 1).VolgendVak = l.ElementAt(i);
                l.ElementAt(i).VorigVak = l.ElementAt(i - 1);
            }
            l.Add(new PoortVak());                    //9 Blauw poortvakje
            l.ElementAt(8).VolgendVak = l.ElementAt(9);
            l.ElementAt(9).VorigVak = l.ElementAt(8);
            l.Add(new StartVak("Blauw"));                    //10 Blauw start
            l.ElementAt(9).VolgendVak = l.ElementAt(10);
            l.ElementAt(10).VorigVak = l.ElementAt(9);
            for (int i = 11; i < 19; i++)               //11-18 leeg vakje
            {
                l.Add(new Vak());
                l.ElementAt(i - 1).VolgendVak = l.ElementAt(i);
                l.ElementAt(i).VorigVak = l.ElementAt(i - 1);
            }
            l.Add(new PoortVak());                    //19 Zwart poortvakje
            l.ElementAt(18).VolgendVak = l.ElementAt(19);
            l.ElementAt(19).VorigVak = l.ElementAt(18);
            l.Add(new StartVak("Zwart"));            //20 Zwart startvakje
            l.ElementAt(19).VolgendVak = l.ElementAt(20);
            l.ElementAt(20).VorigVak = l.ElementAt(19);
            for (int i = 21; i < 29; i++)               //21-28 leeg vakje
            {
                l.Add(new Vak());
                l.ElementAt(i - 1).VolgendVak = l.ElementAt(i);
                l.ElementAt(i).VorigVak = l.ElementAt(i - 1);
            }
            l.Add(new PoortVak());                    //29 Geel poortvakje
            l.ElementAt(28).VolgendVak = l.ElementAt(29);
            l.ElementAt(29).VorigVak = l.ElementAt(28);
            l.Add(new StartVak("Geel"));                    //30 Geel startvakje
            l.ElementAt(29).VolgendVak = l.ElementAt(30);
            l.ElementAt(30).VorigVak = l.ElementAt(29);
            for (int i = 31; i < 39; i++)               //31-38 lege vakjes
            {
                l.Add(new Vak());
                l.ElementAt(i - 1).VolgendVak = l.ElementAt(i);
                l.ElementAt(i).VorigVak = l.ElementAt(i - 1);
            }
            l.Add(new PoortVak());                    //39 Rood poortvakje
            l.ElementAt(38).VolgendVak = l.ElementAt(39);
            l.ElementAt(39).VolgendVak = l.ElementAt(0);
            l.Add(new ThuisVak("Blauw"));       //40-43 Blauwe thuisvakken
            l.ElementAt(9).ZijVak = l.ElementAt(40);
            l.ElementAt(40).VorigVak = l.ElementAt(9);
            l.Add(new ThuisVak("Blauw"));
            l.ElementAt(40).VolgendVak = l.ElementAt(41);
            l.ElementAt(41).VorigVak = l.ElementAt(40);
            l.Add(new ThuisVak("Blauw"));
            l.ElementAt(41).VolgendVak = l.ElementAt(42);
            l.ElementAt(42).VorigVak = l.ElementAt(41);
            l.Add(new ThuisVak("Blauw"));
            l.ElementAt(42).VolgendVak = l.ElementAt(43);
            l.ElementAt(43).VorigVak = l.ElementAt(42);
            /////////
            l.Add(new ThuisVak("Zwart"));
            l.ElementAt(19).ZijVak = l.ElementAt(44);     //44-47 Zwarte thuisvakken
            l.ElementAt(44).VorigVak = l.ElementAt(19);
            l.Add(new ThuisVak("Zwart"));
            l.ElementAt(44).VolgendVak = l.ElementAt(45);
            l.ElementAt(45).VorigVak = l.ElementAt(44);
            l.Add(new ThuisVak("Zwart"));
            l.ElementAt(45).VolgendVak = l.ElementAt(46);
            l.ElementAt(46).VorigVak = l.ElementAt(45);
            l.Add(new ThuisVak("Zwart"));
            l.ElementAt(46).VolgendVak = l.ElementAt(47);
            l.ElementAt(47).VorigVak = l.ElementAt(46);
            ////////
            l.Add(new ThuisVak("Geel"));
            l.ElementAt(29).ZijVak = l.ElementAt(48);     //48-51 gele thuisvakken
            l.ElementAt(48).VorigVak = l.ElementAt(29);
            l.Add(new ThuisVak("Geel"));
            l.ElementAt(48).VolgendVak = l.ElementAt(49);
            l.ElementAt(49).VorigVak = l.ElementAt(48);
            l.Add(new ThuisVak("Geel"));
            l.ElementAt(49).VolgendVak = l.ElementAt(50);
            l.ElementAt(50).VorigVak = l.ElementAt(49);
            l.Add(new ThuisVak("Geel"));
            l.ElementAt(50).VolgendVak = l.ElementAt(51);
            l.ElementAt(51).VorigVak = l.ElementAt(50);
            ////////
            l.Add(new ThuisVak("Rood"));
            l.ElementAt(39).ZijVak = l.ElementAt(52);     //52-55 rode thuisvakken
            l.ElementAt(52).VorigVak = l.ElementAt(19);
            l.Add(new ThuisVak("Rood"));
            l.ElementAt(52).VolgendVak = l.ElementAt(53);
            l.ElementAt(53).VorigVak = l.ElementAt(52);
            l.Add(new ThuisVak("Rood"));
            l.ElementAt(53).VolgendVak = l.ElementAt(54);
            l.ElementAt(54).VorigVak = l.ElementAt(53);
            l.Add(new ThuisVak("Rood"));
            l.ElementAt(54).VolgendVak = l.ElementAt(55);
            l.ElementAt(55).VorigVak = l.ElementAt(54);
            ////////
            
            if(Spelers >= 2){
                for(int c = 56; c < 60; c++){
                    // wachtvak toevoegen voor eerste speler
                }

                for (int c = 60; c < 64; c++)
                {
                    // wachtvak toevoegen voor tweede speler
                }
            }

            if (Spelers >= 3)
            {
                for (int c = 64; c < 68; c++)
                {
                    // wachtvak toevoegen voor derde speler
                }
            }

            if (Spelers >= 4)
            {
                for (int c = 68; c < 72; c++)
                {
                    // wachtvak toevoegen voor vierde speler
                }
            }
            
            return l;
        }

    }
}
