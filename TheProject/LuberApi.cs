using System.Collections.Generic;

namespace TheProject
{
    public class LuberApi
    {
        private readonly List<Driver> drivers = new List<Driver>();

        public void AddDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public IList<DriverLocation> getDriverLocationsList(LuberLocation customerLocation)
        {
            IList<DriverLocation> driverLocations = new List<DriverLocation>();
            foreach (var driver in drivers)
            {
                if (driver.Location.Distance(customerLocation) <= 30)
                {
                    driverLocations.Add(
                        new DriverLocation
                        {
                            Name = driver.Name,
                            TimeToPickup = driver.TimeToPickup(customerLocation)
                        });
                }
            }
            return driverLocations;
        }
    }
}