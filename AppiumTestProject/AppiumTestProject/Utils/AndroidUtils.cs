using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.IO;

namespace AppiumTestProject.Utils
{
    public static class AndroidUtils
    {
        private static AppiumDriver<AndroidElement> Driver;

        public static AppiumDriver<AndroidElement> StartTricountApp()
        {
            try
            {
                if (Driver == null)
                {
                    var driverOption = new AppiumOptions();
                    driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, ConfigUtils.GetAndroidConfig("platformName"));
                    driverOption.AddAdditionalCapability(MobileCapabilityType.App, Directory.GetCurrentDirectory() + ConfigUtils.GetAndroidConfig("app"));
                    driverOption.AddAdditionalCapability(AndroidMobileCapabilityType.AppWaitActivity, ConfigUtils.GetAndroidConfig("appWaitActivity"));
                    driverOption.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, ConfigUtils.GetAndroidConfig("appPackage"));

                    Driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                    LogHelper.WriteMessage("Экземпляр драйвера успешно создан!");
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceprion(ex);
                throw;
            }

            return Driver;
        }
    }
}
