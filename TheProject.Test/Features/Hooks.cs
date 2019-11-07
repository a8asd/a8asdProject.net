using System;
using System.Collections.Generic;
using System.Linq;
using BoDi;
using TechTalk.SpecFlow;
using TheProject.Contexts;
using TheProject.Interfaces;
using TheProject.Models;

namespace TheProject.Test.Features
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer objectContainer;
        private static IRequestRideContext context;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            context = new RequestRideContext();
            foreach (var valueTuple in GetSeedRiders())
            {
                context.AddRider(valueTuple.Item1, valueTuple.Item2, valueTuple.Item3);
            }
            objectContainer.RegisterInstanceAs(context);
        }

        [BeforeScenario("webstuff")]
        public void BeforeWebScenario()
        {
            context = new RequestRideWebContext();
            objectContainer.RegisterInstanceAs(context);
        }

        private IEnumerable<(string, double, double)> GetSeedRiders()
        {
            (string, double, double)[] riders =
            {
                ("Riley", 51.6731459, -0.9283008),
                ("Rory", 1, 1)
            };
            return riders;
        }
    }
}
