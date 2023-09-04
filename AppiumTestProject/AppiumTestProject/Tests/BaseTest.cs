using AppiumTestProject.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.Tests
{
    public class BaseTest
    {
        protected AppiumDriver<AndroidElement> Driver;

        [SetUp]
        public void Setup()
        {
            LogHelper.WriteStepHeader("1", "Установить и открыть приложение");
            Driver = AndroidUtils.StartTricountApp();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
