
using System.Collections.Generic;

namespace ArtMin.Application.ViewModels
{
    public class MarcacaoViewModel
    {
        public int MarcacaoId { get; set; }
        public double Gol { get; set; }
        public double Assistencia { get; set; }
        public double Vitoria { get; set; }
        public double PenaltiDefendido { get; set; }
        public double PenaltiPerdido { get; set; }
        public double GolContra { get; set; }
        public int JogadorId { get; set; }
        public JogadorViewModel Jogador { get; set; }

        public IDictionary<int, string> JogadoresSelecionaveis { get; set; }
    }
}