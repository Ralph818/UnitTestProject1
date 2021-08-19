using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.Pages
{
    public class Slider : BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Slider(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement HomeSlider => driver.FindElement(By.Id("homeslider"));
        public IWebElement PrevImageButton => driver.FindElement(By.ClassName("bx-prev"));
        public IWebElement NextImageButton => driver.FindElement(By.ClassName("bx-next"));

        public bool ImageChanged { get; internal set; }

        internal void ClickRightButton()
        {
            string oldStyle = HomeSlider.GetAttribute("style");
            Console.WriteLine("oldStyle => " + oldStyle);
            NextImageButton.Click();
            Thread.Sleep(TimeSpan.FromMilliseconds(2000));
            string newStyle = HomeSlider.GetAttribute("style");
            Console.WriteLine("newStyle => " + newStyle);
            ImageChanged = !String.Equals(oldStyle, newStyle);
        }
    }
}