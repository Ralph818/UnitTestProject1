using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestProject1.Tests;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.Pages
{
    internal class ContactServicePage: BasePage
    {
        private WebDriverWait wait;
        private Actions action;

        //Properties
        public IWebElement SubjectHeading { get; set; }
        public IWebElement EmailAddress => Driver.FindElement(By.Id("email"));
        public IWebElement OrderReference => Driver.FindElement(By.Id("id_order"));
        public IWebElement Message => Driver.FindElement(By.Id("message"));
        public IWebElement SendButton => Driver.FindElement(By.Id("submitMessage"));
        public IWebElement FileUpload => Driver.FindElement(By.Id("fileUpload"));

        //Constructor
        public ContactServicePage(IWebDriver driver) : base(driver) 
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            action = new Actions(driver);
        }

        //Methods
        public void Open()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=contact");
            wait.Until(ElementIsVisible(By.Id("center_column")));
        }

        public ConfirmationPage FillFormAndSend(ContactData contactData)
        {
            string xpath = "//option[contains(text(),'" + contactData.Subject + "')]";
            SubjectHeading = Driver.FindElement(By.XPath(xpath));
            SubjectHeading.Click();

            EmailAddress.SendKeys(contactData.Email);
            OrderReference.SendKeys(contactData.OrderReference);
            Message.SendKeys(contactData.Message);
            FileUpload.SendKeys(contactData.FilePath);
           
            SendButton.Click();

            return new ConfirmationPage(Driver);
        }
    }
}