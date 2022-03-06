using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Extentions
{
    public static class FileExtension
    {
        public static bool IsSupported(this IFormFile file,string contentType)
        {
            return file.ContentType.Contains(contentType);
        }
        public static bool IsGreaterThanGivenMb (this IFormFile file ,int mb)
        {
            return file.Length > mb * 1024 * 1024;
        }
    }
}
