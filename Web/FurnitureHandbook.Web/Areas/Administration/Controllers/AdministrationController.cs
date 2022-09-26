namespace FurnitureHandbook.Web.Areas.Administration.Controllers
{
    using FurnitureHandbook.Common;
    using FurnitureHandbook.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
