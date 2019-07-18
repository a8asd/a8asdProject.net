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
        private IEnumerable<Driver> availableDrivers;

        [Given(@"(.*) is a customer at (.*), (.*)")]
        public void GivenCharlieIsACustomerAt(string name, double latitude, double longitude)
        {
            customer = new Customer {Name = name,Location = new LuberLocation(latitude,longitude)};
        }
        
        [Given(@"(.*) is a driver at (.*), (.*)")]
        public void GivenDaniIsADriverAt(string name, double latitude, double longitude)
        {
            var driver = new Driver {Name = name, TimeToPickup = 20, Location = new LuberLocation(latitude, longitude)};
            driver.TimeToPickup = (int) driver.Location.Distance(customer.Location);
            drivers.Add(driver);
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

        public IEnumerable<Driver> getDriverLocationsList(LuberLocation customerLocation)
        {
            return drivers;
        }
    }
}
