namespace FurnitureHandbook.Web.ViewModels.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using FurnitureHandbook.Data.Models;
    using FurnitureHandbook.Services.Mapping;

    using static FurnitureHandbook.Common.GlobalConstants;
    using static FurnitureHandbook.Common.GlobalConstants.Project;

    using Project = FurnitureHandbook.Data.Models.Project;

    public class CreateProjectInputModel : IMapFrom<Project>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето 'Заглавие' е задължително.")]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Полето 'Описание' е задължително.")]
        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string Description { get; set; }

        [Display(Name = "Снимка")]
        [Required(ErrorMessage = "Снимка на проекта е задължителна.")]
        public string ImageUrl { get; set; }

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

        public int? ClientId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Clients { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Полето 'Категория' е задължително.")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
