using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JRowStyle : JSystem
    {
        public string Expression;
        public string Value;
        public Janus.Windows.GridEX.GridEXFormatStyle JanusRowStyle;

        public JRowStyle()
        {
        }
    }

    public class JRowStyles : JSystem
    {
        public JRowStyle[] Rows = new JRowStyle[0];

        public JRowStyles()
        {
        }

        public int Add(JRowStyle pRow)
        {
            Array.Resize(ref Rows, Rows.Length + 1);
            Rows[Rows.Length - 1] = pRow;
            return Rows.Length - 1;
        }

        public void Clear()
        {
            Array.Resize(ref Rows, 0);
        }
    }
}
