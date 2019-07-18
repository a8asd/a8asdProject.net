using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookRideSteps
    {
        private Customer customer;
        private IEnumerable<DriverLocation> availableDrivers;
        private readonly LuberApi luberApi = new LuberApi();

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
                luberApi.AddDriver(new Driver
                {
                    Name = input.Name,
                    Location = new LuberLocation(input.Latitude, input.Longitude)
                });
            }
        }

        [When(@"Charlie asks for the available drivers list")]
        public void WhenCharlieAsksForTheAvailableDriversList()
        {
            availableDrivers = luberApi.getDriverLocationsList(customer.Location);
        }

        [Then(@"these drivers are displayed")]
        public void ThenTheseDriversAreDisplayed(Table table)
        {
            table.CompareToSet(availableDrivers);
        }
    }

    public class DriverInput
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
