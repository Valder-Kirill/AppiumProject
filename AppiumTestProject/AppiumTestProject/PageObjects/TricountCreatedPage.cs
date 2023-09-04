using AppiumTestProject.Elements;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.PageObjects
{
    public class TricountCreatedPage
    {
        private static AppiumDriver<AndroidElement> Driver;

        private LabelElement ParticipantsItem => new LabelElement(Driver.FindElementById("com.tribab.tricount.android:id/limitedParticipantsList1"), "Participants item");
        private ButtonElement DoneBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/shareTricountDoneBtn"), "Done button");

        public TricountCreatedPage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public string GetParticipantsItemText()
        {
            return ParticipantsItem.GetText();
        }

        public void ClickDoneBtn()
        {
            DoneBtn.Click();
        }
    }
}
