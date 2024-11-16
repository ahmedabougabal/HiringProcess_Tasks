using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileProviders;
using System.Security.AccessControl;

namespace Dr_GreicheTask.PL.Helpers
{
    public class DocumentSettings
    {

        public static string UploadFile(IFormFile file, string folderName)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            string filePath = Path.Combine(folderPath, fileName);
            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);

            return fileName;


        }
        public static void DeleteFile(string fileName, string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
            if (File.Exists(filePath))
                File.Delete(filePath);


        }
        //sabah
        public static string Upload(IFormFile file, string folderName)
        {
            bool ret = true;
            string filepath = "";
            string fileName = " ";
            if (!string.IsNullOrEmpty(folderName))
            {

                string FolderPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);
                if (!System.IO.Directory.Exists(FolderPath))
                    System.IO.Directory.CreateDirectory(FolderPath);

                fileName = Path.GetFileName(file.FileName);
                filepath = new PhysicalFileProvider(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot\\files", folderName)).Root + $@"\{fileName}";

                try
                {
                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyToAsync(stream, new System.Threading.CancellationToken());
                    }
                }
                catch (Exception e)
                {
                    ret = false;
                    string ex = e.Message;
                }
            }
            else
                ret = false;
            return fileName;
        }
    }
}
