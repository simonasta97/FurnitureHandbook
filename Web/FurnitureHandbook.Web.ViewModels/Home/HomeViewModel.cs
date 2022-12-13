namespace FurnitureHandbook.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Web.ViewModels.Projects;

    public class HomeViewModel
    {
        public IEnumerable<LatestProjectViewModel> Projects { get; set; }
    }
}
