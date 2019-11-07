using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TheProject.Interfaces;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookingRidesSteps 
    {
        private readonly IRequestRideContext context;

        public BookingRidesSteps(IRequestRideContext context)
        {
            this.context = context;
        }

        [Given(@"the following riders")]
        public void GivenTheFollowingRiders(Table table)
        {
            foreach (var rider in table.CreateSet<RiderModel>())
            {
                context.AddRider(rider.Name, rider.Latitude, rider.Longitude);
            }
        }

        [Given("we have these drivers")]
        public void WeHaveTheseDrivers(Table table)
        {
            foreach (var driver in table.CreateSet<DriverModel>())
            {
                context.AddDriver(driver.Name, driver.Lat, driver.Lng);
            }
        }

        [When(@"(.*) requests a ride to (.*),(.*)")]
        public void WhenRiderRequestsRideTo(string riderName, double latitude,double longitude)
        {
            context.RequestRide(riderName,latitude,longitude);
        }

        [Then(@"(.*) sees these drivers")]
        public void ThenRiderSeesTheseDrivers(string riderName,Table table)
        {
            table.CompareToSet(context.GetAvailableDrivers(riderName));
        }

        [When(@"(.*) accepts (.*)'s ride")]
        public void WhenDannyAcceptsRileySRide(string driverName, string riderName)
        {
            context.DriverAcceptsRequest(driverName, riderName);
        }

        [Then(@"(.*)'s ride is accepted")]
        public void ThenRileySRideIsAccepted(string riderName)
        {
            Assert.IsTrue(context.GetRequest(riderName).Accepted);
        }

        [Then(@"(.*) is busy")]
        public void ThenDriverIsBusy(string driverName)
        {
            Assert.IsFalse(context.GetDriver(driverName).IsAvailable);
        }

        [Then(@"these requests are available")]
        public void ThenTheseRidesAreOnOffer(Table table)
        {
            List<RequestModel> requests = new List<RequestModel>();
            foreach (var request in context.GetAvailableRequests())
            {
                requests.Add(new RequestModel
                {
                    RiderName = request.RiderName,
                    StartLatitude = request.Start.Latitude,
                    StartLongitude = request.Start.Latitude,
                    Distance = request.Destination.DistanceFrom(request.Start)
                });
            }
            table.CompareToSet(requests);
        }

        [When(@"(.*) selects (.*)")]
        public void WhenRileySelectsDanny(string riderName, string driverName)
        {
            context.SelectRideRequest(riderName, driverName);
        }

        [Then(@"(.*) sees these notifications")]
        public void ThenDannySeesTheseNotifications(string driverName, Table table)
        {
            table.CompareToSet(context.GetAvailableRequestsFor(driverName).Select(r =>
                new RequestModel()
                {
                    RiderName =  r.RiderName,
                    StartLatitude = r.Start.Latitude,
                    StartLongitude = r.Start.Longitude,
                    DestinationLatitude = r.Destination.Latitude,
                    DestinationLongitude = r.Destination.Longitude
                }
                ));
        }
    }

    public class RequestModel
    {
        public string RiderName { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double Distance { get; set; }
        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }
    }


    public class DriverModel
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
