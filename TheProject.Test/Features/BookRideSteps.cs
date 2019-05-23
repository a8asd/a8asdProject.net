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
        private readonly LuberContext _luberContext = new LuberContext();

        [Given(@"(.*) is a registered customer")]
        public void GivenPatIsARegisteredCustomer(string name)
        {
            _luberContext.CreateCustomer(name);
        }

        [Given(@"(.*) is an available driver")]
        public void GivenCharlieIsAnAvailableDriver(string name)
        {
            _luberContext.CreateDriver(name);
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
}
