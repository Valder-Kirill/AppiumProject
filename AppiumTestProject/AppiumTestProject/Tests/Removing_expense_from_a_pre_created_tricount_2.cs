using AppiumTestProject.PageObjects;
using AppiumTestProject.Utils;
using NUnit.Framework;

namespace AppiumTestProject.Tests
{
    public class Removing_expense_from_a_pre_created_tricount_2 : BaseTest
    {
        private WelcomePage WelcomePage => new WelcomePage(Driver);
        private MainPage MainPage => new MainPage(Driver);
        private WhoAreYouForm WhoAreYouForm => new WhoAreYouForm(Driver);
        private TricountExpensesPage TricountExpensesPage => new TricountExpensesPage(Driver);
        private TricountBalancesPage TricountBalancesPage => new TricountBalancesPage(Driver);
        private ConfirmDeleteExpensesForm ConfirmDeleteExpensesForm => new ConfirmDeleteExpensesForm(Driver);

        string TricountName = "City trip";
        string UserName = "Alex";
        string MemberName1 = "Brian";
        string MemberName2 = "Julia";
        string MemberName3 = "Thomas";

        [Test]
        public void Test()
        {
            LogHelper.WriteStepHeader("2 3 4", "Принять условия приватности и куки");
            WelcomePage.ConfirmEverythingInTheStartWindow();
            MainPage.IsOpen();

            LogHelper.WriteStepHeader("5", "Выбрать уже созданный трикаунт «City trip»");
            MainPage.OpenTricount(TricountName);

            LogHelper.WriteStepHeader("6", "Выбрать любое имя");
            WhoAreYouForm.SelectUser(UserName);
            TricountExpensesPage.IsOpen();

            LogHelper.WriteStepHeader("7", "Перейти на вкладку баланса");
            TricountExpensesPage.OpenBalances();
            Assert.IsTrue(TricountBalancesPage.IsOpen(), "Страница баланса не открыта!");

            LogHelper.WriteStepHeader("8", "Проверка балансов участников");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(UserName) != 0, $"Баланс {UserName} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MemberName1) != 0, $"Баланс {MemberName1} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MemberName2) != 0, $"Баланс {MemberName2} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MemberName3) != 0, $"Баланс {MemberName3} не соответствует ожидаемому!");
            LogHelper.WriteMessage("Балансы соответствуют ожидаемым значениям.");

            LogHelper.WriteStepHeader("9", "Перейти обратно на Expenses");
            TricountBalancesPage.OpenExpenses();
            Assert.IsTrue(TricountExpensesPage.IsOpen(), "Страница Expenses не открыта!");

            LogHelper.WriteStepHeader("10", "Выделить все элементы на этой вкладке и нажать на урну для удаления");
            TricountExpensesPage.LongPressTransaction();
            TricountExpensesPage.ClickDeleteBtn();

            LogHelper.WriteStepHeader("11", "Подтвердить удаление");
            ConfirmDeleteExpensesForm.ClickDeleteBtn();

            LogHelper.WriteStepHeader("12", "Перейти на вкладку баланса");
            TricountExpensesPage.OpenBalances();
            Assert.IsTrue(TricountBalancesPage.IsOpen(), "Страница баланса не открыта!");

            LogHelper.WriteStepHeader("13", "Проверка балансов участников");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(UserName) == 0, $"Баланс {UserName} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MemberName1) == 0, $"Баланс {MemberName1} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MemberName2) == 0, $"Баланс {MemberName2} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MemberName3) == 0, $"Баланс {MemberName3} не соответствует ожидаемому!");
            LogHelper.WriteMessage("Балансы соответствуют ожидаемым значениям.");
        }
    }
}
