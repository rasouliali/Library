namespace Library.UI.Helpers
{
    public class FileHelper
    {
        public static string GetFile(IFormFile item)
        {
            var baseFolder = Path.Combine("wwwroot", "img");
            if (Directory.Exists(baseFolder) == false)
                Directory.CreateDirectory(baseFolder);

            string filePath = "";
            string fileName = Guid.NewGuid() + item.FileName.Substring(item.FileName.LastIndexOf("."));

            filePath = Path.Combine(baseFolder, fileName);

            (filePath, fileName) = GetNewFileName(baseFolder, item, filePath, fileName);//if exist this filename replace new filename to it

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                item.CopyTo(stream);
            }

            return fileName;
        }

        private static (string, string) GetNewFileName(string baseFolder, IFormFile item, string filePath, string fileName)
        {
            var fileNameEdited = fileName;
            while (File.Exists(filePath))
            {
                fileNameEdited = Guid.NewGuid() + item.FileName.Substring(item.FileName.LastIndexOf("."));
                filePath = Path.Combine(baseFolder, fileNameEdited);
            }

            return (filePath, fileNameEdited);
        }

    }
}
