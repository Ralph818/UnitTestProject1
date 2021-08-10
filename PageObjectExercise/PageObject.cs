using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjectExercise
{
    public class PageObject
    {
        private IWebDriver driver;
        private String url = "https://www.ultimateqa.com";
        private WebDriverWait wait;

        public PageObject(IWebDriver Driver)
        {
            driver = Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public PageObject Open()
        {
            driver.Navigate().GoToUrl(this.url);
            return this;
        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public string SearchText(String search)
        {
            driver.FindElement(By.XPath("//*[@class='et_pb_menu__icon et_pb_menu__search-button']")).Click();
            wait.Until(ElementIsVisible(By.XPath("//*[@class='et_pb_menu__search-input']")));

            //enter text to search
            IWebElement searchBox = driver.FindElement(By.XPath("//*[@class='et_pb_menu__search-input']"));
            searchBox.SendKeys(search);
            searchBox.SendKeys(Keys.Enter);

            wait.Until(ElementToBeClickable(By.LinkText("Complicated Page")));

            return driver.Url;
        }

        public string OpenComplicatedPage()
        {
            driver.FindElement(By.LinkText("Complicated Page")).Click();
            wait.Until(ElementExists(By.ClassName("et_pb_menu__logo")));
            return driver.Url;
        }

    }
}
