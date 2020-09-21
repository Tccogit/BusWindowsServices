using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Personel
{
    public class JPersonelContractTable :JTable 
    {
        public int PersonelCode;
        public DateTime StartDate;
        public DateTime EndDate;
        public int PCode;

        public JPersonelContractTable()
            : base("AUTPersonelContract")
        {
        }
    }
}
