using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookRideSteps
    {
        private Customer customer;
        private readonly List<Driver> drivers = new List<Driver>();
        private IEnumerable<DriverLocation> availableDrivers;

        [Given(@"(.*) is a customer at (.*), (.*)")]
        public void GivenCharlieIsACustomerAt(string name, double latitude, double longitude)
        {
            customer = new Customer { Name = name, Location = new LuberLocation(latitude, longitude) };
        }

        [Given(@"these drivers are available")]
        public void GivenTheseDrivers(Table table)
        {
            var inputs = table.CreateSet<DriverInput>();
            foreach (var input in inputs)
            {
                drivers.Add(new Driver
                {
                    Name = input.Name,
                    Location = new LuberLocation(input.Latitude,input.Longitude)
                });
            }
        }

        [When(@"Charlie asks for the available drivers list")]
        public void WhenCharlieAsksForTheAvailableDriversList()
        {
            availableDrivers = getDriverLocationsList(customer.Location);
        }

        [Then(@"these drivers are displayed")]
        public void ThenTheseDriversAreDisplayed(Table table)
        {
            table.CompareToSet(availableDrivers);
        }

        public IList<DriverLocation> getDriverLocationsList(LuberLocation customerLocation)
        {
            IList<DriverLocation> driverLocations = new List<DriverLocation>();
            foreach (var driver in drivers)
            {
                if (driver.Location.Distance(customer.Location) <= 30)
                {
                    driverLocations.Add(
                        new DriverLocation
                        {
                            Name = driver.Name,
                            TimeToPickup = driver.TimeToPickup(customer.Location)
                        });
                }
            }
            return driverLocations;
        }
    }

    public class DriverInput
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
