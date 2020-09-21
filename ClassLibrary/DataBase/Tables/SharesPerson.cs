using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class JOtherPersonTable : JTable
    {
        public JOtherPersonTable()
            : base(JTableNamesShares.OtherPerson)
        {
        }
        int Code { get; set; }
        string Name { get; set; }
        string Fam { get; set; }
        string FatherName { get; set; }
        string ShSh { get; set; }
        string ShMeli { get; set; }
        int Sader { get; set; }
        string BthDate { get; set; }
        bool Sex { get; set; }
        bool Maried { get; set; }
        int Child { get; set; }
        int Suport { get; set; }
        string MAddress { get; set; }
        string MTell { get; set; }
        int MCity { get; set; }
        string PostCode { get; set; }
        string OAddress { get; set; }
        string OTell { get; set; }
        string OCity { get; set; }
        string Mobile { get; set; }
        bool Block { get; set; }
        bool Die { get; set; }
    }
    /// <summary>
    /// فیلدهای موجود در جدول اشخاص دیتابیس سهام
    /// </summary>
    public enum JOtherPersonEnum
    {
        Code,
        Name,
        Fam,
        FatherName,
        ShSh,
        ShMeli,
        Sader,
        BthDate,
        Sex,
        Maried,
        Child,
        Suport,
        MAddress,
        MTell,
        MCity,
        PostCode,
        OAddress,
        OTell,
        OCity,
        Mobile,
        Block,
        Die
    }
    /// <summary>
    /// فیلدهای جدول شهرها از دیتابیس سهام
    /// </summary>
    public enum JSharesCitiesEnum
    {
        Code,
        City
    }

}
