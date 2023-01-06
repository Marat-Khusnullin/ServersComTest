using OpenQA.Selenium;
using System.Xml.Linq;

namespace ServersComTest.PageObjectModels
{
    public class CloudServerEditorPage: MainSitePage
    {
        private WebDriver _driver;

        public CloudServerEditorPage(WebDriver driver) : base(driver) 
        { 
            _driver = driver;
        }

        /// <summary>
        /// Блок Location
        /// </summary>
        public IWebElement LocationBlock => _driver.FindElement(By.XPath(LocationBlockPath));
        private string LocationBlockPath = "//div[@id='location_id']";

        /// <summary>
        /// Блок Image
        /// </summary>
        public IWebElement ImageBlock => _driver.FindElement(By.XPath(ImageBlockPath));
        private string ImageBlockPath = "//div[@id='image_id']";

        /// <summary>
        /// Блок Configuration
        /// </summary>
        public IWebElement ConfigurationBlock => _driver.FindElement(By.XPath(ConfigurationBlockPath));
        private string ConfigurationBlockPath = "//div[@id='flavor_id']";

        /// <summary>
        /// Кнопка помесячной оплаты
        /// </summary>
        public IWebElement PerMonthPaymentButton => _driver.FindElement(By.XPath(ConfigurationBlockPath + "//button[@title='per month']"));

        /// <summary>
        /// Кнопка почасовой оплаты
        /// </summary>
        public IWebElement PerHourPaymentButton => _driver.FindElement(By.XPath(ConfigurationBlockPath + "//button[@title='per hour']"));

        /// <summary>
        /// Блок Backup
        /// </summary>
        public IWebElement BackupBlock => _driver.FindElement(By.XPath(BackupBlockPath));
        private string BackupBlockPath = "//div[@id='backup_enabled']";

        /// <summary>
        /// Кнопка необходимости бэкапа
        /// </summary>
        public IWebElement BackupWantedButton => _driver.FindElement(By.XPath(BackupBlockPath + "//button[.//input[@id='backup_copies']]"));

        /// <summary>
        /// Поле ввода количество необходимых копий бэкапа
        /// </summary>
        public IWebElement BackupCountInput => _driver.FindElement(By.XPath(BackupBlockPath + "//input[@id='backup_copies']"));

        /// <summary>
        /// Кнопка отмены бэкапа
        /// </summary>
        public IWebElement BackupCancelButton => _driver.FindElement(By.XPath(BackupBlockPath + "//button[.//h4[text()='No, I don't need automatic backups']]"));

        /// <summary>
        /// Блок Network features
        /// </summary>
        public IWebElement NetworkFeaturesBlock => _driver.FindElement(By.XPath(NetworkFeaturesBlockPath));
        private string NetworkFeaturesBlockPath = "//div[@class='b18x3tjq wwis14o'][.//h3[text()='Network features']]";

        /// <summary>
        /// Блок Name
        /// </summary>
        public IWebElement NameBlock => _driver.FindElement(By.XPath(NameBlockPath));
        private string NameBlockPath = "//div[@id='name']";

        /// <summary>
        /// Поле ввода блока Name
        /// </summary>
        public IWebElement NameInput => _driver.FindElement(By.XPath(NameBlockPath + "//input"));

        /// <summary>
        /// Кнопка создания облачного сервера
        /// </summary>
        public IWebElement CloudServerCreateButton => _driver.FindElement(By.XPath("//button[@title='Create Cloud Server']"));

        /// <summary>
        /// Кнопка отмены создания облачного сервера
        /// </summary>
        public IWebElement CloudServerCancelButton => _driver.FindElement(By.XPath("//button[@title='Cancel']"));

        /// <summary>
        /// Клик по одной локации из списка
        /// </summary>
        public void LocationButtonClick(string locationName)
        {
            _driver.FindElement(By.XPath(LocationBlockPath + $"//button[.//span[text()='{locationName}']]")).Click();
        }

        /// <summary>
        /// Клик по одному образу из списка
        /// </summary>
        public void ImageButtonClick(string imageName)
        {
            var element = _driver.FindElement(By.XPath(ImageBlockPath + $"//button[.//h4[text()='{imageName}']]"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        /// <summary>
        /// Клик по одной конфигурации из списка
        /// </summary>
        public void ConfigurationButtonClick(string configurationName)
        {
            var element = _driver.FindElement(By.XPath(ConfigurationBlockPath + $"//button[.//h4[text()='{configurationName}']]"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        /// <summary>
        /// Клик по одной сетевой опции
        /// </summary>
        public void NetworkFeatureButtonClick(string featureName)
        {
            var element = _driver.FindElement(By.XPath(NetworkFeaturesBlockPath + $"//button[.//h4[text()='{featureName}']]"));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }
    }
}
