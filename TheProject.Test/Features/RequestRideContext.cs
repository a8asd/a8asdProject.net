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

        public List<RideOption> GetAvailableDrivers(Rider rider)
        {
            List<RideOption> rideOptions = null;
            if (rider != null)
            {
                var sortedDriverList = (from driver in driverList
                                        where driver.Location.DistanceFrom(rider.Location) <= 16.0
                                        select (distance: driver.Location.DistanceFrom(rider.Location), driver))
                    .OrderBy(x => x.distance);
                rideOptions = sortedDriverList.Select(x => new RideOption(x.driver, (decimal)12.00)).ToList();
                if (rideOptions.Count() > 5)
                    rideOptions = rideOptions.GetRange(0, 5);
            }
            return rideOptions;
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

    public class RideOption
    {
        public Driver Driver { get; }
        public decimal Price { get; }

        public RideOption(Driver driver, decimal price)
        {
            Driver = driver;
            Price = price;
        }
    }
}