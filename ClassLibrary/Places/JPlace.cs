using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JPlace
    {
        #region Properties
        public int Code { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public int Altitude { get; set; }
        public string Description { get; set; }
        #endregion

        #region Insert, Update, Delete
        public int Insert()
        {
            JPlaceTable jPlaceTable = new JPlaceTable();
            jPlaceTable.SetValueProperty(this);
            return jPlaceTable.Insert();
        }

        public bool Update()
        {
            JPlaceTable jPlaceTable = new JPlaceTable();
            jPlaceTable.SetValueProperty(this);
            return jPlaceTable.Update();
        }

        public bool Delete()
        {
            JPlaceTable jPlaceTable = new JPlaceTable();
            jPlaceTable.SetValueProperty(this);
            return jPlaceTable.Delete();
        }
        #endregion

        #region GetData
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from clsPlaces where Code=" + pCode.ToString());
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
        #endregion
    }

    public class JPlaces
    {
        public DataTable GetDataTable()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * from clsPlaces");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public string GetWebQuery()
        {
            return "Select * from clsPlaces";
        }
    }
}
