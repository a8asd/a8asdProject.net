using System.Collections.Generic;
using TheProject.Models;

namespace TheProject.Interfaces
{
    public interface IRequestRideContext
    {
        void AddRider(string memberName, double latitude, double longitude);
        List<RideOption> GetAvailableDrivers(string riderName);
        void AddDriver(string name, double latitude, double longitude);
        Rider FindRider(string name);
        Driver GetDriver(string name);
        void RequestRide(string riderName, double latitude, double longitude);
        RideRequest GetRequest(string riderName);
        void DriverAcceptsRequest(string driverName, string riderName);
        IEnumerable<RideRequest> GetAvailableRequests();
        void SelectRideRequest();
    }
}