using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Personel
{
    public class JPersonelContract
    {
        public int Code { get; set; }
        public int PersonelCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PCode { get; set; }
         public JPersonelContract()
        {
        }
         public JPersonelContract(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert()
        {
            JPersonelContractTable AT = new JPersonelContractTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }
        public bool Delete()
        {
            JPersonelContractTable AT = new JPersonelContractTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }
        public bool Update()
        {
            JPersonelContractTable AT = new JPersonelContractTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPersonelContract where Code=" + pCode.ToString());
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

    public class JPersonelContracts
    {
        public static DataTable GetDataTable(int pPersonelCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"Select AUTPersonelContract .Code
	                ,(SELECT Fa_Date FROM StaticDates WHERE En_Date = AUTPersonelContract .StartDate ) StartDate 
	                ,(SELECT Fa_Date FROM StaticDates WHERE En_Date = AUTPersonelContract .EndDate ) EndDate 
               		,clsAllPerson .Name as OwnerName
		                From AUTPersonelContract 
                        Inner Join clsAllPerson ON  AUTPersonelContract .PCode = clsAllPerson .Code 
                        WHERE AUTPersonelContract.PersonelCode=" + pPersonelCode.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }
    }

}
