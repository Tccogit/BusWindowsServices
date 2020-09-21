using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace BusManagment.SMS
{
    public class JSMS : JSystem
    {
        public int Code { get; set; }
        public string Mobile { get; set; }
        public string Text { get; set; }
        public string send { get; set; }
        public DateTime Regdate { get; set; }
        public DateTime Senddate { get; set; }
        public string Description { get; set; }
        public string project { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }
        public int PersonCode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SendDevice { get; set; }
        public string batchId { get; set; }
        public JSMS() { }
      
        public int Insert(bool isWeb = false)
        {
           
                if (!JPermission.CheckPermission("BusManagment.SMS.JSMS.Insert"))
                    return 0;
                JSMSTable ST = new JSMSTable();
                ST.SetValueProperty(this);
                Code = ST.Insert();
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JSMS", Code, 0, 0, 0, "ثبت SMS", "", 0);
                return Code;
           
        }

        


    }
 
    }

