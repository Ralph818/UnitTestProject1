using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.Pages
{
    internal class MyStoreHomePage : BasePage
    {
        WebDriverWait wait;

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
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            wait.Until(ElementIsVisible(By.Id("header_logo")));
        }

        internal ResultsPage PerformSearch(string searchString)
        {
            SearchBox.SendKeys(searchString);
            SearchButton.Click();
            return new ResultsPage(Driver);
        }
    }
}