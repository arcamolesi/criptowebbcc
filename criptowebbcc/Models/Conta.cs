using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace criptowebbcc.Models
{
    [Table("Contas")]
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Cliente: ")]
        public Cliente cliente { get; set; }

        [Display(Name = "Moeda: ")]
        public Moeda moeda { get; set; }

        [Display(Name = "Quantidade: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float quantidade { get; set; }

        public ICollection<Transacao> transacoes { get; set; }

    }
}
