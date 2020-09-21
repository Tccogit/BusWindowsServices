using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    class Types
    {
    }


    public class NameValue
    {
        public string Name;
        public int Value;

        public override string ToString()
        {
            return JLanguages._Text(Name);
        }
    }
}
