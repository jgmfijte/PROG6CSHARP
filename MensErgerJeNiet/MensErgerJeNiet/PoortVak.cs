using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensErgerJeNiet
{
    public class PoortVak : Vak
    {
        private LinkedList<ThuisVak> _ThuisVakken = new LinkedList<ThuisVak>();

        public PoortVak(LinkedList<ThuisVak> thuisVakken)
        {
            this._ThuisVakken = thuisVakken;
        }
    }
}
