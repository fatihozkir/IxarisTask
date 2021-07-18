using System;

namespace IxarisTask.Models
{
    /// <summary>
    /// Represents the transfer data model.
    /// </summary>
    public class Transfer
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Transfer()
        {

        }

        /// <summary>
        /// Parameterized constructor for initializing the transfer object.
        /// </summary>
        /// <param name="sourceAccountId"></param>
        /// <param name="targetAccountId"></param>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="transferId"></param>
        public Transfer(int sourceAccountId, int targetAccountId, decimal amount, DateTime date, int transferId)
        {
            SourceAccountId = sourceAccountId;
            TargetAccountId = targetAccountId;
            Amount = amount;
            Date = date;
            TransferId = transferId;
        }
        /// <summary>
        /// Represents the key of the source account
        /// </summary>
        public int SourceAccountId { get; set; }
        /// <summary>
        /// Represents the key of the target account
        /// </summary>
        public int TargetAccountId { get; set; }
        /// <summary>
        /// Represents the transferred amount
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Represents the transfer date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Represents the transfer Id
        /// </summary>
        public int TransferId { get; set; }

    }
}
