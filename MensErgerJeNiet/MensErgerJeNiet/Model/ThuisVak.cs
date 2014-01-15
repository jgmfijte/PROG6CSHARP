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
        public string Kleur { get; set; }

        public ThuisVak(string kleur)
        {
            SetImage(Kleur + "Thuis");
            this.Kleur = kleur;
        }

        public bool HeeftPion()
        {
            return false;
        }
    }
}
