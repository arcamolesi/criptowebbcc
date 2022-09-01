using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace criptowebbcc.Models
{
    public enum Operacao { Compra, Venda }

    [Table("Transacoes")]
    public class Transacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Conta: ")]
        public Conta conta { get; set; }

        [Display(Name = "Data: ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
        public DateTime data { get; set; }

        [Display(Name = "Quantidade: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float quantidade { get; set; }

        [Display(Name = "Valor: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }

        public Operacao operacao { get; set; }
    }
}
