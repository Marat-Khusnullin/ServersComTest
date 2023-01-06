using OpenQA.Selenium;

namespace ServersComTest.PageObjectModels
{
    public class NewOrEditContactPage: MainSitePage
    {
        private WebDriver _driver;

        public NewOrEditContactPage(WebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Поле ввода имени
        /// </summary>
        public IWebElement FirstNameInput => _driver.FindElement(By.XPath("//input[@id='fname']"));

        /// <summary>
        /// Поле ввода фамилии
        /// </summary>
        public IWebElement LastNameInput => _driver.FindElement(By.XPath("//input[@id='lname']"));

        /// <summary>
        /// Поле ввода "второго имени". Допустим ввод отчества
        /// </summary>
        public IWebElement MiddleNameInput => _driver.FindElement(By.XPath("//input[@id='tokens.middlename']"));

        /// <summary>
        /// Поле ввода электронной почты
        /// </summary>
        public IWebElement EmailInput => _driver.FindElement(By.XPath("//input[@id='email']"));

        /// <summary>
        /// Поле ввода второй электронной почты
        /// </summary>
        public IWebElement SecondaryEmailInput => _driver.FindElement(By.XPath("//input[@id='email2']"));

        /// <summary>
        /// Поле ввода номера телефона
        /// </summary>
        public IWebElement PhoneNumberInput => _driver.FindElement(By.XPath("//input[@id='phone_number']"));

        /// <summary>
        /// Блок с выбором роли
        /// </summary>
        public IWebElement RoleSelectBlock => _driver.FindElement(By.XPath("//div[@id='role']"));

        /// <summary>
        /// Поле ввода названия компании
        /// </summary>
        public IWebElement CompanyInput => _driver.FindElement(By.XPath("//input[@id='tokens.company']"));

        /// <summary>
        /// Поле ввода названия работы
        /// </summary>
        public IWebElement JobTitleInput => _driver.FindElement(By.XPath("//input[@id='tokens.title']"));

        /// <summary>
        /// Поле ввода роли работы
        /// </summary>
        public IWebElement JobRoleInput => _driver.FindElement(By.XPath("//input[@id='tokens.role']"));

        /// <summary>
        /// Поле ввода никнейма
        /// </summary>
        public IWebElement NickNameInput => _driver.FindElement(By.XPath("//input[@id='nickname']"));

        /// <summary>
        /// Поле ввода комментария
        /// </summary>
        public IWebElement NoteInput => _driver.FindElement(By.XPath("//textarea[@id='tokens.note']"));

        /// <summary>
        /// Кнопка добавления деталей контакта
        /// </summary>
        public IWebElement AddContactDetailsButton => _driver.FindElement(By.XPath("//button[@title='Add more details']"));

        /// <summary>
        /// Кнопка удаления деталей контакта
        /// </summary>
        public IWebElement DeleteContactDetailsButton => _driver.FindElement(By.XPath("//button[@title='Delete']"));

        /// <summary>
        /// Элемент выбора типа дополнительной детали контакта
        /// </summary>
        public IWebElement ContactDetailTypeElement => _driver.FindElement(By.XPath("//div[@class='s1fnwgp css-b62m3t-container']"));

        /// <summary>
        /// Поле ввода деталей контакта
        /// </summary>
        public IWebElement ContactDetailInput => _driver.FindElement(By.XPath("//input[@id='contacts[0].value']"));

        /// <summary>
        /// Кнопка создания контакта
        /// </summary>
        public IWebElement CreateContactButton => _driver.FindElement(By.XPath("//button[@title='Create']"));

        /// <summary>
        /// Кнопка сохранения изменеий контакта
        /// </summary>
        public IWebElement SaveContactButton => _driver.FindElement(By.XPath("//button[@title='Save']"));

        /// <summary>
        /// Кнопка отмены
        /// </summary>
        public IWebElement CancelContactButton => _driver.FindElement(By.XPath("//button[@title='Cancel']"));

        /// <summary>
        /// Выбор роли
        /// </summary>
        public void SelectRole(string role)
        {
            RoleSelectBlock.FindElement(By.XPath($"//label[text()='{role}']")).Click();
        }

        /// <summary>
        /// Заполнение указанного поля указанным значением
        /// </summary>
        public void FillInput(string fieldName, string value)
        {
            var element = _driver.FindElement(By.XPath($"//div[./div[./h3[text()='{fieldName}']]]//input[@type='text']"));
            
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.SendKeys(value);
        }

        /// <summary>
        /// Очистка поля Comments
        /// </summary>
        public void ClearNoteArea()
        {
            NoteInput.SendKeys(Keys.Control + "a");
            NoteInput.SendKeys(Keys.Delete);
        }
    }
}
