using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace ClassLibrary
{
    public class JMapObject
    {
        public JMapObject()
        {
        }
        public JMapObject(string ID, string Name, List<JMarkerInfo> Markers, List<JRouteInfo> Routes)
        {
            this.ID = ID;
            this.Name = Name;
            this.Markers = Markers == null ? new List<JMarkerInfo>() : Markers;
            this.Routes = Routes == null ? new List<JRouteInfo>() : Routes;
        }
        public string ID;
        public string Name;
        public List<JMarkerInfo> Markers = new List<JMarkerInfo>();
        public List<JRouteInfo> Routes = new List<JRouteInfo>();
        public List<JMapPoint> Points = new List<JMapPoint>();
        public Pen PointsStrokeStyle;
        public JAction PointsAction;
        public List<Tuple<DateTime, DateTime>> DateTimeLimit;
    }
    public class JMapPoint
    {
        public JMapPoint()
        {
        }
        public JMapPoint(PointLatLng Point, DateTime Date)
        {
            this.Point = Point;
            this.Date = Date;
        }
        public PointLatLng Point;
        public DateTime Date = DateTime.Now;
    }
    public class JRouteInfo
    {
        public JRouteInfo()
        {
        }
        public JRouteInfo(string Title, PointLatLng StartPoint, PointLatLng EndPoint, Pen StrokeStyle, List<JAction> Actions, DateTime Date)
        {
            this.Title = Title;
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
            this.StrokeStyle = StrokeStyle;
            this.Actions = Actions;
            this.Date = Date;
        }
        public string Title;
        public PointLatLng StartPoint;
        public PointLatLng EndPoint;
        public Pen StrokeStyle;
        public List<JAction> Actions;
        public DateTime Date = DateTime.Now;
    }
    public class JMarkerInfo
    {
        public JMarkerInfo()
        {
        }
        public JMarkerInfo(string ToolTipText, PointLatLng Point, List<JAction> Actions, Bitmap Icon, DateTime Date)
        {
            this.ToolTipText = ToolTipText;
            this.Point = Point;
            this.Actions = Actions;
            this.Icon = Icon;
            this.Date = Date;
        }
        public string ToolTipText;
        public PointLatLng Point;
        public List<JAction> Actions;
        public Bitmap Icon;
        public DateTime Date = DateTime.Now;
    }

    public partial class JMapViewer : UserControl
    {
        public event EventHandler<PointLatLng> OnNewPosition;
        public event EventHandler<PointLatLng> OnMouseClick;
        public event EventHandler<PointLatLng> OnMouseDoubleClick;

        public double Lat = 0, Lng = 0;
        private List<JMapObject> objects;
        public List<JMapObject> Objects
        {
            get
            {
                if (objects == null) objects = new List<JMapObject>();
                return objects;
            }
            set
            {
                objects = value;
            }
        }

        public JMapViewer()
        {
            InitializeComponent();
            gMapControl1.OnPositionChanged += gMapControl1_OnPositionChanged;

            gMapControl1.MouseClick += gMapControl1_MouseClick;
            gMapControl1.MouseDoubleClick += gMapControl1_MouseDoubleClick;
        }

        void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                OnMouseDoubleClick(this, new PointLatLng(Lat, Lng));
            }
        }

        void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                OnMouseClick(this, new PointLatLng(Lat, Lng));
            }
        }

        void gMapControl1_OnPositionChanged(PointLatLng point)
        {
            Lat = point.Lat;
            Lng = point.Lng;
            PointLatLng p = new PointLatLng(Lat, Lng);
            OnNewPosition(this, p);
        }

        public void InitializeMap(string PositionByKeyword = "", GMap.NET.MapProviders.GMapProvider gMapProvider = null)
        {
            // Initialize map:
            if (gMapProvider == null) gMapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl1.MapProvider = gMapProvider;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            if (PositionByKeyword.Length > 0) gMapControl1.SetPositionByKeywords(PositionByKeyword);
        }

        public void SetPosition(PointLatLng Position, int Zoom = 0)
        {
            gMapControl1.Position = Position;
            if (Zoom > 0)
                gMapControl1.Zoom = Zoom;
        }

        public JMapObject GetObject(string ID)
        {
            var q = Objects.Where(m => m.ID == ID);
            if (q.Count() > 0)
                return q.First();
            return null;
        }

        public void AddMarker(string ToolTipText, string MarkerID, PointLatLng Position, GMarkerGoogleType MarkerImage = GMarkerGoogleType.green)
        {
            GMapOverlay markersOverlay = new GMapOverlay(MarkerID);
            GMarkerGoogle marker = new GMarkerGoogle(Position, MarkerImage);
            marker.ToolTipText = ToolTipText;
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);
        }
        public void AddMarker(string ToolTipText, string MarkerID, PointLatLng Position, Bitmap MarkerImage)
        {
            GMapOverlay markersOverlay = new GMapOverlay(MarkerID);
            GMarkerGoogle marker = new GMarkerGoogle(Position, MarkerImage);
            marker.ToolTipText = ToolTipText;
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);
        }

        public void DeleteRoute(string MarkerName)
        {
            DeleteMarker(MarkerName);
        }
        public void DeleteMarker(string MarkerName)
        {
            try
            {
                gMapControl1.Overlays.Remove(gMapControl1.Overlays.Where(m => m.Id == MarkerName).First());
            }
            catch { }
        }

        public void AddRoute(string RouteTitle, string RouteID, PointLatLng startPoint, PointLatLng endPoint, Pen StrokeStyle)
        {
            PointLatLng start = new PointLatLng(startPoint.Lat, startPoint.Lng);
            PointLatLng end = new PointLatLng(endPoint.Lat, endPoint.Lng);
            MapRoute route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(
              start, end, false, false, 15);
            GMapRoute r = new GMapRoute(route.Points, RouteTitle);
            GMapOverlay routesOverlay = new GMapOverlay(RouteID);
            if (StrokeStyle != null)
                r.Stroke = StrokeStyle;
            routesOverlay.Routes.Add(r);
            gMapControl1.Overlays.Add(routesOverlay);
        }

        public void AddMarkersRoute(string MarkerID_A, string MarkerID_B, string RouteTitle, string RouteID, Pen StrokeStyle)
        {
            var q = gMapControl1.Overlays.Where(m => m.Id == MarkerID_A);
            if (q.Count() == 0) return;
            GMapOverlay markerA = q.First();
            q = gMapControl1.Overlays.Where(m => m.Id == MarkerID_B);
            if (q.Count() == 0) return;
            GMapOverlay markerB = q.First();
            AddRoute(RouteTitle, RouteID, markerA.Markers[0].Position, markerB.Markers[0].Position, StrokeStyle);
        }

        public void AddPolygon(string PolygonID, List<PointLatLng> points, Pen StrokeStyle = null, Brush FillStyle = null)
        {
            if (FillStyle == null) FillStyle = new SolidBrush(Color.FromArgb(50, Color.Red));
            if (StrokeStyle == null) StrokeStyle = new Pen(Color.Red, 1);
            GMapOverlay polyOverlay = new GMapOverlay(PolygonID);
            GMapPolygon polygon = new GMapPolygon(points, "_" + PolygonID);
            polygon.Fill = FillStyle;
            polygon.Stroke = StrokeStyle;
            polyOverlay.Polygons.Add(polygon);
            gMapControl1.Overlays.Add(polyOverlay);
        }

        public double GetDistance(string RouteID)
        {
            try
            {
                // Distance in Kilometer
                return gMapControl1.Overlays.Where(m => m.Id == RouteID).First().Routes.First().Distance;
            }
            catch
            {
                return 0;
            }
        }

        public void ClearAllOverlays()
        {
            gMapControl1.Overlays.Clear();
        }

        public void RefreshObjects()
        {
            ClearAllOverlays();
            if (Objects != null)
                foreach (JMapObject item in Objects)
                {
                    if (item.Routes != null)
                        for (int i = 0; i < item.Routes.Count; i++)
                        {
                            JRouteInfo route = item.Routes[i];
                            if (CheckDate(route.Date, item.ID))
                                AddRoute(route.Title, item.ID + "|Route|" + i.ToString(), route.StartPoint, route.EndPoint, route.StrokeStyle);
                        }
                    if (item.Markers != null)
                        for (int i = 0; i < item.Markers.Count; i++)
                        {
                            JMarkerInfo marker = item.Markers[i];
                            if (CheckDate(marker.Date, item.ID))
                                AddMarker(marker.ToolTipText, item.ID + "|Marker|" + i.ToString(), marker.Point, marker.Icon);
                        }
                    if (item.Points != null && item.Points.Count > 1)
                    {
                        for (int i = 0; i < item.Points.Count - 1; i++)
                        {
                            JMapPoint mapPoint_A = item.Points[i];
                            JMapPoint mapPoint_B = item.Points[i + 1];
                            if (CheckDate(mapPoint_A.Date, item.ID) && CheckDate(mapPoint_B.Date, item.ID))
                                AddRoute("", item.ID + "|Point|" + i.ToString(), mapPoint_A.Point, mapPoint_B.Point, item.PointsStrokeStyle);
                        }
                    }
                }
        }

        public bool CheckDate(DateTime Date, string ObjectID)
        {
            var q = Objects.Where(m => m.ID == ObjectID);
            List<Tuple<DateTime, DateTime>> DTLimit = q.First().DateTimeLimit;
            if (DTLimit != null)
                foreach (Tuple<DateTime, DateTime> limit in DTLimit)
                {
                    if (Date >= limit.Item1 && Date < limit.Item2)
                        return true;
                }
            else
                return true;
            return false;
        }

        void gMapControl1_OnRouteLeave(GMap.NET.WindowsForms.GMapRoute item)
        {
            RunAction(item.Overlay.Id, "RouteLeave");
        }

        void gMapControl1_OnRouteEnter(GMap.NET.WindowsForms.GMapRoute item)
        {
            RunAction(item.Overlay.Id, "RouteEnter");
        }

        void gMapControl1_OnRouteClick(GMap.NET.WindowsForms.GMapRoute item, System.Windows.Forms.MouseEventArgs e)
        {
            RunAction(item.Overlay.Id, "RouteClick");
        }

        void gMapControl1_OnMarkerLeave(GMap.NET.WindowsForms.GMapMarker item)
        {
            RunAction(item.Overlay.Id, "MarkerLeave");
        }

        void gMapControl1_OnMarkerEnter(GMap.NET.WindowsForms.GMapMarker item)
        {
            RunAction(item.Overlay.Id, "MarkerEnter");
        }

        void gMapControl1_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, System.Windows.Forms.MouseEventArgs e)
        {
            RunAction(item.Overlay.Id, "MarkerClick");
        }

        private void RunAction(string ID, string EventName)
        {
            string[] str = ID.Split('|');
            var q = Objects.Where(m => m.ID == str[0]);
            if (q.Count() > 0)
            {
                if (str[1] == "Route")
                {
                    if (q.First().Routes[Convert.ToInt32(str[2])].Actions != null)
                    {
                        var p = q.First().Routes[Convert.ToInt32(str[2])].Actions.Where(m => m.Name == EventName);
                        if (p.Count() > 0)
                        {
                            JAction action = p.First();
                            action.AddArg(ID);
                            action.run();
                        }
                    }
                }
                if (str[1] == "Marker")
                {
                    if (q.First().Markers.ElementAt(Convert.ToInt32(str[2])).Actions != null)
                    {
                        var p = q.First().Markers.ElementAt(Convert.ToInt32(str[2])).Actions.Where(m => m.Name == EventName);
                        if (p.Count() > 0)
                        {
                            JAction action = p.First();
                            action.AddArg(ID);
                            action.run();
                        }
                    }
                }
                if (str[1] == "Point")
                {
                    var p = q.First().PointsAction;
                    if (p != null)
                    {
                        JAction action = p;
                        action.AddArg(ID);
                        action.run();
                    }
                }
            }
        }
    }
}
