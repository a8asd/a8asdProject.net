using System;
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

        [Given(@"(.*) is a registered customer")]
        public void GivenPatIsARegisteredCustomer(string name)
        {
            pat = new Customer
            {
                Name = name
            };
        }
        
        [Given(@"(.*) is an available driver")]
        public void GivenCharlieIsAnAvailableDriver(string name)
        {
            charlie = new Driver
            {
                Name = name
            };
        }
        
        [When(@"Pat books a ride with Charlie")]
        public void WhenPatBooksARideWithCharlie()
        {
            booking = new Booking
            {
                Customer = pat,
                Driver = charlie
            };
        }
        
        [Then(@"a booking exists between (.*) and (.*)")]
        public void ThenABookingExistsBetweenPatAndCharlie(string customer, string driver)
        {
            Assert.AreEqual(customer, booking.Customer.Name);
            Assert.AreEqual(driver, booking.Driver.Name);
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
