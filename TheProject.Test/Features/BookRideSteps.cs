using System;
using System.Data.SqlTypes;
using NUnit.Core;
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
           pat = new Customer {Name = name};
        }

        [Given(@"(.*) is a available driver")]
        public void GivenCharlieIsAAvailableDriver(string name)
        {
            charlie = new Driver{Name = name};
    }
        
        [When(@"Pat books a ride")]
        public void WhenPatBooksARide()
        {
           booking = new Booking();
           booking.Customer = pat;
           booking.Driver = charlie;
        }
        
        [Then(@"Charlie is Pat's driver")]
        public void ThenCharlieIsPatSDriver()
        {
            Assert.AreEqual(pat, booking.Customer);
            Assert.AreEqual(charlie, booking.Driver);
        }
    }

    public class Booking
    {
        public Driver Driver { get; set; }
        public Customer Customer { get; set; }
    }

    public class Driver
    {
        public string Name { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}
