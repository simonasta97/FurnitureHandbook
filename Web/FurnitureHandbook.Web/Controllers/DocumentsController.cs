namespace FurnitureHandbook.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using FurnitureHandbook.Services.Data.Categories;
    using FurnitureHandbook.Services.Data.Documents;
    using FurnitureHandbook.Web.ViewModels.Documents;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    using static FurnitureHandbook.Common.GlobalConstants;
    using static FurnitureHandbook.Common.GlobalConstants.Document;

    [Authorize(Roles = AdministratorRoleName)]
    public class DocumentsController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IDocumentsService documentsService;
        private readonly ICategoriesService categoriesService;

        public DocumentsController(IWebHostEnvironment webHostEnvironment, IDocumentsService documentsService, ICategoriesService categoriesService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.documentsService = documentsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateDocumentInputModel();
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDocumentInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
                return this.View(inputModel);
            }

            var wwwRootDirectory = this.webHostEnvironment.WebRootPath;
            if (Directory.Exists(Path.Combine(wwwRootDirectory, "documents")) == false)
            {
                Directory.CreateDirectory(Path.Combine(wwwRootDirectory, "documents"));
            }

            var pathToSaveInDb = this.documentsService.UploadDocument(inputModel.File, wwwRootDirectory);
            try
            {
                await this.documentsService.CreateAsync(inputModel, pathToSaveInDb);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);

                inputModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();

                return this.View(inputModel);
            }

            var categoryId = inputModel.CategoryId;
            return this.RedirectToAction("ById", "Categories", new { id = categoryId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int documentId)
        {
            await this.documentsService.DeleteAsync(documentId);
            return this.RedirectToAction("All", "Categories");
        }
    }
}
