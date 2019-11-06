using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gherkin.Events.Args.Pickle;
using NUnit.Framework;

namespace TheProject.Test.Unit
{
    public class LocationTest
    {
        private const int AnyLatitude = 50;
        private const int AnyLongitude = 50;
        private const int AnyInvalidLatitude = 91;
        private const int AnyInvalidLong = 181;

        [Test]
        public void CreatingLocationWithValidLatAndLong()
        {
            TddLocation location = new TddLocation(AnyLatitude, AnyLongitude);
            Assert.AreEqual(AnyLatitude, location.Latitude);
            Assert.AreEqual(AnyLongitude, location.Longitude);
        }

        [Test]
        public void CreatingLocationWithInvalidLatThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TddLocation(AnyInvalidLatitude, AnyLongitude));
        }

        [Test]
        public void CreatingLocationWithInvalidLongThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TddLocation(AnyLatitude, AnyInvalidLong));
        }

        [Test]
        public void DistanceFromReturnsDistanceBetweenTwoLocations()
        {
            TddLocation location1 = new TddLocation(AnyLatitude, AnyLongitude);
            TddLocation location2 = new TddLocation(70, 70);
            Assert.AreEqual(2840.121, location1.DistanceFrom(location2));
        }

    }

    public class TddLocation
    {
        private const int MinLat = -90;
        private const int MaxLat = 90;
        private const int MinLong = 180;
        private const int MaxLong = 180;
        private const double LatToKMMultiplier = 111.045;
        private const double LongToKMMultiplier = 88.514;
        private const int Accuracy = 3;

        public TddLocation(int latitude, int longitude)
        {
            if (latitude <= MinLat || latitude > MaxLat || longitude <= -MinLong || longitude > MaxLong)
                throw new ArgumentOutOfRangeException();
            Latitude = latitude;
            Longitude =longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double DistanceFrom(TddLocation location2)
        {
            double latDelta = (Latitude  - location2.Latitude) * LatToKMMultiplier;
            double longDelta =( Longitude - location2.Longitude) * LongToKMMultiplier;
            return Math.Round(Math.Sqrt(latDelta * latDelta + longDelta * longDelta), Accuracy ) ;
        }

    }
}
