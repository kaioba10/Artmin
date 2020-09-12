using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtMin.Application.ViewModels
{
    public class JogadorViewModel
    {
        public int JogadorId { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo de {1} caracteres permitidos")]
        [MinLength(2, ErrorMessage = "Mínimo de {1} caracteres permitidos")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo E-mail obrigatório")]
        [MaxLength(120, ErrorMessage = "Máximo de {1} caracteres permitidos")]
        [MinLength(2, ErrorMessage = "Mínimo de {1} caracteres permitidos")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-mail em formato inválido.")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CPF obrigatório")]
        [MaxLength(11, ErrorMessage = "Número de caracteres inválido.")]
        [MinLength(11, ErrorMessage = "Número de caracteres inválido.")]
        public string Cpf { get; set; }


        [DisplayName("Goleiro?")]
        public bool Goleiro { get; set; }

        [DisplayName("Administrador?")]
        public bool Admin { get; set; }

        [DisplayName("Jogador Ativo?")]
        public bool Ativo { get; set; }
    }
}