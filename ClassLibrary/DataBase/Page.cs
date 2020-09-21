using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    public class JPage: JSystem
    {


        public long Start;
        public long Count;
        public string Condition;
        public string BaseSQL;
        public string Ordered;

        public JPage()
        {
        }


        public string PagingSQL()
        {
            try
            {
                string _SQL;
                _SQL = SetCondition();

                if (Ordered == null || Ordered.Length == 0)
                    Ordered = "Code";
                string PageSQL = @"
SELECT * FROM
(
	SELECT ROW_NUMBER() OVER (ORDER BY [@Order@]) AS [row_number],a.* FROM
	(
    	@Table@
	)as a
)
AS a WHERE [row_number] BETWEEN @Start@ AND @End@";
                PageSQL = PageSQL.Replace("@Table@", _SQL);
                PageSQL = PageSQL.Replace("@Start@", Start.ToString());
                PageSQL = PageSQL.Replace("@End@", (Start + Count - 1).ToString());
                PageSQL = PageSQL.Replace("@Order@", Ordered.Trim().Replace("[","").Replace("]",""));

                return PageSQL;
            }
            catch
            {
                return BaseSQL;
            }
            finally
            {
            }
        }

        private string DeleteOrder()
        {
            string _SQL;
            int i = BaseSQL.IndexOf("order by", StringComparison.OrdinalIgnoreCase);

            if (i > 0 && BaseSQL.IndexOf("from", i, StringComparison.OrdinalIgnoreCase) == -1)
            {
                _SQL = BaseSQL.Remove(i);
            }
            else
            {
                _SQL = BaseSQL;
            }
            return _SQL;
        }

        public string SetCondition()
        {
            string _SQL = DeleteOrder();
            try
            {
                string PageSQL = @"
                    select * from
                    (
                        @Table@
                    ) as a @Where@";
                if (Condition != null && Condition.Length > 0)
                {
                    PageSQL = PageSQL.Replace("@Where@", " WHERE " + Condition);
                }
                else
                {
                    PageSQL = PageSQL.Replace("@Where@", "");
                }
                PageSQL = PageSQL.Replace("@Table@", _SQL);

                return PageSQL;
            }
            catch
            {
                return BaseSQL;
            }
            finally
            {
            }
        }

        public void NextPage()
        {
            Start += Count;
        }

        public void PreviousPage()
        {
            if (Start < Count)
            {
                Start = 1;
            }
            else
                if (Start > 1)
                {
                    Start -= Count;
                }

        }

        public JDataTable RefreshPage ()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string sql = PagingSQL();
                DB.setQuery(sql);
                JDataTable DT = (JDataTable)DB.Query_DataTable();
				if (DT == null)
				{
					DB.setQuery(BaseSQL);
					DT = (JDataTable)DB.Query_DataTable();
				}
                DT.Paging = this;
                return DT;
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
