using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public class JGroupSMSSQL : JSystem
    {
                #region Constructor
        public JGroupSMSSQL()
        {
        }

        public JGroupSMSSQL(int pGroupCode)
        {
            GetData(pGroupCode);
        }

        #endregion

        #region Field
        public int Code { set; get; }
        /// <summary>
        /// کد 
        /// </summary>
        public int GroupCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string SQL { set; get; }
        #endregion

        #region MainMethod
        public int Insert()
        {
            JGroupSMSSQLTable JECCT = new JGroupSMSSQLTable();
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JGroupSMSSQL.Insert"))
                {
                    JECCT.SetValueProperty(this);
                    Code = JECCT.Insert();
                    if (Code > 0)
                    {
                        //Nodes.DataTable.Merge(JEmployeeCostCenters.GetDataTable(JECCT.Code));
                        return Code;
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
        }

        public bool update()
        {
            JGroupSMSSQLTable JECCT = new JGroupSMSSQLTable();
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JGroupSMSSQL.update"))
                {

                    JECCT.SetValueProperty(this);
                    return JECCT.Update();
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Delete()
        {
            JGroupSMSSQLTable JECCT = new JGroupSMSSQLTable();
            try
            {
                if (JPermission.CheckPermission("ClassLibrary.JGroupSMSSQL.Delete"))
                {
                    JECCT.SetValueProperty(this);
                    if (JECCT.Delete())
                    {
                        //Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        #endregion

        #region find&getdata

        public bool GetData(int pGroupCode)
        {
            string Qouery = "select * from ClsSMSGroupSQL where GroupCode=" + pGroupCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #endregion

        #region ShowData&GetNode
        public void ShowDialog()
        {
            JGroupSMSSQLFrom JFF = new JGroupSMSSQLFrom();
                JFF.State = JFormState.Insert;
                if (JFF.ShowDialog() == System.Windows.Forms.DialogResult.Retry)
                    ShowDialog();
        }

        public DataTable ViewPersonByGroup(int pGroupCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            GetData(pGroupCode);
            try
            {
                Db.setQuery(SQL);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #endregion
    }

    public class JGroupSMSSQLTable : JTable
    {
        public JGroupSMSSQLTable()
            : base("ClsSMSGroupSQL")
        {
        }
        /// <summary>
        /// کد گروه
        /// </summary>
        public int GroupCode;
        /// <summary>
        /// 
        /// </summary>
        public string SQL;
    }
}
