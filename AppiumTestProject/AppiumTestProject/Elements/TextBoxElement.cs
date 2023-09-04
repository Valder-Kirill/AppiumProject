using AppiumTestProject.Utils;
using OpenQA.Selenium.Appium.Android;
using System;

namespace AppiumTestProject.Elements
{
    public class TextBoxElement : BaseElement
    {
        private AndroidElement Element;
        private string ElementName;

        public TextBoxElement(AndroidElement element, string elementName) : base(element, elementName)
        {
            Element = element;
            ElementName = elementName;
        }

        public void SendKeys(string text)
        {
            try
            {
                LogHelper.WriteMessage("Заполняем текстовое поле '" + ElementName + "'");
                Element.SendKeys(text);
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceprion(ex);
            }
        }

        
    }
}
