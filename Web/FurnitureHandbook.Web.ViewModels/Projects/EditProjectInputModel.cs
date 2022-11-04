namespace FurnitureHandbook.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;

    using static FurnitureHandbook.Common.GlobalConstants;
    using static FurnitureHandbook.Common.GlobalConstants.Project;

    using Project = FurnitureHandbook.Data.Models.Project;

    public class EditProjectInputModel : IMapFrom<Project>
    {
        [Required]
        public string Id { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето 'Заглавие' е задължително.")]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Полето 'Описание' е задължително.")]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Полето 'Цена' е задължително.")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Авансово плащане")]
        [Required(ErrorMessage = "Полето 'Авансово плащане' е задължително.")]
        public decimal DownPayment { get; set; }

        [Display(Name = "Начална дата")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Крайна дата")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Статус на проекта")]
        [Required(ErrorMessage = "Полето 'Статус' е задължително.")]
        public StatusType Status { get; set; }
    }
}
