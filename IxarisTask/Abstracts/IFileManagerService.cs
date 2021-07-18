using System.Collections.Generic;

namespace IxarisTask.Abstracts
{
    /// <summary>
    /// The Contract of FileManagerService
    /// </summary>
    public interface IFileManagerService
    {
        /// <summary>
        /// Checks existance of the given filepath.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool CheckFileExistance(string filePath);
        /// <summary>
        /// Reads the file through the given filepath.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        List<string> ReadFile(string filePath);
    }
}
