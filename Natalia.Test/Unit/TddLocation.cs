using System;
using NUnit.Framework.Constraints;

namespace Natalia.Test.Unit
{
    internal class TddLocation
    {
        private const int MaxLatitude = 90;
        private const int MinLatitude = -90;
        private const int MaxLongitude = 180;
        private const int MinLongitude = -180;

        public TddLocation(double latitude, double longitude)
        {
            if (latitude > MaxLatitude)
                throw  new ArgumentOutOfRangeException(nameof(latitude), $"Latitude cannot be over {MaxLatitude}");
            if (latitude < MinLatitude)
                throw new ArgumentOutOfRangeException(nameof(latitude), $"Latitude cannot be under {MinLatitude}");
            if (longitude > MaxLongitude)
                throw new ArgumentOutOfRangeException(nameof(latitude), $"Longitude cannot be over {MaxLongitude}");
            if (longitude < MinLongitude)
                throw new ArgumentOutOfRangeException(nameof(latitude), $"Longitude cannot be under {MinLongitude}");
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }

        /// <summary>
        /// returns the distance in meters between this
        /// Location and the given one.
        /// </summary>
        /// <param name="tddLocation"></param>
        /// <returns></returns>
        public decimal DistanceFrom(TddLocation tddLocation)
        {
            var la1 = Math.Abs(this.Latitude - tddLocation.Latitude);
            var la2 = Math.Abs(tddLocation.Latitude - this.Latitude);
            var lo1 = Math.Abs(this.Longitude - tddLocation.Longitude);
            var lo2 = Math.Abs(tddLocation.Longitude - this.Longitude);

            var latDiff = la1 < la2 ? la1 : la2;
            var longDiff = lo1 < lo2 ? lo1 : lo2;

            var latDist = latDiff * 111.045;
            var longDist = longDiff * 88.541;
            var x = (latDist * latDist) + (longDist * longDist);
            return Math.Round((decimal)Math.Sqrt(x), 3) ;
        }
    }
}