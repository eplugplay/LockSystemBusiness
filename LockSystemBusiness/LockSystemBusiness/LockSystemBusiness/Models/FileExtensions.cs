using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LockSystemBusiness.Models
{
    public static class FileExtensions
    {
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo directoryInfo, params string[] extensions)
        {
            var allowedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);
            return directoryInfo.EnumerateFiles().Where(f => allowedExtensions.Contains(f.Extension));
        }
    }
}