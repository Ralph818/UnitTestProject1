using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjectExercise
{
    [TestClass]
    public class AutomationQuiz
    {
        private IWebDriver Driver;
        private WebDriverWait wait;
        private Actions actions;
        private PageObject page;

        [TestInitialize]
        public void TestSetup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        }

        [TestCleanup]
        public void TestClean()
        {
            Driver.Quit();
        }

        [TestMethod]
        public void Quiz()
        {
            PageObject page = new PageObject(Driver).Open();
            //wait.Until(ElementExists(By.XPath("//img[@data-attachment-id='214976']")));

            string urlSearch = page.SearchText("Complicated Page");
            Assert.AreEqual("https://ultimateqa.com/?s=Complicated+Page", urlSearch);

            string urlComplicatedPage = page.OpenComplicatedPage();
            Assert.AreEqual("https://ultimateqa.com/complicated-page/", urlComplicatedPage);
        } 
    }
}
