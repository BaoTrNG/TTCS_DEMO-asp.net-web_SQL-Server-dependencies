using Microsoft.AspNetCore.Mvc;

namespace WebChungKhoan3._0.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
