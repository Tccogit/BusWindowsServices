using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment
{
    public class JStaticNode :JSystem
    {
        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "ClassLibrary.JBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("JBaseDefine", "BusManagment.JStaticNode.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("JBaseDefine", "BusManagment.JStaticNode.TreeView");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.BaseDefine.GetHashCode();
            return Node;
        }

        public static JNode _Finance()
        {
            JNode Node = new JNode(0, "Documents.JAUTDocuments");
            Node.Name = "Finance";
            //Node.Icone = 4;
            Node.Hint = "Finance";

            JAction Ac = new JAction("Finance", "BusManagment.Documents.JAUTDocuments.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("Finance", "BusManagment.Documents.JAUTDocuments.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }

        public static JNode _WorkOrder()
        {
            JNode Node = new JNode(0, "WorkOrder.JTariff");
            Node.Name = "WorkOrder";
            //Node.Icone = 4;
            Node.Hint = "WorkOrder";

            JAction Ac = new JAction("WorkOrder", "BusManagment.WorkOrder.JTariffs.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("WorkOrder", "BusManagment.WorkOrder.JTariffs.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }

        public static JNode _ReportForm()
        {
            JNode Node = new JNode(0, "BusManagment.JDailyPerformanceReportOnBus");
            Node.Name = "JDailyPerformanceRportOnBus";
            //Node.Icone = 4;
            Node.Hint = "JDailyPerformanceRportOnBus";

            JAction Ac = new JAction("JDailyPerformanceReportOnBus", "BusManagment.Reports.JDailyPerformanceRportOnBus.ShowForm", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _ShowOnlineMap()
        {
            JNode Node = new JNode(0, "BusManagment.JShowOnlineMapForm");
            Node.Name = "JShowOnlineMapForm";
            //Node.Icone = 4;
            Node.Hint = "JShowOnlineMapForm";

            JAction Ac = new JAction("JShowOnlineMapForm", "BusManagment.AVL.JOnlineMapForm.ShowDialog", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }

        public JNode[] TreeView()
        {
            JNode[] Node = new JNode[7];
            Node[0] = (new ClassLibrary.JBaseDefine()).GetNode(ClassLibrary.JBaseDefine.TypeFleet);
            Node[1] = (new ClassLibrary.JBaseDefine()).GetNode(ClassLibrary.JBaseDefine.TypeLine);
            Node[2] = (new ClassLibrary.JBaseDefine()).GetNode(ClassLibrary.JBaseDefine.TypeStation);
            Node[3] = (new ClassLibrary.JBaseDefine()).GetNode(ClassLibrary.JBaseDefine.TypeSallerTicket);
            Node[4] = (new ClassLibrary.JBaseDefine()).GetNode(ClassLibrary.JBaseDefine.SpecificationType);
            Node[5] = (new ClassLibrary.JBaseDefine()).GetNode(ClassLibrary.JBaseDefine.EmploymentType);
            Node[6] = (new ClassLibrary.JBaseDefine()).GetNode(ClassLibrary.JBaseDefine.VacationType);
            //Node[6] = JStaticNode._ReportForm();
            return Node;
        }

    }
}
