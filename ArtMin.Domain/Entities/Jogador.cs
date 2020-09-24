using System;

namespace ArtMin.Domain.Entities
{
    public class Jogador
    {
        public int JogadorId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; set; }
        public bool Goleiro { get; private set; }
        public bool Admin { get; private set; }
        public bool Ativo { get; private set; }

        public void Alterar(string nome, string email, string cpf, bool goleiro, bool admin, bool ativo)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Goleiro = goleiro;
            Admin = admin;
            Ativo = ativo;
        }
    }
}
