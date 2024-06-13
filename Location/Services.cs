using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location
{
    public class Services
    {
        GeoCoordinateWatcher watcher;

        public void GetLocationEvent()
        {
            this.watcher = new GeoCoordinateWatcher();
            this.watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
            if (!started)
            {
                Console.WriteLine("GeoCoordinateWatcher start.");
            }
        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            PrintPosition(e.Position.Location.Latitude, e.Position.Location.Longitude);
        }

        private void PrintPosition(double Latitude, double Longitude)
        {
            Console.WriteLine("Latitude: {0}, Longitude {1}", Latitude, Longitude);
        }
    }
}
