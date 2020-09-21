using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.Station
{
    public class JStation : JSystem
    {
        #region Properties
        public int Code { get; set; }
        public int StationTypeCode { get; set; }
        public string Name { get; set; }
        public int ZoneCode { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public bool isTerminal { get; set; }
        public string Address { get; set; }
        public string StationCode { get; set; }
        public int Radius { get; set; }
        public int Angle { get; set; }
        public Int64 IMEI { get; set; }
        public int MinSpeed { get; set; }
        public int ImageCode { get; set; }

        #endregion

        public JStation()
        {
        }
        public JStation(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Station.JStation.Insert"))
                return 0;
            StationTable AT = new StationTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JStations.GetDataTable(Code));
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JStation", Code, 0, 0, 0, "ثبت ایستگاه", "", 0);
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Station.JStation.Update"))
                return false;
            StationTable AT = new StationTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JStations.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JStation", AT.Code, 0, 0, 0, "ویرایش ایستگاه", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool Delete(bool isWeb = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Station.JStation.Delete"))
                return false;
            StationTable AT = new StationTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("BusManagment.JStation", AT.Code, 0, 0, 0, "حذف ایستگاه", "", 0);
                return true;
            }
            else return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTStation where code=" + pCode.ToString());
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
            Node.Name = "Station";
            Node.MouseClickAction = new JAction("Station", "BusManagment.Station.JStations.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.Station.JStation");
            Node.MouseDBClickAction = new JAction("EditStation", "BusManagment.Station.JStationForm.ShowDialog", null, new object[] { (int)pRow["Code"] });

            int code = (int)pRow["Code"];
            JPopupMenu pMenu = new JPopupMenu("BusManagment.Bus.JBuses", Node.Code);
            JAction deleteAction = new JAction("delete...", "BusManagment.Station.JStationForm.Delete", null, new object[] { code });
            JAction editAction = new JAction("Edit...", "BusManagment.Station.JStationForm.ShowDialog", null, new object[] { code });
            JAction newAction = new JAction("new...", "BusManagment.Station.JStationForm.ShowDialog", null, null);

            pMenu.Insert(deleteAction);
            pMenu.Insert(editAction);
            pMenu.Insert(newAction);

            Node.Popup = pMenu;
            return Node;

            //AUTOMOBILE.Automobile.JAutomobileForm AForm = new Automobile.JAutomobileForm((int)pRow["Code"]);
            //AForm.ShowDialog();
            //return null;
        }

        public bool FindDuplicate()
        {
            JDataBase DB = new JDataBase();
            DataTable dt = new DataTable();
            string query = @"SELECT * FROM AUTStation WHERE Code <> " + Code + " AND IMEI = " + IMEI;
            DB.setQuery(query);
            dt = DB.Query_DataTable();
            DB.Dispose();
            return dt.Rows.Count > 0;
        }
    }

    public class JStations : JSystem
    {

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Price", "BusManagment.Station.JStation.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Station.JStationForm.ShowDialog");

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public static string GetWebQuery()
        {
            return @"SELECT  TOP 100 percent 
	                    S.[Code]
	                    ,S.Name
	                    ,Z.Name AS 'ZoneName'
					    ,STUFF(
						     (SELECT DISTINCT ',' + cast(LineNumber as nvarchar)
						      FROM AUTLineStation
						      inner join AUTLine l on l.Code = LineCode
						      WHERE StationCode = S.Code
						      FOR XML PATH ('')
					    ), 1, 1, '') Line
                        ,s.StationCode
					    , (Select Name from subdefine Where Code = S.StationTypeCode ) StationType
                        ,case IsTerminal when 1 then N'بلی' else N'خیر' end as IsTerminal
					    ,Cast(S.Lat AS nvarchar(50)) Lat,Cast(S.Lng AS nvarchar(50)) Lng ,S.[Address]
					    , properties.سایبان,properties.تابلو,properties.صندلی
                        , S.IMEI 'IMEI', S.LastRTPISRequest
                        ,ISNULL((select sum( PassCount) from autlineStation where StationCode = S.code),0) PassCount
                    FROM AUTStation S
                    INNER JOIN AUTZone Z ON S.ZoneCode = Z.Code
				    Left JOIN [Propperty_ClassName_BusManagment.Station_1000002] properties ON properties .ObjectCode = S.Code
				    group by  S.[Code]
	                    ,S.Name ,Z.Name, s.StationCode, S.StationTypeCode,IsTerminal, S.Lat, S.Lng,S.[Address]
					    , properties.سایبان,properties.تابلو,properties.صندلی, S.IMEI, S.LastRTPISRequest";
        }

        public static DataTable GetDataTable(int pCode = 0)
        {
            if (!JPermission.CheckPermission("BusManagment.Station.JStations.GetDataTable"))
                return null;
            JDataBase DB = new JDataBase();
            try
            {

                string query = @"
                                    SELECT 
	                                    S.[Code]
	                                    ,S.Name
	                                    ,Z.Name AS 'ZoneName',StationCode
										, (Select Name from subdefine Where Code = S.StationTypeCode ) StationType
								        ,Cast(S.Lat AS nvarchar(50)) Lat,Cast(S.Lng AS nvarchar(50)) Lng ,S.[Address]
										, properties .*
                                    FROM AUTStation S
                                    INNER JOIN AUTZone Z ON S.ZoneCode = Z.Code
									Left JOIN [Propperty_ClassName_BusManagment.Station_1000002] properties ON properties .ObjectCode = S.Code 
                                ";
                if (pCode > 0)
                    query += " WHERE  S.Code = " + pCode;
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

        public static DataTable GetWebDataTable(int pCode, int QueryType = 0)
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Station.JStations.GetWebDataTable", "Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            JDataBase DB = new JDataBase();
            try
            {
                string query = "";
                if (QueryType == 0)
                    query = @"SELECT 
	                                    S.[Code]
	                                    ,convert(nvarchar,S.[Code])+' -> '+S.[name] as [StationName]
	                                    ,Z.Name AS 'ZoneName',StationCode
										, (Select Name from subdefine Where Code = S.StationTypeCode ) StationType
								        ,Cast(S.Lat AS nvarchar(50)) Lat,Cast(S.Lng AS nvarchar(50)) Lng ,S.[Address]
										, properties .*
                                    FROM AUTStation S
                                    INNER JOIN AUTZone Z ON S.ZoneCode = Z.Code
									Left JOIN [Propperty_ClassName_BusManagment.Station_1000002] properties ON properties .ObjectCode = S.Code
                                    where Lat<>0 and Lat between -90 and 90  and Lng<>0 and Lng between -90 and 90";
                else
                    query = @"SELECT 
	                                    S.[Code]
	                                    ,Z.Name AS 'ZoneName',StationCode
										, (Select Name from subdefine Where Code = S.StationTypeCode ) StationType
								        ,Cast(S.Lat AS nvarchar(50)) Lat,Cast(S.Lng AS nvarchar(50)) Lng ,S.[Address]
										, properties .*
                                    FROM AUTStation S
                                    INNER JOIN AUTZone Z ON S.ZoneCode = Z.Code
									Left JOIN [Propperty_ClassName_BusManagment.Station_1000002] properties ON properties .ObjectCode = S.Code
                                    where Lat<>0 and Lat between -90 and 90  and Lng<>0 and Lng between -90 and 90";
                if (pCode > 0)
                {
                    query += " and S.[Code] = " + pCode + PermitionSql + "Order by  S.[Code]";
                }
                else
                {
                    query += " and 1 = 1 " + PermitionSql + " Order by  S.[Code]";
                }
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

        public static DataTable GetDataTableForComboBox(int pCode = 0,bool QueryType = false)
        {
            if (!JPermission.CheckPermission("BusManagment.Station.JStations.GetDataTable"))
                return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = "";
                if (QueryType == false)
                {
                    query = @"
                                    
                SELECT 
	                                                    S.[Code]
	                                                    ,case when S.IMEI > 0 then concat(S.Name, ' ', N'(تابلو)') else S.Name end Name
	                                                    ,Z.Name AS 'ZoneName',StationCode,
                                                        isnull(cast(S.name as nvarchar(max)),N'نامشخص')+' ( '+
										
										                (select ss.LineCode1 from(SELECT DISTINCT LineCode1,als1.StationCode
                FROM [dbo].[AUTLineStation] als1
                CROSS APPLY (select (select cast(LineNumber as varchar) from autline where code = als2.LineCode) + ',' 
                              FROM [dbo].[AUTLineStation] als2
                              WHERE als1.StationCode = als2.StationCode 
                              FOR XML PATH('') ) D ( LineCode1 ))ss where ss.StationCode = S.Code)
										
										                +' ) ' as NameWCode
										                , (Select Name from subdefine Where Code = S.StationTypeCode ) StationType
								                        ,Cast(S.Lat AS nvarchar(50)) Lat,Cast(S.Lng AS nvarchar(50)) Lng ,S.[Address]
										                , properties .*
                                                    FROM AUTStation S
                                                    INNER JOIN AUTZone Z ON S.ZoneCode = Z.Code
									                Left JOIN [Propperty_ClassName_BusManagment.Station_1000002] properties ON properties .ObjectCode = S.Code
                                ";
                }
                else {
                    query = @" select Code,StationCode,Name,ZoneCode,Lat,Lng,IsTerminal from AutStation S ";
                }

                if (pCode > 0)
                    query += " WHERE  S.Code = " + pCode;
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

