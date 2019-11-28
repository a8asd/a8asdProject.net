
using BoDi;
using TechTalk.SpecFlow;

namespace TheProject.Test.Features
{
    [Binding]
    internal class Hooks
    {
        private static WebContext context;

        private readonly IObjectContainer objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeFeature("web")]
        public static void BeforeFeature()
        {
            context = new WebContext();
        }

        [AfterFeature("web")]
        public static void AfterFeature()
        {
            context.Quit();
        }

        [BeforeScenario("web")]
        public void AssignWebDriver()
        {
            objectContainer.RegisterInstanceAs<IContext>(context);
        }
    }
}
