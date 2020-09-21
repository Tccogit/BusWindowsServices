using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;

namespace ClassLibrary
{
    public class JHistory : JCore
    {
        /// <summary>
        /// کد سابقه
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// کد شیء
        /// </summary>
        public int ObjectCode { get; set; }
        public int ObjectCode1 { get; set; }
        public int ObjectCode2 { get; set; }
        public int ObjectCode3 { get; set; }
        /// <summary>
        /// تاریخ و زمان تغییرات
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// کد کاربر
        /// </summary>
        public int UserCode { get; set; }
        /// <summary>
        /// پست سازمانی کاربر
        /// </summary>
        public int PostCode { get; set; }
        /// <summary>
        /// متن مربوط به سابقه
        /// </summary>
        public string History { get; set; }
        /// <summary>
        /// در صورتی این کل فیلدها بصورت ایکس ام ال ثبت شود، این فیلد مقدار صحیح میگیرد
        /// </summary>
        public bool AllFields { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        public JHistory()
        {

        }

        public JHistory(string pClassName)
        {
            ClassName = pClassName;
        }

        public JHistory(object OClass)
        {
            ClassName = OClass.GetType().FullName;
        }

        public bool Save()
        {
            return Save(ClassName, ObjectCode, ObjectCode1, ObjectCode2, ObjectCode3, History, Description, 999);
        }
        public bool Save(string pClassName, int pObjectCode, int pObjectCode1, int pObjectCode2, int pObjectCode3, string pHistory, string pDesc, int S)
        {
            if (S != 999)
                return true; //then all below will be ignored

			ArchivedDocuments.JArchiveDataBase db = new ArchivedDocuments.JArchiveDataBase();
			try
			{
				int userCode = 1, PostCode = 1;
				if (JMainFrame.CurrentUserCode != null & JMainFrame.CurrentUserCode > 1)
				{
					userCode = JMainFrame.CurrentUserCode;
				}
				if (JMainFrame.CurrentPostCode != null & JMainFrame.CurrentPostCode > 1)
				{
					PostCode = JMainFrame.CurrentPostCode;
				}

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
                           (N'" + pClassName + @"'
                           ," + pObjectCode + @"
                           ," + pObjectCode1 + @"
                           ," + pObjectCode2 + @"
                           ," + pObjectCode3 + @"
                           ,getdate()
                           ," + userCode + @"
                           ," + PostCode + @"
                           ,@pHistory
                           ,null
                           ,N'd" + pDesc.Replace("'", "''") + @"')");
                db.AddParams("@pHistory", pHistory);
                db.Query_Execute(false, false);
				return true;
			}
			catch
			{
				return false;
			}
			finally
			{
				db.Dispose();
			}
        }


        /// <summary>
        /// ذخیره سابقه همراه با توضیحات
        /// </summary>
        /// <param name="pTB"></param>
        /// <param name="pObjectCode"></param>
        /// <param name="pDesc"></param>
        /// <returns></returns>
        public bool Save(string pClassName, int pObjectCode, int pObjectCode1, int pObjectCode2, int pObjectCode3, string pHistory, string pDesc, JDataBase pDB)
        {
            return Save(pClassName, pObjectCode, pObjectCode1, pObjectCode2, pObjectCode3, pHistory, ClassLibrary.JMainFrame.CurrentUserCode, ClassLibrary.JMainFrame.CurrentPostCode, pDesc, pDB);
        }
        public bool Save(string pClassName, int pObjectCode, int pObjectCode1, int pObjectCode2, int pObjectCode3, string pHistory, int pUserCode, int pPostCode, string pDesc, JDataBase pDB)
        {
            return true; //then all below will be ignored

            // Set Properties
            ClassName = pClassName;
            ObjectCode = pObjectCode;
            ObjectCode1 = pObjectCode1;
            ObjectCode2 = pObjectCode2;
            ObjectCode3 = pObjectCode3;
            History = pHistory;
            UserCode = pUserCode;
            PostCode = pPostCode;
            Description = pDesc;

            ArchivedDocuments.JArchiveDataBase adb = new ArchivedDocuments.JArchiveDataBase();

            JHistoryTable JHT = new JHistoryTable();
            JHT.SetValueProperty(this);
            if (pDB == null)
                JHT.Insert(0,(JDataBase)adb,true);
            else
            {
                pDB.ADDRelation(adb);
				JHT.Insert(0, (JDataBase)adb, true);
			}

			adb.Dispose();
            return true;
        }
        public bool Save(JTable pTB, int pObjectCode, string pDesc, JDataBase pDB)
        {
            return true; //then all below will be ignored

            History = pTB.GetXML();
            Date = DateTime.Now;
            Description = pDesc;
            ObjectCode = pObjectCode;
            UserCode = JMainFrame.CurrentUserCode;
            PostCode = JMainFrame.CurrentPostCode;
            AllFields = false;

            ArchivedDocuments.JArchiveDataBase adb = new ArchivedDocuments.JArchiveDataBase();

            JHistoryTable JHT = new JHistoryTable();
            JHT.SetValueProperty(this);
            if (pDB == null)
				JHT.Insert(0, (JDataBase)adb, true);
			else
            {
                pDB.ADDRelation(adb);
				JHT.Insert(0, (JDataBase)adb, true);
			}

			adb.Dispose();
            return true;
        }

        //public bool Save(JTable pTB, int pObjectCode, string pDesc)
        //{
        //    return Save(pTB, pObjectCode, pDesc, null);
        //}

        /// <summary>
        /// ذخیره سابقه به صورت رشته
        /// </summary>
        /// <param name="PHistory"></param>
        /// <param name="PObjectCode"></param>
        public bool Save(string PHistory, string pClassName, int PObjectCode)
        {
            return Save(PHistory, pClassName, PObjectCode, null);
        }
        public bool Save(string PHistory, string pClassName, int PObjectCode, JDataBase pDB)
        {
            return true; //then all below will be ignored

            Date = DateTime.Now;
            History = PHistory;
            ObjectCode = PObjectCode;
            UserCode = JMainFrame.CurrentUserCode;
            PostCode = JMainFrame.CurrentPostCode;
            AllFields = false;

            ArchivedDocuments.JArchiveDataBase adb = new ArchivedDocuments.JArchiveDataBase();

            JHistoryTable JHT = new JHistoryTable();
            JHT.SetValueProperty(this);
            if (pDB == null)
				JHT.Insert(0, (JDataBase)adb, true);
			else
            {
                pDB.ADDRelation(adb);
				JHT.Insert(0, (JDataBase)adb, true);
			}

			adb.Dispose();
            return true;
        }

        /// <summary>
        /// ذخیره سابقه بصورت جدول
        /// </summary>
        /// <param name="pTable"></param>
        /// <param name="pObjectCode"></param>
        /// <returns></returns>
        //public bool Save(DataTable pTable, int pObjectCode)
        //{
        //    Date = DateTime.Now;
        //    //DataTable table = new DataTable();
        //    System.Xml.XmlDocument doc = JSerialization.SerilizeXML(pTable);
        //    if (doc==null)
        //        return false;
        //    History = doc.InnerXml;
        //    ObjectCode = pObjectCode;
        //    UserCode = JMainFrame.CurrentUserCode;
        //    PostCode = JMainFrame.CurrentPostCode;
        //    AllFields = true;
        //    JHostoryTable JHT = new JHostoryTable();
        //    JHT.SetValueProperty(this);
        //    JHT.Insert();
        //    return true;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTB"></param>
        /// <param name="pObjectCode"></param>
        /// <returns></returns>
        public bool Save(object OClass, JTable pTB, int pObjectCode)
        {
            return Save(OClass, pTB, pObjectCode, "");
        }
		public bool Save(object OClass, JTable pTB, int pObjectCode, string Desc)
        {
            return true; //then all below will be ignored

            ArchivedDocuments.JArchiveDataBase adb = new ArchivedDocuments.JArchiveDataBase();
            try
			{
				ClassName = OClass.GetType().FullName;
				//ClassName = pTB.ToString();
				History = pTB.GetXML();
				ObjectCode = pObjectCode;
				UserCode = JMainFrame.CurrentUserCode;
				PostCode = JMainFrame.CurrentPostCode;
				AllFields = true;
				Description = Desc;
				Date = JDateTime.Now();


				JHistoryTable JHT = new JHistoryTable();
				JHT.SetValueProperty(this);
				JHT.Insert(0, adb, true, false);

			}
			catch
			{
			}
            finally
            {
				adb.Dispose();
            }
			return true;
		}
        /// <summary>
        /// بازیابی سابقه تغییرات یک رکورد بر اساس نام کلاس و کد شیء
        /// </summary>
        /// <param name="pObjectCode"></param>
        /// <returns></returns>
        public DataTable RetrieveHistory(int pObjectCode)
        {
            ArchivedDocuments.JArchiveDataBase db = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.History + " WHERE [ClassName] = " + JDataBase.Quote(this.ClassName) +
                        " AND ObjectCode=" + pObjectCode + " AND AllFields = 1");
                if (db.Query_DataReader())
                {
                    DataTable table = new DataTable();
                    while (db.DataReader.Read())
                    {
                        try
                        {
                            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                            //System.Xml.XmlDataDocument doc = new System.Xml.XmlDataDocument();
                            doc.LoadXml(db.DataReader["History"].ToString());
                            DataTable tblHistory = new JDataTable();
                            try
                            {
                                tblHistory = (JDataTable)JSerialization.DeserializeXML(doc, typeof(JDataTable));
                            }
                            catch
                            {
                                try
                                {
                                    tblHistory = (DataTable)JSerialization.DeserializeXML(doc, typeof(DataTable));
                                }
                                catch
                                {
                                }
                            }
                            tblHistory.Columns.Add("UserNameChange");
                            tblHistory.Columns.Add("DateChange");
                            Employment.JEOrganizationChart tmp = new Employment.JEOrganizationChart((int)(db.DataReader["PostCode"]));
                            tblHistory.Rows[0]["UserNameChange"] = tmp.full_title;
                            tblHistory.Rows[0]["DateChange"] = JDateTime.FarsiDate(Convert.ToDateTime(db.DataReader["Date"]));
                            table.Merge(tblHistory);
                        }
                        catch
                        {
                        }
                    }
                    return table;
                }
                return null;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable PersonHistory(int pPostCode)
        {
            ArchivedDocuments.JArchiveDataBase db = new ArchivedDocuments.JArchiveDataBase();

            JConfig conf = new JConfig();
			try
			{
				db.setQuery(@"SELECT Code
                    , isnull((Select TEXT From " + conf.Server + @".dic where name = ClassName) , ClassName) ObjectType, ObjectCode
                    , isnull((Select TEXT From " + conf.Server + @".dic where name = Description) , Description) Operation
                    , (Select Fa_Date from " + conf.Server + @".StaticDates where EN_Date = (CONVERT(Date, [Date]))) Date
                    , CONVERT(Time(0), [Date]) Time
                    ,History
                    FROM clsHistory WHERE [UserCode] = " + pPostCode.ToString());
				return db.Query_DataTable();
			}
			catch
			{
				return null;
			}
			finally
			{
				db.Dispose();
			}
        }

        public DataTable GetDataTableHistory(string pHistory, int pPostCode, DateTime pDate)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(pHistory);
            DataTable tblHistory = new DataTable();
            tblHistory = (DataTable)JSerialization.DeserializeXML(doc, typeof(DataTable));
            tblHistory.Columns.Add("UserNameChange");
            tblHistory.Columns.Add("DateChange");
            Employment.JEOrganizationChart tmp = new Employment.JEOrganizationChart(pPostCode);
            tblHistory.Rows[0]["UserNameChange"] = tmp.full_title;
            tblHistory.Rows[0]["DateChange"] = JDateTime.FarsiDate(pDate);
            return tblHistory;
        }

        /// <summary>
        /// Convert XML To DataTable
        /// برای بازیابی تغییرات ثبت شده
        /// </summary>
		public DataTable GetXMLHistory(int pCode)
		{
			ArchivedDocuments.JArchiveDataBase db = new ArchivedDocuments.JArchiveDataBase();
			try
			{
				db.setQuery("Select History from clsHistory WHERE Code = " + pCode.ToString());
				System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
				doc.LoadXml(db.Query_DataTable().Rows[0][0].ToString());
				DataTable tblHistory = new DataTable();
				tblHistory = (DataTable)JSerialization.DeserializeXML(doc, typeof(DataTable));
				return tblHistory;
			}
			finally
			{
				db.Dispose();
			}
		}

        public void ShowModal(int ObjectCode)
        {
            JHistoryForm HF = new JHistoryForm(this, ObjectCode);
            HF.ShowDialog();
        }
    }

    public class JHistories
    {
        public static DataTable GetHistory(JHistoryTable HistoryValues, JHistoryTableEnum SearchFields)
        {
            string where = " Where 1=1 ";
            if ((SearchFields & JHistoryTableEnum.Code) == JHistoryTableEnum.Code)
                where += " AND Code='" + HistoryValues.Code + "'";
            if ((SearchFields & JHistoryTableEnum.ClassName) == JHistoryTableEnum.ClassName)
                where += " AND ClassName='" + HistoryValues.ClassName + "'";
            if ((SearchFields & JHistoryTableEnum.Date) == JHistoryTableEnum.Date)
                where += " AND Date='" + HistoryValues.Date + "'";
            if ((SearchFields & JHistoryTableEnum.Description) == JHistoryTableEnum.Description)
                where += " AND Description='" + HistoryValues.Description + "'";
            if ((SearchFields & JHistoryTableEnum.History) == JHistoryTableEnum.History)
                where += " AND History='" + HistoryValues.History + "'";
            if ((SearchFields & JHistoryTableEnum.ObjectCode) == JHistoryTableEnum.ObjectCode)
                where += " AND ObjectCode='" + HistoryValues.ObjectCode + "'";
            if ((SearchFields & JHistoryTableEnum.ObjectCode1) == JHistoryTableEnum.ObjectCode1)
                where += " AND ObjectCode1='" + HistoryValues.ObjectCode1 + "'";
            if ((SearchFields & JHistoryTableEnum.ObjectCode2) == JHistoryTableEnum.ObjectCode2)
                where += " AND ObjectCode2='" + HistoryValues.ObjectCode2 + "'";
            if ((SearchFields & JHistoryTableEnum.ObjectCode3) == JHistoryTableEnum.ObjectCode3)
                where += " AND ObjectCode3='" + HistoryValues.ObjectCode3 + "'";
            if ((SearchFields & JHistoryTableEnum.PostCode) == JHistoryTableEnum.PostCode)
                where += " AND PostCode='" + HistoryValues.PostCode + "'";
            if ((SearchFields & JHistoryTableEnum.UserCode) == JHistoryTableEnum.UserCode)
                where += " AND UserCode='" + HistoryValues.UserCode + "'";

            ArchivedDocuments.JArchiveDataBase db = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                db.setQuery("Select * from clsHistory " + where);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
