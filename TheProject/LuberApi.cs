using System.Collections.Generic;

namespace TheProject
{
    public class LuberApi
    {
        private const int MaximumDistance = 30;
        private readonly List<Driver> drivers = new List<Driver>();

        public void AddDriver(Driver driver)
        {
            drivers.Add(driver);
        }

        public IList<DriverLocation> GetDriverLocationsList(Location customerLocation)
        {
            IList<DriverLocation> driverLocations = new List<DriverLocation>();
            foreach (var driver in drivers)
            {
                AddDriverToListIfCloseEnough(customerLocation, driver, driverLocations);
            }
            return driverLocations;
        }

        private static void AddDriverToListIfCloseEnough(Location customerLocation, Driver driver, IList<DriverLocation> driverLocations)
        {
            if (IsDriverCloseEnough(customerLocation, driver))
            {
                driverLocations.Add(
                    new DriverLocation
                    {
                        Name = driver.Name,
                        TimeToPickup = driver.TimeToPickup(customerLocation)
                    });
            }
        }

        private static bool IsDriverCloseEnough(Location customerLocation, Driver driver)
        {
            return driver.Location.Distance(customerLocation) <= MaximumDistance;
        }
    }
}