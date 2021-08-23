using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace LoggingPractice.Tests
{
    [TestClass]
    [TestCategory("Tests related to search")]
    public class SearchFunctionality : BaseTest
    {
        [Description("This one is for testing the search engine using the lookup word 'blouse'")]
        [TestProperty("Author","RafaelVillalvazo")]
        [TestMethod]
        public void SearchingBlouses()
        {
            MyStoreHomePage myStoreHomePage = new MyStoreHomePage(driver);
            myStoreHomePage.GoTo();
            ResultsPage resultsPage = myStoreHomePage.PerformSearch("blouse");
            Assert.IsTrue(resultsPage.HasResults, "The results page was not loaded");
        }

        [Description("This one is for testing the search engine using the lookup word 'nothing'")]
        [TestProperty("Author", "RafaelVillalvazo")]
        [TestMethod]
        public void SearchingNothing()
        {
            MyStoreHomePage myStoreHomePage = new MyStoreHomePage(driver);
            myStoreHomePage.GoTo();
            ResultsPage resultsPage = myStoreHomePage.PerformSearch("nothing");
            Assert.IsFalse(resultsPage.HasResults, "The results page was not loaded");
        }
    }
}
