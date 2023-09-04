using AppiumTestProject.Elements;
using AppiumTestProject.Models;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppiumTestProject.PageObjects
{
    public class TricountBalancesPage
    {
        private static AppiumDriver<AndroidElement> Driver;

        private ReadOnlyCollection<AndroidElement> RightTextView => Driver.FindElementsById("com.tribab.tricount.android:id/widget_balance_right_text_view");
        private ReadOnlyCollection<AndroidElement> LeftTextView => Driver.FindElementsById("com.tribab.tricount.android:id/widget_balance_left_text_view");
        private ButtonElement ExpensesBtn => new ButtonElement(Driver.FindElementByXPath(@"//android.widget.LinearLayout[@content-desc=""Expenses""]"), "Expenses button");
        private LabelElement HowShoultIBalanceNameTo => new LabelElement(Driver.FindElementById(@"com.tribab.tricount.android:id/item_reimbursement_to_text_view"), "How shoult i balance name to");
        private LabelElement HowShoultIBalanceNameFrom => new LabelElement(Driver.FindElementById(@"com.tribab.tricount.android:id/item_reimbursement_from_text_view"), "How shoult i balance name from");
        private LabelElement HowShoultIBalanceAmount => new LabelElement(Driver.FindElementById(@"com.tribab.tricount.android:id/item_reimbursement_amount_text_view"), "How shoult i balance name amount");

        public TricountBalancesPage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public double? GetBalanceByName(string name)
        {
            double? res = null;

            for (var i = 0; i < RightTextView.Count; i++)
            {
                if (RightTextView[i].Text.Contains(name) || LeftTextView[i].Text.Contains(name))
                {
                    if (RightTextView[i].Text.Contains("$"))
                    {
                        res = double.Parse(RightTextView[i].Text.Replace("$", "").Replace(".", ",").Replace("+", ""));
                    }
                    else
                    {
                        res = double.Parse(LeftTextView[i].Text.Replace("$", "").Replace(".", ",").Replace("+", ""));
                    }
                }
            }

            return res;
        }

        public HowShouldIBalanceModel CheckHowShouldIBalance()
        {
            return new HowShouldIBalanceModel()
            {
                NameTo = HowShoultIBalanceNameTo.GetText(),
                NameFrom = HowShoultIBalanceNameFrom.GetText(),
                Amount = double.Parse(HowShoultIBalanceAmount.GetText().Replace("$", "").Replace(".", ",").Replace("+", ""))
            };
        }

        public void OpenExpenses()
        {
            ExpensesBtn.Click();
        }

        public bool IsOpen()
        {
            return RightTextView.First().Displayed;
        }
    }
}
