using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TheProject.Models;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookingRidesSteps
    {
        private List<Driver> availableDrivers;
        private readonly RequestRideContext requestRideContext = new RequestRideContext();

        [Given(@"(.*) is a member at (.*),(.*)")]
        public void GivenRileyIsAMember(string memberName, double latitude, double longitude)
        {
            requestRideContext.AddMember(memberName, latitude, longitude);
        }

        [Given("we have these drivers")]
        public void WeHaveTheseDrivers(Table table)
        {
            foreach (var driver in table.CreateSet<DriverRow>())
            {
                requestRideContext.AddDriver(driver.Name, driver.Lat, driver.Lng);
            }
        }

        [Given(@"(.*) is a driver at (.*),(.*)")]
        public void GivenDannyIsADriverAt(string driverName, double latitude, double longitude)
        {
            requestRideContext.AddDriver(driverName, latitude, longitude);

        }

        [When(@"(.*) requests a ride")]
        public void WhenRileyRequestsARideFrom(string memberName)
        {
            var member = requestRideContext.Find(memberName);
            availableDrivers = requestRideContext.GetAvailableDrivers(member);
        }

        [Then(@"Riley sees these drivers")]
        public void ThenRileySeesTheseDrivers(Table table)
        {
            table.CompareToSet(availableDrivers);
        }
    }

    public class DriverRow
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
