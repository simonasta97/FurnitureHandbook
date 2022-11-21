namespace FurnitureHandbook.Services.Data.Images
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public class ImagesService : IImagesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "pdf" };

        public string UploadImages(IFormFile image, string wwwRootDirectory)
        {
            var name = image.FileName;
            var extension = Path.GetExtension(image.FileName).TrimStart('.');

            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Невалиден формат на снимката - {extension}");
            }

            var path = Path.Combine(wwwRootDirectory, "images/projects/", image.FileName);
            var pathToSaveInDb = Path.Combine("/images/projects/", image.FileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return pathToSaveInDb;
        }
    }
}
