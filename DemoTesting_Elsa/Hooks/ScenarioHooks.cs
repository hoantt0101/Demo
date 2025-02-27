using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestSpecs.Driver;

namespace SpecFlowProject.Hooks
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly IObjectContainer _container;
        private static DriverFactory _driverFactory;
        private IWebDriver _driver;
        public ScenarioHooks(IObjectContainer container)
        {
            _container = container;
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverFactory = new DriverFactory();
            _driver = _driverFactory.CreateDriver();
            _container.RegisterInstanceAs<IWebDriver>(_driver);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            _driver = _container.Resolve<IWebDriver>();
            _driver.Close();
            _driver.Dispose();
        }
    }
}
