using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace BusManagment
{
    public class JBusManagment
    {

        public void ListView()
        {
        }

        public ClassLibrary.JNode[] TreeView()
        {
            JNode[] Node = new JNode[12];
            Node[0] = BusManagment.JStaticNode._BaseDefine();
            Node[1] = BusManagment.Fleet.JFleet.GetTreeNode();
            Node[2] = BusManagment.Zone.JZone.GetTreeNode();
            Node[3] = BusManagment.Line.JLine.GetTreeNode();
            Node[4] = BusManagment.Bus.JBus.GetTreeNode();
            Node[5] = BusManagment.SellerTicket.JSellerTicket.GetTreeNode();
            Node[6] = BusManagment.Station.JStation.GetTreeNode();
            Node[7] = BusManagment.Personel.JPersonel.GetTreeNode();
            Node[8] = BusManagment.JStaticNode._ReportForm();
            Node[9] = BusManagment.JStaticNode._ShowOnlineMap();
            Node[10] = BusManagment.JStaticNode._Finance();
            Node[11] = BusManagment.JStaticNode._WorkOrder();
 
            return Node;

        }

    }
}
