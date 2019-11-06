using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TheProject.Models;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookingRidesSteps
    {
        private List<Driver> availableDrivers;
        private readonly RequestRideContext requestRideContext = new RequestRideContext();

        [Given(@"the following riders")]
        public void GivenTheFollowingRiders(Table table)
        {
            List<Rider> riderList = new List<Rider>();
            foreach (var rider in table.CreateSet<RiderModel>())
            {
                riderList.Add(new Rider() { Name = rider.Name, Location = new Location(rider.Latitude, rider.Longitude) });
            }
            requestRideContext.AddRiders(riderList);
        }

        [Given("we have these drivers")]
        public void WeHaveTheseDrivers(Table table)
        {
            foreach (var driver in table.CreateSet<DriverRow>())
            {
                requestRideContext.AddDriver(driver.Name, driver.Lat, driver.Lng);
            }
        }

        [Given(@"(.*) is a driver at (.*),(.*)")]
        public void GivenDannyIsADriverAt(string driverName, double latitude, double longitude)
        {
            requestRideContext.AddDriver(driverName, latitude, longitude);
        }

        [When(@"(.*) requests a ride")]
        public void WhenRileyRequestsARideFrom(string memberName)
        {
            var member = requestRideContext.Find(memberName);
            availableDrivers = requestRideContext.GetAvailableDrivers(member);
        }

        [Then(@"Riley sees these drivers")]
        public void ThenRileySeesTheseDrivers(Table table)
        {
            table.CompareToSet(availableDrivers);
        }

        [Given(@"these rides are on offer for (.*)")]
        public void GivenTheseRidesAreOnOfferForDanny(string driverName, Table table)
        {
            var availableRides = table.CreateSet<RideModel>();
            foreach (var ride in availableRides)
            {
                AddRide(driverName, ride);
            }
          
        }

        public void AddRide(string driverName, RideModel ride)
        {
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride
            {
                Distance = ride.Distance,
                RiderName = ride.RiderName,
                DropoffLocation = new Location(ride.Latitude, ride.Longitude),
                DriverName = driverName,
                Status = "Pending"
            });
        }


        [When(@"Danny accepts Riley's ride")]
        public void WhenDannyAcceptsRileySRide()
        {
            
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
