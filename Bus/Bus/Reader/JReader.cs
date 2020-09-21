using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.Reader
{
    class JReader
    {

        public int Code { get; set; }
        public long MicID { get; set; }
        public int ReaderVersion { get; set; }
        public int ModuleVersion { get; set; }
        public int ModuleSerial { get; set; }
        public int SamVersion { get; set; }
        public UInt32 SamSerial { get; set; }
        public int BusNumber { get; set; }
        public int ReaderId { get; set; }
        public long IMEI { get; set; }

        public DateTime VersionDate { get; set; }
        public JReader()
        {
        }
        public JReader(int rCode)
        {
            if (rCode > 0)
                this.GetData(rCode);
        }

        public int Insert()
        {
           // VersionDate = DateTime.Now;
            JReaderTable RT = new JReaderTable();
            RT.SetValueProperty(this);
            RT.IsView = true;
            Code = RT.Insert(1,true);
           

            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JReader", Code, 0, 0, 0, "ثبت کارتخوان اتوبوس", "", 0);


            return Code;
        }
      
        public bool Update()
        {
            JReaderTable RT = new JReaderTable();
            RT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("BusManagment.JBusDevise", RT.Code, 0, 0, 0, "ویرایش دستگاه اتوبوس", "", 0);
            return RT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from ReaderVersion where code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
