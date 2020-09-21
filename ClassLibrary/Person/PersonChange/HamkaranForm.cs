using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public partial class JHamkaranForm : JBaseForm
    {
        public JHamkaranForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataPerson(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = "";
                if (pCode != 0)
                    WHERE = " AND Code = " + pCode;
                DB.setQuery(@" select Code,Name,TafsiliCode,IDNo,
            case personType 
            when 1 then (Select fatherName From clsPerson where Code=clsAllPerson.Code) 
            when 2 then (Select IDNo From organization where Code=clsAllPerson.Code) 
            end fathername,
            case personType 
            when 1 then (Select ShMeli From clsPerson where Code=clsAllPerson.Code) 
            when 2 then (Select IDNo From organization where Code=clsAllPerson.Code) 
            end ShMeli,
            (Select Name From clsPerson where Code=clsAllPerson.Code) Nam,
            (Select Fam From clsPerson where Code=clsAllPerson.Code) fam           
            from clsAllPerson
            order by Name  " + WHERE);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void JHamkaranForm_Load(object sender, EventArgs e)
        {            
            FillGrid();
        }

        private void FillGrid()
        {
            jdgvInfo.DataSource = GetDataPerson(0);
        }

        int _Code;
        private void jdgvInfo_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (jdgvInfo.SelectedRow != null)
            {
                _Code = Convert.ToInt32(jdgvInfo.SelectedRow["Code"].ToString());
                jdgvTafsili.DataSource = GetDataTableAccounting(jdgvInfo.SelectedRow["Nam"].ToString() , jdgvInfo.SelectedRow["Fam"].ToString());
            }
        }

        private void MenuConfirm_Click(object sender, EventArgs e)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@" select TafsiliCode From ClsAllPerson Where TafsiliCode=" + jdgvTafsili.SelectedRow["Code"].ToString());
                if (DB.Query_DataTable().Rows.Count > 0)
                {
                    JMessages.Error(" یک کد تفصیلی تعریف شده ", "");
                    return;
                }
                JAllPerson tmpPerson = new JAllPerson(_Code);
                tmpPerson.TafsiliCode = Convert.ToInt32(jdgvTafsili.SelectedRow["Code"].ToString());
                if (tmpPerson.Update(DB))
                {
                    JMessages.Information(" ویرایش با موفقیت انجام شد ", "");
                    FillGrid();
                }
                else
                    JMessages.Error(" خطا در ویرایش ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

        public DataTable GetDataTableAccounting(string pNam,string pFam)
        {
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase(Cn.GetConnection("ClassLibrary.JHamkaranForm.Accounting", 0));

            try
            {
                string Sql = @"  SELECT DL.AccNum Code,DL.Title Name            
FROM Acc.DL Dl 
With(NoLock), Acc.DlViews DV With(NoLock)    
WHERE 
Dl.dltype = DV.DlType and 
(DL.DLType in (2,4)) And
RTrim(Ltrim(Replace(Replace(DL.Title,' ',''),N'ی','ي'))) Like
RTrim(Ltrim(Replace(Replace('%@Nam%',' ',''),N'ی','ي'))) 
     And RTrim(Ltrim(Replace(Replace(DL.Title,N'ي','ی'),' ',''))) Like 
     RTrim(Ltrim(Replace(Replace('%@Fam%',N'ي','ی'),' ','')))

--And RTrim(Ltrim(Replace(Replace(DL.Title,' ',''),N'ی','ي'))) Like Replace(N'%@Nam%',' ','')
--And RTrim(Ltrim(Replace(Replace(DL.Title,' ',''),N'ی','ي'))) Like Replace(N'%@Fam%',' ','') 
ORDER BY Title";
                Sql = Sql.Replace("@Nam", pNam);
                Sql= Sql.Replace("@Fam", pFam);
                db.setQuery(Sql);
                return db.Query_DataTable();

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
                Cn.Dispose();
            }
        }
    }
}
