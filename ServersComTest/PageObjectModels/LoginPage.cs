using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ServersComTest.PageObjectModels
{
    public class LoginPage
    {
        private WebDriver _driver;

        public LoginPage(WebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Кнопка подтверждения использований Cookie файлов
        /// </summary>
        public IWebElement CookieButton => _driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));

        /// <summary>
        /// Логотип с названием сайта
        /// </summary>
        public IWebElement MainLogo => _driver.FindElement(By.ClassName("l1gmm7ie"));

        /// <summary>
        /// Подпись к логотипу
        /// </summary>
        public IWebElement LoginTitle => _driver.FindElement(By.XPath(LoginTitlePath));
        private string LoginTitlePath = "//div[@class='hjhmia0']/span";

        /// <summary>
        /// Поле ввода Email
        /// </summary>
        public BaseLoginInput EmailInput => new BaseLoginInput(_driver, "Email");

        /// <summary>
        /// Поле ввода Password
        /// </summary>
        public BaseLoginInput PasswordInput => new BaseLoginInput(_driver, "Password");

        /// <summary>
        /// Всплывающее окно с предупреждением о некорректности введенного значения поля Email
        /// </summary>
        public IWebElement EmailWarningMessagePopup => _driver.FindElement(By.XPath(EmailWarningMessageElementPath));
        private string EmailWarningMessageElementPath = "//div[@id=':r0:'][@class='b1h25vo1']";

        /// <summary>
        /// Текст всплывающего окна с предупреждением о некорректности введенного значения поля Email
        /// </summary>
        public string EmailWarningMessageText => EmailWarningMessagePopup.Text;

        /// <summary>
        /// Всплывающее окно с предупреждением о некорректности введенного значения поля Password
        /// </summary>
        public IWebElement PasswordWarningMessagePopup => _driver.FindElement(By.XPath(PasswordWarningMessageElementPath));
        private string PasswordWarningMessageElementPath = "//div[@id=':r1:'][@class='b1h25vo1']";

        /// <summary>
        /// Текст всплывающего окна с предупреждением о некорректности введенного значения поля Password
        /// </summary>
        public string PasswordWarningMessageText => PasswordWarningMessagePopup.Text;

        /// <summary>
        /// Сообщение о некорректности введенной почты или пароля
        /// </summary>
        public IWebElement InvalidEmailOrPasswordMessage => _driver.FindElement(By.XPath(InvalidEmailOrPasswordMessagePath));
        private string InvalidEmailOrPasswordMessagePath = "//div[@class='v194kz7h']";

        /// <summary>
        /// Текст сообщения о некорректности введенной почты или пароля
        /// </summary>
        public string InvalidEmailOrPasswordMessageText => _driver.FindElement(By.XPath(InvalidEmailOrPasswordMessagePath + "//span")).Text;

        /// <summary>
        /// Кнопка входа на сайт
        /// </summary>
        public IWebElement SignInButton => _driver.FindElement(By.XPath(SignInButtonPath));
        private string SignInButtonPath = "//button[@class='sv8lcon']";

        /// <summary>
        /// Гиперссылка перехода к регистрации
        /// </summary>
        public IWebElement JoinButton => _driver.FindElement(By.XPath(JoinButtonPath));
        private string JoinButtonPath = "//a[@class='lj16mvx']";

        /// <summary>
        /// Гиперссылка перехода к форме восстановления пароля
        /// </summary>
        public IWebElement ForgotPasswordText => _driver.FindElement(By.XPath(ForgotPasswordTextPath));
        private string ForgotPasswordTextPath = "//a[@class='f8w9670']";

        /// <summary>
        /// Ожидание исчезновения страницы-индикатора загрузки
        /// </summary>
        public void WaitProgressbarClose()
        {
            var initImplicitWait = _driver.Manage().Timeouts().ImplicitWait;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            wait.Until(condition =>
            {
                try
                {
                    condition.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.25);
                    var elementToBeDisplayed = _driver.FindElement(By.XPath("//div[@class='preloader']"));
                    return !elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
            _driver.Manage().Timeouts().ImplicitWait = initImplicitWait;
        }

        /// <summary>
        /// Проверка отображения блока с сообщением о о некорректности введенной почты или пароля
        /// </summary>
        /// <returns></returns>
        public bool IsInvalidEmailOrPasswordMessageDisplayed()
        {
            try
            {
                return _driver.FindElement(By.XPath(InvalidEmailOrPasswordMessagePath)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка отображения основного блока с полями для ввода логина и пароля и изображениями
        /// Используется для проверки отображения страницы входа
        /// </summary>
        /// <returns></returns>
        public bool IsMainLoginBlockDisplayed()
        {
            try
            {
                return _driver.FindElement(By.ClassName("rnhzm9g")).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
