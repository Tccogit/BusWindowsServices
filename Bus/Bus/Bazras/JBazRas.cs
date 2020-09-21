using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;

namespace BusManagment.Bazras
{
    public class JBazRasService
    {
        public int Code { get; set; }
        public Int64 BazrasCode { get; set; }
        public Int64 DriverCode { get; set; }
        public int BusNumber { get; set; }
        public int LineNumber { get; set; }
        public DateTime DateCard { get; set; }
        public DateTime MoveDate { get; set; }
        public DateTime RealMoveDate { get; set; }

        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public DateTime Date3 { get; set; }
        public Int16 BazrasDevice { get; set; }

        public int Insert()
        {
            JBazRasServiceTable BST = new JBazRasServiceTable();
            BST.SetValueProperty(this);
            BST.IsView = true;
            return BST.Insert(1, true);
        }
        public bool Updateit1() //update insert field of database in autbazrasservice for bazrasservicereport 
        {

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(@"
                    update AUTBazRasService Set InsertDate=getdate()
                    where code=" + Code + "");
                DB.Query_Execute();
            }
            finally
            {
                DB.Dispose();
            }
            JBazRasServiceTable BST = new JBazRasServiceTable();
            BST.SetValueProperty(this);
            return BST.Update();

        }
        public bool Update(bool RefershAgain)
        {
            if (RefershAgain)
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    DB.setQuery(@"delete from AutBusServices where ISOK = 11 and EzamBeCode = " + Code);
                    // exec[SP_UpdateBazrasService] '" + MoveDate.ToString("yyyy-MM-dd") + "'");
                    DB.Query_Execute(true);
                }
                catch
                {

                }
                finally
                {
                   // DB.Dispose();
                }
            }
            else
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    DB.setQuery(@"delete from AutBusServices where ISOK = 11 and  EzamBeCode = " + Code);
                    DB.Query_Execute(true);
                }
                catch
                {

                }
                finally
                {
                   // DB.Dispose();
                }
            }
            JBazRasServiceTable BST = new JBazRasServiceTable();
            BST.SetValueProperty(this);
            return BST.Update();

        }
        public int Find()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select Code from AUTBazRasService a where a.BusNumber="
                    + BusNumber
                    + " and a.MoveDate='"
                    + MoveDate.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                DataTable DT = DB.Query_DataTable();
                if (DT != null && DT.Rows.Count == 1)
                {
                    return int.Parse(DT.Rows[0]["Code"].ToString());
                }
            }
            finally
            {
                DB.Dispose();
            }
            return 0;
        }

        public bool GetData(int PCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from AUTBazRasService where code=" + PCode);
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
    }

    public class JBazRasServices
    {
        public static DataTable GetData()
        {
            return null;
        }
    }

    public class JBazRasServiceTable : ClassLibrary.JTable
    {
        public Int64 BazrasCode;
        public Int64 DriverCode;
        public int BusNumber;
        public int LineNumber;
        public DateTime DateCard;
        public DateTime MoveDate;
        public DateTime RealMoveDate;
        public DateTime Date1;
        public DateTime Date2;
        public DateTime Date3;
        public Int16 BazrasDevice;

        public JBazRasServiceTable()
            : base("AUTBazRasService")
        {

        }
    }

}
