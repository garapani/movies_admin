using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace MoviesWeb.Utils
{
    public static class FileUtil
    {
        public static string SaveFileToPhysicalLocation(string prefix, IFormFile file)
        {
            //Getting FileName
            var fileName = Path.GetFileName(file.FileName);

            //Assigning Unique Filename (Guid)
            var myUniqueFileName = prefix + "_" + Convert.ToString(Guid.NewGuid());

            //Getting file Extension
            var fileExtension = Path.GetExtension(fileName);

            // concatenating  FileName + FileExtension
            var newFileName = String.Concat(myUniqueFileName, fileExtension);
            var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            if (!Directory.Exists(imagesPath))
                Directory.CreateDirectory(imagesPath);

            // Combines two strings into a path.
            var filepath = new PhysicalFileProvider(imagesPath).Root + $@"{newFileName}";
            using (FileStream fs = File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            return newFileName;
        }

        public static bool DeleteFile(string relativeFilePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(relativeFilePath))
                {
                    var actualPath = Path.Combine(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")).Root, relativeFilePath);
                    if (File.Exists(actualPath))
                    {
                        File.Delete(actualPath);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
