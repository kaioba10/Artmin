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

        [DisplayName("CPF")]
        [Required(ErrorMessage = "CPF obrigatório")]
        public string Cpf { get; set; }


        [DisplayName("Goleiro?")]
        public bool Goleiro { get; set; }
        public string GoleiroDescricao { get { return Goleiro ? "Sim" : "Não"; } }

        [DisplayName("Administrador?")]
        public bool Admin { get; set; }
        public string AdminDescricao { get { return Admin ? "Sim" : "Não"; } }

        [DisplayName("Jogador Ativo?")]
        public bool Ativo { get; set; }
        public string AtivoDescricao { get { return Ativo ? "Sim" : "Não"; } }

        public bool ComparaCpf { get; set; }
        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
    }
}