using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Bl.FileManager
{
    public static class ImgMethod
    {
        public static string ChangeToUrl(this IFormFile file,string envPath,string folder)
        {
            string path = Path.Combine(envPath, folder);
            string fileName=file.FileName;
            using (FileStream filestream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(filestream);
            };
            return fileName;
        }
    }
}
