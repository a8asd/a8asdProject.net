using System;
using System.Collections.Generic;
using System.Linq;
using TheProject.Interfaces;
using TheProject.Models;

namespace TheProject.Contexts
{
    public class RequestRideContext : IRequestRideContext
    {
        private readonly List<Driver> drivers = new List<Driver>();
        private readonly List<Rider> riders = new List<Rider>();
        private readonly List<RideRequest> requests = new List<RideRequest>();

        public void AddRider(string memberName, double latitude, double longitude)
        {
            riders.Add(new Rider
            {
                Name = memberName,
                Location = new Location(latitude, longitude)
            });
        }

        public List<RideOption> GetAvailableDrivers(string riderName)
        {
            var rideOptions = new List<RideOption>();
            var request = requests.Find(x => x.RiderName == riderName);
            if (request == null)
            {
                return rideOptions;
            }

            var available = drivers.FindAll(x => x.Location.DistanceFrom(request.Start) < 16);
            available = available.OrderBy(x => x.Location.DistanceFrom(request.Start)).ToList();
            available = available.GetRange(0, Math.Min(5, available.Count));
            rideOptions = available.Select(x => new RideOption
            {
                DriverName = x.Name,
                Price = (decimal)12.00,
                Start = request.Start,
                Destination = request.Destination,
                RiderName = request.RiderName
            }).ToList();

            return rideOptions;
        }

        public void AddDriver(string name, double latitude, double longitude)
        {
            drivers.Add(new Driver { Name = name, Location = new Location(latitude, longitude) });
        }

        public Rider FindRider(string name)
        {
            return riders.Find(x => x.Name == name);
        }

        public Driver GetDriver(string name)
        {
            return drivers.Find(x => x.Name.Equals(name));
        }

        public void RequestRide(string riderName, double latitude, double longitude)
        {
            var rider = FindRider(riderName);
            var destination = new Location(latitude, longitude);
            requests.Add(new RideRequest
            {
                Destination = destination,
                Start = rider.Location,
                RiderName = riderName,
            });
        }

        public RideRequest GetRequest(string riderName)
        {
            return requests.Find(x => x.RiderName.Equals(riderName));
        }

        public void DriverAcceptsRequest(string driverName, string riderName)
        {
            var request = requests.Find(r => r.RiderName == riderName);
            request.Accept();
        }

        public IEnumerable<RideRequest> GetAvailableRequests()
        {
            return requests.FindAll(x => x.Accepted == false);
        }

        public void SelectRideRequest(string riderName, string driverName)
        {
            var request = requests.Find(r => r.RiderName == riderName);
            request.DriverName = driverName;
        }

        public List<RideRequest> GetAvailableRequestsFor(string driverName)
        {
            return requests.FindAll(r => !r.Accepted && r.DriverName == driverName);
        }
    }
}