using System;
using System.Collections.Generic;
using Gherkin.Ast;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookRideSteps
    {
        private Customer customer;
        private List<Driver> drivers = new List<Driver>();

        [Given(@"(.*) is a customer at (.*), (.*)")]
        public void GivenCharlieIsACustomerAt(string name, double p0, double p1)
        {
            customer = new Customer {Name = name,Location = new LuberLocation(p0,p1)};
        }
        
        [Given(@"(.*) is a driver at (.*), (.*)")]
        public void GivenDaniIsADriverAt(string name, double p0, double p1)
        {
            var driver = new Driver {Name = name, TimeToPickup = 20};
            driver.Location = new LuberLocation(p0,p1);
            driver.TimeToPickup = (int) driver.Location.Distance(customer.Location);
            drivers.Add(driver);
        }
        
        [When(@"Charlie asks for the available drivers list")]
        public void WhenCharlieAsksForTheAvailableDriversList()
        {
        }
        
        [Then(@"these drivers are displayed")]
        public void ThenTheseDriversAreDisplayed(Table table)
        {
            table.CompareToSet(getDriverLocationsList(customer.Location));
        }

        public IEnumerable<Driver> getDriverLocationsList(LuberLocation customerLocation)
        {
            return drivers;
        }
    }

    public class Driver
    {
        public string Name { get; set; }
        public int TimeToPickup { get; set; }
        public LuberLocation Location { get; set; }
    }

    internal class Customer
    {
        public LuberLocation Location { get; set; }
        public string Name { get; set; }
    }

    public class LuberLocation
    {
        private readonly double lat;
        private readonly double lon;

        public LuberLocation(double lat, double lon)
        {
            this.lat = lat;
            this.lon = lon;
        }

        public double Distance(LuberLocation to)
        {
            var lt = (to.lat - lat)*111;
            var ln = (to.lon - lon)*64;
            return Math.Sqrt((lt*lt)+(ln*ln));
        }
    }
}
