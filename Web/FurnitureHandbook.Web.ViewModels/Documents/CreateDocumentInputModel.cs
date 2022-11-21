namespace FurnitureHandbook.Web.ViewModels.Documents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;
    using Microsoft.AspNetCore.Http;

    using static FurnitureHandbook.Common.GlobalConstants.Document;

    public class CreateDocumentInputModel
    {
        [Display(Name = "Име на документа")]
        [Required(ErrorMessage = "Полето 'Име на документа' е задължително.")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето 'Размер' е задължително.")]
        [Range(MinSizeLength, MaxSizeLength)]
        public int Size { get; set; }

        [Required]
        public IFormFile File { get; set; }

        [Display(Name = "Тип на файла")]
        [Required(ErrorMessage = "Полето 'Тип на файла' е задължително.")]
        public string FileType { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Полето 'Категория' е задължително.")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
