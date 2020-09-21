using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable()]
    public class JDataTable: System.Data.DataTable
    {

        public string ClassName;
        public string ObjectCode;
        public string BaseSQL;
        public JPage Paging;

        public JDataTable()
        {
        }
        public JDataTable(string tableName)
            : base(tableName)
        {
		}
        protected JDataTable(SerializationInfo info, StreamingContext context)
            :base(info,context)
        {
		}
        public JDataTable(string tableName, string tableNamespace)
            :base(tableName,tableNamespace)
        {
        }

        public void RemoveDuplicateRows(string colName)
        {
            System.Collections.Hashtable hTable = new System.Collections.Hashtable();
            System.Collections.ArrayList duplicateList = new System.Collections.ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (System.Data.DataRow drow in this.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (System.Data.DataRow dRow in duplicateList)
                this.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
        }

        public void Tidy(string colName, string NewcolName, int Len)
        {
            try
            {
                if (this.Columns.IndexOf(NewcolName) < 0)
                {
                    this.Columns.Add(NewcolName);
                }
                foreach (System.Data.DataRow drow in this.Rows)
                {
                    if (drow[colName].ToString().Length > Len)
                        drow[NewcolName] = drow[colName].ToString().Remove(Len, drow[colName].ToString().Length - Len) + "...";
                    else
                        drow[NewcolName] = drow[colName].ToString();

                }
            }
            catch
            {
            }
            this.AcceptChanges();
        }
    }
}
