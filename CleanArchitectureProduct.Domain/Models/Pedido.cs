using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureProduct.Domain.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do cliente é obrigatorio")]
        [StringLength(60)]
        public string NomeCliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email do cliente é obrigatorio")]
        [StringLength(60)]
        public string EmailCliente { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Pago { get; set; } = false;
        public ICollection<ItemPedido>? Pedidos { get; set; }
    }
}