using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ClassLibrary.Socket
{

    public class JSocketClientManager
    {
        public int Code { get; set; }
        public string Ip { get; set; }
        public DateTime DateTime { get; set; }
		public bool State { get; set; }
		public String ClassName { get; set; }
		public int ObjectCode { get; set; }
		public DateTime LastDateTime { get; set; }

        public bool Insert()
        {

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("insert into ClsSocketClientManager(ip,DateTime,State) values(@ip,@DateTime,@State)");
                DB.Params.Add("ip", Ip);
                DB.Params.Add("DateTime", DateTime);
                DB.Params.Add("State", State);

                DB.Query_Execute();
                return true;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool Update()
        {
            JSocketClientManagerTable SCM = new JSocketClientManagerTable();
            SCM.SetValueProperty(this);
            return SCM.Update();
        }

        public bool Delete()
        {
            JSocketClientManagerTable SCM = new JSocketClientManagerTable();
            SCM.SetValueProperty(this);
            return SCM.Delete();
        }

        public bool Find(string pIP)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from ClsSocketClientManager where ip="+JDataBase.Quote(pIP));
                DB.Query_DataTable();
                if (DB.datatable.Rows.Count == 1)
                {
                    Code = int.Parse(DB.datatable.Rows[0]["Code"].ToString());
                    Ip = DB.datatable.Rows[0]["IP"].ToString();
                    DateTime = DateTime.Parse(DB.datatable.Rows[0]["DateTime"].ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            JSocketClientManagerTable SCM = new JSocketClientManagerTable();
            return SCM.GetData(this, pCode);

        }

        public bool GetData(string pIP)
        {
            return Find(pIP);
        }

        public bool Save(System.Net.Sockets.Socket pClient)
        {
            Ip = BSPTCPServer.GetClientInfo(pClient).IP;
            DateTime = JDateTime.Now();

            if (Find(Ip))
            {
                Update();
                return true;
            }
            else
            {
				State = pClient.Connected;
                Insert();
                return true;
            }
            return false;
        }

    }

    public class JSocketClientManagerTable:JTable
    {
        public string Ip;
        public DateTime DateTime;
        public bool State;
		public String ClassName;
		public int ObjectCode;
		public DateTime LastDateTime;

        public JSocketClientManagerTable()
            : base("ClsSocketClientManager")
        {
        }

    }

    public class JSocketClientDataManager
    {
        public int Code { get; set; }
        public string IP { get; set; }
        public byte[] Data { get; set; }
        public DateTime GetDate { get; set; }

        public int IsProceced { get; set; }

        public Int64 ID { get; set; }
        public Int64 Insert()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("insert into ClsSocketClientDataManager(ip,Data,GetDate,IsProceced,ID) values(@ip,@Data,@GetDate,@IsProceced,@ID) SELECT @@IDENTITY a");
                DB.Params.Add("ip", IP);
                DB.Params.Add("Data", Data);
                DB.Params.Add("GetDate", GetDate);
                DB.Params.Add("IsProceced", IsProceced);
                DB.Params.Add("ID", ID);

                return Int64.Parse(DB.Query_DataTable().Rows[0][0].ToString());
                //DB.Query_Execute();

                //DB.setQuery("SELECT @@IDENTITY a");
                //return Int64.Parse(DB.Query_DataTable().Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool Delete(Int64 pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("delete from ClsSocketClientDataManager where Code=@Code");
                DB.Params.Add("Code", pCode);

                DB.Query_Execute();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool Process()
        {
            return true;
        }
    }

    public class JSocketClientDataManagerTable: JTable
    {
        public string IP;
        public byte[] Data;
        public DateTime GetDate;
		public Int16 IsProceced;
        public Int64 ID;

        public JSocketClientDataManagerTable()
            : base("ClsSocketClientDataManager")
        {
        }

    }

    public class JSocketManager
    {

        public static bool Connect(System.Net.Sockets.Socket pClient)
        {
            JSocketClientManager SM = new JSocketClientManager();
            return SM.Save(pClient);
        }

        public static bool DisConnect(System.Net.Sockets.Socket pClient)
        {
            JSocketClientManager SM = new JSocketClientManager();
			SM.State = false;
            return SM.Save(pClient);
        }

        public static bool Delete(Int64 pIndex)
        {
            JSocketClientDataManager SCD = new JSocketClientDataManager();
            return SCD.Delete(pIndex);
        }
        public static Int64 GetData(System.Net.Sockets.Socket pClient, byte[] pData, String pAction,Int64 ID , int pIsProceced)
        {
            JSocketClientDataManager SCD = new JSocketClientDataManager();
            SCD.Data = pData;
            SCD.IsProceced = pIsProceced;
            SCD.IP = BSPTCPServer.GetClientInfo(pClient).IP;
            SCD.GetDate = JDateTime.Now();
            SCD.ID = ID;
            Int64 RecordNumber = SCD.Insert();
            return RecordNumber;
        }

        public static void RunSocetAction(object Obj)
        {
            try
            {
                object[] p = (Obj as object[]);
                string pAction = p[2].ToString();
                byte[] pData = (p[0] as byte[]);
                System.Net.Sockets.Socket pClient = (p[3] as System.Net.Sockets.Socket);
                Int64 RecordNumber = (Int64)p[1];
                JAction A = new JAction("ExtractDate", pAction, new object[] { pData, RecordNumber }, null);
                if (A != null)
                {
                    object Ret = A.run();
                    if (Ret is KeyValuePair<String, int>)
                    {
                        JSocketClientManager SM = new JSocketClientManager();
                        SM.LastDateTime = JDateTime.Now();

                        SM.ClassName = ((KeyValuePair<String, int>)Ret).Key;
                        SM.ObjectCode = ((KeyValuePair<String, int>)Ret).Value;
                        SM.Save(pClient);
                    }
                }
            }
            catch(Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
        }

        public static bool SendData(string pIP, byte[] pData)
        {
            return true;
        }

        public static void ProcessData()
        {
        }

    }
}
