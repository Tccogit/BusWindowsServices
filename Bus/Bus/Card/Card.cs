using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.Card
{
    public class JCard : JSystem
    {
        public int Code { get; set; }
        public int Type { get; set; }

        public JCard()
        {
        }
        public JCard(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            return false;
        }

        public bool Delete(bool isWeb = false)
        {
            return false;
        }

        public bool GetData(int pCode)
        {
            return false;
        }

    }


    public class JCards : JSystem
    {

        public static DataTable GetDataTable(int pCode = 0)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = "select * from AUTCardType "
                     + " Where " + JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "AUTCardType.Code");
                if (pCode > 0)
                    query += " AND  Code = " + pCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }



    }

}
