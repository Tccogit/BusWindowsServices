using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// انواع آدرس
    /// </summary>
    public enum JAddressTypes
    {
        None = 0, Home = 1, Work = 2, GasStation = 3
    }

    public class JPersonAddress
    {
        public JPersonAddress()
        {
        }

        public JPersonAddress(int pPCode, JAddressTypes pAddressType)
        {
            getData(pPCode, pAddressType);
        }

        public JPersonAddress(int pPCode)
        {
            if (!getData(pPCode, JAddressTypes.None))
                if (!getData(pPCode, JAddressTypes.Home))
                    getData(pPCode, JAddressTypes.Work);
        }
        /// <summary>
        /// کد آدرس
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// نوع آدرس
        /// </summary>
        public JAddressTypes AddressType { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// شهر
        /// </summary>
        public int City { get; set; }
        /// <summary>
        /// کد پستی
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// تلفن
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// فاکس
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// همراه
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// وب سایت
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        /// آدرس کامل
        /// </summary>
        public string FullAddress
        {
            get
            {
                string cityName = (new JSubBaseDefine(City).Name);
                return cityName + " - " + Address;
            }
        }

        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName
        { get; set; }

        /// <summary>
        /// کد
        /// </summary>
        public int ObjectCode
        { get; set; }

        /// <summary>
        /// استان
        /// </summary>
        public int State { get; set; }

        public int Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
                return Insert(this.PCode, 0, db);
            }
            finally
            {
                db.Dispose();
            }
        }
        public int Insert(JDataBase db)
        {
            return Insert(this.PCode, 0, db);
        }
        /// <summary>
        /// درج آدرس
        /// </summary>
        /// <returns></returns>
        public int Insert(int pPCode, Int64 pSharePCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                return Insert(pPCode, pSharePCode, db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// درج آدرس
        /// </summary>
        /// <returns></returns>
        public int Insert(int pPCode, Int64 pSharePCode, JDataBase db)
        {
            try
            {
                PCode = pPCode;
                JAddressTable addressTable = new JAddressTable();
                addressTable.SetValueProperty(this);
                if (pSharePCode > 0 && Code > 0)
                    JShareWebLog.Insert(db, "clsPersonAddress", Code, 'i');
                return addressTable.Insert(db);

                //            string InsertSQL =
                //                @"DECLARE @Code INT "+
                //                JDataBase.GetInsertSQL(JTableNamesClassLibrary.PersonAddress)+

                //                @"INSERT INTO " + JTableNamesClassLibrary.PersonAddress +
                //                @"(Code, PCode, AddressType, Address, City, PostalCode, Tel , Fax, Mobile, Email, WebSite) VALUES
                //                (@Code, @PCode, @AddressType, @Address, @City, @PostalCode, @Tel , @Fax, @Mobile, @Email, @WebSite) 
                //                SELECT @Code";

                //            //JDataBase db = JGlobal.MainFrame.GetDBO();
                //            try
                //            {
                //                db.setQuery(InsertSQL);
                //                db.AddParams("@PCode", pPCode);
                //                db.AddParams("@AddressType", this.AddressType.GetHashCode());
                //                db.AddParams("@Address", this.Address);
                //                db.AddParams("@City", this.City);
                //                db.AddParams("@PostalCode", this.PostalCode);
                //                db.AddParams("@Tel", this.Tel);
                //                db.AddParams("@Fax", this.Fax);
                //                db.AddParams("@Mobile", this.Mobile);
                //                db.AddParams("@Email", this.Email);
                //                db.AddParams("@WebSite", this.WebSite);
                //                return Convert.ToInt32(db.Query_ExecutSacler());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //db.Dispose();
            }
        }

        /// <summary>
        /// ویرایش آدرس
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            //JPersonAddressTable addressTable = new JPersonAddressTable();
            //addressTable.SetValueProperty(this);
            //return addressTable.Update();
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("UPDATE " + JTableNamesClassLibrary.PersonAddress +
                            @" SET Address=@Address , City = @City, PostalCode = @PostalCode, Tel = @Tel, Fax=@Fax,
                            Mobile =@Mobile, Email=@Email, WebSite=@WebSite WHERE PCode=@PCode AND AddressType=@AddressType");
                db.AddParams("@Address", this.Address);
                db.AddParams("@City", this.City);
                db.AddParams("@PostalCode", this.PostalCode);
                db.AddParams("@Tel", this.Tel);
                db.AddParams("@Fax", this.Fax);
                db.AddParams("@Mobile", this.Mobile);
                db.AddParams("@Email", this.Email);
                db.AddParams("@WebSite", this.WebSite);
                db.AddParams("@PCode", this.PCode);
                db.AddParams("@AddressType", this.AddressType.GetHashCode());
                db.beginTransaction("UpdatePerson");
                if (db.Query_Execute() > -1)
                {
                    //if ((new JAllPerson(PCode)).SharePCode > 0 && Code > 0)
                    if (JShareWebLog.Insert(db, "clsPersonAddress", Code, 'u') < 0)
                    {
                        db.Rollback("UpdatePerson");
                        return false;
                    }
                    if (db.Commit())
                        return true;
                }
                db.Rollback("UpdatePerson");
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("UpdatePerson");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Save()
        {
            if (Code > 0)
            {
                return Update();
            }
            else
            {
                return Insert() > 0;
            }
        }

        public bool Delete(JDataBase pDB)
        {
            JDataBase DB = pDB;
            string DeleteQuery = "DELETE FROM " + JTableNamesClassLibrary.PersonAddress + " WHERE Code=@Code";
            try
            {
                DB.Params.Clear();
                DB.setQuery(DeleteQuery);
                DB.AddParams("Code", this.Code);
                /// درج در جدول سابقه سهام برای انتقال به وب سایت
                //if ((new JAllPerson(PCode)).SharePCode > 0 && Code > 0)
                //    JShareWebLog.Insert(DB, "clsPersonAddress", Code, 'd');
                return (DB.Query_Execute() > -1);
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


        public bool Delete(int Code)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            string DeleteQuery = "DELETE FROM " + JTableNamesClassLibrary.PersonAddress + " WHERE Code=@Code";
            try
            {
                DB.Params.Clear();
                DB.setQuery(DeleteQuery);
                DB.AddParams("Code", Code);
                /// درج در جدول سابقه سهام برای انتقال به وب سایت
                //if ((new JAllPerson(PCode)).SharePCode > 0 && Code > 0)
                //    JShareWebLog.Insert(DB, "clsPersonAddress", Code, 'd');
                return (DB.Query_Execute() > -1);
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
        /// خواندن اطلاعات آدرس بر اساس کد رکورد آدرس
        /// </summary>
        /// <param name="pCode">کد رکورد آدرس</param>
        /// <returns></returns>
        public Boolean getData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.PersonAddress + " WHERE [Code] = " + pCode.ToString());
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
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="isEmail">اگر false 
        /// باشد به معنی آن است که value
        /// شماره همراه است در غیر این صورت ایمیل است.</param>
        /// <returns></returns>
        public Boolean getData(string value,bool isEmail=true)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (isEmail)
                    db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.PersonAddress + " WHERE [Email] = '" + value + "'");
                else
                    db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.PersonAddress + " WHERE [Mobile] = '" + value + "'");
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
        /// خواندن اطلاعات آدرس بر اساس کد شخص و نوع آدرس
        /// </summary>
        /// <param name="pPCode">کد شخص</param>
        /// <param name="pAddressType">نوع آدرس</param>
        /// <returns></returns>
        public Boolean getData(int pPCode, JAddressTypes pAddressType)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                this.AddressType = pAddressType;
                db.setQuery("SELECT * FROM " + JTableNamesClassLibrary.PersonAddress + " WHERE [PCode] = " + pPCode.ToString() + " AND [AddressType] = " + pAddressType.GetHashCode().ToString());
                System.Data.DataTable DT = db.Query_DataTable();
                if (DT.Rows.Count == 1)
                {
                    JTable.SetToClassProperty(this, db.datatable.Rows[0]);
                    //this.PCode = pPCode;
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        ///  جستجوی آدرس بر اساس کد شخص و نوع آدرس
        /// </summary>
        /// <param name="pPCode">کد شخص</param>
        /// <param name="pAddressType">نوع آدرس</param>
        /// <returns></returns>
        public int Find(int pPCode, JAddressTypes pAddressType)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT Code FROM " + JTableNamesClassLibrary.PersonAddress + " WHERE [PCode] = " + pPCode.ToString() + " AND [AddressType] = " + pAddressType.GetHashCode().ToString());
                object result = db.Query_ExecutSacler();
                if (result == null)
                    return 0;
                return Convert.ToInt32(result);
            }
            finally
            {
                db.Dispose();
            }
        }

        public System.Data.DataTable RetrieveForWeb(int objCode, string ClassName, JAddressTypes pAddressType)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query =
                @"
                     SELECT clsPersonAddress.Code,
                      Address ,
                      AddressType ,
                      City ,
                      ClassName ,
                      dbo.clsPersonAddress.Code ,
                      Email ,
                      Fax ,
                      Mobile ,
                      ObjectCode ,
                      PCode ,
                      PostalCode ,
                      State ,
                      Tel ,
                      WebSite,t1.name as City_Name,t2.name as State_Name From " + JTableNamesClassLibrary.PersonAddress + @"
                        LEFT JOIN subdefine  t1 ON (t1.Code = clsPersonAddress.City)
			            LEFT JOIN subdefine  t2 ON (t2.Code = clsPersonAddress.State)

			             WHERE ObjectCode =" + objCode.ToString() + " AND  ClassName='" + ClassName + "' ORDER BY  clsPersonAddress.Code DESC ";

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
    }
}
