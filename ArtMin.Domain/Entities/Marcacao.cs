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
        public bool ArtilheiroDia { get; set; }
        public bool AssistenteDia { get; set; }
        public bool VitoriosoDia { get; set; }
        public int JogadorId { get; set; }
        public virtual Jogador Jogador { get; set; }

        public void Alterar(double gol, double assistencia, double vitoria, double penaltiDefendido, double penaltiPerdido, double golContra,
                            double pontos, bool artilheiroDia, bool assistenteDia, bool vitoriosoDia)
        {
            Gol = Gol + (gol * 3);
            Assistencia = Assistencia + (assistencia * 2);
            Vitoria = Vitoria + vitoria;
            PenaltiDefendido = PenaltiDefendido + (penaltiDefendido * 4);
            PenaltiPerdido = PenaltiPerdido + (penaltiPerdido * -2);
            GolContra = GolContra + (golContra * -1);
            Pontos = Pontos + pontos;
            var artilheiro = 0;
            var assistente = 0;
            double vitorioso = 0;

            if (artilheiroDia || assistenteDia || vitoriosoDia)
            {
                if (artilheiroDia)
                    artilheiro = 4;

                if (assistenteDia)
                    assistente = 3;

                if (vitoriosoDia)
                    vitorioso = 1.5;
            }

            ArtilheiroDia = artilheiroDia;
            AssistenteDia = assistenteDia;
            VitoriosoDia = vitoriosoDia;

            var total = Gol + Assistencia + Vitoria + PenaltiDefendido + PenaltiPerdido + GolContra + artilheiro + assistente + vitorioso;
            Pontos = total;
        }
    }
}
