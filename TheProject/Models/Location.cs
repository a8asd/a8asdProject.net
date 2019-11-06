using System;

namespace TheProject.Models
{
    public class Location
    {
        private const int MinLat = -90;
        private const int MaxLat = 90;
        private const int MinLong = 180;
        private const int MaxLong = 180;
        private const double LatToKMMultiplier = 111.045;
        private const double LongToKMMultiplier = 88.514;
        private const int Accuracy = 3;

        public Location(double latitude, double longitude)
        {
            if (latitude <= MinLat || latitude > MaxLat || longitude <= -MinLong || longitude > MaxLong)
                throw new ArgumentOutOfRangeException();
            Latitude = latitude;
            Longitude =longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double DistanceFrom(Location location2)
        {
            double latDelta = (Latitude  - location2.Latitude) * LatToKMMultiplier;
            double longDelta =( Longitude - location2.Longitude) * LongToKMMultiplier;
            return Math.Round(Math.Sqrt(latDelta * latDelta + longDelta * longDelta), Accuracy ) ;
        }

    }
}