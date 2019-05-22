using System.Collections.Generic;

namespace TheProject.Test.Features
{
    public class LuberContext
    {
        private Booking booking;
        private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();
        public IList<Booking> bookings = new List<Booking>();

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
            booking = new Booking
            {
                Customer = customers[customerName],
                Driver = drivers[driverName]
            };

            bookings.Add(booking);
        }
    }
}