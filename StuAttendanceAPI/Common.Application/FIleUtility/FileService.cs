using Microsoft.AspNetCore.Http;

namespace Common.Application.FIleUtility
{
    /// <summary>
    /// File Managing Service. This class handles saving a file, deleting file and retrieving fie.
    /// </summary>
    public class FileService : IFileService
    {
        public void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath, true);
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="path">path</param>
        /// <param name="fileName">file name</param>
        public void DeleteFile(string path, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path,
                  fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }


        /// <summary>
        /// delete a single file and its path
        /// </summary>
        /// <param name="filePath"></param>
        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        /// <summary>
        /// Save file and return void.
        /// </summary>
        /// <param name="file">file to be saved</param>
        /// <param name="directoryPath">location</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException">exception if file is not valid</exception>
        public async Task SaveFile(IFormFile file, string directoryPath)
        {
            if (file == null)
                throw new InvalidDataException("file is Null");

            var fileName = file.FileName;

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var path = Path.Combine(folderName, fileName);
            using var stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream);
        }


        /// <summary>
        /// Saving a file and returning the file location/path
        /// </summary>
        /// <param name="file">file to be saved</param>
        /// <param name="directoryPath"> location</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException">exception is a file is not valid</exception>
        public async Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath)
        {
            if (file == null)
                throw new InvalidDataException("file is Null");

            var fileName = file.FileName;

            fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                                          .Replace(":", "")
                                          .Replace(".", "") + Path.GetExtension(fileName);

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var path = Path.Combine(folderName, fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return fileName;
        }
    }
}
