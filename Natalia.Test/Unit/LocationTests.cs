using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Gherkin.Events.Args.Pickle;
using NUnit.Framework;

namespace Natalia.Test.Unit
{
    public class LocationTests
    {
        private const double ValidLatitude = 50.0000;
        private const double ValidLongitude = 0.00000;
        private const int InvalidNegativeLatitude = -91;
        private const int InvalidPositiveLatitude = 91;

        [Test]
        public void ConstructorSetsLatitudeAndLongitude()
        {
            TddLocation x = new TddLocation(ValidLatitude, ValidLongitude);
            Assert.AreEqual(x.Latitude, ValidLatitude);
            Assert.AreEqual(x.Longitude, ValidLongitude);
        }

        [Test]
        public void ConstructorThrowsInvalidArgumentExceptionIfPassedLatitudeIsInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                TddLocation tddLocation = new TddLocation(InvalidNegativeLatitude, ValidLongitude);
            });
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                TddLocation tddLocation = new TddLocation(InvalidPositiveLatitude, ValidLongitude);
            });
        }

        [Test]
        public void ConstructorThrowsInvalidArgumentExceptionIfPassedLongitudeIsInvalid()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new TddLocation(ValidLatitude, -181));
            Assert.Throws<ArgumentOutOfRangeException>(() => new TddLocation(ValidLatitude, 181));
        }

        [Test]
        public void ConstrutorAcceptsBoundaryLatitude()
        {
            var a = new TddLocation(90, ValidLongitude);
            var b = new TddLocation(-90, ValidLongitude);
            Assert.True(true);
        }

        [Test]
        public void ConstructorAcceptsBoundaryLongitude()
        {
            var a = new TddLocation(ValidLatitude, 180);
            var b = new TddLocation(ValidLatitude, -180);
            Assert.True(true);
        }

        [Test]
        public void DistanceFromReturnsCorrectlyForSameValue()
        {
            var a = new TddLocation(ValidLatitude, ValidLongitude);
            var b = new TddLocation(ValidLatitude, ValidLongitude);
            var distance = a.DistanceFrom(b);
            Assert.AreEqual(0, distance);
        }

        [Test]
        public void DistanceFromReturnsExpectedValue()
        {
            TddLocation point1 = new TddLocation(ValidLatitude, ValidLongitude);
            TddLocation point2 = new TddLocation(ValidLatitude + 1, ValidLongitude);
            Assert.AreEqual(point1.DistanceFrom(point2), (decimal)111.045);

        }
    }
}
