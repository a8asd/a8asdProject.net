using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;
using System.IO;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookingRidesSteps
    {
        private readonly IList<Driver> driverList = new List<Driver>();
        private IList<Driver> AvailableDriversList;

        [Given(@"Riley is a member")]
        public void GivenRileyIsAMember()
        {
            
        }
        
        [Given(@"(.*) is a driver at (.*),(.*)")]
        public void GivenDannyIsADriverAt(string driverName, Decimal p0, Decimal p1)
        {
            driverList.Add(new Driver{Name=driverName});
        }
        
        [When(@"Riley requests  a ride from (.*),(.*)")]
        public void WhenRileyRequestsARideFrom(Decimal p0, Decimal p1)
        {
            AvailableDriversList = driverList;
        }
        
        [Then(@"Riley sees these drives")]
        public void ThenRileySeesTheseDrives(Table table)
        {
           table.CompareToSet<Driver>(AvailableDriversList);
        }
    }

    internal class Driver
    {
        public string Name { get; set; }
    }
}
