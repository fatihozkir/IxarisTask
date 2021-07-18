using IxarisTask.Abstracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IxarisTask.Concretes
{
    /// <summary>
    /// The concrete contract of FileManagerService.
    /// </summary>
    public class FileManagerService : IFileManagerService
    {
        public bool CheckFileExistance(string filePath)
        {
            CheckFilePath(filePath);           
            var isFileExist = File.Exists(filePath);
            return isFileExist;
        }

        public List<string> ReadFile(string filePath)
        {
            CheckFilePath(filePath);
            var result = File.ReadAllLines(filePath);
            return result.ToList();
        }

        private void CheckFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException($"{nameof(filePath)} cannot be null or empty string!");
        }
    }
}
