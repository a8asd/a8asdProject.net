using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TheProject.Models;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookingRidesSteps
    {
        private List<Driver> driverList = new List<Driver>();
        private List<Driver> availableDrivers;
        private List<Member> memberList = new List<Member>();

        [Given(@"(.*) is a member at (.*),(.*)")]
        public void GivenRileyIsAMember(string memberName,double latitude, double longitude)
        {
            memberList.Add(new Member{Name = memberName,Location = new Location(latitude,longitude)});
        } 
        
        [Given(@"(.*) is a driver at (.*),(.*)")]
        public void GivenDannyIsADriverAt(string driverName,double latitude, double longitude)
        {
            driverList.Add(new Driver {Name = driverName,Location = new Location(latitude,longitude)});
        }
        
        [When(@"(.*) requests a ride from (.*),(.*)")]
        public void WhenRileyRequestsARideFrom(string memberName,double latitude, double longitude)
        {
            
            if (memberList.Find(x=>x.Name==memberName)!=null)
            {
                Location memberLocation = new Location(latitude, longitude);

                //availableDrivers = driverList.FindAll(d => d.Location.DistanceFrom(memberLocation) <= 16.0);
                var sortedDriverlist = (from driver in driverList
                        where driver.Location.DistanceFrom(memberLocation) <= 16.0
                        select (distance: driver.Location.DistanceFrom(memberLocation), driver: driver))
                    .OrderBy(x => x.distance);
                    if(sortedDriverlist.Count() > 5)             
                        availableDrivers = sortedDriverlist.Select(x => x.driver).ToList().GetRange(0,5);
                    else
                    {
                        availableDrivers = sortedDriverlist.Select(x => x.driver).ToList();
                    }
            }
        }
        
        [Then(@"Riley sees these drivers")]
        public void ThenRileySeesTheseDrivers(Table table)
        {
            table.CompareToSet(availableDrivers);
        }
    }

    internal class Member
    {
        public string Name { get; set; }
        public Location Location { get; set; }
    }

    public class Driver
    {
        public string Name { get; set; }
        public Location Location { get; set; }
    }
}
