using Microsoft.EntityFrameworkCore;

namespace criptowebbcc.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) :
            base(options)
        { }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Moeda> moedas { get; set; }
        public DbSet<Conta> contas { get; set; }
        public DbSet<Transacao> transacoes { get; set; }

    }
}
