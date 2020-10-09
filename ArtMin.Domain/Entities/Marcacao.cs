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

        public void Alterar(double gol, double assistencia, double vitoria, double penaltiDefendido, double penaltiPerdido, double golContra)
        {
            Gol = gol;
            Assistencia = assistencia;
            Vitoria = vitoria;
            PenaltiDefendido = penaltiDefendido;
            PenaltiPerdido = penaltiPerdido;
            GolContra = golContra;
        }
    }
}
