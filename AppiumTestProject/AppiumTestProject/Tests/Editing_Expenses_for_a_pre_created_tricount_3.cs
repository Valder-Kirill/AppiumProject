using AppiumTestProject.PageObjects;
using AppiumTestProject.Utils;
using NUnit.Framework;

namespace AppiumTestProject.Tests
{
    public class Editing_Expenses_for_a_pre_created_tricount_3 : BaseTest
    {
        private WelcomePage WelcomePage => new WelcomePage(Driver);
        private MainPage MainPage => new MainPage(Driver);
        private WhoAreYouForm WhoAreYouForm => new WhoAreYouForm(Driver);
        private TricountExpensesPage TricountExpensesPage => new TricountExpensesPage(Driver);
        private TricountBalancesPage TricountBalancesPage => new TricountBalancesPage(Driver);
        private ConfirmDeleteExpensesForm ConfirmDeleteExpensesForm => new ConfirmDeleteExpensesForm(Driver);
        private ExpensePage ExpensePage => new ExpensePage(Driver);
        private EditExpensePage EditExpensePage => new EditExpensePage(Driver);

        string TricountName = "City trip";
        string[] TransactionToDelete = new string[]
        {
            "Hotel",
            "Car"
        };
        string UserName = "Alex";
        string MemberName1 = "Brian";
        string MemberName2 = "Julia";
        string MemberName3 = "Thomas";
        double Amount = 1000;

        [Test]
        public void Test()
        {
            LogHelper.WriteStepHeader("2 3 4", "Принять условия приватности и куки");
            WelcomePage.ConfirmEverythingInTheStartWindow();
            MainPage.IsOpen();

            LogHelper.WriteStepHeader("5", $"Выбрать уже созданный трикаунт «{TricountName}»");
            MainPage.OpenTricount(TricountName);

            LogHelper.WriteStepHeader("6", "Выбрать любое имя");
            WhoAreYouForm.SelectUser(UserName);
            TricountExpensesPage.IsOpen();

            LogHelper.WriteStepHeader("7", "Оставить только один элемент на вкладке Expenses");
            foreach(var transaction in TransactionToDelete)
            {
                TricountExpensesPage.LongPressTransaction(transaction);
            }
            TricountExpensesPage.ClickDeleteBtn();

            LogHelper.WriteStepHeader("8", "Подтвердить удаление");
            ConfirmDeleteExpensesForm.ClickDeleteBtn();

            LogHelper.WriteStepHeader("9", "Перейти на вкладку баланса");
            TricountExpensesPage.OpenBalances();
            Assert.IsTrue(TricountBalancesPage.IsOpen(), "Страница баланса не открыта!");

            LogHelper.WriteStepHeader("10", "Зафиксировать балансы участников");
            var mainUserBalance = TricountBalancesPage.GetBalanceByName(UserName);
            var member1Balance = TricountBalancesPage.GetBalanceByName(MemberName1);
            var member2Balance = TricountBalancesPage.GetBalanceByName(MemberName2);
            var member3Balance = TricountBalancesPage.GetBalanceByName(MemberName3);

            LogHelper.WriteStepHeader("11", "Перейти на вкладку Expenses");
            TricountBalancesPage.OpenExpenses();
            Assert.IsTrue(TricountExpensesPage.IsOpen(), "Страница Expenses не открыта!");

            LogHelper.WriteStepHeader("12", "Открыть первый элемент");
            TricountExpensesPage.OpenExpense();
            Assert.IsTrue(ExpensePage.IsOpen(), "Страница элемента Expenses не открыта!");

            LogHelper.WriteStepHeader("13", "Нажать Edit для редактирования");
            ExpensePage.EditClick();
            Assert.IsTrue(EditExpensePage.IsOpen(), "Страница редактирования элемента expense не открыта!");

            LogHelper.WriteStepHeader("14", "Поставить Amount в 1000$ и убедиться, что каждый участник включён в expense, оплата на основном пользователе");
            EditExpensePage.AmountFillIn(Amount);
            EditExpensePage.PaidBySelect(UserName);
            EditExpensePage.SelectAllMembers();
            EditExpensePage.DoneBtnClick();
            Assert.AreEqual(ExpensePage.GetAmount(), Amount, "Сумма не верна!");
            LogHelper.WriteMessage("Сумма верна!");
            ExpensePage.Back();

            LogHelper.WriteStepHeader("15", "Перейти на вкладку баланса");
            TricountExpensesPage.OpenBalances();
            Assert.IsTrue(TricountBalancesPage.IsOpen(), "Страница баланса не открыта!");

            LogHelper.WriteStepHeader("16", "Проверка балансов участников");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(UserName) == Amount * 0.75, $"Баланс {UserName} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MemberName1) == Amount * 0.25 * -1, $"Баланс {MemberName1} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MemberName2) == Amount * 0.25 * -1, $"Баланс {MemberName2} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MemberName3) == Amount * 0.25 * -1, $"Баланс {MemberName3} не соответствует ожидаемому!");
            LogHelper.WriteMessage("Балансы соответствуют ожидаемым значениям.");
        }
    }
}
