using MensErgerJeNiet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

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

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

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

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            OnPropertyChanged("beurt");
            OnPropertyChanged("HuidigOnderdeel");
            OnPropertyChanged("bord");
            OnPropertyChanged("gameWindow");

            foreach (Vak v in bord.SpelVakken)
            {
                OnPropertyChanged("BackgroundImage");
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
                        GooiDobbelSteen();
                        HuidigOnderdeel = "Dobbel";
                        OnPropertyChanged("bord");
                        VolgendeBeurt();
                        //set text;
                    }
                    else
                    {
                        MessageBox.Show("Er gaat iets mis in de case Spel_Beginnen tijdens het PionInSpelBrengen(). Deze hoort de waarde true te returnen maar doet dit niet.");
                    }
                    break;
                case "Lopen":
                    if (PionLopen(DobbelWaarde))
                    {
                        CheckGewonnen();
                        GooiDobbelSteen();
                        HuidigOnderdeel = "Dobbel";
                        OnPropertyChanged("bord.SpelVakken");
                        VolgendeBeurt();
                    }
                    else
                    {
                        MessageBox.Show("Er gaat iets mis in de case Lopen tijdens het PionLopen met dobbelwaarde " + DobbelWaarde + ". Heb je wel een pion geselecteerd?");
                    }
                    break;
                case "Dobbel":
                    if (DobbelWaarde < 6)
                    {
                        if (CheckPionInSpel())
                        {
                            HuidigOnderdeel = "Lopen";
                            OnPropertyChanged("bord.SpelVakken");
                            SpeelSpel();
                            //set text
                        }
                        else
                        {
                            GooiDobbelSteen();
                            HuidigOnderdeel = "Dobbel";
                            OnPropertyChanged("bord.SpelVakken");
                            //set text
                            VolgendeBeurt();
                        }
                        OnPropertyChanged("bord.SpelVakken");
                    }
                    else if (DobbelWaarde == 6)
                    {
                        HuidigOnderdeel = "Zes";
                        SpeelSpel();
                        //set text
                        OnPropertyChanged("bord.SpelVakken");
                    }
                    break;
                case "Zes":
                    if (PionLopen(DobbelWaarde))
                    {
                        GooiDobbelSteen();
                        HuidigOnderdeel = "Dobbel";
                        OnPropertyChanged("bord.SpelVakken");
                        VolgendeBeurt();
                        //set text
                    }

                    if (PionInSpelBrengen())
                    {
                        GooiDobbelSteen();
                        HuidigOnderdeel = "Dobbel";
                        OnPropertyChanged("bord.SpelVakken");
                        VolgendeBeurt();
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
            Speler huidigeSpeler = bord.Spelers.First(s => s.Kleur == Beurt);

            for (int j = 0; j < 4; j++)
            {
                if (huidigeSpeler.WachtVakken[j] != null)
                {
                    huidigeSpeler.WachtVakken[j].BrengPionInSpel();
                    huidigeSpeler.WachtVakken[j].Pion = null;
                    
                    for (int x = 0; x < 4; x++)
                    {
                        Console.WriteLine("testing - " + huidigeSpeler.WachtVakken[x].Pion); 
                    }
                    return true;
                }
                else
                {
                    return false;
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
            for (int i = 0; i < AantalSpelers; i++)
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
                        gameWindow.VorigeSpelerBeurt.Content = Beurt;

                        switch (i)
                        {
                            case 0:
                                Beurt = "Rood";
                                break;
                            case 1:
                                Beurt = "Blauw";
                                break;
                            case 2:
                                Beurt = "Zwart";
                                break;
                            case 3:
                                Beurt = "Geel";
                                break;
                        }

                        HuidigOnderdeel = "Spel_Beginnen";
                        gameWindow.SpelerAanDeBeurt.Content = Beurt;
                    }
                }
            }
            else
            {
                VolgendeBeurt();
            }

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

                Console.WriteLine(bord.SpelVakken[totalValue].GetType().ToString());

                if (HuidigOnderdeel == "Lopen")
                {
                    if (bord.SpelVakken[totalValue].Pion != null && !bord.SpelVakken[totalValue].GetType().ToString().Equals("MensErgerJeNiet.WachtVak"))
                    {
                        if (bord.SpelVakken[totalValue].Pion.Eigenaar.Kleur.Equals(Beurt))
                        {
                            FieldValue = totalValue;
                            SpeelSpel();
                        }
                    }
                }
                Console.WriteLine(totalValue.ToString()); //Deze is voor debug-doeleinden, nog niet verwijderen aub
            }
            catch
            {
                MessageBox.Show("Helaas is er iets met het bord niet goed, wij willen u verzoeken om dit te melden bij de makers.");
            }
        }
    }
}
