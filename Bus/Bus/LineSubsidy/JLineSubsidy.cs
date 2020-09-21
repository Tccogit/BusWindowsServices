using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.LineSubsidy
{
    public class JLineSubsidy : JSystem
    {
        public int Code { get; set; }
        public Double Linenumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxServiceSubsidyPrice { get; set; }
        public int MinServiceSubsidyPrice { get; set; }
        public int MaxTransactionSubsidyPrice { get; set; }
        public int MinTransactionSubsidyPrice { get; set; }
        public int ServicePrice { get; set; }
        public int TransactionPrice { get; set; }
        public int MaxSubsidyPrice { get; set; }

        public JLineSubsidy() { }
        public int Insert(bool isWeb = false)
        {

            if (!JPermission.CheckPermission("BusManagment.LineSubsidy.JLineSubsidy.Insert"))
                return 0;
            JLineSubsidyTable LST = new JLineSubsidyTable();
            LST.SetValueProperty(this);
            Code = LST.Insert();
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JLineSubsidy", Code, 0, 0, 0, "ثبت LineSubsidy", "", 0);
            return Code;

        }
        public bool GetData(int PCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from AUTLineSubsidy where code=" + PCode);
                if (DB.Query_DataReader())
                    if (DB.DataReader.Read())
                    {
                        ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                        return true;
                    }
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        public bool Update() 
        {
            JLineSubsidyTable LST = new JLineSubsidyTable();
            LST.SetValueProperty(this);
            return LST.Update();

        }

    }
}
