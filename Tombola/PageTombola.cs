using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace UnitTestProject1.Tombola
{
    public class PageTombola
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private string url = "https://tombola.com.ar/login";
        private string dni = "32437911";
        private string password = "2011asdf1234A";

        public PageTombola(IWebDriver Driver)
        {
            driver = Driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        public PageTombola Open()
        {
            driver.Navigate().GoToUrl(url);
            wait.Until(ElementIsVisible(By.TagName("h1")));
            return this;
        }

        public string Login()
        {
            IWebElement txtDni = driver.FindElement(By.XPath("//input[@type='text']"));
            IWebElement txtPass = driver.FindElement(By.XPath("//input[@type='password']"));
            IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(), 'Ingresar')]"));
            
            txtDni.SendKeys(this.dni);
            txtPass.SendKeys(this.password);
            loginButton.Click();

            Thread.Sleep(10000); 

            wait.Until(ElementIsVisible(By.XPath("//*[@role='alert']")));
            return driver.FindElement(By.XPath("//*[@role='alert']")).Text;
        }
    }
}
