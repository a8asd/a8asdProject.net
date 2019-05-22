using System;
using System.Collections.Generic;
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
        private Booking booking;
        private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();
        private List<Booking> bookings = new List<Booking>();

        [Given(@"(.*) is a registered customer")]
        public void GivenIsARegisteredCustomer(string name)
        {
            customers.Add(name, new Customer { Name = name });
        }

        [Given(@"(.*) is an available driver")]
        public void GivenIsAnAvailableDriver(string name)
        {
            drivers.Add(name, new Driver { Name = name });
        }

        [When(@"(.*) books a ride with (.*)")]
        public void WhenCustomerBooksARideWithDriver(string customerName, string driverName)
        {
            bookings.Add( new Booking
            {
                Customer = customers[customerName],
                Driver = drivers[driverName]
            });
        }

        [Then(@"a booking exists between (.*) and (.*)")]
        public void ThenABookingExistsBetweenPatAndCharlie(string customerName, string driverName)
        {
            Assert.AreEqual(customerName, booking.Customer.Name);
            Assert.AreEqual(driverName, booking.Driver.Name);
        }

        [Then(@"these are the bookings")]
        public void ThenTheseAreTheBookings(Table table)
        {
            List<BookingItem> bookingList = new List<BookingItem>();
            foreach (var booking in bookings)
            {
                bookingList.Add(new BookingItem()
                {
                    Driver = booking.Driver.Name,
                    Customer = booking.Customer.Name
                });
            }
            table.CompareToSet<BookingItem>(bookingList);
        }

    }

    internal class BookingItem
    {
        public string Driver { get; internal set; }
        public string Customer { get; internal set; }
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
