using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace ClassLibrary.History
{
    internal class JLogHistory
    {
        public static void Log(string query, DbParameterCollection parameters)
        {
            if ((query.ToLower().Contains("clshistory") && query.ToLower().Contains("jdatabase.jloghistory")) || query.ToLower().Contains("exceptiontable"))
                return;
            if (JMainFrame.CurrentPostCode <= 0 || JMainFrame.CurrentUserCode <= 0)
                return;
            JDataBase db = new JDataBase();
            query = query.ToLower();
            foreach (DbParameter item in parameters)
                query = query.Replace(item.ParameterName.ToLower(), item.Value.ToString());
            db.setQuery(@"INSERT INTO [dbo].[clsHistory]
                           ([ClassName]
                           ,[ObjectCode]
                           ,[ObjectCode1]
                           ,[ObjectCode2]
                           ,[ObjectCode3]
                           ,[Date]
                           ,[UserCode]
                           ,[PostCode]
                           ,[History]
                           ,[AllFields]
                           ,[Description])
                     VALUES
                           (N'JDataBase.JLogHistory'
                           ,0
                           ,0
                           ,0
                           ,0
                           ,getdate()
                           ," + JMainFrame.CurrentUserCode + @"
                           ," + JMainFrame.CurrentPostCode + @"
                           ,@Query
                           ,null
                           ,null)");
            db.AddParams("@Query", query);
            db.Query_Execute(true);
        }
    }
}
