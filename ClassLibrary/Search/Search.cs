using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ClassLibrary
{
    public class JSearch: JCore
    {

/*        private JPropertyTable _recordPropertyBag;
        public JPropertyTable RecordPropertyBag
        {
            get
            {
                return _recordPropertyBag;
            }
        }
        public JAction SearchAction;
        public JNode[] Resaults;

        public JSearch(JAction pSearchAction)
        {
                this._recordPropertyBag = new JPropertyTable();
                SearchAction = pSearchAction;
        }

        public void Show()
        {
            JSearchForm SF = new JSearchForm(this);
            SF.ShowDialog();
        }

        public void AddPropertyGrid(JPropertySpec pPropertySpec)
        {
            try
            {
                this._recordPropertyBag.Properties.Add(pPropertySpec);
            }
            catch (Exception) { throw; }
        }

        public object GetValue(string propertyName)
        {
            return this._recordPropertyBag[propertyName];
        }

        public bool SetValue(string propertyName, object value)
        {
            this._recordPropertyBag[propertyName] =  value;
            return true;
        }
        */
    }
}
