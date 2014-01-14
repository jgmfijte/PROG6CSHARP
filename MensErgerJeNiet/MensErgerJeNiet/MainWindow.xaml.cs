using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MensErgerJeNiet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bord speelBord;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void StartNewGame(int humanPlayers, int computerPlayers)
        {
            List<Speler> spelerList = new List<Speler>();

            int overallCount = 0;

            for(int c = 0; c < humanPlayers; c++){
                spelerList.Add(new Speler(Model.SpelersKleurenSingleton.Instance.GetKleuren()[(overallCount + 1)], new StartVak(), false));
                overallCount++;
            }

            for (int c = 0; c < computerPlayers; c++)
            {
                spelerList.Add(new Speler(Model.SpelersKleurenSingleton.Instance.GetKleuren()[(overallCount + 1)], new StartVak(), true));
                overallCount++;
            }

            speelBord = new Bord(spelerList);
        }

        public void PaintBord()
        {
            //          x P S
            //    W W   x T x   W W
            //    W W   x T x   W W  
            //          x T x
            //  S x x x x T x x x x x
            //  P T T T T   T T T T P
            //  x x x x x T x x x x S
            //          x T x
            //    W W   x T x   W W
            //    W W   x T x	W W
            //          S P x
            //
            // W = Wachtvakje
            // T = Thuisvakje
            // X = Normaal vakje
            // P = Poortvakje
            // S = Startvakje

            // Hieronder moet je dus die grid gaan vullen aan de hand van coordinaten. Hierboven staat het bord al uitgetekend.
        }
    }
}
