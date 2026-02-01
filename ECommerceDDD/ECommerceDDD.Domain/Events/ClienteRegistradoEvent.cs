using MediatR;

namespace ECommerceDDD.Domain.Events
{
    public class ClienteRegistradoEvent : DomainEvent
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public DateTime DataNascimento { get; }

        public ClienteRegistradoEvent(
            Guid id,
            string nome,
            string email,
            DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }
    }
}
