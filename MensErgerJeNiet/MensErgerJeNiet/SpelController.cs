using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class SpelController
    {
        public SpelController(int realSpelers, int computerSpelers)
        {
            new MensErgerJeNiet.Model.Bord2(realSpelers, computerSpelers);
            Console.WriteLine("eind");
        }



    }
}
