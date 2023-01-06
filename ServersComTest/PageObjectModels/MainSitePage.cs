using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ServersComTest.PageObjectModels
{
    public class MainSitePage
    {
        private WebDriver _driver;

        public MainSitePage(WebDriver driver) 
        { 
            _driver = driver;
        }

        /// <summary>
        /// Шапка сайта
        /// </summary>
        public IWebElement MainHeader => _driver.FindElement(By.XPath(MainHeaderPath));
        private string MainHeaderPath = "//nav";

        /// <summary>
        /// Кнопка открытия бокового меню навигации
        /// </summary>
        public IWebElement NavMenuButton => _driver.FindElement(By.XPath(NavMenuButtonPath));
        private string NavMenuButtonPath => MainHeaderPath + "//button[@class='s1tvhopm']";

        /// <summary>
        /// Список - иерархия открытых модулей
        /// </summary>
        public IWebElement NavModulesList => _driver.FindElement(By.XPath(NavModulesListPath));
        private string NavModulesListPath => MainHeaderPath + "//ol";

        /// <summary>
        /// Поле поиска в шапке
        /// </summary>
        public IWebElement SearchInput => _driver.FindElement(By.XPath(SearchInputPath));
        private string SearchInputPath => MainHeaderPath + "//input";

        /// <summary>
        /// Кнопка просмотра корзины
        /// </summary>
        public IWebElement CartElement => _driver.FindElement(By.XPath(CartElementPath));
        private string CartElementPath => MainHeaderPath + "//a[@class='c3d8t2e']";

        /// <summary>
        /// Элемент информации профиля
        /// </summary>
        public IWebElement ProfileElement => _driver.FindElement(By.XPath(ProfileElementPath));
        private string ProfileElementPath => MainHeaderPath + "//div[@class='c1asuurm']";

        /// <summary>
        /// Кнопка открытия списка действий для профиля
        /// </summary>
        public IWebElement ProfileActionButton => _driver.FindElement(By.XPath(ProfileActionButtonPath));
        private string ProfileActionButtonPath => ProfileElementPath + "//button";

        /// <summary>
        /// Текст кнопки открытия списка действий для профиля
        /// </summary>
        public string ProfileActionButtonText => _driver.FindElement(By.XPath(ProfileActionButtonPath + "//span")).Text;

        /// <summary>
        /// Элемент списка доступных функций для профиля
        /// </summary>
        public IWebElement ProfileActionList => _driver.FindElement(By.XPath(ProfileActionListPath));
        private string ProfileActionListPath => ProfileElementPath + "//ul";

        /// <summary>
        /// Кнопка Profile в списке функций для профиля
        /// </summary>
        public IWebElement ProfileButton => _driver.FindElement(By.XPath(ProfileButtonPath));
        private string ProfileButtonPath => ProfileActionListPath + "//li[.//span[text()='Profile']]";

        /// <summary>
        /// Кнопка Logout в списке функций для профиля
        /// </summary>
        public IWebElement LogoutButton => _driver.FindElement(By.XPath(LogoutButtonPath));
        private string LogoutButtonPath => ProfileActionListPath + "//li[.//span[text()='Logout']]";

        /// <summary>
        /// Боковое меню для навигации по модулям сайта
        /// </summary>
        public IWebElement NavigationMenu => _driver.FindElement(By.XPath(NavigationMenuPath));
        private string NavigationMenuPath => "//div[contains(@class, 's1fw6rty')]";

        /// <summary>
        /// Логотип сайта в боковом меню
        /// </summary>
        public IWebElement SiteLogo => _driver.FindElement(By.XPath(SiteLogoPath));
        private string SiteLogoPath => NavigationMenuPath + "//a";

        /// <summary>
        /// Список модулей сайта
        /// </summary>
        public IWebElement SiteModulesList => _driver.FindElement(By.XPath(SiteModulesListPath));
        private string SiteModulesListPath => NavigationMenuPath + "//ul";

        /// <summary>
        /// Блок с сообщением об успешном действии
        /// </summary>
        public IWebElement SuccessActionMessage => _driver.FindElement(By.XPath(SuccessActionMessagePath));
        private string SuccessActionMessagePath = "//div[@class='cmc8fd']";

        /// <summary>
        /// Текст сообщения об успешном действии
        /// </summary>
        public string SuccessActionMessageText => _driver.FindElement(By.XPath(SuccessActionMessagePath+ "//div[@class='m11324zt']//span")).Text;

        /// <summary>
        /// Кнопка закрытия сообщения об успешном действии
        /// </summary>
        public IWebElement SuccessActionMessageCloseButton => _driver.FindElement(By.XPath(SuccessActionMessagePath + "//button"));

        /// <summary>
        /// Нажатие на элемент списка модулей
        /// </summary>
        /// <param name="moduleName"></param>
        public void ModulesListElementClick(string moduleName)
        {
            var moduleElement = SiteModulesList.FindElement(By.XPath($"//span[text()='{moduleName}']"));
            //((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", moduleElement);
            moduleElement.Click();
        }

        /// <summary>
        /// Ожидание исчезновения страницы-индикатора загрузки
        /// </summary>
        public void WaitProgressbarClose()
        {
            // Явное ожидание из-за нестабильной прорисовки элементов
            Thread.Sleep(250);
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
        /// Проверка отображения шапки сайта. используется для проверки открытия сайта
        /// </summary>
        /// <returns></returns>
        public bool IsHeaderDisplayed()
        {
            try
            {
                _driver.FindElement(By.XPath(MainHeaderPath));
                return true;
            } 
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
