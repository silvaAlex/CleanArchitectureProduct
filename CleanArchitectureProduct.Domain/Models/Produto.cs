using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureProduct.Domain.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome Produto é obrigatorio")]
        [StringLength(20)]
        public string NomeProduto { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preço é obrigatorio")]
        public decimal Preco { get; set; } = 0;
    }
}