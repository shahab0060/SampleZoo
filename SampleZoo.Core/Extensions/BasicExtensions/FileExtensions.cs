using Microsoft.AspNetCore.Http;
using SampleZoo.Core.Utils;
using SampleZoo.Domain.ViewModels.Common;

namespace SampleZoo.Core.Extensions.BasicExtensions
{
    public static class FileExtensions
    {
        public static async Task<string?> UploadImage(this IFormFile? file, string path,
               string preferedName,
                List<ResizeImageDto> resizesInformation,
                int editCounts,
                string? deleteImageName = null)
        {
            if (editCounts > 0)
                preferedName = $"{preferedName}-v{editCounts}";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (file is null) return null;
            string newImageName = preferedName.ToUrl() + Path.GetExtension(file.FileName);
            if (file.Length > 0)
            {
                using (var stream = System.IO.File.Create(path + newImageName))
                {
                    await file.CopyToAsync(stream);
                }
            }
            await path.ConvertToWebP(newImageName);
            await path.ResizeImage(resizesInformation, newImageName, deleteImageName);
            return newImageName;
        }

        public static async Task ResizeImage(this string originalPath, List<ResizeImageDto> resizesInformation,
             string fileName, string? deleteFileName)
        {
            foreach (var resize in resizesInformation)
            {
                await originalPath.ResizeImage(resize, fileName, deleteFileName);
            }
        }

        static async Task ResizeImage(this string originalPath, ResizeImageDto resizeImage, string fileName, string? deleteFileName)
        {
            deleteFileName!.DeleteFile(resizeImage.ResizedImagePath);
            deleteFileName!.ConvertImageNameToWebP()!.DeleteFile(resizeImage.ResizedImagePath);
            if (!Directory.Exists(resizeImage.ResizedImagePath))
                Directory.CreateDirectory(resizeImage.ResizedImagePath);
            originalPath.ImageResizer(resizeImage.ResizedImagePath, fileName, resizeImage.ImageWidth, resizeImage.ImageHeight);
            await resizeImage.ResizedImagePath.ConvertToWebP(fileName);
        }

        public static void DeleteFile(this string? fileName, string path)
        {
            if (string.IsNullOrEmpty(fileName)) return;
            var filePath = Path.Combine(path, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
