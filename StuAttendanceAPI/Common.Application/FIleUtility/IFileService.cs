using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Common.Application.FIleUtility
{
    public interface IFileService
    {
        void DeleteDirectory(string directoryPath);

        /// <summary>
        /// delete a single file and its path
        /// </summary>
        /// <param name="filePath"></param>
        void DeleteFile(string filePath);

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="path">path</param>
        /// <param name="fileName">file name</param>
        void DeleteFile(string path, string fileName);

        /// <summary>
        /// Save file and return void.
        /// </summary>
        /// <param name="file">file to be saved</param>
        /// <param name="directoryPath">location</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException">exception if file is not valid</exception>
        Task SaveFile(IFormFile file, string directoryPath);

        /// <summary>
        /// Saving a file and returning the file location/path
        /// </summary>
        /// <param name="file">file to be saved</param>
        /// <param name="directoryPath"> location</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException">exception is a file is not valid</exception>
        Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath);
    }
}
