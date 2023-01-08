using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using ServersComTest.PageObjectModels;
using TechTalk.SpecFlow;

namespace ServersComTest.LoginTests
{
    [Binding]
    internal class LoginSteps
    {
        private ScenarioContext _scenarioContext;
        private WebDriver _driver;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = (ChromeDriver)_scenarioContext["driver"];
        }

        [Given(@"открываем страницу входа")]
        public void GivenOpenLoginPage()
        {
            _driver.Navigate().GoToUrl("https://portal.servers.com/login");
            var page = new LoginPage(_driver);
            page.WaitProgressbarClose();
            page.CookieButton.Click();
        }

        [Given(@"поле Email заполняем значением (.*)")]
        public void GivenFillEmailField(string email)
        {
            var loginPage = new LoginPage(_driver);
            loginPage.EmailInput.Input.SendKeys(email);
            _scenarioContext["email"] = email;
        }

        [Given(@"поле Password заполняем значением (.*)")]
        public void GivenFillPasswordField(string password)
        {
            var loginPage = new LoginPage(_driver);
            loginPage.PasswordInput.Input.SendKeys(password);
        }



        [When(@"наводим мышкой на значок предупреждения поля Email")]
        public void WhenPutCursorOnEmailWarning()
        {
            var loginPage = new LoginPage(_driver);
            Actions action = new Actions(_driver);
            action.MoveToElement(loginPage.EmailInput.StatusIcon).Perform();
        }

        [When(@"наводим мышкой на значок предупреждения поля Password")]
        public void WhenPutCursorOnPasswordWarning()
        {
            var loginPage = new LoginPage(_driver);
            Actions action = new Actions(_driver);
            action.MoveToElement(loginPage.PasswordInput.StatusIcon).Perform();
        }

        [When(@"нажимаем на логотип сайта")]
        public void WhenPushSiteLogo()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.MainLogo.Click();
        }

        

        [Then(@"для поля Email появляется сообщение с текстом (.*)")]
        public void ThenEmailFieldIsMessageDisplayed(string message)
        {
            var loginPage = new LoginPage(_driver);
            Assert.AreEqual(message, loginPage.EmailWarningMessageText, "Сообщение не соответствует ожидаемому");
        }

        [Then(@"для поля Password появляется сообщение с текстом (.*)")]
        public void ThenPasswordFieldMessageDisplayed(string message)
        {
            var loginPage = new LoginPage(_driver);
            Assert.AreEqual(message, loginPage.PasswordWarningMessageText, "Сообщение не соответствует ожидаемому");
        }

        [Then(@"в поле Email отображается значок корректности введенного значения")]
        public void ThenEmailCheckIconDisplayed()
        {
            var loginPage = new LoginPage(_driver);
            Assert.IsTrue(loginPage.EmailInput.IsCheckIconDisplayed(), "Значок корректности значения не отображается");
        }

        [Then(@"в поле Password отображается значок корректности введенного значения")]
        public void ThenPasswordCheckIconDsplayed()
        {
            var loginPage = new LoginPage(_driver);
            Assert.IsTrue(loginPage.PasswordInput.IsCheckIconDisplayed(), "Значок корректности значения не отображается");
        }

        [Then(@"отображается сообщение о некорректной почте или пароле с текстом (.*)")]
        public void ThenInvalidEmailOrPasswordMessageDisplayed(string message)
        {
            var loginPage = new LoginPage(_driver);
            Assert.IsTrue(loginPage.IsInvalidEmailOrPasswordMessageDisplayed(), "Сообщение о некорректной почте или пароле не отображается");
            Assert.AreEqual(message, loginPage.InvalidEmailOrPasswordMessageText, "Сообщение не соответствует ожидаемому");
        }

        [Given(@"нажимаем кнопку входа")]
        [When(@"нажимаем кнопку входа")]
        public void WhenPushSiginButton()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.SignInButton.Click();
        }

        [When(@"открывается страница входа")]
        [Then(@"открывается страница входа")]
        public void ThenLoginPageOpens()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.WaitProgressbarClose();
            Assert.IsTrue(loginPage.IsMainLoginBlockDisplayed(), "Страница входа не открылась!");
        }
    }
}
