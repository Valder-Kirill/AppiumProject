using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.Elements
{
    public class ButtonElement : BaseElement
    {
        private AndroidElement Element;
        private string ElementName;

        public ButtonElement(AndroidElement element, string elementName) : base(element, elementName)
        {
            Element = element;
            ElementName = elementName;
        }
    }
}
