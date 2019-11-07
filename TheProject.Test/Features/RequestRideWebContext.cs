using System.Collections.Generic;
using TheProject.Interfaces;
using TheProject.Models;

namespace TheProject.Test.Features
{
    public class RequestRideWebContext : IRequestRideContext
    {
        private readonly List<Driver> drivers = new List<Driver>();
        private readonly List<Rider> riders = new List<Rider>();
        private readonly List<RideRequest> requests = new List<RideRequest>();

        public void AddRider(string memberName, double latitude, double longitude)
        {
        }

        public List<RideOption> GetAvailableDrivers(string riderName)
        {
            return null;
        }

        public void AddDriver(string name, double latitude, double longitude)
        {
        }

        public Rider FindRider(string name)
        {
            return null;
        }

        public Driver GetDriver(string name)
        {
            return null;
        }

        public void RequestRide(string riderName, double latitude, double longitude)
        {
        }

        public RideRequest GetRequest(string riderName)
        {
            return null;
        }

        public void DriverAcceptsRequest(string driverName, string riderName)
        {
        }

        public IEnumerable<RideRequest> GetAvailableRequests()
        {
            return null;
        }

        public void SelectRideRequest(string riderName, string driverName)
        {
            
        }

        public List<RideRequest> GetAvailableRequestsFor(string driverName)
        {
            return null;
        }
    }
}