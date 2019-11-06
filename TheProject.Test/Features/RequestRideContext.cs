﻿using System.Collections.Generic;
using System.Linq;
using TheProject.Models;

namespace TheProject.Test.Features
{
    public class RequestRideContext
    {
        private readonly List<Driver> driverList = new List<Driver>();
        private readonly List<Rider> memberList = new List<Rider>();

        public void AddMember(string memberName, double latitude, double longitude)
        {
            memberList.Add(new Rider { Name = memberName, Location = new Location(latitude, longitude) });
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

        public void AddRiders(List<Rider> riders)
        {
            foreach (var rider in riders)
            {
                AddMember(rider.Name, rider.Location.Latitude, rider.Location.Longitude);                
            }
        }
    }
}