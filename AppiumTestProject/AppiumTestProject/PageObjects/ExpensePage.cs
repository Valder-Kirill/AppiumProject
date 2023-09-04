using AppiumTestProject.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.PageObjects
{
    public class ExpensePage
    {
        private static AppiumDriver<AndroidElement> Driver;

        private ButtonElement EditBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/editTransaction"), "Edit button");
        private ButtonElement BackBtn => new ButtonElement(Driver.FindElementByAccessibilityId("Navigate up"), "Back button");
        private TextBoxElement AmountTB => new TextBoxElement(Driver.FindElementById("com.tribab.tricount.android:id/transactionReadOnlyOriginalAmount"), "Amount text box");

        public ExpensePage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public double GetAmount()
        {
            return double.Parse(AmountTB.GetText().Replace("$", "").Replace(",", "").Replace(".", ",").Replace("+", ""));
        }

        public bool IsOpen()
        {
            return EditBtn.IsDisplayed();
        }

        public void EditClick()
        {
            EditBtn.Click();
        }

        public void Back()
        {
            BackBtn.Click();
        }
    }
}
