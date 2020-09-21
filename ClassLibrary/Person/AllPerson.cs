using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public enum JDiedStatus
    {
        Died = 0, NotDied = 1, All = 100
    }
    public enum JBlockStatus
    {
        Block = 0, NotBlock = 1, All = 100
    }
    public enum JPersonTypes
    {
        None = 0, RealPerson = 1, LegalPerson = 2, OtherPerson = 3, NonIranianPerson = 4,
    }

    public class JAllPerson : JSystem
    {
        public static Type DiedType = Type.GetType("ClassLibrary.JDiedStatus");
        public static Type BlockType = Type.GetType("ClassLibrary.JBlockStatus");
        public JAllPerson()
        {

        }
        public JAllPerson(int pCode)
        {
            this.GetData(pCode);
        }
        #region Properties
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد شخص حقیقی
        /// </summary>
        //public int RealPerson { get; set; }
        /// <summary>
        /// کد شخص حقوقی
        /// </summary>
        //public int LegalPerson { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// شماره شناسنامه / شماره ثبت
        /// </summary>
        public string IDNo { get; set; }
        /// <summary>
        /// فعال / غیر فعال
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// نوع شخص (حقیقی / حقوقی)
        /// </summary>
        public JPersonTypes PersonType { get; set; }
        /// <summary>
        /// اطلاعات شخص ناقص می باشد-شماره شناسنامه و غیره ثبت نشده است
        /// </summary>
        public bool IncompleteInformation { get; set; }
        /// <summary>
        /// کد تفصیلی
        /// </summary>
        public int TafsiliCode { get; set; }

        #endregion

        /// <summary>
        /// جستجوی شخص
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool Find(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("IF Exists (SELECT Code FROM  " + JTableNamesClassLibrary.AllPerson + " WHERE Code = " + pCode.ToString() +
                    ") SELECT 1 ELSE SELECT 0");
                return ((int)DB.Query_ExecutSacler() == 1);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetName(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT Name FROM  " + JTableNamesClassLibrary.AllPerson + " WHERE Code = " + pCode.ToString() );
                if (DB.Query_DataTable().Rows.Count == 1)
                    return DB.Query_DataTable().Rows[0]["Name"].ToString();
                else
                    return "";
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void ShowDialog()
        {
            if (this.PersonType == JPersonTypes.RealPerson)
            {
                JPerson person = new JPerson(this.Code);
                person.ShowDialog();
            }
            else
                if (this.PersonType == JPersonTypes.LegalPerson)
                {
                    JOrganization  person = new JOrganization(this.Code);
                    person.ShowDialog();
                }
        }
        public void ShowPropertiesDialog()
        {
            JPersonPropertiesForm form = new JPersonPropertiesForm();
            form.ShowDialog();
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "ClassLibrary.JAllPerson");
            Node.Icone = JImageIndex.Person.GetHashCode();

			JAction DelRepeatAction = new JAction("DeleteRepeat...", "ClassLibrary.DelRepeatPersonForm.ShowDialog", null, null);
			Node.Popup.Insert(DelRepeatAction);

            return Node;
        }

        public static bool CheckTafsiliCode(int pTafsiliCode,int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("IF Exists (SELECT Code FROM  " + JTableNamesClassLibrary.AllPerson + " WHERE Code <> " + pCode+ " And TafsiliCode = " + pTafsiliCode.ToString() +
                    ") SELECT 1 ELSE SELECT 0");
                return ((int)DB.Query_ExecutSacler() == 1);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// درج در جدول واسط
        /// </summary>
        /// <returns></returns>
        public bool Insert(JDataBase pDB)
        {
            JDataBase DB = pDB;
            try
            {
                DB.Params.Clear();
                DB.setQuery("INSERT INTO " + JTableNamesClassLibrary.AllPerson + " (Code, Name, IDNo, Active, PersonType,IncompleteInformation,TafsiliCode,SharePCode) " +
                        " Values (@Code, @Name, @IDNo, @Active, @PersonType,@IncompleteInformation,@TafsiliCode, @SharePCode)");
                DB.AddParams("Code", this.Code);
                DB.AddParams("Name", this.Name);
                DB.AddParams("IDNo", this.IDNo);
                DB.AddParams("Active", this.Active);
                DB.AddParams("PersonType", this.PersonType.GetHashCode());
                DB.AddParams("IncompleteInformation", this.IncompleteInformation);
                DB.AddParams("TafsiliCode", this.TafsiliCode);
                DB.AddParams("SharePCode", 0);

                if (DB.Query_Execute() >= 0)
                {
					

					//
					JDataBase TDB1 = new JDataBase();
					JDataBase TDB2 = new JDataBase();
					try
					{
						TDB1.setQuery("exec SP_PersonAddressViewSharePCode");
						TDB1.Query_Execute(true);

						TDB2.setQuery("exec SP_PersonAddressView");
						TDB2.Query_Execute(true);
					}
					finally
					{
						//db.Dispose();
					}
					//
					
					
					
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
                // DB.Dispose();
            }
        }
        /// <summary>
        /// ویرایش جدول واسط
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase pDB)
        {
            JDataBase DB = pDB;
            try
            {
                DB.setQuery(" UPDATE " + JTableNamesClassLibrary.AllPerson +
                    " Set Name =@Name, IDNo=@IDNo, Active=@Active,IncompleteInformation=@IncompleteInformation,TafsiliCode=@TafsiliCode, SharePCode = @SharePCode WHERE Code=@Code");
                DB.Params.Clear();
                DB.AddParams("Code", this.Code);
                DB.AddParams("Name", this.Name);
                DB.AddParams("IDNo", this.IDNo);
                DB.AddParams("Active", this.Active);
                DB.AddParams("IncompleteInformation", this.IncompleteInformation);
                DB.AddParams("TafsiliCode", this.TafsiliCode);
                DB.AddParams("SharePCode", 0);
                if (DB.Query_Execute() > -1)
                {
                    //if (SharePCode > 0)
                    //    JShareWebLog.Insert(pDB, "clsAllPerson", Code, 'u');
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
                //DB.Dispose();
            }
        }

        /// <summary>
        /// حذف از جدول واسط
        /// </summary>
        /// <returns></returns>
        public bool Delete(JDataBase pDB)
        {
            //JDataBase DB = pDB;
            try
            {
                JAllPersonTable table = new JAllPersonTable();
                table.SetValueProperty(this);
                if (table.Delete(pDB))
                {
                    //if (SharePCode > 0)
                    //    JShareWebLog.Insert(pDB, "clsAllPerson", Code, 'd');
                    return true;
                }
                else
                    return false;

                //DB.setQuery(" DELETE FROM " + JTableNamesClassLibrary.AllPerson + " WHERE Code=@Code");
                //DB.Params.Clear();
                //DB.AddParams("Code", this.Code);
                //return DB.Query_Execute() > -1;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                //DB.Dispose();
            }
        }

        /// <summary>
        /// سهامدار
        /// </summary>
        /// <returns></returns>
        public bool UpdateSahamdar(int pCode)
		{
			return true;
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                //SharePCode = JPersons.GetMaxSharePCode() + 1;
                //db.setQuery(" UPDATE " + JTableNamesClassLibrary.AllPerson +
                //    " Set SharePCode = " + (SharePCode).ToString() + " WHERE (SharePCode=0 OR SharePCode is null) AND Code=" + pCode);
                ///return db.Query_Execute() > -1;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// خواندن اطلاعات اشخاص از دیتابیس
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.AllPerson + " WHERE [Code] = " + pCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// خواندن اطلاعات اشخاص از دیتابیس
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetDataTafsiliCode(int pTafsiliCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.AllPerson + " WHERE TafsiliCode = " + pTafsiliCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجوی کد شخص بر اساس کد سهامداری
        /// </summary>
        /// <param name="pSharePCode"></param>
        /// <returns></returns>
        public static int GetCodeBySharePCode(Int64 pSharePCode, int pCompanyCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (pSharePCode > 0)
                {
                    // Feyzollahi Changes
					//db.setQuery("SELECT Code FROM " + JTableNamesClassLibrary.AllPerson + " WHERE SharePCode = " + pSharePCode.ToString());
					db.setQuery(@"select cap.Code,sp.SharePCode,ca.Name as CompanyName,cap.Name 
									from SharePCodeSheet sp
									inner join ShareCompany sc on sc.Code=sp.CompanyCode
									inner join clsAllPerson ca on ca.Code=sc.PCode
									inner join clsAllPerson cap on cap.Code=sp.PersonCode
									where sp.SharePCode > 0 and sp.SharePCode=" + pSharePCode.ToString()+
																				" and CompanyCode="+pCompanyCode.ToString()
																				);
                    DataTable table = db.Query_DataTable();
                    if (table.Rows.Count >= 1)
                    {
                        int code = Convert.ToInt32(table.Rows[0]["Code"]);
                        return code;
                    }
                }
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

		/// <summary>
		/// جستجوی کد شخص بر اساس کد سهامداری
		/// </summary>
		/// <param name="pSharePCode"></param>
		/// <returns></returns>
		public static int GetShareCodeByPCode(Int64 pPCode, int pCompanyCode)
		{
			JDataBase db = JGlobal.MainFrame.GetDBO();
			try
			{
				if (pPCode > 0)
				{
					// Feyzollahi Changes
					//db.setQuery("SELECT Code FROM " + JTableNamesClassLibrary.AllPerson + " WHERE SharePCode = " + pSharePCode.ToString());
					db.setQuery(@"select cap.Code,sp.SharePCode,ca.Name as CompanyName,cap.Name 
									from SharePCodeSheet sp
									inner join ShareCompany sc on sc.Code=sp.CompanyCode
									inner join clsAllPerson ca on ca.Code=sc.PCode
									inner join clsAllPerson cap on cap.Code=sp.PersonCode
									where sp.SharePCode > 0 and clsAllPerson.Code=" + pPCode.ToString() +
																				" and CompanyCode=" + pCompanyCode.ToString()
																				);
					DataTable table = db.Query_DataTable();
					if (table.Rows.Count >= 1)
					{
						int code = Convert.ToInt32(table.Rows[0]["SharePCode"]);
						return code;
					}
				}
				return 0;
			}
			finally
			{
				db.Dispose();
			}
		}
		
		private static string _SelectQueryFind =
			 @"
		Select distinct ST2.Code, ST2.Name, ST2.IDNo_RegNo, ST2.Active,
			substring(
				(
					Select ','+cast(ST1.SharePCode as varchar)  AS [text()]
					From 
					(
		SELECT cap.Code as Code, cap.Name as Name, cap.IDNo As IDNo_RegNo, cap.Active as Active  , sps.SharePCode as SharePCode   
		FROM clsAllPerson cap
		left join SharePCodeSheet sps on sps.personcode=cap.Code
		group by cap.Code, cap.Name, cap.IDNo, cap.Active, sps.SharePCode
		)
					 ST1
					Where ST1.Code = ST2.Code
					ORDER BY ST1.Code
					For XML PATH ('')
				), 2, 1000) SharePCode
		From 
		(
		SELECT cap.Code as Code, cap.Name as Name, cap.IDNo As IDNo_RegNo, cap.Active as Active  , sps.SharePCode as SharePCode   
		FROM clsAllPerson cap
		left join SharePCodeSheet sps on sps.personcode=cap.Code
		group by cap.Code, cap.Name, cap.IDNo, cap.Active, sps.SharePCode
		)
		 ST2
		 inner join clsAllPerson cap on cap.Code=ST2.Code					
";

        /// <summary>
        /// جستجوی کلیه اشخاص
        /// </summary>
        /// <param name="pCode">کد شخص</param>
        /// <param name="pName">نام شخص</param>
        /// <param name="pActive">فعال / غیر فعال (در صورتی که -1 باشد در نظر گرفته نمیشود)</param>
        /// <param name="pPersonType">نوع شخص </param>
        /// <returns></returns>

        public static DataTable SearchPerson(int pCode, string pName, int pActive, JPersonTypes pPersonType, int pTafsiliCode,Int64 pSharePCode)
        {
			return SearchPerson(pCode, pName, pActive, pPersonType, "", pTafsiliCode, pSharePCode);
        }

        public static DataTable SearchPerson(int pCode, string pName, int pActive, JPersonTypes pPersonType, string pCondition,int pTafsiliCode,Int64 pSharePCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = _SelectQueryFind;

                Query = Query + "  WHERE cap.IncompleteInformation=0 ";
                if (pCode != 0)
                {
                    Query = Query + " AND cap.Code = " + pCode.ToString();
                }
				if (pSharePCode != 0)
				{
					Query = Query + " AND SharePCode = " + pSharePCode.ToString();
				}
                if (pTafsiliCode != 0)
                {
                    Query = Query + " AND TafsiliCode = " + pTafsiliCode.ToString();
                }
                if (pName.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery("cap.Name", true) + " LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pName, false) + '%');
                }
                if (pPersonType != JPersonTypes.None)
                {
                    Query = Query + " AND cap.PersonType = " + pPersonType.GetHashCode().ToString();
                }
                if (pActive != -1)
                {
                    Query = Query + " AND cap.Active = " + pActive.ToString();
                }
                if (pCondition!=null && pCondition.Trim().Length > 0)
                    Query += " AND  " + pCondition;

                DB.setQuery(Query);
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


        public static DataTable GetDataContractPerson(int pCode, string pName, int pActive, JPersonTypes pPersonType, string pCondition)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string _SelectQuery =
     " SELECT Name Full_Title, Code, Name, IDNo As IDNo_RegNo, Active FROM " + JTableNamesClassLibrary.AllPerson;

                string Query = _SelectQuery;

                Query = Query + "  WHERE IncompleteInformation=0 ";
                if (pCode != 0)
                {
                    Query = Query + " AND Code = " + pCode.ToString();
                }
                if (pName.Trim() != "")
                {
                    Query = Query + " AND " + JDataBase.RemoveSpaceQuery("Name", true) + " LIKE "
                        + JDataBase.Quote('%' + JDataBase.RemoveSpaceQuery(pName, false) + '%');
                }
                if (pPersonType != JPersonTypes.None)
                {
                    Query = Query + " AND PersonType = " + pPersonType.GetHashCode().ToString();
                }
                if (pActive != -1)
                {
                    Query = Query + " AND Active = " + pActive.ToString();
                }
                if (pCondition.Trim().Length > 0)
                    Query += " AND  " + pCondition;

                DB.setQuery(Query);
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

        public static bool CheckCodeMeli(string pCodeMeli)
        {
            int Sum = 0;
            decimal d = 0;
            string str = pCodeMeli.ToString();
            if(str.Length != 10)
                return false;
            for (int i = 0; i < 9; i++)
                Sum = Sum + (Convert.ToInt32(str[i].ToString()) * (10 - i));
            d = Sum % 11;
            if (d > 1)
                d = 11 - d;
            if (d.ToString() == str[9].ToString())
                return true;
            else
                return false;
        }

    }

    public class JAllPersons : JSystem
    {
        public static DataTable GetDataTable(JPersonTypes personType)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = @"  SELECT Code, Name , IDNo IDNo_RegNo , Active, 
                 Case PersonType When 1 then 'حقیقی'  when 2 then 'حقوقی' when 3 then 'سایر' else '' end PersonType 
                  FROM clsAllPerson where 1=1 ";
                if (personType != JPersonTypes.None)
                    Query += " AND PersonType  = " + personType.GetHashCode().ToString();
                db.setQuery(Query);
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
            }
        }
        public void ListView()
        {
            ListView(JPersonTypes.None);
        }

        public void ListView(JPersonTypes pPersonType)
        {
            Nodes.ObjectBase = new JAction("NewNode", "ClassLibrary.JAllPerson.GetNode");
            Nodes.DataTable = GetDataTable(pPersonType);


            JAction newAction = new JAction("New...", "ClassLibrary.jChangePersonCodeForm.ShowDialog", null, new object[] { 0, 0 });
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "PersonChange...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

        }
    }
}
