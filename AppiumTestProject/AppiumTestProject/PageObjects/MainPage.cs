using AppiumTestProject.Elements;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.PageObjects
{
    public class MainPage 
    {
        private static AppiumDriver<AndroidElement> Driver;

        private ButtonElement AddTricountBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/activity_main_button_add_tricount"), "Add tricount button");
        private LabelElement TricountTitle(string name) => new LabelElement(Driver.FindElementByXPath($"//android.widget.TextView[@text='{name}']"), "Tricount title"); 

        public MainPage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public void ClickAddNewTricountBtn()
        {
            AddTricountBtn.Click();
        }

        public void OpenTricount(string name)
        {
            TricountTitle(name).Click();
        }

        public bool IsOpen()
        {
            return AddTricountBtn.IsDisplayed();
        }
    }
}
