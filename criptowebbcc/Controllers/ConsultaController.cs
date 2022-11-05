using criptowebbcc.Models;
using criptowebbcc.Models.Consulta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace criptowebbcc.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly Contexto contexto;

        public ConsultaController (Contexto context)
        {
            contexto = context;
        }
        
       
        public IActionResult Pesquisa()
        {
             return View();
        }

        //[HttpGet("/Consulta/ListarItens/{produtorId}")]
        public IActionResult Geral(string nome)
        {
            List<Cliente> lista = new List<Cliente>();  
            if (nome != null)
            {
                //lista = contexto.clientes.OrderBy(o => o.cidade).
                //    ThenBy(d => d.estado).Where(c => c.cidade == nome).ToList();
                lista = contexto.clientes.OrderBy(o => o.cidade).
                 ThenBy(d => d.estado).Where(c =>c.nome.Contains(nome)).ToList();
            }
            else
            {
                 lista = contexto.clientes.OrderBy(o => o.cidade).
                         ThenBy(d => d.estado).ToList();
            }

            return View(lista);
        }

        public IActionResult Clientes(string nome)
        {
            List<Cliente> lista = new List<Cliente>();
            if (nome != null)
            {
                //lista = contexto.clientes.OrderBy(o => o.cidade).
                //    ThenBy(d => d.estado).Where(c => c.cidade == nome).ToList();
                lista = contexto.clientes.OrderBy(o => o.cidade).
                 ThenBy(d => d.estado).Where(c => c.nome.Contains(nome)).ToList();
            }
            else
            {
                lista = contexto.clientes.OrderBy(o => o.cidade).
                        ThenBy(d => d.estado).ToList();
            }

            return View(lista);
        }

        public IActionResult Agrupar()
        {

            IEnumerable<TransacaoGrp> lstGrpTrans = from item in contexto.transacoes
                                   .Include(c => c.conta).Include(c => c.conta.cliente)
                                   .Include(c => c.conta.moeda)
                                   .ToList()
                                                  group item by new { item.conta.cliente.nome, item.conta.moeda.descricao}
                                   into grupo
                                                  orderby grupo.Key.nome, grupo.Key.descricao
                                                  select new TransacaoGrp
                                                  {
                                                      nome = grupo.Key.nome,
                                                      moeda = grupo.Key.descricao,
                                                      valor = grupo.Sum(p => p.quantidade * p.valor)
                                                  };

            return View(lstGrpTrans);

        }

        public IActionResult AgruparByNome()
        {

            IEnumerable<TransacaoGrp> lstGrpTrans = from item in contexto.transacoes
                                   .Include(c => c.conta).Include(c => c.conta.cliente)
                                   .Include(c => c.conta.moeda)
                                   .ToList()
                                                    group item by new { item.conta.cliente.nome }
                                   into grupo
                                                    orderby grupo.Key.nome
                                                    select new TransacaoGrp
                                                    {
                                                        nome = grupo.Key.nome,
                                                        valor = grupo.Sum(p => p.quantidade * p.valor)
                                                    };

            return View(lstGrpTrans);

        }

        public IActionResult AgruparByMes()
        {

            IEnumerable<ContaMes> lstContaMes = from item in contexto.transacoes
                                   .Include(c => c.conta).Include(c => c.conta.cliente)
                                   .Include(c => c.conta.moeda)
                                   .ToList()
                                                    group item by new { item.conta.id, item.data.Month }
                                   into grupo
                                                    orderby grupo.Key.id
                                                    orderby grupo.Key.Month
                                                    select new ContaMes
                                                    {
                                                       conta = grupo.Key.id,
                                                       mes = grupo.Key.Month,
                                                       valor = grupo.Sum(p => p.quantidade * p.valor)
                                                    };

            return View(lstContaMes);

        }



        public IActionResult Transacoes()
        {
            IEnumerable<TransacaoQry> listaTransacao = from item in contexto.transacoes
                                                         .Include(c => c.conta).Include(c => c.conta.cliente).Include(c => c.conta.moeda)
                                                         .OrderBy(o => o.conta)
                                                         .ToList()
                                                       select new TransacaoQry
                                                       {
                                                           id = item.id,
                                                           conta = item.contaid,
                                                           cliente = item.conta.cliente.nome,
                                                           moeda = item.conta.moeda.descricao,
                                                           quantidade = item.quantidade,
                                                           valor = item.conta.moeda.venda,
                                                           total = item.quantidade * item.conta.moeda.venda,
                                                           operacao = (item.operacao == Operacao.Compra) ? "Compra" : "Venda"

                                                       };




            return View(listaTransacao);

        }


        public IActionResult AgruparTransacao()
        {
            IEnumerable<TransacaoQry> listaTransacao = from item in contexto.transacoes
                                                         .Include(c => c.conta).Include(c => c.conta.cliente).Include(c => c.conta.moeda)
                                                         .OrderBy(o => o.conta)
                                                         .ToList()
                                                       select new TransacaoQry
                                                       {
                                                           id = item.id,
                                                           conta = item.contaid,
                                                           cliente = item.conta.cliente.nome,
                                                           moeda = item.conta.moeda.descricao,
                                                           quantidade = item.quantidade,
                                                           valor = item.conta.moeda.venda,
                                                           total = item.quantidade * item.conta.moeda.venda,
                                                           operacao = (item.operacao == Operacao.Compra) ? "Compra" : "Venda"

                                                       };

            IEnumerable<TransacaoGrpOperacao> listaGrpOper = from item in listaTransacao
                                                             .ToList()
                                                             group item by new { item.conta, item.operacao }
                                                             into grupo
                                                             orderby grupo.Key.conta
                                                             select new TransacaoGrpOperacao
                                                             {
                                                                 conta = grupo.Key.conta,
                                                                 operacao = grupo.Key.operacao,
                                                                 valor = grupo.Sum(p => p.total)
                                                             };

            return View(listaGrpOper);
        }


    }
}
