using BusManagment.Line;
using BusManagment.Zone;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;

namespace BusManagment.Station
{
    public partial class JStationForm : ClassLibrary.JBaseForm
    {
        private int Code;
        private double Lat = 0, Lng = 0;

        public JStationForm()
        {
            InitializeComponent();
            State = ClassLibrary.JFormState.Insert;
            InitForm();
        }

        private void InitForm()
        {
            SetDefalut();

            // Configuring PropertyControl
            jPropertyValue.ClassName = "BusManagment.Station";
            jPropertyValue.ObjectCode = 1000002;
            jPropertyValue.ValueObjectCode = Code;
        }

        public JStationForm(int PCode)
        {
            InitializeComponent();
            Code = PCode;
            Load1(PCode);
            State = ClassLibrary.JFormState.Update;
            InitForm();
        }

        public void SetDefalut()
        {
            JZones Zone = new JZones();
            jComZone.DataSource = JZones.GetDataTable();
            jComZone.DisplayMember = "Name";
            jComZone.ValueMember = "Code";
            JStationTypes StationTypes = new JStationTypes();
            JStation station = new JStation(Code);
            StationTypes.SetComboBox(cboStationType,station.StationTypeCode);
        }

        private void Load1(int pCode)
        {
            JStation Auto = new JStation();
            Auto.GetData(pCode);
            txtName.Text = Auto.Name;
            try { Lat = Convert.ToDouble(Auto.Lat); }
            catch { Lat = 0; }
            try { Lng = Convert.ToDouble(Auto.Lng); }
            catch { Lng = 0; }
            txtLat.Text = Lat.ToString();
            txtLng.Text = Lng.ToString();
            jComZone.SelectedValue = Auto.ZoneCode;
            cboStationType.SelectedValue = Auto.StationTypeCode;
        }

        private void SetData(JStation Auto)
        {
            Auto.Code = Code;
            try { Auto.Lat = Convert.ToDecimal(Lat); }
            catch { Auto.Lat = 0; }
            try { Auto.Lng = Convert.ToDecimal(Lng); }
            catch { Auto.Lng = 0; }
            Auto.Name = txtName.Text;
            Auto.ZoneCode = Convert.ToInt32(jComZone.SelectedValue);
            Auto.StationTypeCode = Convert.ToInt32(cboStationType.SelectedValue);
            SetDefalut();
        }


        private bool Validation()
        {
            bool result = true;

            string message = "فیلد ({0}) مورد نیاز است";
            if (txtName.Text.Trim() == string.Empty)
            {
                result = false;
                ClassLibrary.JMessages.Error(string.Format(message, ClassLibrary.JLanguages._Text(lblName.Text.Split(':')[0])), "اخطار!");
                txtName.Focus();
            }

            if (jComZone.SelectedValue == null)
            {
                result = false;
                ClassLibrary.JMessages.Error(string.Format(message, ClassLibrary.JLanguages._Text(lblZone.Text.Split(':')[0])), "اخطار!");
                txtName.Focus();
            }

            if (cboStationType.SelectedValue == null)
            {
                result = false;
                ClassLibrary.JMessages.Error(string.Format(message, ClassLibrary.JLanguages._Text(lblStationType.Text.Split(':')[0])), "اخطار!");
                txtName.Focus();
            }

            return result;
        }


        private int Save()
        {
            JStation objAutoDefine = new JStation();
            SetData(objAutoDefine);
            if (State == ClassLibrary.JFormState.Insert)
                Code = objAutoDefine.Insert();
            else
                if (State == ClassLibrary.JFormState.Update)
                    objAutoDefine.Update();
            State = ClassLibrary.JFormState.Update;
            if (Code > 0)
            {
                jPropertyValue.ValueObjectCode = Code;
                jPropertyValue.Save();
            }
            return Code;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void Delete()
        {
            if (ClassLibrary.JMessages.Question("آیا تمایل دارید مورد انتخاب شده حذف گردد", "اخطار!") == System.Windows.Forms.DialogResult.Yes)
            {
                JStation objStation = new JStation();
                objStation.Code = Code;
                if (objStation.Delete())
                    Close();
                else
                    ClassLibrary.JMessages.Message("پردازش با خطا مواجه شد", "", ClassLibrary.JMessageType.Error);
            }
            else
            {
                Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                bool IsNew = Code == 0;
                if (Save() > 0)
                {
                      
                }
                Close();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (Save() > 0)
                {
                    btnApply.Enabled = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtLong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLat_TextChanged(object sender, EventArgs e)
        {

        }

        private void JStationForm_Load(object sender, EventArgs e)
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
            gMapControl1.MouseDoubleClick += gMapControl1_MouseDoubleClick;
            gMapControl1.Position = new PointLatLng(33.1375511923461, 53.4375);
            gMapControl1.CanDragMap = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.Zoom = 6;

            // Set StationMarker on the map
            if (Lat > 0 && Lng > 0)
            {
                PointLatLng point = new PointLatLng(Lat, Lng);
                AddMarker(point);

                gMapControl1.Zoom = 14;
            }

        }

        void gMapControl1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
            AddMarker(point);
        }

        private void AddMarker(PointLatLng point)
        {
            gMapControl1.Overlays.Clear();
            GMapOverlay markersOverlay = new GMapOverlay("S1");
            Lat = point.Lat;
            Lng = point.Lng;
            GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.arrow);
            marker.ToolTipText = "ایستگاه";
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);
            txtLat.Text = Lat.ToString();
            txtLng.Text = Lng.ToString();
            gMapControl1.Position = point;
            gMapControl1.Update();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.Property.JDefinePropertyForm DefinePropertyForm = new Globals.Property.JDefinePropertyForm("BusManagment.Station", 1000002);
            DefinePropertyForm.ShowDialog();
        }

        private void btnZoomout_Click(object sender, EventArgs e)
        {
            double zoom = gMapControl1.Zoom;
            if (--zoom < 2) zoom = 2;
            gMapControl1.Zoom = zoom;
        }

        private void btnZoomin_Click(object sender, EventArgs e)
        {
            double zoom = gMapControl1.Zoom;
            if (++zoom > 17) zoom = 17;
            gMapControl1.Zoom = zoom;
        }

        private void btnShowOnMap_Click(object sender, EventArgs e)
        {
            PointLatLng point = new PointLatLng(Convert.ToDouble(txtLat.Text), Convert.ToDouble(txtLng.Text));
            AddMarker(point);
        }
    }
}
