using criptowebbcc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace criptowebbcc.Controllers
{
    public class Consulta1Controller : Controller
    {
        private readonly Contexto contexto;

        public Consulta1Controller (Contexto context)
        {
            contexto = context;

        }



        public IActionResult Index()
        {
            return View(contexto.clientes.ToList());
        }
    }
}
