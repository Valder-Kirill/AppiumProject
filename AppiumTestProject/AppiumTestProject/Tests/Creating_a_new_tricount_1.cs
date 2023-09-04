using AppiumTestProject.PageObjects;
using AppiumTestProject.Utils;
using NUnit.Framework;

namespace AppiumTestProject.Tests
{
    public class Creating_a_new_tricount_1 : BaseTest
    {
        private WelcomePage WelcomePage => new WelcomePage(Driver);
        private MainPage MainPage => new MainPage(Driver);
        private SelectTricountCreationPage SelectTricountCreationPage => new SelectTricountCreationPage(Driver);
        private CreateNewTricountPage CreateNewTricountPage => new CreateNewTricountPage(Driver);
        private TricountCreatedPage TricountCreatedPage => new TricountCreatedPage(Driver);
        private TricountExpensesPage TricountExpensesPage => new TricountExpensesPage(Driver);
        private TricountBalancesPage TricountBalancesPage => new TricountBalancesPage(Driver);
        private CreateNewExpensePage CreateNewExpensePage => new CreateNewExpensePage(Driver);

        private string MainName = "Viktor";
        private string SecondName = "Lida";
        private string Email = "mile@bk.ru";
        private string TricountTitle = "Good tricount";
        private string ExpenseTitle = "New expense";
        private string TricountDescription = "Oh, tricount description....!";
        private double Amount = 10;
        private int TricountCategory = 1;

        [Test]
        public void Test()
        {
            LogHelper.WriteStepHeader("2 3 4", "Принять условия приватности и куки");
            WelcomePage.ConfirmEverythingInTheStartWindow();
            Assert.IsTrue(MainPage.IsOpen(), "Главная страница не открыта!");

            LogHelper.WriteStepHeader("5", "Нажать на «+», выбрать «New tricount»");
            MainPage.ClickAddNewTricountBtn();
            SelectTricountCreationPage.AddNewTricount();
            Assert.IsTrue(CreateNewTricountPage.IsOpen(), "Страница создания нового трикаунта не открыта!");

            LogHelper.WriteStepHeader("6 7 8 9", "Создать новый tricount");
            CreateNewTricountPage.FillInCreateNewTricountPage(TricountTitle, TricountDescription, TricountCategory, new string[] { MainName, SecondName }, Email);
            Assert.AreEqual(TricountCreatedPage.GetParticipantsItemText(), SecondName, "Имя пользователя на странице Following participant не соответствует ожидаемому!");
            TricountCreatedPage.ClickDoneBtn();
            Assert.IsTrue(TricountExpensesPage.IsOpen(), "Страница Expenses не открыта!");

            LogHelper.WriteStepHeader("10", "Перейти на вкладку баланса");
            TricountExpensesPage.OpenBalances();
            Assert.IsTrue(TricountBalancesPage.IsOpen(), "Страница баланса не открыта!");

            LogHelper.WriteStepHeader("11", "Проверка балансов участников");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MainName) == 0, $"Баланс {MainName} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(SecondName) == 0, $"Баланс {SecondName} не соответствует ожидаемому!");
            LogHelper.WriteMessage("Балансы соответствуют ожидаемым значениям.");

            LogHelper.WriteStepHeader("12", "Перейти обратно на Expenses и добавить новый Expenses");
            TricountBalancesPage.OpenExpenses();
            Assert.IsTrue(TricountExpensesPage.IsOpen(), "Страница Expenses не открыта!");
            TricountExpensesPage.ClickAddBtn();

            LogHelper.WriteStepHeader("13", "Создать новый Expenses");
            CreateNewExpensePage.CreateNewExpense(ExpenseTitle, Amount);
            TricountExpensesPage.ExpenseIsExist(ExpenseTitle);

            LogHelper.WriteStepHeader("14", "Проверка баланса");
            TricountExpensesPage.OpenBalances();
            Assert.IsTrue(TricountBalancesPage.IsOpen(), "Страница баланса не открыта!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MainName) == Amount / 2, $"Баланс {MainName} не соответствует ожидаемому!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(SecondName) == Amount / 2 * -1, $"Баланс {SecondName} не соответствует ожидаемому!");
            LogHelper.WriteMessage("Балансы соответствуют ожидаемым значениям.");

            LogHelper.WriteStepHeader("15", "Проверка How should I balance");
            var howShouldIBalance = TricountBalancesPage.CheckHowShouldIBalance();

            Assert.IsTrue(howShouldIBalance.NameTo.Contains(MainName) && howShouldIBalance.NameFrom.Contains(SecondName) &&
                howShouldIBalance.Amount == Amount / 2, "How should I balance содержить некорректные данные!");
            LogHelper.WriteMessage("How should I balance содержит корректные данные");
        }
    }
}