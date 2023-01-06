using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ServersComTest.PageObjectModels;
using TechTalk.SpecFlow;

namespace ServersComTest
{
    [Binding]
    public class CommonSteps
    {
        private ScenarioContext _scenarioContext;
        private WebDriver _driver;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (ChromeDriver)_scenarioContext["driver"];
        }

        [Given(@"произведена авторизация пользователя с email (.*) и паролем (.*)")]
        public void GivenPushProfileMenuButton(string email, string password)
        {
            _driver.Navigate().GoToUrl("https://portal.servers.com/login");
            var loginPage = new LoginPage(_driver);
            loginPage.WaitProgressbarClose();
            loginPage.CookieButton.Click();
            loginPage.EmailInput.Input.SendKeys(email);
            _scenarioContext["email"] = email;
            loginPage.PasswordInput.Input.SendKeys(password);
            loginPage.SignInButton.Click();
            var userPage = new MainSitePage(_driver);
            userPage.WaitProgressbarClose();
        }

        [Given(@"ожидаем (.*) секунды")]
        [Given(@"ожидаем (.*) секунд")]
        [Given(@"ожидаем (.*) секунду")]
        public void GivenWait(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        [When(@"нажимаем кнопку назад браузера")]
        public void WhenPushBackBrouserButton()
        {
            _driver.Navigate().Back();
        }
    }
}
