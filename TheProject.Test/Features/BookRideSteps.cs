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

        [When(@"Pat requests offers")]
        public void WhenPatRequestsOffers()
        {
            var offerItems = _luberContext.offerItems;
        }

        [When(@"(.*) is available (.*) miles away")]
        public void WhenCharlieIsAvailableMilesAway(string driverName, int distance)
        {
            _luberContext.CreateOffer(driverName, distance);
        }

        [Then(@"these are the offers")]
        public void ThenTheseAreTheOffers(Table table)
        {
            IEnumerable<OfferItem> offerItemList = new List<OfferItem>();

            table.CompareToSet<OfferItem>(_luberContext.offerItems);
        }

    }

    public class OfferItem
    {
        public int Distance { get; internal set; }
        public string Driver { get; internal set; }
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
