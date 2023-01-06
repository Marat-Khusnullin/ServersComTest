using OpenQA.Selenium;

namespace ServersComTest.PageObjectModels
{
    public class BaseLoginInput
    {
        private readonly IWebDriver _driver;

        private string FieldName;
        private string BaseElementPath => "//div[@class='i1hde2xr'][.//label[text()='" + FieldName + "']]";

        public BaseLoginInput(IWebDriver driver, string fieldName)
        {
            _driver = driver;
            FieldName = fieldName;
        }

        /// <summary>
        /// Текст метки поля
        /// </summary>
        public IWebElement Label => _driver.FindElement(By.XPath(LabelElementPath));
        private string LabelElementPath => BaseElementPath + "//label/label";

        /// <summary>
        /// Поле ввода
        /// </summary>
        public IWebElement Input => _driver.FindElement(By.XPath(InputElementPath));
        private string InputElementPath => BaseElementPath + "//input";

        /// <summary>
        /// Значок отображающий корректность/некорректность введенного значения
        /// </summary>
        public IWebElement StatusIcon => _driver.FindElement(By.XPath(StatusIconPath));
        private string StatusIconPath => BaseElementPath + "//span";

        /// <summary>
        /// Проверка отображения значка предупреждения о некорректности введенного значения
        /// </summary>
        /// <returns></returns>
        public bool IsWarningIconDisplayed()
        {
            try
            {
                _driver.FindElement(By.XPath(BaseElementPath + "//i[@class='e1je3lf i1v7rha4']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Проверка отображения значка корректности введенного значения
        /// </summary>
        /// <returns></returns>
        public bool IsCheckIconDisplayed()
        {
            try
            {
                _driver.FindElement(By.XPath(BaseElementPath + "//i[@class='i9ak24k']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
