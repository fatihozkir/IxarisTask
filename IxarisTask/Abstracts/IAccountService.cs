using IxarisTask.Models;
using System.Collections.Generic;

namespace IxarisTask.Abstracts
{
    /// <summary>
    /// The contract of the AccountService
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Extracts the unique Bank Accounts by both source account  and target account Ids.
        /// </summary>
        /// <param name="transfers"></param>
        /// <returns></returns>
        List<Account> ExtractAccounts(List<Transfer> transfers);
        /// <summary>
        /// Calculates the final balances of all the accounts.
        /// </summary>
        /// <param name="accounts">Registered Accounts</param>
        /// <param name="transfers">Executed Transfer transactions</param>
        /// <returns></returns>
        List<Account> GetAllFinalBalances(ref List<Account> accounts, List<Transfer> transfers);
        /// <summary>
        /// Gets the highest balanced account.
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        Account GetHighestBalancedAccount(ref List<Account> accounts);
        /// <summary>
        /// Gets the frequently used source account.
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        Account GetFrequentlyUsedSourceAccount(ref List<Account> accounts);
    }
}
