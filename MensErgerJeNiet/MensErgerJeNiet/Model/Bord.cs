using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace MensErgerJeNiet
{
    public class Bord
    {
        private List<Speler> _Spelers ;

        private Speler speler1 = null;
        private Speler speler2 = null;
        private Speler speler3 = null;
        private Speler speler4 = null;

        private LinkedList<ThuisVak> ThuisVakjesPlayer1 = new LinkedList<ThuisVak>();
        private LinkedList<ThuisVak> ThuisVakjesPlayer2 = new LinkedList<ThuisVak>();
        private LinkedList<ThuisVak> ThuisVakjesPlayer3 = new LinkedList<ThuisVak>();
        private LinkedList<ThuisVak> ThuisVakjesPlayer4 = new LinkedList<ThuisVak>();

        private IEnumerable _Vakjes;
        private LinkedList<Vak> VakjesLinkedList = new LinkedList<Vak>();

        public Bord(List<Speler> Spelers)
        {
            this._Spelers = Spelers;
            InitializeSpelers();
            InitializeThuisVakjes();
            MaakBord();
        }

        private void InitializeSpelers()
        {
            speler1 = _Spelers.ElementAt(0);
            speler2 = _Spelers.ElementAt(1);
            
            if (_Spelers.ElementAt(2) != null)
            {
                speler3 = _Spelers.ElementAt(2);
            }
            if (_Spelers.ElementAt(3) != null)
            {
                speler4 = _Spelers.ElementAt(3);
            }
        }

        private void InitializeThuisVakjes()
        {
            for (int c = 0; c < 4; c++)
            {
                ThuisVakjesPlayer1.AddFirst(new ThuisVak(speler1.Kleur));
                ThuisVakjesPlayer2.AddFirst(new ThuisVak(speler2.Kleur));
            }

            if (speler3 != null)
            {
                for (int c = 0; c < 4; c++)
                {
                    ThuisVakjesPlayer3.AddFirst(new ThuisVak(speler3.Kleur));
                }
            }

            if (speler4 != null)
            {
                for (int c = 0; c < 4; c++)
                {
                    ThuisVakjesPlayer4.AddFirst(new ThuisVak(speler4.Kleur));
                }
            }
        }

        private void MaakBord()
        {
            LinkedList<ThuisVak> ThuisVakjeLinkedList = new LinkedList<ThuisVak>();

            //for (int c = 0; c < 4; c++)
            //{
            //    ThuisVakjeLinkedList.AddFirst(new ThuisVak(Model.SpelersKleurenSingleton.Instance.GetKleuren()[(c + 1)]));
            //}

                VakjesLinkedList.AddFirst(speler1.StartVak);
            for (int c = 0; c < 8; c++ )
                VakjesLinkedList.AddLast(new Vak());

            VakjesLinkedList.AddLast(speler2.PoortVak = new PoortVak(ThuisVakjesPlayer2));
            VakjesLinkedList.AddLast(speler2.StartVak);
            for (int c = 0; c < 8; c++)
                VakjesLinkedList.AddLast(new Vak());

            if (speler3 != null)
            {
                VakjesLinkedList.AddLast(speler3.PoortVak = new PoortVak(ThuisVakjesPlayer3));
                VakjesLinkedList.AddLast(speler3.StartVak);
            }
            else
            {
                VakjesLinkedList.AddLast(new Vak());
                VakjesLinkedList.AddLast(new Vak());
            }
            for (int c = 0; c < 8; c++)
                VakjesLinkedList.AddLast(new Vak());

            if (speler4 != null)
            {
                VakjesLinkedList.AddLast(speler4.PoortVak = new PoortVak(ThuisVakjesPlayer4));
                VakjesLinkedList.AddLast(speler4.StartVak);
            }
            else
            {
                VakjesLinkedList.AddLast(new Vak());
                VakjesLinkedList.AddLast(new Vak());
            }
            for (int c = 0; c < 8; c++)
                VakjesLinkedList.AddLast(new Vak());

            VakjesLinkedList.AddLast(new PoortVak(ThuisVakjesPlayer1));
        }
    }
}
