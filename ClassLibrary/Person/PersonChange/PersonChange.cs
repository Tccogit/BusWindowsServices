using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data ;

namespace ClassLibrary
{
    public class JPersonChange
    {
        public int oldPCode;
        public int newPCode;

        private string[] Tables;

        //private string[] Tables = {"t1@f1","t2@f2","" };LegPersonContract
        //private string[] Tables = { 
        //                            "LegVicarious@Person_Code",
        //                            "LegAdvocate@Person_Code",
        //                            "LegAdvocacy@PersonCode",
        //                            "legProbateInheritance@CodePerson",
        //                            "LegPersonExecute@PersonCode",
        //                            "estPrimaryOwnerGround@PCode",
        //                            "estGround@Person",
        //                            "estGroundHistory@Person",
        //                            "estSheet@PCode",
        //                            "estPrimaryOwnerBuild@PCode",
        //                            "estDefaultOwners@PCode",
        //                            "LegPersonPetition@PersonCode",
        //                            "REstTransferPersons@PersonCode",
        //               /*Share*/    
        //                            "ShareSheet@PCode",
        //                            "ShareAgent@PCode",
        //                            "ShareTransfer@FPCode",
        //                            "ShareTransfer@SPCode",
        //                            "SharePersonLogger@PCode",
        //                            "ShareSheetLog@PCode",
        //                            "ShareSheetLog@NewPCode",

        //                            "clsSignatureMen@SignPCode", 
        //                            "empContract@PCode"
        //              /*Finance*/ , "finAssetShare@PersonCode"
        //              /*Finance*/ , "finCheques@ReceiverCode", 
        //                            "finCheques@ExporterCode"
        //              /*Finance*/ , "finFish@ReceiverCode"
        //                          , "finFish@ExporterCode"
        //              /*Finance*/ , "finPromissoryNote@ReceiverCode" 
        //                          , "finPromissoryNote@ExporterCode"
        //              /*Finance*/ , "finRealPrice@ReceiverCode"
        //                          , "finRealPrice@ExporterCode"
        //              /*Leg*/     , "legPersonContract@PersonCode"
        //              /*Meeting*/ , "MetMeetingPersons@PersonCode"
        //              /*Res*/     , "ResPersonFood@PersonCode"
        //                          , "ResEmployeeFood@EmployeeCode"
        //                          , "ResEmployeeCostCenter@PersonCode"
        //                          , "Users@Pcode"
        //                          , "estPrimaryOwnerGround@Pcode"
        //                          , "Refer@sender_code"
        //                          , "Refer@receiver_code"
        //                          , "SmPersonalCard@PersonalCode"
        //                          , "SmSellers@IdPerson"
        //                          , "SecLinkPerson@PersonCode"	
        //                          , "SecOrder@UserRegister"	
        //                          , "SecForm@PersonCode"
        //                          , "SecVisitors@Userc"
        //                          , "PrkDayProfile@UserReg"
        //            /*Store*/     , "StoreBillGoods@Seller"
        //            /*Store*/     , "StoreBillGoods@Buyer"
        //                          , "StoreBillGoods@Creator"
        //            /*Employee*/  , "EmpEmployee@PCode"
        //                          , "EmpPersonnelContract@id_employee" 
        //                          , "EmpFamilyInformation@PCode"  
        //                          , "EmpVacationDaily@PCode"                                  
        //           /* Bascool */  , "BascolWeights@PersonCode"



        //                          };


        public JPersonChange()
        {
            RefreshTables();
        }

        private void RefreshTables()
        {
            if (Tables != null && Tables.Length > 0)
            {
                Array.Resize(ref Tables, 0);
            }

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM ClsRelationTables where MasterTableName='ClsPerson@Code'");
                DataTable DT = DB.Query_DataTable();
                int count = 0;

                Tables = new string[DT.Rows.Count];
                foreach (DataRow DR in DT.Rows)
                {
                    Tables[count++] = DR["SlaveTableName"].ToString();
                }

            }
            catch
            {
            }
            finally
            {
                DB.Dispose();
            }
        }


        public bool Changes(Int64 pOldPCode, Int64 pNewPCode)
        {
            return Changes(pOldPCode, pNewPCode, null);
        }

        public bool Changes(Int64 pOldPCode, Int64 pNewPCode , JDataBase pDB)
        {
            RefreshTables();
            JDataBase DB ;
            if (pDB == null)
                DB = new JDataBase();
            else
                DB = pDB;
            //DB.beginTransaction("ChnagePersonCode");
            try
            {
                if (UpdateTables(pOldPCode, pNewPCode, DB))
                {
                    if (DeletePerson(Convert.ToInt32(pOldPCode), DB))
                    {
                        //DB.Commit();
                        return true;
                    }
                }
                //DB.Rollback("ChnagePersonCode");
                return false;
            }
            catch
            {
                //DB.Rollback("ChnagePersonCode");
                return false;
            }
            finally
            {
                if (pDB == null)
                    DB.Dispose();
            }
        }


        private bool DeletePerson(int pOldPCode, JDataBase DB)
        {
            JPerson person = new JPerson(pOldPCode);
            return person.Delete(DB, false);
        }

        public bool UpdateTables(Int64 pOldPCode, Int64 pNewPCode, JDataBase pDB)
        {
            JDataBase DB;
            if (pDB == null)
                DB = new JDataBase();
            else
                DB = pDB;
            try
            {
                foreach (string Table in Tables)
                {
                    string tname = Table.Split('@')[0];
                    string fname = Table.Split('@')[1];

                    string SQL = "UPDATE [" + tname.Trim() + "] SET " + fname + "=" + pNewPCode.ToString() + " WHERE " + fname + "=" + pOldPCode.ToString();


                    DB.setQuery(SQL);
                    int ret = DB.Query_Execute();
                    //if (ret < 0)
                    //    return false;
                    //return true;
                    //if (ret < 0) DB.RecordCount
                    //{
                    //    return false;
                    //}
                }

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (pDB == null)
                    DB.Dispose();
            }

        }

        public DataTable RepeatPersonA(bool NameFam, bool FatherName, bool ShSh, bool ShMelli)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"Select A.Code, A.Name, A.Fam, A.FatherName, A.ShSh, dbo.MiladiTOShamsi(A.BthDate) BthDate, A.ShMeli  
                    from dbo.clsPerson A, dbo.clsPerson B WHERE A.Code> B.Code ";
                if (NameFam)
                    query = query + @" And LTRIM(Rtrim(A.Name)) <>'' and LTRIM(Rtrim(A.Fam))  <>''
                and (REPLACE(A.Name, ' ','') =REPLACE(B.Name, ' ','') and REPLACE(A.Fam , ' ','') =REPLACE(B.Fam, ' ',''))";
                if (FatherName)
                    query = query + @"and (A.FatherName<>'' and  REPLACE(A.FatherName, ' ','') = REPLACE(B.FatherName, ' ','') )";
                if (ShSh)
                    query = query + @"and (A.ShSh<>'' and A.ShSh<>'0' and  REPLACE(A.ShSh, ' ','') = REPLACE(B.ShSh, ' ','') )";
                if (ShMelli)
                    query = query + @"and  (Len(A.ShMeli)>=10 and Len(B .ShMeli)>=10 and  REPLACE(A.ShMeli,'-', '') = REPLACE(B.ShMeli,'-', ''))";
                db.setQuery(query,false);
                DataTable table = db.Query_DataTable();
                return table;
            }
            finally
            {
                db.Dispose();
            }
        }


        public DataTable RepeatPersonB(DataRow  person,  bool NameFam, bool FatherName, bool ShSh, bool ShMelli)
        {

            JDataBase db = new JDataBase();
            try
            {
                string query = @"Select A.Code, A.Name, A.Fam, A.FatherName, A.ShSh, dbo.MiladiTOShamsi(A.BthDate) BthDate, A.ShMeli  , Adr.Address, Adr.Tel
                    from dbo.clsPerson A   left join clsPersonAddress Adr on A.Code = Adr.PCode and Adr.AddressType = 1  WHERE 1=1";
                if (NameFam)
                    query = query + @" And REPLACE(A.Name, ' ', '') = REPLACE(" + JDataBase.Quote(person["Name"].ToString()) + ", ' ','')" +
                     " And REPLACE(A.Fam, ' ', '') = REPLACE(" + JDataBase.Quote(person["Fam"].ToString()) + ", ' ','')";
                if (FatherName)
                    query = query + @" And REPLACE(A.FatherName, ' ', '') = REPLACE(" + JDataBase.Quote(person["FatherName"].ToString()) + ", ' ','')";
                if (ShSh)
                    query = query + @" And REPLACE(A.ShSh, ' ', '') = REPLACE(" + JDataBase.Quote(person["ShSh"].ToString()) + ", ' ','')";
                if (ShMelli)
                    query = query + @" And REPLACE(A.ShMeli, '-', '') = REPLACE(" + JDataBase.Quote(person["ShMeli"].ToString()) + ", '-','')";
                db.setQuery(query,false);
                DataTable table = db.Query_DataTable();
                return table;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
