using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace criptowebbcc.Models
{
    [Table("Moedas")]
    public class Moeda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Descrição: ")]
        [StringLength(40)]
        public string descricao { get; set; }

        [Display(Name = "Compra: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float compra { get; set; }

        [Display(Name = "Venda: ")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float venda { get; set; }

        public ICollection<Conta> contas { get; set; }

    }
}
