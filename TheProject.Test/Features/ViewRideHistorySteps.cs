using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class ViewRideHistorySteps
    {
        private LuberContext context;
        private IList<Booking> completedBookings;

        public ViewRideHistorySteps(LuberContext context)
        {
            this.context = context;
        }

        [Given(@"(.*) is a registered driver")]
        public void GivenCharlieIsARegisteredDriver(string driverName)
        {
            context.CreateDriver(driverName);
        }
        
        [Given(@"(.*) is a registered customr")]
        public void GivenPatIsARegisteredCustomer(string customerName)
        {
            context.CreateCustomer(customerName);
        }

        [Given(@"(.*) has a booking with (.*)")]
        public void GivenPatHasABookingWithCharlie(string customerName, string driverName)
        {
            context.CreateBooking(customerName, driverName);
        }

        [Given(@"(.*) has completed a booking with (.*) travelling (.*) miles")]
         public void GivenCharliesHasCompletedABookingWithPatTravellingMiles(string customerName, string driverName, int distance)
        {
            context.CompleteBooking(customerName, driverName, distance);
        }

        [When(@"(.*) views the work history")]
        public void WhenCharlieViewsTheWorkHistory(string driverName)
        {
            completedBookings = context.bookings.Where(a => a.Driver.Name == driverName && a.Complete).ToList();
        }
        
        [Then(@"These are the rides for (.*)")]
        public void ThenTheseAreTheRides(string driver, Table table)
        {
            IList<RideHistory> rideHistoryList = completedBookings.Select(a => new RideHistory
            {
                Driver = a.Driver.Name,
                Customer = a.Customer.Name,
                Distance = a.Distance
            }).ToList();

            table.CompareToSet(rideHistoryList);
        }
    }

    public class RideHistory
    {
        public string Driver { get; set; }

        public string Customer { get; set; }

        public int Distance { get; set; }
    }
}
