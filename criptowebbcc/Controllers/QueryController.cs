using criptowebbcc.Models;
using Microsoft.AspNetCore.Mvc;

namespace criptowebbcc.Controllers
{
    public class QueryController : Controller
    {
        private readonly Contexto contexto;

        public QueryController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Cliente(string filtro)
        {
            List<Cliente> lista = new List<Cliente>();

            if (filtro == null)
            {
                lista = contexto.clientes
                         .OrderBy(o => o.estado)
                         .ThenBy(p => p.cidade).ThenByDescending(n => n.nome)
                         .ToList();

            }
            else
            {
                // lista = contexto.clientes.Where(c => c.nome == nome)
                //lista = contexto.clientes.Where(c => c.cidade == cidade)
                lista = contexto.clientes.Where(c => c.nome.Contains(filtro))
                         .OrderBy(o => o.estado)
                        .ThenBy(p => p.cidade).ThenByDescending(n => n.nome)
                        .ToList();
            }
           
            return View(lista);
     
        }

        public IActionResult Pesquisa()
        {
            return View();
        }
    }
}
