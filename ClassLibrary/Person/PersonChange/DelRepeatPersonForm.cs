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
    public partial class DelRepeatPersonForm : Globals.JBaseForm
    {
        JPersonChange pChange = new JPersonChange();
        public DelRepeatPersonForm()
        {
            InitializeComponent();
            SetFieldsList();
            LBAllFields.gridEX1.MouseDoubleClick += new MouseEventHandler(LBAllFields_MouseDoubleClick);
            LBPersonFields.gridEX1.MouseDoubleClick += new MouseEventHandler(LBPersonFields_MouseDoubleClick);
        }

        void LBAllFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LBAllFields.gridEX1.SelectedItems.Count > 0)
            {
                string Table = LBAllFields.gridEX1.SelectedItems[0].GetRow().Cells["ComplateTable"].Text.Split(new char[] { '@' })[0];
                ShowTable(Table);
            }
        }

        void LBPersonFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LBPersonFields.gridEX1.SelectedItems.Count > 0)
            {
                string Table = LBPersonFields.gridEX1.SelectedItems[0].GetRow().Cells["SlaveTableName"].Text.Split(new char[] { '@' })[0];
                ShowTable(Table);
            }
        }

        private void ShowTable(string Table)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@" select * from " + Table);
                DataTable DT = DB.Query_DataTable();
                LBShowData.DataSource = DT;
            }
            catch
            {
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void chName_CheckedChanged(object sender, EventArgs e)
        {
            //if (!chName.Checked || !chShMelli.Checked )
                //return;
           // grdAllPerson.DataSource = pChange.RepeatPersonA(chName.Checked, chFatherName.Checked, chShSh.Checked, chShMelli.Checked);

        }

        private void grdAllPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //grdRepeatPerson.DataSource = pChange.RepeatPersonB(grdAllPerson.SelectedRow.Row, chName.Checked, chFatherName.Checked, chShSh.Checked, chShMelli.Checked);
        }

        private void DelRepeatPersonForm_Shown(object sender, EventArgs e)
        {
            chName.Checked = false;
            chName.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("آیا میخواهید بقیه اشخاص بجز شخص انتخاب شده حذف شود؟", "حذف") != DialogResult.Yes)
                return;
            int selectedCode = (int)grdRepeatPerson.CurrentRow.Cells["Code"].Value;
            foreach (DataRow row in ((DataTable)grdRepeatPerson.DataSource).Rows)
            {
                int pCode = (int)row["Code"];
                if (pCode == selectedCode)
                    continue;
                JPersonChange pChange = new JPersonChange();
                    pChange.Changes(pCode, selectedCode);
            }
        }

        private void grdRepeatPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedCode = (int)grdRepeatPerson.CurrentRow.Cells["Code"].Value;
            JPerson person = new JPerson(selectedCode);
            person.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdAllPerson.SelectedRow != null)
            {
                int selectedCode = (int)grdRepeatPerson.CurrentRow.Cells["Code"].Value;
                JPerson person = new JPerson(selectedCode);
                person.ShowDialog();
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (grdRepeatPerson.CurrentRow != null)
            {
                int selectedCode = (int)grdRepeatPerson.CurrentRow.Cells["Code"].Value;
                JPerson person = new JPerson(selectedCode);
                person.ShowDialog();
            }
        }

        private void grdAllPerson_OnRowSelectionClick(object Sender, EventArgs e)
        {
            if (grdAllPerson.SelectedRow == null)
                return;
            grdRepeatPerson.DataSource = pChange.RepeatPersonB(grdAllPerson.SelectedRow.Row, chName.Checked, chFatherName.Checked, chShSh.Checked, chShMelli.Checked);

        }

        private void SetFieldsList()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"
select * from 
(
SELECT CS.TABLE_NAME+'@'+COLUMN_NAME ComplateTable FROM information_schema.tables TS
inner join INFORMATION_SCHEMA.COLUMNS CS
on TS.TABLE_NAME=CS.TABLE_NAME
where TABLE_TYPE = 'BASE TABLE'
and 
	LOWER(CS.TABLE_NAME+'@'+COLUMN_NAME)
	not in (
		select LOWER(ltrim(rtrim(SlaveTableName))) from ClsRelationTables)
) as CS		
order by CS.ComplateTable
");
                DataTable DT = DB.Query_DataTable();
                LBAllFields.DataSource = DT;

                DB.setQuery("SELECT * FROM ClsRelationTables where MasterTableName='ClsPerson@Code'");
                DT = DB.Query_DataTable();
                LBPersonFields.DataSource = DT;

            }
            catch
            {
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
//            JDataBase db = new JDataBase();
//            JPersonChange pChange = new JPersonChange();
//            db.setQuery(@"select A.Code CodeA,B.Code CodeB,A.Name + ' ' + A.Fam,B.Name + ' ' + B.Fam from clsPerson A inner join clsPerson B on  substring(cast(A.Code as nvarchar),2,LEN(cast(A.Code as nvarchar)-1))= 
//substring(cast(B.Code as nvarchar),2,LEN(cast(B.Code as nvarchar)-1)) And A.Code<>B.Code
//And (A.Name + ' ' + A.Fam)=(B.Name + ' ' + B.Fam)
//And A.Code > 20000000");
//            foreach (DataRow dr in db.Query_DataTable().Rows)
//                pChange.Changes((int)dr["CodeA"], (int)dr["CodeB"]);

            if (chName.Checked && chFatherName.Checked && chShSh.Checked)
            {
                int count = 0;
                DataTable DTPersons = (grdAllPerson.DataSource as DataTable);
                foreach (DataRow DR in DTPersons.Rows)
                {
                    count++;
                    DataTable DTPerson = pChange.RepeatPersonB(DR, chName.Checked, chFatherName.Checked, chShSh.Checked, chShMelli.Checked);
                    if (DTPerson.Rows.Count >= 2)
                    {
                        JPerson PS1 = new JPerson((int)DTPerson.Rows[0]["Code"]);
                        JPerson PS2 = new JPerson((int)DTPerson.Rows[1]["Code"]);
                        if (PS1._SharePCode == 0)
                        {
                            pChange.Changes((int)DTPerson.Rows[0]["Code"], (int)DTPerson.Rows[1]["Code"]);
                        }
                        else
                        {
                            if (PS2._SharePCode == 0)
                            {
                                pChange.Changes((int)DTPerson.Rows[1]["Code"], (int)DTPerson.Rows[0]["Code"]);
                            }
                            else
                            {
                                if (PS2._SharePCode == 0 && PS1._SharePCode == 0)
                                {
                                    pChange.Changes((int)DTPerson.Rows[0]["Code"], (int)DTPerson.Rows[1]["Code"]);
                                }
                            }
                        }

                    }

                }
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (JMainFrame.CurrentPostCode==1 && LBAllFields.gridEX1.SelectedItems.Count > 0)
            {
                ClassLibrary.Person.PersonChange.jRelationTables RT = new ClassLibrary.Person.PersonChange.jRelationTables();
                RT.MasterTableName = "ClsPerson@Code";
                RT.SlaveTableName = LBAllFields.gridEX1.SelectedItems[0].GetRow().Cells["ComplateTable"].Text;
                int Code = RT.Insert();
                (LBAllFields.DataSource as DataTable).Rows.Remove(((DataRowView)LBAllFields.gridEX1.SelectedItems[0].GetRow().DataRow).Row);
                (LBAllFields.DataSource as DataTable).AcceptChanges();

                DataRow DR = (LBPersonFields.DataSource as DataTable).NewRow();
                DR["Code"] = Code;
                DR["MasterTableName"] = "ClsPerson@Code";
                DR["SlaveTableName"] = RT.SlaveTableName;
                (LBPersonFields.DataSource as DataTable).Rows.Add(DR);
                (LBPersonFields.DataSource as DataTable).AcceptChanges();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (JMainFrame.CurrentPostCode == 1 && LBPersonFields.gridEX1.SelectedItems.Count > 0)
            {
                ClassLibrary.Person.PersonChange.jRelationTables RT = new ClassLibrary.Person.PersonChange.jRelationTables();
                RT.Code = (int)LBPersonFields.gridEX1.SelectedItems[0].GetRow().Cells["Code"].Value;
                RT.MasterTableName = "ClsPerson@Code";
                RT.SlaveTableName = LBPersonFields.gridEX1.SelectedItems[0].GetRow().Cells["SlaveTableName"].Text;
                RT.Delete();

                (LBPersonFields.DataSource as DataTable).Rows.Remove(((DataRowView)LBPersonFields.gridEX1.SelectedItems[0].GetRow().DataRow).Row);
                (LBPersonFields.DataSource as DataTable).AcceptChanges();

                DataRow DR = (LBAllFields.DataSource as DataTable).NewRow();
                DR["ComplateTable"] = RT.SlaveTableName;
                (LBAllFields.DataSource as DataTable).Rows.Add(DR);
                (LBAllFields.DataSource as DataTable).AcceptChanges();
            }

        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
        }

		private void button2_Click(object sender, EventArgs e)
		{
			JDataBase db = new JDataBase();
			try
			{
				do
				{
					db.setQuery(@"select min(Code) minCode,Max(Code) maxCode,Name,Fam,FatherName,ShSh,count(*) c from clsPerson
							group by Name,Fam,FatherName,ShSh
							having Count(*) > 1
							order by c desc
						");
					DataTable dt = db.Query_DataTable();
					if (dt.Rows.Count == 0)
						return;
					JPersonChange pChange = new JPersonChange();
					pChange.Changes((int)dt.Rows[0]["minCode"], (int)dt.Rows[0]["maxCode"]);
				}
				while (true);
			}
			finally
			{
				db.Dispose();
			}
		}

    }
}
