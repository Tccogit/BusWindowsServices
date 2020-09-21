using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class JCitiy : JSubBaseDefine
	{
		public JCitiy()
			: base(JBaseDefine.CityCode)
		{
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class JCities : JSubBaseDefines
	{
		//public JCitiy[] Items;
		public JCities()
			: base(JBaseDefine.CityCode)
		{

		}

		public DataTable GetNewCity(int pLastCode)
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			try
			{
				DB.setQuery(@"SELECT [Code],[name] From [subdefine] 
                    WHERE [bcode]=" + JBaseDefine.CityCode.ToString() +
									" AND Code>" + pLastCode.ToString() +
									" ORDER BY [Code]");
				return DB.Query_DataTable();
			}
			finally
			{
				DB.Dispose();
			}
		}

		public DataTable GetCitiesByState(int state)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("select sd2.code,sd2.name city from subdefine sd1 inner join subdefine sd2 on sd2.parentcode = sd1.Code where sd1.bcode=" + JBaseDefine.ProvinceCode + " and sd1.code=" + state);
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
		}

		public DataTable GetStates()
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("select sd2.code,sd2.name state from subdefine sd2 where sd2.bcode=" + JBaseDefine.ProvinceCode);
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
		}

	}
}
