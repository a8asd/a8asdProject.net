using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;
using NUnit.Framework;
using TheProject.Contexts;
using TheProject.Interfaces;
using TheProject.Models;

namespace TheProject.Test.Unit
{
    class ContextTests
    {
        private IRequestRideContext context;
        private const string DriverName = "Danny";
        private const string RiderName = "Riley";
        private const double DriverLongitude = 1.0;
        private const double DriverLatitude = 1.0;
        private const double RiderLatitude = 2.0;
        private const double RiderLongitude = 2.0;
        private const double DestinationLatitude = 3.0;
        private const double DestinationLongitude = 3.0;

        [SetUp]
        public void Setup()
        {
            context = new RequestRideContext();
        }

        private void DriverAcceptsRequest()
        {
            context.AddDriver(DriverName, DriverLatitude, DriverLongitude);
            context.AddRider(RiderName, RiderLatitude, RiderLongitude);
            context.RequestRide(RiderName, DestinationLatitude, DestinationLongitude);
            context.DriverAcceptsRequest(DriverName, RiderName);
        }

        [Test]
        public void OnDriverAcceptsRequestStatusChangesToAccepted()
        {
            DriverAcceptsRequest();
            Assert.IsTrue(context.GetRequest(RiderName).Accepted);
        }


        [Test]
        public void OnDriverAcceptsRequestNewRidePopulatedWithCorrectDestination()
        {
            DriverAcceptsRequest();
            var rideDestination = context.GetCurrentRide(RiderName, DriverName).Destination;
            Assert.AreEqual(DestinationLatitude, rideDestination.Latitude);
            Assert.AreEqual(DestinationLongitude, rideDestination.Longitude);
        }

        [Test]
        public void OnRiderSelectingDriverRequestUpdatedWithDriverName()
        {
            SeedRider();
            SeedRequest();
            context.SelectRideRequest(RiderName, DriverName);
            var request = context.GetAvailableRequests().FirstOrDefault(r => r.RiderName == RiderName);
            Assert.AreEqual(request.DriverName, DriverName);
        }

        [Test]
        public void GetAvailableRequestsForDriverOnlyReturnRequestsForThatDriver()
        {
            SeedRider();
            SeedRequest();
            SeedRequest();
            SeedRequest();
            context.SelectRideRequest(RiderName, DriverName);
            var requests = context.GetAvailableRequestsFor(DriverName);

            Assert.IsTrue(requests.All(r => r.DriverName == DriverName));
        }

        private void SeedRider()
        {
            context.AddRider(RiderName, RiderLatitude, RiderLongitude);
        }

        private void SeedRequest()
        {
            context.RequestRide(RiderName, RiderLatitude, RiderLongitude);
        }

        [Test]
        public void OnDriverAcceptRequestANewRideIsCreated()
        {
            DriverAcceptsRequest();
            Ride rileysRide = context.GetCurrentRide(RiderName, DriverName);
            Assert.IsNotNull(rileysRide);
        }

        [Test]
        public void OnDriverAcceptRequestRidesCountIncreases()
        {
            var rideCountBefore = context.GetRides().Count;
            DriverAcceptsRequest();
            Assert.AreEqual(rideCountBefore+1, context.GetRides().Count);
        }


    }
}
