using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookRideSteps
    {
        private Customer customer;
        private Driver driver;
        private Booking booking;
        private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();

        [Given(@"(.*) is a registered customer")]
        public void GivenIsARegisteredCustomer(string name)
        {
            customers.Add(name, new Customer {Name = name});
        }
        
        [Given(@"(.*) is an available driver")]
        public void GivenIsAnAvailableDriver(string name)
        {
            drivers.Add(name, new Driver { Name = name });
        }
        
        [When(@"(.*) books a ride with (.*)")]
        public void WhenCustomerBooksARideWithDriver(string customerName, string driverName)
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
            Assert.AreEqual(customerName, booking.Customer.Name);
            Assert.AreEqual(driverName, booking.Driver.Name);
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
