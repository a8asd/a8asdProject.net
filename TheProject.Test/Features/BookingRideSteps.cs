using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookingRidesSteps
    {
        private List<Driver> driverList = new List<Driver>();
        private List<Driver> availableDrivers;
        private List<Member> memberList = new List<Member>();

        [Given(@"(.*) is a member at (.*),(.*)")]
        public void GivenRileyIsAMember(string memberName,Decimal p0, Decimal p1)
        {
            memberList.Add(new Member{Name = memberName});
        } 
        
        [Given(@"(.*) is a driver at (.*),(.*)")]
        public void GivenDannyIsADriverAt(string driverName,Decimal p0, Decimal p1)
        {
            driverList.Add(new Driver {Name = driverName});
        }
        
        [When(@"(.*) requests a ride from (.*),(.*)")]
        public void WhenRileyRequestsARideFrom(string memberName,Decimal p0, Decimal p1)
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
    }

    public class Driver
    {
        public string Name { get; set; }
    }
}
