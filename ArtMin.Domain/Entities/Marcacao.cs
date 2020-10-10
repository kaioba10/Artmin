using System.Collections.Generic;

namespace ArtMin.Domain.Entities
{
    public class Marcacao
    {
        public int MarcacaoId { get; set; }
        public double? Gol { get; set; }
        public double? Assistencia { get; set; }
        public double? Vitoria { get; set; }
        public double? PenaltiDefendido { get; set; }
        public double? PenaltiPerdido { get; set; }
        public double? GolContra { get; set; }
        public double? Pontos { get; set; }
        public int JogadorId { get; set; }
        public virtual Jogador Jogador { get; set; }

        public void Alterar(double gol, double assistencia, double vitoria, double penaltiDefendido, double penaltiPerdido, double golContra, double pontos)
        {
            Gol = Gol + gol;
            Assistencia = Assistencia + assistencia;
            Vitoria = Vitoria + vitoria;
            PenaltiDefendido = PenaltiDefendido + penaltiDefendido;
            PenaltiPerdido = PenaltiPerdido + penaltiPerdido;
            GolContra = GolContra + golContra;
            Pontos = Pontos + pontos;
        }
    }
}
