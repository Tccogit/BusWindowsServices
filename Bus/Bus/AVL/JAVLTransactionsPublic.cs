using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.AVL
{
    public class JAVLTransactionsPublic
    {
        public static bool AddAVL(TransactionPublic.JTransactionAVLHeader AH, TransactionPublic.JTransactionAVL AVL, Int64 recordNumber, string Header_IMEI, float Header_BusSerial, byte[] Header_Version, ClassLibrary.JDataBase db)
        {
            if (db == null || AH == null || AVL == null)
                return false;
            db.Params.Clear();
            if (db.Params.Count > 0)
            {
                try
                {
                    db.Params.Remove("Longitude");
                    db.Params.Remove("Latitude");
                    db.Params.Remove("Altitude");
                    db.Params.Remove("Speed");
                    db.Params.Remove("Course");
                    db.Params.Remove("EventDate");
                    db.Params.Remove("SimCardCharge");
                    db.Params.Remove("BusSerial");
                    db.Params.Remove("IMEI");
                    db.Params.Remove("Version");
                    db.Params.Remove("BatteryCharge");
                    db.Params.Remove("GpsAnt");
                    db.Params.Remove("GsmAnt");
                    db.Params.Remove("recordNumber");
                    db.Params.Remove("TransactionID");
                    db.Params.Remove("Dir");
                }
                catch
                {
                }
            }

            DateTime dtemp;
            string date = (new DateTime(AH.DATE.Year, AH.DATE.Month, AH.DATE.Day, AVL.Time[0], AVL.Time[1], AVL.Time[2])).ToString("yyyy-MM-dd HH:mm:ss");
            if (DateTime.TryParse(date, out dtemp) & AH.DATE.Year>=2015)
            {


            }
            else
            {
                date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            db.setQuery(@"EXEC SP_InsertAUTAvlTransaction_Zarrin_Save_Just_Point
	                    @Longitude,
	                    @Latitude,
	                    @Altitude,
	                    @Speed,
	                    @Course,
	                    @EventDate,
	                    @SimCardCharge,
	                    @BusSerial,
	                    @IMEI,
	                    @Version,
	                    @BatteryCharge,
	                    @GpsAnt,
	                    @GsmAnt,
	                    @recordNumber,
	                    @TransactionID,
                        @Dir");
            db.AddParams("Longitude", AVL.Lon);
            db.AddParams("Latitude",AVL.Lat);
            db.AddParams("Altitude", AVL.Alt.ToString());
            db.AddParams("Speed", AVL.Speed.ToString());
            db.AddParams("Course", AVL.Cource.ToString());
            db.AddParams("EventDate", date);
            db.AddParams("SimCardCharge", AH.SimCharge.ToString());
            db.AddParams("BusSerial", AH.busSerial.ToString());
            db.AddParams("IMEI", Header_IMEI.ToString());
            db.AddParams("Version", Header_Version);
            db.AddParams("BatteryCharge", AH.Battryvoltvalue.ToString());
            db.AddParams("GpsAnt", AH.GpsAnttena.ToString());
            db.AddParams("GsmAnt", AH.GsmAnttena.ToString());
            db.AddParams("recordNumber", recordNumber.ToString());
            db.AddParams("TransactionID", AVL.transactionid.ToString());
            db.AddParams("Dir", AVL.Dir.ToString());
            db.CommandTimeout = 60;
            if (db.Query_Execute() >= 0)
            {
                db.Params.Clear();
                return true;
            }
            return true;
        }

        public static bool ProcessAVL()
        {
            return false;
        }

        public static bool DistanceMeasurement(ClassLibrary.JDataBase db)
        {
            double Distance = 0;
            try
            {
                if (db.datatable != null)
                    db.datatable.Clear();
                db.setQuery(@"SELECT TOP 1 BusCode,[Date]EDate FROM dbo.AUTDailyAvlPerformanceRportOnBus 
                                WHERE IsProceced = 0 --AND [Date] < Cast(GETDATE() AS Date)
                                GROUP BY BusCode,[Date]
                                ORDER BY BusCode,EDate");
                DataTable Dt = db.Query_DataTable();
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        db.setQuery(@"SELECT EventDate,Latitude,Longitude FROM dbo.AUTAvlTransaction 
                                        WHERE BusCode = " + Dt.Rows[0]["BusCode"].ToString() + @" AND
                                              CAST(EventDate AS DATE) = cast('" + Dt.Rows[0]["EDate"].ToString() + @"' as Date)
                                        GROUP BY EventDate,Latitude,Longitude
                                        ORDER BY EventDate");
                        DataTable DtTransactions = db.Query_DataTable();
                        if (DtTransactions != null)
                        {
                            if (DtTransactions.Rows.Count > 1)
                            {
                                Distance = GetDistance(DtTransactions, MeasureUnits.Kilometers);
                                db.setQuery(@"Update [dbo].[AUTDailyAvlPerformanceRportOnBus] set [IsProceced] = 1,[Distance] = " + Distance.ToString() + @"
                                                        ,[ProcessDate] = getdate()
                                                        where BusCode = " + Dt.Rows[0]["BusCode"].ToString() + @" and [Date] = cast('"
                                                       + Dt.Rows[0]["EDate"].ToString() + @"' as date)");
                                db.Query_Execute();
                                return true;
                            }
                            else
                            {
                                if (DtTransactions.Rows.Count == 1)
                                {
                                    db.setQuery(@"Update [dbo].[AUTDailyAvlPerformanceRportOnBus] set [IsProceced] = 1,[Distance] = 0,[ProcessDate] = getdate()
                                                        where BusCode = " + Dt.Rows[0]["BusCode"].ToString() + @" and [Date] = cast('"
                                                        + Dt.Rows[0]["EDate"].ToString() + @"' as date)");
                                    db.Query_Execute();
                                }
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// The distance type to return the results in.
        /// </summary>
        public enum MeasureUnits { Miles, Kilometers };

        /// <summary>
        /// Returns the distance in miles or kilometers of any two
        /// latitude / longitude points. (Haversine formula)
        /// </summary>
        public static double GetDistance(double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasureUnits units)
        {
            if (latitudeA <= -90 || latitudeA >= 90 || longitudeA <= -180 || longitudeA >= 180
                || latitudeB <= -90 && latitudeB >= 90 || longitudeB <= -180 || longitudeB >= 180)
            {
                throw new ArgumentException(String.Format("Invalid value point coordinates. Points A({0},{1}) B({2},{3}) ",
                                                          latitudeA,
                                                          longitudeA,
                                                          latitudeB,
                                                          longitudeB));
            }


            double R = (units == MeasureUnits.Miles) ? 3960 : 6371;
            double dLat = toRadian(latitudeB - latitudeA);
            double dLon = toRadian(longitudeB - longitudeA);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
            Math.Cos(toRadian(latitudeA)) * Math.Cos(toRadian(latitudeB)) *
            Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;
            return d;
        }

        public static double GetDistance(DataTable PointList, MeasureUnits units)
        {
            double latitudeA = 0, longitudeA = 0, latitudeB = 0, longitudeB = 0, FinalRes = 0;
            for (int i = 0; i < PointList.Rows.Count - 1; i++)
            {
                latitudeA = Convert.ToDouble(PointList.Rows[i]["Latitude"].ToString());
                longitudeA = Convert.ToDouble(PointList.Rows[i]["Longitude"].ToString());
                latitudeB = Convert.ToDouble(PointList.Rows[i + 1]["Latitude"].ToString());
                longitudeB = Convert.ToDouble(PointList.Rows[i + 1]["Longitude"].ToString());
                if (latitudeA <= -90 || latitudeA >= 90 || longitudeA <= -180 || longitudeA >= 180
                    || latitudeB <= -90 && latitudeB >= 90 || longitudeB <= -180 || longitudeB >= 180)
                {
                    throw new ArgumentException(String.Format("Invalid value point coordinates. Points A({0},{1}) B({2},{3}) ",
                                                              latitudeA,
                                                              longitudeA,
                                                              latitudeB,
                                                              longitudeB));
                }


                double R = (units == MeasureUnits.Miles) ? 3960 : 6371;
                double dLat = toRadian(latitudeB - latitudeA);
                double dLon = toRadian(longitudeB - longitudeA);
                double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(toRadian(latitudeA)) * Math.Cos(toRadian(latitudeB)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
                double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
                double d = R * c;
                FinalRes += d;
            }
            return FinalRes;
        }

        /// <summary>
        /// Convert to Radians.
        /// </summary>      
        private static double toRadian(double val)
        {
            return (Math.PI / 180) * val;
        }

        public static DataTable GetDataTable(string buses, DateTime dateA, DateTime dateB)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("select * from AUTAVLTransactionCache Where BusCode in (" + buses + ") and [EventDate]>= CAST('" + dateA.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) and [EventDate]< CAST('" + dateB.ToString("yyyy-MM-dd HH:mm:ss") + "' as datetime) order by [EventDate] AND BusCode in (select MAX(code) From AUTAVLTransactionCache GROUP BY BUSCode)");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            string PermitionSql = " where " + ClassLibrary.JPermission.getObjectSql("BusManagment.AVL.JAVLTransactions.GetWebQuery", "avl.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            return @"SELECT top 100 avl.Code
                      ,ISNULL(a.BUSNumber, 0) as BUSNumber
                      ,avl.Latitude
                      ,avl.Longitude
                      ,avl.Altitude
                      ,avl.EventDate as EventDate
                      ,avl.RecievedDate
                      ,avl.Course
                      ,avl.Speed
                      ,avl.BatteryCharge
                      ,avl.GpsAntenna
                      ,avl.GsmAntenna
                      ,avl.SimCardCharge
                FROM   AUTAvlTransaction avl
                       INNER JOIN AUTBus a
                            ON  avl.BusCode = a.Code
                " + PermitionSql + @"
                ORDER BY avl.Code DESC";
        }
    }
}
