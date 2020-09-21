using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder.Tariff
{
    public class ServiceTurn : JSystem
    {
        public int Code { get; set; }
        public int BusNumber { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FirstDay { get; set; }
        public int SecondDay { get; set; }
        public ServiceTurn()
        {
        }
        public ServiceTurn(int pCode)
        {
            if (pCode > 0)
            {
                this.GetData(pCode);
            }
        }
        public int Insert()
        {
            ServiceTurnTable AT = new ServiceTurnTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }

        public bool Update()
        {
            ServiceTurnTable AT = new ServiceTurnTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            ServiceTurnTable AT = new ServiceTurnTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                return true;
            }
            else return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusServiceTurn where code=" + pCode.ToString());
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
    }
}
