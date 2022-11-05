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


        [Display(Name = "Sigla: ")]
        [StringLength(7)]
        public string sigla { get; set; }

        [Display(Name = "Compra: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float compra { get; set; }

        [Display(Name = "Venda: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float venda { get; set; }


        [Display(Name = "Capitalização: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float capital { get; set; }


        [Display(Name = "Vol 24h: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float vol24 { get; set; }


        [Display(Name = "Vol Total: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float voltotal { get; set; }


        [Display(Name = "Var 24h: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float var24h { get; set; }


        [Display(Name = "Var 7d: ")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public float var7d { get; set; }


        public ICollection<Conta> contas { get; set; }

    }
}
