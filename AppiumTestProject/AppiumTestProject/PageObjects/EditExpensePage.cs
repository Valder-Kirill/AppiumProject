using AppiumTestProject.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.PageObjects
{
    public class EditExpensePage
    {
        private static AppiumDriver<AndroidElement> Driver;

        private TextBoxElement Amount => new TextBoxElement((AndroidElement)Driver.FindElementById("com.tribab.tricount.android:id/activity_transaction_amount_wrapper").FindElementByXPath("//android.widget.EditText"), "Amount text box");
        private CheckBoxElement ForWhomCheckB => new CheckBoxElement(Driver.FindElementById("com.tribab.tricount.android:id/activity_transaction_participants_check_box"), "For whom check box");
        private ComboBoxElement PaidByComboB => new ComboBoxElement(Driver.FindElementById("com.tribab.tricount.android:id/spinner"), "Paid by combo box");
        private ButtonElement DoneBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/done"), "Done button");
        private TextBoxElement PaidByTextBox(string name) => new TextBoxElement(Driver.FindElementByXPath($"//android.widget.CheckedTextView[@text='{name}']"), "Paid by text box");

        public EditExpensePage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public bool IsOpen()
        {
            return Amount.IsDisplayed();
        }

        public void AmountFillIn(double amount)
        {
            Amount.SendKeys(amount.ToString());
        }

        public void SelectAllMembers()
        {
            if (!ForWhomCheckB.IsChecked())
            {
                ForWhomCheckB.Click();
            }
        }

        public void PaidBySelect(string userName)
        {
            PaidByComboB.Click();
            PaidByTextBox(userName).Click();
        }

        public void DoneBtnClick()
        {
            DoneBtn.Click();
        }

    }
}
