using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Windows.Threading;

namespace GMapTestApplication
{
    /// <summary>
    /// Interaction logic for MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        DispatcherTimer timer = null;
        int currentPosition = 0;
        int lastPosition;
        bool isDialog = false;
        MapRoute travelRoute;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public MapControl()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MapControl_Loaded);
            this.MouseDoubleClick += new MouseButtonEventHandler(MapControl_MouseDoubleClick);
            this.PreviewMouseDown += new MouseButtonEventHandler(MapControl_PreviewMouseDown);
        }

        void MapControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void MapControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point point = e.GetPosition(transporterMap);
            PointLatLng latlog = new PointLatLng();
            latlog = transporterMap.FromLocalToLatLng((int)point.X, (int)point.Y);
            this.Latitude = latlog.Lat;
            this.Longitude = latlog.Lng;
        }

        public MapControl(bool isdialog)
        {
            InitializeComponent();
            this.isDialog = isdialog;
            this.Loaded += new RoutedEventHandler(MapControl_Loaded);
        }

        private void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitializeMap();
            this.transporterMap.Position = new PointLatLng(8.50530975053822, 76.9513320922852);
            this.transporterMap.Zoom = 10;
            if (!isDialog)
            {
                this.transporterMap.Zoom = 13;
                this.DrawRoute();
                this.InitializeVehicleDemoTimer();
            }
        }

        private void InitializeMap()
        {
            //GMapProvider.WebProxy = new System.Net.WebProxy("webx.tvm.nestgroup.net", 8080);
            //GMapProvider.WebProxy.Credentials = new System.Net.NetworkCredential(@"uname", "pswd");

            // set cache mode only if no internet avaible
            try
            {
                System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("www.bing.com");
            }
            catch
            {
                transporterMap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection available, going to CacheOnly mode.", "GMap.NET - Demo.WindowsPresentation", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // config map
            transporterMap.MapProvider = GMapProviders.BingMap;

        }

        private List<MapPoint> GetNavRoute()
        {
            List<MapPoint> trivandrumRoute = this.GetTrivandrumKazhakootamRoute();

            return trivandrumRoute;
        }

        /// <summary>
        /// Route from trivandrum to kazhakuttam
        /// </summary>
        /// <returns></returns>
        private List<MapPoint> GetTrivandrumKazhakootamRoute()
        {
            List<MapPoint> mapPoints = new List<MapPoint>();
            MapPoint mapPoint = new MapPoint();
            mapPoint.Location = "Trivandrum";
            PointLatLng latLong = new PointLatLng();
            latLong.Lat = 8.50530975053822;
            latLong.Lng = 76.9513320922852;
            mapPoint.LatLong = latLong;
            mapPoints.Add(mapPoint);

            mapPoint = new MapPoint();
            mapPoint.Location = "Thampanoor";
            latLong = new PointLatLng();
            latLong.Lat = 8.51923092225111;
            latLong.Lng = 76.9417190551758;
            mapPoint.LatLong = latLong;
            mapPoints.Add(mapPoint);

            mapPoint = new MapPoint();
            mapPoint.Location = "Palayam";
            latLong = new PointLatLng();
            latLong.Lat = 8.52958658725011;
            latLong.Lng = 76.9382858276367;
            mapPoint.LatLong = latLong;
            mapPoints.Add(mapPoint);

            mapPoint = new MapPoint();
            mapPoint.Location = "Sreekaryam";
            latLong = new PointLatLng();
            latLong.Lat = 8.52958658725011;
            latLong.Lng = 76.9288444519043;
            mapPoint.LatLong = latLong;
            mapPoints.Add(mapPoint);

            mapPoint = new MapPoint();
            mapPoint.Location = "Chavadimukku";
            latLong = new PointLatLng();
            latLong.Lat = 8.54282784825271;
            latLong.Lng = 76.9233512878418;
            mapPoint.LatLong = latLong;
            mapPoints.Add(mapPoint);

            mapPoint = new MapPoint();
            mapPoint.Location = "Chavadimukku";
            latLong = new PointLatLng();
            latLong.Lat = 8.55572914761792;
            latLong.Lng = 76.9030952453613;
            mapPoint.LatLong = latLong;
            mapPoints.Add(mapPoint);

            mapPoint = new MapPoint();
            mapPoint.Location = "Chavadimukku";
            latLong = new PointLatLng();
            latLong.Lat = 8.56693255306045;
            latLong.Lng = 76.889705657959;
            mapPoint.LatLong = latLong;
            mapPoints.Add(mapPoint);

            mapPoint = new MapPoint();
            mapPoint.Location = "Kazhakuttam";
            latLong = new PointLatLng();
            latLong.Lat = 8.56608382177185;
            latLong.Lng = 76.874942779541;
            mapPoint.LatLong = latLong;
            mapPoints.Add(mapPoint);

            return mapPoints;
        }

        private void DrawRoute()
        {
            List<MapPoint> trivandrumRoute = this.GetNavRoute();

            if (trivandrumRoute.Count > 2)
            {
                PointLatLng start, end;
                RoutingProvider rp = this.transporterMap.MapProvider as RoutingProvider;
                MapRoute route;
                if (rp == null)
                {
                    rp = GMapProviders.GoogleMap; // use google if provider does not implement routing
                }

                for (int i = 0; i < trivandrumRoute.Count - 1; i++)
                {
                    start = trivandrumRoute[i].LatLong;
                    end = trivandrumRoute[i + 1].LatLong;
                    //Get map route
                    route = rp.GetRoute(start, end, false, false, (int)transporterMap.Zoom);
                    if (travelRoute == null)
                    {
                        travelRoute = route;
                    }
                    else
                    {
                        travelRoute.Points.AddRange(route.Points);
                    }

                    if (route != null)
                    {
                        GMapMarker mRoute = new GMapMarker(start);
                        {
                            mRoute.Route.AddRange(route.Points);
                            mRoute.RegenerateRouteShape(this.transporterMap);
                            mRoute.ZIndex = -1;
                        }
                        this.transporterMap.Markers.Add(mRoute);
                    }
                }
            }

            for (int i = 0; i < trivandrumRoute.Count; i++)
            {
                this.PinPointsOnMap(trivandrumRoute[i].LatLong);
            }
        }

        private void PinPointsOnMap(PointLatLng latLong)
        {
            GMapMarker m = new GMapMarker(latLong);
            {
                Placemark p = null;
                {
                    GeoCoderStatusCode status;
                    var plret = GMapProviders.GoogleMap.GetPlacemark(latLong, out status);
                    if (status == GeoCoderStatusCode.G_GEO_SUCCESS && plret != null)
                    {
                        p = plret;
                    }
                }

                string ToolTipText;
                if (p != null)
                {
                    ToolTipText = p.Address;
                }
                else
                {
                    ToolTipText = latLong.ToString();
                }

                m.Shape = new PinMarker(this, m, ToolTipText);
                m.ZIndex = 55;
            }

            transporterMap.Markers.Add(m);
        }

        private void InitializeVehicleDemoTimer()
        {
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += new EventHandler(timer_Tick);
            }
            timer.Start();
        }

        GMapMarker vehicleMarker = new GMapMarker(new PointLatLng(21.453069, 78.297364));
        bool hasStarted = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (travelRoute != null)
            {
                lock (travelRoute)
                {
                    if (!hasStarted)
                    {
                        vehicleMarker = new GMapMarker(travelRoute.Points[currentPosition]);
                        vehicleMarker.Shape = new RotatingEllipse(this, vehicleMarker, string.Format("Start:{0} - {1} ", travelRoute.Name, travelRoute.Points[currentPosition].ToString()));
                        transporterMap.Markers.Add(vehicleMarker);
                        currentPosition++;
                        hasStarted = true;
                    }
                    else
                    {
                        if (currentPosition < travelRoute.Points.Count)
                        {
                            vehicleMarker.Position = travelRoute.Points[currentPosition];
                            //vehicleMarker.Shape = new PinMarker(this, vehicleMarker, string.Format("Start:{0} - {1} ", route.Name, route.Points[currentPosition].ToString()));
                            {
                                RotatingEllipse marker = vehicleMarker.Shape as RotatingEllipse;
                                marker.userControl = this;
                                marker.Marker = vehicleMarker;
                                //marker.LableText = string.Format("Start:{0} - {1} ", travelRoute.Name, travelRoute.Points[currentPosition].ToString());
                            }
                            currentPosition++;
                        }
                        else
                        {
                            timer.Stop();
                        }

                    }
                }
            }
        }
    }

    public class MapPoint
    {
        string location;
        string latitude;
        PointLatLng latLong;

        public PointLatLng LatLong
        {
            get { return latLong; }
            set { latLong = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
