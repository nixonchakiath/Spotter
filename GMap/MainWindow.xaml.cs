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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GMapMarker currentMarker;
        public MainWindow()
        {
            InitializeComponent();
            this.InitiGMap();
        }

        private void InitiGMap()
        {
            // add your custom map db provider
            //MySQLPureImageCache ch = new MySQLPureImageCache();
            //ch.ConnectionString = @"server=sql2008;User Id=trolis;Persist Security Info=True;database=gmapnetcache;password=trolis;";
            //MainMap.Manager.SecondaryCache = ch;

            // set your proxy here if need
            //GMapProvider.WebProxy = new WebProxy("10.2.0.100", 8080);
            //GMapProvider.WebProxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeada");
            GMapProvider.WebProxy = new System.Net.WebProxy("webx.tvm.nestgroup.net", 8080);
            GMapProvider.WebProxy.Credentials = new System.Net.NetworkCredential(@"uname", "pswd");

            // set cache mode only if no internet avaible
            try
            {
                System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("www.bing.com");
            }
            catch
            {
                MainMap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection available, going to CacheOnly mode.", "GMap.NET - Demo.WindowsPresentation", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // config map
            MainMap.MapProvider = GMapProviders.OpenStreetMap;
            MainMap.Position = new PointLatLng(21.453069, 78.297364);
            MainMap.Zoom = 6;
            
            // map events
            //MainMap.OnPositionChanged += new PositionChanged(MainMap_OnCurrentPositionChanged);
            //MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);
            //MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
            //MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);
            //MainMap.MouseMove += new System.Windows.Input.MouseEventHandler(MainMap_MouseMove);
            //MainMap.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(MainMap_MouseLeftButtonDown);
            //MainMap.Loaded += new RoutedEventHandler(MainMap_Loaded);
            //MainMap.MouseEnter += new MouseEventHandler(MainMap_MouseEnter);

            // get map types
            //comboBoxMapType.ItemsSource = GMapProviders.List;
            //comboBoxMapType.DisplayMemberPath = "Name";
            //comboBoxMapType.SelectedItem = MainMap.MapProvider;

            // acccess mode
            //comboBoxMode.ItemsSource = Enum.GetValues(typeof(AccessMode));
            //comboBoxMode.SelectedItem = MainMap.Manager.Mode;

            // get cache modes
            //checkBoxCacheRoute.IsChecked = MainMap.Manager.UseRouteCache;
            //checkBoxGeoCache.IsChecked = MainMap.Manager.UseGeocoderCache;

            // setup zoom min/max
            //sliderZoom.Maximum = MainMap.MaxZoom;
            //sliderZoom.Minimum = MainMap.MinZoom;

            // get position
            //textBoxLat.Text = MainMap.Position.Lat.ToString(CultureInfo.InvariantCulture);
            //textBoxLng.Text = MainMap.Position.Lng.ToString(CultureInfo.InvariantCulture);

            // get marker state
            //checkBoxCurrentMarker.IsChecked = true;

            // can drag map
            //checkBoxDragMap.IsChecked = MainMap.CanDragMap;

#if DEBUG
         //checkBoxDebug.IsChecked = true;
#endif

            //validator.Window = this;

            // set current marker
            currentMarker = new GMapMarker(MainMap.Position);
            {
                currentMarker.Shape = new RotatingEllipse(this, currentMarker, "India");
                currentMarker.Offset = new System.Windows.Point(-15, -15);
                currentMarker.ZIndex = int.MaxValue;
                MainMap.Markers.Add(currentMarker);
            }

            ////if(false)
            //{
            //    // add my city location for demo
            //    GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;

            //    PointLatLng? city = GMapProviders.GoogleMap.GetPoint("INDIA", out status);
            //    if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            //    {
            //        GMapMarker it = new GMapMarker(city.Value);
            //        {
            //            it.ZIndex = 55;
            //            it.Shape = new CustomMarkerDemo(this, it, "Welcome to India");
            //        }
            //        MainMap.Markers.Add(it);

            //        #region -- add some markers and zone around them --
            //        //if(false)
            //        {
            //            List<PointAndInfo> objects = new List<PointAndInfo>();
            //            {
            //                string area = "Kerala";
            //                PointLatLng? pos = GMapProviders.GoogleMap.GetPoint("India " + area, out status);
            //                if (pos != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            //                {
            //                    objects.Add(new PointAndInfo(pos.Value, area));
            //                }
            //            }
            //            {
            //                string area = "Tamilnadu";
            //                PointLatLng? pos = GMapProviders.GoogleMap.GetPoint("India " + area, out status);
            //                if (pos != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            //                {
            //                    objects.Add(new PointAndInfo(pos.Value, area));
            //                }
            //            }
            //            {
            //                string area = "Goa";
            //                PointLatLng? pos = GMapProviders.GoogleMap.GetPoint("India " + area, out status);
            //                if (pos != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
            //                {
            //                    objects.Add(new PointAndInfo(pos.Value, area));
            //                }
            //            }
            //            AddDemoZone(8.8, city.Value, objects);
            //        }
            //        #endregion
            //    }
            //}

            //// perfromance test
            //timer.Interval = TimeSpan.FromMilliseconds(44);
            //timer.Tick += new EventHandler(timer_Tick);

            //// transport demo
            //transport.DoWork += new DoWorkEventHandler(transport_DoWork);
            //transport.ProgressChanged += new ProgressChangedEventHandler(transport_ProgressChanged);
            //transport.WorkerSupportsCancellation = true;
            //transport.WorkerReportsProgress = true;
        }

        public void MainMap_OnTileLoadStart()
        {
            MessageBox.Show("Started loadding");
        }

        private List<PointLatLng> RoutePoints = new List<PointLatLng>();
        private PointLatLng selectedPoint;

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point point = e.GetPosition(MainMap);
            PointLatLng latlog = new PointLatLng();
            latlog = MainMap.FromLocalToLatLng((int)point.X, (int)point.Y);
            {   //latlog list for routing support
                selectedPoint = latlog;
                RoutePoints.Add(latlog);
            }

            GMapMarker m = new GMapMarker(latlog);
            {
                Placemark p = null;
                //if (checkBoxPlace.IsChecked.Value)
                { //for get place information
                    GeoCoderStatusCode status;
                    var plret = GMapProviders.GoogleMap.GetPlacemark(latlog, out status);
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
                    ToolTipText = latlog.ToString();
                }

                m.Shape = new PinMarker(this, m, ToolTipText);
                m.ZIndex = 55;
            }

            MainMap.Markers.Add(m);
        }

        MapRoute route;
        List<PointLatLng> routePath = new List<PointLatLng>();

        private void ShowRoute_Click(object sender, RoutedEventArgs e)
        {
            if (RoutePoints.Count > 1)
            {
                PointLatLng start = RoutePoints[0];
                PointLatLng end = RoutePoints[1];
                RoutingProvider rp = MainMap.MapProvider as RoutingProvider;
                if (rp == null)
                {
                    rp = GMapProviders.GoogleMap; // use google if provider does not implement routing
                }
                //Start timer 


                for (int i = 0; i < this.RoutePoints.Count - 1; i++)
                {
                    start = RoutePoints[i];
                    end = RoutePoints[i + 1];
                    //Get map route
                    route = rp.GetRoute(start, end, false, false, (int)MainMap.Zoom);
                    routePath.AddRange(route.Points);// Combining path of selected route

                    if (route != null)
                    {
                        GMapMarker mRoute = new GMapMarker(start);
                        {
                            //for show route 
                            mRoute.Route.AddRange(route.Points);
                            mRoute.RegenerateRouteShape(MainMap);

                            //for show polygon
                            //route.Points.Add(route.Points[0]);
                            //mRoute.Polygon.AddRange(route.Points);
                            //mRoute.RegeneratePolygonShape(MainMap);

                            mRoute.ZIndex = -1;
                        }

                        MainMap.Markers.Add(mRoute);
                    }
                }//end of for loop
            }
        }

        DispatcherTimer timer;
        int currentPosition = 0;
        int lastPosition;

        private void InitializeVehicleDemoTimer()
        {
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += new EventHandler(timer_Tick);
            }
        }

        private void StartVehicleDemo()
        {
            this.InitializeVehicleDemoTimer();
            if (route != null)
            {
                lastPosition = route.Points.Count;
                timer.Start();
            }
            else
            {
                MessageBox.Show("Please select a route before start the demo");
            }
        }

        private void StopVehicleDemo()
        {
            timer.Stop();
        }

        GMapMarker vehicleMarker = new GMapMarker(new PointLatLng(21.453069, 78.297364));
        bool hasStarted = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (route != null)
            {
                lock (route)
                {
                    if (!hasStarted)
                    {
                        vehicleMarker = new GMapMarker(route.Points[currentPosition]);
                        vehicleMarker.Shape = new PinMarker(this, vehicleMarker, string.Format("Start:{0} - {1} ", route.Name, route.Points[currentPosition].ToString()));
                        MainMap.Markers.Add(vehicleMarker);
                        currentPosition++;
                        hasStarted = true;
                    }
                    else
                    {
                        vehicleMarker.Position = route.Points[currentPosition];
                        //vehicleMarker.Shape = new PinMarker(this, vehicleMarker, string.Format("Start:{0} - {1} ", route.Name, route.Points[currentPosition].ToString()));
                        {
                            PinMarker marker = vehicleMarker.Shape as PinMarker;
                            marker.MainMap = this;
                            marker.Marker = vehicleMarker;
                            marker.LableText = string.Format("Start:{0} - {1} ", route.Name, route.Points[currentPosition].ToString());
                        }
                        currentPosition++;
                        if (currentPosition >= lastPosition)
                        {
                            currentPosition = 0;
                        }
                    }
                }
            }
        }

        private void GeoLocation_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                GeoCoderStatusCode status = MainMap.SetCurrentPositionByKeywords(GeoLocation.Text);
                if (status != GeoCoderStatusCode.G_GEO_SUCCESS)
                {
                    MessageBox.Show("Google Maps Geocoder can't find: '" + GeoLocation.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    currentMarker.Position = MainMap.Position;
                }
            }
        }

        private void VehicleDemoStop_Click(object sender, RoutedEventArgs e)
        {
            StopVehicleDemo();
        }

        private void VehicleDemoStart_Click(object sender, RoutedEventArgs e)
        {
            StartVehicleDemo();
        }

        private void Polygun_Click(object sender, RoutedEventArgs e)
        {
            if (RoutePoints.Count > 1)
            {
                GMapMarker mRoute = new GMapMarker(RoutePoints[0]);
                {
                    //for show polygon
                    RoutePoints.Add(RoutePoints[0]);
                    mRoute.Polygon.AddRange(RoutePoints);
                   
                    mRoute.RegeneratePolygonShape(MainMap);
                    mRoute.ZIndex = -1;
                }

                MainMap.Markers.Add(mRoute);
            }
        }

        private void DrawPolygun()
        {
            //bool isFirst = true;
            //Point firstPoint = new Point();   
            //if (routePath.Count > 1)
            //{
            //    PointCollection polyPointCollection = new PointCollection();
            //    foreach (PointLatLng latlng in routePath)
            //    {
            //        if (isFirst)
            //        {
            //            firstPoint.X = latlng.Lat;
            //            firstPoint.Y = latlng.Lng;
            //            isFirst = false;
            //        }

            //        polyPointCollection.Add(new Point(latlng.Lat, latlng.Lng));
            //    }

            //    polyPointCollection.Add(firstPoint);
            //    Polygon area = new Polygon();
            //    area.Points = polyPointCollection;
            //    area.Stretch = Stretch.Fill;
            //    area.Stroke = Brushes.Blue;
            //    area.Opacity = .5;

            //}
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            var clear = MainMap.Markers.Where(p => p != null && p != currentMarker);
            if (clear != null)
            {
                for (int i = 0; i < clear.Count(); i++)
                {
                    MainMap.Markers.Remove(clear.ElementAt(i));
                    i--;
                }
            }
        }
    }
}
