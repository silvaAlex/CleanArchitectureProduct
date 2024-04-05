using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CleanArchitectureProduct.Domain.Models
{
    public class ItemPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantidade é obrigatorio")]
        public int Quantidade { get; set; }

        [Required]

        [DisplayName("Produto")]
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto? Produto { get; set; }

        [Required]
        [DisplayName("Pedido")]
        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public virtual Pedido? Pedido { get; set; }
    }
}
