
namespace BusManagment.Line
{
    class JLineStationTable : ClassLibrary.JTable
    {
        public int LineCode;
        public int StationCode;
        public bool IsBack;
        public double Priority;

        public JLineStationTable()
            : base("AUTLineStation")
        {
        }
    }
}
