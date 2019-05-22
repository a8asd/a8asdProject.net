using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookRideSteps
    {
        private Customer pat;
        private Driver charlie;
        private Booking booking;
        private Dictionary<string,Customer> customers = new Dictionary<string, Customer>();
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();

        [Given(@"(.*) is a registered customer")]
        public void GivenPatIsARegisteredCustomer(string name)
        {
            customers[name] = new Customer() {Name = name};
        }
        
        [Given(@"(.*) is an available driver")]
        public void GivenIsAnAvailableDriver(string name)
        {
            drivers[name] = new Driver() {Name = name};
        }
        
        [When(@"(.*) books a ride with (.*)")]
        public void WhenPatBooksARideWithCharlie(string customerName, string driverName)
        {
            booking = new Booking
            {
                Customer = customers[customerName],
                Driver = drivers[driverName]
            };
        }
        
        [Then(@"a booking exists between (.*) and (.*)")]
        public void ThenABookingExistsBetweenPatAndCharlie(string customerName, string driverName)
        {
            Assert.AreEqual(customers[customerName].Name, booking.Customer.Name);
            Assert.AreEqual(drivers[driverName].Name, booking.Driver.Name);
        }
    }

    internal class Booking
    {
        internal Customer Customer;
        internal Driver Driver;
    }

    internal class Driver
    {
        public string Name { get; set; }
    }

    internal class Customer
    {
        public string Name { get; set; }
    }
}
