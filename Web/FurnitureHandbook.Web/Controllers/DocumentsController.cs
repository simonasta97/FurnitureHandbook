namespace FurnitureHandbook.Web.Controllers
{
    using System.Data;

    using FurnitureHandbook.Services.Data.Categories;
    using FurnitureHandbook.Services.Data.Documents;
    using FurnitureHandbook.Web.ViewModels.Documents;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static FurnitureHandbook.Common.GlobalConstants;

    [Authorize(Roles = AdministratorRoleName)]
    public class DocumentsController : Controller
    {
        private readonly IDocumentsService documentsService;
        private readonly ICategoriesService categoriesService;

        public DocumentsController(IDocumentsService documentsService, ICategoriesService categoriesService)
        {
            this.documentsService = documentsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateDocumentInputModel();
            viewModel.Categories = this.categoriesService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }
    }
}
