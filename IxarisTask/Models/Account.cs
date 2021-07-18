namespace IxarisTask.Models
{
    /// <summary>
    /// Represents the Bank Account data model.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Represents the Unique Account Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents the Total Balance of the Account
        /// </summary>
        public decimal TotalBalance { get; set; }
        /// <summary>
        /// Represents the amount of usage of the bank account.
        /// </summary>
        public int AmountOfUsage { get; set; }
    }
}
