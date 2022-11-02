namespace FurnitureHandbook.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoriesListViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
