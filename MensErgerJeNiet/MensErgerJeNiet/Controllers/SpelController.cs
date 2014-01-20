using MensErgerJeNiet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MensErgerJeNiet
{
    public class SpelController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Bord bord { get; set; }
        private SpelWindow gameWindow;
        private int RealSpelers { get; set; }
        private int ComputerSpelers { get; set; }
        private string HuidigOnderdeel { get; set; }
        private string Beurt { get; set; }
        private int AantalSpelers { get; set; }
        private int DobbelWaarde { get; set; }
        private int[] DobbelWedstrijd;
        private int WedstrijdRonde;

        public SpelController(int realSpelers, int computerSpelers, SpelWindow gameWindow)
        {
            this.gameWindow = gameWindow;
            RealSpelers = realSpelers;
            ComputerSpelers = computerSpelers;
            AantalSpelers = RealSpelers + ComputerSpelers;
            bord = new Bord(RealSpelers, ComputerSpelers);

            WedstrijdRonde = 0;
            DobbelWedstrijd = new int[4];

            gameWindow.SpelerAanDeBeurt.Content = Beurt;
            gameWindow.ForegroundText.Content = "Hier komt wat aanvullende info!";

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void SpeelSpel(int s)
        {
            switch (HuidigOnderdeel)
            {
                case "Spel_Start":
                    DobbelOnderdeel();
                    break;
                case "Lopen":
                    if (PionLopen(s, DobbelWaarde))
                    {
                        CheckGewonnen();
                        VolgendeBeurt();
                        HuidigOnderdeel = "Dobbel";
                    }
                    break;
                case "Dobbel":
                    if (DobbelWaarde < 6)
                    {
                        if (CheckPionInSpel())
                        {
                            HuidigOnderdeel = "Lopen";
                            //set text
                        }
                        else
                        {
                            HuidigOnderdeel = "Dobbel";
                            //set text
                            VolgendeBeurt();
                        }
                    }
                    else
                    {
                        HuidigOnderdeel = "Zes";
                        //set text
                    }
                    break;
                case "Zes":
                    if (PionLopen(s, DobbelWaarde))
                    {
                        HuidigOnderdeel = "Dobbel";
                        //set text
                    }

                    if (PionInSpelBrengen(s))
                    {
                        HuidigOnderdeel = "Dobbel";
                        //set text
                    }
                    break;

            }
        }

        public bool PionLopen(int s, int steps)
        {
            if (bord.SpelVakken[s].Pion != null)
            {
                if (bord.SpelVakken[s].Pion.Eigenaar.Kleur.Equals(Beurt) && !(s > 39)) //max vakken
                {
                    bord.SpelVakken[s].Verplaats(steps);
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Geen Pion op dit vakje");
                return false;
            }
            return false;
        }

        public bool PionInSpelBrengen(int s)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (bord.Spelers[i].WachtVakken[j].Pion != null)
                    {
                        if (bord.Spelers[i].WachtVakken[j].Pion.Eigenaar.Kleur.Equals(Beurt))
                        {
                            bord.Spelers[i].WachtVakken[j].BrengPionInSpel();
                            bord.Spelers[i].WachtVakken[j].Pion = null;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }


        public bool CheckPionInSpel()
        {
            int PionInSpel = 0;
            for (int i = 0; i < 40; i++)
            {
                if (bord.SpelVakken[i].Pion != null)
                {
                    if (bord.SpelVakken[i].Pion.Eigenaar.Kleur.Equals(Beurt))
                    {
                        PionInSpel++;
                    }
                }
            }
            if (PionInSpel == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void GooiDobbelSteen()
        {
            DobbelWaarde = DobbelsteenSingleton.Instance.GooiDobbelsteen();
            gameWindow.DobbelValue.Content = DobbelWaarde;
        }

        private void CheckGewonnen()
        {
            for (int i = 0; i < bord.Spelers.Count - 1; i++)
            {
                if (bord.Spelers[i].Kleur.Equals(Beurt))
                {
                    if (bord.Spelers[i].ThuisVakkenVol())
                    {
                        gameWindow.ForegroundText.Content = bord.Spelers[i].Kleur + "wint het spel!";
                    }
                }
            }
        }

        private void DobbelOnderdeel()
        {
            GooiDobbelSteen();
            DobbelWedstrijd[WedstrijdRonde] = DobbelWaarde;
            WedstrijdRonde++;
            if (WedstrijdRonde == AantalSpelers)
            {
                for (int i = 0; i < AantalSpelers; i++)
                {
                    if (DobbelWedstrijd.Max() == DobbelWedstrijd[i])
                    {
                        switch (i)
                        {
                            case 0:
                                Beurt = "rood";
                                OnPropertyChanged("Beurt");
                                HuidigOnderdeel = "SPEL_BEGINNEN";
                                //setOnderdeel();
                                break;
                            case 1:
                                Beurt = "blauw";
                                OnPropertyChanged("Beurt");
                                HuidigOnderdeel = "SPEL_BEGINNEN";
                                //setOnderdeel();
                                break;
                            case 2:
                                Beurt = "groen";
                                OnPropertyChanged("Beurt");
                                HuidigOnderdeel = "SPEL_BEGINNEN";
                                //setOnderdeel();
                                break;
                            case 3:
                                Beurt = "geel";
                                OnPropertyChanged("Beurt");
                                HuidigOnderdeel = "SPEL_BEGINNEN";
                                //setOnderdeel();
                                break;
                        }
                    }
                }
            }
            else
            {
                VolgendeBeurt();
            }
        }

        public void BrengPionInSpel()
        {
        }

        private void VolgendeBeurt()
        {
            switch (AantalSpelers) //rood - blauw - zwart - geel
            {
                case 2:
                    if (Beurt.Equals("Rood"))
                    {
                        Beurt = "Blauw";
                        OnPropertyChanged("Beurt");
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                    else if (Beurt.Equals("Blauw"))
                    {
                        Beurt = "Rood";
                        OnPropertyChanged("Beurt");
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                    break;
                case 3:
                    if (Beurt.Equals("Rood"))
                    {
                        Beurt = "Blauw";
                        OnPropertyChanged("Beurt");
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                    else if (Beurt.Equals("Blauw"))
                    {
                        Beurt = "Zwart";
                        OnPropertyChanged("Beurt");
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                    else if (Beurt.Equals("Zwart"))
                    {
                        Beurt = "Rood";
                        OnPropertyChanged("Beurt");
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                    break;
                case 4:
                    if (Beurt.Equals("Rood"))
                    {
                        Beurt = "Blauw";
                        OnPropertyChanged("Beurt");
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                    else if (Beurt.Equals("Blauw"))
                    {
                        Beurt = "Zwart";
                        OnPropertyChanged("Beurt");
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                    else if (Beurt.Equals("Zwart"))
                    {
                        Beurt = "Geel";
                        OnPropertyChanged("Beurt");
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                    else if (Beurt.Equals("Geel"))
                    {
                        Beurt = "Rood";
                        OnPropertyChanged("Beurt");
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                    break;
            }
        }

        public void FieldButtonClicked(string buttonName)
        {
            string[] splittedUnderscore = buttonName.Split('_');
            char[] splittedValues = splittedUnderscore[0].ToCharArray();

            string totalString = "";
            int totalValue;

            for (int c = 1; c < splittedValues.Length; c++)
            {
                totalString += splittedValues[c].ToString();
            }

            try
            {
                totalValue = int.Parse(totalString);
                // in dit try blok de volgende functie aanroepen met de value totalValue. Alle exceptions worden opgevangen, dus moet goedkomen.
                // aub niet aan de code hierboven zitten.

                Console.WriteLine(totalValue.ToString()); //Deze is voor debug-doeleinden, nog niet verwijderen aub
            }
            catch
            {
                MessageBox.Show("Helaas is er iets met het bord niet goed, wij willen u verzoeken om dit te melden bij de makers.");
            }
        }
    }
}
