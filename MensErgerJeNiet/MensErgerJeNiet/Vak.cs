using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MensErgerJeNiet
{
    public class Vak
    {
        public Vak VorigVak { get; set; }
        public Vak VolgendVak { get; set; }
        public Pion Pion { get; set; }
        public Image BackgroundImage { get; set; }
        public Color VakColor { get; set; }
    }
}
