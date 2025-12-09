using ECommerceDDD.Domain.Entities;

namespace ECommerceDDD.Domain.Events
{
    public class ClienteRegistradoEvent : DomainEvent
    {
        public string Nome { get; }
        public string Email { get; }
        public DateTime DataNascimento { get; }

        public ClienteRegistradoEvent(Cliente cliente)
            : base(cliente.Id)
        {
            Nome = cliente.Nome;
            Email = cliente.Email.Address;
            DataNascimento = cliente.DataNascimento;
        }
    }
}
