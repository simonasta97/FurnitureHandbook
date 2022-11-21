namespace FurnitureHandbook.Web.ViewModels.Clients
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using static FurnitureHandbook.Common.GlobalConstants.Client;

    public class CreateClientInputModel
    {
        [Display(Name = "Имена на клиента")]
        [Required(ErrorMessage = "Полето 'Имена на клиента' е задължително!")]
        [StringLength(MaxFullNameLength)]
        public string FullName { get; set; }

        [Display(Name = "Телефонен номер")]
        [Required(ErrorMessage = "Полето 'Телефонен номер' е задължително!")]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Полето 'Адрес' е задължително!")]
        [StringLength(MaxAddressLength, MinimumLength = MinAddressLength, ErrorMessage = "Полето {0} трябва да бъде между {2} и {1} символа.")]
        public string Address { get; set; }
    }
}
