using NUnit.Framework;
using System;
using TheProject.Models;

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
            Location location = new Location(AnyLatitude, AnyLongitude);
            Assert.AreEqual(AnyLatitude, location.Latitude);
            Assert.AreEqual(AnyLongitude, location.Longitude);
        }

        [Test]
        public void CreatingLocationWithInvalidLatThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Location(AnyInvalidLatitude, AnyLongitude));
        }

        [Test]
        public void CreatingLocationWithInvalidLongThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Location(AnyLatitude, AnyInvalidLong));
        }

        [Test]
        public void DistanceFromReturnsDistanceBetweenTwoLocations()
        {
            Location location1 = new Location(AnyLatitude, AnyLongitude);
            Location location2 = new Location(70, 70);
            Assert.AreEqual(2840.121, location1.DistanceFrom(location2));
        }

    }
}
