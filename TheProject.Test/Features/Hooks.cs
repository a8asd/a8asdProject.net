using BoDi;
using TechTalk.SpecFlow;
using TheProject.Contexts;
using TheProject.Interfaces;

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
            objectContainer.RegisterInstanceAs(context);
        }

        [BeforeScenario("webstuff")]
        public void BeforeWebScenario()
        {
            context = new RequestRideWebContext();
            objectContainer.RegisterInstanceAs(context);
        }
    }
}
