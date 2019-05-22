using System;
using TechTalk.SpecFlow;

namespace TheProject.Test.Features
{
    [Binding]
    public class ViewRideHistorySteps
    {
        [Given(@"Charlie is a registered driver")]
        public void GivenCharlieIsARegisteredDriver()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Charlies has completed a ride with Pat")]
        public void GivenCharliesHasCompletedARideWithPat()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Charlie views the work history")]
        public void WhenCharlieViewsTheWorkHistory()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"These are the rides")]
        public void ThenTheseAreTheRides(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
