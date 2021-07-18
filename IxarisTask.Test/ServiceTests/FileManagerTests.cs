using IxarisTask.Abstracts;
using IxarisTask.Concretes;
using Moq;
using System;
using System.IO;
using Xunit;

namespace IxarisTask.Test.ServiceTests
{
    /// <summary>
    /// Represents the test cases of FileManagerService functions
    /// </summary>
    public class FileManagerTests
    {
        #region Fields
        private readonly IFileManagerService _fileManagerService;
        #endregion

        #region Ctor
        public FileManagerTests()
        {
            _fileManagerService = Mock.Of<FileManagerService>();

        }

        #endregion

        #region Test cases of CheckFileExistance Method
        /// <summary>
        /// Tests the Throws ArgumentException case when the path is null or empty
        /// </summary>
        /// <param name="filePath"></param>
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void Should_ThrowArgumentException_When_PathIsNullOrEmpty(string filePath)
        {
            var exception = Assert.Throws<ArgumentException>(() => _fileManagerService.CheckFileExistance(filePath));
            Assert.Equal($"{nameof(filePath)} cannot be null or empty string!", exception.Message);
        }

        /// <summary>
        /// Tests the existance statement when the filePath is not existed
        /// </summary>
        [Fact]
        public void Should_ReturnNegativeResult_When_FileIsNotExisted()
        {
            string directoryPath = AppSettingsDefaults.DirectoryPath;
            var path = $"{directoryPath}transfers1.txt";
            var result = _fileManagerService.CheckFileExistance(path);
            Assert.False(result);
        }

        /// <summary>
        /// Tests the existance statement when the filePath is existed
        /// </summary>
        [Fact]
        public void Should_ReturnPositiveResult_When_FilePathIsExisted()
        {
            string directoryPath = AppSettingsDefaults.DirectoryPath;
            var path = $"{directoryPath}transfers.txt";
            var result = _fileManagerService.CheckFileExistance(path);
            Assert.True(result);
        }
        #endregion

        #region Test Cases of ReadFile Method
        /// <summary>
        /// Tests the Throws ArgumentException case when the path is null or empty
        /// </summary>
        /// <param name="filePath"></param>
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void Should_ThrowArgumentException_When_FilePathIsEmptyNullOrWhiteSpace(string filePath)
        {
            var exception = Assert.Throws<ArgumentException>(()=>_fileManagerService.ReadFile(filePath));

            Assert.Equal($"{nameof(filePath)} cannot be null or empty string!", exception.Message);
        }
        /// <summary>
        /// Tests the  result when the given filepath is not existed
        /// </summary>
        [Fact]
        public void Should_ThrowFileNotFoundException_When_FileIsNotExisted()
        {
            string directoryPath = AppSettingsDefaults.DirectoryPath;
            var path = $"{directoryPath}transfers1.txt";
            
            Assert.Throws<FileNotFoundException>(() => _fileManagerService.ReadFile(path));
            
           
        }

        /// <summary>
        /// Tests the read result when the given filepath is existed
        /// </summary>
        [Fact]
        public void Should_ReturnFilledList_When_FileIsExisted()
        {
            string directoryPath = AppSettingsDefaults.DirectoryPath;
            var path = $"{directoryPath}transfers.txt";
            var result = _fileManagerService.ReadFile(path);
            Assert.NotEmpty(result);
        }

        #endregion
    }
}
