using AppiumTestProject.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.PageObjects
{
    public class CreateNewExpensePage
    {
        private static AppiumDriver<AndroidElement> Driver;

        private TextBoxElement TitleTextBox => new TextBoxElement(Driver.FindElementByXPath("//android.widget.EditText[@text='Title']"), "Title text box");
        private ButtonElement DoneBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/done"), "Done Button");
        private TextBoxElement AmountTextBox => new TextBoxElement(Driver.FindElementByXPath("//android.widget.EditText[@text='Amount']"), "Amount text box");

        public CreateNewExpensePage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public void CreateNewExpense(string title, double amount)
        {
            TitleTextBox.SendKeys(title);
            AmountTextBox.SendKeys(amount.ToString());
            DoneBtn.Click();
        }

    }
}
