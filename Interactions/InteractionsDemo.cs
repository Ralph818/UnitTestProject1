using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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
            actions = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver?.Quit();
        }
        [Category ("DragAndDrop")]
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

    }
}
