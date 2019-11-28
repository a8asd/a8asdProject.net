
using BoDi;
using TechTalk.SpecFlow;

namespace TheProject.Test.Features
{
    [Binding]
    internal class Hooks
    {
        private static IContext context;

        private readonly IObjectContainer objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeFeature]
        public static void BeforeNormalFeature()
        {
            context = new Context();
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

        [BeforeScenario]
        public void AssignWebDriver()
        {
            objectContainer.RegisterInstanceAs<IContext>(context);
        }
    }
}
