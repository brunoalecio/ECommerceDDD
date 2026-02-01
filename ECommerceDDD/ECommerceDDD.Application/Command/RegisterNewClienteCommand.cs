using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace ECommerceDDD.Application.Command
{
    public class RegisterNewClienteCommand : IRequest<bool>
    {
        public string Nome { get; }
        public string Email { get; }
        public DateTime DataNascimento { get; }

        public RegisterNewClienteCommand(string nome, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }
    }
}

