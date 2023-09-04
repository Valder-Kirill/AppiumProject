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
            LogHelper.WriteStepHeader("2 3 4", "������� ������� ����������� � ����");
            WelcomePage.ConfirmEverythingInTheStartWindow();
            Assert.IsTrue(MainPage.IsOpen(), "������� �������� �� �������!");

            LogHelper.WriteStepHeader("5", "������ �� �+�, ������� �New tricount�");
            MainPage.ClickAddNewTricountBtn();
            SelectTricountCreationPage.AddNewTricount();
            Assert.IsTrue(CreateNewTricountPage.IsOpen(), "�������� �������� ������ ��������� �� �������!");

            LogHelper.WriteStepHeader("6 7 8 9", "������� ����� tricount");
            CreateNewTricountPage.FillInCreateNewTricountPage(TricountTitle, TricountDescription, TricountCategory, new string[] { MainName, SecondName }, Email);
            Assert.AreEqual(TricountCreatedPage.GetParticipantsItemText(), SecondName, "��� ������������ �� �������� Following participant �� ������������� ����������!");
            TricountCreatedPage.ClickDoneBtn();
            Assert.IsTrue(TricountExpensesPage.IsOpen(), "�������� Expenses �� �������!");

            LogHelper.WriteStepHeader("10", "������� �� ������� �������");
            TricountExpensesPage.OpenBalances();
            Assert.IsTrue(TricountBalancesPage.IsOpen(), "�������� ������� �� �������!");

            LogHelper.WriteStepHeader("11", "�������� �������� ����������");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MainName) == 0, $"������ {MainName} �� ������������� ����������!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(SecondName) == 0, $"������ {SecondName} �� ������������� ����������!");
            LogHelper.WriteMessage("������� ������������� ��������� ���������.");

            LogHelper.WriteStepHeader("12", "������� ������� �� Expenses � �������� ����� Expenses");
            TricountBalancesPage.OpenExpenses();
            Assert.IsTrue(TricountExpensesPage.IsOpen(), "�������� Expenses �� �������!");
            TricountExpensesPage.ClickAddBtn();

            LogHelper.WriteStepHeader("13", "������� ����� Expenses");
            CreateNewExpensePage.CreateNewExpense(ExpenseTitle, Amount);
            TricountExpensesPage.ExpenseIsExist(ExpenseTitle);

            LogHelper.WriteStepHeader("14", "�������� �������");
            TricountExpensesPage.OpenBalances();
            Assert.IsTrue(TricountBalancesPage.IsOpen(), "�������� ������� �� �������!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(MainName) == Amount / 2, $"������ {MainName} �� ������������� ����������!");
            Assert.IsTrue(TricountBalancesPage.GetBalanceByName(SecondName) == Amount / 2 * -1, $"������ {SecondName} �� ������������� ����������!");
            LogHelper.WriteMessage("������� ������������� ��������� ���������.");

            LogHelper.WriteStepHeader("15", "�������� How should I balance");
            var howShouldIBalance = TricountBalancesPage.CheckHowShouldIBalance();

            Assert.IsTrue(howShouldIBalance.NameTo.Contains(MainName) && howShouldIBalance.NameFrom.Contains(SecondName) &&
                howShouldIBalance.Amount == Amount / 2, "How should I balance ��������� ������������ ������!");
            LogHelper.WriteMessage("How should I balance �������� ���������� ������");
        }
    }
}