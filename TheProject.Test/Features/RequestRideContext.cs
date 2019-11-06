using System.Collections.Generic;
using System.Linq;
using TheProject.Models;

namespace TheProject.Test.Features
{
    public class RequestRideContext
    {
        private readonly List<Driver> driverList = new List<Driver>();
        private readonly List<Rider> memberList = new List<Rider>();
        private List<Ride> rides = new List<Ride>();

        public void AddRider(string memberName, double latitude, double longitude)
        {
            memberList.Add(new Rider
            {
                Name = memberName, 
                Location = new Location(latitude, longitude)
            });
        }

        public List<Driver> GetAvailableDrivers(Rider rider)
        {
            List<Driver> drivers = null;
            if (rider != null)
            {
                var sortedDriverList = (from driver in driverList
                                        where driver.Location.DistanceFrom(rider.Location) <= 16.0
                                        select (distance: driver.Location.DistanceFrom(rider.Location), driver))
                    .OrderBy(x => x.distance);
                drivers = sortedDriverList.Select(x => x.driver).ToList();
                if (drivers.Count() > 5)
                    drivers = drivers.GetRange(0, 5);
            }
            return drivers;
        }

        public void AddDriver(string name, double latitude, double longitude)
        {
            driverList.Add(new Driver { Name = name, Location = new Location(latitude, longitude) });
        }

        public Rider Find(string memberName)
        {
            return memberList.Find(x => x.Name == memberName);
        }

        public void AddRide(string driverName, RideModel ride)
        {
            rides.Add(new Ride
            {
                Distance = ride.Distance,
                RiderName = ride.RiderName,
                DropoffLocation = new Location(ride.Latitude, ride.Longitude),
                DriverName = driverName,
                Status = "Pending"
            });
        }

        public List<Ride> GetRides(string driverName)
        {
            return rides.Where(r => r.DriverName == driverName).ToList();
        }
    }
}