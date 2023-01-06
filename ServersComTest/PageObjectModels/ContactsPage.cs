using OpenQA.Selenium;

namespace ServersComTest.PageObjectModels
{
    public class ContactsPage : MainSitePage
    {
        private WebDriver _driver;

        public ContactsPage(WebDriver driver) : base(driver)
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
        /// Элемент выбора роли
        /// </summary>
        public IWebElement RoleField => _driver.FindElement(By.XPath(RoleFieldPath));
        private string RoleFieldPath => HeaderBlockPath + "//div[contains(@class, 's1fnwgp')]";

        /// <summary>
        /// Кнопка обновления списка
        /// </summary>
        public IWebElement RefreshButton => _driver.FindElement(By.XPath(RefreshButtonPath));
        private string RefreshButtonPath => HeaderBlockPath + "//button[@title='Refresh']";

        /// <summary>
        /// Кнопка добавления контакта
        /// </summary>
        public IWebElement CreateButton => _driver.FindElement(By.XPath(CreateButtonPath));
        private string CreateButtonPath => HeaderBlockPath + "//a[@title='Create']";

        /// <summary>
        /// Кнопка подтверждения удаления контакта
        /// </summary>
        public IWebElement DeleteButton => _driver.FindElement(By.XPath("//button[@title='Delete']"));

        /// <summary>
        /// Кнопка отмены подтверждения удаления контакта
        /// </summary>
        public IWebElement CancelButton => _driver.FindElement(By.XPath("//button[@title='Cancel']"));

        /// <summary>
        /// Таблица со списком контактов
        /// </summary>
        public IWebElement ContactsTable => _driver.FindElement(By.XPath(ContactsTablePath));
        private string ContactsTablePath => "//table";

        /// <summary>
        /// Хэдер таблицы
        /// </summary>
        public IWebElement TableHeader => _driver.FindElement(By.XPath(TableHeaderPath));
        private string TableHeaderPath => ContactsTablePath + "//thead";

        /// <summary>
        /// Тело таблицы (список элементов)
        /// </summary>
        public IWebElement TableBody => _driver.FindElement(By.XPath(TableBodyPath));
        private string TableBodyPath => ContactsTablePath + "//tbody";

        /// <summary>
        /// Удаление строки таблицы (контакта) по имени контакта
        /// </summary>
        public void DeleteTableRowByName(string name)
        {
            _driver.FindElement(By.XPath(TableBodyPath + $"//tr[./td[@title='{name}']]//td[last()]")).Click();
            DeleteButton.Click();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Проверка наличия строки таблицы (контакта) по имени контакта
        /// </summary>
        /// <returns></returns>
        public bool IsTableRowDisplayed(string name)
        {
            try
            {
                _driver.FindElement(By.XPath(TableBodyPath + $"//tr[./td[@title='{name}']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
