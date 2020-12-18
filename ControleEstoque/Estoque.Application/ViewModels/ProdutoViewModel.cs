using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Código é obrigatorio")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
    }
}
