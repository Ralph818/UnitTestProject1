using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace UnitTestProject1.Tests
{
    [TestClass]
    public class BaseTest
    {
        public IWebDriver driver;

        [TestInitialize]
        [Description("Running begore every test method")]
        public void Setup()
        {
            WebDriverFactory factory = new WebDriverFactory();
            driver = factory.Create(BrowserType.Chrome);
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        [Description("Running after every test method")]
        public void Finalize()
        {
            driver.Close();
            driver.Quit();
        }
    }
}