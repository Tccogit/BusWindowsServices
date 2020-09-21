using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JGlobal: JSystem
    {
        public JGlobal()
        {
            if (MainFrame == null)
            {
                MainFrame = new JMainFrame();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static JMainFrame MainFrame = new JMainFrame();

        public static JUser CurrentUser;
    }
}
