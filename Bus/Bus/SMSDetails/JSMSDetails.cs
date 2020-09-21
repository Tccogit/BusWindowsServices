using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.SMSDetails
{
    public class JSMSDetails : JSystem
    {
        public int Code { get; set; }
        public int SMSMasterCode { get; set; }
        public int Status { get; set; }
        public int PersonCode { get; set; }
        public JSMSDetails() { }
        public int Insert(bool isweb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.SMSDetails.JSMSDetails.Insert"))
                return 0;
            JSMSDetailsTable ST = new JSMSDetailsTable();
            ST.SetValueProperty(this);
            Code = ST.Insert(0,true);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JSMSDetails", Code, 0, 0, 0, "جزئیات SMS", "", 0);
            return Code;

        }
    }
}
