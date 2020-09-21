using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassLibrary
{
    public enum JNodeType
    {
        Start = 1,
        End = 2,
        NonEmployment = 3 ,
        Employment = 4 ,
        EmploymentManager = 5 ,
    }

    public class JFromManagerWorkFlow
    {
        public int Code { get; set; }
        public JNodeType NodeType { get; set; }
        public int Ordered { get; set; }
        public int PostCode { get; set; }
        public int FormCode { get; set; }
        public string Condition { get; set; }

        public JFromManagerWorkFlow()
        {
        }

        public int Insert()
        {
            jWorkFlowTable WT = new jWorkFlowTable();
            WT.SetValueProperty(this);
            Code = WT.Insert();
            return Code;
        }

        public bool Update()
        {
            jWorkFlowTable WT = new jWorkFlowTable();
            WT.SetValueProperty(this);
            return WT.Update();
        }

        public bool Delete()
        {
            jWorkFlowTable WT = new jWorkFlowTable();
            WT.SetValueProperty(this);
            return WT.Delete();
        }

        public bool GetData(int pCode)
        {
            jWorkFlowTable WT = new jWorkFlowTable();
            string SQL = WT.CreateQuery(" Code = " + pCode.ToString());
            
            JDataBase DB= new JDataBase();
            try
            {
                DB.setQuery(SQL);
                DataTable DT = DB.Query_DataTable();
                if (DT.Rows.Count > 0)
                {
                    jWorkFlowTable.SetToClassProperty(this, DT.Rows[0]);
                }
                return true;
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetOrderd(int pOrder)
        {
            jWorkFlowTable WT = new jWorkFlowTable();
            string SQL = WT.CreateQuery(" Ordered = " + pOrder.ToString());

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(SQL);
                DataTable DT = DB.Query_DataTable();
                if (DT.Rows.Count > 0)
                {
                    jWorkFlowTable.SetToClassProperty(this, DT.Rows[0]);
                }
                return true;
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

        public void Next()
        {
            JFromManagerWorkFlow NextNode = new JFromManagerWorkFlow();
            GetOrderd(Ordered + 1);
        }

        public DataTable GetPosts()
        {
            Employment.JEOrganizationChart OC = new Employment.JEOrganizationChart();
            switch (NodeType)
            {
                case JNodeType.Employment:
                    OC.GetData(PostCode);
                    break;
                case JNodeType.EmploymentManager:
                    OC.GetData(PostCode);
                    OC.GetData(OC.parentcode);
                    break;
                case JNodeType.End:
                    return null;
                    break;
                case JNodeType.NonEmployment:
                    OC.GetData(PostCode);
                    break;
                case JNodeType.Start:
                    return null;
                    break;
            }
            return null;
        }
    }


    public class JFromManagerWorkFlows
    {

        public JFromManagerWorkFlows()
        {
        }
    }
}
