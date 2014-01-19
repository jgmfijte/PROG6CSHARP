using MensErgerJeNiet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
