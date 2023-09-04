using OpenQA.Selenium.Appium.Android;
using System;

namespace AppiumTestProject.Elements
{
    class CheckBoxElement : BaseElement
    {
        private AndroidElement Element;
        private string ElementName;

        public CheckBoxElement(AndroidElement element, string elementName) : base(element, elementName)
        {
            Element = element;
            ElementName = elementName;
        }

        public bool IsChecked()
        {
            return Convert.ToBoolean(Element.GetAttribute("checked"));
        }
    }
}
