namespace FurnitureHandbook.Services.Data.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Web.ViewModels.Projects;

    public interface IProjectsService
    {
        Task CreateAsync(CreateProjectInputModel projectModel, string pathToSaveInDb);

        Task<IEnumerable<TModel>> GetAllUserProjects<TModel>(string userId, int page, int itemsPerPage = 6);

        Task<int> GetCountAsync();

        Task<TModel> GetByIdAsync<TModel>(string id);

        Task UpdateAsync(string id, EditProjectInputModel projectModel);

        Task DeleteAsync(string id);
    }
}
