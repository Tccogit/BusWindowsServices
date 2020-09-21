using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JRule: JCore
    {
        public string[] Fields;
        public string[] FieldsLabel;
        public string SQL;

        public JRule(string pSQL)
        {
            SQL = pSQL;
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM (" + SQL + ") AS _RULES WHERE Code=0");
                DB.Query_DataSet();
                Fields = new string[DB.DataSet.Tables[0].Columns.Count];
                for (int i = 0; i < DB.DataSet.Tables[0].Columns.Count; i++)
                {
                    Fields[i] = DB.DataSet.Tables[0].Columns[i].ColumnName;
                }
            }
            finally
            {
                DB.Dispose();
            }
            FieldsLabel = new string[Fields.Length];
            int Count =0;
            int Index = 0;
            foreach (string Field in Fields)
            {
                FieldsLabel[Count] = '[' + Field.Substring(0, 1) + GetNewIndex(Field.Substring(0, 1).ToUpper()[0], Count) + ']';
                Count++;
            }
        }

        private int GetNewIndex(char pCh , int pCount)
        {
            int Counter = 1;
            for (int i = 0; i < pCount; i++)
                if (FieldsLabel[i].Substring(1, 1).ToUpper()[0] == pCh)
                    Counter++;
            return Counter;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Formule">[A1]>2 AND ([B2] LIKE "%ALI%" OR [G4] IS NULL)</param>
        /// <returns></returns>
        public string Decode(string pFormule)
        {
            int Counter=0;
            foreach (string Field in FieldsLabel)
            {
                pFormule = pFormule.Replace(Field, Fields[Counter++]);
            }
            return pFormule;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Formule">[Code]>1 AND [FirstName] LIKE "%ALI%"</param>
        /// <returns></returns>
        public string Encode(string pFormule)
        {
            int Counter = 0;
            foreach (string Field in Fields)
            {
                pFormule = pFormule.Replace(Field, FieldsLabel[Counter++]);
            }
            return pFormule;
        }

        public bool SpellCheck(string Formule)
        {
            return true;
        }

        public bool Check(string pFormule)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(SQL + " WHERE " + pFormule);
                return DB.Query_DataReader();
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
    }
}
