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
using System.Windows.Shapes;

namespace MensErgerJeNiet.Model
{
    /// <summary>
    /// Interaction logic for Spel.xaml
    /// </summary>
    public partial class SpelWindow : Window
    {
        public SpelController spel;

        public SpelWindow(int realSpelers, int computerSpelers)
        {
            InitializeComponent();
            
            spel = new SpelController(realSpelers, computerSpelers, this);
            
            DataContext = spel;
            //spel.SpeelSpel(100);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            spel.SpeelSpel(100);
            //spel.GooiDobbelSteen();
        }

        private void FieldButton_Click(object sender, RoutedEventArgs e)
        {
            var buttonClicked = (Button)sender;
            spel.FieldButtonClicked(buttonClicked.Name);
        }
    }
}
