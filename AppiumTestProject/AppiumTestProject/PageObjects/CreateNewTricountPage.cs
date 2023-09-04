using AppiumTestProject.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;

namespace AppiumTestProject.PageObjects
{
    public class CreateNewTricountPage
    {
        private static AppiumDriver<AndroidElement> Driver;

        private TextBoxElement TitleTextBox => new TextBoxElement(Driver.FindElementById("com.tribab.tricount.android:id/activity_create_tricount_title"), "Title text box");
        private TextBoxElement DescriptionTextBox => new TextBoxElement(Driver.FindElementById("com.tribab.tricount.android:id/activity_create_tricount_description"), "Description text box");
        private ButtonElement Category(int i) => new ButtonElement(Driver.FindElementById($"com.tribab.tricount.android:id/category{i}"), "Category");
        private TextBoxElement NameTextBox() => new TextBoxElement(Driver.FindElementById("com.tribab.tricount.android:id/activity_create_tricount_participant_input"), "Name text box");
        private ButtonElement AddNameBtn() => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/add_participant_button"), "Add name button");
        private ButtonElement DoneBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/done"), "Done button");

        public CreateNewTricountPage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public void FillInCreateNewTricountPage(string title, string description, int category, string[] names, string email = null)
        {
            TitleTextBox.SendKeys(title);
            DescriptionTextBox.SendKeys(description);
            TitleTextBox.Click();
            Category(category).Click();
            Driver.HideKeyboard();
            TouchAction touch = new TouchAction(Driver);
            foreach (var name in names)
            {
                touch.Press(NameTextBox().GetAndroidElement()).Release().Perform();
                NameTextBox().SendKeys(name);
                AddNameBtn().Click();
            }
            DoneBtn.Click();
        }

        public bool IsOpen()
        {
            return TitleTextBox.IsDisplayed();
        }
    }
}
