using IxarisTask.Abstracts;
using IxarisTask.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace IxarisTask.Concretes
{
    /// <summary>
    /// The concrete contract of TransferService.
    /// </summary>
    public class TransferService : ITransferService
    {
        public List<Transfer> ConvertToTransferList(List<string> transfers)
        {
            if (transfers == null)
                throw new ArgumentNullException($"{nameof(transfers)} cannot be NULL!");

            var transferList = new List<Transfer>();
            if (!transfers.Any()) 
                return transferList;

            foreach (var transfer in transfers.Skip(1))
            {
                var splittedTransfer = transfer.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (splittedTransfer is null || splittedTransfer.Length <= 0 || splittedTransfer.Length < 4) 
                    continue;

                var sourceAccountId = Convert.ToInt32(splittedTransfer[0].Trim());
                var targetAccountId = Convert.ToInt32(splittedTransfer[1].Trim());
                var amount = Convert.ToDecimal(splittedTransfer[2].Trim(), new CultureInfo("en-US"));
                var date = Convert.ToDateTime(splittedTransfer[3].Trim());
                var transferId = Convert.ToInt32(splittedTransfer[4].Trim());

                transferList.Add(new Transfer(sourceAccountId, targetAccountId, amount, date, transferId));
            }
            return transferList;
        }

        
    }
}
