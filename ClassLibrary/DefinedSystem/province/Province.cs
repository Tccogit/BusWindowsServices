using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class JProvince : JSubBaseDefine
    {
        public JProvince()
            : base(JBaseDefine.ProvinceCode)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JProvinces : JSubBaseDefines
    {
        public JProvince[] Items;
        public JProvinces()
            : base(JBaseDefine.ProvinceCode)
        {

        }
//        public System.Data.DataTable GetProvinces()
//        {
//            JDataBase db = JGlobal.MainFrame.GetDBO();
//            try
//            {
//                string Query = @"  SELECT   [Code]
//                                  ,[bcode]
//                                  ,[name]
//                                  ,[parentcode]
//                                  ,[TempCode]
//                                 FROM [ERP_Sepad].[dbo].[subdefine]
//                                    WHERE bcode=3
//                                    ORDER BY  parentcode DESC,bcode ";

//                db.setQuery(Query);
//                return db.Query_DataTable();
//            }
//            catch (Exception ex)
//            {
//                JSystem.Except.AddException(ex);
//                return null;
//            }
//            finally
//            {
//                db.Dispose();
//            }
//        }
    }
}
