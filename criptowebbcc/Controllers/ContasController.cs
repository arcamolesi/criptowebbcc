using criptowebbcc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace criptowebbcc.Controllers
{
    public class ContasController : Controller
    {
        private readonly Contexto contexto; 

        public ContasController(Contexto _contexto)
        {
            this.contexto = _contexto;
        }


        // GET: ContasController
        public ActionResult Index()
        {
            // var contexto = _context.InsumosArea.Include(i => i.area).Include(i => i.insumo);
            var dados = contexto.contas.Include(cli => cli.cliente).Include(moe => moe.moeda);
            return View(dados.ToList());
        }

        // GET: ContasController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || contexto.contas == null)
            {
                return NotFound();
            }
            var conta = contexto.contas
                .Include(c => c.cliente)
                .Include(o => o.moeda)
                .FirstOrDefault(m => m.id == id);

            if (conta == null)
            {
                return NotFound();
            }


            return View(conta);
        }

        // GET: ContasController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["listaClientes"] = new SelectList(contexto.clientes, "id", "nome");
            ViewData["listaMoedas"] = new SelectList(contexto.moedas, "id", "descricao");
            return View();
        }

        // POST: ContasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind ("id, clienteid, moedaid, quantidade")] Conta conta)
        {
            if (ModelState.IsValid)
            {
                contexto.contas.Add(conta);
                contexto.SaveChanges();
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContasController/Edit/5
        public  ActionResult Edit (int? id)
        {
            if (id == null || contexto.contas == null)
            {
                return NotFound(); 
            }

            var conta = contexto.contas.Find(id); 
            if (conta == null)
            {
                return NotFound(); 
            }

            ViewData["listaClientes"] = new SelectList(contexto.clientes, "id", "nome");
            ViewData["listaMoedas"] = new SelectList(contexto.moedas, "id", "descricao");
            
            return View(conta);
        }

        // POST: ContasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("id, clienteid, moedaid, quantidade")] Conta conta)
        {
            if(id != conta.id)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid)
            {
                contexto.contas.Update(conta);
                contexto.SaveChanges(); 
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }


        }

        // GET: ContasController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || contexto.contas == null)
            {
                return NotFound();
            }
            var conta =  contexto.contas
                .Include(c => c.cliente)
                .Include(o => o.moeda)
                .FirstOrDefault(m => m.id == id);
          
            if (conta == null)
            {
                return NotFound();
            }

           
            return View(conta);

        }

        // POST: ContasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (int  id)
        {
            
            var conta = contexto.contas.Find(id); 
            if (conta!= null)
            {
                contexto.contas.Remove(conta); 
                contexto.SaveChanges();
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }


        }
    }
}
