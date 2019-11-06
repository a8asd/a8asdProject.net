using System;
using System.Collections.Generic;
using System.Linq;
using TheProject.Models;

namespace TheProject.Test.Features
{
    public class RequestRideContext
    {
        private readonly List<Driver> driverList = new List<Driver>();
        private readonly List<Rider> riderList = new List<Rider>();
        private List<RideOption> rides = new List<RideOption>();
        private List<RideRequest> requests = new List<RideRequest>();

        public void AddRider(string memberName, double latitude, double longitude)
        {
            riderList.Add(new Rider
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

            var available = driverList.FindAll(x => x.Location.DistanceFrom(request.Start) < 16);
            available = available.OrderBy(x=>x.Location.DistanceFrom(request.Start)).ToList();
            available = available.GetRange(0, Math.Min(5,available.Count));
            rideOptions = available.Select(x => new RideOption
            { 
                DriverName= x.Name,
                Price= (decimal)12.00,
                Start = request.Start,
                Destination = request.Destination,
                RiderName = request.RiderName
            }).ToList();

            return rideOptions;
        }

        public void AddDriver(string name, double latitude, double longitude)
        {
            driverList.Add(new Driver { Name = name, Location = new Location(latitude, longitude) });
        }

        public Rider Find(string memberName)
        {
            return riderList.Find(x => x.Name == memberName);
        }

        public Driver GetDriver(string driverName)
        {
            return driverList.Find(x => x.Name.Equals(driverName));
        }

        public void RequestRide(string riderName, double latitude, double longitude)
        {
            var rider = Find(riderName);
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
            return requests.FindAll(x=>x.Accepted == false);
        }
    }

    public class RideRequest
    {
        public Location Destination { get; set; }
        public Location Start { get; set; }
        public string RiderName { get; set; }
        public bool Accepted { get; private set; }

        public void Accept()
        {
            Accepted = true;
        }
    }

    public class RideOption
    {
        public Driver Driver { get; set; }
        public decimal Price { get; set; }
        public double Distance { get; set; }
        public string RiderName { get; set; }
        public Location Destination { get; set; }
        public string DriverName { get; set; }
        public RideStatus Status { get; set; }
        public Location Start { get; set; }

        public void Accept()
        {
            Status = RideStatus.Accepted;
        }
    }
}