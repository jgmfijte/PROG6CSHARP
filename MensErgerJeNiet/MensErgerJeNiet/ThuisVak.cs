using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class ThuisVak : Vak
    {
        public Speler VakEigenaar { get; set; }
        public bool HeeftPion()
        {
            return false;
        }
    }
}
