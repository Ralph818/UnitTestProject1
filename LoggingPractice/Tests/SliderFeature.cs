using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.Pages;

namespace LoggingPractice.Tests
{
    [TestClass]
    [TestCategory("SliderFeature")]
    public class SliderFeature : BaseTest
    {
        [TestMethod]
        [Description("Validates that slider changes images")]
        [TestProperty("Author", "RafaelVillalvazo")]
        public void SliderNextImage()
        {
            MyStoreHomePage homePage = new MyStoreHomePage(driver);
            homePage.GoTo();
            homePage.Slider.ClickRightButton();
            Assert.IsTrue(homePage.Slider.ImageChanged);
        }
    }
}
