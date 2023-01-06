using OpenQA.Selenium;

namespace ServersComTest.PageObjectModels
{
    public class CloudServersPage : MainSitePage
    {
        private WebDriver _driver;

        public CloudServersPage(WebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Название модуля
        /// </summary>
        public string ModuleNameText => _driver.FindElement(By.XPath("//h3//span")).Text;

        /// <summary>
        /// Блок с элементами в верхней части страницы
        /// </summary>
        public IWebElement HeaderBlock => _driver.FindElement(By.XPath(HeaderBlockPath));
        private string HeaderBlockPath = "//div[@class='p16k7q0d']";

        /// <summary>
        /// Поле поиска
        /// </summary>
        public IWebElement SearchField => _driver.FindElement(By.XPath(SearchFieldPath));
        private string SearchFieldPath => HeaderBlockPath + "//input";

        /// <summary>
        /// Кнопка обновления списка
        /// </summary>
        public IWebElement ShowCredentialsButton => _driver.FindElement(By.XPath(ShowCredentialsButtonPath));
        private string ShowCredentialsButtonPath => HeaderBlockPath + "//button[@title='Show credentials']";

        /// <summary>
        /// Кнопка обновления списка
        /// </summary>
        public IWebElement RefreshButton => _driver.FindElement(By.XPath(RefreshButtonPath));
        private string RefreshButtonPath => HeaderBlockPath + "//button[@title='Refresh']";

        /// <summary>
        /// Кнопка добавления сервера
        /// </summary>
        public IWebElement CreateButton => _driver.FindElement(By.XPath(CreateButtonPath));
        private string CreateButtonPath => HeaderBlockPath + "//a[@title='Create server']";
    }
}
