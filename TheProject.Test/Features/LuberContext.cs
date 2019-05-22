using System;
using System.Collections.Generic;

namespace TheProject.Test.Features
{
    public class LuberContext
    {
        private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();
        public IList<Booking> bookings = new List<Booking>();
        public IList<OfferItem> offerItems = new List<OfferItem>();

        public void CreateCustomer(string name)
        {
            customers.Add(name, new Customer {Name = name});
        }

        public void CreateDriver(string name)
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

        public void CreateOffer(string driverName, int distance)
        {
            var offerItem = new OfferItem()
            {
                Driver = drivers[driverName].Name,
                Distance = distance
            };

            offerItems.Add(offerItem);
        }
    }
}