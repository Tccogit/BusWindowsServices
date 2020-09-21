
using ClassLibrary;
using System.Data;
namespace BusManagment.Station
{
    public partial class JStationSearchForm : ClassLibrary.JBaseForm
    {
        public JStationSearchForm()
        {
            InitializeComponent();
            LoadStations();
        }

        private void LoadStations()
        {
            grdStation.DataSource = JStations.GetDataTable();
        }

        #region " Fields "

        /// <summary>
        /// ایستگاه انتخاب شده
        /// </summary>
        private JStation _SelectedStation;

        #endregion " Fields "

        #region " Properties "

        /// <summary>
        /// ایستگاه انتخاب شده
        /// </summary>
        public JStation SelectedStation
        {
            get { return _SelectedStation; }
            set { _SelectedStation = value; }
        }
        

        #endregion " Properties "


        private void grdStation_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (grdStation.SelectedRow != null)
            {
                SelectedStation = new JStation();
                if (SelectedStation.GetData(System.Convert.ToInt32(grdStation.SelectedRow.Row["Code"])))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }
         
    }
}
