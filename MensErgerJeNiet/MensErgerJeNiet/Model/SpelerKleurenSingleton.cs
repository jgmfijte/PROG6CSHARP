using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MensErgerJeNiet.Model
{
    public class SpelersKleurenSingleton
    {
        private static SpelersKleurenSingleton instance;

        private SpelersKleurenSingleton() { }

        public static SpelersKleurenSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SpelersKleurenSingleton();
                }
                return instance;
            }
        }

        public Dictionary<int, Color> GetKleuren()
        {
            Dictionary<int, Color> colorDict = new Dictionary<int, Color>();

            colorDict.Add(1, Color.FromRgb(255, 0, 0));
            colorDict.Add(2, Color.FromRgb(0, 255, 0));
            colorDict.Add(3, Color.FromRgb(0, 0, 255));
            colorDict.Add(4, Color.FromRgb(255, 255, 0));

            return colorDict;
        }
    }
}
