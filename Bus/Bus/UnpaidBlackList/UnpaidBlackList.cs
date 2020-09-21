using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.UnpaidBlackList
{
    public class JUnpaidBlackList : JSystem
    {
        public int Code { get; set; }
        public int pCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime InsertDate { get; set; }
        public bool PayAfterFinish { get; set; }//uuu

        public JUnpaidBlackList()
        {
        }
        public JUnpaidBlackList(int Code)
        {
            if (Code > 0)
                this.GetData(Code);
        }

        public bool GetData(int Code)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from UnpaidBlackList where Code =" + Code.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.UnpaidBlackList.JUnpaidBlackList.Insert"))
            //    return 0;
            UnpaidBlackListTable AT = new UnpaidBlackListTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();

            jHistory.Save("BusManagment.JUnpaidBlackList", Code, 0, 0, 0, "ثبت در لیست سیاه عدم پرداخت ", "", 0);
            return Code;
        }
        public bool Update(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.UnpaidBlackList.JUnpaidBlackList.Insert"))
            //    return 0;
            UnpaidBlackListTable AT = new UnpaidBlackListTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JUnpaidBlackList", AT.Code, 0, 0, 0, "ویرایش لیست سیاه عدم پرداخت", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.UnpaidBlackList.JUnpaidBlackList.Delete"))
            //    return false;
            UnpaidBlackListTable AT = new UnpaidBlackListTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                //if (!isWeb)
                //    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JUnpaidBlackList", AT.Code, 0, 0, 0, "حذف از لیست سیاه عدم پرداخت", "", 0);
                return true;
            }
            else return false;
        }


    }
}
