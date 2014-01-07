using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    class Dobbelsteen
    {
        public int Waarde { get; set; }

        public void Dobbel()
        {
            Random random = new Random();
            int waarde = random.Next(1, 7);
            Waarde = waarde;
        }
    }
}
