namespace ArtMin.Domain.Entities
{
    public class Jogador
    {
        public int JogadorId { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public bool Goleiro { get; private set; }
        public bool Admin { get; private set; }
        public bool Ativo { get; private set; }


        public void Alterar(string nome, string email, bool goleiro, bool admin, bool ativo)
        {
            Nome = nome;
            Email = email;
            Goleiro = goleiro;
            Admin = admin;
            Ativo = ativo;
        }
    }
}
