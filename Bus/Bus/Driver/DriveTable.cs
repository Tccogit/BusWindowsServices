using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusManagment.Driver
{
    public class DriveTable : ClassLibrary.JTable
    {

        public int PersonCode;
        public int EmploymentCode;
        public string CertificateNumber;
        public DateTime CertificateDate;
        public DateTime CertificateExpirationDate;
        public int CertificateType;

        public DriveTable()
            : base("AUTDrive")
        {
        }
    }
}
