using AppiumTestProject.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.PageObjects
{
    public class ConfirmDeleteExpensesForm
    {
        private static AppiumDriver<AndroidElement> Driver;

        private ButtonElement DeleteBtn => new ButtonElement(Driver.FindElementById("android:id/button1"), "Delete Button");

        public ConfirmDeleteExpensesForm(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public void ClickDeleteBtn()
        {
            DeleteBtn.Click();
        }
    }
}
