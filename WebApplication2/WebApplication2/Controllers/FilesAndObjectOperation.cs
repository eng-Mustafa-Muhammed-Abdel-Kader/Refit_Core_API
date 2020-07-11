using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class FilesAndObjectOperation
    {
        public static readonly IHostingEnvironment hosting;

        //public static readonly string linkApi = "http://mostafammm2020-001-site1.htempurl.com";
        public static readonly string linkApi = "https://localhost:44398";

        public static bool DeleteFile(string fileName)
        {
            try
            {
                var FolderName = Path.Combine(hosting.WebRootPath,"Resources", "Images", fileName);
                var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);

                FileInfo file = new FileInfo(PathToSave);

                if (file.Exists)
                {
                    file.Delete();
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
