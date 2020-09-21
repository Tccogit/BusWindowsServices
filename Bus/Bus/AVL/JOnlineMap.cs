using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.AVL
{
    public class JOnlineMap
    {
        public static DataTable GetBusDetails(string BusSerial)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery(@"select B.Code, B.BUSNumber, A.Capacity, A.Plaque, PO.Name OwnerName, PO.Fam OwnerFam from AUTBus B
                            left join AUTAutomobile A on A.code = B.CarCode
                            left join AUTBusOwner O on O.BusCode = B.Code
                            left join clsPerson PO on PO.Code = O.CodePerson
                            where BUSNumber = " + BusSerial);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static void UpdateBusLocation(int pBackTime, int lenTime)
        {
            return;
//            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
//            try
//            {
//                db.setQuery(@"
//update AUTBus set
//	           LastTransactionID = AT.TransactionId,
//	           LastLongitude = AT.Longitude,
//	           LastLatitude = AT.Latitude,
//	           LastAltitude = AT.Altitude,
//	           LastCourse = AT.Course,
//	           LastSpeed = AT.Speed,
//	           LastDate = AT.EventDate
//from AUTBus AB inner join 
//(
//    select TOP 1 * from AUTAvlTransaction tt where 
//    EventDate
//    between DATEADD(hour,-1,getdate())
//    and getdate()
//    order by EventDate DESC
//)
//AT
//ON AB.Code = AT.BusCode and ab.LastDate<AT.EventDate");
                
//                db.Query_Execute();
//            }
//            finally
//            {
//                db.Dispose();
//            }
        }
    }
}
