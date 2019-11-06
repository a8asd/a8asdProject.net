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

        [Given(@"Riley is a member")]
        public void GivenRileyIsAMember()
        {
        }
        
        [Given(@"(.*) is a driver at (.*),(.*)")]
        public void GivenDannyIsADriverAt(string driverName,Decimal p0, Decimal p1)
        {
            driverList.Add(new Driver {Name = driverName});
        }
        
        [When(@"Riley requests a ride from (.*),(.*)")]
        public void WhenRileyRequestsARideFrom(Decimal p0, Decimal p1)
        {
            availableDrivers = driverList;
        }
        
        [Then(@"Riley sees these drivers")]
        public void ThenRileySeesTheseDrivers(Table table)
        {
            table.CompareToSet<Driver>(availableDrivers);
        }
    }

    public class Driver
    {
        public string Name { get; set; }
    }
}
