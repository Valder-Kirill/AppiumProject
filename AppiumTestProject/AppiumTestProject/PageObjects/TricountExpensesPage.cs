using AppiumTestProject.Elements;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Collections.Generic;
using System.Linq;

namespace AppiumTestProject.PageObjects
{
    public class TricountExpensesPage
    {
        private static AppiumDriver<AndroidElement> Driver;
        private static TouchAction Action => new TouchAction(Driver);

        private ButtonElement AddBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/bottomAppBarAddButton"), "Add button");
        private ButtonElement BalancesBtn => new ButtonElement(Driver.FindElementByXPath("//android.widget.LinearLayout[@content-desc=\"Balances\"]"), "Balances button");
        private List<AndroidElement> Transactions => new List<AndroidElement>(Driver.FindElementsById($"com.tribab.tricount.android:id/rootTransaction"));
        private ButtonElement DeleteBtn => new ButtonElement(Driver.FindElementById("com.tribab.tricount.android:id/delete"), "Delete button");
         
        public TricountExpensesPage(AppiumDriver<AndroidElement> driver)
        {
            Driver = driver;
        }

        public bool IsOpen()
        {
            return AddBtn.IsDisplayed();
        }

        public void OpenBalances()
        {
            BalancesBtn.Click();
        }

        public void ClickAddBtn()
        {
            AddBtn.Click();
        }

        public void LongPressTransaction(string name = null) 
        {
            if(name != null)
            {
                Action.LongPress(Transactions.Where(t => t.FindElementById("com.tribab.tricount.android:id/item_transaction_title").Text.Contains(name)).FirstOrDefault()).Release().Perform();
            }
            else
            {
                foreach (var transaction in Transactions)
                {
                    Action.LongPress(transaction).Release().Perform();
                }
            }
        }

        public void ClickDeleteBtn()
        {
            DeleteBtn.Click();
        }

        public void OpenExpense(string name = null)
        {
            if (name != null)
            {
                Transactions.Where(t => t.Text == name).FirstOrDefault().Click();
            }
            else
            {
                Transactions.FirstOrDefault().Click();
            }
        }

        public bool ExpenseIsExist(string name)
        {
            return Transactions.Where(t => t.FindElementById("com.tribab.tricount.android:id/item_transaction_title").Text.Contains(name)).FirstOrDefault().Displayed;
        }
    }
}
