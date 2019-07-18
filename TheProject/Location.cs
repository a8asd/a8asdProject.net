using System;

namespace TheProject
{
    public class Location
    {
        private readonly double latitude;
        private readonly double longitude;

        public Location(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public double Distance(Location to)
        {
            var lt = (to.latitude - latitude)*111;
            var ln = (to.longitude - longitude)*64;
            return Math.Sqrt((lt*lt)+(ln*ln));
        }
    }
}