using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationResources;
using UnitTestProject1.Pages;

namespace UnitTestProject1.Tests
{
    [TestClass]
    [TestCategory("Tests related to messaging customer service")]
    public class ContactUsTests : BaseTest
    {
        private const string FilePath = "C:/Users/YamiletGIGA/Documents/IMG_20201130_093846232.jpg";
        
        [TestMethod]
        [Description("Designed to test the customer service contact feature")]
        [TestProperty("Author","RafaelVillalvazo")]
        public void SendMessageToCustomerService()
        {
            ContactServicePage contactServicePage = new ContactServicePage(driver);
            contactServicePage.Open();
            ConfirmationPage confirmationPage = contactServicePage.FillFormAndSend(new ContactData("Webmaster", "ralph533@gmail.com", "12345", FilePath, "Apoyo con esta orden de compra, no he recibido el producto"));
            Assert.IsTrue(confirmationPage.IsVisible,"The message was not sent");
        }
    }
}
