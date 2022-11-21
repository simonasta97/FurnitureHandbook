namespace FurnitureHandbook.Services.Data.Documents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Web.ViewModels.Documents;
    using Microsoft.AspNetCore.Http;

    public interface IDocumentsService
    {
        Task CreateAsync(CreateDocumentInputModel resourceModel, string pathToSaveInDb);

        Task DeleteAsync(int documentId);

        string UploadDocument(IFormFile document, string wwwRootDirectory);
    }
}
