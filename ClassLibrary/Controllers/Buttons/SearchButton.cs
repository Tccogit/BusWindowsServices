using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ClassLibrary.Controllers.Buttons
{
    public partial class JSearchButton : System.Windows.Forms.Button
    {
        public JSearchButton()
        {
            InitializeComponent();
        }

        public JSearchButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
