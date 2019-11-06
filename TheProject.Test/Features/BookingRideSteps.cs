using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TheProject.Models;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookingRidesSteps
    {
        private List<RideOption> _rideOptions;
        private readonly RequestRideContext _requestRideContext = new RequestRideContext();

        [Given(@"the following riders")]
        public void GivenTheFollowingRiders(Table table)
        {
            List<Rider> riderList = new List<Rider>();
            foreach (var rider in table.CreateSet<RiderModel>())
            {
                riderList.Add(new Rider() { Name = rider.Name, Location = new Location(rider.Latitude, rider.Longitude) });
            }
            _requestRideContext.AddRiders(riderList);
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

        [When(@"(.*) requests a ride to (.*), (.*)")]
        public void WhenRileyRequestsARideFrom(string memberName, double lat, double lng)
        {
            var member = _requestRideContext.Find(memberName);
            _rideOptions = _requestRideContext.GetAvailableDrivers(member);
        }

        [Then(@"Riley sees these drivers")]
        public void ThenRileySeesTheseDrivers(Table table)
        {
            table.CompareToSet(_rideOptions.Select(o => new { name = o.Driver.Name, price = o.Price }));
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
