using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Personel
{
    public class JPersonelTable: JTable
    {
        public JPersonelTable()
            : base("AUTPersonel")
        {

        }
        public int PersonCode ;
        public string CertificateNumber ;
        public DateTime CertificateDate ;
        public DateTime CertificateExpirationDate ;
        public int CertificateType ;
        public string PersonelCode;
        public int Specification ;
        public int FleetCode ;
        public int EmployeeType ;
    }
}
