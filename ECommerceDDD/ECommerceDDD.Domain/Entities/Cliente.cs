using ECommerceDDD.Domain.Core;
using ECommerceDDD.Domain.ValueObjects;

namespace ECommerceDDD.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public DateTime DataNascimento { get; private set; }

        // Construtor exigido pelo EF Core
        protected Cliente() { }

        public Cliente(string nome, Email email, DateTime dataNascimento)
        {
            DefinirNome(nome);
            DefinirEmail(email);
            DefinirDataNascimento(dataNascimento);
        }

        public void DefinirNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome inválido.");

            Nome = nome.Trim();
        }

        public void DefinirEmail(Email email)
        {
            if (email == null)
                throw new ArgumentException("Email inválido.");

            Email = email;
        }

        public void DefinirDataNascimento(DateTime data)
        {
            if (data > DateTime.Now)
                throw new ArgumentException("Data de nascimento inválida.");

            DataNascimento = data;
        }
    }
}
