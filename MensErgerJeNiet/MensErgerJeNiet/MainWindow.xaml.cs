using MensErgerJeNiet.Model;
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

        public MainWindow()
        {
            InitializeComponent();
        }

        public void StartNewGame(int humanPlayers, int computerPlayers)
        {
            //List<Speler> spelerList = new List<Speler>();
            //
            //int overallCount = 0;
            //
            //for(int c = 0; c < humanPlayers; c++){
            //    spelerList.Add(new Speler(Model.SpelersKleurenSingleton.Instance.GetKleuren()[(overallCount + 1)], new StartVak(), false));
            //    overallCount++;
            //}
            //
            //for (int c = 0; c < computerPlayers; c++)
            //{
            //    spelerList.Add(new Speler(Model.SpelersKleurenSingleton.Instance.GetKleuren()[(overallCount + 1)], new StartVak(), true));
            //    overallCount++;
            //}
            //
            //speelBord = new Bord(spelerList);
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            int realSpelers;
            int computerSpelers;
            int totalSpelers;

            try
            {
                realSpelers = int.Parse(humanPlayers.Text);
                computerSpelers = int.Parse(computerPlayers.Text);

                totalSpelers = realSpelers + computerSpelers;

                
                if (totalSpelers >= 2 && totalSpelers <= 4)
                {
                    new SpelWindow(realSpelers, computerSpelers).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sorry, je hebt de spelregels niet helemaal goed gelezen zo te zien. Je moet minimaal 1 echte speler hebben. Heb je 1 echte speler, dan moet je ook minimaal 1 computerspeler hebben. Anders moet je minimaal 2 echte spelers kiezen. Aan het totaal aantal spelers zit wel een maximum van 4! Probeer het opnieuw aub.", "Error in input", MessageBoxButton.OK);
                }
            }
            catch
            {
                MessageBox.Show("De waardes die je hebt ingevuld zijn niet geldig, dit moet verplicht een getal zijn.", "Error in input", MessageBoxButton.OK);
            }
        }
    }
}
