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
            spel = new SpelController(realSpelers, computerSpelers);
            InitializeComponent();
            DataContext = spel;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int dobbelWaarde = DobbelsteenSingleton.Instance.GooiDobbelsteen();

            DobbelValue.Content = dobbelWaarde;
        }
    }
}
