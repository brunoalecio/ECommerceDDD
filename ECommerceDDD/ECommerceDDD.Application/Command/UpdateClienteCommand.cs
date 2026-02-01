using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace ECommerceDDD.Application.Command
{
    public class UpdateClienteCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public string Nome { get; }
        public string Email { get; }
        public DateTime DataNascimento { get; }

        public UpdateClienteCommand(Guid id, string nome, string email, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }
    }
}

