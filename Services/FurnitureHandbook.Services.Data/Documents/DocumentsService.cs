namespace FurnitureHandbook.Services.Data.Documents
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Web.ViewModels.Documents;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using static FurnitureHandbook.Common.GlobalConstants.Document;

    public class DocumentsService : IDocumentsService
    {
        private readonly IDeletableEntityRepository<Document> documentsRepository;
        private readonly string[] allowedFilesExtensions = new[] { "docx", "pdf", "mp4", "jpg", "png" };

        public DocumentsService(IDeletableEntityRepository<Document> documentsRepository)
        {
            this.documentsRepository = documentsRepository;
        }

        public async Task CreateAsync(CreateDocumentInputModel resourceModel, string pathToSaveInDb)
        {
            var isExist = this.documentsRepository
                .AllAsNoTracking()
                .Any(c => c.Name == resourceModel.Name && c.CategoryId == resourceModel.CategoryId);

            if (isExist)
            {
                throw new Exception(DocumentAlreadyExist);
            }

            var document = new Document
            {
                Name = resourceModel.Name,
                FileUrl = pathToSaveInDb,
                Size = resourceModel.Size,
                FileType = (FileType)Enum.Parse(typeof(FileType), resourceModel.FileType),
                CategoryId = resourceModel.CategoryId,
            };

            await this.documentsRepository.AddAsync(document);
            await this.documentsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int documentId)
        {
            var document = await this.documentsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == documentId);

            if (document == null)
            {
                throw new Exception(DocumentNotFound);
            }

            this.documentsRepository.Delete(document);
            await this.documentsRepository.SaveChangesAsync();
        }

        public string UploadDocument(IFormFile document, string wwwRootDirectory)
        {
            var name = document.FileName;
            var extension = Path.GetExtension(document.FileName).TrimStart('.');

            if (!this.allowedFilesExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Невалиден формат на файла - {extension}");
            }

            var path = Path.Combine(wwwRootDirectory, "documents/", document.FileName);
            var pathToSaveInDb = Path.Combine("/documents/", document.FileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                document.CopyTo(fileStream);
            }

            return pathToSaveInDb;
        }
    }
}
