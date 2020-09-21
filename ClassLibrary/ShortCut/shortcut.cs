using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JShortCut
    {
        public System.Windows.Forms.Keys Key = System.Windows.Forms.Keys.None;
        public bool Alt;
        public bool Control;
        public bool Shift;
        public JAction Action;
        public object Object;
    }

    public class JShortCuts
    {
        public JShortCut[] ShortCuts;

        public void Add(JShortCut pShortCut)
        {
            Array.Resize(ref ShortCuts, ShortCuts.Length + 1);
            ShortCuts[ShortCuts.Length - 1] = pShortCut;
        }

        public void Delete(System.Windows.Forms.KeyEventArgs pKeyt)
        {
            int i = Find(pKeyt);
            if (i >= 0)
            {
                Shift(i);
            }
        }

        public void Clear()
        {
            Array.Resize(ref ShortCuts, 0);
        }

        public void Shift(int pIndex)
        {
            for (int i = pIndex; i < ShortCuts.Length -1 ; i++)
            {
                ShortCuts[i] = ShortCuts[i + 1];
            }
            Array.Resize(ref ShortCuts, ShortCuts.Length - 1);
        }


        public int Find(System.Windows.Forms.KeyEventArgs pKey)
        {
            int i = 0;
            foreach (JShortCut sc in ShortCuts)
            {
                if (sc.Alt == pKey.Alt
                    && sc.Control == pKey.Control
                    && sc.Shift == pKey.Shift
                    && sc.Key == pKey.KeyCode)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public object Run(System.Windows.Forms.KeyEventArgs pKey)
        {
            int i = Find(pKey);

            if (i >= 0)
            {
                JShortCut SC = ShortCuts[i];
                return SC.Action.run(SC.Object);
            }
            return null;
        }

    }
}
