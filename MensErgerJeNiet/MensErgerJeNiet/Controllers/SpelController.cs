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
        private string VorigeBeurt { get; set; }
        private int AantalSpelers { get; set; }
        private int DobbelWaarde { get; set; }
        private int[] DobbelWedstrijd;
        private int FieldValue { get; set; }
        private int WedstrijdRonde;
        private bool canUseButtons = false;

        public SpelController(int realSpelers, int computerSpelers, SpelWindow gameWindow)
        {
            this.gameWindow = gameWindow;
            RealSpelers = realSpelers;
            ComputerSpelers = computerSpelers;
            AantalSpelers = RealSpelers + ComputerSpelers;
            bord = new Bord(RealSpelers, ComputerSpelers);

            WedstrijdRonde = 0;
            DobbelWedstrijd = new int[4];
            HuidigOnderdeel = "Spel_Start";
            Beurt = "Rood";

            gameWindow.SpelerAanDeBeurt.Content = Beurt;
            gameWindow.VorigeSpelerBeurt.Content = "";
            gameWindow.ForegroundText.Content = "Hier komt wat aanvullende info!";
            // SpeelSpel(100);

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void SpeelSpel()
        {
            switch (HuidigOnderdeel)
            {
                case "Spel_Start":
                    DobbelOnderdeel();
                    break;
                case "Spel_Beginnen":
                    if (PionInSpelBrengen())
                    {
                        HuidigOnderdeel = "Dobbel";
                        SpeelSpel();
                        //set text;
                    }
                    break;
                case "Lopen":
                    if (PionLopen(DobbelWaarde))
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
                            SpeelSpel();
                            //set text
                        }
                        else
                        {
                            HuidigOnderdeel = "Dobbel";
                            //set text
                            VolgendeBeurt();
                        }
                    }
                    else if(DobbelWaarde == 6)
                    {
                        HuidigOnderdeel = "Zes";
                        SpeelSpel();
                        //set text
                    }
                    break;
                case "Zes":
                    if (PionLopen(DobbelWaarde))
                    {
                        HuidigOnderdeel = "Dobbel";
                        //set text
                    }

                    if (PionInSpelBrengen())
                    {
                        HuidigOnderdeel = "Dobbel";
                        SpeelSpel();
                        //set text
                    }
                    break;

            }
        }

        public bool PionLopen(int steps)
        {
            if (bord.SpelVakken[FieldValue].Pion != null)
            {
                if (bord.SpelVakken[FieldValue].Pion.Eigenaar.Kleur.Equals(Beurt) && !(FieldValue > 39)) //max vakken
                {
                    bord.SpelVakken[FieldValue].Verplaats(steps);
                    OnPropertyChanged("Bord");
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

        public bool PionInSpelBrengen()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (bord.Spelers[i].WachtVakken[j].Pion != null)
                    {
                        Console.WriteLine(bord.Spelers[i].WachtVakken[j].Pion.Eigenaar.Kleur);
                        Console.WriteLine(Beurt);

                        if (bord.Spelers[i].WachtVakken[j].Pion.Eigenaar.Kleur.Equals(Beurt))
                        {
                            bord.Spelers[i].WachtVakken[j].BrengPionInSpel();
                            bord.Spelers[i].WachtVakken[j].Pion = null;
                            return true;
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
                        gameWindow.ForegroundText.Content = bord.Spelers[i].Kleur + " wint het spel!";
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
                                    gameWindow.VorigeSpelerBeurt.Content = Beurt;
                                    Beurt = "Rood";
                                    HuidigOnderdeel = "Spel_Beginnen";
                                    gameWindow.SpelerAanDeBeurt.Content = Beurt;
                                    //setOnderdeel();
                                    break;
                                case 1:
                                    gameWindow.VorigeSpelerBeurt.Content = Beurt;
                                    Beurt = "Blauw";
                                    HuidigOnderdeel = "Spel_Beginnen";
                                    gameWindow.SpelerAanDeBeurt.Content = Beurt;
                                    //setOnderdeel();
                                    break;
                                case 2:
                                    gameWindow.VorigeSpelerBeurt.Content = Beurt;
                                    Beurt = "Zwart";
                                    HuidigOnderdeel = "Spel_Beginnen";
                                    gameWindow.SpelerAanDeBeurt.Content = Beurt;
                                    //setOnderdeel();
                                    break;
                                case 3:
                                    gameWindow.VorigeSpelerBeurt.Content = Beurt;
                                    Beurt = "Geel";
                                    HuidigOnderdeel = "Spel_Beginnen";
                                    gameWindow.SpelerAanDeBeurt.Content = Beurt;
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
                        VorigeBeurt = Beurt;
                        Beurt = "Blauw";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                        gameWindow.VorigeSpelerBeurt.Content = VorigeBeurt;
                    }
                    else if (Beurt.Equals("Blauw"))
                    {
                        VorigeBeurt = Beurt;
                        Beurt = "Rood";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                        gameWindow.VorigeSpelerBeurt.Content = VorigeBeurt;
                    }
                    break;
                case 3:
                    if (Beurt.Equals("Rood"))
                    {
                        VorigeBeurt = Beurt;
                        Beurt = "Blauw";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                        gameWindow.VorigeSpelerBeurt.Content = VorigeBeurt;
                    }
                    else if (Beurt.Equals("Blauw"))
                    {
                        VorigeBeurt = Beurt;
                        Beurt = "Zwart";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                        gameWindow.VorigeSpelerBeurt.Content = VorigeBeurt;
                    }
                    else if (Beurt.Equals("Zwart"))
                    {
                        VorigeBeurt = Beurt;
                        Beurt = "Rood";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                        gameWindow.VorigeSpelerBeurt.Content = VorigeBeurt;
                    }
                    break;
                case 4:
                    if (Beurt.Equals("Rood"))
                    {
                        VorigeBeurt = Beurt;
                        Beurt = "Blauw";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                        gameWindow.VorigeSpelerBeurt.Content = VorigeBeurt;
                    }
                    else if (Beurt.Equals("Blauw"))
                    {
                        VorigeBeurt = Beurt;
                        Beurt = "Zwart";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                        gameWindow.VorigeSpelerBeurt.Content = VorigeBeurt;
                    }
                    else if (Beurt.Equals("Zwart"))
                    {
                        VorigeBeurt = Beurt;
                        Beurt = "Geel";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                        gameWindow.VorigeSpelerBeurt.Content = VorigeBeurt;
                    }
                    else if (Beurt.Equals("Geel"))
                    {
                        VorigeBeurt = Beurt;
                        Beurt = "Rood";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                        gameWindow.VorigeSpelerBeurt.Content = VorigeBeurt;
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

                FieldValue = totalValue;
                SpeelSpel();

                Console.WriteLine(totalValue.ToString()); //Deze is voor debug-doeleinden, nog niet verwijderen aub
            }
            catch
            {
                MessageBox.Show("Helaas is er iets met het bord niet goed, wij willen u verzoeken om dit te melden bij de makers.");
            }
        }
    }
}
