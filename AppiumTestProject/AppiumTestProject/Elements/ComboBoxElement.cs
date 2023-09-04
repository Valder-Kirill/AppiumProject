using OpenQA.Selenium.Appium.Android;

namespace AppiumTestProject.Elements
{
    public class ComboBoxElement : BaseElement
    {
        private AndroidElement Element;
        private string ElementName;

        public ComboBoxElement(AndroidElement element, string elementName) : base(element, elementName)
        {
            Element = element;
            ElementName = elementName;
        }

        public string GetValue()
        {
            return Element.Text;
        }
    }
}
