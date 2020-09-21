using BusManagment.Price;
using BusManagment.Station;
using ClassLibrary;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BusManagment.Line
{
    public partial class FormLine : ClassLibrary.JBaseForm
    {
        private int Code, _MarkerStatus;
        private DataTable _Stations;
        private DataTable _BackStations;
        private GMapMarker _SelectedMarker;
        private List<Tuple<string, PointLatLng, int>> PathPoints = new List<Tuple<string, PointLatLng, int>>();
        private bool isMarkerSelectedForAction = false;

        int _LineCode;
        public FormLine()
        {
            InitializeComponent();
            State = ClassLibrary.JFormState.Insert;
            SetDefalut();
            JLineTypes MC = new JLineTypes();
            MC.SetComboBox(JcmbLineType);
        }

        public FormLine(int PCode)
        {
            InitializeComponent();
            InitMap();
            Code = PCode;

            RefreshStation();
            RefreshBackStation();
            RefreshPrices();

            _LineCode = PCode;
            Load1(PCode);
            SetDefalut();
            if (PCode > 0)
                State = ClassLibrary.JFormState.Update;
        }

        private void Load1(int PCode)
        {
            JLine objLine = new JLine();
            objLine.GetData(PCode);
            txtLineName.Text = objLine.LineName;
            txtLineNumber.Text = objLine.LineNumber.ToString();

            //JcmbLineType.SelectedValue = objLine.LineType;
            JLineTypes MC = new JLineTypes();
            MC.SetComboBox(JcmbLineType, objLine.LineType);
            JCmbZoneCode.SelectedValue = objLine.ZoneCode;
            JcmbFleet.SelectedValue = objLine.Fleet;

            checkState.Checked = objLine.Status;
            checkRotate.Checked = objLine.Rotate;
        }

        private void SetData(JLine objLine)
        {
            objLine.Code = Code;
            objLine.LineName = txtLineName.Text;
            objLine.LineNumber = Convert.ToDouble(txtLineNumber.Text);
            objLine.LineType = (int)JcmbLineType.SelectedValue;
            objLine.Fleet = (int)JcmbFleet.SelectedValue;
            objLine.ZoneCode = (int)JCmbZoneCode.SelectedValue;
            objLine.Status = checkState.Checked;
            objLine.Rotate = checkRotate.Checked;
        }

        public void SetDefalut()
        {
            DataTable DT = Fleet.JFleets.GetDataTable(0);
            JcmbFleet.DataSource = DT;
            JcmbFleet.DisplayMember = "Name";
            JcmbFleet.ValueMember = "Code";

            DataTable DTZ = Zone.JZones.GetDataTable(0);
            JCmbZoneCode.DataSource = DTZ;
            JCmbZoneCode.DisplayMember = "Name";
            JCmbZoneCode.ValueMember = "Code";
        }

        private bool Validate()
        {
            if (txtLineName.Text.Trim() == string.Empty)
            {
                ClassLibrary.JMessages.Error("لطفا نام خط را مشخص کنید", "");
                txtLineName.Focus();
                tabControl.SelectedIndex = 0;
                return false;
            }

            if (txtLineNumber.Text.Trim() == string.Empty)
            {
                ClassLibrary.JMessages.Error("لطفا شماره خط را مشخص کنید", "");
                txtLineName.Focus();
                tabControl.SelectedIndex = 0;
                return false;
            }

            if (JcmbLineType.SelectedValue == null)
            {
                ClassLibrary.JMessages.Error("لطفا نوع خط را انتخاب کنید", "");
                JcmbLineType.Focus();
                tabControl.SelectedIndex = 0;
                return false;
            }
            return true;
        }

        private void RefreshPrices()
        {
            JPrices prices = new JPrices();
            grdPrices.DataSource = prices.GetPrices(Code);
        }

        private int Save()
        {

            JLine objAutoDefine = new JLine();
            SetData(objAutoDefine);
            if (State == ClassLibrary.JFormState.Insert)
                Code = objAutoDefine.Insert();
            else
                if (State == ClassLibrary.JFormState.Update)
                    objAutoDefine.Update();
            State = ClassLibrary.JFormState.Update;

            return Code;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Save();
                Close();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Validate())
                Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormLine_Load(object sender, EventArgs e)
        {

        }

        private void RefreshStation(int code = 0)
        {
            lstStations.Items.Clear();
            _Stations = JLineStations.GetLineStations(Code, false);
            for (int i = 0; i < _Stations.Rows.Count; i++)
            {
                // Set to ListView
                ListViewItem item = new ListViewItem();
                item.Text = _Stations.Rows[i]["StationName"].ToString();
                item.Tag = _Stations.Rows[i];
                if (code > 0 && code == Convert.ToInt32(_Stations.Rows[i]["Code"]))
                    item.Selected = true;
                lstStations.Items.Add(item);

                // Show On Map
                ShowOnMap();
            }
        }

        private void RefreshBackStation(int code = 0)
        {
            lstBackStations.Items.Clear();
            _BackStations = JLineStations.GetLineStations(Code, true);
            for (int i = 0; i < _BackStations.Rows.Count; i++)
            {
                //Set To ListView
                ListViewItem item = new ListViewItem();
                item.Text = _BackStations.Rows[i]["StationName"].ToString();
                item.Tag = _BackStations.Rows[i];
                if (code > 0 && code == Convert.ToInt32(_BackStations.Rows[i]["Code"]))
                    item.Selected = true;
                lstBackStations.Items.Add(item);

                // Show On Map
                ShowOnMap();
            }
        }

        private void ShowOnMap()
        {
            gMapControl1.Overlays.Clear();
            if (_Stations != null)
                for (int i = 0; i < _Stations.Rows.Count; i++)
                {

                    PointLatLng pointA = new PointLatLng(Convert.ToDouble(_Stations.Rows[i]["Lat"]), Convert.ToDouble(_Stations.Rows[i]["Lng"]));
                    GMarkerGoogleType marker = GMarkerGoogleType.blue;
                    if (i == 0) marker = GMarkerGoogleType.blue;
                    AddMarker(_Stations.Rows[i]["StationName"].ToString(), pointA, marker);
                    if (i < _Stations.Rows.Count - 1)
                    {
                        PointLatLng pointB = new PointLatLng(Convert.ToDouble(_Stations.Rows[i + 1]["Lat"]), Convert.ToDouble(_Stations.Rows[i + 1]["Lng"]));
                        AddRoute(_Stations.Rows[i]["StationName"].ToString() + " به " + _Stations.Rows[i + 1]["StationName"].ToString(), pointA, pointB, (new Pen(Color.Blue)));
                    }
                }

            if (_BackStations != null)
                for (int i = 0; i < _BackStations.Rows.Count; i++)
                {
                    PointLatLng pointA = new PointLatLng(Convert.ToDouble(_BackStations.Rows[i]["Lat"]), Convert.ToDouble(_BackStations.Rows[i]["Lng"]));
                    GMarkerGoogleType marker = GMarkerGoogleType.red;
                    if (i == 0) marker = GMarkerGoogleType.red;
                    AddMarker(_BackStations.Rows[i]["StationName"].ToString(), pointA, marker);
                    if (i < _BackStations.Rows.Count - 1)
                    {
                        PointLatLng pointB = new PointLatLng(Convert.ToDouble(_BackStations.Rows[i + 1]["Lat"]), Convert.ToDouble(_BackStations.Rows[i + 1]["Lng"]));
                        AddRoute(_BackStations.Rows[i]["StationName"].ToString() + " به " + _BackStations.Rows[i + 1]["StationName"].ToString(), pointA, pointB, (new Pen(Color.Red)));
                    }
                }
        }

        private void AddMarker(string MarkerTitle, PointLatLng point, GMarkerGoogleType MarkerType = GMarkerGoogleType.arrow)
        {
            //gMapControl1.Overlays.Clear();
            GMapOverlay markersOverlay = new GMapOverlay("_" + Guid.NewGuid().ToString().Replace("-", ""));
            GMarkerGoogle marker = new GMarkerGoogle(point, MarkerType);
            marker.ToolTipText = MarkerTitle;
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);
            gMapControl1.Position = point;
            gMapControl1.Update();
            gMapControl1.Position = point;
            gMapControl1.Zoom = 14;
        }

        private void AddRoute(string RouteTitle, PointLatLng startPoint, PointLatLng endPoint, Pen StrokeStyle)
        {
            PointLatLng start = startPoint;
            PointLatLng end = endPoint;
            MapRoute route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(
              start, end, false, false, 15);
            GMapRoute r = new GMapRoute(route.Points, RouteTitle);
            GMapOverlay routesOverlay = new GMapOverlay("_" + Guid.NewGuid().ToString().Replace("-", ""));
            if (StrokeStyle != null)
                r.Stroke = StrokeStyle;
            routesOverlay.Routes.Add(r);
            gMapControl1.Overlays.Add(routesOverlay);
        }

        public void AddPrice()
        {
            if (txtPrice.Text != string.Empty)
                if (txtStartDatePrice.IsValidDate())
                    if (txtEndDatePrice.IsValidDate())
                        if (txtStartTimePrice.IsValidDate())
                            if (txtEndTimePrice.IsValidDate())
                            {
                                JPrice Price = new JPrice();
                                Price.Price = txtPrice.IntValue;
                                Price.LineCode = Code;
                                Price.StartDate = txtStartDatePrice.Date;
                                Price.Enddate = txtEndDatePrice.Date;
                                Price.StartTime = TimeSpan.Parse(txtStartTimePrice.Text);
                                Price.EndTime = TimeSpan.Parse(txtEndTimePrice.Text);

                                if (Price.Insert() > 0)
                                {
                                    RefreshPrices();
                                    txtPrice.Text = "";
                                    txtPrice.Tag = 0;
                                }
                                else
                                    ClassLibrary.JMessages.Error("پردازش با خطا مواجه شد.", "");
                            }
                            else
                                ClassLibrary.JMessages.Error("ساعت پایان معتبر نیست", "اخطار!");
                        else
                            ClassLibrary.JMessages.Error("ساعت آغاز معتبر نیست", "اخطار!");
                    else
                        ClassLibrary.JMessages.Error("تاریخ پایان معتبر نیست", "اخطار!");
                else
                    ClassLibrary.JMessages.Error("تاریخ آغاز معتبر نیست", "اخطار!");
            else
                ClassLibrary.JMessages.Error("مبلغ را وارد کنید", "اخطار!");
        }

        public void AddStation(bool IsBack = false)
        {


            if (!IsBack)
            {
                int Priority = 0;
                if (_Stations == null)
                    Priority = 1;
                else
                    Priority = _Stations.Rows.Count + 1;

                JLineStation LineStation = new JLineStation();
                LineStation.IsBack = IsBack;
                LineStation.StationCode = ((JStation)txtStation.Tag).Code;
                LineStation.LineCode = Code;
                LineStation.Priority = Priority;

                if (LineStation.Insert() > 0)
                {
                    RefreshStation();
                }
                else
                {
                    ClassLibrary.JMessages.Error("پردازش با خطا مواجه شد.", "");
                }
            }
            else
            {
                int Priority = 0;
                if (_BackStations == null)
                    Priority = 1;
                else
                    Priority = _BackStations.Rows.Count + 1;

                JLineStation LineStation = new JLineStation();
                LineStation.IsBack = IsBack;
                LineStation.StationCode = ((JStation)txtBackStation.Tag).Code;
                LineStation.LineCode = Code;
                LineStation.Priority = Priority;

                if (LineStation.Insert() > 0)
                {
                    RefreshBackStation();
                }
                else
                {
                    ClassLibrary.JMessages.Error("پردازش با خطا مواجه شد.", "");
                }
            }
        }

        private void btnActivePath_Click(object sender, EventArgs e)
        {
            if (txtStation.Text.Length > 0)
            {
                if (Code == 0)
                {
                    if (ClassLibrary.JMessages.Question("برای ثبت مسیر ابتدا باید خط را ثبت کنید. آیا مایلید مشخصات خط ثبت شود؟", "") == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Validate())
                        {
                            Save();
                        }
                    }
                }

                if (Code > 0)
                {
                    AddStation();
                    txtStation.Text = "";
                    txtStation.Tag = 0;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                _LineCode = Save();
                if (_LineCode > 0)
                {
                    if (SavePrice())
                    {
                        txtPrice.Text = "";
                        txtStartTimePrice.Text = "";
                        txtStartDatePrice.Text = "";
                        txtEndTimePrice.Text = "";
                        txtEndDatePrice.Text = "";
                    }
                    else
                        JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "خطا");
                }
            }
        }

        private bool SavePrice()
        {
            bool result = false;
            if (txtPrice.Text == "")
            {
                JMessages.Error("لطفا مبلغ کنید", "خطا");
                return false;
            }
            if (txtStartDatePrice.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ شروع را وارد کنید", "خطا");
                return false;
            }
            if (txtEndDatePrice.Date != DateTime.MinValue && txtStartDatePrice.Date > txtEndDatePrice.Date)
            {
                JMessages.Error("لطفا تاریخ شروع و پایان را بصورت صحیح وارد کنید", "خطا");
                return false;
            }
            TimeSpan temp = new TimeSpan();
            if (!TimeSpan.TryParse(txtStartTimePrice.Text, out temp))
            {
                JMessages.Error("لطفا ساعت شروع را بصورت صحیح وارد کنید", "خطا");
                return false;
            }
            if (!TimeSpan.TryParse(txtEndTimePrice.Text, out temp))
            {
                JMessages.Error("لطفا ساعت پایان را بصورت صحیح وارد کنید", "خطا");
                return false;
            }
            JPrice price = new JPrice(_priceCode);
            price.Price = txtPrice.IntValue;
            price.StartDate = txtStartDatePrice.Date;
            price.Enddate = txtEndDatePrice.Date;
            price.StartTime = TimeSpan.Parse(txtStartTimePrice.Text);
            price.EndTime = TimeSpan.Parse(txtEndTimePrice.Text);
            price.LineCode = _LineCode;
            if (_priceCode == 0)
            {
                result = price.Insert() > 0;
            }
            else
            {
                result = price.Update();
            }
            if (result) RefreshPrices();
            btnActPrice.Text = ClassLibrary.JLanguages._Text("Add");
            _priceCode = 0;
            return result;
        }

        private void btnDeactPrice_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchStation_Click(object sender, EventArgs e)
        {
            JStationSearchForm StationSearch = new JStationSearchForm();
            if (StationSearch.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtStation.Text = StationSearch.SelectedStation.Name;
                txtStation.Tag = StationSearch.SelectedStation;
            }
        }

        private void btnDeActivePath_Click(object sender, EventArgs e)
        {
            //if (jJanusGridStation.SelectedRow != null)
            //{
            //    jJanusGridStation.SelectedRow.Delete();
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            JStationSearchForm StationSearch = new JStationSearchForm();
            if (StationSearch.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackStation.Text = StationSearch.SelectedStation.Name;
                txtBackStation.Tag = StationSearch.SelectedStation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtBackStation.Text.Length > 0)
            {
                if (Code == 0)
                {
                    if (ClassLibrary.JMessages.Question("برای ثبت مسیر ابتدا باید خط را ثبت کنید. آیا مایلید مشخصات خط ثبت شود؟", "") == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Validate())
                        {
                            Save();
                        }
                    }
                }

                if (Code > 0)
                {
                    AddStation(true);
                    txtBackStation.Text = "";
                    txtBackStation.Tag = 0;
                }
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (lstStations.SelectedItems.Count > 0)
            {
                if (ClassLibrary.JMessages.Question("آیا مایلید ایستگاه انتخاب شده حذف شود؟", "اخطار") == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (var item in lstStations.SelectedItems)
                    {
                        DataRow row = (DataRow)((ListViewItem)item).Tag;
                        JLineStation station = new JLineStation();
                        station.Code = Convert.ToInt32(row["Code"]);
                        if (station.Delete())
                        {
                            RefreshStation();
                        }
                    }

                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (lstBackStations.SelectedItems.Count > 0)
            {
                if (ClassLibrary.JMessages.Question("آیا مایلید ایستگاه انتخاب شده حذف شود؟", "اخطار") == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (var item in lstBackStations.SelectedItems)
                    {
                        DataRow row = (DataRow)((ListViewItem)item).Tag;
                        JLineStation station = new JLineStation();
                        station.Code = Convert.ToInt32(row["Code"]);
                        if (station.Delete())
                        {
                            RefreshBackStation();
                        }
                    }

                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (lstStations.SelectedItems.Count == 1)
            {
                foreach (var item in lstStations.SelectedItems)
                {
                    DataRow row = (DataRow)((ListViewItem)item).Tag;
                    JLineStation station = new JLineStation();
                    station.Code = Convert.ToInt32(row["Code"]);
                    if (station.PriorityDown(false))
                    {
                        RefreshStation(station.Code);
                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (lstBackStations.SelectedItems.Count == 1)
            {
                foreach (var item in lstBackStations.SelectedItems)
                {
                    DataRow row = (DataRow)((ListViewItem)item).Tag;
                    JLineStation station = new JLineStation();
                    station.Code = Convert.ToInt32(row["Code"]);
                    if (station.PriorityDown(true))
                    {
                        RefreshBackStation(station.Code);
                    }
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (lstStations.SelectedItems.Count == 1)
            {
                foreach (var item in lstStations.SelectedItems)
                {
                    ListViewItem Item = (ListViewItem)item;
                    if (Item.Index != lstStations.Items.Count - 1)
                    {
                        DataRow row = (DataRow)Item.Tag;
                        JLineStation station = new JLineStation();
                        station.Code = Convert.ToInt32(row["Code"]);
                        if (station.PriorityUp(false))
                        {
                            RefreshStation(station.Code);
                        }
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (lstBackStations.SelectedItems.Count == 1)
            {
                foreach (var item in lstBackStations.SelectedItems)
                {
                    ListViewItem Item = (ListViewItem)item;
                    if (Item.Index != lstStations.Items.Count - 1)
                    {
                        DataRow row = (DataRow)Item.Tag;
                        JLineStation station = new JLineStation();
                        station.Code = Convert.ToInt32(row["Code"]);
                        if (station.PriorityUp(true))
                        {
                            RefreshBackStation(station.Code);
                        }
                    }
                }
            }
        }

        private void FormLine_Load_1(object sender, EventArgs e)
        {
        }

        private void InitMap()
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
            // Initialize Map (LinePath)
            gMapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            System.IO.Directory.CreateDirectory(ClassLibrary.JConfig.appPath + "\\MapCache");
            mapLinePath.CacheLocation = ClassLibrary.JConfig.appPath + "\\MapCache";
            mapLinePath.MapProvider = gMapProvider;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            mapLinePath.MarkersEnabled = true;
            mapLinePath.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            mapLinePath.RoutesEnabled = true;
            mapLinePath.Position = new PointLatLng(33.1375511923461, 53.4375);
            mapLinePath.CanDragMap = true;
            mapLinePath.MaxZoom = 18;
            mapLinePath.MinZoom = 2;
            mapLinePath.Zoom = 6;
        }

        private void mapLinePath_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMarkerSelectedForAction == false)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left && _MarkerStatus == 0)
                {
                    int order = PathPoints.Count() + 1;
                    PathPoints.Add(new Tuple<string, PointLatLng, int>("_" + Guid.NewGuid().ToString(), mapLinePath.FromLocalToLatLng(e.X, e.Y), order));
                    DrawMap();
                }
                if (_MarkerStatus == 2) _MarkerStatus = 0;
            }
        }

        public void DrawMap()
        {
            mapLinePath.Overlays.Clear();
            for (int i = 0; i < PathPoints.Count(); i++)
            {
                AddPoint(PathPoints[i].Item1, PathPoints[i].Item2, PathPoints[i].Item3.ToString());
                if (i > 0)
                    AddLine(PathPoints[i - 1].Item2, PathPoints[i].Item2);
            }
        }

        public void AddPoint(string ID, PointLatLng point, string MarkerTitle)
        {
            //mapLinePath.Position = point;
            GMapOverlay markersOverlay = new GMapOverlay(ID);
            GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.arrow);
            marker.ToolTipText = MarkerTitle;
            markersOverlay.Markers.Add(marker);
            mapLinePath.Overlays.Add(markersOverlay);
            mapLinePath.UpdateMarkerLocalPosition(marker);
        }

        public void AddLine(PointLatLng pointA, PointLatLng pointB)
        {
            GMapRoute gRoute = new GMapRoute(new List<PointLatLng>() { pointA, pointB }, "");

            GMapOverlay routesOverlay = new GMapOverlay("_" + Guid.NewGuid().ToString().Replace("-", ""));
            routesOverlay.Routes.Add(gRoute);
            mapLinePath.Overlays.Add(routesOverlay);
            mapLinePath.UpdateRouteLocalPosition(gRoute);
        }

        private void mapLinePath_MouseMove(object sender, MouseEventArgs e)
        {
            if (_SelectedMarker != null && isMarkerSelectedForAction == false)
            {
                _SelectedMarker.Position = mapLinePath.FromLocalToLatLng(e.X, e.Y);
                mapLinePath.UpdateMarkerLocalPosition(_SelectedMarker);
            }
        }

        private void mapLinePath_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && isMarkerSelectedForAction == false)
            {
                if (_SelectedMarker == null)
                {
                    _MarkerStatus = 1;
                    _SelectedMarker = item;
                    item.Size = new Size(48, 48);
                }
                else
                {
                    _MarkerStatus = 2;
                    _SelectedMarker = null;
                    //PathPoints.FindAll(m => m.Item1 == item.Overlay.Id).ForEach(m => m = new Tuple<string, PointLatLng, int>(m.Item1, item.Position, m.Item3));
                    Tuple<string, PointLatLng, int> path = PathPoints.Where(m => m.Item1 == item.Overlay.Id).First();
                    path = new Tuple<string, PointLatLng, int>(path.Item1, item.Position, path.Item3);

                    item.Size = new Size(32, 32);
                    DrawMap();
                }
            }
            else
            {
                if (isMarkerSelectedForAction)
                {
                    isMarkerSelectedForAction = false;
                    btnDeletePoint.Enabled = false;
                    btnInsertPoint.Enabled = false;
                    _SelectedMarker.Size = new Size(32, 32);
                    _SelectedMarker = null;

                }
                else
                {
                    isMarkerSelectedForAction = true;
                    _SelectedMarker = item;
                    btnDeletePoint.Enabled = true;
                    btnInsertPoint.Enabled = true;
                    item.Size = new Size(48, 48);
                }
            }
        }

        private void btnDelPrice_Click(object sender, EventArgs e)
        {
            if (grdPrices.SelectedRow != null)
            {
                if (ClassLibrary.JMessages.Question("آیا مایلید موارد انتخاب شده حذف گردد؟", "") == System.Windows.Forms.DialogResult.Yes)
                {
                    JPrice price = new JPrice();
                    price.Code = Convert.ToInt32(grdPrices.SelectedRow["Code"]);
                    if (price.Delete())
                        RefreshPrices();
                    else
                        ClassLibrary.JMessages.Error("پردازش با خطا مواجه شد", "");
                }
            }
        }
        int _priceCode = 0;
        private void btnEditOwner_Click(object sender, EventArgs e)
        {
            if (grdPrices.SelectedRow != null)
            {
                _priceCode = Convert.ToInt32(grdPrices.SelectedRow["Code"]);
                JPrice price = new JPrice(_priceCode);
                txtPrice.Text = price.Price.ToString();
                txtStartDatePrice.Date = price.StartDate;
                txtEndDatePrice.Date = price.Enddate;
                txtEndTimePrice.Text = price.EndTime.ToString();
                txtStartTimePrice.Text = price.StartTime.ToString();
                btnActPrice.Text = ClassLibrary.JLanguages._Text("Save...");
            }
        }

        private void grdPrices_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            btnEditPrice.PerformClick();
        }
    }
}
