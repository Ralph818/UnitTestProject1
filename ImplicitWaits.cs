using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class ImplicitWaits
    {
        public IWebDriver driver;
        
        [TestInitialize]
        public void setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void close()
        {
            driver?.Quit();
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void test1()
        {
            driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsTrue(driver.FindElement(By.Id("success")).Displayed);
        }

        [TestMethod]
        public void removeGray()
        {
            driver.Navigate().GoToUrl("https://www.newsday.com/sports/columnists/david-lennon/yankees-phillies-estevan-florial-greg-allen-1.50310946");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='demo-modal-a'][1]")));
            IWebElement element = driver.FindElement(By.TagName("main"));
            var element2 = driver.FindElements(By.XPath("//*[@class = 'control_main-container']"));
            
            IJavaScriptExecutor javaScriptExecutor = driver as IJavaScriptExecutor;
            javaScriptExecutor.ExecuteScript("arguments[0].remove()", element2[1]);
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, "style", "display: contents");
            IWebElement element3 = driver.FindElement(By.TagName("body"));
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element3, "style", "overflow: visible");

            Thread.Sleep(3000);
        }
        

    }
}
