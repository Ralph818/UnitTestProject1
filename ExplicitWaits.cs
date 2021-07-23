using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium;
using WebDriverManager;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class ExplicitWaits
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
            Thread.Sleep(3000);
            driver?.Quit();
        }
  
        [TestMethod]
        public void ExplicitWait2()
        { 
            driver.Navigate().GoToUrl("https://www.newsday.com/sports/columnists/david-lennon/yankees-phillies-estevan-florial-greg-allen-1.50310946");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement element = wait.Until((d) =>
            {
                return d.FindElement(By.XPath("//*[@id='mce_24']"));
            });
            //IWebElement element2 = driver.FindElement(By.XPath("//*[@id='mce_24']"));
            Assert.IsTrue(element.Text.Contains("SELECTED"));
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void Explicitwait3()
        {
            driver.Navigate().GoToUrl("https://www.newsday.com/sports/columnists/david-lennon/yankees-phillies-estevan-florial-greg-allen-1.50310946");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ElementExists(By.XPath("//*[@id='mce_24'")));
        }

        [TestMethod]
        public void HowToCorrectlySinchronize()
        {
            //first go to ultimateqa home page
            driver.Navigate().GoToUrl("http://www.ultimateqa.com");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ElementExists(By.XPath("//*[@class='wp-image-215826 lazyloaded']")));
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@class='wp-image-215826 lazyloaded']")).Displayed);

            //then click on the Automation Exercises link
            driver.FindElement(By.LinkText("Automation Exercises")).Click();
            wait.Until(ElementExists(By.XPath("//*[@class='wp-image-216051 lazyloaded']")));
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@class='wp-image-216051 lazyloaded']")).Displayed);

            //then click on the Big page with many elements link
            driver.FindElement(By.LinkText("Big page with many elements")).Click();
            wait.Until(ElementExists(By.XPath("//*[@class='wp-image-216051 lazyloaded']")));
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@class='wp-image-216051 lazyloaded']")).Displayed);
        }

        [TestMethod]
        public void TheInternetSiteExplicitWait()  //most recommended
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");

            //wait for the page to complete loading
            wait.Until(ElementIsVisible(By.XPath("//img[@src='/img/forkme_right_green_007200.png']")));
            
            //click on the Remove button
            driver.FindElement(By.XPath("//button[contains(text(),'Remove')]")).Click();
            
            //wait for the checkbox to be removed and a message to appear
            wait.Until(InvisibilityOfElementLocated(By.XPath("//*[@id='checkbox']")));
            Assert.IsTrue(driver.FindElement(By.XPath("//p[contains(text(),'gone!')]")).Displayed);           
        }

        [TestMethod]
        public void TheInternetSiteImplicitWait()  //not recommended
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");

            //Implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //click on the Remove button
            driver.FindElement(By.XPath("//button[contains(text(),'Remove')]")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//p[contains(text(),'gone!')]")).Displayed);
        }
    }
}
