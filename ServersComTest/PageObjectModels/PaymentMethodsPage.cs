using OpenQA.Selenium;

namespace ServersComTest.PageObjectModels
{
    public class PaymentMethodsPage : MainSitePage
    {
        private WebDriver _driver;

        public PaymentMethodsPage(WebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Название модуля
        /// </summary>
        public string ModuleNameText => _driver.FindElement(By.XPath("//h3//span")).Text;
    }
}
