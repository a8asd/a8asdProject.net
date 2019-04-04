﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TheProject.Test
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("BookRide")]
    public partial class BookRideFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BookRide.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BookRide", "So that I can reach my destination quickly\r\nAs Pat \r\nI want to book a ride", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Pat books a ride with a driver")]
        public virtual void PatBooksARideWithADriver()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Pat books a ride with a driver", null, ((string[])(null)));
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
testRunner.When("Pat books a ride with George", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 8
testRunner.Then("George is booked by Pat", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Driver",
                        "Passenger",
                        "IsBooked"});
            table1.AddRow(new string[] {
                        "George",
                        "Pat",
                        "true"});
            table1.AddRow(new string[] {
                        "John",
                        "no booking",
                        "false"});
#line 9
testRunner.Then("these results are expected", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Books a ride with the first available driver")]
        [NUnit.Framework.CategoryAttribute("myTag")]
        public virtual void BooksARideWithTheFirstAvailableDriver()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Books a ride with the first available driver", null, new string[] {
                        "myTag"});
#line 15
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 16
testRunner.When("Pat books a ride", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("Boris is booked by Pat", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

