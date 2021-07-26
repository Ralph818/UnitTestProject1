using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.Interactions
{
    [TestFixture]
    public class InteractionsDemo
    {
        public IWebDriver driver { get; private set; }
        private Actions actions;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver?.Quit();
        }

        [Category("DragAndDrop")]
        [Test]
        public void DragDropExample1()
        {
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            wait.Until(FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = driver.FindElement(By.Id("droppable"));

            actions.DragAndDrop(sourceElement, targetElement).Perform();

            Thread.Sleep(3000);
            Assert.AreEqual("Dropped!", targetElement.Text);
        }

        [Category("DragAndDrop")]
        [Test]
        public void DragDropExample2()
        {
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            wait.Until(FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = driver.FindElement(By.Id("droppable"));

            actions.ClickAndHold(sourceElement).Perform();
            actions.MoveToElement(targetElement).Perform();
            actions.Release(sourceElement).Perform();

            //Another way to do this, in 2 steps is:
            /* var drag = actions
                .ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Release(sourceElement)
                .Build();
            drag.Perform();*/


            Thread.Sleep(3000);
            Assert.AreEqual("Dropped!", targetElement.Text);

        }

        [Category("DragAndDrop")]
        [Test]
        public void DragDropQuiz()
        {
            driver.Navigate().GoToUrl("http://www.pureexample.com/jquery-ui/basic-droppable.html");
            wait.Until(FrameToBeAvailableAndSwitchToIt(By.Id("ExampleFrame-94")));

            IWebElement sourceElement = driver.FindElement(By.XPath("//*[@class='square ui-draggable']"));
            IWebElement targetElement = driver.FindElement(By.XPath("//div[contains(text(),'Drop here')]"));

            actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("dropped!", driver.FindElement(By.Id("info")).Text);
            Thread.Sleep(3000);
        }

        [Test]
        public void Resizable()
        {
            driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");
            wait.Until(FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));
            IWebElement webElement = driver.FindElement(By.XPath("//*[@class = 'ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"));

            actions.ClickAndHold(webElement).DragAndDropToOffset(webElement, 50, 50).Perform();
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='resizable' and @style]")).Displayed);

        }

        [Test]
        public void OpenNetworksTab()
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            actions.KeyDown(Keys.Control).KeyDown(Keys.Shift).SendKeys("q").Perform();

            //actions.SendKeys(Keys.F12).Perform();

            actions.KeyUp(Keys.Control).KeyUp(Keys.Shift).Perform();
            driver.Navigate().GoToUrl("https://www.ultimateqa.com");

            Thread.Sleep(3000);
        }  //This doesn't work in Chrome

        [Test]
        public void DragAndDropHTML5()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
            IWebElement elementA = driver.FindElement(By.Id("column-a"));
            IWebElement elementB = driver.FindElement(By.Id("column-b"));

            //Import javascript file and execute it to simulate drag and drop for HTML5
            var jsFile = File.ReadAllText(@"C:\Users\YamiletGIGA\source\repos\UnitTestProject1\drag_and_drop_helper.js");
            IJavaScriptExecutor javaScript = driver as IJavaScriptExecutor;
            //Execute javascript - #{{id value}}
            javaScript.ExecuteScript(jsFile + "$('#column-a').simulateDragDrop({ dropTarget: '#column-b'});");

            Assert.AreEqual("B", elementA.Text);

            Thread.Sleep(2000);
        }

        [Test]
        public void DrawInCanvas()
        {
            driver.Navigate().GoToUrl("https://compendiumdev.co.uk/selenium/gui_user_interactions.html");
            wait.Until(ElementIsVisible(By.Id("canvas")));
           
            IWebElement canvas = driver.FindElement(By.Id("canvas"));
            actions.MoveToElement(canvas).ClickAndHold().Perform();
            //to draw a V
            int y;
            for (int x=1; x<=20; x++)
            {
                if (x<=10)
                    y = 1;
                else
                    y = -1;
 
                actions.MoveByOffset(1,y).Perform();
                actions.Release().Perform();
                actions.ClickAndHold().Perform();
            }
            actions.Release();
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='keyeventslist']/li")).Displayed);
        }
    }
}
