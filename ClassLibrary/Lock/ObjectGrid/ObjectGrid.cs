using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ClassLibrary
{
    public enum JDataType
    {
        Number,
        Text,
        Money,
        Date,
        Time,
        DateTime,
        List
    }

    public partial class JObjectGrid : UserControl
    {

        public JObjectGrid()
        {
            InitializeComponent();
        }

        public void AddItem(string pName, JDataType pType,object pList, object pDefaultValue, int pOrder)
        {
            if (pType == JDataType.Number)
            {

            }
            else
                if (pType == JDataType.Text)
                {
                }
                else
                    if (pType == JDataType.Date)
                    {
                    }
                    else
                        if (pType == JDataType.DateTime)
                        {
                        }
                        else
                            if (pType == JDataType.List)
                            {
                            }
                            else
                                if (pType == JDataType.Money)
                                {
                                }
                                else
                                    if (pType == JDataType.Time)
                                    {
                                    }
        }

        public void Refresh()
        {
        }
    }
}
