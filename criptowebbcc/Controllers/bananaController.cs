using Microsoft.AspNetCore.Mvc;

namespace criptowebbcc.Controllers
{
    public class bananaController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.texto = "FEMA-IMESA"; 
            return View();
        }

        public IActionResult madura()
        {
            return View(); 
        }
        
    }
}
