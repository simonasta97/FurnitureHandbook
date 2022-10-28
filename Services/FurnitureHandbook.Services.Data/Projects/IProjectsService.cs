﻿namespace FurnitureHandbook.Services.Data.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IProjectsService
    {
        Task<IEnumerable<TModel>> GetAllUserProjects<TModel>(string userId, int page, int itemsPerPage = 6);

        Task<int> GetCountAsync();
    }
}
