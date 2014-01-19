using MensErgerJeNiet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class SpelController
    {
        public Bord2 bord { get; set; }

        public SpelController(int realSpelers, int computerSpelers)
        {
            bord = new Bord2(realSpelers, computerSpelers);
            //new MensErgerJeNiet.Model.Bord2(realSpelers, computerSpelers);
            Console.WriteLine("eind");
        }



    }
}
