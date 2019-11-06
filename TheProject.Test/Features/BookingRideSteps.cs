using System;
using System.Collections.Generic;
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
        public void WhenRileyRequestsARideFrom(string memberName,Decimal latitude, Decimal longitude)
        {
            if (memberList.Find(x=>x.Name==memberName)!=null)
            {
                availableDrivers = driverList;
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
