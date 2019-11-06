﻿using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TheProject.Models;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookingRidesSteps
    {
        private List<Driver> _availableDrivers;
        private readonly RequestRideContext _requestRideContext;

        public BookingRidesSteps(RequestRideContext requestRideContext)
        {
            _requestRideContext = requestRideContext;
        }

        [Given(@"the following riders")]
        public void GivenTheFollowingRiders(Table table)
        {
            foreach (var rider in table.CreateSet<RiderModel>())
            {
                _requestRideContext.AddRider(rider.Name, rider.Latitude, rider.Longitude);
            }
        }

        [Given("we have these drivers")]
        public void WeHaveTheseDrivers(Table table)
        {
            foreach (var driver in table.CreateSet<DriverRow>())
            {
                _requestRideContext.AddDriver(driver.Name, driver.Lat, driver.Lng);
            }
        }

        [Given(@"(.*) is a driver at (.*),(.*)")]
        public void GivenDannyIsADriverAt(string driverName, double latitude, double longitude)
        {
            _requestRideContext.AddDriver(driverName, latitude, longitude);
        }

        [When(@"(.*) requests a ride")]
        public void WhenRileyRequestsARideFrom(string memberName)
        {
            var member = _requestRideContext.Find(memberName);
            _availableDrivers = _requestRideContext.GetAvailableDrivers(member);
        }

        [Then(@"Riley sees these drivers")]
        public void ThenRileySeesTheseDrivers(Table table)
        {
            table.CompareToSet(_availableDrivers);
        }

        [Given(@"these rides are on offer for (.*)")]
        public void GivenTheseRidesAreOnOfferForDanny(string driverName, Table table)
        {
            var availableRides = table.CreateSet<RideModel>();
            foreach (var ride in availableRides)
            {
                _requestRideContext.AddRide(driverName, ride);
            }
        }

        [When(@"(.*) accepts (.*)'s ride")]
        public void WhenDannyAcceptsRileySRide(string driverName, string riderName)
        {
            var rides = _requestRideContext.GetRides(driverName);
            var ride = rides.FirstOrDefault(r => r.RiderName == riderName);
            if (ride != null)
                ride.Accept();
        }

        [Then(@"Riley's ride is accepted")]
        public void ThenRileySRideIsAccepted()
        {

        }

        [Then(@"Danny is busy")]
        public void ThenDannyIsBusy()
        {

        }

        [Then(@"these rides are on offer")]
        public void ThenTheseRidesAreOnOffer(Table table)
        {

        }

    }

    public class RideModel
    {
        public double Distance { get; set; }
        public string RiderName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Ride
    {
        public double Distance { get; set; }
        public string RiderName { get; set; }
        public Location DropoffLocation { get; set; }
        public string DriverName { get; set; }
        public string Status { get; set; }

        public void Accept()
        {
            Status = "Accepted";
        }
    }

    public class DriverRow
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class RiderModel
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
