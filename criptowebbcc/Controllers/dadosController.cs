using criptowebbcc.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace criptowebbcc.Controllers
{
    public class dadosController : Controller
    {
        private readonly Contexto contexto;

        public dadosController(Contexto context)
        {
            contexto = context; 

        }


        public IActionResult Cliente()
        {
            contexto.Database.ExecuteSqlRaw("delete from clientes");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('clientes', RESEED, 0)");
            Random randNum = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vCidade = { "Assis", "Candido Mota", "Taruma", "Paraguaçu", "Palmital", "Pedrinhas", "Maracai", "Cruzalia" };
            for (int i = 0; i < 100; i++)
            {
                Cliente cliente = new Cliente();

                cliente.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                cliente.cidade = vCidade[randNum.Next() % 8];
                cliente.estado = (Estado)randNum.Next(20);
                cliente.idade = randNum.Next(18, 95);
                contexto.clientes.Add(cliente);
            }
            contexto.SaveChanges();

            return View(contexto.clientes.OrderBy(o => o.id).ToList());
        }


        public IActionResult Moeda() {
            contexto.Database.ExecuteSqlRaw("delete from moedas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('moedas', RESEED, 0)");
            Random randNum = new Random();
            Encoding encode = Encoding.GetEncoding("iso-8859-1");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = System.IO.File.Open("Moedas.xlsx", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);

            reader.Read(); //ler a primeira linha e ignora pois é o cabeçalho 

            do
            {
                while (reader.Read())
                {
                    Moeda moeada = new Moeda(); 
                    moeada.descricao = reader[1].ToString();  
                    moeada.sigla = reader[2].ToString();
                    moeada.compra = Convert.ToSingle(reader[3].ToString());
                    moeada.venda = moeada.compra +  moeada.compra *  randNum.Next(1, 50)/100;
                    try
                    {
                        moeada.capital = Convert.ToSingle(reader[4].ToString());
                    }
                    catch 
                    {
                        moeada.capital = 0; 
                    }
                    try
                    {
                        moeada.vol24 = Convert.ToSingle(reader[5].ToString());
                    }
                    catch
                    {
                        moeada.vol24 = 0; 
                    }
                    try
                    {
                        moeada.voltotal = Convert.ToSingle(reader[6].ToString());
                    }
                    catch
                    {
                        moeada.voltotal = 0; 
                    }
                    try
                    {
                        moeada.var24h = Convert.ToSingle(reader[7].ToString());
                    }
                    catch
                    {
                        moeada.var24h = 0; 
                    }
                    try
                    {
                        moeada.var7d = Convert.ToSingle(reader[8].ToString());
                    }
                    catch
                    {
                        moeada.var7d = 0; 
                    }
                    
                    contexto.moedas.Add(moeada);

                }
                contexto.SaveChanges();

            } while (reader.NextResult());

            return View(contexto.moedas.ToList());
        }

        public IActionResult Conta()
        {
            contexto.Database.ExecuteSqlRaw("delete from contas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('contas', RESEED, 0)");
            Random randNum = new Random();

            for (int i = 0; i < 1000; i++)
            {
                Conta conta = new Conta();

                conta.clienteid = randNum.Next(1, 100);
                Cliente cliente = contexto.clientes.Find(conta.clienteid);

                conta.moedaid = randNum.Next(1, 100);
                Moeda moeda = contexto.moedas.Find(conta.moedaid);

                conta.quantidade = randNum.Next(1, 500000);
                contexto.contas.Add(conta);

            }
            contexto.SaveChanges();

            return View(contexto.contas.OrderBy(o => o.id).ToList());
        }



        public IActionResult Transacao()
        {
            contexto.Database.ExecuteSqlRaw("delete from transacoes");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('transacoes', RESEED, 0)");
            Random randNum = new Random();

            for (int i = 0; i < 10000; i++)
            {
                Transacao transacao = new Transacao();
                
                transacao.contaid = randNum.Next(1, 1000);
                Conta conta = contexto.contas.Find(transacao.contaid);

                transacao.quantidade = randNum.Next(1, 5000);
                transacao.data = Convert.ToDateTime("01/01/2021").AddDays(randNum.Next(0, 650)); 
                transacao.valor = randNum.Next(100, 2000);
                transacao.operacao = (randNum.Next()%2 == 0) ? Operacao.Compra : Operacao.Venda; 
                contexto.transacoes.Add(transacao);

            }
            contexto.SaveChanges();

            return View(contexto.transacoes.OrderBy(o => o.id).ToList());
        }

    }
}
