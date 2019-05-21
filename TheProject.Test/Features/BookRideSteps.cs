using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookRideSteps
    {
        private Booking booking;
        private Customer pat;
        private Driver charlie;

        [Given(@"(.*) is a registered customer")]
        public void GivenARegisteredCustomer(string name)
        {
            pat = new Customer() {Name = name};
        }
        
        [Given(@"(.*) is an available driver")]
        public void GivenAnAvailableDriver(string name)
        {
            charlie = new Driver() {Name = name};
        }
        
        [When(@"(.*) books a ride with Charlie")]
        public void WhenSomeoneBooksARide(string customerName)
        {
            booking = new Booking {Customer = pat, Driver = charlie};
        }
        
        [Then(@"Charlie is booked to Pat")]
        public void ThenCharlieIsBookedToPat()
        {
            Assert.AreEqual(pat, booking.Customer);
            Assert.AreEqual(charlie, booking.Driver);
        }
    }

    public class Driver
    {
        public string Name { get; internal set; }
    }

    public class Customer
    {
        public string Name { get; internal set; }
    }

    public class Booking
    {
        public Customer Customer { get; internal set; }
        public Driver Driver { get; internal set; }
    }
}
