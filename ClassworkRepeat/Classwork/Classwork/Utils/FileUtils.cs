using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Utils
{
    public class FileUtils
    {
        public static string Create(string FolderPath,IFormFile file)
        {
            var FileName = Guid.NewGuid() + file.FileName;
            var FullPath = Path.Combine(FolderPath, FileName);
            FileStream fileStream = new FileStream(FullPath, FileMode.Create);
            file.CopyToAsync(fileStream);
            fileStream.Close();
            return FileName;
        }
        public static void Delete(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
