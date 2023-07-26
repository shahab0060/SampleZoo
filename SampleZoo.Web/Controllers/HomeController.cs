using Microsoft.AspNetCore.Mvc;

namespace SampleZoo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => Redirect("/swagger");
    }
}