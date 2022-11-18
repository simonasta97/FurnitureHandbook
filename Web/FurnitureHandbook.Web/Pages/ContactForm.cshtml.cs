namespace FurnitureHandbook.Web.Pages
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ContactFormModel : PageModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [BindProperty]
        public string Name { get; set; }

        [Required]
        [BindProperty]
        public string Subject { get; set; }

        [Required]
        [BindProperty]
        public string Message { get; set; }

        public string InfoMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (this.ModelState.IsValid)
            {
                this.InfoMessage = "Thank you for submitting the contact form.";

                // TODO: Send mail
                // TODO: Save to database
                // return this.Redirect("/");
            }

            return this.Page();
        }
    }
}