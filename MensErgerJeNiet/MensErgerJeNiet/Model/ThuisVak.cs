using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MensErgerJeNiet
{
    public class ThuisVak : Vak
    {
        public Speler VakEigenaar { get; set; }

        public ThuisVak(string kleur)
        {
            base.SetImage(kleur + "LeegSpelerVak");
        }

        public bool HeeftPion()
        {
            if (this.Pion != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
