using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    public class LuberContext
    {
        public Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        public Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();
        public IList<Booking> bookings = new List<Booking>();

        public void AddCustomer(string name)
        {
            customers.Add(name, new Customer {Name = name});
        }

        public void ExtractDriver(string name)
        {
            drivers.Add(name, new Driver {Name = name});
        }

        public void CreateBooking(string customerName, string driverName)
        {
            var booking = new Booking
            {
                Customer = customers[customerName],
                Driver = drivers[driverName]
            };

            bookings.Add(booking);
        }
    }

    [Binding]
    public class BookRideSteps
    {
        private readonly LuberContext _luberContext = new LuberContext();

        [Given(@"(.*) is a registered customer")]
        public void GivenPatIsARegisteredCustomer(string name)
        {
            _luberContext.AddCustomer(name);
        }

        [Given(@"(.*) is an available driver")]
        public void GivenCharlieIsAnAvailableDriver(string name)
        {
            _luberContext.ExtractDriver(name);
        }

        [When(@"(.*) books a ride with (.*)")]
        public void WhenPatBooksARideWithCharlie(string customerName, string driverName)
        {
            _luberContext.CreateBooking(customerName, driverName);
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
            foreach (var booking in _luberContext.bookings)
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

    public class Booking
    {
        internal Customer Customer;
        internal Driver Driver;
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
