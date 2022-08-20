namespace criptowebbcc.Models
{
    public class Moeda
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public float compra { get; set; }
        public float venda { get; set; }

        public ICollection<Conta> contas { get; set; }

    }
}
