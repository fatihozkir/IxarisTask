using IxarisTask.Abstracts;
using IxarisTask.Concretes;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IxarisTask.Test.ServiceTests
{
    /// <summary>
    /// Represents the test cases of TransferService functions
    /// </summary>
    public class TransferServiceTests
    {
        #region Fields
        private readonly ITransferService _transferService;
        #endregion

        #region Ctor
        public TransferServiceTests()
        {
            _transferService = Mock.Of<TransferService>();
        }
        #endregion

        #region Test Cases Of ConvertToTransferList Method
        /// <summary>
        /// Tests when the Parameter Comes Null and throws the ArgumentNullException
        /// </summary>
        [Fact]
        public void Should_ThrowArgumentNullException_When_ParameterIsNull()
        {

            var exception = Assert.Throws<ArgumentNullException>(() => _transferService.ConvertToTransferList(null));

            Assert.Equal($"Value cannot be null. (Parameter 'transfers cannot be NULL!')", exception.Message);
        }

        /// <summary>
        /// Tests when the Parameter Comes Empty List and returns the empty list.
        /// </summary>
        [Fact]
        public void Should_ReturnEmptyList_When_ParameterIsEmptyList()
        {
            var result = _transferService.ConvertToTransferList(new List<string>());
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests when the Parameter Comes filled List and returns the desired list result.
        /// </summary>
        [Fact]
        public void Should_ReturnFilledList_When_ParameterIsFilled()
        {
            var result = _transferService.ConvertToTransferList(new List<string>()
            {
                "SOURCE_ACCT, DESTINATION_ACCT, AMOUNT, DATE, TRANSFERID",
                "0, 112233, 60.00, 10/08/2055, 1445",
                "0, 223344, 25.03, 10/08/2055, 1446",
                "0, 334455, 67.67, 11/08/2055, 1447",
                "112233, 223344, 11.11, 11/08/2055, 1448",
                "112233, 334455, 12.12, 13/08/2055, 1449",
                "223344, 334455, 006.018, 13/08/2055, 1450",
            });
            Assert.NotEmpty(result);
        }


        #endregion

    }
}
