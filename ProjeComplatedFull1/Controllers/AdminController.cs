using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjeComplatedFull1.Controllers
{
    //[Authorize(Roles = "admin,profesor")]
    [Authorize(Roles = "2")]
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
