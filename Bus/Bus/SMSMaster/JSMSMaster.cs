using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.SMSMaster
{
    public class JSMSMaster : JSystem
    {
        public int Code { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime SendDate { get; set; }
        public int UserCode { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int IsSend { get; set; }
        public JSMSMaster()
        { }
        public int Insert(bool IsWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.SMSMaster.JSMSMaster.Insert"))
                return 0;
            JSMSMasterTable ST = new JSMSMasterTable();
            ST.SetValueProperty(this);
            Code = ST.Insert(0, true);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JSMSMaster", Code, 0, 0, 0, "ثبت کننده SMS", "", 0);
            return Code;

        }

    }
}
