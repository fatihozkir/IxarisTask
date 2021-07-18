using IxarisTask.Models;
using System.Collections.Generic;

namespace IxarisTask.Abstracts
{
    /// <summary>
    /// The contract of TransferService
    /// </summary>
    public interface ITransferService
    {
        /// <summary>
        /// Converts the read data to the actual List of Transfer object.
        /// </summary>
        /// <param name="transfers"></param>
        /// <returns></returns>
        List<Transfer> ConvertToTransferList(List<string> transfers);
    }
}
