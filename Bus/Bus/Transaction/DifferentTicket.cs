using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusManagment.Transaction
{
    public class JDifferentTicket
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLineNumber">'110,166'</param>
        /// <param name="TicketPrice">'200,300'</param>
        /// <returns></returns>
        public static string MysqlDatabaseWithSqlServerTransactionDifferences(string pLineNumber,string TicketPrice)
        {
            string @Query = @"
select ES.* from ExtractedTickets ES
left join AUTTicketTransaction AT
ON 
ES.EventDate = AT.EventDate AND 
ES.BusSerial = AT.BusNumber AND
ES.PassengerCardSerial = AT.PassengerCardSerial
where AT.Code is NULL
AND cast(right(ES.RecordNumber,4)as int) >0
AND ES.LineNumber in ({0})
AND ES.TicketPrice in ({1})
                ";

            return String.Format(Query, pLineNumber, TicketPrice);
        }
    }
}
