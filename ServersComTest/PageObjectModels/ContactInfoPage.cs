using OpenQA.Selenium;

namespace ServersComTest.PageObjectModels
{
    public class ContactInfoPage: MainSitePage
    {
        private WebDriver _driver;

        public ContactInfoPage(WebDriver driver):base(driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Название модуля
        /// </summary>
        public string ModuleNameText => _driver.FindElement(By.XPath("//h3//span")).Text;

        /// <summary>
        /// Кнопка обновления контакта
        /// </summary>
        public IWebElement RefreshButton => _driver.FindElement(By.XPath("//button[@title='Refresh']"));

        /// <summary>
        /// Кнопка изменения контакта
        /// </summary>
        public IWebElement EditButton => _driver.FindElement(By.XPath("//button[@title='Edit']"));

        /// <summary>
        /// Текст поля имени
        /// </summary>
        public string FirstNameFieldText => GetFieldValue("First name");

        /// <summary>
        /// Текст поля фамилии
        /// </summary>
        public string LastNameFieldText => GetFieldValue("Last name");

        // <summary>
        /// Текст поля второго имени/отчества
        /// </summary>
        public string MiddleNameFieldText => GetFieldValue("Middle name");

        /// <summary>
        /// Текст поля никнейма
        /// </summary>
        public string NicknameFieldText => GetFieldValue("Nickname");

        /// <summary>
        /// Текст поля электронной почты
        /// </summary>
        public string EmailFieldText => _driver.FindElement(By.XPath("//div[./div[text()='Email']]//span//div//a")).Text;

        /// <summary>
        /// Текст поля второй электронной почты
        /// </summary>
        public string SecondaryEmailFieldText => _driver.FindElement(By.XPath("//div[./div[text()='Secondary email']]//span//div//a")).Text;

        /// <summary>
        /// Текст поля номера телефона
        /// </summary>
        public string PhoneNumberFieldText => GetFieldValue("Phone number");

        /// <summary>
        /// Текст поля роли
        /// </summary>
        public string RoleFieldText => GetFieldValue("Role");

        /// <summary>
        /// Текст поля компании
        /// </summary>
        public string CompanyFieldText => GetFieldValue("Company");

        /// <summary>
        /// Текст поля названия работы
        /// </summary>
        public string JobTitleFieldText => GetFieldValue("Job title");

        /// <summary>
        /// Текст поля роли работы
        /// </summary>
        public string JobRoleFieldText => GetFieldValue("Job role");

        /// <summary>
        /// Текст поля комментария
        /// </summary>
        public string CommentsFieldText => _driver.FindElement(By.XPath("//div[./div[text()='Comments']]//span//p")).Text;

        /// <summary>
        /// Текст поля деталей контакта
        /// </summary>
        public string ContactDetailsFieldText => _driver.FindElement(By.XPath("//div[./div[text()='Contact details']]//span//p")).Text;

        /// <summary>
        /// Текст поля типа деталей контакта
        /// </summary>
        public string ContactDetailsTypeFieldText => _driver.FindElement(By.XPath("//div[./div[text()='Contact details']]//span//p//span//span")).Text;

        private string GetFieldValue(string fieldName)
        {
            return _driver.FindElement(By.XPath($"//div[./div[text()='{fieldName}']]//span//span")).Text;
        }
    }
}
