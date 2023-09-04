using AppiumTestProject.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.PageObjects
{
    public class SelectTricountCreationPage
    {
        private static AppiumDriver<AndroidElement> Driver;

        private ButtonElement NewTricountBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/fab_add_fab"), "New tricount button");

        public SelectTricountCreationPage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public void AddNewTricount()
        {
            NewTricountBtn.Click();
        }
    }
}
