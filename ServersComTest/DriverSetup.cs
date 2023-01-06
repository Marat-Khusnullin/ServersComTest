using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace ServersComTest
{
    [Binding]
    public class DriverSetup
    {
        private ScenarioContext _scenatioContext;

        public DriverSetup(ScenarioContext scenarioContext) 
        {
            _scenatioContext = scenarioContext;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _scenatioContext["driver"] = driver;
        }

        [AfterScenario]
        public void DeleteWebDriver()
        {
            var driver = (ChromeDriver)_scenatioContext["driver"];
            driver.Quit();
        }
    }
}
