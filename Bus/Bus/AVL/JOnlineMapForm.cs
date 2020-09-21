using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BusManagment.AVL
{
    public partial class JOnlineMapForm : ClassLibrary.JBaseForm
    {
        DataTable BusPositions;
        int PositionIndex = 0;

        public JOnlineMapForm()
        {
            InitializeComponent();
        }

        private void JOnlineMapForm_Load(object sender, EventArgs e)
        {
            // Initialize Map
            GMap.NET.MapProviders.GMapProvider gMapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            System.IO.Directory.CreateDirectory(ClassLibrary.JConfig.appPath + "\\MapCache");
            gMapControl1.CacheLocation = ClassLibrary.JConfig.appPath + "\\MapCache";
            gMapControl1.MapProvider = gMapProvider;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.Position = new PointLatLng(33.1375511923461, 53.4375);
            gMapControl1.CanDragMap = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.Zoom = 6;
            gMapControl1.OnMapZoomChanged += gMapControl1_OnMapZoomChanged;
            gMapControl1.MouseDown += gMapControl1_MouseDown;
            gMapControl1.MouseUp += gMapControl1_MouseUp;
            gMapControl1.OnMarkerClick += gMapControl1_OnMarkerClick;

            // Bus List
            DataTable DT =  Bus.JBuses.GetDataTable();
            foreach (DataRow row in DT.Rows)
            {
                chbBuses.Items.Add(row["BusNumber"].ToString());
            }
        }

        void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            (new JBusDetailsForm(item.ToolTipText)).ShowDialog();
        }

        void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            //timer1.Enabled = true;
        }

        void gMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //timer1.Enabled = false;
        }

        void gMapControl1_OnMapZoomChanged()
        {
            UpdateMarkers();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chbOnline.Checked) checkOnlineData();
            else
            {
                double lat = Transaction.JTransactions.ConvertNMEAToDecimal(Convert.ToDouble(BusPositions.Rows[PositionIndex]["Lat"]));
                double lng = Transaction.JTransactions.ConvertNMEAToDecimal(Convert.ToDouble(BusPositions.Rows[PositionIndex]["Lng"]));
                string busserial = BusPositions.Rows[PositionIndex]["BusSerial"].ToString();
                AddMarker(new PointLatLng(lat, lng), busserial);
                UpdateMarkers();
                if (++PositionIndex >= BusPositions.Rows.Count) PositionIndex = 0;
            }
        }

        public void checkOnlineData()
        {
            //(new Transaction.JTransactions()).CheckData();
            string buses = "";
            foreach (var item in chbBuses.CheckedItems)
            {
                buses += "," + item.ToString();
            }
            if (buses.Length > 1)
                buses = buses.Substring(1);
            DataTable dt = AVL.JAVLTransaction.GetDataTable(buses);

            gMapControl1.Overlays.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    double lat = Convert.ToDouble(item["Latitude"]);
                    double lng = Convert.ToDouble(item["Longitude"]);
                    AddMarker(new PointLatLng(lat, lng), item["BusCode"].ToString());
                }
            }
            UpdateMarkers();
        }

        private void AddMarker(PointLatLng point, string Text)
        {
            var q = gMapControl1.Overlays.Where(m => m.Id == Text);
            if (q.Count() > 0)
            {
                gMapControl1.Overlays.Remove(q.First());
            }
            GMapOverlay markersOverlay = new GMapOverlay(Text);
            GMarkerGoogle marker = new GMarkerGoogle(point, new Bitmap(imageList1.Images[0]));
            marker.ToolTipText = Text;
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);
            gMapControl1.Update();
        }

        private void UpdateMarkers()
        {
            foreach (var item in gMapControl1.Overlays)
            {
                foreach (var marker in item.Markers)
                {
                    gMapControl1.UpdateMarkerLocalPosition(marker);
                }
            }
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            try
            {
                var q = gMapControl1.Overlays.Where(m => m.Id == chbBuses.SelectedItem.ToString());
                if (q.Count() == 0) return;
                gMapControl1.Position = q.First().Markers.First().Position;
                gMapControl1.Zoom = 16;
            }
            catch { }
        }

        private void chbOnline_CheckedChanged(object sender, EventArgs e)
        {
            timeA.Enabled = !chbOnline.Checked;
            timeB.Enabled = !chbOnline.Checked;
            dateA.Enabled = !chbOnline.Checked;
            dateB.Enabled = !chbOnline.Checked;
            btnShow.Enabled = !chbOnline.Checked;
            if (chbOnline.Checked)
            {
                timer1.Interval = 2000;
            }
            else
            {
                timer1.Interval = 400;
            }
            timer1.Enabled = chbOnline.Checked;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (chbBuses.CheckedItems.Count == 0) return;

            string buses = "";
            foreach (var item in chbBuses.CheckedItems)
            {
                BusManagment.Bus.JBus jBus = new Bus.JBus(item.ToString());
                buses += "," + jBus.Code.ToString();
            }
            if (buses.Length > 1)
                buses = buses.Substring(1);
            DateTime date_A = new DateTime(dateA.Date.Year, dateA.Date.Month, dateA.Date.Day, timeA.Hours, timeA.Minute, 0);
            DateTime date_B = new DateTime(dateB.Date.Year, dateB.Date.Month, dateB.Date.Day, timeB.Hours, timeB.Minute, 0);

            BusPositions = AVL.JAVLTransactions.GetDataTable(buses, date_A, date_B);

            PositionIndex = 0;
            if (BusPositions.Rows.Count == 0) return;
            gMapControl1.Overlays.Clear();

            timer1.Enabled = true;
        }
    }
}
