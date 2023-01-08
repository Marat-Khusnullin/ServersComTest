using OpenQA.Selenium;


namespace ServersComTest.PageObjectModels
{
    // Класс костыль сделанный чтобы просто можно было проверить название модуля не добавляя для каждого модуля отдельную страницу
    // При написании полноценных тестов, конечно же, можно реализовать проверку другим образом. Например, вынеся блок с названием
    // класс MainSitePage. Но тогда чуть-чуть надо будет подумать в целом над корректным наследованием
    public class BaseModulePage
    {
        private WebDriver _driver;

        public BaseModulePage(WebDriver driver) 
        { 
            _driver = driver;
        }

        /// <summary>
        /// Название модуля
        /// </summary>
        public string ModuleNameText => _driver.FindElement(By.XPath("//h3//span")).Text;
    }
}
