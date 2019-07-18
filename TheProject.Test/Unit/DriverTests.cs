using NUnit.Framework;

namespace TheProject.Test.Unit
{
    public class DriverTests
    {
        [Test]
        public void TimeToPickupFromHereIsZero()
        {
            var location = new LuberLocation(53,0);
            var driver = new Driver {Location = new LuberLocation(53, 0)};
            Assert.AreEqual("0m 0s",driver.TimeToPickup(location));
        }

        [Test]
        public void TimeToPickupFromHereInMinutesAndSeconds()
        {
            var location = new LuberLocation(53, 0);
            var driver = new Driver { Location = new LuberLocation(53,0.1) };
            Assert.AreEqual("6m 24s", driver.TimeToPickup(location));
        }
    }
    }
