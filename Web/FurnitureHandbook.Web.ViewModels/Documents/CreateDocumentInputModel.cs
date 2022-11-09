namespace FurnitureHandbook.Web.ViewModels.Documents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FurnitureHandbook.Data.Models;

    using static FurnitureHandbook.Common.GlobalConstants;
    using static FurnitureHandbook.Common.GlobalConstants.Document;

    public class CreateDocumentInputModel
    {
        [Display(Name = "Име на документа")]
        [Required(ErrorMessage = "Полето 'Име на документа' е задължително.")]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето 'Размер' е задължително.")]
        [Range(MinSizeLength, MaxSizeLength)]
        public int Size { get; set; }

        [Required]
        public string FileUrl { get; set; }

        [Display(Name = "Тип на файла")]
        [Required(ErrorMessage = "Полето 'Тип на файла' е задължително.")]
        public string FileType { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Полето 'Категория' е задължително.")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Categories { get; set; }
    }
}
