using AppiumTestProject.Utils;
using OpenQA.Selenium.Appium.Android;
using System;

namespace AppiumTestProject.Elements
{
    public class LabelElement : BaseElement
    {
        private AndroidElement Element;
        private string ElementName;

        public LabelElement(AndroidElement element, string elementName) : base(element, elementName)
        {
            Element = element;
            ElementName = elementName;
        }
    }
}
