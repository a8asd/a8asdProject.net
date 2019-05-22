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
        private Booking booking;
        private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();
        private IList<Booking> bookings = new List<Booking>();

        [Given(@"(.*) is a registered customer")]
        public void GivenPatIsARegisteredCustomer(string name)
        {
            customers.Add(name, new Customer { Name = name});
        }
        
        [Given(@"(.*) is an available driver")]
        public void GivenCharlieIsAnAvailableDriver(string name)
        {
            drivers.Add(name, new Driver {Name = name});
        }
        
        [When(@"(.*) books a ride with (.*)")]
        public void WhenPatBooksARideWithCharlie(string customerName, string driverName)
        {
            booking = new Booking
            {
                Customer = customers[customerName],
                Driver = drivers[driverName]
            };

            bookings.Add(booking);


        }

        

        //[Then(@"a booking exists between (.*) and (.*)")]
        //public void ThenABookingExistsBetweenPatAndCharlie(string customerName, string driverName)
        //{
        //    Assert.AreEqual(customers[customerName], booking.Customer);
        //    Assert.AreEqual(drivers[driverName], booking.Driver);
        //}

        [Then(@"these are the bookings")]
        public void ThenTheseAreTheBookings(Table table)
        {
            List<BookingItem> bookingItemList = new List<BookingItem>();
            foreach (var booking in bookings)
            {

                bookingItemList.Add(new BookingItem
                {
                    DriverName = booking.Driver.Name, CustomerName = booking.Customer.Name
                });
            }

            table.CompareToSet<BookingItem>(bookingItemList);
        }

    }

    public class BookingItem
    {
        public string DriverName { get; set; }
        public string CustomerName { get; set; }
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
