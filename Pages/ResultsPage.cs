using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestProject1.Pages
{
    internal class ResultsPage : BasePage
    {
        WebDriverWait wait;

        //Constructor
        public ResultsPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        //Properties
        public bool HasResults
        {
            get
            {
                try
                {
                    return ProductContainer.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
            internal set { }
        }

        public IWebElement ProductContainer => Driver.FindElement(By.ClassName("product-container"));
    }
}