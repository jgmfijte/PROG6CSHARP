using MensErgerJeNiet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MensErgerJeNiet
{
    public class SpelController
    {
        public Bord bord { get; set; }
        private SpelWindow gameWindow;

        public SpelController(int realSpelers, int computerSpelers, SpelWindow gameWindow)
        {
            this.gameWindow = gameWindow;

            bord = new Bord(realSpelers, computerSpelers);

            gameWindow.SpelerAanDeBeurt.Content = "Speler 1 (Rood)";
            gameWindow.ForegroundText.Content = "Hier komt wat aanvullende info!";
        }

        public void GooiDobbelSteen()
        {
            gameWindow.DobbelValue.Content = DobbelsteenSingleton.Instance.GooiDobbelsteen();
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
