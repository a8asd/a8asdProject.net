using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookRideSteps
    {
        private Customer customer;
        private Driver driver;
        private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();
        private List<Booking> bookings = new List<Booking>();

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
            Booking booking = new Booking
            {
                Customer = customers[customerName],
                Driver = drivers[driverName]
            };

            bookings.Add(booking);
        }

        //[Then(@"a booking exists between (.*) and (.*)")]
        //public void ThenABookingExistsBetweenPatAndCharlie(string customerName, string driverName)
        //{
        //    Assert.AreEqual(customerName, booking.Customer.Name);
        //    Assert.AreEqual(driverName, booking.Driver.Name);
        //}

        [Then(@"these bookings exist")]
        public void ThenTheseBookingsExist(Table table)
        {
            List<BookingItem> list = bookings.Select(x => new BookingItem
                {Customer = x.Customer.Name, Driver = x.Driver.Name}).ToList();
    
            table.CompareToSet(list);
        }

    }

    internal class BookingItem
    {
        public string Customer { get; set; }
        public string Driver { get; set; }
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
