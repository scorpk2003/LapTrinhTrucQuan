using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongTro.src.Models;
using GMap.NET.WindowsForms.Markers;

namespace QuanLyPhongTro.src.Components
{
    public partial class ucMap : UserControl
    {
        private GMapControl mapControl { get; set; } = new();
        private GMapOverlay? markerOverlay { get; set; }

        private List<PointLatLng> Point { get; set; } = new();
        public ucMap()
        {
            InitializeComponent();
            Mediator.Mediator.Instance.Register<List<ListRoom>>(Name, async (lr) =>
            {
                foreach (var room in lr)
                {
                    OpenStreetMapProvider provider = OpenStreetMapProvider.Instance;
                    Point.Add(provider.GetPoint(room.Address, out GeoCoderStatusCode code)!.Value);
                    if (code != GeoCoderStatusCode.G_GEO_SUCCESS)
                    {
                        MessageBox.Show("Địa chỉ không tồn tại!!!");
                        return;
                    }
                }
                await Task.CompletedTask;
            });
        }

        private void ucMap_Load(object sender, EventArgs e)
        {
            mapControl.MapProvider = OpenStreetMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            mapControl.MinZoom = 2;
            mapControl.MaxZoom = 18;
            mapControl.Zoom = 5;

            mapControl.Position = Point.First();

            markerOverlay = new GMapOverlay("markers");
            mapControl.Overlays.Add(markerOverlay);
            mapControl.OnMarkerClick += OnMarkerClick;

            foreach (var markpoint in Point)
            {
                var marker = new GMarkerGoogle(markpoint!, GMarkerGoogleType.lightblue_dot);
            }

            this.Controls.Add(mapControl);
        }

        private void OnMarkerClick(GMapMarker marker, MouseEventArgs e)
        {
        }
    }

}
