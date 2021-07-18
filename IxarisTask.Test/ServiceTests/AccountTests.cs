using IxarisTask.Abstracts;
using IxarisTask.Concretes;
using IxarisTask.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IxarisTask.Test.ServiceTests
{
    /// <summary>
    /// Represents the test cases of AccountService functions
    /// </summary>
    public class AccountTests
    {
        private readonly IAccountService _accountService;
        public AccountTests()
        {
            _accountService = Mock.Of<AccountService>();
        }

        #region Test Cases of ExtractAccounts Function
        /// <summary>
        /// Tests when the paremeter comes null and throws the ArgumentNullException
        /// </summary>
        [Fact]
        public void Should_ThrowArgumentException_When_ParameterListComesNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _accountService.ExtractAccounts(null));
            Assert.Equal("Value cannot be null. (Parameter 'transfers cannot be NULL or empty list!')", exception.Message);

        }
        /// <summary>
        /// Tests when the paremeter comes empty list and returns empty list
        /// </summary>
        [Fact]
        public void Should_ReturnEmptyList_When_ParameterListHasNoItem()
        {
            var accounts = _accountService.ExtractAccounts(new List<Transfer>());
            Assert.Empty(accounts);

        }
        /// <summary>
        /// Tests when the parameter get the proper data and returns the desired result.
        /// </summary>
        /// <param name="transferAmount"></param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Should_ReturnFilledAccountList_When_ParamterListHasItems(int transferAmount)
        {
            var transfers = new List<Transfer>();
            for (int i = 0; i < transferAmount; i++)
            {
                transfers.Add(new Transfer
                {
                    TransferId = FakeData.NumberData.GetNumber(),
                    Amount = Convert.ToDecimal(FakeData.NumberData.GetDouble()),
                    Date = FakeData.DateTimeData.GetDatetime(),
                    SourceAccountId = FakeData.NumberData.GetNumber(),
                    TargetAccountId = FakeData.NumberData.GetNumber(),
                });
            }
            var result = _accountService.ExtractAccounts(transfers);
            Assert.NotEmpty(result);
        }

        #endregion

        #region Test Cases of GetAllFinalBalances Function
        /// <summary>
        ///  Tests when the paremeter comes null and throws the ArgumentNullException
        /// </summary>
        [Fact]
        public void Should_ThrowArgumentNullException_When_AccountParameterComesNull()
        {
            List<Account> account = null;
            var exception = Assert.Throws<ArgumentNullException>(() => _accountService.GetAllFinalBalances(ref account, new List<Transfer>()));
            Assert.Equal("Value cannot be null. (Parameter 'accounts cannot be NULL or empty list!')", exception.Message);
        }
        /// <summary>
        /// Tests when the account paremeter comes empty list and returns empty list
        /// </summary>
        [Fact]
        public void Should_ReturnEmptyList_When_AccountParameterComesEmpty()
        {
            List<Account> account = new List<Account>();
            var finalBalances = _accountService.GetAllFinalBalances(ref account, new List<Transfer>());
            Assert.Empty(finalBalances);
        }
        /// <summary>
        /// Tests when the transfers paremeter is null and returns empty list
        /// </summary>
        [Fact]
        public void Should_ReturnEmptyList_When_TransfersParameterComesNull()
        {
            var account = new List<Account>
            {
                new Account
                {
                    Id=FakeData.NumberData.GetNumber(),
                },
                new Account
                {
                    Id=FakeData.NumberData.GetNumber(),
                }
            };
            var finalBalances = _accountService.GetAllFinalBalances(ref account, null);
            Assert.Empty(finalBalances);
        }
        /// <summary>
        /// Tests when the transfers paremeter is empty List and returns empty list
        /// </summary>
        [Fact]
        public void Should_ReturnEmptyList_When_TransfersParameterComesEmpty()
        {
            var account = new List<Account>
            {
                new Account
                {
                    Id=FakeData.NumberData.GetNumber(),
                },
                new Account
                {
                    Id=FakeData.NumberData.GetNumber(),
                }
            };
            var finalBalances = _accountService.GetAllFinalBalances(ref account, new List<Transfer>());
            Assert.Empty(finalBalances);
        }
        /// <summary>
        /// Tests all the parameters are fine and returns the desired result.
        /// </summary>
        [Fact]
        public void Should_ReturnFilledListOfAccount_When_ParametersComeCorrectly()
        {
            var accountId = FakeData.NumberData.GetNumber();
            var secondAccountId = FakeData.NumberData.GetNumber();
            var accounts = new List<Account>
            {
                new Account
                {
                    Id=accountId,
                    TotalBalance=Convert.ToDecimal(FakeData.NumberData.GetDouble())*10
                },
                new Account
                {
                    Id=secondAccountId,
                    TotalBalance=Convert.ToDecimal(FakeData.NumberData.GetDouble())*100
                }
            };
            var transfers = new List<Transfer>()
            {
                new Transfer
                {
                    SourceAccountId=accountId,
                    TargetAccountId=secondAccountId,
                    Amount = Convert.ToDecimal(FakeData.NumberData.GetDouble())*100,
                    Date = FakeData.DateTimeData.GetDatetime(),
                    TransferId=FakeData.NumberData.GetNumber()
                },
                 new Transfer
                {
                    SourceAccountId=secondAccountId,
                    TargetAccountId=accountId,
                    Amount = Convert.ToDecimal(FakeData.NumberData.GetDouble())*10,
                    Date = FakeData.DateTimeData.GetDatetime(),
                    TransferId=FakeData.NumberData.GetNumber()
                }
            };
            var finalBalances = _accountService.GetAllFinalBalances(ref accounts, transfers );
            Assert.NotEmpty(finalBalances);
        }
        #endregion

    }
}
