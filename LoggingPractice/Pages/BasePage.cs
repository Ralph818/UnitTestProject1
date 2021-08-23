using OpenQA.Selenium;

namespace LoggingPractice.Pages
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