using OpenQA.Selenium;

namespace UnitTestProject1.Pages
{
    public class BasePage
    {
        public IWebDriver Driver { get; internal set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}