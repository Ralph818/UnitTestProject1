using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace LoggingPractice.Pages
{
    internal class MyStoreHomePage : BasePage
    {
        WebDriverWait wait;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // Constructor
        public MyStoreHomePage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Slider = new Slider(driver);
        }

        // Properties
        public IWebElement SearchBox => Driver.FindElement(By.Name("search_query"));
        public IWebElement SearchButton => Driver.FindElement(By.Name("submit_search"));
        public Slider Slider { get; internal set; }

        // Methods
        internal void GoTo()
        {
            string url = "http://automationpractice.com/index.php";
            Driver.Navigate().GoToUrl(url);
            wait.Until(ElementIsVisible(By.Id("header_logo")));
            logger.Info($"Opened url => {url}");
        }

        internal ResultsPage PerformSearch(string searchString)
        {
            logger.Trace("Attempting to perform a search");
            SearchBox.SendKeys(searchString);
            SearchButton.Click();
            logger.Info($"Searched for an item in the search bar => {searchString}");
            return new ResultsPage(Driver);
        }
    }
}