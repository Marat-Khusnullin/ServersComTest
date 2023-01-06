using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ServersComTest.PageObjectModels;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace ServersComTest.ProfileTests
{
    [Binding]
    public class ProfileSteps
    {
        private ScenarioContext _scenarioContext;
        private WebDriver _driver;

        public ProfileSteps(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            _driver = (ChromeDriver)_scenarioContext["driver"];
        }

        [Given(@"нажимаем кнопку меню профиля")]
        public void GivenPushProfileMenuButton()
        {
            var userPage = new MainSitePage(_driver);
            userPage.ProfileActionButton.Click();
        }

        [Given(@"нажимаем кнопку модуля (.*)")]
        public void GivenPushModuleButton(string moduleName)
        {
            var userPage = new MainSitePage(_driver);
            userPage.ModulesListElementClick(moduleName);
        }

        [Given(@"нажимаем кнопку добавления контакта")]
        public void GivenPushAddContactButton()
        {
            var contactsPage = new ContactsPage(_driver);
            contactsPage.CreateButton.Click();
        }

        [Given(@"нажимаем кнопку добавления сервера")]
        public void GivenPushAddServerButton()
        {
            var cloudServersPage = new CloudServersPage(_driver);
            cloudServersPage.CreateButton.Click();
        }

        [Given(@"нажимаем кнопку добавления деталей контакта")]
        public void GivenPushAddContactDetailButton()
        {
            var newContactPage = new NewOrEditContactPage(_driver);
            newContactPage.AddContactDetailsButton.Click();
        }

        [Given(@"нажимаем кнопку удаления деталей контакта")]
        public void GivenPushDeleteContactDetailButton()
        {
            var newContactPage = new NewOrEditContactPage(_driver);
            newContactPage.DeleteContactDetailsButton.Click();
        }

        [Given(@"заполняем поле (.*) значением (.*)")]
        public void GivenFillFieldByValue(string fieldName, string value)
        {
            var newContactPage = new NewOrEditContactPage(_driver);
            _scenarioContext[fieldName] = value;
            newContactPage.FillInput(fieldName, value);
        }

        [Given(@"в поле Jobe role выбираем значение (.*)")]
        public void GivenSelectJobeRole(string value)
        {
            var newContactPage = new NewOrEditContactPage(_driver);
            _scenarioContext["Role"] = value;
            newContactPage.SelectRole(value);
        }

        [Given(@"в поле Comments записываем значение (.*)")]
        public void GivenFillCommentsField(string value)
        {
            var newContactPage = new NewOrEditContactPage(_driver);
            _scenarioContext["Comments"] = value;
            newContactPage.NoteInput.SendKeys(value);
        }

        [Given(@"в поле Contact details записываем значение (.*)")]
        public void GivenFillContactDetailsField(string value)
        {
            var newContactPage = new NewOrEditContactPage(_driver);
            _scenarioContext["Contact details"] = newContactPage.ContactDetailTypeElement.Text+": " + value;
            newContactPage.ContactDetailInput.SendKeys(value);
        }

        [Given(@"добавили контакт со случайными данными")]
        public void GivenRandomContactCreated()
        {
            GivenPushModuleButton("Profile");
            GivenPushModuleButton("Contacts");
            GivenPushAddContactButton();

            var random = new Random();
            GivenFillFieldByValue("First name", "TestValue" + random.Next(10000));
            GivenFillFieldByValue("Last name", "TestValue" + random.Next(10000));
            GivenFillFieldByValue("Middle name", "TestValue" + random.Next(10000));
            GivenFillFieldByValue("Email", "TestValue" + random.Next(10000) + "@rp.ru");
            GivenFillFieldByValue("Secondary email", "TestValue" + random.Next(10000) + "@rp.ru");
            GivenFillFieldByValue("Phone number", "+79" + random.Next(100000000, 200000000));

            var roles = new List<string>() { "Technical", "Billing", "Abuse", "Emergency"};
            GivenSelectJobeRole(roles.ElementAt(random.Next(roles.Count)));
            GivenFillFieldByValue("Company", "TestValue" + random.Next(10000));
            GivenFillFieldByValue("Job title", "TestValue" + random.Next(10000));
            GivenFillFieldByValue("Job role", "TestValue" + random.Next(10000));
            GivenFillFieldByValue("Nickname", "TestValue" + random.Next(10000));
            GivenFillCommentsField("TestValue" + random.Next(10000));
            GivenPushAddContactDetailButton();
            GivenFillContactDetailsField("+79" + random.Next(100000000, 200000000));
            GivenPushCreateContactDetailButton();
            var userPage = new MainSitePage(_driver);
            userPage.SuccessActionMessageCloseButton.Click();
            Thread.Sleep(1000);
        }

        [Given(@"нажимаем кнопку редактирования контакта")]
        public void GivenPushEditContactButton()
        {
            var contactInfoPage = new ContactInfoPage(_driver);
            contactInfoPage.EditButton.Click();
        }

        [Given(@"изменяем все поля контакта")]
        public void GivenFillContactFieldsByRandomValues()
        {
            var random = new Random();
            var newContactPage = new NewOrEditContactPage(_driver);
            newContactPage.FirstNameInput.Clear();
            GivenFillFieldByValue("First name", "TestValue" + random.Next(10000));

            newContactPage.LastNameInput.Clear();
            GivenFillFieldByValue("Last name", "TestValue" + random.Next(10000));

            newContactPage.MiddleNameInput.Clear();
            GivenFillFieldByValue("Middle name", "TestValue" + random.Next(10000));

            newContactPage.EmailInput.Clear();
            GivenFillFieldByValue("Email", "TestValue" + random.Next(10000) + "@rp.ru");

            newContactPage.SecondaryEmailInput.Clear();
            GivenFillFieldByValue("Secondary email", "TestValue" + random.Next(10000) + "@rp.ru");

            newContactPage.PhoneNumberInput.Clear();
            GivenFillFieldByValue("Phone number", "+79" + random.Next(100000000, 200000000));

            // Пока не трогаем роли, так как нужно учитывать, что можем щелкнуть по уже выбранному значению и отменить его
            //var roles = new List<string>() { "Technical", "Billing", "Abuse", "Emergency" };
            //GivenSelectJobeRole(roles.ElementAt(random.Next(roles.Count)));

            newContactPage.CompanyInput.Clear();
            GivenFillFieldByValue("Company", "TestValue" + random.Next(10000));

            newContactPage.JobTitleInput.Clear();
            GivenFillFieldByValue("Job title", "TestValue" + random.Next(10000));

            newContactPage.JobRoleInput.Clear();
            GivenFillFieldByValue("Job role", "TestValue" + random.Next(10000));

            newContactPage.NickNameInput.Clear();
            GivenFillFieldByValue("Nickname", "TestValue" + random.Next(10000));

            newContactPage.ClearNoteArea();
            GivenFillCommentsField("TestValue" + random.Next(10000));

            GivenPushDeleteContactDetailButton();
            GivenPushAddContactDetailButton();
            GivenFillContactDetailsField("+79" + random.Next(100000000, 200000000));
        }

        [Given(@"выбираем локацию (.*)")]
        public void GivenSelectLocation(string locationName)
        {
            var cloudServerEditorPage = new CloudServerEditorPage(_driver);
            cloudServerEditorPage.LocationButtonClick(locationName);
        }

        [Given(@"выбираем образ (.*)")]
        public void GivenSelectImage(string imageName)
        {
            var cloudServerEditorPage = new CloudServerEditorPage(_driver);
            cloudServerEditorPage.ImageButtonClick(imageName);
        }

        [Given(@"выбираем конфигурацию (.*)")]
        public void GivenSelectConfiguration(string configurationName)
        {
            var cloudServerEditorPage = new CloudServerEditorPage(_driver);
            cloudServerEditorPage.ConfigurationButtonClick(configurationName);
        }

        [Given(@"выбираем необходимость бекапа в количестве (.*) единиц")]
        public void GivenSelectBackup(int copiesCount)
        {
            var cloudServerEditorPage = new CloudServerEditorPage(_driver);

            //Костыль перехода к элементу
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", cloudServerEditorPage.BackupWantedButton);
            cloudServerEditorPage.BackupWantedButton.Click();
            cloudServerEditorPage.BackupCountInput.SendKeys("" + copiesCount);
        }

        [Given(@"выбираем сетевую опцию (.*)")]
        public void GivenSelectNetworkFeature(string featureName)
        {
            var cloudServerEditorPage = new CloudServerEditorPage(_driver);
            cloudServerEditorPage.NetworkFeatureButtonClick(featureName);
        }

        [Given(@"в поле Name ввожу значение (.*)")]
        public void GivenFillNameFieldByValue(string value)
        {
            var cloudServerEditorPage = new CloudServerEditorPage(_driver);
            cloudServerEditorPage.NameInput.SendKeys(value);
        }
        


        [When(@"нажимаем кнопку выхода из профиля")]
        public void WhenPushLogoutButton()
        {
            var userPage = new MainSitePage(_driver);
            userPage.LogoutButton.Click();
        }

        [When(@"удаляем в таблице добавленный контакт")]
        public void WhenDeleteAddedContact()
        {
            var contactsPage = new ContactsPage(_driver);
            var name = (string)_scenarioContext["First name"] + " " + (string)_scenarioContext["Last name"];
            contactsPage.DeleteTableRowByName(name);
        }

        [When(@"нажимаем кнопку сохранения изменений контакта")]
        public void GivenPushSaveContactDetailButton()
        {
            var newContactPage = new NewOrEditContactPage(_driver);
            newContactPage.SaveContactButton.Click();
        }

        [When(@"нажимаем кнопку создания сервера")]
        public void GivenPushCreateServerButton()
        {
            var cloudServersEditorPage = new CloudServerEditorPage(_driver);
            cloudServersEditorPage.CloudServerCreateButton.Click();
        }


        [Then(@"отображается сообщение об успешном действии с текстом (.*)")]
        public void ThenSuccessActionMessageDisplayed(string text)
        {
            var userPage = new MainSitePage(_driver);
            
            // Здесь было решено не проверять само отображение сообщения, ибо наличие текста уже подразумевает наличие сообщения
            Assert.AreEqual(text, userPage.SuccessActionMessageText, "Текст сообщения не соответствует ожидаемому");
            userPage.SuccessActionMessageCloseButton.Click();
        }

        [Then(@"отображается страница Contact info")]
        public void ThenContactInfoPageDisplayed()
        {
            var contactInfoPage = new ContactInfoPage(_driver);

            Assert.AreEqual("Contact info", contactInfoPage.ModuleNameText);
        }

        [Then(@"на странице Contact info отображаются введенные раннее данные контакта")]
        public void ThenContactInfoValuesDisplayed()
        {
            var contactInfoPage = new ContactInfoPage(_driver);

            Assert.AreEqual(_scenarioContext["First name"], contactInfoPage.FirstNameFieldText);
            Assert.AreEqual(_scenarioContext["Last name"], contactInfoPage.LastNameFieldText);
            Assert.AreEqual(_scenarioContext["Middle name"], contactInfoPage.MiddleNameFieldText);
            Assert.AreEqual(_scenarioContext["Nickname"], contactInfoPage.NicknameFieldText);
            var email = (string)_scenarioContext["Email"];
            Assert.AreEqual(email.ToLower(), contactInfoPage.EmailFieldText);
            email = (string)_scenarioContext["Secondary email"];
            Assert.AreEqual(email.ToLower(), contactInfoPage.SecondaryEmailFieldText);
            Assert.AreEqual(_scenarioContext["Phone number"], contactInfoPage.PhoneNumberFieldText);
            Assert.AreEqual(_scenarioContext["Role"], contactInfoPage.RoleFieldText);
            Assert.AreEqual(_scenarioContext["Company"], contactInfoPage.CompanyFieldText);
            Assert.AreEqual(_scenarioContext["Job title"], contactInfoPage.JobTitleFieldText);
            Assert.AreEqual(_scenarioContext["Job role"], contactInfoPage.JobRoleFieldText);
            Assert.AreEqual(_scenarioContext["Comments"], contactInfoPage.CommentsFieldText);
            Assert.AreEqual(_scenarioContext["Contact details"], contactInfoPage.ContactDetailsFieldText);
        }

        [Then(@"в списке контактов нет добавленного контакта")]
        public void ThenAddedContactNotDisplayed()
        {
            var contactsPage = new ContactsPage(_driver);

            var name = (string)_scenarioContext["First name"] + " " + (string)_scenarioContext["Last name"];
            Assert.IsFalse(contactsPage.IsTableRowDisplayed(name), "Добавленный контакт всё ещё отображается в таблице");
        }

        [Then(@"отображается страница Payment methods")]
        public void ThenPaymentMethodsPageDisplayed()
        {
            var paymentMethodsPage = new PaymentMethodsPage(_driver);

            Assert.AreEqual("Payment methods", paymentMethodsPage.ModuleNameText);
        }



        [Given(@"нажимаем кнопку создания контакта")]
        [When(@"нажимаем кнопку создания контакта")]
        public void GivenPushCreateContactDetailButton()
        {
            var newContactPage = new NewOrEditContactPage(_driver);
            newContactPage.CreateContactButton.Click();
        }


        [Given(@"открывается страница пользователя")]
        [Then(@"открывается страница пользователя")]
        public void ThenUserPageOpens()
        {
            var userPage = new MainSitePage(_driver);
            userPage.WaitProgressbarClose();
            Assert.IsTrue(userPage.IsHeaderDisplayed(), "Страница пользователя не открылась!");
            Assert.AreEqual((string)_scenarioContext["email"], userPage.ProfileActionButtonText, "Email в шапке не соответствует email'у пользователя!");
        }
    }
}
