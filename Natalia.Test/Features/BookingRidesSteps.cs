using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Natalia.Test.Features
{
    [Binding]
    public class BookingRidesSteps
    {
        private List<Driver> _availableDrivers = new List<Driver>();
        private readonly List<Driver> _allDrivers = new List<Driver>();
        private List<Member> _allMembers = new List<Member>() { new Member() { Name = "Riley"} };

        [Given(@"(.*) is a member")]
        public void GivenRileyIsAMember(string memberName)
        {
             
        }

        [Given(@"(.*) is a driver at (.*), (.*)")]
        public void GivenDannyIsADriverAt(string driverName, decimal p0, decimal p1)
        {
            _allDrivers.Add(new Driver() {Name = driverName});
        }

        [When(@"Riley requests a ride from (.*), (.*)")]
        public void WhenRileyRequestsARideFrom(decimal p0, decimal p1)
        {
            _availableDrivers = _allDrivers;
        }

        [Then(@"Riley sees this list of drivers")]
        public void ThenRileySeesThisListOfDrivers(Table table)
        {
            table.CompareToSet<Driver>(_availableDrivers);
        }
    }

    public class Member
    {
        public string Name { get; set; }
    }

    public class Driver
    {
        public string Name { get; set; }
    }
}
