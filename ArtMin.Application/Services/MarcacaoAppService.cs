
using ArtMin.Application.Interfaces;
using ArtMin.Application.ViewModels;
using ArtMin.Domain.Entities;
using ArtMin.Domain.Interfaces.Repositories;
using AutoMapper;
using System.Collections.Generic;

namespace ArtMin.Application.Services
{
    public class MarcacaoAppService : IMarcacaoAppService
    {
        private readonly IMarcacaoRepository _marcacaoRepository;
        private readonly IJogadorRepository _jogadorRepository;

        public MarcacaoAppService(IMarcacaoRepository marcacaoRepository, IJogadorRepository jogadorRepository)
        {
            _marcacaoRepository = marcacaoRepository;
            _jogadorRepository = jogadorRepository;
        }

        public IEnumerable<MarcacaoViewModel> GetAll()
        {
            var marcacaoViewModel = Mapper.Map<IEnumerable<Marcacao>, IEnumerable<MarcacaoViewModel>>(_marcacaoRepository.GetAll());
            return marcacaoViewModel;
        }

        public void Create(MarcacaoViewModel marcacaoViewModel)
        {
            var marcacaoJogador = VerificaMarcacaoExistente(marcacaoViewModel);
            var resultado = marcacaoViewModel.Resultado;

            if (resultado)
            {
                Edit(marcacaoViewModel);
            }
            else
            {
                CalculaPontos(marcacaoViewModel);
                var marcacao = Mapper.Map<MarcacaoViewModel, Marcacao>(marcacaoViewModel);
                _marcacaoRepository.Add(marcacao);
            }
        }

        public MarcacaoViewModel GetById(int id)
        {
            var marcacao = _marcacaoRepository.GetById(id);
            var marcacaoViewModel = Mapper.Map<Marcacao, MarcacaoViewModel>(marcacao);

            return marcacaoViewModel;
        }

        public void Edit(MarcacaoViewModel marcacaoViewModel)
        {
            var marcacao = _marcacaoRepository.GetById(marcacaoViewModel.MarcacaoId);
            marcacao.Alterar(marcacaoViewModel.Gol, marcacaoViewModel.Assistencia, marcacaoViewModel.Vitoria, marcacaoViewModel.PenaltiDefendido, 
                             marcacaoViewModel.PenaltiPerdido, marcacaoViewModel.GolContra, marcacaoViewModel.Pontos, marcacaoViewModel.ArtilheiroDia,
                             marcacaoViewModel.AssistenteDia, marcacaoViewModel.VitoriosoDia);
            _marcacaoRepository.Update(marcacao);
        }

        public void Delete(int id)
        {
            var marcacao = _marcacaoRepository.GetById(id);
            _marcacaoRepository.Remove(marcacao);
        }

        private void CalculaPontos(MarcacaoViewModel marcacaoViewModel)
        {
            var gols = marcacaoViewModel.Gol * 3;
            var assistencias = marcacaoViewModel.Assistencia * 2;
            var vitorias = marcacaoViewModel.Vitoria;
            var defesaPenalti = marcacaoViewModel.PenaltiDefendido * 4;
            var golContra = marcacaoViewModel.GolContra * -1.5;
            var penaltiPerdido = marcacaoViewModel.PenaltiPerdido * -2;
            var artilheiro = 0;
            var assistente = 0;
            double vitorioso = 0;

            if (marcacaoViewModel.ArtilheiroDia || marcacaoViewModel.AssistenteDia || marcacaoViewModel.VitoriosoDia)
            {
                if (marcacaoViewModel.ArtilheiroDia)
                {
                    artilheiro = 4;
                }

                if (marcacaoViewModel.AssistenteDia)
                {
                    assistente = 3;
                }

                if (marcacaoViewModel.VitoriosoDia)
                {
                    vitorioso = 1.5;
                }
                
            }


            var total = gols + assistencias + vitorias + defesaPenalti + golContra + penaltiPerdido + artilheiro + assistente + vitorioso;

            marcacaoViewModel.Pontos = total;
        }

        private bool VerificaMarcacaoExistente(MarcacaoViewModel marcacaoViewModel)
        {
            var marcacao = _marcacaoRepository.VerificaMarcacaoExistente(marcacaoViewModel.JogadorId);

            if (marcacao.MarcacaoId != 0)
            {
                marcacaoViewModel.MarcacaoId = marcacao.MarcacaoId;
                marcacaoViewModel.Resultado = true;
            }

            return marcacaoViewModel.Resultado;
        }
    }
}
