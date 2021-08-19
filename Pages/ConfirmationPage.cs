using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestProject1.Pages
{
    internal class ConfirmationPage: BasePage
    {
        WebDriverWait wait;

        public ConfirmationPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool IsVisible
        {
            get
            {
                try
                {
                    return Driver.FindElement(By.XPath("//p[@class='alert alert-success']")).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
    }
}