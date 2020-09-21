using ClassLibrary;
using System;
using System.Data;

namespace BusManagment.Line
{
    public class JLineStation : JSystem
    {
        public int Code { get; set; }
        public int LineCode { get; set; }
        public int StationCode { get; set; }
        public bool IsBack { get; set; }
        public double Priority { get; set; }

        public int Insert()
        {
            JLineStationTable AT = new JLineStationTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            //if (Code > 0)
            //Nodes.DataTable.Merge(JLines.GetDataTable(Code));
            return Code;
        }
        public JLineStation()
        {
        }
        //public JLineStation(int pCode)
        //{
        //    if (pCode > 0)
        //        this.GetData(pCode);
        //}
        public bool Update()
        {
            JLineStationTable AT = new JLineStationTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                //Nodes.Refreshdata(Nodes.CurrentNode, JLines.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            JLineStationTable AT = new JLineStationTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                //Nodes.Delete(Nodes.CurrentNode);
                return true;
            }
            else return false;
        }

        public bool DeleteByStationCode(int StationCode)
        {
            JDataBase db = new JDataBase();
            db.setQuery("delete from autlinestation where stationcode = " + StationCode);
            if (db.Query_Execute() >= 0)
                return true;
            else return false;
        }

        public bool PriorityDown(bool IsBack)
        {
            int RowAffected = 0;
            if (Code > 0)
            {
                string sql = string.Format(@"
                                                Declare @Priority2 Float
                                                Declare @Priority1 Float
                                                Declare @Code INT
                                                Declare @CodePreviuse INT
                                                SET @Priority2 = 0 
                                                SET @Priority1 = 0 
                                                SET @CodePreviuse = 0 
                                                SET @Code = {0}

                                                SELECT @Priority2 = ISNULL(Previuse.Priority,0) , @CodePreviuse = Previuse.Code  FROM  [AUTLineStation] [Current] 
                                                CROSS APPLY( Select Top 1 Previuse.[Priority],Previuse.Code From [AUTLineStation] Previuse Where Previuse.[Priority] < [Current].[Priority] AND Previuse.IsBack = '{1}' Order BY Previuse.[Priority] DESC)Previuse
                                                Where [Current].Code = @Code

                                                SELECT @Priority1 = ISNULL(Previuse.Priority,0)  FROM  [AUTLineStation] [Current] 
                                                CROSS APPLY( Select Top 1 Previuse.[Priority] From [AUTLineStation] Previuse Where Previuse.[Priority] < [Current].[Priority] Order BY Previuse.[Priority] DESC)Previuse
                                                Where [Current].Code = @CodePreviuse

                                                Update [AUTLineStation] SET [Priority] = (@Priority2 + @Priority1) / 2.0 Where [AUTLineStation].Code = @Code
                                            ", Code, IsBack);
                JDataBase db = new JDataBase();
                db.setQuery(sql);
                RowAffected = db.Query_Execute();
            }

            return RowAffected > 0;
        }

        public bool PriorityUp(bool IsBack)
        {
            int RowAffected = 0;
            if (Code > 0)
            {
                string sql = string.Format(@"
                                                Declare @Priority2 Float
                                                Declare @Priority1 Float
                                                Declare @Code INT
                                                Declare @CodePreviuse INT
                                                SET @Priority2 = 0 
                                                SET @Priority1 = 0 
                                                SET @CodePreviuse = 0 
                                                SET @Code = {0}

                                                SELECT @Priority2 = ISNULL(Previuse.Priority,0) , @CodePreviuse = Previuse.Code  FROM  [AUTLineStation] [Current] 
                                                CROSS APPLY( Select Top 1 Previuse.[Priority],Previuse.Code From [AUTLineStation] Previuse Where Previuse.[Priority] > [Current].[Priority] AND Previuse.IsBack = '{1}' Order BY Previuse.[Priority] ASC)Previuse
                                                Where [Current].Code = @Code

                                                SELECT @Priority1 = ISNULL(Previuse.Priority,0)  FROM  [AUTLineStation] [Current] 
                                                CROSS APPLY( Select Top 1 Previuse.[Priority] From [AUTLineStation] Previuse Where Previuse.[Priority] > [Current].[Priority] Order BY Previuse.[Priority] ASC)Previuse
                                                Where [Current].Code = @CodePreviuse
                                                if @Priority2 > @Priority1 
                                                    set @Priority1 = @Priority2 + 1
                                                Update [AUTLineStation] SET [Priority] = (@Priority2 + @Priority1) / 2.0 Where [AUTLineStation].Code = @Code
                                            ", Code, IsBack);
                JDataBase db = new JDataBase();
                db.setQuery(sql);
                RowAffected = db.Query_Execute();
            }

            return RowAffected > 0;
        }
    }

    public class JLineStations : JSystem
    {

        public void ListView()
        {
            //JSystem.Nodes.DataTable = GetDataTable(0);
            //JSystem.Nodes.ObjectBase = new JAction("Line", "BusManagment.Line.JLine.GetNode");

            //JAction ActInsertAutombile = new JAction("Insert", "BusManagment.Line.FormLine.ShowDialog");

            //JToolbarNode InsertAutombile = new JToolbarNode();
            //InsertAutombile.Click = ActInsertAutombile;
            //InsertAutombile.Icon = JImageIndex.Add;

            //JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public static void DeleteByLineCode(int pLineCode, JDataBase DB)
        {
            DB.setQuery(@" Delete from AUTLineStation  WHERE LineCode = " + pLineCode.ToString());
            DB.Query_Execute();
        }

        public static DataTable GetLineStations(int pLineCode, bool IsBack)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"
                                    SELECT 	                                    
                                            LS.Code
                                            ,LS.LineCode
                                            ,LS.StationCode
                                            ,S.Name AS 'StationName'
                                            ,L.LineName
                                            ,LS.IsBack
                                            ,S.Lat as 'Lat'
                                            ,S.Lng as 'Lng'
                                            ,LS.CheckPriority
                                    FROM AUTLineStation LS
                                    INNER JOIN AUTStation S ON LS.StationCode = S.Code
                                    INNER JOIN AUTLine L ON LS.LineCode = L.Code
                                ";
                query += " WHERE L.Code = " + pLineCode + " AND IsBack = '" + IsBack.ToString() + "'";
                query += " ORDER BY LS.Priority";
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
