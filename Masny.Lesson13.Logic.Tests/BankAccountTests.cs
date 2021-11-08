using System;
using Xunit;

namespace Masny.Lesson13.Logic.Tests
{
    /// <summary>
    /// Bank account tests.
    /// </summary>
    public class BankAccountTests
    {
        [Fact]
        public void Constructor_CorrectValues_Returns_FilledProperies()
        {
            // Arrange
            var testCustomerName = "TestCustomerName";
            var testBalance = 10.01;

            // Act
            var bankAccount = new BankAccount(testCustomerName, testBalance);

            // Assert
            Assert.Equal(testCustomerName, bankAccount.CustomerName);
            Assert.Equal(testBalance, bankAccount.Balance);
        }

        [Fact]
        public void Debit_CorrectAmount_Returns_CorrectBalance()
        {
            // Arrange
            var testCustomerName = "TestCustomerName";
            var testBalance = 10.01;
            var amount = 0D;

            var bankAccount = new BankAccount(testCustomerName, testBalance);

            // Act
            bankAccount.Debit(amount);

            // Assert
            Assert.Equal(testBalance + amount, bankAccount.Balance);
        }

        [Fact]
        public void Debit_AmountBiggerThenBalance_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var testCustomerName = "TestCustomerName";
            var testBalance = 10.01;

            var bankAccount = new BankAccount(testCustomerName, testBalance);

            // Act
            //Action testWrite = () => bankAccount.Debit(11);

            // Assert
            //Assert.Throws<ArgumentOutOfRangeException>(testWrite);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => bankAccount.Debit(11));

            Assert.Equal(
                "Specified argument was out of the range of valid values. (Parameter 'amount')",
                exception.Message);
        }

        [Fact]
        public void Debit_AmountLowerThenZero_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var testCustomerName = "TestCustomerName";
            var testBalance = 10.01;

            var bankAccount = new BankAccount(testCustomerName, testBalance);

            // Act
            //Action testWrite = () => bankAccount.Debit(11);

            // Assert
            //Assert.Throws<ArgumentOutOfRangeException>(testWrite);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => bankAccount.Debit(-1));

            Assert.Equal(
                "Specified argument was out of the range of valid values. (Parameter 'amount')",
                exception.Message);
        }

        [Fact]
        public void Credit_CorrectAmount_Returns_CorrectBalance()
        {
            // Arrange
            var testCustomerName = "TestCustomerName";
            var testBalance = 10.01;
            var amount = 10D;

            var bankAccount = new BankAccount(testCustomerName, testBalance);

            // Act
            bankAccount.Credit(amount);

            // Assert
            Assert.Equal(testBalance + amount, bankAccount.Balance);
        }

        [Fact]
        public void Credit_AmountLowerThenZero_Throws_ArgumentOutOfRangeException()
        {
            // Arrange
            var testCustomerName = "TestCustomerName";
            var testBalance = 10.01;

            var bankAccount = new BankAccount(testCustomerName, testBalance);

            // Act
            //Action testWrite = () => bankAccount.Credit(11);

            // Assert
            //Assert.Throws<ArgumentOutOfRangeException>(testWrite);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => bankAccount.Credit(-1D));
            Assert.Equal(
                "Specified argument was out of the range of valid values. (Parameter 'amount')",
                exception.Message);
        }

        //[Fact]
        //public void Main_CorrectValues_Returns_CorrectBalanceAndCustomerName()
        //{
        //    // Arrange
        //    var testCustomerName = "Mr. Bryan Walton";
        //    var testBalance = 11.99;
        //    var credit = 5.77;
        //    var debit = 11.22;

        //    // Act
        //    var bankAccount = BankAccount.Main();

        //    // Assert
        //    Assert.Equal(testCustomerName, bankAccount.CustomerName);
        //    Assert.Equal(testBalance + credit + debit, bankAccount.Balance);
        //}
    }
}
