using IxarisTask.Abstracts;
using IxarisTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IxarisTask.Concretes
{
    /// <summary>
    /// The concrete contract of AccountService.
    /// </summary>
    public class AccountService : IAccountService
    {
        public List<Account> ExtractAccounts(List<Transfer> transfers)
        {
            if (transfers == null)
                throw new ArgumentNullException($"{nameof(transfers)} cannot be NULL or empty list!");

            var result = new List<Account>();
            var sourceAccounts = transfers.Select(x => x.SourceAccountId).Distinct().ToList();
            var targetAccounts = transfers.Select(x => x.TargetAccountId).Distinct().ToList();
            var mergedAccounts = sourceAccounts.Union(targetAccounts).ToList();
            if (mergedAccounts is null || !mergedAccounts.Any()) return result;

            foreach (var accountNumber in mergedAccounts)
            {
                result.Add(new Account() { Id = accountNumber });
            }
            return result;
        }

        public List<Account> GetAllFinalBalances(ref List<Account> accounts, List<Transfer> transfers)
        {
            ValidateAccountList(accounts);
            var result = new List<Account>();
            if (transfers is null || !transfers.Any() || accounts is null || !accounts.Any()) return result;

            foreach (var transfer in transfers)
            {
                var sourceAccount = accounts.FirstOrDefault(x => x.Id == transfer.SourceAccountId);
                var targetAccount = accounts.FirstOrDefault(x => x.Id == transfer.TargetAccountId);

                var securityOfTotalBalanceOfSourceAccount = sourceAccount.TotalBalance;
                var securityOfUsageAmountOfSourceAccount = targetAccount.AmountOfUsage;
                var securityOfTotalBalanceOfTargetAccount = targetAccount.TotalBalance;
                try
                {
                    sourceAccount.TotalBalance -= transfer.Amount;
                    targetAccount.TotalBalance += transfer.Amount;
                    sourceAccount.AmountOfUsage++;
                }
                catch (Exception)
                {
                    //Transaction Safety
                    //In any exception case the transfer transaction will be rolled back.
                    if (sourceAccount.TotalBalance != securityOfTotalBalanceOfSourceAccount)
                    {
                        sourceAccount.TotalBalance = securityOfTotalBalanceOfSourceAccount;
                    }

                    if (sourceAccount.AmountOfUsage!=securityOfUsageAmountOfSourceAccount)
                    {
                        sourceAccount.AmountOfUsage = securityOfUsageAmountOfSourceAccount;
                    }

                    if (targetAccount.TotalBalance!=securityOfTotalBalanceOfTargetAccount)
                    {
                        targetAccount.TotalBalance = securityOfTotalBalanceOfTargetAccount;
                    }
                }
            }
            result = accounts.Where(x=>x.TotalBalance>0).OrderByDescending(x=>x.TotalBalance).ToList();
            return result;
        }

        public Account GetFrequentlyUsedSourceAccount(ref List<Account> accounts)
        {
            ValidateAccountList(accounts);
            return accounts.Where(x => x.TotalBalance > 0).OrderByDescending(x => x.AmountOfUsage).FirstOrDefault();
        }

        public Account GetHighestBalancedAccount(ref List<Account> accounts)
        {
            ValidateAccountList(accounts);
            return accounts.OrderByDescending(x => x.TotalBalance).FirstOrDefault();
        }

        private void ValidateAccountList(List<Account> accounts)
        {
            if (accounts is null)
                throw new ArgumentNullException($"{nameof(accounts)} cannot be NULL or empty list!");
        }
    }
}
