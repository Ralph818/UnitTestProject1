using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Interactions;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public IWebDriver Driver { get; private set; }
        private WebDriverWait wait;
        private IWebElement element;
        private Actions actions;

        [TestInitialize]
        public void GetChromeDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver();
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            Driver.Manage().Window.Maximize();
            actions = new Actions(Driver);
        }

        [TestCleanup]
        public void RunAfterEveryTest()
        {
            IJavaScriptExecutor javaScript4 = Driver as IJavaScriptExecutor;
            javaScript4.ExecuteScript("alert('Mission completed xD')");
            Thread.Sleep(1500);
            Driver?.Quit();
        }

        [TestMethod]
        public void ElementIdentificationQuiz()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            element = Driver.FindElements(By.ClassName("et_pb_blurb_description"))[3];
            Clickear();
            Regresar();
            element = Driver.FindElement(By.Id("simpleElementsLink"));
            Clickear();
            Regresar();
            element = Driver.FindElement(By.LinkText("Click this link"));
            Clickear();
            Regresar();
            element = Driver.FindElement(By.Name("clickableLink"));
            Clickear();
            Regresar();
            element = Driver.FindElement(By.PartialLinkText("Click this link"));
            Clickear();
            Regresar();
            element = Driver.FindElements(By.TagName("a"))[9];
            Clickear();
            Regresar();
            element = Driver.FindElement(By.CssSelector("#simpleElementsLink"));
            Clickear();
            Regresar();
            element = Driver.FindElement(By.XPath("//*[@id='simpleElementsLink']"));
            Clickear();
            Regresar();



        }

        private void Clickear()
        {
            IJavaScriptExecutor javaScriptExecutor = Driver as IJavaScriptExecutor;
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, "style", "border: 3px solid red; border-style: dashed;");
            element.Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Link success")));
        }

        private void Regresar()
        {
            Driver.Navigate().Back();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("simpleElementsLink")));
        }

        [TestMethod]
        public void SeleniumElementLocationExam()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            //Driver.FindElement(By.XPath("//*[@type='radio'][@value='female']")).Click(); //click any radio button
            //Driver.FindElement(By.XPath("//*[@type='checkbox'][@value='Car']")).Click(); //Select one checkbox
            //Driver.FindElement(By.TagName("select")).Click();
            //Driver.FindElement(By.XPath("//*[@value='audi']")).Click(); // Click on the Audi value

            //IWebElement el = Driver.FindElement(By.XPath("//*[contains(text(),'Tab 2')]")); //Click on Tab 2, then enable the text for Tab 2 and assert
            //el.Click();
            //IWebElement el2 = Driver.FindElement(By.XPath("//*[contains(text(),'Tab 2 content')]/.."));
            //IJavaScriptExecutor javaScript = Driver as IJavaScriptExecutor;
            //javaScript.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", el2, "class", "et_pb_tab et_pb_tab_1 clearfix et_pb_active_content");
            ////Assert.AreEqual(el2.Text,"Tab 2 content");

            //IWebElement el3 = Driver.FindElement(By.XPath("//*[@id='htmlTableId']//td[3]"));
            //IJavaScriptExecutor javaScript1 = Driver as IJavaScriptExecutor;
            //javaScript1.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", el3, "style", "border: 7px solid green; border-style: dashed;");

            //IWebElement el4 = Driver.FindElement(By.XPath("//*[@class='et_pb_column et_pb_column_1_3 et_pb_column_10  et_pb_css_mix_blend_mode_passthrough']")); //Driver.FindElement(By.CssSelector("[class$='et_pb_row_5']"));
            //IJavaScriptExecutor javaScript2 = Driver as IJavaScriptExecutor;
            //javaScript2.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", el4, "style", "border: 7px solid blue; border-style: dashed;");
            //Thread.Sleep(3000);

            //IWebElement el5 = Driver.FindElements(By.Id("button1"))[1];
            //el5.Click();
            //wait.Until(webDriver => webDriver.FindElement(By.CssSelector("h1")).Displayed);
            //IWebElement el6 = Driver.FindElement(By.CssSelector("h1"));
            //IJavaScriptExecutor javaScript3 = Driver as IJavaScriptExecutor;
            //javaScript2.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", el6, "style", "border: 7px solid blue; border-style: dashed;");
            //Thread.Sleep(3000);
            //Regresar();


            //IWebElement el7 = Driver.FindElement(By.XPath("//h2[contains(text(),'HTML Table with no id')]/following-sibling::*/tbody//td[contains(text(),'$120,000+')]"));
            //Assert.IsTrue(el7.Displayed);

            //Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='htmlTableId']/tbody//tr[3]//td[3]")).Text.Equals("$120,000+"));

            //Assert.IsTrue(Driver.FindElement(By.XPath("//button[text()='Click Me!']/ancestor::form/preceding-sibling::h3")).Text.Contains("Feel free to practice your test automation on these elements"));

            Assert.IsTrue(Driver.FindElement(By.XPath("//*[@id='htmlTableId']//tr[last()]//td[1]")).Text.Equals("Quality Assurance Engineer"));
        }

        [TestMethod]
        public void TestNavigation()
        {
            Driver.Navigate().GoToUrl("http://www.ultimateqa.com");
            IWebElement el1 = Driver.FindElement(By.XPath("//html/head/title"));
            Assert.AreEqual("Home - Ultimate QA",Driver.Title);

            Driver.Navigate().GoToUrl("http://www.ultimateqa.com/automation");
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.FindElement(By.XPath("//html/head/title")).GetAttribute("innerText").Equals("Automation Practice - Ultimate QA"));

            Driver.FindElement(By.XPath("//*[@href='../complicated-page']")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.FindElement(By.XPath("//html/head/title")).GetAttribute("innerText").Equals("Complicated Page - Ultimate QA"));

            Driver.Navigate().Back();
            Thread.Sleep(2000);
            Assert.IsTrue(Driver.FindElement(By.XPath("//html/head/title")).GetAttribute("innerText").Equals("Automation Practice - Ultimate QA"));
        }

        [TestMethod]
        public void TestManipulation()
        {
            Driver.Navigate().GoToUrl("http://www.ultimateqa.com/filling-out-form");

            IWebElement name = Driver.FindElement(By.Id("et_pb_contact_name_1"));
            name.Clear();
            name.SendKeys("Rafael");

            IWebElement message = Driver.FindElement(By.Id("et_pb_contact_message_1"));
            message.Clear();
            message.SendKeys("Houston, We've got a problem");

            Thread.Sleep(1000);
            
            String captcha = Driver.FindElement(By.ClassName("et_pb_contact_captcha_question")).Text;
            int num1 = Int32.Parse(captcha.Substring(0,2));
            int num2 = Int32.Parse(captcha.Substring(3,2));
            int resultado = num1 + num2;

            IWebElement captchaRes = Driver.FindElement(By.XPath("//*[@name='et_pb_contact_captcha_1']"));
            captchaRes.Clear();
            captchaRes.SendKeys(resultado.ToString());

            Thread.Sleep(1000);

            var submitButton = Driver.FindElements(By.XPath("//*[@name='et_builder_submit_button']"));
            submitButton[1].Submit();

            Thread.Sleep(2000);
            Assert.AreEqual("Please refresh the page and try again.", Driver.FindElement(By.XPath("//*[@class='et-pb-contact-message']/p")).Text);

        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void TestInterrogationAttribute()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            IWebElement el1 = Driver.FindElement(By.XPath("//*[@id='button1']"));
            String type = el1.GetAttribute("type");
            Assert.AreEqual("submit", type);
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void TestInterrogationCssValue()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            IWebElement el1 = Driver.FindElement(By.XPath("//*[@id='button1']"));
            String type = el1.GetCssValue("letter-spacing");
            Assert.AreEqual("normal", type);
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void TestInterrogationDisplayed()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            IWebElement el1 = Driver.FindElement(By.XPath("//*[@id='button1']"));
            Assert.IsTrue(el1.Displayed);
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void TestInterrogationEnabled()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            IWebElement el1 = Driver.FindElement(By.XPath("//*[@id='button1']"));
            Assert.IsTrue(el1.Enabled);
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void TestInterrogationNotSelected()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            IWebElement el1 = Driver.FindElement(By.XPath("//*[@id='button1']"));
            Assert.IsFalse(el1.Selected);
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void TestInterrogationText()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            IWebElement el1 = Driver.FindElement(By.XPath("//*[@id='button1']"));
            Assert.AreEqual("Click Me!", el1.Text);
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void TestInterrogationTag()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            IWebElement el1 = Driver.FindElement(By.XPath("//*[@id='button1']"));
            Assert.AreEqual("button", el1.TagName);
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void TestInterrogationHeight()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            IWebElement el1 = Driver.FindElement(By.XPath("//*[@id='button1']"));
            Assert.AreEqual(21, el1.Size.Height);
        }

        [TestMethod]
        [TestCategory("Element Interrogation")]
        public void TestInterrogationLocation()
        {
            Driver.Navigate().GoToUrl("https://www.ultimateqa.com/simple-html-elements-for-automation/");
            IWebElement el1 = Driver.FindElement(By.XPath("//*[@id='button1']"));
            Assert.AreEqual(135, el1.Location.X);
            Assert.AreEqual(182, el1.Location.Y);
        }

        [TestMethod]
        public void AutomationQuiz()
        {
            //navigate to ultimateqa.com
            Driver.Navigate().GoToUrl("http://www.ultimateqa.com");
            wait.Until(ElementExists(By.XPath("//img[@data-attachment-id='214976']")));
            
            //click on the search button
            Driver.FindElement(By.XPath("//*[@class='et_pb_menu__icon et_pb_menu__search-button']")).Click();
            wait.Until(ElementIsVisible(By.XPath("//*[@class='et_pb_menu__search-input']")));

            //enter text to search
            IWebElement searchBox = Driver.FindElement(By.XPath("//*[@class='et_pb_menu__search-input']"));
            searchBox.SendKeys("complicated page");
            searchBox.SendKeys(Keys.Enter);
           
            //wait and assert that the search worked
            wait.Until(ElementToBeClickable(By.LinkText("Complicated Page")));
            Assert.AreEqual("https://ultimateqa.com/?s=complicated+page", Driver.Url);

            //click on the complicated page link and assert
            Driver.FindElement(By.LinkText("Complicated Page")).Click();
            wait.Until(ElementExists(By.ClassName("et_pb_menu__logo")));
            Assert.AreEqual("https://ultimateqa.com/complicated-page/", Driver.Url);
        }
    }
}
