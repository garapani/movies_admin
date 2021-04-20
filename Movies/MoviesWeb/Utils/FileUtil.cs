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

            // Combines two strings into a path.
            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root + $@"{newFileName}";
            using (FileStream fs = File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            return newFileName;
        }
    }
}
