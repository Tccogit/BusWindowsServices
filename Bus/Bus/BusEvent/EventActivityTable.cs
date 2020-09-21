using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.BusEvent
{
    class EventActivityTable : ClassLibrary.JTable
    {
       
        public int Event;
        public int activity;
        public int Priority;
        public EventActivityTable()
           : base ("AUTBusEventActivity")
        {
        }
    }
}
