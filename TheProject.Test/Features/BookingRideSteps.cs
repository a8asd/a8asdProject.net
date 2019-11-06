using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookingRidesSteps 
    {
        private readonly RequestRideContext context;

        public BookingRidesSteps(RequestRideContext context)
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

        [Given(@"(.*) is a driver at (.*),(.*)")]
        public void GivenDannyIsADriverAt(string driverName, double latitude, double longitude)
        {
            context.AddDriver(driverName, latitude, longitude);
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

    }

    public class RequestModel
    {
        public string RiderName { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double Distance { get; set; }
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
