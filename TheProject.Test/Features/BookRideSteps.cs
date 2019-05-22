using System.Collections.Generic;
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

            table.CompareToSet(bookingItemList);
        }

    }

    public class BookingItem
    {
        public string DriverName { get; set; }
        public string CustomerName { get; set; }
    }
}
