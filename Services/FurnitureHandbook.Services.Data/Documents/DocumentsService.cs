namespace FurnitureHandbook.Services.Data.Documents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Common.Repositories;
    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Web.ViewModels.Documents;
    using Microsoft.EntityFrameworkCore;
    using static FurnitureHandbook.Common.GlobalConstants.Document;

    public class DocumentsService : IDocumentsService
    {
        private readonly IDeletableEntityRepository<Document> documentsRepository;

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

        public async Task DeleteAsync(int id)
        {
            var document = await this.documentsRepository
                .All()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (document == null)
            {
                throw new Exception(DocumentNotFound);
            }

            this.documentsRepository.Delete(document);
            await this.documentsRepository.SaveChangesAsync();
        }
    }
}
