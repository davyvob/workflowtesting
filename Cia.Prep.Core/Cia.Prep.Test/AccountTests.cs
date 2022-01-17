using Howest.Cia.Bank.Core;
using System;
using Xunit;

namespace Howest.Cia.Bank.Tests
{
    public class AccountTests
    {
        [Theory]
        [InlineData(150, 50, 100)]
        [InlineData(50, 25, 25)]
        [InlineData(15000, 2345, 12655)]
        public void Withdraw_WithValidAmount_UpdatesBalanceCorrectly(decimal startBalance, decimal amount, decimal endBalance)
        {
            //Arrange
            decimal initialAmount = startBalance;
            Account account = new Account(initialAmount);
            decimal amountToWithdraw = amount;
            decimal expectedBalance = endBalance;

            //Act
            decimal actualBalance = account.Withdraw(amountToWithdraw);

            //Assert
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Fact]
        public void Withdraw_WithAmountGreaterThenBalance_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            decimal initialAmount = 50M;
            Account account = new Account(initialAmount);
            decimal amountToWithdraw = 60M;
            string expectedErrorMessage = Account.AmountExceedsBalanceErrorMessage;

            //Assert on Act
            var actualException = Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(amountToWithdraw));
            Assert.Equal(expectedErrorMessage, actualException.Message);

        }

        [Fact]
        public void Deposit_WithValidAmount_UpdatesBalanceCorrectly()
        {
            //Arrange
            decimal initialAmount = 500M;
            Account account = new Account(initialAmount);
            decimal amountToDeposit = 100M;
            decimal expectedBalance = 600M;

            //Act
            decimal actualBalance = account.Deposit(amountToDeposit);

            //Assert
            Assert.Equal(expectedBalance, actualBalance);
        }

        [Fact]
        public void Deposit_WithAmountLessThenZero_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            decimal initialAmount = 500M;
            Account account = new Account(initialAmount);
            decimal amountToDeposit = -50M;
            string expectedErrorMessage = Account.AmountLessThanZeroErrorMessage;

            //Assert on Act
            var actualException = Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(amountToDeposit));
            Assert.Equal(expectedErrorMessage, actualException.Message);
        }

        [Fact]
        public void Deposit_WithAmountHigherThan2000_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            decimal initialAmount = 500M;
            Account account = new Account(initialAmount);
            decimal amountToDeposit = 2001M;
            string expectedErrorMessage = account.AmountExceedsMaximumAmountErrorMessage;

            //Assert on Act
            var actualException = Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(amountToDeposit));
            Assert.Equal(expectedErrorMessage, actualException.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Withdraw_WithAmountLessThanOrEqualToZero_ThrowsArgumentOutOfRangeException(decimal amount)
        {
            //Arrange
            decimal initialAmount = 50M;
            Account account = new Account(initialAmount);
            decimal amountToWithdraw = amount;
            string expectedErrorMessage = Account.AmountLessThanZeroErrorMessage;

            //Assert on Act
            var actualException = Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(amountToWithdraw));
            Assert.Equal(expectedErrorMessage, actualException.Message);

        }
    }
}

