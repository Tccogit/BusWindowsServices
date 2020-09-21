using System;
using System.Data;
using ClassLibrary;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace BusManagment.SellerTicket
{
    public partial class SellerForm :ClassLibrary.JBaseForm
    {
        private int _Code;
        public SellerForm()
        {
            InitializeComponent();
            State = ClassLibrary.JFormState.Insert;
            JSellerTicketTypes types = new JSellerTicketTypes();
            types.SetComboBox(jComType);
        }
   
        public SellerForm(int PCode)
        {
            InitializeComponent();
            LoadData(PCode);
            _Code = PCode;
            State = ClassLibrary.JFormState.Update;

        }

        public void Delete()
        {
            if (JMessages.Question("آیا میخواهید باجه انتخاب شده حذف شود؟", "هشدار") == System.Windows.Forms.DialogResult.Yes)
            {
                JSellerTicket objAutoDefine = new JSellerTicket();
                objAutoDefine.Code = _Code;
                if (!objAutoDefine.Delete())
                {
                    ClassLibrary.JMessages.Message("عملیات حذف با خطا مواجه شد", "", ClassLibrary.JMessageType.Error);
                }
            }
        }

        private void SellerForm_Load(object sender, EventArgs e)
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

        private void LoadData(int PCode)
        {
            SellerTicket.JSellerTicket objSeller = new SellerTicket.JSellerTicket();
            _Code = PCode;
            objSeller.GetData(_Code);
            txtStationName.Tag = objSeller.StationCode;
            Station.JStation station = new Station.JStation (objSeller.StationCode);
            Zone.JZone zone = new Zone.JZone(station.ZoneCode);
            txtStationName.Text = zone.Name + " - " + station.Name;
               
            txtAddress.Text = objSeller.Adress;
            txtTel.Text = objSeller.Tel;
            txtLat.Text = objSeller.lat.ToString();
            txtLongs.Text = objSeller.longs.ToString();
            txtTel.Text = objSeller.Tel;
            JSellerTicketTypes types = new JSellerTicketTypes();
            types.SetComboBox(jComType,objSeller.Type);
            LoadSellers();
        }

        private void SetData(SellerTicket.JSellerTicket objSeller)
        {
            objSeller.Adress = txtAddress.Text;
            objSeller.Tel = txtTel.Text;
            objSeller.StationCode = Convert.ToInt32(txtStationName.Tag);
            objSeller.lat = Convert.ToDecimal(txtLat.Text);
            objSeller.longs = Convert.ToDecimal(txtLongs.Text);
            if (jComType.SelectedValue != null)
                objSeller.Type = Convert.ToInt32(jComType.SelectedValue);
        }

        private bool Save()
        {
            bool result = false;
            if (Validate())
            {
                SellerTicket.JSellerTicket objSeller = new SellerTicket.JSellerTicket(_Code);
                SetData(objSeller);
                if (State == ClassLibrary.JFormState.Insert)
                {
                    _Code = objSeller.Insert();
                    result = _Code > 0;
                }
                else
                {
                    if (State == ClassLibrary.JFormState.Update)
                        result = objSeller.Update();
                }
                State = ClassLibrary.JFormState.Update;
            }
            return result;
        }
        private bool Validate()
        {
            if (jComType.SelectedValue == null)
            {
                JMessages.Error("لطفا نوع باجه را انتخاب کنید", "خطا");
                tabControl1.SelectedIndex = 0;
                return false;
            }
            if (txtStationName.Tag == null ||(int)txtStationName.Tag == 0)
            {
                JMessages.Error("لطفا ایستگاه را انتخاب کنید", "خطا");
                tabControl1.SelectedIndex = 0;
                return false;
            }
            return true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "خطا");
        }

        private void jComType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            ClassLibrary.JFindPersonForm FindP = new ClassLibrary.JFindPersonForm();
            FindP.ShowDialog();
            if (FindP.SelectedPerson != null)
            {
                txtPerson.Text = FindP.SelectedPerson.Name;
                txtPerson.Tag = FindP.SelectedPersonCode;
            }
        }

        private void btnSearchStation_Click(object sender, EventArgs e)
        {
            Station.JStationSearchForm form = new Station.JStationSearchForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Zone.JZone zone = new Zone.JZone(form.SelectedStation.ZoneCode);
                txtStationName.Text =  zone.Name + " - " + form.SelectedStation.Name;
                txtStationName.Tag = form.SelectedStation.Code;

                txtLongs.Text = form.SelectedStation.Lng.ToString();
                txtLat.Text = form.SelectedStation.Lat.ToString();
            }
        }
        private void LoadSellers()
        {
            grdSeller.DataSource = JSellerOwners.GetDataTable(_Code);
        }

        private bool SaveSeller()
        {
            bool result = false;
            if (txtPerson.Tag == null || (int)txtPerson.Tag == 0)
            {
                JMessages.Error("لطفا شخص را انتخاب کنید", "خطا");
                return false;
            }
            if (txtStartDate.Date == DateTime.MinValue )
            {
                JMessages.Error("لطفا تاریخ شروع و پایان را وارد کنید", "خطا");
                return false;
            }
            if ( txtEndDate.Date != DateTime.MinValue && txtStartDate.Date > txtEndDate.Date)
            {
                JMessages.Error("لطفا تاریخ شروع و پایان را بصورت صحیح وارد کنید", "خطا");
                return false;
            }
            JSellerOwner owner = new JSellerOwner(_ownerCode);
            owner.PCode = (int)txtPerson.Tag;
            owner.StartDate = txtStartDate.Date;
            owner.EndDate = txtEndDate.Date;
            owner.Code_sellerTicket = _Code;
            owner.Active = chActiveSeller.Checked;
            if (_ownerCode == 0)
            {
                result = owner.Insert() > 0;
            }
            else
            {
                result = owner.Update();
            }
            if (result) LoadSellers();
            btnAddSeller.Text = ClassLibrary.JLanguages._Text("Add");
            _ownerCode = 0;
            return result;
        }

        private void btnAddSeller_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                if (SaveSeller())
                {
                    txtPerson.Tag = 0;
                    txtPerson.Text = "";
                    txtStartDate.Text = "";
                    txtEndDate.Text = "";
                }
                else
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "خطا");
            }
        }
        int _ownerCode;
        private void btnEditOwner_Click(object sender, EventArgs e)
        {
            if (grdSeller.SelectedRow != null)
            {
                _ownerCode = Convert.ToInt32(grdSeller.SelectedRow["Code"]);
                txtPerson.Text = grdSeller.SelectedRow["Name"].ToString();
                JSellerOwner owner = new JSellerOwner(_ownerCode);
                txtPerson.Tag = owner.PCode;
                txtStartDate.Date = owner.StartDate;
                txtEndDate.Date = owner.StartDate;
                chActiveSeller.Checked = owner.Active;
                btnAddSeller.Text = ClassLibrary.JLanguages._Text("Save...");
            }
        }

        private void btnDelSeller_Click(object sender, EventArgs e)
        {
            if (grdSeller.SelectedRow != null)
            {
                if (JMessages.Question("آیا می خواهید باجه دار انتخاب شده حذف شود؟", "حذف؟") == System.Windows.Forms.DialogResult.Yes)
                {
                    _ownerCode = Convert.ToInt32(grdSeller.SelectedRow["Code"]);
                    JSellerOwner owner = new JSellerOwner(_ownerCode);
                    if (owner.Delete())
                        LoadSellers();
                    _ownerCode = 0;
                }
            }
        }

        private void grdSeller_GridRowDoubleClick(object sender, EventArgs e)
        {
        }

        private void grdSeller_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            btnEditSeller.PerformClick();
        }

        private void btnShowOnMap_Click(object sender, EventArgs e)
        {
            PointLatLng point = new PointLatLng(Convert.ToDouble(txtLat.Text), Convert.ToDouble(txtLongs.Text));
            AddMarker(point);
        }

        private double Lat = 0, Lng = 0;
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
            txtLongs.Text = Lng.ToString();
            gMapControl1.Position = point;
            gMapControl1.Update();

        }
    }
}
