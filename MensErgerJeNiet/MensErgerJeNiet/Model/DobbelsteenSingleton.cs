using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class DobbelsteenSingleton
    {
        private static DobbelsteenSingleton instance;

        private DobbelsteenSingleton() { }

        Random random = new Random();

        public static DobbelsteenSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DobbelsteenSingleton();
                }
                return instance;
            }
        }

        public int GooiDobbelsteen()
        {
            return random.Next(1, 7);
        }
    }
}
