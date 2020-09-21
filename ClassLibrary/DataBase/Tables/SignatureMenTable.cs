using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JSignatureMenTable : JTable
    {
        public JSignatureMenTable()
            : base(JTableNamesClassLibrary.SignatureMen)
        {
        }
        #region Fields
        public int PCode;
        public int SignPCode;        
        public string FirstName;
        public string LastName;
        public string FatherName;
        public string IDNo;
        public bool Active;
        public string Post;
        public string Description;
        public DateTime FromDate;
        public DateTime ToDate;
        #endregion
    }

    public enum JSignatureMenFields
    {
        Code,
        PCode,
        FirstName,
        LastName,
        FatherName,
        IDNo,
        Active,
        Post,
        Description,
        SignPCode,
        FromDate,
        ToDate
    }
}

