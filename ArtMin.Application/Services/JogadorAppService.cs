using ArtMin.Application.Interfaces;
using ArtMin.Application.ViewModels;
using ArtMin.Domain.Entities;
using ArtMin.Domain.Interfaces.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace ArtMin.Application.Services
{
    public class JogadorAppService : IJogadorAppService
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadorAppService(IJogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }

        public IEnumerable<JogadorViewModel> GetAll()
        {
            var jogadorViewModel = Mapper.Map<IEnumerable<Jogador>, IEnumerable<JogadorViewModel>>(_jogadorRepository.GetAll());

            return jogadorViewModel;
        }

        public void Create(JogadorViewModel jogadorViewModel)
        {
            var jogador = Mapper.Map<JogadorViewModel, Jogador>(jogadorViewModel);
            ComparaCpf(jogadorViewModel);

            if (jogadorViewModel.ComparaCpf)
            {
                throw new ArgumentException("CPF já cadastrado na base de dados.");
            }
            _jogadorRepository.Add(jogador);            
        }

        public JogadorViewModel GetById(int id)
        {
            var jogador = _jogadorRepository.GetById(id);
            var jogadorViewModel = Mapper.Map<Jogador, JogadorViewModel>(jogador);

            return jogadorViewModel;
        }

        public void Edit(JogadorViewModel jogadorViewModel)
        {
            var jogador = _jogadorRepository.GetById(jogadorViewModel.JogadorId);
            jogador.Alterar(jogadorViewModel.Nome, jogadorViewModel.Email, jogadorViewModel.Goleiro, jogadorViewModel.Admin, jogadorViewModel.Ativo);
            _jogadorRepository.Update(jogador);
        }

        public void Delete(int id)
        {
            var jogador = _jogadorRepository.GetById(id);
            _jogadorRepository.Remove(jogador);

        }

        private bool ComparaCpf(JogadorViewModel jogador)
        {
            var cpfLimpo = jogador.Cpf.Replace(".", "").Replace("-", "");
            var validacaoCpf = _jogadorRepository.GetAll();
            jogador.ComparaCpf = false;

            foreach (var item in validacaoCpf)
            {
                if (cpfLimpo == item.Cpf)
                {
                    jogador.ComparaCpf = true;
                }
            }

            return jogador.ComparaCpf;
        }
    }
}
