using NUnit.Framework;

namespace TheProject.Test.Unit
{
    public class LocationTest
    {
        [Test]
        public void DistanceBetweenSameLocationIsZero()
        {
            var from = new Location(23.0,24.0);
            var to = new Location(23.0,24.0);
            Assert.AreEqual(0,from.Distance(to));
        }

        [Test]
        public void DistanceBetweenOneDegreeEachWay()
        {
            var from = new Location(1.0,1.0);
            var to = new Location(2.0,2.0);
            Assert.AreEqual(128.129,from.Distance(to),.001);
        }

        [Test]
        public void LondonToBristol()
        {
            var from = new Location(51.5656944, -0.10395);
            var to = new Location(51.44931, -2.601203);
            Assert.AreEqual(160.345, from.Distance(to),.001);
        }
    }
}
