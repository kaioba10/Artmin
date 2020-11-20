
using System.ComponentModel;

namespace ArtMin.Application.ViewModels
{
    public class MarcacaoViewModel
    {
        public int MarcacaoId { get; set; }

        [DisplayName("Gols Marcados")]
        public double Gol { get; set; }

        [DisplayName("Assistências")]
        public double Assistencia { get; set; }

        [DisplayName("Vitórias")]
        public double Vitoria { get; set; }

        [DisplayName("Pênaltis Defendidos")]
        public double PenaltiDefendido { get; set; }

        [DisplayName("Pênaltis Perdidos")]
        public double PenaltiPerdido { get; set; }

        [DisplayName("Gols Contra")]
        public double GolContra { get; set; }

        [DisplayName("Pontos")]
        public double Pontos { get; set; }

        [DisplayName("Artilheiro do dia?")]
        public bool ArtilheiroDia { get; set; }

        [DisplayName("Assistente do dia?")]
        public bool AssistenteDia { get; set; }

        [DisplayName("Vitorioso do dia?")]
        public bool VitoriosoDia { get; set; }
        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
        public int JogadorId { get; set; }
        public JogadorViewModel Jogador { get; set; }
    }
}