using System.Collections.Generic;
using System.Linq;
using TheProject.Models;

namespace TheProject.Test.Features
{
    public class RequestRideContext
    {
        private readonly List<Driver> driverList = new List<Driver>();
        private readonly List<Member> memberList = new List<Member>();

        public void AddMember(string memberName, double latitude, double longitude)
        {
            memberList.Add(new Member { Name = memberName, Location = new Location(latitude, longitude) });
        }

        public List<Driver> GetAvailableDrivers(Member member)
        {
            List<Driver> drivers = null;
            if (member != null)
            {
                var sortedDriverList = (from driver in driverList
                                        where driver.Location.DistanceFrom(member.Location) <= 16.0
                                        select (distance: driver.Location.DistanceFrom(member.Location), driver))
                    .OrderBy(x => x.distance);
                drivers = sortedDriverList.Select(x => x.driver).ToList();
                if (drivers.Count() > 5)
                    drivers = drivers.GetRange(0, 5);
            }
            return drivers;
        }

        public void AddDriver(string driverName, double latitude, double longitude)
        {
            driverList.Add(new Driver { Name = driverName, Location = new Location(latitude, longitude) });
        }

        public Member Find(string memberName)
        {
            return memberList.Find(x => x.Name == memberName);
        }
    }
}