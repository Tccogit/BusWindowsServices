using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Station
{
   public class JStationType:ClassLibrary.JSubBaseDefine
    {
       public JStationType()
           : base(ClassLibrary.JBaseDefine.TypeStation)
        {
        }
    }
   public class JStationTypes : ClassLibrary.JSubBaseDefines
   {
       public JStationTypes()
           : base(ClassLibrary.JBaseDefine.TypeStation)
       {
       }
   }
}
