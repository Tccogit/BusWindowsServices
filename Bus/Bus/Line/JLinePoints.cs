using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Line
{
    public class JLinePoint
    {
        #region Properties
        public int Code { get; set; }
        public int LineCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int OrderNo { get; set; }
        public int PathType { get; set; }
        #endregion
    }
    public class JLinePoints
    {
        public static bool UpdateLinePoints(int LineCode, List<JLinePoint> linePoints, bool isAutoOrderNo, int PathType = 0)
        {

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                int order = 1;
                db.beginTransaction("linePoints");
                db.setQuery("Delete From AUTFleetLinePoints Where LineCode = " + LineCode + "And PathType = " + PathType);
                db.Query_Execute();
                string sql = @"declare @points table([LineCode] [int],
	                            [Latitude] [decimal](18, 14),
	                            [Longitude] [decimal](18, 14),
	                            [OrderNo] [smallint],
	                            [PathType] [tinyint],
								[DistanceLastPoint] [float] NOT NULL DEFAULT ((0)))" + " \r\n";
                foreach (JLinePoint point in linePoints)
                {
                    sql += @"INSERT INTO @points(LineCode,Latitude,Longitude,OrderNo,PathType) VALUES
                             (" + point.LineCode + ", " + point.Latitude + ", " + point.Longitude + ", " + (isAutoOrderNo == true ? order : point.OrderNo) + ", " + PathType + ") \r\n";
                    order++;
                }
                sql += @"
                    update point2 set [DistanceLastPoint] = dbo.GetDistance2Points(point1.Longitude, point1.Latitude, point2.Longitude, point2.Latitude)
                    from @points point2
                    inner join @points point1 on point1.OrderNo = point2.OrderNo - 1

                    insert into AUTFleetLinePoints
                    select [LineCode], [Latitude], [Longitude], [OrderNo], [PathType], sum([DistanceLastPoint]) over (order by orderno) from @points";
                db.setQuery(sql);
                if (db.Query_Execute() >= 0)
                {
                    db.Commit();
                    return true;
                }
                db.Rollback("linePoints");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static bool DeleteLinePoints(int LineCode, int PathType = 0)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                int order = 1;
                db.beginTransaction("linePointsDel");
                db.setQuery("Delete From AUTFleetLinePoints Where LineCode = " + LineCode + " And PathType = " + PathType);
                if (db.Query_Execute() >= 0)
                {
                    db.Commit();
                    return true;
                }
                db.Rollback("linePointsDel");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetDataTable(int lineCode = 0, int PathType = 0)
        {
            string where = "";
            if (lineCode > 0)
                where = " Where LineCode=" + lineCode + " and PathType = " + PathType;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * From AUTFleetLinePoints " + where + " Order By OrderNo ASC");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public static DataTable GetDataTableNew(int lineCode = 0, int PathType = 0)
        {
            string where = "";
            if (lineCode > 0)
                where = "and  als.LineCode=" + lineCode + " and IsBack = " + PathType;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"select ats.Lat latitude,ats.Lng longitude from autlinestation als 
                             left join autstation ats on als.StationCode = ats.Code
                             where linecode not in(select LineCode from AUTFleetLinePoints where pathtype="+PathType+"+1) " + where+ " Order By Priority");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
