using AppiumTestProject.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.PageObjects
{
    public class WhoAreYouForm
    {
        private static AppiumDriver<AndroidElement> Driver;

        private ButtonElement Name(string name) => new ButtonElement(Driver.FindElementByXPath($"//android.widget.TextView[@text='{name}']"), $"Name: {name}");

        public WhoAreYouForm(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public void SelectUser(string name)
        {
            Name(name).Click();
        }
    }
}
