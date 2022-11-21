namespace FurnitureHandbook.Services.Data.Images
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using static System.Net.Mime.MediaTypeNames;

    public interface IImagesService
    {
        string UploadImages(IFormFile image, string wwwRootDirectory);
    }
}
