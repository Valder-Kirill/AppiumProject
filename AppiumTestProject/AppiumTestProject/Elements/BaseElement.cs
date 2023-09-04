using AppiumTestProject.Utils;
using OpenQA.Selenium.Appium.Android;
using System;

namespace AppiumTestProject.Elements
{
    public class BaseElement
    {
        private AndroidElement Element;
        private string ElementName;

        public BaseElement(AndroidElement element, string elementName)
        {
            Element = element;
            ElementName = elementName;
        }

        public void Click()
        {
            try
            {
                LogHelper.WriteMessage("Нажимаем на контрол '" + ElementName + "'");
                Element.Click();
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceprion(ex);
            }
        }

        public bool IsDisplayed()
        {
            LogHelper.WriteMessage("Проверяем отображение контрола '" + ElementName + "'");
            return Element.Displayed;
        }

        public AndroidElement GetAndroidElement()
        {
            return Element;
        }

        public string GetText()
        {
            try
            {
                LogHelper.WriteMessage("Получаем текст из контрола '" + ElementName + "'");
                LogHelper.WriteMessage("Текст: '" + Element.Text + "'");
                return Element.Text;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceprion(ex);
            }

            return "";
        }
    }
}
