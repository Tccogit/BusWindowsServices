using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.Price
{
    public class JPrice
    {
        public int Code { get; set; }
        public int LineCode { get; set; }
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Enddate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Insert(JDataBase db = null)
        {
            PriceTable AT = new PriceTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);

            return Code;
        }

        public JPrice()
        {

        }

        public JPrice(int pCode)
        {
            this.GetData(pCode);
        }

        public bool Update()
        {
            PriceTable AT = new PriceTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete()
        {
            PriceTable AT = new PriceTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPrice where code=" + pCode.ToString());
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

        public bool GetDataLineCode(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTPrice where LineCode=" + pCode.ToString());
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

        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "Price";
            Node.MouseClickAction = new JAction("Price", "BusManagment.Price.JPrices.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.Price.JPrice");
            Node.MouseDBClickAction = new JAction("EditPrice", "BusManagment.Price.JPriceForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            return Node;

            //AUTOMOBILE.Automobile.JAutomobileForm AForm = new Automobile.JAutomobileForm((int)pRow["Code"]);
            //AForm.ShowDialog();
            //return null;
        }
    }

    public class JPrices
    {

        public static void DeleteByLineCode(int pLineCode,JDataBase DB)
        {
                DB.setQuery(@" Delete from AUTPrice  WHERE LineCode = " + pLineCode.ToString());
                DB.Query_Execute();
        }

        public DataTable GetWebPrices(int pLineCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select ROW_NUMBER() over (order by code desc) as N'ردیف' , Price as N'مبلغ'
                    ,(Select Fa_Date From  StaticDates Where  En_Date = StartDate) as N'تاریخ شروع'
                    ,(Select Fa_Date From  StaticDates Where  En_Date = EndDate )as N'تاریخ پایان'
                    ,Left( StartTime, 5) as N'ساعت شروع',Left( EndTime , 5) as N'ساعت پایان' 
                     from AUTPrice WHERE LineCode = " + pLineCode.ToString());
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

        public DataTable GetPrices(int pLineCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@" select Code , Price 
                    ,(Select Fa_Date From  StaticDates Where  En_Date = StartDate)StartDate
                    ,(Select Fa_Date From  StaticDates Where  En_Date = EndDate )EndDate
                    ,Left( StartTime, 5) StartTime,Left( EndTime , 5) EndTime 
                     from AUTPrice WHERE LineCode = " + pLineCode.ToString());
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

