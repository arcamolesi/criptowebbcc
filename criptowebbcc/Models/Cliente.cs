using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace criptowebbcc.Models
{
    public enum Estado {RS,SC, PR, SP, RJ, ES, MG, MS, MT, TO, GO, DF, RO, AC, AM, PA, PI, PE, PB, CE, RN}

    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [Display(Name ="Nome: ")]
        [StringLength(35)]
        public string nome { get; set; }

        [StringLength(25)]
        [Display(Name ="Cidade: ")]
        public string cidade { get; set; }

        [Display(Name = "Estado: ")]
        public Estado estado { get; set; }

        [Display(Name = "Idade: ")]
        [Range(18,70, ErrorMessage = "valor entre 18..70" )]
        public int idade { get; set; }

        public ICollection<Conta> contas { get; set; }
       
    }
}
