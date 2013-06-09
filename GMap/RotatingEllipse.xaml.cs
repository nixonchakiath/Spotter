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
using GMap.NET.WindowsPresentation;
using System.Windows.Controls.Primitives;

namespace GMapTestApplication
{
    /// <summary>
    /// Interaction logic for RotatingEllipse.xaml
    /// </summary>
    public partial class RotatingEllipse : UserControl
    {
         #region Private Members
        private MainWindow MainMap;
        public UserControl userControl;
        public GMapMarker Marker;
        private Popup popup = new Popup();
        private Label lable = new Label();
        #endregion
        
        public RotatingEllipse()
        {
            InitializeComponent();
        }

        #region Public Methods
        public RotatingEllipse(MainWindow mainMap, GMapMarker marker,string title)
        {
            InitializeComponent();

            this.MainMap = mainMap;
            this.Marker = marker;

            popup.Placement = PlacementMode.Mouse;
            {
                lable.Background = Brushes.Blue;
                lable.Foreground = Brushes.White;
                lable.BorderBrush = Brushes.WhiteSmoke;
                lable.BorderThickness = new Thickness(2);
                lable.Padding = new Thickness(5);
                lable.FontSize = 22;
                lable.Content = title;
            }
            popup.Child = lable;
        }

        public RotatingEllipse(UserControl mainMap, GMapMarker marker, string title)
        {
            InitializeComponent();

            this.userControl = mainMap;
            this.Marker = marker;

            popup.Placement = PlacementMode.Mouse;
            {
                lable.Background = Brushes.Blue;
                lable.Foreground = Brushes.White;
                lable.BorderBrush = Brushes.WhiteSmoke;
                lable.BorderThickness = new Thickness(2);
                lable.Padding = new Thickness(5);
                lable.FontSize = 22;
                lable.Content = title;
            }
            popup.Child = lable;
        }
        #endregion

        #region EventHandlers
        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
      

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            popup.IsOpen = true;
        }  
        #endregion
    }
}
