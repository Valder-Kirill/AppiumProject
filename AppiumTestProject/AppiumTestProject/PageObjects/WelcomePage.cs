using AppiumTestProject.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.PageObjects
{
    public class WelcomePage
    {
        private static AppiumDriver<AndroidElement> Driver;

        private LabelElement Header => new LabelElement(Driver.FindElementById("com.tribab.tricount.android:id/first_string"), "Header");
        private ButtonElement NextBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/action_button"), "Next button");

        public WelcomePage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public void ConfirmEverythingInTheStartWindow()
        {
            for (var i = 0; i < 5; i++)
            {
                Header.GetText();
                NextBtn.Click();
            }
        }
    }
}
