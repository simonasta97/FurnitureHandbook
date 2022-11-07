﻿namespace FurnitureHandbook.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProjectsListViewModel : PagingViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; set; }
    }
}