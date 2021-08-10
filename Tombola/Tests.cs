using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace UnitTestProject1.Tombola
{
    [TestClass]
    public class Tests
    {
        private IWebDriver Driver;

        [TestInitialize]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void Terminate()
        {
            Driver.Quit();
        }

        [TestMethod]
        public void LoginWithUnknownDNI()
        {
            PageTombola page = new PageTombola(Driver).Open();

            string response = page.Login();

            Thread.Sleep(10000);

            Assert.AreEqual("Este DNI no está registrado con esta contraseña.", response);

            Thread.Sleep(3000);
        }
    }
}
